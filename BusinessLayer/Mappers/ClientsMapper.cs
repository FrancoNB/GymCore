using BusinessLayer.Models;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Mappers
{
    public static class ClientsMapper
    {
        public static Clients Adapter(ClientsModel model)
        {
            if (model == null) return null;

            return new Clients
            {
                IdClients = model.IdClients,
                RegisterDate = model.RegisterDate,
                Name = model.Name,
                Surname = model.Surname,
                Locality = model.Locality,
                Address = model.Address,
                Phone = model.Phone,
                Mail = model.Mail,
                Observations = model.Observations
            };
        }

        public static ClientsModel Adapter(Clients entity)
        {
            if (entity == null) return null;

            return new ClientsModel
            {
                IdClients = entity.IdClients,
                RegisterDate = entity.RegisterDate,
                Name = entity.Name,
                Surname = entity.Surname,
                Locality = entity.Locality,
                Address = entity.Address,
                Phone = entity.Phone,
                Mail = entity.Mail,
                Observations = entity.Observations
            };
        }

        public static IEnumerable<Clients> AdapterList(IEnumerable<ClientsModel> models)
        {
            var entities = new List<Clients>();

            foreach (ClientsModel item in models)
            {
                entities.Add(Adapter(item));
            }

            return entities;
        }

        public static IEnumerable<ClientsModel> AdapterList(IEnumerable<Clients> entities)
        {
            var models = new List<ClientsModel>();

            foreach (Clients item in entities)
            {
                models.Add(Adapter(item));
            }

            return models;
        }
    }
}
