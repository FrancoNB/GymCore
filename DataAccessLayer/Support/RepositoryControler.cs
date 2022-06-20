using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace DataAccessLayer.Support
{
    public abstract class RepositoryControler : RepositoryConnection
    {
        protected List<MySqlParameter> parameters;

        protected async Task<int> ExecuteNonQueryAsync(string transaction)
        {
            OpenConnection();

            try
            {
                using (var command = new MySqlCommand())
                {
                    command.Connection = GetConnection();
                    command.CommandText = transaction;
                    command.CommandType = CommandType.Text;

                    foreach (MySqlParameter parameter in parameters)
                    {
                        command.Parameters.Add(parameter);
                    }

                    parameters.Clear();

                    return await command.ExecuteNonQueryAsync();
                }
            }
            catch (MySqlException ex)
            {
                throw new RepositoryException("[" + ex.Number + "] " + ex.Message + "\n\n" + ex.StackTrace, ex.Number);
            }
            finally
            {
                CloseConnection();
            }
        }

        protected async Task<DataTable> ExecuteReaderAsync(string transaction)
        {
            try
            {
                OpenConnection();

                using (var command = new MySqlCommand())
                {
                    command.Connection = GetConnection();
                    command.CommandText = transaction;
                    command.CommandType = CommandType.Text;

                    if (parameters != null)
                    {
                        foreach (MySqlParameter parameter in parameters)
                        {
                            command.Parameters.Add(parameter);
                        }

                        parameters.Clear();
                    }

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        using (var table = new DataTable())
                        {
                            table.Load(reader);

                            return table;
                        }
                    }
                }
            } 
            catch(MySqlException ex)
            {
                throw new RepositoryException("[" + ex.Number + "] " + ex.Message + "\n\n" + ex.StackTrace, ex.Number);
            }  
            finally
            {
                CloseConnection();
            }
        }
    }
}
