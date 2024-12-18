using Microsoft.Extensions.LocalMessage;

namespace MyStack.LocalMessage.Test
{
    public class WrappedEventHandler : ILocalEventHandler<LocalEventWrapper<WrappedEventData>>
    {
        public async Task HandleAsync(LocalEventWrapper<WrappedEventData> eventData, CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask;
        }
    }
}
