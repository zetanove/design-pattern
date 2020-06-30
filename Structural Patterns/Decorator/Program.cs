using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            ILogger log=new ConsoleLog()
        }
    }

    public interface ILogger
    {
        void Log(String msg);
    }

    public abstract class Logger : ILogger
    {
        public ILogger Component { get; set; }
        public abstract void Log(string msg);
        
        public void SetComponent(ILogger il)
        {
            Component = il;
        }
    }

    public class ConsoleLog : Logger
    {
        public override void Log(string msg)
        {
            this.Component.Log(msg);
            Console.WriteLine(msg);
        }
    }

    class FileLog : Logger
    {
        public override void Log(string msg)
        {
            this.Component.Log(msg);
            //throw new NotImplementedException();
        }


    }
}
