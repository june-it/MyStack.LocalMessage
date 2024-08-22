using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.LocalMessage;

namespace MyStack.LocalMessage.Test
{
    public class LocalMessageTest
    {
        public IServiceProvider GetServiceProvider()
        {
            var services = new ServiceCollection();
            services.AddLocalMessage(typeof(LocalMessageTest).Assembly);
            return services.BuildServiceProvider();
        }

        [Test]
        public void Send_Hello()
        {
            var messageBus = GetServiceProvider().GetRequiredService<ILocalMessageBus>();
            messageBus.PublishAsync(new HelloEvent());
            Assert.Pass();
        }
        [Test]
        public void Send_Ping_Pong()
        {
            var messageBus = GetServiceProvider().GetRequiredService<ILocalMessageBus>();
            var pong = messageBus.SendAsync(new Ping()).Result;
            Assert.IsNotNull(pong);
        }
        [Test]
        public void Send_WrappedEvent_Object()
        {
            var messageBus = GetServiceProvider().GetRequiredService<ILocalMessageBus>();
            messageBus.PublishAsync(new WrappedEventData());
            Assert.Pass();
        } 
    }
}