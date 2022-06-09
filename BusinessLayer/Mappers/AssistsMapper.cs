using BusinessLayer.Models;
using DataAccessLayer.Entities;
using System.Collections.Generic;

namespace BusinessLayer.Mappers
{
    public class AssistsMapper
    {
        public static Assists Adapter(AssistsModel model)
        {
            if (model == null) return null;

            return new Assists
            {
                IdAssists = model.IdAssists,
                Date = model.Date,
                IdClients = model.IdClients,
                IdSubscriptions = model.IdSubscriptions
            };
        }

        public static AssistsModel Adapter(Assists entity)
        {
            if (entity == null) return null;

            return new AssistsModel
            {
                IdAssists = entity.IdAssists,
                Date = entity.Date,
                IdClients = entity.IdClients,
                IdSubscriptions = entity.IdSubscriptions
            };
        }

        public static IEnumerable<Assists> AdapterList(IEnumerable<AssistsModel> models)
        {
            var entities = new List<Assists>();

            foreach (AssistsModel item in models)
            {
                entities.Add(Adapter(item));
            }

            return entities;
        }

        public static IEnumerable<AssistsModel> AdapterList(IEnumerable<Assists> entities)
        {
            var models = new List<AssistsModel>();

            foreach (Assists item in entities)
            {
                models.Add(Adapter(item));
            }

            return models;
        }
    }
}
