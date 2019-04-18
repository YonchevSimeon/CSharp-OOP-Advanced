namespace DependencyInversion.Models.Strategies
{
    public class DividingStrategy : Strategy
    {
        public override int Calculate(int firstOperand, int secondOperand)
        {
            return firstOperand / secondOperand;
        }
    }
}
