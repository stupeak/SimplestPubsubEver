# SimplestPubSubEver
A super simple, lightweight, and fast PubSub pattern for Unity.

### Import Package

```
Window > Package Manager > (+) Plus Button > Add Package form git Url
```

git URL:

```
https://github.com/stupeak/SimplestPubSubEver.git?path=Assets/SimplestPubSubEver
```




### Example

```C#
using Stupeak.SimplestPubSubEver;

```


#### Message

```C#
internal readonly struct LoadScenePayLoadMessage : IMessage        //sample payload message
{
    public readonly float value;
    public readonly string state;

    public LoadScenePayLoadMessage(float value, string state)
    {
        this.value = value;
        this.state = state;
    }
}
```

#### Subscriber

```C#
ISubscriber subscriber { get; set; }

//subscribe with topic
subscriber.Subscribe<LoadScenePayLoadMessage>(Topic.FromMessage<LoadScenePayLoadMessage>(), static (payload) =>
{
    UnityEngine.Debug.Log($"state: {payload.state}, value: {payload.value}");
});

```

#### Publisher

```C#
IPublisher publisher { get; set; }

//create a message and publish to subscribers who are already subscribed to this event.
LoadScenePayLoadMessage payload = new LoadScenePayLoadMessage(999, "Success");
publisher.Publish(loadTopic, payload);
```

#### Topic

```C#
Topic loadTopic = Topic.FromMessage<LoadScenePayLoadMessage>();      //sample topic to publish
```
