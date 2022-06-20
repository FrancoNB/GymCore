using BusinessLayer.Models;
using DataAccessLayer.Entities;
using System.Collections.Generic;

namespace BusinessLayer.Mappers
{
    public static class RoutinesMapper
    {
        public static Routines Adapter(RoutinesModel model)
        {
            if (model == null) return null;

            return new Routines
            {
                IdRoutines = model.IdRoutines,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                State = model.State,
                IdClients = model.IdClients,
                IdWorkPlans = model.IdWorkPlans
            };
        }

        public static RoutinesModel Adapter(Routines entity)
        {
            if (entity == null) return null;

            return new RoutinesModel
            {
                IdRoutines = entity.IdRoutines,
                StartDate = entity.StartDate,
                EndDate = entity.EndDate,
                State = entity.State,
                IdClients = entity.IdClients,
                IdWorkPlans = entity.IdWorkPlans
            };
        }

        public static IEnumerable<Routines> AdapterList(IEnumerable<RoutinesModel> models)
        {
            var entities = new List<Routines>();

            foreach(RoutinesModel item in models)
            {
                entities.Add(Adapter(item));
            }

            return entities;
        }

        public static IEnumerable<RoutinesModel> AdapterList(IEnumerable<Routines> entities)
        {
            var models = new List<RoutinesModel>();

            foreach (Routines item in entities)
            {
                models.Add(Adapter(item));
            }

            return models;
        }
    }
}
