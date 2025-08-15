using System;
using System.Collections.Generic;

namespace Stupeak.SimplestPubSubEver
{
    public class SubscriptionBag : IDisposable
    {
        List<ISubscription> subscriptions;

        public SubscriptionBag(int capacity = 0)
        {
            subscriptions = new(capacity);
        }

        public void Add(ISubscription subscription)
        {
            subscriptions.Add(subscription);
        }

        public void Dispose()
        {
            for (var i = 0; i < subscriptions.Count; i++)
            {
                subscriptions[i].Dispose();
            }

            subscriptions = null;
        }
    }

    public static class SubscriptionListExtension
    {
        public static void AddTo(this ISubscription subscription, SubscriptionBag subscriptionList)
        {
            subscriptionList.Add(subscription);
        }
    }
}
