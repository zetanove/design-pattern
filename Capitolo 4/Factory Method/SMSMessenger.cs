namespace Factory_Method
{
    public class SMSMessenger : Messenger
    {
        public override Alert CreateAlert(string title, string msg, string recipient)
        {
            SMSAlert alert = new SMSAlert(recipient, title+"-"+msg);
            return alert;
        }
    }
}
