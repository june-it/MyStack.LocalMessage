using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Extensions.LocalMessage
{
    /// <summary>
    /// Represents an event subscription interface
    /// </summary>
    /// <typeparam name="TEvent">The type of the event</typeparam>
    public interface ILocalEventHandler<TEvent>
        where TEvent : class, ILocalEvent
    {
        Task HandleAsync(TEvent eventData, CancellationToken cancellationToken = default);
    }

}
