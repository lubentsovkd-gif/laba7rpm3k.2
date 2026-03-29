using laba7rpm3k._2.Strategy_Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba7rpm3k._2.Template_Method_Pattern
{
    public class FileHandler : EventHandlerBase
    {
        public FileHandler(IFormatStrategy strategy) : base(strategy) { }
        public override string FormatMessage(string type, object data)
        {
            return type + _formatStrategy.Format(data.ToString(), DateTime.Now);
        }
        public override void SendMessage(string message)
        {
            File.AppendAllText("logs.txt", message+"\n");
            /*
             * Возвращаясь к длинному комментарию в EventHandlerBase.cs...
             * 
             * По-хорошему стоило бы сделать тип файла зависящим от IFormatStrategy
             * или сделать весь класс абстрактным и наследовать из него что-то вроде
             * JsonHandler & TextHandler || ByteHandler (если бы преобразовывали текст
             * в цепочку битов), используя паттерн Стратегия внутри Шаблонного Метода
             * 
             * Но раз в задании сказано "имитация системы", то и запариваться я не стал
             */
        }
    }
}
