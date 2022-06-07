using BusinessLayer.Models;
using BusinessLayer.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.SubscriptionsStrategy
{
    public class SubscriptionsInvalidate : ISubscriptionsStrategy
    { 
        public async Task<AcctionResult> SaveChanges(SubscriptionsModel subscriptionModel)
        {
            subscriptionModel.Operation = Operation.Invalidate;

            return await subscriptionModel.SaveChanges();
        }
    }
}
