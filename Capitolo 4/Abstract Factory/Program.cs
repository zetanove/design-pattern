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
        static IDatabaseAbstractFactory dbFactory;
        static void Main(string[] args)
        {
            string connectionString = "Server=myServerAddress;Database=myDataBase;Trusted_Connection=True;";
            if (args == null || args.Length==0 )
            {
                dbFactory=DatabaseAbstractFactory.GetFactory("sql");
            }
            else if (args.Length > 1)
            {
                dbFactory = DatabaseAbstractFactory.GetFactory(args[0]);
            }

            IDbConnection conn = dbFactory.CreateConnection(connectionString);
            var cmd = dbFactory.CreateCommand(conn, "SELECT * FROM Clienti");
            cmd.Execute();
        }
    }
}
