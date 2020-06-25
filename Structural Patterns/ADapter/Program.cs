using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            Adaptee aee = new Adaptee();
            //Test(aee); //non va, serve un adattatore

            ITarget target = new Adapter(aee);

            Test(target);
        }

        static void Test(ITarget t)
        {
            t.Request();
        }
    }
}
