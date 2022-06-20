using BusinessLayer.Models;
using System.Collections.Generic;

namespace BusinessLayer.Cache
{
    public class PaymentsCache : Subscribeable<PaymentsModel>
    {
        private static PaymentsCache instance;

        private static readonly object _lock = new object();
        public static PaymentsCache GetInstance()
        {
            if (instance == null)
            {
                lock (_lock)
                {
                    if (instance == null)
                    {
                        instance = new PaymentsCache();
                    }
                }
            }

            return instance;
        }

        private PaymentsCache()
        {
            _resource = new List<PaymentsModel>();
            _subscriberList = new List<ISubscriber<PaymentsModel>>();
        }
    }
}
