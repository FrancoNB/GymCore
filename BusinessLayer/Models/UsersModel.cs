using BusinessLayer.Cache;
using BusinessLayer.ValueObjects;
using DataAccessLayer.Entities;
using DataAccessLayer.InterfaceRepositories;
using DataAccessLayer.Repositories;
using DataAccessLayer.Support;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.Models
{
    public class UsersModel
    {
    
        #region "FIELDS"
        private int _idUsers;
        private DateTime _registerDate;
        private string _type;
        private string _username;
        private string _password;
        private string _state;
        private DateTime _lastConnection;
        #endregion

        #region "GETERS/SETTERS"
        public int IdUsers { get => _idUsers; set => _idUsers = value; }
        public DateTime RegisterDate { get => _registerDate; private set => _registerDate = value; }
        public string Type { get => _type; set => _type = value; }
        public string Username { get => _username; set => _username = value; }
        public string Password { get => _password; set => _password = value; }
        public string State{ get => _state; set => _state = value; }
        public DateTime LastConnection { get => _lastConnection; private set => _lastConnection = value; }
        #endregion

        private IUsersRepository repository;
        public Operation Operation { private get; set; }

        public UsersModel()
        {
            repository = new UsersRepository();
        }

        public UsersModel(IUsersRepository repository)
        {
            this.repository = repository;
        }

        public async Task<AcctionResult> SaveChanges()
        {
            var dataModel = new Users()
            {
                IdUsers = this.IdUsers,
                RegisterDate = this.RegisterDate,
                Type = this.Type,
                Username = this.Username,
                Password = this.Password,
                State = this.State,
                LastConnection = this.LastConnection
            };

            try
            {
                switch (Operation)
                {
                    case Operation.Insert:
                        ValidateInsert();
                        await repository.Insert(GetDataEntity());
                        return new AcctionResult(true, "Usuario guardado correctamente... !");

                    case Operation.Update:
                        ValidateUpdate();
                        await repository.Update(GetDataEntity());
                        return new AcctionResult(true, "Usuario modificado correctamente... !");

                    case Operation.Delete:
                        ValidateDelete();
                        await repository.Delete(IdUsers);
                        return new AcctionResult(true, "Usuario eliminado correctamente... !");

                    default:
                        return new AcctionResult(false, "No se establecio la operacion a realizar... !");
                }               
            } 
            catch (Exception ex)
            {
                if (ex is RepositoryException repositoryEx && repositoryEx.Code == 2627)
                    return new AcctionResult(false, "El nombre de usuario " + dataModel.Username + " no esta disponible... !");
                else
                    return new AcctionResult(false, ex.Message);
            }
        }

        public async Task<AcctionResult> LogIn()
        {
            try
            {
                ValidateLogin();

                var user = await repository.GetUser(Username, Password);

                if (user != null)
                {
                    await repository.UpdateLastConnection(DateTime.Now, user.IdUsers);

                    UserCache.IdUsers = user.IdUsers;
                    UserCache.Username = user.Username;
                    UserCache.Type = user.Type;

                    return new AcctionResult(true);
                }
                else
                    return new AcctionResult(false, "Usuario y/o contraseña incorrectos... !");
            } catch(Exception ex)
            {
                return new AcctionResult(false, ex.Message);
            }
        }
        
        public async Task<IEnumerable<UsersModel>> GetAll()
        {
            var dataModel = await repository.GetAll();

            var list = new List<UsersModel>();
            foreach (Users item in dataModel) 
            {
                list.Add(new UsersModel
                {
                    IdUsers = item.IdUsers,
                    RegisterDate = item.RegisterDate,
                    Type = item.Type,
                    Username = item.Username,
                    Password = item.Password,
                    State = item.State,
                    LastConnection = item.LastConnection
                });
            }

            return list;
        }

        private Users GetDataEntity()
        {
            return new Users()
            {
                IdUsers = this.IdUsers,
                RegisterDate = this.RegisterDate,
                Type = this.Type,
                Username = this.Username,
                Password = this.Password,
                State = this.State,
                LastConnection = this.LastConnection
            };
        }

        #region "VALIDATES"
        private void ValidateLogin()
        {
            if (string.IsNullOrWhiteSpace(Username))
                throw new ArgumentException("No se introdujo un usuario... !");

            if (string.IsNullOrWhiteSpace(Password))
                throw new ArgumentException("No se introdujo una contraseña... !");
        }

        private void ValidateInsert()
        {
            if (string.IsNullOrWhiteSpace(Username))
                throw new ArgumentException("Se debe especificar un nombre para el nuevo usuario... !");

            if (string.IsNullOrWhiteSpace(Password))
                throw new ArgumentException("Se debe especificar una contraseña para el nuevo usuario... !");

            if (string.IsNullOrWhiteSpace(Type))
                throw new ArgumentException("Se debe especificar un tipo para el nuevo usuario... !");

            if (string.IsNullOrWhiteSpace(State))
                throw new ArgumentException("Se debe especificar el estado del nuevo usuario... !");

            IdUsers = -1;
            RegisterDate = DateTime.Now;
            LastConnection = DateTime.MinValue;
        }

        private void ValidateUpdate()
        {
            if (IdUsers < 1)
                throw new ArgumentException("No se selecciono ningun usuario para modificar... !");

            if (string.IsNullOrWhiteSpace(Username))
                throw new ArgumentException("El nombre de usuario no puede quedar vacio... !");

            if (string.IsNullOrWhiteSpace(Password))
                throw new ArgumentException("La contraseña no puede quedar vacia... !");

            if (string.IsNullOrWhiteSpace(Type))
                throw new ArgumentException("el tipo de usuario no puede quedar vacio... !");

            if (string.IsNullOrWhiteSpace(State))
                throw new ArgumentException("El estado del usuario no puede quedar vacio... !");

            RegisterDate = DateTime.Now;
        }

        private void ValidateDelete()
        {
            if (IdUsers < 1)
                throw new ArgumentException("No se selecciono ningun usuario para eliminar... !");
        }
        #endregion
    }
}
