using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            ITarget target = new Adapter();
            Test(target);
        }

        static void Test(ITarget t)
        {
            t.Request();
        }
    }

    interface ITarget
    {
        void Request();
    }


    class Adapter : Adaptee, ITarget
    {
        public Adapter()
        {
            
        }

        public void Request()
        {
            base.SpecificRequest();
        }
    }

    class Adaptee
    {
        public void SpecificRequest()
        {
            Console.WriteLine("Adaptee.SpecificRequest");
        }
    }
}
