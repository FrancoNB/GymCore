using BusinessLayer.Models;
using DataAccessLayer.Entities;
using System.Collections.Generic;

namespace BusinessLayer.Mappers
{
    public static class PackagesMapper
    {
        public static Packages Adapter(PackagesModel model)
        {
            if (model == null) return null;

            return new Packages
            {
                IdPackages = model.IdPackages,
                Name = model.Name,
                NumberSessions = model.NumberSessions,
                AvailableDays = model.AvailableDays,
                Price = model.Price
            };
        }

        public static PackagesModel Adapter(Packages entity)
        {
            if (entity == null) return null;

            return new PackagesModel
            {
                IdPackages = entity.IdPackages,
                Name = entity.Name,
                NumberSessions = entity.NumberSessions,
                AvailableDays = entity.AvailableDays,
                Price = entity.Price
            };
        }

        public static IEnumerable<Packages> AdapterList(IEnumerable<PackagesModel> models)
        {
            var entities = new List<Packages>();

            foreach (PackagesModel item in models)
            {
                entities.Add(Adapter(item));
            }

            return entities;
        }

        public static IEnumerable<PackagesModel> AdapterList(IEnumerable<Packages> entities)
        {
            var models = new List<PackagesModel>();

            foreach (Packages item in entities)
            {
                models.Add(Adapter(item));
            }

            return models;
        }
    }
}
