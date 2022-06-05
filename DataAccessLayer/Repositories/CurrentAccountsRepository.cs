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
    public class CurrentAccountsRepository : RepositoryControler, ICurrentAccountsRepository
    {
        private readonly string insert;
        private readonly string update;
        private readonly string delete;
        private readonly string selectAll;
        private readonly string selectMaxId;

        public CurrentAccountsRepository()
        {
            this.insert = "INSERT INTO CurrentAccounts (TicketCode, Date, Credit, Debit, Detail, Clients_idClients) VALUES (@ticketCode, @date, @credit, @debit, @detail, @idClients)";

            this.update = "UPDATE CurrentAccounts SET TicketCode = @ticketCode, Date = @date, Credit = @credit, Debit = @debit, Detail = @detail, "
                        + "Clients_idClients = @idClients WHERE IdCurrentAccounts = @idCurrentAccounts";

            this.delete = "DELETE FROM CurrentAccounts WHERE IdCurrentAccounts = @idCurrentAccounts";

            this.selectAll = "SELECT *, SUM(Credit - Debit) OVER (PARTITION BY Clients_idClients ORDER BY idCurrentAccounts) Balance FROM CurrentAccounts";

            this.selectMaxId = "SELECT Max(IdCurrentAccounts) as lastId FROM CurrentAccounts";
        }

        public async Task<int> Insert(CurrentAccounts entity)
        {
            parameters = new List<MySqlParameter> {
                new MySqlParameter("TicketCode", entity.TicketCode),
                new MySqlParameter("Date",entity.Date),
                new MySqlParameter("Credit",entity.Credit),
                new MySqlParameter("Debit",entity.Debit),
                new MySqlParameter("Detail",entity.Detail),
                new MySqlParameter("IdClients",entity.IdClients)
            };
            return await ExecuteNonQueryAsync(insert);
        }

        public async Task<int> Update(CurrentAccounts entity)
        {
            parameters = new List<MySqlParameter>
            {
                new MySqlParameter("IdCurrentAccounts",entity.IdCurrentAccounts),
                new MySqlParameter("TicketCode", entity.TicketCode),
                new MySqlParameter("Date",entity.Date),
                new MySqlParameter("Credit",entity.Credit),
                new MySqlParameter("Debit",entity.Debit),
                new MySqlParameter("Detail",entity.Detail),
                new MySqlParameter("IdClients",entity.IdClients)
            };
            return await ExecuteNonQueryAsync(update);
        }

        public async Task<int> Delete(int id)
        {
            parameters = new List<MySqlParameter>
            {
                new MySqlParameter("@idCurrentAccounts", id)
            };
            return await ExecuteNonQueryAsync(delete);
        }

        public async Task<IEnumerable<CurrentAccounts>> GetAll()
        {
            using (var table = await ExecuteReaderAsync(selectAll))
            {
                var list = new List<CurrentAccounts>();

                foreach (DataRow row in table.Rows)
                {
                    list.Add(new CurrentAccounts()
                    {
                        IdCurrentAccounts = Convert.ToInt32(row["IdCurrentAccounts"]),
                        TicketCode = row["TicketCode"].ToString(),
                        Date = Convert.ToDateTime(row["Date"]),
                        Credit = Convert.ToDouble(row["Credit"]),
                        Debit = Convert.ToDouble(row["Debit"]),
                        Balance = Convert.ToDouble(row["Balance"]),
                        Detail = row["Detail"].ToString(),
                        IdClients = Convert.ToInt32(row["Clients_idClients"])
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
