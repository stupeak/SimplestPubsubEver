using System.Collections.Generic;
using UnityEngine;

namespace Stupeak.SimplestPubsubEver
{
    internal static class MessageBroker
    {
        private static readonly Dictionary<Channel, List<ISubscriber>> m_Subscribers = new();

        public static void Subscribe(ISubscriber subscriber, Channel channel)
        {
            if (m_Subscribers.TryGetValue(channel, out List<ISubscriber> subscribers))
            {
                subscribers.Add(subscriber);
            }
            else
            {
                m_Subscribers.Add(channel, new List<ISubscriber>() { subscriber });
            }
        }

        public static void Unsubscribe(ISubscriber subscriber, Channel channel)
        {
            if (m_Subscribers.TryGetValue(channel, out List<ISubscriber> subscribers))
            {
                subscribers.Remove(subscriber);
            }
        }

        public static void Publish<T>(T message, Channel channel)
            where T : IMessage
        {
            if (!m_Subscribers.TryGetValue(channel, out List<ISubscriber> subscribers))
            {
                return;
            }

            foreach (var subscriber in subscribers)
            {
                subscriber.OnNotify(message);
            }
        }

#if UNITY_EDITOR
        //domain reload

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        static void DomainReLoad()
        {
            m_Subscribers.Clear();
        }
#endif
    }
}
