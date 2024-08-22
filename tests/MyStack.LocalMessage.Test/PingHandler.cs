using Microsoft.Extensions.LocalMessage;

namespace MyStack.LocalMessage.Test
{
    public class PingHandler : IRequestHandler<Ping, Pong>
    {
        public async Task<Pong> HandleAsync(Ping eventData, CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask;
            return new Pong() { Content = "OK" };
        }
    }
}
