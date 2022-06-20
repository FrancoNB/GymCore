using BusinessLayer.Cache;
using BusinessLayer.Mappers;
using BusinessLayer.ValueObjects;
using DataAccessLayer.InterfaceRepositories;
using DataAccessLayer.Repositories.Interfaces;
using DataAccessLayer.Support;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.Models
{
    public class AssistsModel
    {
        private int _idAssists;
        private DateTime _date;
        private int _idClients;
        private int _idSubscriptions;

        public int IdAssists { get => _idAssists; set => _idAssists = value; }
        public DateTime Date { get => _date; set => _date = value; }
        public string DateString
        {
            get
            {
                if (Date == null)
                {
                    return string.Empty;
                }
                else if (Date == DateTime.MinValue)
                {
                    return "Desconocida";
                }
                else
                {
                    return Date.ToString("dd/MM/yyyy");
                }

            }
        }
        public int IdClients { get => _idClients; set => _idClients = value; }
        public int IdSubscriptions { get => _idSubscriptions; set => _idSubscriptions = value; }


        private IAssistsRepository repository;
        public Operation Operation { get; set; }

        public AssistsModel()
        {
            repository = new AssistsRepository();
        }

        public AssistsModel(IAssistsRepository repository)
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
                        await repository.Insert(AssistsMapper.Adapter(this));
                        resultMsg = "Asistencia cargada correctamente... !";
                        break;

                    case Operation.Delete:
                        ValidateDelete();
                        await repository.Delete(IdAssists);
                        resultMsg = "Asistencia eliminada correctamente... !";
                        break;

                    case Operation.Update:
                    case Operation.Invalidate:
                        return new AcctionResult(false, "No se admite la operacion seleccionada... !");

                    default:
                        return new AcctionResult(false, "No se establecio la operacion a realizar... !");
                }

                AssistsCache.GetInstance().Resource = await GetAll();

                return new AcctionResult(true, resultMsg);
            }
            catch (Exception ex)
            {
                if (ex is RepositoryException repositoryEx && repositoryEx.Code == 1451)
                    return new AcctionResult(false, "La asistencia que intentas eliminar se encuntra asociada a otros datos, por lo tanto, no es posible eliminarla... !");
                
                return new AcctionResult(false, ex.Message);
            }
        }

        public async Task<IEnumerable<AssistsModel>> GetAll()
        {
            return AssistsMapper.AdapterList(await repository.GetAll());
        }

        public async Task<int> GetLastId()
        {
            return await repository.GetLastId();
        }

        private void ValidateInsert()
        {
            if (IdClients < 1)
                throw new ArgumentException("Se debe especificar el cliente al que asignarle la asistencia... !");

            if (IdSubscriptions < 1)
                throw new ArgumentException("Se debe especificar el la subscripcion del cliente que se va a consumir... !");

            IdAssists = -1;
        }

        private void ValidateDelete()
        {
            if (IdAssists < 1)
                throw new ArgumentException("No se selecciono ninguna asistencia para eliminar... !");
        }
    }
}
