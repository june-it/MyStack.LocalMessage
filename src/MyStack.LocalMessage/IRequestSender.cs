using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Extensions.LocalMessage
{
    /// <summary>
    /// Represents the request sender interface
    /// </summary>
    public interface IRequestSender
    {
        /// <summary>
        /// Send an event request with a return result
        /// </summary>
        /// <typeparam name="TResponse">The type of the return result</typeparam>
        /// <param name="requestData">Request data</param>
        /// <param name="cancellationToken">Cancellation Token</param>
        /// <returns>Returns the result if processing is successful, otherwise returns null</returns>
        Task<TResponse?> SendAsync<TResponse>(IRequest<TResponse> requestData, CancellationToken cancellationToken = default)
            where TResponse : class;
    }
}
