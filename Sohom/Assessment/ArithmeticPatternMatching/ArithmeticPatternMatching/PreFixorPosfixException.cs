using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArithmeticPatternMatching
{
    public class PreFixorPosfixException:Exception//if the user enters an prefix or postfix expression this exception is thrown
    {
        public PreFixorPosfixException(String p) :base(p)
        {
        }
    }
}
