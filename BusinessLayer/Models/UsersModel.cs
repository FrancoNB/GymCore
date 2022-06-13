using BusinessLayer.Cache;
using BusinessLayer.Mappers;
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
        public enum UsersTypes
        {
            Manager,
            Trainer,
            Accountant,
            Null
        }

        #region "FIELDS"
        private int _idUsers;
        private DateTime _registerDate;
        private UsersTypes _type;
        private string _username;
        private string _password;
        private DateTime _lastConnection;
        #endregion

        #region "GETERS/SETTERS"
        public int IdUsers { get => _idUsers; set => _idUsers = value; }
        public DateTime RegisterDate { get => _registerDate; set => _registerDate = value; }
        public string RegisterDateString
        {
            get
            {
                if(RegisterDate == null)
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
        public UsersTypes Type { get => _type; set => _type = value; }
        public string TypeString
        {
            get
            {
                if (Type == UsersTypes.Manager)
                    return "Administrador";
                else if (Type == UsersTypes.Trainer)
                    return "Entrenador";
                else if (Type == UsersTypes.Accountant)
                    return "Cajero";
                else
                    return "Indeterminado";
            }

            set
            {
                if (value == "Administrador")
                    Type = UsersTypes.Manager;
                else if (value == "Entrenador")
                    Type = UsersTypes.Trainer;
                else if (value == "Cajero")
                    Type = UsersTypes.Accountant;
                else
                    Type = UsersTypes.Null;
            }
        }
        public string Username { get => _username; set => _username = value.Trim(); }
        public string Password { get => _password; set => _password = value.Trim(); }
        public DateTime LastConnection { get => _lastConnection; set => _lastConnection = value; }
        public string LastConnectionString
        {
            get
            {
                if (LastConnection == null)
                {
                    return string.Empty;
                }
                else if (LastConnection == DateTime.MinValue)
                {
                    return "Nunca";
                }
                else
                {
                    return LastConnection.ToString("dd/MM/yy HH:mm:ss");
                }

            }
        }
        #endregion

        private IUsersRepository repository;
        public Operation Operation { get; set; }

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
            try
            {
                string resultMsg;

                switch (Operation)
                {
                    case Operation.Insert:
                        ValidateInsert();
                        await repository.Insert(UsersMapper.Adapter(this));
                        resultMsg = "Usuario guardado correctamente... !";
                        break;

                    case Operation.Update:
                        ValidateUpdate();
                        await repository.Update(UsersMapper.Adapter(this));
                        resultMsg = "Usuario modificado correctamente... !";
                        break;

                    case Operation.Delete:
                        ValidateDelete();
                        await repository.Delete(IdUsers);
                        resultMsg = "Usuario eliminado correctamente... !";
                        break;

                    case Operation.Invalidate:
                        return new AcctionResult(false, "No se admite la operacion seleccionada... !");

                    default:
                        return new AcctionResult(false, "No se establecio la operacion a realizar... !");
                }

                UsersCache.GetInstance().Resource = await GetAll();

                return new AcctionResult(true, resultMsg);
            } 
            catch (Exception ex)
            {
                if (ex is RepositoryException repositoryEx)
                {
                    if(repositoryEx.Code == 1062)
                        return new AcctionResult(false, "El nombre de usuario " + Username + " no esta disponible... !");
                    else if(repositoryEx.Code == 1451)
                        return new AcctionResult(false, "El usuario que intentas eliminar se encuntra asociado a otros datos, por lo tanto, no es posible eliminarlo... !");
                }

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

                    LoginCache.IdUsers = user.IdUsers;
                    LoginCache.Username = user.Username;
                    LoginCache.Type = user.Type;

                    UsersCache.GetInstance().Resource = await GetAll();

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
            return UsersMapper.AdapterList(await repository.GetAll());
        }

        public async Task<int> GetLastId()
        {
            return await repository.GetLastId();
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

            if (string.IsNullOrWhiteSpace(TypeString))
                throw new ArgumentException("Se debe especificar un tipo para el nuevo usuario... !");

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

            if (string.IsNullOrWhiteSpace(TypeString))
                throw new ArgumentException("el tipo de usuario no puede quedar vacio... !");

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
