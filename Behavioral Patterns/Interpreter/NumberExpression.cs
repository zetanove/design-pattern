using System;

namespace Interpreter
{
    public class NumberExpression : AbstractExpression
    {
        double number;

        public NumberExpression(double i)
        {
            number = i;
        }

        public NumberExpression(String s)
        {
            number = int.Parse(s);
        }

        public double Interpret()
        {
            return number;
        }
    }


}
