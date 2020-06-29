using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            AbstractLogger logger = null;
            try
            {
                int b = 0;
                int i = 1 / b;
            }
            catch(Exception ex)
            {
                LogError err = new LogError();
                logger = new FileLogger(".\\log.txt");
                err.SetLogger(logger);
                err.Log(ex.Message);

                logger = new ConsoleLogger();
                err.SetLogger(logger);
                err.Log(ex.Message);
            }


            Console.ReadLine();
        }
    }

    interface LogEvent
    {
        void Log(string str);
        void SetLogger(AbstractLogger logger);
    }

    public class LogError : LogEvent
    {
        private AbstractLogger logger;
        public void Log(string str)
        {
            if(logger!=null)
                logger.LogError(str);
        }

        public void SetLogger(AbstractLogger logger)
        {
            this.logger = logger;
        }
    }

    public abstract class AbstractLogger
    {
        public abstract void LogError(string msg);             
    }

    public class FileLogger : AbstractLogger
    {
        string path;
        public FileLogger(string path)
        {
            this.path = path;
        }

        public override void LogError(string msg)
        {
            using (var sw = File.AppendText(path))
            {
                sw.WriteLine(msg);
            }
        }
    }

    public class ConsoleLogger : AbstractLogger
    {
        public ConsoleLogger() { }
        

        public override void LogError(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
