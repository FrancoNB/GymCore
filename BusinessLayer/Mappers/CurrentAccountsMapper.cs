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
    public static class CurrentAccountsMapper
    {
        public static CurrentAccounts Adapter(CurrentAccountsModel model)
        {
            if (model == null) return null;

            return new CurrentAccounts
            {
                IdCurrentAccounts = model.IdCurrentAccounts,
                Date = model.Date,
                TicketCode = model.TicketCode.Value,
                Debit = model.Debit,
                Credit = model.Credit,
                Balance = model.Balance,
                Detail = model.Detail,
                IdClients = model.IdClients
            };
        }

        public static CurrentAccountsModel Adapter(CurrentAccounts entity)
        {
            if (entity == null) return null;

            return new CurrentAccountsModel
            {
                IdCurrentAccounts = entity.IdCurrentAccounts,
                Date = entity.Date,
                TicketCode = Tickets.Create(entity.TicketCode),
                Debit = entity.Debit,
                Credit = entity.Credit,
                Balance = entity.Balance,
                Detail = entity.Detail,
                IdClients = entity.IdClients
            };
        }

        public static IEnumerable<CurrentAccounts> AdapterList(IEnumerable<CurrentAccountsModel> models)
        {
            var entitis = new List<CurrentAccounts>();

            foreach (CurrentAccountsModel item in models)
            {
                entitis.Add(Adapter(item));
            }

            return entitis;
        }

        public static IEnumerable<CurrentAccountsModel> AdapterList(IEnumerable<CurrentAccounts> entities)
        {
            var models = new List<CurrentAccountsModel>();

            foreach (CurrentAccounts item in entities)
            {
                models.Add(Adapter(item));
            }

            return models;
        }

    }
}
