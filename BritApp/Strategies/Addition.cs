namespace BritApp.Strategies
{
    public class Addition : IStrategy
    {
        public float Calculate(float leftOperand, float rightOperand)
        {
            return leftOperand + rightOperand;
        }
    }

}
