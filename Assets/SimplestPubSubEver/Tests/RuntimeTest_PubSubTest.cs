using UnityEngine;
using NUnit.Framework;

namespace Stupeak.SimplestPubSubEver.Sample
{
    internal class RuntimeTest_PubSubTest
    {
        SubscriptionBag subscriptionBag = new(1);

        [Test]
        public void SubscribeTest()
        {
            var subscriber = Messager.MessageSubscriber();

            subscriber.Subscribe<InfoMessage>(OnNotify).AddTo(subscriptionBag);
        }

        [Test]
        public void PublishTest()
        {
            IPublisher publisher = Messager.MessagePublisher();
            publisher.Publish(new InfoMessage() { value = 42 });
        }

        void OnNotify(InfoMessage message)
        {
            Debug.Log($"Received message with value: {message.value}");
            Debug.Assert(message.value == 42, "Message value should be 42");

            // Unsubscribe
            subscriptionBag?.Dispose();
        }

        struct InfoMessage : IMessage
        {
            public int value;
        }
    }
}
