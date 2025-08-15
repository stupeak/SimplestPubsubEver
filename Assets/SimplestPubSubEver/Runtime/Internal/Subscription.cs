using System;
using System.Collections.Generic;

namespace Stupeak.SimplestPubSubEver
{
    public interface ISubscription : IDisposable
    {

    }

    internal sealed class Subscription<T> : ISubscription
    {
        Delegate callbackMessage;
        WeakReference<List<Delegate>> subscribedCallbacks;

        public Subscription(Delegate callbackMessage, List<Delegate> subscribedCallbacks)
        {
            this.callbackMessage = callbackMessage;
            this.subscribedCallbacks = new(subscribedCallbacks);
        }

        public void Dispose()
        {
            if (subscribedCallbacks.TryGetTarget(out var target))
            {
                target.Remove(callbackMessage);
            }

            callbackMessage = null;
        }
    }
}
