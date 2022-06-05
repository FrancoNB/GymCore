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
    public class SubscriptionsRepository : RepositoryControler, ISubscriptionsRepository
    {
        private readonly string insert;
        private readonly string update;
        private readonly string updateState;
        private readonly string delete;
        private readonly string selectAll;
        private readonly string selectMaxId;
        private readonly string selectByIdClient;

        public SubscriptionsRepository()
        {
            this.insert = "INSERT INTO Subscriptions (TicketCode, StartDate, Package, Price, TotalSessions, UsedSessions, AvailableSessions, EndDate, ExpireDate, Observations, "
                        + "State, Clients_idClients, CurrentAccounts_idCurrentAccounts) VALUES (@ticketCode, @startDate, @package, @price, @totalSessions, @usedSessions, "
                        + "@availabeSessions, @endDate, @expireDate, @observations, @state, @idClients, @idCurrentAccounts)";

            this.update = "UPDATE Subscriptions SET TicketCode = @ticket_code, StartDate = @start_date, Package = @package, Price = @price, TotalSessions  = @total_sessions, "
                        + "UsedSessions = @used_sessions, AvailableSessions = @availabe_sessions, EndDate = @end_date,  ExpireDate = @expire_date, Observations = @observations, "
                        + "State = @state, Clients_IdClients = @idClients, CurrentAccounts_idCurrentAccounts = @idCurrentAccounts WHERE IdSubscriptions = @idSubscriptions";

            this.updateState = "UPDATE Subscriptions SET State = @state WHERE IdSubscriptions = @idSubscriptions";

            this.delete = "DELETE FROM Subscriptions WHERE IdSubscriptions = @idSubscriptions";

            this.selectAll = "SELECT * FROM Subscriptions";

            this.selectMaxId = "SELECT Max(IdSubscriptions) as lastId FROM Subscriptions";

            this.selectByIdClient = "SELECT * FROM Subscriptions WHERE Clients_IdClients = @idClients";

        }

        public async Task<int> Insert(Subscriptions entity)
        {
            parameters = new List<MySqlParameter>
            {
                new MySqlParameter("@ticketCode", entity.TicketCode),
                new MySqlParameter("@startDate", entity.StartDate),
                new MySqlParameter("@package", entity.Package),
                new MySqlParameter("@price", entity.Price),
                new MySqlParameter("@totalSessions", entity.TotalSessions),
                new MySqlParameter("@usedSessions", entity.UsedSessions),
                new MySqlParameter("@availabeSessions", entity.AvailableSessions),
                new MySqlParameter("@endDate", entity.EndDate),
                new MySqlParameter("@expireDate", entity.ExpireDate),
                new MySqlParameter("@observations", entity.Observations),
                new MySqlParameter("@state", entity.State),
                new MySqlParameter("@idClients", entity.IdClients),
                new MySqlParameter("@idCurrentAccounts", entity.IdCurrentAccounts)
            };
            return await ExecuteNonQueryAsync(insert);
        }

        public async Task<int> Update(Subscriptions entity)
        {
            parameters = new List<MySqlParameter>
            {
                new MySqlParameter("@ticketCode", entity.TicketCode),
                new MySqlParameter("@startDate", entity.StartDate),
                new MySqlParameter("@package", entity.Package),
                new MySqlParameter("@price", entity.Price),
                new MySqlParameter("@totalSessions", entity.TotalSessions),
                new MySqlParameter("@usedSessions", entity.UsedSessions),
                new MySqlParameter("@availabeSessions", entity.AvailableSessions),
                new MySqlParameter("@endDate", entity.EndDate),
                new MySqlParameter("@expireDate", entity.ExpireDate),
                new MySqlParameter("@observations", entity.Observations),
                new MySqlParameter("@state", entity.State),
                new MySqlParameter("@idClients", entity.IdClients),
                new MySqlParameter("@idCurrentAccounts", entity.IdCurrentAccounts),
                new MySqlParameter("@idSubscriptions", entity.IdSubscriptions)
            };
            return await ExecuteNonQueryAsync(update);
        }

        public async Task<int> UpdateState(int id, string state)
        {
            parameters = new List<MySqlParameter>
            {
                new MySqlParameter("@idSubscriptions", id),
                new MySqlParameter("@state", state)
            };

            return await ExecuteNonQueryAsync(updateState);
        }

        public async Task<int> Delete(int id)
        {
            parameters = new List<MySqlParameter>
            {
                new MySqlParameter("@idSubscriptions", id)
            };

            return await ExecuteNonQueryAsync(delete);
        }

        public async Task<IEnumerable<Subscriptions>> GetAll()
        {
            return await ExecuteSelect(selectAll);
        }

        public async Task<IEnumerable<Subscriptions>> GetByIdClient(int idClient)
        {
            parameters = new List<MySqlParameter>
            {
                new MySqlParameter("@idClients", idClient)
            };

            return await ExecuteSelect(selectByIdClient);
        }

        private async Task<IEnumerable<Subscriptions>> ExecuteSelect(string query)
        {
            using (var table = await ExecuteReaderAsync(query))
            {
                var list = new List<Subscriptions>();

                foreach (DataRow row in table.Rows)
                {
                    list.Add(new Subscriptions()
                    {
                        IdSubscriptions = Convert.ToInt32(row["IdSubscriptions"]),
                        TicketCode = row["TicketCode"].ToString(),
                        StartDate = Convert.ToDateTime(row["StartDate"]),
                        Package = row["Package"].ToString(),
                        Price = Convert.ToDouble(row["Price"]),
                        TotalSessions = Convert.ToInt32(row["TotalSessions"]),
                        UsedSessions = Convert.ToInt32(row["UsedSessions"]),
                        AvailableSessions = Convert.ToInt32(row["AvailableSessions"]),
                        EndDate = Convert.ToDateTime(row["EndDate"]),
                        ExpireDate = Convert.ToDateTime(row["ExpireDate"]),
                        Observations = row["Observations"].ToString(),
                        State = row["state"].ToString(),
                        IdClients = Convert.ToInt32(row["Clients_idClients"]),
                        IdCurrentAccounts = Convert.ToInt32(row["CurrentAccounts_idCurrentAccounts"])
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
