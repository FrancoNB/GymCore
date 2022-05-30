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
    public class RoutineRepository : RepositoryControler, IRoutineRepository
    {

        private readonly string insert;
        private readonly string update;
        private readonly string delete;
        private readonly string selectAll;
        private readonly string selectMaxId;

        public RoutineRepository()
        {
            this.insert = "INSERT INTO Routine (StartDate, EndDate, State, IdClients, IdWorksPlans) VALUES (@startDate, @endDate, @state, @idClients, @idWorksPlans)";
            this.update = "UPDATE Routine SET StartDate = @startDate, EndDate = @endDate, State = @state, IdClients = @idClients, IdWorksPlans = @idWorksPlans WHERE IdRoutine = @idRoutine";
            this.delete = "DELETE FROM Routne WHERE IdRoutine = @idRoutine";
            this.selectAll = "SELECT * FROM Routine";
            this.selectMaxId = "SELECT Max(IdRoutine) as lastid FROM Routine";
        }

        public async Task<int> Insert(Routine entity)
        {
            parameters = new List<MySqlParameter> {
                new MySqlParameter("@startDate", entity.StartDate),
                new MySqlParameter("@endDate",entity.EndDate),
                new MySqlParameter("@state",entity.State),
                new MySqlParameter("@idClients",entity.IdClients),
                new MySqlParameter("@idWorksPlans ",entity.IDWorkPlans)
            };
            return await ExecuteNonQueryAsync(insert);
        }

        public async Task<int> Update(Routine entity)
        {
            parameters = new List<MySqlParameter>
            {
                new MySqlParameter("@idRoutine",entity.IdRoutine),
                new MySqlParameter("@startDate", entity.StartDate),
                new MySqlParameter("@endDate",entity.EndDate),
                new MySqlParameter("@state",entity.State),
                new MySqlParameter("@idClients",entity.IdClients),
                new MySqlParameter("@idWorksPlans ",entity.IDWorkPlans)
            };
            return await ExecuteNonQueryAsync(update);
        }

        public async Task<int> Delete(int id)
        {
            parameters = new List<MySqlParameter>
            {
                new MySqlParameter("@idRoutine", id)
            };
            return await ExecuteNonQueryAsync(delete);
        }

        public async Task<IEnumerable<Routine>> GetAll()
        {
            using (var table = await ExecuteReaderAsync(selectAll))
            {
                var list = new List<Routine>();

                foreach (DataRow row in table.Rows)
                {
                    list.Add(new Routine()
                    {
                        IdRoutine = Convert.ToInt32(row["IdRoutine"]),
                        StartDate = Convert.ToDateTime(row["StartDate"]),
                        EndDate = Convert.ToDateTime(row["EndDate"]),
                        State = row["State"].ToString(),
                        IdClients = Convert.ToInt32(row["IdClients"]),
                        IDWorkPlans = Convert.ToInt32(row["IdWorkPlans"])
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
