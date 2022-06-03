namespace BusinessLayer.Support
{
    public interface ISubscribeable<T> where T : class
    {
        void Attach(ISuscriber<T> observer);

        void Detach(ISuscriber<T> observer);

        void Notify();
    }
}
