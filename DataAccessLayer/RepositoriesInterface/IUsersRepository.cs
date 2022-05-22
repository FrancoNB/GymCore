using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.InterfaceRepositories
{
    public interface IUsersRepository : ICrudRepository<Users>
    {
        Users GetUser(string username, string password);
        int UpdateLastConnection(DateTime lastConnection, int idUser);
    }
}
