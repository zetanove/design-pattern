using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_Factory.DatabaseFactory
{
    class SqlServerConnection : IDbConnection
    {
        private string connectionString { get; set; }

        public SqlServerConnection(String str)
        {
            connectionString = str;
        }
        public void Close()
        {
            Console.WriteLine("Close connection");
        }

        public void Open()
        {
            Console.WriteLine("Open connection: "+connectionString);
        }
    }
}
