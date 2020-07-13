namespace Interpreter
{
    public class MultExpression : BinaryExpression
    {        
        public MultExpression(AbstractExpression leftExpression, AbstractExpression rightExpression):base(leftExpression,rightExpression)
        {
        }

        public override double Interpret()
        {
            return leftExpression.Interpret() * rightExpression.Interpret();
        }
    }

}
