namespace Interpreter
{
    public class MultExpression : AbstractExpression
    {
        AbstractExpression leftExpression;
        AbstractExpression rightExpresion;
        public MultExpression(AbstractExpression leftExpression, AbstractExpression rightExpresion)
        {
            this.leftExpression = leftExpression;
            this.rightExpresion = rightExpresion;
        }

        public double Interpret()
        {
            return leftExpression.Interpret() * rightExpresion.Interpret();
        }
    }

}
