using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Extensions.LocalMessage
{
    /// <summary>
    /// Represents the event publisher interface
    /// </summary>
    public interface IEventPublisher
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
    }
}
