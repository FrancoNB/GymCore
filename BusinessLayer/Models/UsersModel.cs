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
        private int _idUsers;
        private DateTime _registerDate;
        private string _type;
        private string _username;
        private string _password;
        private string _state;
        private DateTime _lastConnection;

        private IUsersRepository repository;
        public Operation Operation { private get; set; }

        public int IdUsers { get => _idUsers; set => _idUsers = value; }
        public DateTime RegisterDate { get => _registerDate; set => _registerDate = value; }
        public string Type { get => _type; set => _type = value; }
        public string Username { get => _username; set => _username = value; }
        public string Password { get => _password; set => _password = value; }
        public string State{ get => _state; set => _state = value; }
        public DateTime LastConnection { get => _lastConnection; set => _lastConnection = value; }

        public UsersModel()
        {
            repository = new UsersRepository();
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
                        await repository.Insert(dataModel);
                        return new AcctionResult(true, "Usuario guardado correctamente !");

                    case Operation.Update:
                        await repository.Update(dataModel);
                        return new AcctionResult(true, "Usuario modificado correctamente !");

                    case Operation.Delete:
                        await repository.Delete(this.IdUsers);
                        return new AcctionResult(true, "Usuario eliminado correctamente !");

                    default:
                        return new AcctionResult(false, "No se establecio la Operacion a realizar.");
                }               
            } 
            catch (Exception ex)
            {
                if (ex is RepositoryException repositoryEx && repositoryEx.Code == 2627)
                    return new AcctionResult(false, "El nombre de usuario " + dataModel.Username + " no esta disponible.");
                else
                    return new AcctionResult(false, ex.Message);
            }
        }

        public async Task<AcctionResult> LogIn(string username, string password)
        {
            try
            {
                var user = await repository.GetUser(username, password);

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
    }
}
