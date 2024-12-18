# MyStack.LocalMessage

Open-source lightweight local message bus library


| nuget      | stats |
| ----------- | ----------- | 
| [![nuget](https://img.shields.io/nuget/v/MyStack.LocalMessage.svg?style=flat-square)](https://www.nuget.org/packages/MyStack.LocalMessage)    | [![stats](https://img.shields.io/nuget/dt/MyStack.LocalMessage.svg?style=flat-square)](https://www.nuget.org/stats/packages/MyStack.LocalMessage?groupby=Version)         |

# Getting Started

## Add Service Support
``` 
services.AddLocalMessage(Assembly.GetExecutingAssembly());
```

## 1、Event Subscription and Publication
### Define Events
```
public class HelloEvent: ILocalEvent
{
}

```

### Subscribe to Events
```
public class HelloEventHandler : ILocalEventHandler<HelloEvent>
{
    public async Task HandleAsync(HelloEvent eventData, CancellationToken cancellationToken = default)
    {
        await Task.CompletedTask;
    }
}
```
### Publish Events
```
await eventBus.PublishAsync(new HelloEvent());
```
## 2、Request/Response Subscription and Publication
### Define Requests
```
public class Ping : IRequest<Pong>
{
    
}
```
### Define Responses
```
 public class Pong
 {
 }
```

### Subscribe to Requests and Return Response Results
```
public class PingHandler : IRequestHandler<Ping, Pong>
{
    public Task<Pong> HandleAsync(Ping eventData, CancellationToken cancellationToken = default)
    {
        return Task.FromResult(new Pong());
    }
}
```
### Publish Requests
```
var pongMessage = eventBus.SendAsync(ping);
```

## 3、Wrapped Event Data Subscription and Publication
### Define Wrapped Event Data
```
public class WrappedEventData
{
}

```

### Subscribe to Wrapped Event Data
```
public class WrappedEventHandler : ILocalEventHandler<LocalEventWrapper<WrappedEventData>>
{
    public async Task HandleAsync(LocalEventWrapper<WrappedEventData> eventData, CancellationToken cancellationToken = default)
    {
        await Task.CompletedTask;
    }
}
```

###  Publish Wrapped Event Data
```
eventBus.SendAsync(new WrappedEventData());
```


#  License

MIT