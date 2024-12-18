﻿using System;

namespace Microsoft.Extensions.LocalMessage.Subscriptions
{
    public class SubscriptionInfo
    {
        public SubscriptionInfo(Type messageType, Type handlerType)
        {
            MessageType = messageType;
            HandlerType = handlerType;
        }
        public SubscriptionInfo(Type messageType, Type handlerType, Type responseType)
        {
            MessageType = messageType;
            HandlerType = handlerType;
            ResponseType = responseType;
        }

        public Type MessageType { get; }
        public Type HandlerType { get; }
        public Type? ResponseType { get; }
    }
}
