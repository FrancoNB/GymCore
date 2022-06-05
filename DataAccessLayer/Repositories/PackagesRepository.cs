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
    public class PackagesRepository : RepositoryControler, IPackagesRepository
    {
        private readonly string insert;
        private readonly string update;
        private readonly string delete;
        private readonly string selectAll;
        private readonly string selectMaxId;

        public PackagesRepository()
        {
            this.insert = "INSERT INTO Packages (Name, NumberSessions, AvailableDays, Price) VALUES (@name, @numberSessions, @availableDays, @price)";
            this.update = "UPDATE Packages SET Name = @name, NumberSessions = @numberSessions, AvailableDays = @availableDays, Price = @price WHERE IdPackages = @idPackages";
            this.delete = "DELETE FROM Packages WHERE IdPackages = @idPackages";
            this.selectAll = "SELECT * FROM Packages";
            this.selectMaxId = "SELECT Max(IdPackages) as lastId FROM Packages";
        }

        public async Task<int> Insert(Packages entity)
        {
            parameters = new List<MySqlParameter> {
                new MySqlParameter("@name", entity.Name),
                new MySqlParameter("@numberSessions", entity.NumberSessions),
                new MySqlParameter("@availableDays", entity.AvailableDays),
                new MySqlParameter("@price", entity.Price)
            };
            return await ExecuteNonQueryAsync(insert);
        }

        public async Task<int> Update(Packages entity)
        {
            parameters = new List<MySqlParameter>
            {
                new MySqlParameter("@name", entity.Name),
                new MySqlParameter("@numberSessions", entity.NumberSessions),
                new MySqlParameter("@availableDays", entity.AvailableDays),
                new MySqlParameter("@price", entity.Price),
                new MySqlParameter("@idPackages", entity.IdPackages)
            };
            return await ExecuteNonQueryAsync(update);
        }

        public async Task<int> Delete(int id)
        {
            parameters = new List<MySqlParameter>
            {
                new MySqlParameter("@idPackages", id)
            };
            return await ExecuteNonQueryAsync(delete);
        }

        public async Task<IEnumerable<Packages>> GetAll()
        {
            using (var table = await ExecuteReaderAsync(selectAll))
            {
                var list = new List<Packages>();

                foreach (DataRow row in table.Rows)
                {
                    list.Add(new Packages()
                    {
                        IdPackages = Convert.ToInt32(row["IdPackages"]),
                        Name = row["Name"].ToString(),
                        NumberSessions = Convert.ToInt32(row["NumberSessions"]),
                        AvailableDays = Convert.ToInt32(row["AvailableDays"]),
                        Price = Convert.ToDouble(row["Price"])                    
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
