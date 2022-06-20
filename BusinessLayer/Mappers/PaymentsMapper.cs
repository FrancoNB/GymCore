using BusinessLayer.Models;
using BusinessLayer.ValueObjects;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Mappers
{
    public class PaymentsMapper
    {
        public static Payments Adapter(PaymentsModel model)
        {
            if (model == null) return null;

            return new Payments
            {
                IdPayments = model.IdPayments,
                TicketCode = model.TicketCode.Value,
                Date = model.Date,
                PaymentMethod = model.PaymentMethodString,
                Amount = model.Amount,
                Observations = model.Observations,
                IdClients = model.IdClients,
                IdCurrentAccounts = model.IdCurrentAccounts
            };
        }

        public static PaymentsModel Adapter(Payments entity)
        {
            if (entity == null) return null;

            return new PaymentsModel
            {
                IdPayments = entity.IdPayments,
                TicketCode = Tickets.Create(entity.TicketCode),
                Date = entity.Date,
                PaymentMethodString = entity.PaymentMethod,
                Amount = entity.Amount,
                Observations = entity.Observations,
                IdClients = entity.IdClients,
                IdCurrentAccounts = entity.IdCurrentAccounts
            };
        }

        public static IEnumerable<Payments> AdapterList(IEnumerable<PaymentsModel> models)
        {
            var entities = new List<Payments>();

            foreach (PaymentsModel item in models)
            {
                entities.Add(Adapter(item));
            }

            return entities;
        }

        public static IEnumerable<PaymentsModel> AdapterList(IEnumerable<Payments> entities)
        {
            var models = new List<PaymentsModel>();

            foreach (Payments item in entities)
            {
                models.Add(Adapter(item));
            }

            return models;
        }
    }
}
