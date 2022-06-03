using DataAccessLayer.Entities;
using DataAccessLayer.InterfaceRepositories;
using DataAccessLayer.Support;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;


namespace DataAccessLayer.Repositories.Interfaces
{
    public class AssistsRepository : RepositoryControler, IAssistsRepository
    {
        private readonly string insert;
        private readonly string update;
        private readonly string delete;
        private readonly string selectAll;
        private readonly string selectMaxId;

        public AssistsRepository()
        {
            this.insert = "INSERT INTO Assists (Date, Clients_idClients, Subscriptions_idSubscriptions) VALUES (@date, @idClients, @idSubscriptions)";
            this.update = "UPDATE Assists SET Date = @date, Clients_idClients = @idClients, Subscriptions_idSubscriptions = @idSubscriptions WHERE IdAssists = @idAssists";
            this.delete = "DELETE FROM Assists WHERE IdAssists = @idAssists";
            this.selectAll = "SELECT * FROM Assists";
            this.selectMaxId = "SELECT Max(IdAssists) as lastId FROM Assists";
        }

        public async Task<int> Insert(Assists entity)
        {
            parameters = new List<MySqlParameter> {
                new MySqlParameter("@date", entity.Date),
                new MySqlParameter("@idClients", entity.IdClients),
                new MySqlParameter("@IdSubscriptions", entity.IdSubscriptions)             
            };
            return await ExecuteNonQueryAsync(insert);
        }

        public async Task<int> Update(Assists entity)
        {
            parameters = new List<MySqlParameter>
            {
                new MySqlParameter("@idAssists", entity.IdAssists),
                new MySqlParameter("@date", entity.Date),
                new MySqlParameter("@idClients", entity.IdClients),
                new MySqlParameter("@IdSubscriptions", entity.IdSubscriptions)
            };
            return await ExecuteNonQueryAsync(update);
        }

        public async Task<int> Delete(int id)
        {
            parameters = new List<MySqlParameter>
            {
                new MySqlParameter("@idAssists", id)
            };
            return await ExecuteNonQueryAsync(delete);
        }

        public async Task<IEnumerable<Assists>> GetAll()
        {
            using (var table = await ExecuteReaderAsync(selectAll))
            {
                var list = new List<Assists>();

                foreach (DataRow row in table.Rows)
                {
                    list.Add(new Assists()
                    {
                        IdAssists = Convert.ToInt32(row["IdAssists"]),
                        Date = Convert.ToDateTime(row["Date"]),
                        IdClients = Convert.ToInt32(row["Clients_idClients"]),
                        IdSubscriptions = Convert.ToInt32(row["Subscriptions_idSubscriptions"])                 
                    });
                }
                return list;
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

