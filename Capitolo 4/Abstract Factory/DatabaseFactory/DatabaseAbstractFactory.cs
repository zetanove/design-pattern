using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_Factory.DatabaseFactory
{
    interface IDatabaseAbstractFactory
    {
        IDbConnection CreateConnection(string connString);
        IDbCommand CreateCommand(IDbConnection connection, string sql);
    }
}
