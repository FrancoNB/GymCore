using System.Collections.Generic;

namespace BusinessLayer.Cache
{
    public abstract class Subscribeable<T> : ISubscribeable<T> where T : class, new()
    {
        protected IEnumerable<T> _resource;
        protected List<ISubscriber<T>> _subscriberList;

        public IEnumerable<T> Resource { set { _resource = value; Notify(); } }

        public void Attach(ISubscriber<T> observer)
        {
            this._subscriberList.Add(observer);

            observer.Update(_resource);
        }

        public void Detach(ISubscriber<T> observer)
        {
            this._subscriberList.Remove(observer);
        }

        public void Notify()
        {
            foreach (var observer in _subscriberList)
            {
                observer.Update(_resource);
            }
        }
    }
}
