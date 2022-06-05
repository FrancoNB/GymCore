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
    public class PaymentsRepository : RepositoryControler, IPaymentsRepository
    {
        private readonly string insert;
        private readonly string update;
        private readonly string delete;
        private readonly string selectAll;
        private readonly string selectMaxId;

        public PaymentsRepository()
        {
            this.insert = "INSERT INTO Payments (TicketCode, Date, PaymentMethod, Amount, Observations, Clients_IdClients, CurrentAccounts_IdCurrentAccounts) VALUES (@ticketCode, @date, @paymentMethod, "
                        + "@amount, @observations, @idClients, @idCurrentAccounts)";
            this.update = "UPDATE Payments SET TicketCode = @ticketCode, Date = @date, PaymentMethod = @paymentMethod, Amount = @amount, Observations = @observations, "
                        + "Clients_IdClients = @idClients, CurrentAccounts_IdCurrentAccounts = @idCurrentAccounts WHERE IdPayments = @idPayments";
            this.delete = "DELETE FROM Payments WHERE IdPayments = @idPayments";
            this.selectAll = "SELECT * FROM Payments";
            this.selectMaxId = "SELECT Max(IdPayments) as lastId FROM Payments";
        }

        public async Task<int> Insert(Payments entity)
        {
            parameters = new List<MySqlParameter> {
                new MySqlParameter("@ticketCode", entity.TicketCode),
                new MySqlParameter("@date", entity.Date),
                new MySqlParameter("@paymentMethod", entity.PaymentMethod),
                new MySqlParameter("@amount", entity.Amount),
                new MySqlParameter("@observations", entity.Observations),
                new MySqlParameter("@idClients", entity.IdClients),
                new MySqlParameter("@idCurrentAccounts", entity.IdCurrentAccounts)
            };
            return await ExecuteNonQueryAsync(insert);
        }

        public async Task<int> Update(Payments entity)
        {
            parameters = new List<MySqlParameter>
            {
                new MySqlParameter("@IdPayments", entity.IdPayments),
                new MySqlParameter("@ticketCode", entity.TicketCode),
                new MySqlParameter("@date", entity.Date),
                new MySqlParameter("@paymentMethod", entity.PaymentMethod),
                new MySqlParameter("@amount", entity.Amount),
                new MySqlParameter("@observations", entity.Observations),
                new MySqlParameter("@idClients", entity.IdClients),
                new MySqlParameter("@idCurrentAccounts", entity.IdCurrentAccounts)
            };
            return await ExecuteNonQueryAsync(update);
        }

        public async Task<int> Delete(int id)
        {
            parameters = new List<MySqlParameter>
            {
                new MySqlParameter("@idPayments", id)
            };
            return await ExecuteNonQueryAsync(delete);
        }

        public async Task<IEnumerable<Payments>> GetAll()
        {
            using (var table = await ExecuteReaderAsync(selectAll))
            {
                var list = new List<Payments>();

                foreach (DataRow row in table.Rows)
                {
                    list.Add(new Payments()
                    {
                        IdPayments = Convert.ToInt32(row["idPayments"]),
                        TicketCode = row["TicketCode"].ToString(),
                        Date = Convert.ToDateTime(row["Date"]),
                        PaymentMethod = row["PaymentMethod"].ToString(),
                        Amount = Convert.ToDouble(row["Amount"]),
                        Observations = row["Observations"].ToString(),
                        IdClients = Convert.ToInt32(row["Clients_IdClients"]),
                        IdCurrentAccounts = Convert.ToInt32(row["CurrentAccounts_IdCurrentAccounts"])
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

