using System;
using System.Collections.Generic;

namespace Stupeak.SimplestPubSubEver
{
    public interface ISubscription : IDisposable
    {

    }

    internal sealed class Subscription<T> : ISubscription
        where T : IMessage
    {
        IMessageHandler<T> m_MessageHandler;
        WeakReference<List<IMessageHandler>> m_SubscribedCallbacks;

        public Subscription(IMessageHandler<T> messageHandler, List<IMessageHandler> subscribedCallbacks)
        {
            this.m_MessageHandler = messageHandler;
            this.m_SubscribedCallbacks = new(subscribedCallbacks);
        }

        public void Dispose()
        {
            if (m_SubscribedCallbacks.TryGetTarget(out var target))
            {
                target.Remove(m_MessageHandler);
            }

            m_MessageHandler = null;
        }
    }
}
