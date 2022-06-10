using BusinessLayer.Models;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer.Cache
{
    public class SubscriptionsCache : Subscribeable<SubscriptionsModel>
    {
        private static SubscriptionsCache instance;

        private static readonly object _lock = new object();
        public static SubscriptionsCache GetInstance()
        {
            if (instance == null)
            {
                lock (_lock)
                {
                    if (instance == null)
                    {
                        instance = new SubscriptionsCache();
                    }
                }
            }

            return instance;
        }

        private SubscriptionsCache()
        {
            _resource = new List<SubscriptionsModel>();
            _subscriberList = new List<ISubscriber<SubscriptionsModel>>();
        }

        public bool isEmpty()
        {
            return _resource.ToList().Count == 0;
        }
    }
}
