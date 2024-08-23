using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Extensions.LocalMessage
{
    /// <summary>
    /// 表示一个请求处理接口
    /// </summary>
    /// <typeparam name="TRequest">请求的类型</typeparam>
    /// <typeparam name="TResponse">响应的类型</typeparam>
    public interface IRequestHandler<TRequest, TResponse>
        where TRequest : class, IRequest<TResponse>
        where TResponse : class
    {
        Task<TResponse> HandleAsync(TRequest requestData, CancellationToken cancellationToken = default);
    }
}
