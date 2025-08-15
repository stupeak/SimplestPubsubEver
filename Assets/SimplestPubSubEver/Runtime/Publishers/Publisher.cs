#if PUBSUB_UNITASK
using Cysharp.Threading.Tasks;
using System.Threading;
#endif


namespace Stupeak.SimplestPubSubEver
{
    public readonly struct Publisher : IPublisher
    {
        public void Publish<T>(T message, Channel channel = default) where T : IMessage
        {
            MessageBroker.Publish(message, channel);
        }

#if PUBSUB_UNITASK
        public async UniTask PublishAsync<T>(T message, Channel channel = default, CancellationToken cancellationToken = default)
            where T : IMessage
        {
            await MessageBroker.PublishAsync(message, channel, cancellationToken);
        }
#endif
    }
}