namespace Stupeak.SimplestPubsubEver
{
    public interface IListener
    {
        void OnNotify<T>(T message) where T : IMessage;
    }
}
