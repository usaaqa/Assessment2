using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArithmeticPatternMatching
{
    class InvalidStringException : Exception //if the user enters an invalid arithmetic expression this exception is thrown
    {
        public InvalidStringException(String p)
            : base(p)
        { }
    }
}
