using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dwdWarnings
{
    public class DwdException : Exception
    {
        public DwdException() : base() { }
        public DwdException(string message) : base(message) { }
        public DwdException(string message, System.Exception inner) : base(message, inner) { }
    }
}
