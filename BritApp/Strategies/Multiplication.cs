namespace BritApp.Strategies
{
    public class Multiplication : IStrategy
    {
        public float Calculate(float leftOperand, float rightOperand)
        {
            return leftOperand * rightOperand;
        }
    }

}
