using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Arithmetic Patter Matching Test Project
 Developer Name:Sohom Bhattacharya
 Date:25/08/2016 */

namespace ArithmeticPatternMatching
{
    public class ArithmeticPatternMatchingTest
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Your Arithmetic Expression");
            String s = Console.ReadLine();

            Double result = parsethisstring(s); // we parse the string to check for exception
            Console.WriteLine(result);
            Console.ReadKey();
        }

        public static double ArithmaticStringMatch(String input)
        {
            String expr = input;
            Stack<String> ops = new Stack<String>();
            Stack<Double> vals = new Stack<Double>();
            Double num1 = 0;
            Double num2 = 0;
            Double val = 0;
            String operation;
            Double carryreturn;
            for (int i = 0; i < expr.Length; i++)
            {
                String s = expr.Substring(i, 1);
                if (isdigittest(s))
                {
                    vals.Push(Double.Parse(s));//operand stack is pushed with operand value
                }
                else if (s.Equals("s"))// when it encounters 's' from sqrt then it pushes '$' in operator stack and in operand stack the value 2
                {                      // and jumps 4 places
                    vals.Push(2);
                    ops.Push("$");
                    i = i + 4;
                }
                else if (s.Equals(")")) // when we encounter ')' it ignores it
                {
                    //do nothing
                }
                else
                {
                    /*if the stack is not empty and if the top most element in the operator stack is having higher precedence than the incoming element 
                     then values from the operand stack and operator stack is popped and put into their respective arithmetic operation until operator stack is empty.
                     Aftet that the incoming element is pushed into the operator stack */
                    if (ops.Count != 0 && (TestPrecedence(ops.Peek()) > TestPrecedence(s)))
                    {
                        while (ops.Count != 0)
                        {
                            num1 = vals.Pop();
                            num2 = vals.Pop();
                            operation = ops.Pop();
                            val = calculate(num1, num2, operation);
                            vals.Push(val);
                            if(ops.Count>0 && TestPrecedence(operation)>TestPrecedence(ops.Peek()))
                              break;

                        }
                        
                        ops.Push(s);
                    }
                    /*if the stack is not empty and if the top most element in the operator stack is having lower precedence than the incoming element then the element is pushed 
                     operator stack*/
                    else if (ops.Count != 0 && (TestPrecedence(s) > TestPrecedence(ops.Peek())))
                    {
                        ops.Push(s);
                    }
                    /*if the stack is empty the incoming element is pushed into operator stack*/
                    else
                        ops.Push(s);

                }
            }
            /*after we parse the expression the values from the operand stack and operator stack is
             * popped and put into their respective arithmetic operation until operator stack is empty. */
                while (ops.Count != 0)
                        {
                            num1 = vals.Pop();
                            num2 = vals.Pop();
                            operation = ops.Pop();
                            //if (ops.Count != 0 && TestPrecedence(operation) < TestPrecedence(ops.Peek()))
                            //{
                            //    String temp = ops.Pop();
                            //  ops.Push(operation);
                            //  ops.Push(temp);
                            //  operation = ops.Pop();
                            //  val = calculate(num2, num1, operation);
                            //}
                            //else
                            val = calculate(num1, num2, operation);
                            vals.Push(val);

                        }
                carryreturn= vals.Pop();
                return carryreturn; //last value from operator stack is popped and returned
        }

        /*This method is checked for evaluating the precedence of the operators. The presedence is as follows
         squareroot> exponent > division >multiplication>subtraction >addition */
        public static int TestPrecedence(String incoming)
        {
            if (incoming.Equals("$")) return 6;
            if (incoming.Equals("^")) return 5;
            if (incoming.Equals("/")) return 4;
            if (incoming.Equals("*")) return 3;
            if (incoming.Equals("-")) return 2;
            if (incoming.Equals("+")) return 1;
            return 0;
        }
        /*This method is used for the calculation of the values popped out from the operand and operator stack*/
        public static double calculate(Double number1, Double number2, String op)
        {
            Double ret = 0;
            if (op.Equals("^")) ret = Math.Pow(number2, number1);
            if (op.Equals("$")) ret = Math.Sqrt(number1);
            if (op.Equals("/")) ret = number2 / number1;
            if (op.Equals("*")) ret = number2 * number1; 
            if (op.Equals("-")) ret = number2 - number1; 
            if (op.Equals("+")) ret = number2 + number1;
            return ret;

        }
        /* this method is used to check whether the icoming string is operator or operand . If operator then it gets checked for presedence in the 
         operator stack and if it an operand then it gets pushed into the operand stack. For operand the function returns true else it returns false*/
        public static bool isdigittest(String s)
        {
            double p;
            bool canconvert = Double.TryParse(s,out p);
            return canconvert;

        }
        /* this method is used for checking the string for exception whether it is having two back toback operators or whether it is
         * a prefix or postfix expression or is a combination of numeric values and character values not part of the operator range i.e (^,/,*,-,+) */
        public static Double parsethisstring(string input)
        {
            char[] c= input.ToCharArray();
            int k=0;
            int flag=0;
            Double s=0;
            String samplestring = "^/*-+" ;
            String secondsamplestring = "^/-*+0123456789sqrt()";
            try
            {
                for (int i = 0; i < c.Length; i++)
                {
                   if( i < c.Length - 1)
                    {
                    if (samplestring.Contains(c[i].ToString()) && samplestring.Contains(c[i + 1].ToString()) )
                        k = k + 1;
                    }
                    if (!secondsamplestring.Contains(c[i]))
                        flag = flag + 1;
                }

               // if (c[0] == '^' || c[0] == '/' || c[0] == '*' || c[0] == '+' || c[0] == '-' || c[c.Length - 1] == '^' || c[c.Length - 1] == '/' || c[c.Length - 1] == '*' || c[c.Length - 1] == '+' || c[c.Length - 1] == '-')
                if(samplestring.Contains(c[0])||samplestring.Contains(c[c.Length-1]))    
                throw new PreFixorPosfixException("Please enter infix expressions only and the expression value would be zero");
                else if (k > 0)
                    throw new RepeatsameOperatorException("Please Don't repeat operators back to back and the expression value would be zero");
                else if (flag > 0)
                    throw new InvalidStringException("Please enter a valid string and the expression value would be zero");
                else
                    s = ArithmaticStringMatch(input);
               

            }
            catch (PreFixorPosfixException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (RepeatsameOperatorException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (InvalidStringException xe)
            {
                Console.WriteLine(xe.Message);
            }
            return s;
        }
        


    }
}
