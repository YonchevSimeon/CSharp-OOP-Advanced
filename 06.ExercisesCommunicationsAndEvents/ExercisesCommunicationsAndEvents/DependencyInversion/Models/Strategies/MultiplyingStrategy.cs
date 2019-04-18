namespace DependencyInversion.Models.Strategies
{
    public class MultiplyingStrategy : Strategy
    {
        public override int Calculate(int firstOperand, int secondOperand)
        {
            return firstOperand * secondOperand;
        }
    }
}
