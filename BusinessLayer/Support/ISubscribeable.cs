namespace BusinessLayer.Cache
{
    public interface ISubscribeable<T> where T : class, new()
    {
        void Attach(ISubscriber<T> observer);

        void Detach(ISubscriber<T> observer);

        void Notify();
    }
}
