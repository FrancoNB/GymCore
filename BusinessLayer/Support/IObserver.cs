namespace BusinessLayer.Support
{
    public interface IObserver
    {
        void Update(IObservable resource);
    }
}
