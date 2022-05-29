using System;
using DataAccessLayer.Entities;
using BusinessLayer.ValueObjects;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Support;
using DataAccessLayer.Repositories.Interfaces;
using DataAccessLayer.InterfaceRepositories;

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
        public string Name { get => _name; set => _name = value; }
        public string Surname { get => _surname; set => _surname = value; }
        public string Locality { get => _locality; set => _locality = value; }
        public string Address { get => _address; set => _address = value; }
        public string Phone { get => _phone; set => _phone = value; }
        public string Mail { get => _mail; set => _mail = value; }
        public string Observations { get => _observations; set => _observations = value; }

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
                switch (Operation)
                {
                    case Operation.Insert:
                        ValidateInsert();
                        await repository.Insert(GetDataEntity());
                        return new AcctionResult(true, "Cliente guardado correctamente... !");

                    case Operation.Update:
                        ValidateUpdate();
                        await repository.Update(GetDataEntity());
                        return new AcctionResult(true, "Cliente modificado correctamente... !");

                    case Operation.Delete:
                        ValidateDelete();
                        await repository.Delete(IdClients);
                        return new AcctionResult(true, "Cliente eliminado correctamente... !");

                    default:
                        return new AcctionResult(false, "No se establecio la operacion a realizar... !");
                }
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

            if (string.IsNullOrWhiteSpace(Observations))
                Observations = "-";

            RegisterDate = DateTime.Now;
        }

        private void ValidateDelete()
        {
            if (IdClients < 1)
                throw new ArgumentException("No se selecciono ningun cliente para eliminar... !");
        }
    }
}
