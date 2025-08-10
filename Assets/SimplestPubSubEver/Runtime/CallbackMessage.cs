namespace Stupeak.SimplestPubsubEver
{
    public delegate void CallbackMessage(IMessage message);

    public delegate void CallbackMessage<T>(T message) where T : IMessage;
}
