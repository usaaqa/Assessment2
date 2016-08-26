using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace MathExpressionEvaluator
{
    public class MathEvaluator
    {
        public static void CalclateExpression()  //Input for the program
        {
            Evaluate("Sqrt(4)");
            Evaluate("5*4/2");
            Evaluate("1+2+3");
            Evaluate("2+4/Sqrt(4)-4");
            Evaluate("a+2");
            Evaluate("Test");
        }

        public static void Evaluate(string expression)
        {
            bool validate = ValidateExp(expression);
            if (validate == false)
            {
                Console.WriteLine(expression + " = " + "Invalid Input");
            }
            else
            {
                var result = CalculateExpression(expression);
                Console.WriteLine(expression + " = " + result);
            }
        }

        public static bool ValidateExp(string validateExpression) //Validation 
        {
            Regex rg = new Regex(@"^[0-9+/*()-Sqrt]*$");
            return rg.IsMatch(validateExpression);
        }

        public static double CalculateExpression(String input)  //Calculate string Expression
        {
            String expr = "(" + input + ")";
            Stack<String> ops = new Stack<String>();
            Stack<Double> vals = new Stack<Double>();
            StringBuilder sb = new StringBuilder();


            for (int i = 0; i < expr.Length; i++)
            {
                String s = expr.Substring(i, 1);
                if (s.Equals("(")) { }
                else if (s.Equals("+")) ops.Push(s);
                else if (s.Equals("-")) ops.Push(s);
                else if (s.Equals("*")) ops.Push(s);
                else if (s.Equals("/")) ops.Push(s);
                else if (s.Equals("S") || s.Equals("q") || s.Equals("r") || s.Equals("t"))
                {
                    sb.Append(s);
                    string sqrt = sb.ToString();
                    if (sqrt.Equals("Sqrt"))
                    {
                        ops.Push(sqrt);
                    }
                }
                else if (s.Equals(")"))
                {
                    int count = ops.Count;
                    while (count > 0)
                    {
                        String op = ops.Pop();
                        double v = vals.Pop();
                        if (op.Equals("-")) v = vals.Pop() - v;
                        else if (op.Equals("+")) v = vals.Pop() + v;
                        else if (op.Equals("*")) v = vals.Pop() * v;
                        else if (op.Equals("/")) v = vals.Pop() / v;
                        else if (op.Equals("Sqrt")) v = Math.Sqrt(v);
                        vals.Push(v);

                        count--;
                    }
                }
                else vals.Push(Double.Parse(s));

            }
            return vals.Pop();
        }
    }

    class EvaluateExpression
    {
        static void Main(string[] args)
        {
            MathEvaluator.CalclateExpression();
            Console.ReadLine();
        }

    }
        
    
}
