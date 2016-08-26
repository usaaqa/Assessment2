using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArithmeticPatternMatching
{
    class RepeatsameOperatorException : Exception //if the user enters two back to back operators in the expression this exception is thrown
    {
        public RepeatsameOperatorException(String p)
            : base(p)
        { }
    }
}
