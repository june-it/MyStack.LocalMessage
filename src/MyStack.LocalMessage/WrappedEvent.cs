using System.Collections.Generic;

namespace Microsoft.Extensions.LocalMessage
{
    
    public class WrappedEvent<TData> : ILocalEvent
    {
        public TData Data { get; }
        public Dictionary<string, object> Metadata { get; }
        public WrappedEvent(TData data)
        {
            Data = data;
            Metadata = new Dictionary<string, object>();
        }
    }
    public class WrappedEvent : WrappedEvent<object>
    {
        public WrappedEvent(object data) : base(data)
        {
        }
    }
}
