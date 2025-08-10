using UnityEngine;
using NUnit.Framework;

namespace Stupeak.SimplestPubsubEver.Sample
{
    internal class MonoSubscriberTest : MonoBehaviour
    {

        [Test]
        public void SubscribeTest()
        {
            this.Subscribe<InfoMessage>(OnNotify, Channel.Global());
        }

        private void OnDestroy()
        {
            
        }


        void OnNotify(InfoMessage message)
        {
            Debug.Log($"Received message with value: {message.value}");
            Debug.Assert(message.value == 4, "Message value should be 42");
        }
    }
}
