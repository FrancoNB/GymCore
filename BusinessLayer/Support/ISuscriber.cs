using System.Collections.Generic;

namespace BusinessLayer.Cache
{
    public interface ISubscriber<T> where T : class, new()
    {
        void Update(IEnumerable<T> resource);
    }
}
