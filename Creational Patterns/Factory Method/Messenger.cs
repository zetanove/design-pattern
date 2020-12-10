using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_Method
{
    public abstract class Messenger
    {
        public enum AlertKind
        {
            Email,
            SMS
        }

        private static Dictionary<AlertKind, Messenger> _factories;

        static Messenger()
        {
            //_factories = new Dictionary<AlertKind, Messenger>
            //{
            //    { AlertKind.Email , new EmailMessenger() },
            //    { AlertKind.SMS, new SMSMessenger() }
            //};

            _factories = new Dictionary<AlertKind, Messenger>();
            foreach (AlertKind kind in Enum.GetValues(typeof(AlertKind)))
            {
                string name = "Factory_Method." + Enum.GetName(typeof(AlertKind), kind) + "Messenger";
                Type type = Type.GetType(name);
                var messenger = (Messenger)Activator.CreateInstance(type);
                _factories.Add(kind, messenger);
            }
        }

        public static Messenger GetMessenger(AlertKind kind)
        {
            return _factories[kind];
        }

        public abstract Alert CreateAlert(string title, string msg, string recipient);

        public void SendAlert(Alert alert)
        {
            //Invio dell'alert
            Console.WriteLine("Invio dell'alert " + alert.ToString());
            alert.Send();
        }
    }
}
