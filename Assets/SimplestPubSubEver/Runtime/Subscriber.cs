
using System;
using System.Collections.Generic;

namespace Stupeak.SimplestPubsubEver
{
    public class Subscriber : ISubscriber
    {
        private List<Delegate> callbackMessages = new();

        private Channel channel;

        public Subscriber() : this(Channel.Global())
        {

        }

        public Subscriber(Channel channel)
        {
            this.channel = channel;
        }

        public virtual ISubscription Subscribe<T>(CallbackMessage<T> callbackMessage) where T : IMessage
        {
            callbackMessages.Add(callbackMessage);
            MessageBroker.Subscribe(this, channel);

            return new Subscription(this, channel);
        }

        public virtual void OnNotify<T>(T message) where T : IMessage
        {
            for (var i = 0; i < callbackMessages.Count; i++)
            {
                if(callbackMessages[i] is CallbackMessage<T> callback)
                {
                    callback.Invoke(message);
                }
            }
        }
    }
}