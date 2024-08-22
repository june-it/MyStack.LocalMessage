﻿using System.Threading.Tasks;
using System.Threading;
using System.Xml.Linq;

namespace Microsoft.Extensions.LocalMessage
{
    /// <summary>
    /// 表示一个本地事件订阅接口
    /// </summary>
    public interface ILocalEventHandler
    {
    }
    /// <summary>
    /// 表示一个事件订阅接口
    /// </summary>
    /// <typeparam name="TEvent">事件的类型</typeparam>
    public interface ILocalEventHandler<TEvent> : ILocalEventHandler
        where TEvent : class, ILocalEvent
    {
        Task HandleAsync(TEvent eventData, CancellationToken cancellationToken = default);
    }
  
}