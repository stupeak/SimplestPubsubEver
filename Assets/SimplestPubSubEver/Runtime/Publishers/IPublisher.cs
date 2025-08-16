#if PUBSUB_UNITASK
#endif

namespace Stupeak.SimplestPubSubEver
{
    public interface IPublisher
    {
        void Publish<T>(T message, Channel channel = default)
            where T : IMessage;

        //#if PUBSUB_UNITASK
        //        UniTask PublishAsync<T>(T message, Channel channel = default, CancellationToken cancellationToken = default)
        //            where T : IMessage;
        //#endif
    }
}
