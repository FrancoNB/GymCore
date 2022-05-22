using DataAccessLayer.Entities;
using DataAccessLayer.InterfaceRepositories;
using DataAccessLayer.Support;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

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

        public UsersRepository()
        {
            this.insert = "INSERT INTO Users VALUES (@registerDate, @type, @username, @password, @state, @lastConnection)";
            this.update = "UPDATE Users SET RegisterDate = @registerDate, Type = @type, Username = @username, Password = @password, State = @state, LastConnection = @lastConnection WHERE IdUsers = @idUsers";
            this.updateLastConnection = "UPDATE Users SET LastConnection = @lastConnection WHERE IdUsers = @idUsers";
            this.delete = "DELELTE FROM Users WHERE IdUsers = @idUsers";
            this.selectAll = "SELECT * FROM Users";
            this.selectByUserAndPass = "SELECT * FROM Users WHERE Username = @username AND Password = @password";
        }

        public int Insert(Users entity)
        {
            parameters = new List<MySqlParameter>
            {
                new MySqlParameter("@registerDate", entity.RegisterDate),
                new MySqlParameter("@type", entity.Type),
                new MySqlParameter("@username", entity.Username),
                new MySqlParameter("@password", entity.Password),
                new MySqlParameter("@state", entity.State),
                new MySqlParameter("@lastConnection", entity.LastConnection)
            };

            return ExecuteNonQuery(insert);
        }

        public int Update(Users entity)
        {
            parameters = new List<MySqlParameter>
            {
                new MySqlParameter("@registerDate", entity.RegisterDate),
                new MySqlParameter("@type", entity.Type),
                new MySqlParameter("@username", entity.Username),
                new MySqlParameter("@password", entity.Password),
                new MySqlParameter("@state", entity.State),
                new MySqlParameter("@lastConnection", entity.LastConnection),
                new MySqlParameter("@idUsers", entity.IdUsers)
            };

            return ExecuteNonQuery(update);
        }

        public int UpdateLastConnection(DateTime lastConnection, int idUser)
        {
            parameters = new List<MySqlParameter>
            {
                new MySqlParameter("@lastConnection", lastConnection),
                new MySqlParameter("@idUsers", idUser)
            };

            return ExecuteNonQuery(updateLastConnection);
        }

        public int Delete(int id)
        {
            parameters = new List<MySqlParameter>
            {
                new MySqlParameter("@idUsers", id)
            };

            return ExecuteNonQuery(delete);
        }

        public IEnumerable<Users> GetAll()
        {
            using (var table = ExecuteReader(selectAll))
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
                        State = row["State"].ToString(),
                        LastConnection = Convert.ToDateTime(row["LastConnection"])
                    });
                }

                return list;
            }
        }

        public Users GetUser(string username, string password)
        {
            parameters = new List<MySqlParameter>
            {
                new MySqlParameter("@username", username),
                new MySqlParameter("@password", password),
            };

            using (var table = ExecuteReader(selectByUserAndPass))
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
                        State = table.Rows[0]["State"].ToString(),
                        LastConnection = Convert.ToDateTime(table.Rows[0]["LastConnection"])
                    };
                } else
                    return null;
            }
        }
    }
}
