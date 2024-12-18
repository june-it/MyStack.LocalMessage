using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.LocalMessage.Subscriptions;

namespace Microsoft.Extensions.LocalMessage
{
    public class DefaultLocalEventBus : ILocalMessageBus
    {
        private readonly ISubscriptionManager _subscriptionManager;
        private readonly IServiceProvider _serviceProvider;
        public DefaultLocalEventBus(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _subscriptionManager = serviceProvider.GetRequiredService<ISubscriptionManager>();
        }
        public async virtual Task PublishAsync(ILocalEvent eventData, CancellationToken cancellationToken = default)
        {
            var eventType = eventData.GetType();
            var subscriptions = _subscriptionManager.GetSubscriptions(eventType);
            if (subscriptions != null)
            {
                foreach (var subscription in subscriptions)
                {
                    var eventHandlerType = subscription.HandlerType.MakeGenericType(subscription.MessageType);
                    var eventHandler = _serviceProvider.GetRequiredService(eventHandlerType);
                    await ((dynamic)eventHandler).HandleAsync((dynamic)eventData, cancellationToken);
                }
            }
        }

        public async Task PublishAsync(object eventData, CancellationToken cancellationToken = default)
        {
            var eventType = eventData.GetType();
            var subscriptions = _subscriptionManager.GetSubscriptions(eventType);
            if (subscriptions != null)
            {
                foreach (var subscription in subscriptions)
                {
                    var wrappedEvent = typeof(LocalEventWrapper<>).MakeGenericType(eventType);
                    var eventHandlerType = subscription.HandlerType.MakeGenericType(wrappedEvent);
                    var eventHandler = _serviceProvider.GetRequiredService(eventHandlerType);
                    var wrappedEventData = Activator.CreateInstance(wrappedEvent, eventData);
                    if (wrappedEventData == null)
                        throw new ArgumentNullException(nameof(wrappedEventData));
                    await ((dynamic)eventHandler).HandleAsync((dynamic)wrappedEventData, cancellationToken);
                }
            }
        }

        public async virtual Task<TResponse?> SendAsync<TResponse>(IRequest<TResponse> requestData, CancellationToken cancellationToken = default) where TResponse : class
        {
            var requestDataType = requestData.GetType();
            var subscriptions = _subscriptionManager.GetSubscriptions(requestDataType);
            if (subscriptions == null)
                throw new InvalidOperationException("No event subscriptions were found.");
            if (subscriptions != null && subscriptions.Count > 1)
                throw new InvalidOperationException("Only one event subscription is supported.");
            Type requestHandlerType;
            if (subscriptions?[0]?.ResponseType != null)
                requestHandlerType = subscriptions![0].HandlerType.MakeGenericType(subscriptions[0].MessageType, subscriptions[0].ResponseType!);
            else
                requestHandlerType = subscriptions![0].HandlerType.MakeGenericType(subscriptions[0].MessageType);
            var requestHandler = _serviceProvider.GetRequiredService(requestHandlerType);
            return await ((dynamic)requestHandler).HandleAsync((dynamic)requestData, cancellationToken);
        }

    }
}
