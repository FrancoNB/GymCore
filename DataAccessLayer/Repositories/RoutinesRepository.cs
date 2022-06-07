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
    public class RoutinesRepository : RepositoryControler, IRoutinesRepository
    {

        private readonly string insert;
        private readonly string update;
        private readonly string delete;
        private readonly string selectAll;
        private readonly string selectMaxId;

        public RoutinesRepository()
        {
            this.insert = "INSERT INTO Routine (StartDate, EndDate, State, Clients_idClients, WorkPlans_idWorkPlans) VALUES (@startDate, @endDate, @state, @idClients, @idWorkPlans)";
            this.update = "UPDATE Routine SET StartDate = @startDate, EndDate = @endDate, State = @state, Clients_idClients = @idClients, WorkPlans_idWorkPlans = @idWorkPlans WHERE IdRoutine = @idRoutine";
            this.delete = "DELETE FROM Routine WHERE IdRoutine = @idRoutine";
            this.selectAll = "SELECT * FROM Routine";
            this.selectMaxId = "SELECT Max(IdRoutine) AS lastId FROM Routine";
        }

        public async Task<int> Insert(Routines entity)
        {
            parameters = new List<MySqlParameter>
            {
                new MySqlParameter("@startDate", entity.StartDate),
                new MySqlParameter("@endDate", entity.EndDate),
                new MySqlParameter("@state", entity.State),
                new MySqlParameter("@idClients", entity.IdClients),
                new MySqlParameter("@idWorkPlans", entity.IdWorkPlans)
            };
            return await ExecuteNonQueryAsync(insert);
        }

        public async Task<int> Update(Routines entity)
        {
            parameters = new List<MySqlParameter>
            {
                new MySqlParameter("@idRoutine", entity.IdRoutines),
                new MySqlParameter("@startDate", entity.StartDate),
                new MySqlParameter("@endDate", entity.EndDate),
                new MySqlParameter("@state", entity.State),
                new MySqlParameter("@idClients", entity.IdClients),
                new MySqlParameter("@idWorkPlans", entity.IdWorkPlans)
            };
            return await ExecuteNonQueryAsync(update);
        }

        public async Task<int> Delete(int id)
        {
            parameters = new List<MySqlParameter>
            {
                new MySqlParameter("@idRoutine", id),
            };
            return await ExecuteNonQueryAsync(delete);
        }

        public async Task<IEnumerable<Routines>> GetAll()
        {
            using (var table = await ExecuteReaderAsync(selectAll))
            {
                var list = new List<Routines>();

                foreach (DataRow row in table.Rows)
                {
                    list.Add(new Routines()
                    {
                        IdRoutines = Convert.ToInt32(row["IdRoutine"]),
                        StartDate = Convert.ToDateTime(row["StartDate"]),
                        EndDate = Convert.ToDateTime(row["EndDate"]),
                        State = row["State"].ToString(),
                        IdClients = Convert.ToInt32(row["Clients_idClients"]),
                        IdWorkPlans = Convert.ToInt32(row["WorkPlans_idWorkPlans"])
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
