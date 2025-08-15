using UnityEngine;

namespace Stupeak.SimplestPubSubEver
{
    public static class PubsubExtensions
    {
        public static void Publish<T>(this Component unityComponent, T message)
            where T : IMessage
        {
            MessageBroker.Publish(message, Channel.FromScene(unityComponent.gameObject.scene));
        }

        public static ISubscription Subscribe<T>(this Component unityComponent, CallbackMessage<T> callback)
            where T : IMessage
        {
            ISubscriber subscriber = new Subscriber();
            ISubscription subscription = subscriber.Subscribe(callback, Channel.FromScene(unityComponent.gameObject.scene));

            return subscription;
        }
    }
}
