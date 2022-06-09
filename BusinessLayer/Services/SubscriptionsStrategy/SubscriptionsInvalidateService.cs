using BusinessLayer.Models;
using BusinessLayer.Support;
using BusinessLayer.ValueObjects;
using System.Threading.Tasks;

namespace BusinessLayer.Services.SubscriptionsStrategy
{
    public class SubscriptionsInvalidateService : IServiceStrategy<SubscriptionsModel>
    { 
        public async Task<AcctionResult> SaveChanges(SubscriptionsModel subscriptionModel)
        {
            subscriptionModel.Operation = Operation.Invalidate;

            return await subscriptionModel.SaveChanges();
        }
    }
}
