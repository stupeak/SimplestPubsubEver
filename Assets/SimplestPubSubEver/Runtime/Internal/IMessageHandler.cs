
namespace Stupeak.SimplestPubSubEver
{
    public interface IMessageHandler
    {

    }

    public interface IMessageHandler<T> : IMessageHandler
        where T : IMessage
    {
        void Invoke(T message);
    }
}
