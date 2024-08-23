using System.Collections.Generic;

namespace Microsoft.Extensions.LocalMessage
{

    public class LocalEventWrapper<TData> : ILocalEvent
    {
        public TData Data { get; }
        public Dictionary<string, object> Metadata { get; }
        public LocalEventWrapper(TData data)
        {
            Data = data;
            Metadata = new Dictionary<string, object>();
        }
    }
    public class LocalEventWrapper : LocalEventWrapper<object>
    {
        public LocalEventWrapper(object data) : base(data)
        {
        }
    }
}
