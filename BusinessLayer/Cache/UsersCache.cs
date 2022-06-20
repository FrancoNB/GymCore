using BusinessLayer.Models;
using BusinessLayer.Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Cache
{
    public class UsersCache : Subscribeable<UsersModel>
    {
        private static UsersCache instance;

        private static readonly object _lock = new object();
        public static UsersCache GetInstance()
        {
            if (instance == null)
            {
                lock (_lock)
                {
                    if (instance == null)
                    {
                        instance = new UsersCache();
                    }
                }
            }

            return instance;
        }

        private UsersCache()
        {
            _resource = new List<UsersModel>();
            _subscriberList = new List<ISubscriber<UsersModel>>();
        }
    }
}
