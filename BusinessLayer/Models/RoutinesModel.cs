using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Repositories.Interfaces;
using DataAccessLayer.InterfaceRepositories;
using BusinessLayer.ValueObjects;
using DataAccessLayer.Entities;
using BusinessLayer.Mappers;
using DataAccessLayer.Support;

namespace BusinessLayer.Models
{
    public class RoutinesModel
    {
        private int _idRoutine;
        private DateTime _startDate;
        private DateTime _endDate;
        private string _state;
        private int _idClients;
        private int _idWorkPlans;

        public int IdRoutines { get => _idRoutine; set => _idRoutine = value; }
        public DateTime StartDate { get => _startDate; set => _startDate = value; }
        public DateTime EndDate { get => _endDate; set => _endDate = value; }
        public string State { get => _state; set => _state = value; }
        public int IdClients { get => _idClients; set => _idClients = value; }
        public int IdWorkPlans { get => _idWorkPlans; set => _idWorkPlans = value; }

        private IRoutinesRepository repository;

        public Operation Operation { get; set; }

        public RoutinesModel()
        {
            repository = new RoutinesRepository();
        }

        public RoutinesModel(IRoutinesRepository repository)
        {
            this.repository = repository;
        }
        public async Task<AcctionResult> SaveChanges() {
            try
            {
                switch (Operation)
                {
                    case Operation.Insert:
                        ValidateInsert();
                        await repository.Insert(RoutinesMapper.Adapter(this));
                        return new AcctionResult(true, "Rutina cargada correctamente... !");

                    case Operation.Update:
                        ValidateUpdate();
                        await repository.Update(RoutinesMapper.Adapter(this));
                        return new AcctionResult(true, "Rutina modificada correctamente... !");

                    case Operation.Delete:
                        ValidateDelete();
                        await repository.Delete(IdRoutines);
                        return new AcctionResult(true, "Rutina eliminada correctamente... !");

                    case Operation.Invalidate:
                        return new AcctionResult(false, "No se admite la operacion seleccionada... !");

                    default:
                        return new AcctionResult(false, "No se establecio la operacion a realizar... !");
                }
            }
            catch (Exception ex)
            {
                if (ex is RepositoryException repositoryEx && repositoryEx.Code == 1451)
                    return new AcctionResult(false, "La rutina que intentas eliminar se encuntra asociada a otros datos, por lo tanto, no es posible eliminarla... !");

                return new AcctionResult(false, ex.Message);
            }
        }
        public async Task<IEnumerable<RoutinesModel>> GetAll()
        {
            return RoutinesMapper.AdapterList(await repository.GetAll());
        }

        public async Task<int> GetLastId()
        {
            return await repository.GetLastId();
        }

        private void ValidateInsert() {

            if (IdWorkPlans < 1)
                throw new ArgumentException("Debe haber un plan de tranajo asociado a la rutina... !");

            if (IdClients < 1)
                throw new ArgumentException("Debe haber un cliente asociado a la rutina... !");  
                
            if (string.IsNullOrWhiteSpace(State))
                throw new ArgumentException("Se debe especificar el estado de la rutina... !");
            
            IdRoutines = -1;

        }
        private void ValidateUpdate() {
            
            if (IdRoutines < 1)
                throw new ArgumentException("No se selecciono ninguna rutina para modificar.. !");
            
            if (IdWorkPlans < 1)
                throw new ArgumentException("Debe haber un plan de trabajo asociado a la rutina... !");

            if (IdClients < 1)
                throw new ArgumentException("Debe haber un cliente asociado a la rutina... !");

            if (string.IsNullOrWhiteSpace(State))
                throw new ArgumentException("Se debe especificar el estado de la rutina... !");
        }
        private void ValidateDelete() {
            if (IdRoutines < 1)
                throw new ArgumentException("No se selecciono ninguna rutina para eliminar... !");
        }
    }
}