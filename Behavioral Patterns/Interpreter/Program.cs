using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter
{
    class Program
    {
		public static bool IsOperator(string s)
		{
            return s == "+" || s == "-" || s == "*" || s == "/";
		}

		public static AbstractExpression GetOperatorExpression(String s, AbstractExpression left,
				AbstractExpression right)
		{
			switch (s)
			{
				case "+":
					return new PlusExpression(left, right);
				case "-":
					return new MinusExpression(left, right);
				case "*":
					return new MultExpression(left, right);
				case "/":
					return new DivideExpression(left, right);
			}
			return null;
		}


		static void Main(string[] args)
        {
            string espr = "3 8 4 / 2 - 1 + *";
            //Stack<AbstractExpression> stack = ParseExpression(tokenString);
            double val = EvaluateExpression(espr);
            Console.WriteLine($"Risultato di {espr}" + val);

            espr = "5 2 /"; // = 5 / 2
            val = EvaluateExpression(espr);
            Console.WriteLine($"Risultato di {espr}" + val);

        }

        private static double EvaluateExpression(string tokenString)
        {
            Stack<AbstractExpression> stack = new Stack<AbstractExpression>();

            string[] tokenList = tokenString.Split(' ');
            foreach (string s in tokenList)
            {
                if (IsOperator(s))
                {
                    AbstractExpression rightExpression = stack.Pop();
                    AbstractExpression leftExpression = stack.Pop();
                    AbstractExpression op = GetOperatorExpression(s, leftExpression, rightExpression);
                    double result = op.Interpret();
                    stack.Push(new NumberExpression(result));
                }
                else
                {
                    AbstractExpression i = new NumberExpression(s);
                    stack.Push(i);
                }
            }

            AbstractExpression exp = stack.Pop();
            return exp.Interpret();
        }

    }

    public interface AbstractExpression
    {
        double Interpret();
    }

}
