using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_Factory.DatabaseFactory
{
    class SQLServerFactory : IDatabaseAbstractFactory
    {
        public IDbCommand CreateCommand(IDbConnection connection, string sql)
        {
            return new SqlServerCommand(connection, sql);
        }

        public IDbConnection CreateConnection(string connString)
        {
            return new SqlServerConnection(connString);
        }
    }
}
