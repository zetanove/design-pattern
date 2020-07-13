using System;
using System.Collections.Generic;

namespace Interpreter
{
    public class MathEval
    {
        private static bool IsOperator(string s)
        {
            return s == "+" || s == "-" || s == "*" || s == "/";
        }

        private static AbstractExpression GetOperatorExpression(String s, AbstractExpression left,
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

        public static double EvaluateExpression(string strExp)
        {
            Stack<AbstractExpression> stack = new Stack<AbstractExpression>();

            string[] tokenList = strExp.Split(' ');
            foreach (string s in tokenList)
            {
                if (IsOperator(s))
                {
                    AbstractExpression rightExpression = stack.Pop();
                    Console.WriteLine("Pop: " + rightExpression.Interpret());
                    AbstractExpression leftExpression = stack.Pop();
                    Console.WriteLine("Pop: " + leftExpression.Interpret());

                    AbstractExpression op = GetOperatorExpression(s, leftExpression, rightExpression);
                    Console.WriteLine("Applica operatore: " + s);
                    double result = op.Interpret();
                   
                    stack.Push(new NumberExpression(result));
                    Console.WriteLine("Push result: " + result);
                }
                else
                {
                    AbstractExpression i = new NumberExpression(s);
                    Console.WriteLine("Push: " + s);
                    stack.Push(i);
                }
            }

            AbstractExpression exp = stack.Pop();
            return exp.Interpret();
        }
    }

}
