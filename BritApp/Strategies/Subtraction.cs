namespace BritApp.Strategies
{
    public class Subtraction : IStrategy
    {
        public float Calculate(float leftOperand, float rightOperand)
        {
            return leftOperand - rightOperand;
        }
    }

}
