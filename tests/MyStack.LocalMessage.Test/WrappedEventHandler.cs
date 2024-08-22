using Microsoft.Extensions.LocalMessage;

namespace MyStack.LocalMessage.Test
{
    public class WrappedEventHandler : ILocalEventHandler<WrappedEvent<WrappedEventData>>
    {
        public async Task HandleAsync(WrappedEvent<WrappedEventData> eventData, CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask;
        }
    }
}
