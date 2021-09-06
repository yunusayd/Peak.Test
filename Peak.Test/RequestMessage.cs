using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Peak.Test
{
    public class RequestMessage
    {
        public int Prop1 { get; set; }
        public string Prop2 { get; set; }
        public DateTime Prop3 { get; set; }
        public Dictionary<string, object> Items { get; set; } = new Dictionary<string, object>();

        public TReturnType Get<TReturnType>()
        {
            foreach (KeyValuePair<string, object> item in Items)
            {
                if (item.Value != null && item.Value.GetType() == typeof(TReturnType))
                {
                    return (TReturnType)item.Value;
                }
            }
            return default(TReturnType);
        }
        public RequestMessage Add(object o)
        {
            if (Items.ContainsKey(o.GetType().FullName))
                throw new ArgumentException($"Duplicate Key {o.GetType().FullName}");

            Items.Add(o.GetType().FullName, o);
            return this;
        }
    }
}
