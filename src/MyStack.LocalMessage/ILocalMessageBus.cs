namespace Microsoft.Extensions.LocalMessage
{
    /// <summary>
    /// Represents the local message bus interface
    /// </summary>
    public interface ILocalMessageBus : IEventPublisher, IRequestSender
    {
    }
}
