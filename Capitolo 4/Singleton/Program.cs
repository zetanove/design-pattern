using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            Singleton s = null;

            //s = new Singleton(); //errore
            s = Singleton.GetInstance();
            var s2= Singleton.GetInstance();

        }
    }
}
