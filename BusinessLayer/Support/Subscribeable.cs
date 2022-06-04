using System.Collections.Generic;

namespace BusinessLayer.Cache
{
    public abstract class Subscribeable<T> : ISubscribeable<T> where T : class
    {
        protected IEnumerable<T> _resource;
        protected List<ISubscriber<T>> _subscriberLit;

        public IEnumerable<T> Resource { get => _resource; set { _resource = value; Notify(); } }

        public void Attach(ISubscriber<T> observer)
        {
            this._subscriberLit.Add(observer);

            observer.Update(this);
        }

        public void Detach(ISubscriber<T> observer)
        {
            this._subscriberLit.Remove(observer);
        }

        public void Notify()
        {
            foreach (var observer in _subscriberLit)
            {
                observer.Update(this);
            }
        }
    }
}
