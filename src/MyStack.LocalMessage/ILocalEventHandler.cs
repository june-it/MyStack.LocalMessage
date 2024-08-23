using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Extensions.LocalMessage
{
    /// <summary>
    /// 表示一个事件订阅接口
    /// </summary>
    /// <typeparam name="TEvent">事件的类型</typeparam>
    public interface ILocalEventHandler<TEvent>
        where TEvent : class, ILocalEvent
    {
        Task HandleAsync(TEvent eventData, CancellationToken cancellationToken = default);
    }

}
