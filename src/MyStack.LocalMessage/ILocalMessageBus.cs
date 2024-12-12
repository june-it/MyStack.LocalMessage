using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Extensions.LocalMessage
{
    /// <summary>
    /// Represents the local message bus interface
    /// </summary>
    public interface ILocalMessageBus
    {
        /// <summary>
        /// Publish an Event
        /// </summary>
        /// <param name="eventData">Event</param>
        /// <param name="cancellationToken">Cancellation Token</param>
        /// <returns></returns>
        Task PublishAsync(ILocalEvent eventData, CancellationToken cancellationToken = default);
        /// <summary>
        /// Publish an Event Data
        /// </summary>
        /// <param name="eventData">Event data</param>
        /// <param name="cancellationToken">Cancellation Token</param>
        /// <returns></returns>
        Task PublishAsync(object eventData, CancellationToken cancellationToken = default);
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
