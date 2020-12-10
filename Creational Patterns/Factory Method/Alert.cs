using System;

namespace Factory_Method
{
    public abstract class Alert
    {
        public abstract void Send();
    }

    public class SMSAlert : Alert
    {
        private string number;
        private string text;

        public SMSAlert(string n, string t)
        {
            this.number = n;
            this.text = t;
        }

        public override void Send()
        {
            Console.WriteLine("Invio di SMS al numero: " + number);
        }
    }

    public class EmailAlert: Alert
    {
        private string address;
        private string body;
        private string subject;
        private bool isHtml;

        public EmailAlert(string addr, string subj, string text, bool html)
        {
            this.address = addr;
            this.subject = subj;
            this.body = text;
            this.isHtml = html;
        }

        public override void Send()
        {
            Console.WriteLine("Invio di Email a: " +address);
        }
    }
}