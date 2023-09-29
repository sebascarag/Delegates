namespace Delegate.Api.Dtos
{
    public class Response<TResult>
    {
        public List<TResult> Results { get; set; }
    }
}
