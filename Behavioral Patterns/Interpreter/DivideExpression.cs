namespace Interpreter
{

    public class DivideExpression : BinaryExpression
    {
        public DivideExpression(AbstractExpression left, AbstractExpression right) : base(left, right)
        {
        }

        public override double Interpret()
        {
            return leftExpression.Interpret() / rightExpression.Interpret();
        }
    }
}
