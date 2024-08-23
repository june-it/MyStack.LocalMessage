using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Extensions.LocalMessage
{
    /// <summary>
    /// 表示本地事件总线接口
    /// </summary>
    public interface ILocalMessageBus
    {
        /// <summary>
        /// 发布一个事件
        /// </summary>
        /// <param name="eventData">事件数据</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns></returns>
        Task PublishAsync(ILocalEvent eventData, CancellationToken cancellationToken = default);
        /// <summary>
        /// 发布一个事件体
        /// </summary>
        /// <param name="eventData">事件体对象</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns></returns>
        Task PublishAsync(object eventData, CancellationToken cancellationToken = default);
        /// <summary>
        /// 发送一个有返回结果的事件请求
        /// </summary>
        /// <typeparam name="TResponse">返回结果的类型</typeparam>
        /// <param name="requestData">事件数据</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns>处理成功时返回结果，否则返回null</returns>
        Task<TResponse?> SendAsync<TResponse>(IRequest<TResponse> requestData, CancellationToken cancellationToken = default)
            where TResponse : class;
    }
}
