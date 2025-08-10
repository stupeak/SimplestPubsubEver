
namespace Stupeak.SimplestPubsubEver
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

        public static Channel Global()
        {
            return new Channel(0);
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
    }
}