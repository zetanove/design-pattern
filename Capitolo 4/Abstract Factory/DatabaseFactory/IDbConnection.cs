namespace Abstract_Factory.DatabaseFactory
{
    interface IDbConnection
    {
        string ConnectionString { get; set; }
        void Open();
        void Close();
    }
}
