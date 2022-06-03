using BusinessLayer.Models;
using BusinessLayer.Cache;
using System.Collections.Generic;

namespace BusinessLayer.Cache
{
    public class ClientsCache : Subscribeable<ClientsModel>
    {
        private static ClientsCache instance;

        private static readonly object _lock = new object();
        public static ClientsCache GetInstance()
        {
            if (instance == null)
            {
                lock (_lock)
                {
                    if (instance == null)
                    {
                        instance = new ClientsCache();
                    }
                }
            }

            return instance;
        }

        private ClientsCache()
        {
            _resource = new List<ClientsModel>();
            _subscriberLit = new List<ISubscriber<ClientsModel>>();
        }
    }
}
