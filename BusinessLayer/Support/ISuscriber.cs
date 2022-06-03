namespace BusinessLayer.Support
{
    public interface ISubscriber<T> where T : class
    {
        void Update(ISubscribeable<T> resource);
    }
}
