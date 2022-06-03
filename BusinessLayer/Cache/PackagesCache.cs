using BusinessLayer.Models;
using BusinessLayer.Support;
using System.Collections.Generic;

namespace BusinessLayer.Support
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
            _subscriberLit = new List<ISubscriber<PackagesModel>>();
        }
    }
}
