using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Extensions.LocalMessage
{
    /// <summary>
    /// Represents a request handling interface
    /// </summary>
    /// <typeparam name="TRequest">The type of the request</typeparam>
    /// <typeparam name="TResponse">The type of the response</typeparam>
    public interface IRequestHandler<TRequest, TResponse>
        where TRequest : class, IRequest<TResponse>
        where TResponse : class
    {
        Task<TResponse> HandleAsync(TRequest requestData, CancellationToken cancellationToken = default);
    }
}
