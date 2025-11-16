using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restoran_console_appp.Exceptions
{
    public class MoneyHasNotException : Exception
    {
        public MoneyHasNotException(string message) : base (message) { }
    }
}
