namespace Microsoft.Extensions.LocalMessage
{
    /// <summary>
    /// Represents an event interface that can return a result
    /// </summary>
    /// <typeparam name="TResponse"></typeparam>
    public interface IRequest<TResponse>
         where TResponse : class
    {
    }
}
