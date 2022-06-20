using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.InterfaceRepositories
{
    public interface ICrudRepository<Entity> where Entity : class
    {
        Task<int> Insert(Entity entity);
        Task<int> Update(Entity entity);
        Task<int> Delete(int id);
        Task<IEnumerable<Entity>> GetAll();
        Task<int> GetLastId();
    }
}
