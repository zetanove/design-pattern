namespace Interpreter
{
    public abstract class BinaryExpression: AbstractExpression
    {
        protected AbstractExpression leftExpression;
        protected AbstractExpression rightExpresion;

        public BinaryExpression(AbstractExpression leftExpression, AbstractExpression rightExpresion)
        {
            this.leftExpression = leftExpression;
            this.rightExpresion = rightExpresion;
        }

        public abstract double Interpret();
    }
    public class PlusExpression : BinaryExpression
    {
        public PlusExpression(AbstractExpression left, AbstractExpression right): base (left, right)
        {

        }
        public override double Interpret()
        {
            return leftExpression.Interpret() + rightExpresion.Interpret();
        }
    }

    public class MinusExpression : BinaryExpression
    {
        public MinusExpression(AbstractExpression left, AbstractExpression right) : base(left, right)
        {

        }
        public override double Interpret()
        {
            return leftExpression.Interpret() - rightExpresion.Interpret();
        }
    }
}
