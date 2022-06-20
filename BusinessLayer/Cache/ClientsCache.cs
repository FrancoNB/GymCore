using BusinessLayer.Models;
using System.Collections.Generic;
using System.Linq;

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
            _subscriberList = new List<ISubscriber<ClientsModel>>();
        }

        public bool isEmpty()
        {
            return _resource.ToList().Count == 0;
        }
    }
}
