using System.Collections.Generic;
using UnityEngine;
using System;


#if PUBSUB_UNITASK
using Cysharp.Threading.Tasks;
using System.Threading;
#endif


namespace Stupeak.SimplestPubSubEver
{
    internal static class MessageBroker
    {
        private static readonly Dictionary<Channel, Dictionary<Type, List<Delegate>>> Channels = new();

        internal static ISubscription Subscribe<T>(CallbackMessage<T> callbackMessage, Channel channel)
            where T : IMessage
        {
            var callbackMap = GetCallbackMap(channel);
            Type messageType = typeof(T);

            if (callbackMap.TryGetValue(messageType, out var callbackMessages))
            {
                callbackMessages.Add(callbackMessage);
            }
            else
            {
                callbackMessages = new List<Delegate>() { callbackMessage };
                callbackMap.Add(messageType, callbackMessages);
            }

            return new Subscription<T>(callbackMessage, callbackMessages);
        }


        internal static void Publish<T>(T message, Channel channel)
            where T : IMessage
        {
            var callbackMap = GetCallbackMap(channel);
            Type messageType = typeof(T);

            if (!callbackMap.TryGetValue(messageType, out var callbackMessages))
            {
                return;
            }

            foreach (var callbackMessage in callbackMessages)
            {
                ((CallbackMessage<T>)callbackMessage).Invoke(message);
            }
        }

        private static Dictionary<Type, List<Delegate>> GetCallbackMap(Channel channel)
        {
            if (!Channels.TryGetValue(channel, out var callbackMap))
            {
                Channels.Add(channel, callbackMap = new Dictionary<Type, List<Delegate>>());
            }

            return callbackMap;
        }

#if PUBSUB_UNITASK
        internal static async UniTask PublishAsync<T>(T message, Channel channel, CancellationToken cancellationToken)
            where T : IMessage
        {
            await UniTask.CompletedTask;
        }
#endif


#if UNITY_EDITOR
        //domain reload

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        static void DomainReLoad()
        {
            Channels.Clear();
        }
#endif
    }
}
