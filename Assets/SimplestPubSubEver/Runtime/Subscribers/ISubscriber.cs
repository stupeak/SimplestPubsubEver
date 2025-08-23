namespace Stupeak.SimplestPubSubEver
{
    public interface ISubscriber
    {
        ISubscription Subscribe<T>(IMessageHandler<T> messageHandler, Channel channel = default)
            where T : IMessage;
    }
}
