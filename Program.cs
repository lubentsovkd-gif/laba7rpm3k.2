using laba7rpm3k._2.Observer_Pattern;
using laba7rpm3k._2.Strategy_Pattern;
using laba7rpm3k._2.Template_Method_Pattern;

namespace laba7rpm3k._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Подчищяем логи (они находятся в "\bin\Debug\net8.0")
            FileInfo logs = new FileInfo("logs.txt");
            if (logs.Exists) 
            {
                logs.Delete();
            }

            // Создаём всё необходимое
            EventMonitor monitor1 = new EventMonitor();
            EventMonitor monitor2 = new EventMonitor();

            MetricData CpuMetric = new MetricData("CPU", 95.0, 80.0, DateTime.Now);
            MetricData RamMetric = new MetricData("RAM", 6.7, 10.0, DateTime.Now);

            EventHandlerBase consoleHandler = new ConsoleHandler(new TextFormatStrategy());
            EventHandlerBase fileHandlerJson = new FileHandler(new JsonFormatStrategy());
            EventHandlerBase fileHandlerText = new FileHandler(new TextFormatStrategy());

            // Пускай monitor1 использует обработчики с TextFormatStrategy, а monitor – c Json
            monitor1.OnMetricExceeded += consoleHandler.ProcessEvent;
            monitor2.OnMetricExceeded += fileHandlerJson.ProcessEvent;
            monitor1.OnMetricExceeded += fileHandlerText.ProcessEvent;
            // Субъекты проверяют интересующие их метрики
            monitor1.CheckMetric(CpuMetric);
            monitor1.CheckMetric(RamMetric);
            monitor2.CheckMetric(RamMetric);

            // Ну и раз уж у нас таки есть возможность менять стратегию в обработчиках...
            consoleHandler.SetStrategy(new JsonFormatStrategy());
            monitor1.CheckMetric(CpuMetric);
        }
    }
}
