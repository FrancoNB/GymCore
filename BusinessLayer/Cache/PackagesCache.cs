using BusinessLayer.Models;
using BusinessLayer.Support;
using System.Collections.Generic;

namespace BusinessLayer.Cache
{
    public class PackagesCache : ISubscribeable<PackagesModel>
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

        private List<ISuscriber<PackagesModel>> _observersList;

        private IEnumerable<PackagesModel> _resource;

        public IEnumerable<PackagesModel> Resource { get => _resource; set => _resource = value; }

        private PackagesCache()
        {
            _resource = new List<PackagesModel>();
            _observersList = new List<ISuscriber<PackagesModel>>();
        }

        public void Attach(ISuscriber<PackagesModel> observer)
        {
            this._observersList.Add(observer);

            observer.Update(this);
        }

        public void Detach(ISuscriber<PackagesModel> observer)
        {
            this._observersList.Remove(observer);
        }

        public void Notify()
        {
            foreach (var observer in _observersList)
            {
                observer.Update(this);
            }
        }
    }
}
