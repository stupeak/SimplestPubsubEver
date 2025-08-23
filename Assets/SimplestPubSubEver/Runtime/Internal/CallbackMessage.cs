using System;
using UnityEngine.Events;

namespace Stupeak.SimplestPubSubEver
{
    public delegate void CallbackMessage();

    public delegate void CallbackMessage<T>(T message) where T : IMessage;

    internal class CallbackMessageHandler<TMessage> : IMessageHandler<TMessage>
        where TMessage : IMessage
    {
        private readonly Delegate m_Delegate;

        public CallbackMessageHandler(CallbackMessage callback)
        {
            m_Delegate = callback;
        }

        public CallbackMessageHandler(CallbackMessage<TMessage> callback)
        {
            m_Delegate = callback;
        }

        void IMessageHandler<TMessage>.Invoke(TMessage message)
        {
            if (m_Delegate is CallbackMessage callbackMessage)
            {
                callbackMessage?.Invoke();
            }
            else if (m_Delegate is CallbackMessage<TMessage> callbackMessage_T)
            {
                callbackMessage_T?.Invoke(message);
            }
            else
            {
                throw new InvalidOperationException("handler is invalid");
            }
        }
    }


    public class UnityMessageHandler<TMessage> : UnityEvent<TMessage>, IMessageHandler<TMessage>
        where TMessage : IMessage
    {
        void IMessageHandler<TMessage>.Invoke(TMessage message)
        {
            this.Invoke(message);
        }
    }
}
