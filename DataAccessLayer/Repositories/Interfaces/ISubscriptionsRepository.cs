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
        Task<IEnumerable<Subscriptions>> GetByIdClient(int idClient);
        Task<int> UpdateState(int id, string state);
    }
}
