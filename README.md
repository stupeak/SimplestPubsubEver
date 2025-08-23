# SimplestPubSubEver
A super simple, lightweight, and fast PubSub pattern for Unity.

## Import Package

```
Window > Package Manager > (+) Plus Button > Add Package form git Url
```

git URL:

```
https://github.com/stupeak/SimplestPubSubEver.git?path=Assets/SimplestPubSubEver
```




## Examples

### Basic Usage

#### Define a message payload

```C#
using Stupeak.SimplestPubSubEver;

struct LoadScenePayLoadMessage : IMessage 
{
    public float value;
}
```

#### Subscribe and Ubsubscribe to an event
```C#
// ubsubscribe via subscription
ISubscription subscription;

void Awake()
{
    Subscriber subscriber = Messenger.MessageSubscriber();
    // or
    //Subscriber subscriber = new();

    // subscribe
    subscriber.Subscribe<LoadScenePayLoadMessage>(static (payload) =>
    {
        UnityEngine.Debug.Log($"value: {payload.value}");
    });
}

void Destroy()
{
    subscription?.Dispose();
}
```

#### Publisher an event

```C#
void Start()
{
    //create a message and publish to subscribers who are already subscribed to this event.
    LoadScenePayLoadMessage payload = new LoadScenePayLoadMessage(999, "Success");

    Publisher publisher = Messenger.MessagePublisher();
    publisher.Publish(payload);
}
```

#### Notify callback
```C#
subscriber.Subscribe<InfoMessage>(OnNotify);

void OnNotify() // message param is unnecessary
{   
    
}
```

#### Subscribe and Publish to different Channel

```C#
subscriber.Subscribe<Message>(() => { Debug.Log("hello world"); }, Channel.FromType<Message>()));

publisher.Publish(new Message(), Channel.FromType<Message>());
```

#### SubscriptionBag
SubscriptionBag is a list of ISubscription, allowing you to unsubscribe multiple subscriptions at once.

```C#
SubscriptionBag subscriptions = new(4);

subscriber.Subscribe<M1>(() => { }).AddTo(subscriptions);
subscriber.Subscribe<M1>((m) => { }).AddTo(subscriptions);
subscriber.Subscribe<M2>((m) => { }).AddTo(subscriptions);

subscriptions?.Dispose();
```


### Async PubSub (UniTask)

