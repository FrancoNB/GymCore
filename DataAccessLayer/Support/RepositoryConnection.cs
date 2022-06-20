using MySql.Data.MySqlClient;
using System.Configuration;

namespace DataAccessLayer.Support
{
    public abstract class RepositoryConnection
    {
        private static MySqlConnection _connection;
        private static MySqlTransaction _transaction;

        private static readonly object _lock = new object();

        protected static MySqlConnection GetConnection()
        {
            if (_connection == null)
            {
                lock (_lock)
                {
                    if (_connection == null)
                        _connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnectionString"].ConnectionString);
                }
            }

            return _connection;
        }

        protected static void OpenConnection()
        {
            lock (_lock)
            {
                if (GetConnection().State != System.Data.ConnectionState.Open)
                    GetConnection().Open();
            }
        }

        protected static void CloseConnection()
        {
            lock (_lock)
            {
                if (GetConnection().State == System.Data.ConnectionState.Open)
                {
                    if (_transaction == null)
                    {
                        GetConnection().Close();
                    }
                }                
            }
        }

        public static void BeginTransaction()
        {
            lock (_lock)
            {
                if (_transaction == null)
                {
                    OpenConnection();

                    _transaction = GetConnection().BeginTransaction();
                }
            }
        }

        public static void Commit()
        {
            lock (_lock)
            {
                if (_transaction != null)
                {
                    _transaction.Commit();
                    _transaction = null;

                    CloseConnection();
                }
            }
        }

        public static void RollBack()
        {
            lock (_lock)
            {
                if (_transaction != null)
                {
                    _transaction.Rollback();
                    _transaction = null;

                    CloseConnection();
                }
            }
        }
    }
}
