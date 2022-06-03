namespace BusinessLayer.Support
{
    public interface IObservable
    {
        void Attach(IObserver observer);

        void Detach(IObserver observer);

        void Notify();
    }
}
