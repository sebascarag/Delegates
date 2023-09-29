using Delegate.Api.Entities;

namespace Delegate.Api.Repositories
{
    public class Repository<T> : IRepository<T>
    {
        public Task Add(T data)
        {
            //TODO
            return Task.CompletedTask;
        }

        public Task Add(IList<T> data)
        {
            //TODO
            return Task.CompletedTask;
        }
    }
}
