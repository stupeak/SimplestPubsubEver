namespace Stupeak.SimplestPubSubEver
{
    public interface ISubscriber
    {
        ISubscription Subscribe<T>(CallbackMessage<T> callbackMessage, Channel channel = default)
            where T : IMessage;
    }
}
