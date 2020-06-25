using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_Method
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "messaggio di avviso";
            string title = "Warning";
            string recipient = "antonio@dominio.com";



            Messenger messenger = null;
            if (recipient.Contains("@"))
            {
                messenger = Messenger.GetMessenger(Messenger.AlertKind.Email);
            }
            else messenger = Messenger.GetMessenger(Messenger.AlertKind.SMS);

            Alert alert=messenger.CreateAlert(title, text, recipient);
            messenger.SendAlert(alert);

            recipient = "+39123456789";
            if (recipient.Contains("@"))
            {
                messenger = Messenger.GetMessenger(Messenger.AlertKind.Email);
            }
            else messenger = Messenger.GetMessenger(Messenger.AlertKind.SMS);

            alert = messenger.CreateAlert(title, text, recipient);
            messenger.SendAlert(alert);

            Console.ReadLine();
        }
    }
}
