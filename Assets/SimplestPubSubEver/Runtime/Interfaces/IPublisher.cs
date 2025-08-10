namespace Stupeak.SimplestPubsubEver
{
    public interface IPublisher
    {
        public void Publish<T>(T message, Channel topic) where T : IMessage;

        public void Publish<T>(T message) where T : IMessage
        {
            Publish(message, Channel.Global());
        }
    }
}
