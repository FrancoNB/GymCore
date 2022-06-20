using BusinessLayer.Models;
using DataAccessLayer.Entities;
using System.Collections.Generic;

namespace BusinessLayer.Mappers
{
    public static class UsersMapper
    {
        public static Users Adapter(UsersModel model)
        {
            if (model == null) return null;

            return new Users
            {
                IdUsers = model.IdUsers,
                RegisterDate = model.RegisterDate,
                Type = model.TypeString,
                Username = model.Username,
                Password = model.Password,
                LastConnection = model.LastConnection
            };
        }

        public static UsersModel Adapter(Users entity)
        {
            if (entity == null) return null;

            return new UsersModel
            {
                IdUsers = entity.IdUsers,
                RegisterDate = entity.RegisterDate,
                TypeString = entity.Type,
                Username = entity.Username,
                Password = entity.Password,
                LastConnection = entity.LastConnection
            };
        }

        public static IEnumerable<Users> AdapterList(IEnumerable<UsersModel> models)
        {
            var entities = new List<Users>();

            foreach (UsersModel item in models)
            {
                entities.Add(Adapter(item));
            }

            return entities;
        }

        public static IEnumerable<UsersModel> AdapterList(IEnumerable<Users> entities)
        {
            var models = new List<UsersModel>();

            foreach (Users item in entities)
            {
                models.Add(Adapter(item));
            }

            return models;
        }
    }
}
