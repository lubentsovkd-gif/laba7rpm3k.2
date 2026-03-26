using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba7rpm3k._2.Strategy_Pattern
{
    public interface IFormatStrategy
    {
        string Format(string message, DateTime timestamp);
    }
}
