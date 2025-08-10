using UnityEngine;
using NUnit.Framework;

namespace Stupeak.SimplestPubsubEver.Sample
{
    internal class SubscriberTest
    {
        ISubscription subscription1;

        [Test]
        public void SubscribeTest()
        {
            ISubscriber subscriber = new Subscriber();

            subscription1 = subscriber.Subscribe<InfoMessage>(OnNotify);
        }

        [Test]
        public void UnsubscribeTest()
        {
            subscription1?.Unsubscribe();
        }

        void OnNotify(InfoMessage message)
        {
            Debug.Log($"Received message with value: {message.value}");
            Debug.Assert(message.value == 4, "Message value should be 42");
        }
    }

    internal class PublisherTest 
    {
        [Test]
        public void PublishTest()
        {
            IPublisher publisher = new Publisher();
            publisher.Publish(new InfoMessage() { value = 42 });
        }
    }


    struct InfoMessage : IMessage
    {
        public int value;
    }
}
