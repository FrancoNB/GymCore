using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.InterfaceRepositories
{
    public interface ISubscriptionsRepository : ICrudRepository<Subscriptions>
    {
        Task<Subscriptions> GetById(int id);
        Task<int> UpdateState(int id, string state);
    }
}
