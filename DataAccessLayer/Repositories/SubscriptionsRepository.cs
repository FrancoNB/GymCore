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
        private readonly string delete;
        private readonly string selectAll;
        private readonly string selectMaxId;

        public SubscriptionsRepository()
        {
            this.insert = "INSERT INTO Subscriptions (TicketCode, StartDate, Package, Price, TotalSessions, UsedSessions, AvailableSessions, EndDate, ExpireDate, Observations, "
                        + "State, ClientsIdClients, CurrentAccountsIdCurrentAccounts) VALUES (@ticketCode, @startDate, @package, @price, @totalSessions, @usedSessions, "
                        + "@availabeSessions, @endDate, @expireDate, @observations, @state, @clientsIdClients, @currentAccountsIdcurrentAccounts)";

            this.update = "UPDATE Subscriptions SET TicketCode = @ticket_code, StartDate = @start_date, Package = @package, Price = @price, TotalSessions  = @total_sessions, "
                        + "UsedSessions = @used_sessions, AvailableSessions = @availabe_sessions, EndDate = @end_date,  ExpireDate = @expire_date, Observations = @observations, "
                        + "State = @state, ClientsIdClients = @clients_idclients, CurrentAccountsIdCurrentAccounts = @current_accounts_idcurrentaccounts WHERE IdSubscriptions = @idSubscriptions";

            this.delete = "DELETE FROM Subscriptions WHERE IdSubscriptions = @idSubscriptions";

            this.selectAll = "SELECT * FROM Subscriptions";

            this.selectMaxId = "SELECT Max(IdSubscriptions) as lastId FROM Subscriptions";

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
                new MySqlParameter("@clientsIdclients", entity.ClientsIdClients),
                new MySqlParameter("@currentAccountsIdcurrentaccounts", entity.CurrentAccountsIdCurrentAccounts)
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
                new MySqlParameter("@clientsIdclients", entity.ClientsIdClients),
                new MySqlParameter("@currentAccountsIdcurrentaccounts", entity.CurrentAccountsIdCurrentAccounts),
                new MySqlParameter("@idSubscriptions", entity.IdSubscriptions)
            };
            return await ExecuteNonQueryAsync(update);
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
            using (var table = await ExecuteReaderAsync(selectAll))
            {
                var list = new List<Subscriptions>();

                foreach (DataRow row in table.Rows)
                {
                    list.Add(new Subscriptions()
                    {
                        IdSubscriptions = Convert.ToInt32(row["IdSubscriptions"]),
                        TicketCode = Convert.ToInt32(row["TicketCode"]),
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
                        ClientsIdClients = Convert.ToInt32(row["ClientsIdClients"]),
                        CurrentAccountsIdCurrentAccounts = Convert.ToInt32(row["CurrentAccountsIdCurrentAccounts"])                     
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
