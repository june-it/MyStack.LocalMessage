using System.Collections.Generic;

namespace Microsoft.Extensions.LocalMessage.Subscriptions
{
    public interface ISubscriptionRegistrar
    {
        void Register(List<SubscriptionInfo> subscriptions);
    }
}
