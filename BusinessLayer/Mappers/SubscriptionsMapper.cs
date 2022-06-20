using System.Collections.Generic;
using BusinessLayer.Models;
using DataAccessLayer.Entities;

namespace BusinessLayer.Mappers
{
    public static class SubscriptionsMapper
    {
        public static Subscriptions Adapter(SubscriptionsModel model)
        {
            if (model == null) return null;

            return new Subscriptions
            {
                IdSubscriptions = model.IdSubscriptions,
                TicketCode = model.TicketCode.Value,
                StartDate = model.StartDate,
                Package = model.Package,
                Price = model.Price,
                TotalSessions = model.TotalSessions,
                UsedSessions = model.UsedSessions,
                AvailableSessions = model.AvailableSessions,
                EndDate = model.EndDate,
                ExpireDate = model.ExpireDate,
                Observations = model.Observations,
                State = model.StateString,
                IdClients = model.IdClients,
                IdCurrentAccounts = model.IdCurrentAccounts
            };
        }

        public static SubscriptionsModel Adapter(Subscriptions entity)
        {
            if (entity == null) return null;

            return new SubscriptionsModel
            {
                IdSubscriptions = entity.IdSubscriptions,
                TicketCode = ValueObjects.Tickets.Create(entity.TicketCode),
                StartDate = entity.StartDate,
                Package = entity.Package,
                Price = entity.Price,
                TotalSessions = entity.TotalSessions,
                UsedSessions = entity.UsedSessions,
                AvailableSessions = entity.AvailableSessions,
                EndDate = entity.EndDate,
                ExpireDate = entity.ExpireDate,
                Observations = entity.Observations,
                StateString = entity.State,
                IdClients = entity.IdClients,
                IdCurrentAccounts = entity.IdCurrentAccounts
            };
        }

        public static IEnumerable<Subscriptions> AdapterList(IEnumerable<SubscriptionsModel> models)
        {
            var entitis = new List<Subscriptions>();

            foreach(SubscriptionsModel item in models)
            {
                entitis.Add(Adapter(item));
            }

            return entitis;
        }

        public static IEnumerable<SubscriptionsModel> AdapterList(IEnumerable<Subscriptions> entities)
        {
            var models = new List<SubscriptionsModel>();

            foreach (Subscriptions item in entities)
            {
                models.Add(Adapter(item));
            }

            return models;
        }
    }
}
