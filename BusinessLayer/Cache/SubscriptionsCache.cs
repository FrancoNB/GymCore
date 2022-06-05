using BusinessLayer.Models;
using System.Collections.Generic;

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
            _subscriberLit = new List<ISubscriber<SubscriptionsModel>>();
        }
    }
}
