namespace Stupeak.SimplestPubSubEver
{
    public static class Messager
    {
        public static ISubscriber MessageSubscriber()
        {
            return new Subscriber();
        }

        public static IPublisher MessagePublisher()
        {
            return new Publisher();
        }
    }
}
