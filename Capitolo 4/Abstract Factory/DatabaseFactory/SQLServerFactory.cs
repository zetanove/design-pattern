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
            throw new NotImplementedException();
        }

        public IDbConnection CreateConnection(string connString)
        {
            return new SqlConnection(connString);
        }
    }
}
