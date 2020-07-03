using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    class Program
    {
        static void Main(string[] args)
        {
            EmailSettings settings = new EmailSettings();
            Messenger messenger=new Messenger(settings);
            messenger.SendMail("info@antoniopelleriti.it", new []{"dest@dominio.it"}, null, null, 
                "Oggetto", 
                "Corpo del messaggio", 
                "allegato.txt");
        }
    }

    class EmailSettings
    {
        public int Port { get; set; }
        public string Server { get; set; }

        public bool UseSSL { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string FromAddress { get; set; }

        public string FromName { get; set; }

        public bool DeliveryNotification { get; set; }
    }

    class Messenger
    {
        private EmailSettings settings;
        private Logger logger;

        public Messenger(EmailSettings settings)
        {
            this.settings = settings;
            logger = new Logger();
        }
        
        public void SendMail( string mittente, string[] destinatari, string[] cc, string[] bcc, string subject, string body, params string[] attachments)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true;
                mail.From = new MailAddress(settings.FromAddress, settings.FromName);

                if (destinatari != null && destinatari.Any())
                {
                    foreach (var dest in destinatari)
                    {
                        if (dest != null)
                            mail.To.Add(dest.Trim());
                    }
                }

                if (cc != null && cc.Any())
                {
                    foreach (var addr in cc)
                    {
                        if (addr != null)
                            mail.CC.Add(addr.Trim());
                    }
                }

                if (bcc != null && bcc.Any())
                {
                    foreach (var addr in bcc)
                    {
                        if (addr != null)
                            mail.Bcc.Add(addr.Trim());
                    }
                }

                if (attachments != null)
                {
                    foreach (string attach in attachments)
                        mail.Attachments.Add(new Attachment(attach));
                }

                if (settings.DeliveryNotification)
                {
                    mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnSuccess | DeliveryNotificationOptions.OnFailure;
                    mail.Headers.Add("Disposition-Notification-To", settings.FromAddress);
                }

                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Host = settings.Server;
                smtpClient.Port = settings.Port;
                smtpClient.EnableSsl = settings.UseSSL;
                if (!string.IsNullOrEmpty(settings.Username) || !string.IsNullOrEmpty(settings.Password))
                {
                    NetworkCredential cred = new NetworkCredential();
                    cred.UserName = settings.Username;
                    cred.Password = settings.Password;
                    smtpClient.Credentials = cred;
                }
                smtpClient.Send(mail);
                mail.Attachments.Dispose();
            }
            catch (Exception ex)
            {
                logger.Log(ex.ToString());
                throw ex;
            }
        }
    }

    internal class Logger
    {
        internal void Log(string v)
        {
            throw new NotImplementedException();
        }
    }
}
