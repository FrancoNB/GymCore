using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.InterfaceRepositories
{
    public interface ICrudRepository<Entity> where Entity : class
    {
        int Insert(Entity entity);
        int Update(Entity entity);
        int Delete(int id);
        IEnumerable<Entity> GetAll();
    }
}
