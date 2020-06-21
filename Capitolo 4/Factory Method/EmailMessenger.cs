namespace Factory_Method
{
    public class EmailMessenger : Messenger
    {
        public override Alert CreateAlert(string title, string msg, string recipient)
        {
            EmailAlert alert = new EmailAlert(recipient, title, msg, true);
            return alert;
        }
    }
}
