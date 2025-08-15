
using UnityEngine.SceneManagement;

namespace Stupeak.SimplestPubSubEver
{
    public readonly struct Channel
    {
        public readonly int id;

        public Channel(int id)
        {
            this.id = id;
        }

        public override readonly int GetHashCode()
        {
            return id;
        }

        public static Channel Default()
        {
            return default;
        }

        public static Channel FromString(string str)
        {
            return new Channel(str.GetHashCode());
        }

        public static Channel FromMessage<T>() where T : IMessage
        {
            return Channel.FromString(typeof(T).FullName);
        }

        public static Channel FromType<T>()
        {
            return Channel.FromString(typeof(T).FullName);
        }

        public static Channel FromScene(Scene scene)
        {
            return Channel.FromString(scene.path);
        }
    }
}