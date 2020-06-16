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

    abstract class DatabaseAbstractFactory : IDatabaseAbstractFactory
    {
        public abstract IDbCommand CreateCommand(IDbConnection connection, string sql);
        public abstract IDbConnection CreateConnection(string connString);

        public static IDatabaseAbstractFactory GetFactory(string kind)
        {
            if(kind=="sql")
                return new SQLServerFactory();

            throw new Exception("tipo factory non specificato o non implementato");
        }
    }
}
