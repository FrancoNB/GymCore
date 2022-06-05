using BusinessLayer.Models;
using BusinessLayer.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.SubscriptionsStrategy
{
    public class SubscriptionsService
    {
        private ISubscriptionsStrategy strategy;

        public SubscriptionsService(ISubscriptionsStrategy strategy)
        {
            this.strategy = strategy;
        }

        public async Task<AcctionResult> SaveChanges(SubscriptionsModel subscriptionModel)
        {
            return await strategy.SaveChanges(subscriptionModel);
        }
    }
}
