using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator
{
    public interface ChatMediator
    {
        void Register(User user);

        void SendMessage(string from, string message, string toUser);
    }

    public abstract class User
    {
        protected ChatMediator chat;

        public string Nickname { get; set; }
        
        

        public void SetChat(ChatMediator chat)
        {
            this.chat = chat;
            this.Send("entrato in chat!", null);
        }

        public abstract void Notify(string from, string msg);
        public abstract void Send(string msg, string user);
    }

    public class ChatRoom : ChatMediator
    {
        private List<User> users;

        public ChatRoom()
        {
            users=new List<User>();
        }

        public void Register(User user)
        {
            if (!users.Contains(user))
            {
                users.Add(user);
                user.SetChat(this);
            }
        }

        private User FindUser(string nick)
        {
            foreach (var user in users)
            {
                if (user.Nickname == nick)
                    return user;
            }

            return null;
        }

        private void BroadcastMessage(string from, string msg)
        {
            foreach (var user in users)
            {
                if(user.Nickname!=from)
                    user.Notify(from, msg);
            }
        }

        public void SendMessage(string from, string message, string toUser)
        {
            User user = FindUser(toUser);
            if (user == null)
            {
                BroadcastMessage(from, message);
            }
            else user.Notify(from, message);
        }
    }

    public class ChatUser : User
    {
        public ChatUser(string nickName)
        {
            this.Nickname = nickName;
        }

        public override void Notify(string from, string msg)
        {
            Console.WriteLine(this.Nickname+ " ha ricevuto il messaggio: ## "+Environment.NewLine +msg+" da "+from);
        }

        public override void Send(string msg, string user)
        {
            //string text = this.Nickname + " invia il messaggio: " + Environment.NewLine + msg;
            //if (user != null)
            //    text += Environment.NewLine+" a: " + user;
            //Console.WriteLine(text);
            this.chat.SendMessage(Nickname,msg, user);
        }
    }
}
