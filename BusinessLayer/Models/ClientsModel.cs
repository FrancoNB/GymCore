using System;
using DataAccessLayer.InterfaceRepositories;
using DataAccessLayer.Repositories;
using DataAccessLayer.Entities;
using BusinessLayer.ValueObjects;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Support;

namespace BusinessLayer.Models
{
    public class ClientsModel
    {
        public enum ClientsStates
        {
            Enabled,
            Disabled,
            Null
        }

        private int _idClients;
        private DateTime _registerDate;
        private string _name;
        private string _surname;
        private string _locality;
        private string _address;
        private string _phone;
        private string _mail;
        private string _observations;
        private ClientsStates _state;

        public int IdClients { get => _idClients; set => _idClients = value; }
        public DateTime RegisterDate { get => _registerDate; set => _registerDate = value; }
        public string Name { get => _name; set => _name = value; }
        public string Surname { get => _surname; set => _surname = value; }
        public string Locality { get => _locality; set => _locality = value; }
        public string Address { get => _address; set => _address = value; }
        public string Phone { get => _phone; set => _phone = value; }
        public string Mail { get => _mail; set => _mail = value; }
        public string Observations { get => _observations; set => _observations = value; }
        public ClientsStates State { get => _state; set => _state = value; }
        public string StateString 
        { 
            get
            {
                if (State == ClientsStates.Enabled)
                    return "Habilitado";
                else if (State == ClientsStates.Disabled)
                    return "Deshabilitado";
                else
                    return null;
            }

            set
            {
                if (value == "Habilitado")
                    State = ClientsStates.Enabled;
                else if (value == "Deshabilitado")
                    State = ClientsStates.Disabled;
                else
                    State = ClientsStates.Null;
            }
        }

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
                if (ex is RepositoryException repositoryEx && repositoryEx.Code == 1062)
                    return new AcctionResult(false, "El nombre de usuario " + Username + " no esta disponible... !");
                else
                    return new AcctionResult(false, ex.Message);
            }
        }

        public async Task<IEnumerable<UsersModel>> GetAll()
        {
            var dataModel = await repository.GetAll();

            var list = new List<UsersModel>();
            foreach (Users item in dataModel)
            {
                if (item.Type != "Desarrollador")
                {
                    list.Add(new UsersModel
                    {
                        IdUsers = item.IdUsers,
                        RegisterDate = item.RegisterDate,
                        Type = GetEnumTypes(item.Type),
                        Username = item.Username,
                        Password = item.Password,
                        State = GetEnumState(item.State),
                        LastConnection = item.LastConnection
                    });
                }
            }

            return list;
        }

        private Clients GetDataEntity()
        {
            return new Clients()
            {
                IdClients = this.IdClients,
                Date = this.RegisterDate,
                Name = this.Name,
                Surname = this.Surname,
                Locality = this.Locality,
                Address = this.Address,
                Phone = this.Phone,
                Mail = this.Mail,
                Observations = this.Observations,
                State = this.StateString
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
            State = ClientsStates.Enabled;
        }

        private void ValidateUpdate()
        {
            if (IdClients < 1)
                throw new ArgumentException("No se selecciono ningun cliente para modificar... !");

            if (string.IsNullOrWhiteSpace(Name))
                throw new ArgumentException("Se debe especificar el nombre del cliente... !");

            if (string.IsNullOrWhiteSpace(Surname))
                throw new ArgumentException("Se debe especificar el apellido del cliente... !");

            if (string.IsNullOrWhiteSpace(StateString))
                throw new ArgumentException("Se debe especificar el estado del cliente... !");

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
