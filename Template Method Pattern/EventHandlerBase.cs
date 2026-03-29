using laba7rpm3k._2.Observer_Pattern;
using laba7rpm3k._2.Strategy_Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba7rpm3k._2.Template_Method_Pattern
{
    public abstract class EventHandlerBase
    {
        protected IFormatStrategy _formatStrategy; //текущая стратегия
        protected EventHandlerBase(IFormatStrategy strategy)
        {
            _formatStrategy = strategy;
        }
        //Метод установки стратегии
        public void SetStrategy(IFormatStrategy strategy)
        {
            _formatStrategy = strategy;
        }
        /* Не совсем понятно зачем нам метод установки стратегии и её выбор:
         * В случае, если мы пишем в консоль, то хотим видеть тип TextFormatStrategy, он user-friendly (хорошо читаемый)
         * В случае, если записываем в файл, то мы это делаем в определённый формат (txt/json)
         *      то есть для каждого формата свой тип файла, как раз для этого и нужна стратегия,
         *      но в данной реализации получается, что можно использовать JsonFormatStrategy с
         *      выводом в консоль...
         */

        public void ProcessEvent(MetricEventArgs e)
        {
            var message = FormatMessage(e.EventType, e.Data); //форматируем по стратегии
            SendMessage(message); //отправляем уведомление
        }
        public abstract string FormatMessage(string type, object data);
        public abstract void SendMessage(string message);
    }
}
