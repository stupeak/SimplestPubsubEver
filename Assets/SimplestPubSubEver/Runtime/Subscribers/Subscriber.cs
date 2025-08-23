
using System;

namespace Stupeak.SimplestPubSubEver
{
    public readonly struct Subscriber : ISubscriber
    {
        public ISubscription Subscribe<T>(Action callback, Channel channel = default)
            where T : IMessage
        {
            return Subscribe<T>(new CallbackMessage(callback), channel);
        }

        public ISubscription Subscribe<T>(CallbackMessage callback, Channel channel = default)
            where T : IMessage
        {
            CallbackMessageHandler<T> messageHandler = new(callback);

            return Subscribe(messageHandler, channel);
        }

        public ISubscription Subscribe<T>(CallbackMessage<T> callbackMessage, Channel channel = default)
            where T : IMessage
        {
            CallbackMessageHandler<T> messageHandler = new(callbackMessage);

            return Subscribe(messageHandler, channel);
        }

        public ISubscription Subscribe<T>(IMessageHandler<T> messageHandler, Channel channel = default) where T : IMessage
        {
            var subscription = MessageBroker.Subscribe(messageHandler, channel);

            return subscription;
        }
    }
}