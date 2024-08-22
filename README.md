# MyStack.LocalMessage

开源的轻量级本地事件总线类库


| nuget      | stats |
| ----------- | ----------- | 
| [![nuget](https://img.shields.io/nuget/v/MyStack.LocalMessage.svg?style=flat-square)](https://www.nuget.org/packages/MyStack.LocalMessage)    | [![stats](https://img.shields.io/nuget/dt/MyStack.LocalMessage.svg?style=flat-square)](https://www.nuget.org/stats/packages/MyStack.LocalMessage?groupby=Version)         |

# 开始使用

## 添加服务支持
``` 
services.AddLocalMessage(Assembly.GetExecutingAssembly());
```

## 1、事件订阅发布
### 定义事件
```
public class HelloEvent: ILocalEvent
{
}

```

### 订阅事件
```
public class HelloEventHandler : ILocalEventHandler<HelloEvent>
{
    public async Task HandleAsync(HelloEvent eventData, CancellationToken cancellationToken = default)
    {
        await Task.CompletedTask;
    }
}
```
### 发布事件
```
await eventBus.PublishAsync(new HelloEvent());
```
## 2、请求/响应订阅发布
### 定义请求
```
public class Ping : IRequest<Pong>
{
    
}
```
### 定义响应
```
 public class Pong
 {
 }
```

### 订阅请求并返回响应结果
```
public class PingHandler : IRequestHandler<Ping, Pong>
{
    public Task<Pong> HandleAsync(Ping eventData, CancellationToken cancellationToken = default)
    {
        return Task.FromResult(new Pong());
    }
}
```
### 发布请求
```
var pongMessage = eventBus.SendAsync(ping);
```

## 3、事件体订阅发布
### 定义事件体的消息对象
```
public class WrappedEventData
{
}

```

### 订阅事件体
```
public class WrappedEventHandler : ILocalEventHandler<WrappedEvent<WrappedEventData>>
{
    public async Task HandleAsync(WrappedEvent<WrappedEventData> eventData, CancellationToken cancellationToken = default)
    {
        await Task.CompletedTask;
    }
}
```

### 发布事件体
```
eventBus.SendAsync(new WrappedEventData());
```


# 许可证

MIT