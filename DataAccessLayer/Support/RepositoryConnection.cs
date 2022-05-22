using MySql.Data.MySqlClient;

namespace DataAccessLayer.Support
{
    public abstract class RepositoryConnection
    {
        private static readonly string _host = "localhost";
        private static readonly string _port = "5859";
        private static readonly string _username = "root";
        private static readonly string _password = "260999fnb";
        private static readonly string _database = "GymCore";

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
                        _connection = new MySqlConnection("Server=" + _host + ";Port=" + _port + ";Uid=" + _username + ";Pwd=" + _password + ";Database=" + _database);
                }
            }

            return _connection;
        }

        protected static void BeginTransaction()
        {
            if (_transaction != null)
            {
                lock (_lock)
                {
                    if (_transaction == null)
                        _transaction = GetConnection().BeginTransaction();
                }
            }       
        }

        protected static void Commit()
        {
            if (_transaction != null)
                return;

            _transaction.Commit();
            _transaction = null;
        }

        protected static void RollBack()
        {
            if (_transaction != null)
                return;

            _transaction.Rollback();
            _transaction = null;
        }
    }
}
