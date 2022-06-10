using BusinessLayer.Models;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer.Cache
{
    public class AssistsCache : Subscribeable<AssistsModel>
    {
        private static AssistsCache instance;

        private static readonly object _lock = new object();
        public static AssistsCache GetInstance()
        {
            if (instance == null)
            {
                lock (_lock)
                {
                    if (instance == null)
                    {
                        instance = new AssistsCache();
                    }
                }
            }

            return instance;
        }

        private AssistsCache()
        {
            _resource = new List<AssistsModel>();
            _subscriberList = new List<ISubscriber<AssistsModel>>();
        }
    }
}
