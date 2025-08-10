using System;

namespace Stupeak.SimplestPubsubEver
{
    public interface ISubscription : IDisposable
    {
        void Unsubscribe();
    }

    public class Subscription : ISubscription
    {
        ISubscriber subscriber;
        Channel channel;

        public Subscription(ISubscriber subscriber, Channel channel)
        {
            this.subscriber = subscriber;
            this.channel = channel;
        }

        public void Unsubscribe()
        {
            MessageBroker.Unsubscribe(subscriber, channel);
            subscriber = null;
        }

        void IDisposable.Dispose()
        {
            Unsubscribe();
        }
    }
}
