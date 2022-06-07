using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Models;
using BusinessLayer.ValueObjects;

namespace BusinessLayer.Services.SubscriptionsStrategy
{
    public interface ISubscriptionsStrategy
    {
        Task<AcctionResult> SaveChanges(SubscriptionsModel subscriptionModel);
    }
}
