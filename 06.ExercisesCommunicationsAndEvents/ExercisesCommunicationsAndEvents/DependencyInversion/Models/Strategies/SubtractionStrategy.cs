namespace DependencyInversion.Models.Strategies
{
	public class SubtractionStrategy : Strategy
    {
        public override int Calculate(int firstOperand, int secondOperand)
        {
            return firstOperand - secondOperand;
        }
    }
}
