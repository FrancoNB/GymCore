using BusinessLayer.Models;
using BusinessLayer.Support;
using System.Collections.Generic;

namespace BusinessLayer.Cache
{
    public class PackagesCache : IObservable
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

        private List<IObserver> _observersList;

        private IEnumerable<PackagesModel> _resource;

        public IEnumerable<PackagesModel> Resource { get => _resource; set => _resource = value; }

        private PackagesCache()
        {
            _resource = new List<PackagesModel>();
            _observersList = new List<IObserver>();
        }

        public void Attach(IObserver observer)
        {
            this._observersList.Add(observer);

            observer.Update(this);
        }

        public void Detach(IObserver observer)
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
