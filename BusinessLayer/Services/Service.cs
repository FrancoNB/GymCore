using BusinessLayer.Support;
using BusinessLayer.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class Service<Model> where Model : class
    {
        private IServiceStrategy<Model> strategy;

        public void SetStrategy(IServiceStrategy<Model> strategy)
        {
            this.strategy = strategy;
        }

        public async Task<AcctionResult> SaveChanges(Model model)
        {
            return await strategy.SaveChanges(model);
        }
    }
}
