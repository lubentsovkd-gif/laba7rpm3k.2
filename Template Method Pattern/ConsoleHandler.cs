using laba7rpm3k._2.Observer_Pattern;
using laba7rpm3k._2.Strategy_Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba7rpm3k._2.Template_Method_Pattern
{
    public class ConsoleHandler : EventHandlerBase
    {
        public ConsoleHandler(IFormatStrategy strategy) : base(strategy) { }
        public override string FormatMessage(string type, object data)
        {
            return type + _formatStrategy.Format(data.ToString(), DateTime.Now);
        }
        public override void SendMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
