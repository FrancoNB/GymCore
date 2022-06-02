using DataAccessLayer.Entities;
using DataAccessLayer.InterfaceRepositories;
using DataAccessLayer.Support;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class UsersRepository : RepositoryControler, IUsersRepository
    {
        private readonly string insert;
        private readonly string update;
        private readonly string updateLastConnection;
        private readonly string delete;
        private readonly string selectAll;
        private readonly string selectByUserAndPass;
        private readonly string selectMaxId;

        public UsersRepository()
        {
            this.insert = "INSERT INTO Users (RegisterDate, Type, Username, Password, LastConnection) VALUES (@registerDate, @type, @username, @password, @lastConnection)";
            this.update = "UPDATE Users SET RegisterDate = @registerDate, Type = @type, Username = @username, Password = @password, LastConnection = @lastConnection WHERE IdUsers = @idUsers";
            this.updateLastConnection = "UPDATE Users SET LastConnection = @lastConnection WHERE IdUsers = @idUsers";
            this.delete = "DELETE FROM Users WHERE IdUsers = @idUsers";
            this.selectAll = "SELECT * FROM Users";
            this.selectByUserAndPass = "SELECT * FROM Users WHERE Username = @username AND Password = @password";
            this.selectMaxId = "SELECT Max(IdUsers) as lastId FROM Users";
        } 

        public async Task<int> Insert(Users entity)
        {
            parameters = new List<MySqlParameter>
            {
                new MySqlParameter("@registerDate", entity.RegisterDate.Date),
                new MySqlParameter("@type", entity.Type),
                new MySqlParameter("@username", entity.Username),
                new MySqlParameter("@password", entity.Password),
                new MySqlParameter("@lastConnection", entity.LastConnection)
            };

            return await ExecuteNonQueryAsync(insert);
        }

        public async Task<int> Update(Users entity)
        {
            parameters = new List<MySqlParameter>
            {
                new MySqlParameter("@registerDate", entity.RegisterDate),
                new MySqlParameter("@type", entity.Type),
                new MySqlParameter("@username", entity.Username),
                new MySqlParameter("@password", entity.Password),
                new MySqlParameter("@lastConnection", entity.LastConnection),
                new MySqlParameter("@idUsers", entity.IdUsers)
            };

            return await ExecuteNonQueryAsync(update);
        }

        public async Task<int> UpdateLastConnection(DateTime lastConnection, int idUser)
        {
            parameters = new List<MySqlParameter>
            {
                new MySqlParameter("@lastConnection", lastConnection),
                new MySqlParameter("@idUsers", idUser)
            };

            return await ExecuteNonQueryAsync(updateLastConnection);
        }

        public async Task<int> Delete(int id)
        {
            parameters = new List<MySqlParameter>
            {
                new MySqlParameter("@idUsers", id)
            };

            return await ExecuteNonQueryAsync(delete);
        }

        public async Task<IEnumerable<Users>> GetAll()
        {
            using (var table = await ExecuteReaderAsync(selectAll))
            {
                var list = new List<Users>();

                foreach (DataRow row in table.Rows)
                {
                    list.Add(new Users()
                    {
                        IdUsers = Convert.ToInt32(row["IdUsers"]),
                        RegisterDate = Convert.ToDateTime(row["RegisterDate"]),
                        Type = row["Type"].ToString(),
                        Username = row["Username"].ToString(),
                        Password = row["Password"].ToString(),
                        LastConnection = Convert.ToDateTime(row["LastConnection"])
                    });
                }

                return list;
            }
        }

        public async Task<Users> GetUser(string username, string password)
        {
            parameters = new List<MySqlParameter>
            {
                new MySqlParameter("@username", username),
                new MySqlParameter("@password", password),
            };

            using (var table = await ExecuteReaderAsync(selectByUserAndPass))
            {
                if (table.Rows.Count > 0)
                {
                    return new Users
                    {
                        IdUsers = Convert.ToInt32(table.Rows[0]["IdUsers"]),
                        RegisterDate = Convert.ToDateTime(table.Rows[0]["RegisterDate"]),
                        Type = table.Rows[0]["Type"].ToString(),
                        Username = table.Rows[0]["Username"].ToString(),
                        Password = table.Rows[0]["Password"].ToString(),
                        LastConnection = Convert.ToDateTime(table.Rows[0]["LastConnection"])
                    };
                } else
                    return null;
            }
        }
        public async Task<int> GetLastId()
        {
            using (var table = await ExecuteReaderAsync(selectMaxId))
            {
                if (table.Rows.Count > 0)
                    return Convert.ToInt32(table.Rows[0]["lastId"]);
                else
                    return 0;
            }
        }
    }
}
