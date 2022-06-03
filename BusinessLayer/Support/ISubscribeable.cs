namespace BusinessLayer.Support
{
    public interface ISubscribeable<T> where T : class
    {
        void Attach(ISubscriber<T> observer);

        void Detach(ISubscriber<T> observer);

        void Notify();
    }
}
