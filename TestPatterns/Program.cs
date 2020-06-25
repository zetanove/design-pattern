using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prototype;

namespace TestPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            Persona p1 = new Persona("antonio","pelleriti");

            Persona p2 = (Persona)p1.Clone();
            p2.SetNome("Matilda");

            Console.WriteLine(p1);
            Console.WriteLine(p2);
        }
    }
}
