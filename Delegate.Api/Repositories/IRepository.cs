namespace Delegate.Api.Repositories
{
    public interface IRepository<T>
    {
        Task Add(T data);
        Task Add(IList<T> data);
    }
}
