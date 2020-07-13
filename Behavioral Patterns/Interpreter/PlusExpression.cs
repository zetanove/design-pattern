namespace Interpreter
{
    public class PlusExpression : BinaryExpression
    {
        public PlusExpression(AbstractExpression left, AbstractExpression right): base (left, right)
        {

        }
        public override double Interpret()
        {
            return leftExpression.Interpret() + rightExpression.Interpret();
        }
    }
}
