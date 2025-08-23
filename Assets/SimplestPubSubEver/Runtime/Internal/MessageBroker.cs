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
        private static readonly Dictionary<Channel, Dictionary<Type, List<IMessageHandler>>> Channels = new();

        internal static ISubscription Subscribe<T>(IMessageHandler<T> messageHandler, Channel channel)
             where T : IMessage
        {
            var callbackMap = GetHandlerMap(channel);
            Type messageType = typeof(T);

            if (callbackMap.TryGetValue(messageType, out var messageHandlers))
            {
                messageHandlers.Add(messageHandler);
            }
            else
            {
                messageHandlers = new List<IMessageHandler>() { messageHandler };
                callbackMap.Add(messageType, messageHandlers);
            }

            return new Subscription<T>(messageHandler, messageHandlers);
        }


        internal static void Publish<T>(T message, Channel channel)
            where T : IMessage
        {
            var callbackMap = GetHandlerMap(channel);
            Type messageType = typeof(T);

            if (!callbackMap.TryGetValue(messageType, out var messageHandlers))
            {
                return;
            }

            foreach (var callbackMessage in messageHandlers)
            {
                ((IMessageHandler<T>)callbackMessage)?.Invoke(message);
            }
        }

        private static Dictionary<Type, List<IMessageHandler>> GetHandlerMap(Channel channel)
        {
            if (!Channels.TryGetValue(channel, out var handlerMap))
            {
                Channels.Add(channel, handlerMap = new Dictionary<Type, List<IMessageHandler>>());
            }

            return handlerMap;
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
