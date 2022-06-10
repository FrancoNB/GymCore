using BusinessLayer.Models;
using System.Collections.Generic;

namespace BusinessLayer.Cache
{
    public class CurrentAccountsCache : Subscribeable<CurrentAccountsModel>
    {
        private static CurrentAccountsCache instance;

        private static readonly object _lock = new object();
        public static CurrentAccountsCache GetInstance()
        {
            if (instance == null)
            {
                lock (_lock)
                {
                    if (instance == null)
                    {
                        instance = new CurrentAccountsCache();
                    }
                }
            }

            return instance;
        }

        private CurrentAccountsCache()
        {
            _resource = new List<CurrentAccountsModel>();
            _subscriberList = new List<ISubscriber<CurrentAccountsModel>>();
        }
    }
}
