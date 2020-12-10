using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_Factory.DatabaseFactory
{
    class SqlServerCommand: IDbCommand
    {
        private IDbConnection connection { get; set; }
        private string sql { get; set; }

        public SqlServerCommand(IDbConnection conn, string sql)
        {
            this.connection = conn;
            this.sql = sql;
        }
        public object Execute()
        {
            connection.Open();
            Console.WriteLine("Esecuzione: "+sql);
            connection.Close();

            return null; //restituisce eventuali risultati
        }
    }
}
