namespace BusinessLayer.Support
{
    public interface ISuscriber<T> where T : class
    {
        void Update(ISubscribeable<T> resource);
    }
}
