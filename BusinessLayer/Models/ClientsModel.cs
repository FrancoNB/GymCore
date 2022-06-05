﻿using System;
using DataAccessLayer.Entities;
using BusinessLayer.ValueObjects;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLayer.Repositories.Interfaces;
using DataAccessLayer.InterfaceRepositories;
using System.Text.RegularExpressions;
using BusinessLayer.Cache;

namespace BusinessLayer.Models
{
    public class ClientsModel
    {
        private int _idClients;
        private DateTime _registerDate;
        private string _name;
        private string _surname;
        private string _locality;
        private string _address;
        private string _phone;
        private string _mail;
        private string _observations;

        public int IdClients { get => _idClients; set => _idClients = value; }
        public DateTime RegisterDate { get => _registerDate; set => _registerDate = value; }
        public string RegisterDateString
        { 
            get
            {
                if (RegisterDate == null)
                {
                    return string.Empty;
                }
                else if (RegisterDate == DateTime.MinValue)
                {
                    return "Desconocida";
                }
                else
                {
                    return RegisterDate.ToString("dd/MM/yy");
                }
            }
        }
        public string Name { get => _name; set => _name = value.Trim(); }
        public string Surname { get => _surname; set => _surname = value.Trim(); }
        public string Locality { get => _locality; set => _locality = value.Trim(); }
        public string Address { get => _address; set => _address = value.Trim(); }
        public string Phone { get => _phone; set => _phone = value.Trim(); }
        public string Mail { get => _mail; set => _mail = value.Trim(); }
        public string Observations { get => _observations; set => _observations = value.Trim(); }

        private IClientsRepository repository;
        public Operation Operation { get; set; }

        public ClientsModel()
        {
            repository = new ClientsRepository();
        }

        public ClientsModel(IClientsRepository repository)
        {
            this.repository = repository;
        }

        public async Task<AcctionResult> SaveChanges()
        {
            try
            {
                string resultMsg;

                switch (Operation)
                {
                    case Operation.Insert:
                        ValidateInsert();
                        await repository.Insert(GetDataEntity());
                        resultMsg = "Cliente cargado correctamente... !";
                        break;

                    case Operation.Update:
                        ValidateUpdate();
                        await repository.Update(GetDataEntity());
                        resultMsg = "Cliente modificado correctamente... !";
                        break;

                    case Operation.Delete:
                        ValidateDelete();
                        await repository.Delete(IdClients);
                        resultMsg = "Cliente eliminado correctamente... !";
                        break;

                    case Operation.Invalidate:
                        return new AcctionResult(false, "No se admite la operacion seleccionada... !");

                    default:
                        return new AcctionResult(false, "No se establecio la operacion a realizar... !");
                }

                ClientsCache.GetInstance().Resource = await GetAll();

                return new AcctionResult(true, resultMsg);
            }
            catch (Exception ex)
            {
                return new AcctionResult(false, ex.Message);
            }
        }

        public async Task<IEnumerable<ClientsModel>> GetAll()
        {
            var dataModel = await repository.GetAll();

            var list = new List<ClientsModel>();

            foreach (Clients item in dataModel)
            {
                list.Add(new ClientsModel
                {
                    IdClients = item.IdClients,
                    RegisterDate = item.RegisterDate,
                    Name = item.Name,
                    Surname = item.Surname,
                    Locality = item.Locality,
                    Address = item.Address,
                    Phone = item.Phone,
                    Mail = item.Mail,
                    Observations = item.Observations
                });
            }

            return list;
        }

        private Clients GetDataEntity()
        {
            return new Clients()
            {
                IdClients = this.IdClients,
                RegisterDate = this.RegisterDate,
                Name = this.Name,
                Surname = this.Surname,
                Locality = this.Locality,
                Address = this.Address,
                Phone = this.Phone,
                Mail = this.Mail,
                Observations = this.Observations
            };
        }

        private void ValidateInsert()
        {
            if (string.IsNullOrWhiteSpace(Name))
                throw new ArgumentException("Se debe especificar el nombre del cliente... !");

            if (string.IsNullOrWhiteSpace(Surname))
                throw new ArgumentException("Se debe especificar el apellido del cliente... !");

            if (string.IsNullOrWhiteSpace(Locality))
                Locality = "-";

            if (string.IsNullOrWhiteSpace(Address))
                Address = "-";

            if (string.IsNullOrWhiteSpace(Phone))
                Phone = "-";
            else
            {
                if (!IsPhoneNumber(Phone))
                    throw new ArgumentException("El numero de telefono especificado no es valido... !");
            }

            if (string.IsNullOrWhiteSpace(Mail))
                Mail = "-";
            else
            {
                if (!IsValidEmail(Mail))
                    throw new ArgumentException("El mail especificado no es valido... !");
            }

            if (string.IsNullOrWhiteSpace(Observations))
                Observations = "-";

            IdClients = -1;
            RegisterDate = DateTime.Now;
        }

        private void ValidateUpdate()
        {
            if (IdClients < 1)
                throw new ArgumentException("No se selecciono ningun cliente para modificar... !");

            if (string.IsNullOrWhiteSpace(Name))
                throw new ArgumentException("Se debe especificar el nombre del cliente... !");

            if (string.IsNullOrWhiteSpace(Surname))
                throw new ArgumentException("Se debe especificar el apellido del cliente... !");

            if (string.IsNullOrWhiteSpace(Locality))
                Locality = "-";

            if (string.IsNullOrWhiteSpace(Address))
                Address = "-";      

            if (string.IsNullOrWhiteSpace(Phone))
                Phone = "-";
            else
            {
                if (!IsPhoneNumber(Phone))
                    throw new ArgumentException("El numero de telefono especificado no es valido... !");
            }

            if (string.IsNullOrWhiteSpace(Mail))
                Mail = "-";
            else
            {
                if (!IsValidEmail(Mail))
                    throw new ArgumentException("El mail especificado no es valido... !");
            }

            if (string.IsNullOrWhiteSpace(Observations))
                Observations = "-";

            RegisterDate = DateTime.Now;
        }

        private void ValidateDelete()
        {
            if (IdClients < 1)
                throw new ArgumentException("No se selecciono ningun cliente para eliminar... !");
        }

        private bool IsValidEmail(string mail)
        {
            var trimmedEmail = mail.Trim();

            if (trimmedEmail.EndsWith("."))
                return false;

            try
            {
                return new System.Net.Mail.MailAddress(mail).Address == trimmedEmail;
            }
            catch
            {
                return false;
            }
        }

        private bool IsPhoneNumber(string number)
        {
            const string motif = @"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$";

            if (number != null) 
                return Regex.IsMatch(number, motif);
            else 
                return false;
        }
    }
}
