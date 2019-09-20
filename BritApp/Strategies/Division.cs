namespace BritApp.Strategies
{

    public class Division : IStrategy
    {
        public float Calculate(float leftOperand, float rightOperand)
        {
            return leftOperand / rightOperand;
        }
    }
}
