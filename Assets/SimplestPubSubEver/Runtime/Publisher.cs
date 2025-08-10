namespace Stupeak.SimplestPubsubEver
{
    public class Publisher : IPublisher
    {
        public void Publish<T>(T message, Channel channel) where T : IMessage
        {
            MessageBroker.Publish(message, channel);
        }
    }
}