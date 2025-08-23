namespace Stupeak.SimplestPubSubEver
{
    public static class Messager
    {
        public static Subscriber MessageSubscriber()
        {
            return new();
        }

        public static Publisher MessagePublisher()
        {
            return new();
        }
    }
}
