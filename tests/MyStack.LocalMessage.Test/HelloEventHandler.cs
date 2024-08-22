using Microsoft.Extensions.LocalMessage;

namespace MyStack.LocalMessage.Test
{
    public class HelloEventHandler : ILocalEventHandler<HelloEvent>
    {
        public async Task HandleAsync(HelloEvent eventData, CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask;
        }
    }
}
