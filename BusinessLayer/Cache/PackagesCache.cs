using BusinessLayer.Models;
using BusinessLayer.Cache;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer.Cache
{
    public class PackagesCache : Subscribeable<PackagesModel>
    {
        private static PackagesCache instance;

        private static readonly object _lock = new object();
        public static PackagesCache GetInstance()
        {
            if (instance == null)
            {
                lock (_lock)
                {
                    if (instance == null)
                    {
                        instance = new PackagesCache();
                    }  
                }
            }

            return instance;
        }

        private PackagesCache()
        {
            _resource = new List<PackagesModel>();
            _subscriberList = new List<ISubscriber<PackagesModel>>();
        }

        public bool isEmpty()
        {
            return _resource.ToList().Count == 0;
        }
    }
}
