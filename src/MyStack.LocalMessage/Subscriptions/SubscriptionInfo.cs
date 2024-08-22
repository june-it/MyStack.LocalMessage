using System;

namespace Microsoft.Extensions.LocalMessage.Subscriptions
{
    public class SubscriptionInfo
    {
        public SubscriptionInfo(Type eventType, Type eventHandlerType)
        {
            EventType = eventType;
            EventHandlerType = eventHandlerType;
        }
        public SubscriptionInfo(Type eventType, Type eventHandlerType, Type replyType)
        {
            EventType = eventType;
            EventHandlerType = eventHandlerType;
            ResponseType = replyType;
        }

        public Type EventType { get; }
        public Type EventHandlerType { get; }
        public Type? ResponseType { get; }
    }
}
