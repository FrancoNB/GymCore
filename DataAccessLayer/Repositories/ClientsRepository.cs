﻿using DataAccessLayer.Entities;
using DataAccessLayer.InterfaceRepositories;
using DataAccessLayer.Support;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;


namespace DataAccessLayer.Repositories.Interfaces
{
    public class ClientsRepository : RepositoryControler, IClientsRepository
    {
        private readonly string insert;
        private readonly string update;
        private readonly string delete;
        private readonly string selectAll;

        public ClientsRepository()
        {
            this.insert = "INSERT INTO Clients (RegisterDate, Name, Surname, Locality, Address, Phone, Mail, Observations, State) VALUES (@registerDate, @name, @surname, @locality, @address, @phone, @mail, @observations, @state)".
            this.update = "UPDATE Clients SET RegisterDate = @registerDate, Name = @name, Surname = @surname, Locality = @locality, Address = @addres, Phone = @phone, Mail = @mail, State = @state WHERE IdClients = @idClients";
            this.delete = "DELELTE FROM Clients WHERE IdClients = @idClients";
            this.selectAll = "SELECT * FROM Clients";
        }

        public async Task<int> Insert(Clients entity)
        {
            parameters = new List<MySqlParameter>
            {
                new MySqlParameter("@registerDate", entity.RegisterDate),
                new MySqlParameter("@name", entity.Name),
                new MySqlParameter("@surname", entity.Surname),
                new MySqlParameter("@locality", entity.Locality),
                new MySqlParameter("@address", entity.Address),
                new MySqlParameter("@phone", entity.Phone),
                new MySqlParameter("@mail", entity.Mail),
                new MySqlParameter("@observations", entity.Observations),
                new MySqlParameter("@state", entity.State)
            };
            return await ExecuteNonQueryAsync(insert);
        }

        public async Task<int> Update(Clients entity)
        {
            parameters = new List<MySqlParameter>
            {
                new MySqlParameter("@registerDate", entity.RegisterDate),
                new MySqlParameter("@name", entity.Name),
                new MySqlParameter("@surname", entity.Surname),
                new MySqlParameter("@locality", entity.Locality),
                new MySqlParameter("@address", entity.Address),
                new MySqlParameter("@phone", entity.Phone),
                new MySqlParameter("@mail", entity.Mail),
                new MySqlParameter("@observations", entity.Observations),
                new MySqlParameter("@state", entity.State)
            };
            return await ExecuteNonQueryAsync(update);
        }

        public async Task<int> Delete(int id)
        {
            parameters = new List<MySqlParameter>
            {
                new MySqlParameter("@idClients", id)
            };
            return await ExecuteNonQueryAsync(delete);
        }

        public async Task<IEnumerable<Clients>> GetAll()
        {
            using (var table = await ExecuteReaderAsync(selectAll))
            {
                var list = new List<Clients>();

                foreach (DataRow row in table.Rows)
                {
                    list.Add(new Clients()
                    {
                        IdClients = Convert.ToInt32(row["IdUsers"]),
                        RegisterDate = Convert.ToDateTime(row["RegisterDate"]),
                        Surname = row["Surname"].ToString(),
                        Locality = row["Locality"].ToString(),
                        Address = row["Address"].ToString(),
                        Phone = row["Phone"].ToString(),
                        Mail = row["Mail"].ToString(),
                        Observations = row["Observations"].ToString(),
                        State = row["State"].ToString()
                    });
                }
                return list;
            }
        }
    }
} 
