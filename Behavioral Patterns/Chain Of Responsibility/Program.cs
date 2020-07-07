using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chain_Of_Responsibility
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger console=new ConsoleLogger(LogLevel.DEBUG);
            Logger error=new ErrorLogger(LogLevel.ERROR);

            console.SetNextHandler(error);

            Logger chain = console;


            chain.Log("Questa è una informazione", LogLevel.DEBUG);
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

        void SetNextHandler(Logger next);
    }

    public abstract class AbstractLogger: Logger
    {
        private Logger nextHandler;
        protected LogLevel _level;

        public AbstractLogger(LogLevel level)
        {
            this._level = level;
        }

        public void SetNextHandler(Logger next)
        {
            this.nextHandler = next;
        }

        public void Log(string msg, LogLevel level)
        {
            if (this._level <= level)
            {
                TraceLog(msg);
            }
            
            if (nextHandler != null)
            {
                nextHandler.Log(msg, level);
            }
        }

        protected abstract void TraceLog(string message);

    }

    public class ConsoleLogger : AbstractLogger
    {
        public ConsoleLogger(LogLevel level): base(level)
        {
        }

        protected override void TraceLog(string message)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(this._level+": "+message);
        }
    }

    public class ErrorLogger : AbstractLogger
    {
        public ErrorLogger(LogLevel level) : base(level)
        {
        }

        protected override void TraceLog(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(this._level + ": " + message);
        }
    }
}
