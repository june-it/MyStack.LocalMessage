namespace Microsoft.Extensions.LocalMessage
{
    /// <summary>
    /// 表示一个可返回结果的事件接口
    /// </summary>
    /// <typeparam name="TResponse"></typeparam>
    public interface IRequest<TResponse>
         where TResponse : class
    {
    }
}
