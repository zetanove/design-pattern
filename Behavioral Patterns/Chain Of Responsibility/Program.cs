using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chain_Of_Responsibility
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger consoleLogger = new ConsoleLogger(LogLevel.DEBUG);
            Logger fileLogger = new FileLogger("log.txt", LogLevel.INFO);
            Logger warningLogger = new WarningLogger(LogLevel.WARNING);
            Logger emailLogger = new MailLogger("test@email.it", LogLevel.ERROR);

            consoleLogger.SetNextHandler(fileLogger);
            fileLogger.SetNextHandler(warningLogger);
            warningLogger.SetNextHandler(emailLogger);

            consoleLogger
                .SetNextHandler(fileLogger)
                .SetNextHandler(warningLogger)
                .SetNextHandler(emailLogger);

            consoleLogger = new ConsoleLogger(LogLevel.DEBUG,
                                new FileLogger("log.txt", LogLevel.INFO,
                                    new WarningLogger(LogLevel.WARNING,
                                        new MailLogger("test@email.it", LogLevel.ERROR)
                                    )
                                )
                            );
            Logger chain = consoleLogger;

            chain.Log("Questa è una informazione", LogLevel.DEBUG);
            chain.Log("log info", LogLevel.INFO);
            chain.Log("log di un avviso", LogLevel.WARNING);
            chain.Log("Questo è un errore", LogLevel.ERROR);
        }
    }

    public enum LogLevel
    {
        DEBUG,
        INFO,
        WARNING,
        ERROR,
    }

    public interface Logger
    {
        void Log(string msg, LogLevel level);

        Logger SetNextHandler(Logger next);
    }

    public abstract class AbstractLogger: Logger
    {
        private Logger nextHandler;
        protected LogLevel _level;

        public AbstractLogger(LogLevel level): this(level, null)
        {
        }

        public AbstractLogger(LogLevel level, Logger next)
        {
            this._level = level;
            this.nextHandler = next;
        }

        public Logger SetNextHandler(Logger next)
        {
            this.nextHandler = next;
            return next;
        }

        public void Log(string msg, LogLevel level)
        {
            if (this._level == level)
            {
                CreateLog(msg);
            }
            else if (nextHandler != null)
            {
                nextHandler.Log(msg, level);
            }
        }

        protected abstract void CreateLog(string message);

    }

    public class ConsoleLogger : AbstractLogger
    {
        public ConsoleLogger(LogLevel level) : this(level, null)
        {
        }

        public ConsoleLogger(LogLevel level, Logger next) : base(level, next)
        {
        }


        protected override void CreateLog(string message)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(this.GetType().Name+" - "+this._level+": "+message);
        }
    }

    public class WarningLogger : AbstractLogger
    {
        public WarningLogger(LogLevel level, Logger next) : base(level, next)
        {
        }

        public WarningLogger(LogLevel level) : this(level, null)
        {
        }

        protected override void CreateLog(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(this.GetType().Name + " - " + this._level + ": " + message);
        }
    }

    public class FileLogger : AbstractLogger
    {
        private string filePath;

        public FileLogger(string path, LogLevel level, Logger next) : base( level, next)
        {
            filePath = path;
        }

        public FileLogger(string path, LogLevel level) : this(path, level, null)
        {
        }

        protected override void CreateLog(string message)
        {
            Console.WriteLine(this.GetType().Name + " - " + this._level + ": " + message);
            File.AppendAllText(filePath, message);
        }
    }

    public class MailLogger : AbstractLogger
    {
        private string _email;

        public MailLogger(string email, LogLevel level, Logger next) : base(level, next)
        {
            _email = email;
        }

        public MailLogger(string email, LogLevel level) : this(email, level, null)
        {
        }

        protected override void CreateLog(string message)
        {
            Console.ForegroundColor = ConsoleColor.White;            
            Console.WriteLine(this.GetType().Name + " - " + this._level + ": " + message); 
            Console.WriteLine("invio mail di log a: " + _email);
        }
    }
}
