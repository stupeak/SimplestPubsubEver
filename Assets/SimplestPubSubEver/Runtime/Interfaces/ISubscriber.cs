namespace Stupeak.SimplestPubsubEver
{
    public interface ISubscriber
    {
        //Dictionary<channel, Delegate> callbackMessages { get; set; }

        ISubscription Subscribe<T>(CallbackMessage<T> callbackMessage)
            where T : IMessage;

        void OnNotify<T>(T message) where T : IMessage;
    }
}
