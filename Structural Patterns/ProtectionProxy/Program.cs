using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;

namespace ProtectionProxy
{
    class Program
    {
        static void Main(string[] args)
        {
            IBankAccount bank = new ProtectionProxyAccount("pippo", "pluto");
            try
            {
                string numero = bank.GetNumeroConto("pippo");
                bank.StampaSaldo(numero);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            bank = new ProtectionProxyAccount("antonio", "matilda");
            try
            {
                string numero = bank.GetNumeroConto("antonio");
                bank.StampaSaldo(numero);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }

    interface IBankAccount
    {
        string GetNumeroConto(string user);
        string StampaSaldo(string numeroConto);
    }

    class ProtectionProxyAccount: IBankAccount
    {
        private bool isAuthenticated;
        private string username;
        private RealAccount account;
        private string numeroConto;

        public ProtectionProxyAccount(string username, string pwd)
        {
            this.username = username;
            isAuthenticated = new SecurityManager().CheckUser(username, pwd);
            if (isAuthenticated)
            {
                account = new RealAccount();
            }
        }

        public string GetNumeroConto(string user)
        {
            if (isAuthenticated)
            {
                return account.GetNumeroConto(user);
            }
            Console.WriteLine("non autenticato");
            return null;
        }

        public string StampaSaldo(string numeroConto)
        {
            if (isAuthenticated)
            {
                return account.StampaSaldo(numeroConto);
            }
            throw new AuthenticationException();
        }
    }

    class SecurityManager
    {
        public bool CheckUser(string user, string pwd)
        {
            //simula login
            Console.WriteLine("Verifico utente "+user);
            if (user == "antonio" && pwd == "matilda")
                return true;
            else return false;
        }
    }

    class RealAccount : IBankAccount
    {
        public string GetNumeroConto(string user)
        {
            Console.WriteLine("ricavo numero conto di " + user);
            //ricavo il numero del conto dell'utente
            if (user == "antonio")
                return "123";

            Console.WriteLine("ERRORE! non autenticato" );
            return null;
        }

        public string StampaSaldo(string numeroConto)
        {
            //ricavo il saldo del conto dal database
            if (numeroConto == "123")
            {
                return "-1000";
            }
            throw new AuthenticationException();
        }
    }

}
