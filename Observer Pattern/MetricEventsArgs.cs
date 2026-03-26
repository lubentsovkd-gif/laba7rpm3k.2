using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba7rpm3k._2.Observer_Pattern
{
    public class MetricEventArgs(string eventType, MetricData data) : EventArgs
    {
        public string EventType { get; } = eventType ?? throw new ArgumentNullException(nameof(eventType));
        public MetricData Data { get; } = data ?? throw new ArgumentNullException(nameof(data));
    }
}
