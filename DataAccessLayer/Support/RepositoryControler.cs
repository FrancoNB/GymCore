using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;

namespace DataAccessLayer.Support
{
    public abstract class RepositoryControler : RepositoryConnection
    {
        protected List<MySqlParameter> parameters;

        protected int ExecuteNonQuery(string transaction)
        {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();

                    using (var command = new MySqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = transaction;
                        command.CommandType = CommandType.Text;

                        foreach (MySqlParameter parameter in parameters)
                        {
                            command.Parameters.Add(parameter);
                        }

                        parameters.Clear();

                        return command.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException ex)
            {
                throw new RepositoryException(ex.Message, ex.Number);
            }
        }

        protected DataTable ExecuteReader(string transaction)
        {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();

                    using (var command = new MySqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = transaction;
                        command.CommandType = CommandType.Text;

                        foreach (MySqlParameter parameter in parameters)
                        {
                            command.Parameters.Add(parameter);
                        }

                        parameters.Clear();

                        using (var reader = command.ExecuteReader())
                        {
                            using (var table = new DataTable())
                            {
                                table.Load(reader);

                                return table;
                            }
                        }
                    }
                }
            } 
            catch(MySqlException ex)
            {
                throw new RepositoryException(ex.Message, ex.Number);
            }  
        }
    }
}
