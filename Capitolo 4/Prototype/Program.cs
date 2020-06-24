
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            Persona p1 = new Persona("Antonio", "Pelleriti");
            p1.Contatti.Add(new Contatto(ContactType.Email, "antonio.pelleriti@gmail.com"));

            Console.WriteLine(p1);

            Persona p2 = p1;
            p2.SetNome( "Anto");
            Console.WriteLine(p2);
            Console.WriteLine(p1);


            Persona p3 = (Persona)p1.Clone();
            p3.Contatti[0].Text = "anto@outlook.com";
            Console.WriteLine(p1);
            Console.WriteLine(p3);


            Bullet b = new Bullet("#ff0000", 1);
            PrototypeManager manager = new PrototypeManager();
            manager.AddPrototype("red", b);

            Bullet clone1 = (Bullet) manager.GetPrototype("red");
            Bullet clone2 = (Bullet)manager.GetPrototype("red");
            Bullet clone3 = (Bullet)manager.GetPrototype("red");

            Console.Read();
        }
    }
}
