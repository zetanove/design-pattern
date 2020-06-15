using Abstract_Factory.DatabaseFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_Factory
{
    class Client
    {
        static IDatabaseAbstractFactory factory;
        static void Main(string[] args)
        {
            if (args == null || (args.Length > 1 && args[0] == "sql"))
            {
                factory = new SQLServerFactory();                
            }

            IDbConnection conn = factory.CreateConnection(args[1]);
            var cmd = factory.CreateCommand(conn, "SELECT * FROM Clienti");
            cmd.Execute();
        }
    }
}
