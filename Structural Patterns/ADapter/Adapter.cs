using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    interface ITarget
    {
        void Request();
    }


    class Adapter: ITarget
    {
        public Adapter(Adaptee aee)
        {
            adaptee = aee;
        }

        private Adaptee adaptee;

        public void Request()
        {
            adaptee.SpecificRequest();
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
