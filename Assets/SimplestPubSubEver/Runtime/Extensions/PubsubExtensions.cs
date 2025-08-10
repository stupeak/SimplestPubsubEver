namespace Stupeak.SimplestPubsubEver
{
    public static class PubsubExtensions
    {
        public static void Publish<T>(this object _, Channel topic, T message)
            where T : IMessage
        {
            MessageBroker.Publish(message, topic);
        }

        public static ISubscriber Subscribe<T>(this object _,
            CallbackMessage<T> callback,
            Channel topic)
            where T : IMessage
        {
            ISubscriber subscriber = new Subscriber();
            subscriber.Subscribe(callback, topic);

            return subscriber;
        }
    }
}
