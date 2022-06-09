using BusinessLayer.Models;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Mappers
{
    public static class WorkPlansMapper
    {
        public static WorkPlans Adapter(WorkPlansModel model)
        {
            if (model == null) return null;

            return new WorkPlans
            {
                IdWorkPlans = model.IdWorkPlans,
                Name = model.Name,
                Category = model.Category
            };
        }

        public static WorkPlansModel Adapter(WorkPlans entity)
        {
            if (entity == null) return null;

            return new WorkPlansModel
            {
                IdWorkPlans = entity.IdWorkPlans,
                Name = entity.Name,
                Category = entity.Category
            };
        }

        public static IEnumerable<WorkPlans> AdapterList(IEnumerable<WorkPlansModel> models)
        {
            var entities = new List<WorkPlans>();

            foreach (WorkPlansModel item in models)
            {
                entities.Add(Adapter(item));
            }

            return entities;
        }

        public static IEnumerable<WorkPlansModel> AdapterList(IEnumerable<WorkPlans> entities)
        {
            var models = new List<WorkPlansModel>();

            foreach (WorkPlans item in entities)
            {
                models.Add(Adapter(item));
            }

            return models;
        }
    }
}
