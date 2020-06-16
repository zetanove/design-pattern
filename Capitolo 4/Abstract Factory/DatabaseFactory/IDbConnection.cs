namespace Abstract_Factory.DatabaseFactory
{
    interface IDbConnection
    {
        void Open();
        void Close();
    }
}
