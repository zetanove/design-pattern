namespace Interpreter
{

    public class DivideExpression : AbstractExpression
    {
        AbstractExpression leftExpression;
        AbstractExpression rightExpresion;
        public DivideExpression(AbstractExpression leftExpression, AbstractExpression rightExpresion)
        {
            this.leftExpression = leftExpression;
            this.rightExpresion = rightExpresion;
        }

        public double Interpret()
        {
            return leftExpression.Interpret() / rightExpresion.Interpret();
        }
    }
}
