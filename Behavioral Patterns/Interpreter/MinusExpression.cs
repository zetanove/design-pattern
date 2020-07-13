namespace Interpreter
{
    public class MinusExpression : BinaryExpression
    {
        public MinusExpression(AbstractExpression left, AbstractExpression right) : base(left, right)
        {

        }
        public override double Interpret()
        {
            return leftExpression.Interpret() - rightExpression.Interpret();
        }
    }
}
