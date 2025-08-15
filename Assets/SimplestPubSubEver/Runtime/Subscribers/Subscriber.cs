namespace Stupeak.SimplestPubSubEver
{
    public readonly struct Subscriber : ISubscriber
    {
        public ISubscription Subscribe<T>(CallbackMessage<T> callbackMessage, Channel channel = default)
            where T : IMessage
        {
            var subscription = MessageBroker.Subscribe(callbackMessage, channel);

            return subscription;
        }
    }
}