using UnityEngine.Events;

namespace Stupeak.SimplestPubSubEver
{
    public delegate void CallbackMessage(IMessage message);

    public delegate void CallbackMessage<T>(T message) where T : IMessage;

    public interface ICallbackMessage<T>
        where T : IMessage
    {
        void Invoke(T message);
    }

    public class CallbackMessageHandler<T> : ICallbackMessage<T>
        where T : IMessage
    {
        private readonly CallbackMessage<T> _callback;

        public CallbackMessageHandler(CallbackMessage<T> callback)
        {
            _callback = callback;
        }

        public void Invoke(T message)
        {
            _callback?.Invoke(message);
        }
    }

    public class UnityCallback<T> : UnityEvent<T>, ICallbackMessage<T>
        where T : IMessage
    {
        public new void Invoke(T message)
        {
            base.Invoke(message);
        }
    }
}
