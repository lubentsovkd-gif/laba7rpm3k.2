using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba7rpm3k._2.Observer_Pattern
{
    public class EventMonitor
    {

        // Событие (Event) — это ключевой элемент паттерна Observer в C#
        public event MetricEventHandler? OnMetricExceeded;
        public void CheckMetric(MetricData eventData)
        {
            string metricName = eventData.MetricName; 
            double value = eventData.Value; 
            double threshold = eventData.Threshold;
            Console.WriteLine($"[Monitor]: Checking {metricName} ({value} vs {threshold})");
            if (value > threshold)
            {

                // Вместо цикла foreach в методе Notify, мы просто вызываем событие.
                // ?.Invoke проверяет, есть ли подписчики.
                OnMetricExceeded?.Invoke(new MetricEventArgs(eventType: metricName + "_Exceeded", data: eventData));
            }
        }
    }
}
