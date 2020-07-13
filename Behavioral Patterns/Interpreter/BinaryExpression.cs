namespace Interpreter
{
    public abstract class BinaryExpression: AbstractExpression
    {
        protected AbstractExpression leftExpression;
        protected AbstractExpression rightExpression;

        public BinaryExpression(AbstractExpression leftExpression, AbstractExpression rightExpression)
        {
            this.leftExpression = leftExpression;
            this.rightExpression = rightExpression;
        }

        public abstract double Interpret();
    }
}
