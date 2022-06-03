using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLayer.Repositories.Interfaces;
using DataAccessLayer.InterfaceRepositories;
using BusinessLayer.ValueObjects;
using DataAccessLayer.Entities;

namespace BusinessLayer.Models
{
    public class WorkPlansModel
    {
        private int _idWorkPlans;
        private string _name;
        private string _category;

        public int IdWorkPlans { get => _idWorkPlans; set => _idWorkPlans = value; }
        public string Name { get => _name; set => _name = value; }
        public string Category { get => _category; set => _category = value; }


        private IWorkPlansRepository repository;

        public Operation Operation { get; set; }

        public WorkPlansModel()
        {
            repository = new WorkPlansRepository();
        }

        public WorkPlansModel(IWorkPlansRepository repository)
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
                        return new AcctionResult(true, "Plan de trabajo cargado correctamente... !");

                    case Operation.Update:
                        ValidateUpdate();
                        await repository.Update(GetDataEntity());
                        return new AcctionResult(true, "Plan de trabajo modificado correctamente... !");

                    case Operation.Delete:
                        ValidateDelete();
                        await repository.Delete(IdWorkPlans);
                        return new AcctionResult(true, "Plan de trabajo eliminado correctamente... !");

                    default:
                        return new AcctionResult(false, "No se establecio la operacion a realizar... !");
                }
            }
            catch (Exception ex)
            {
                return new AcctionResult(false, ex.Message);
            }
        }
        public async Task<IEnumerable<WorkPlansModel>> GetAll()
        {
            var dataModel = await repository.GetAll();

            var list = new List<WorkPlansModel>();

            foreach (WorkPlans item in dataModel)
            {
                list.Add(new WorkPlansModel
                {
                    IdWorkPlans = item.IdWorkPlans,
                    Name = item.Name,
                    Category = item.Category,
                });
            }

            return list;
        }
        private WorkPlans GetDataEntity()
        {
            return new WorkPlans()
            {
                IdWorkPlans = this.IdWorkPlans,
                Name = this.Name,
                Category = this.Category,
            };
        }

        private void ValidateInsert() 
        {
            if (string.IsNullOrWhiteSpace(Name))
                throw new ArgumentException("Se debe especificar el nombre del plan de trabajo... !");
            if (string.IsNullOrWhiteSpace(Category))
                throw new ArgumentException("Se debe especificar la categoría del plan de trabajo...!");
            
            IdWorkPlans = -1;
        }
        private void ValidateUpdate() 
        {
            if (IdWorkPlans < 1)
                throw new ArgumentException("No se selecciono ningun plan de trabajo para modificar... !");

            if (string.IsNullOrWhiteSpace(Name))
                throw new ArgumentException("Se debe especificar el nombre del plan de trabajo... !");

            if (string.IsNullOrWhiteSpace(Category))
                throw new ArgumentException("Se debe especificar la categoría del plan de trabajo...!");
        }
        private void ValidateDelete() {
           
            if (IdWorkPlans < 1)
                throw new ArgumentException("No se selecciono ningun plan de trabajo para eliminar... !");
        }

    }
}
