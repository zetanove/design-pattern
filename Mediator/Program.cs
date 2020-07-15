using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator
{
    class Program
    {
        static void Main(string[] args)
        {
            ChatRoom room = new ChatRoom();
            User user1=new ChatUser("Antonio");
            User user2 = new ChatUser("Matilda");
            User user3 = new ChatUser("Caterina");

            room.Register(user1);
            room.Register(user2);
            room.Register(user3);


            user1.Send("Prova 1", null); //invia a tutti
            user2.Send("Ciao", "Antonio"); //invia solo ad Antonio

            Console.ReadLine();
        }
    }
}
