namespace DependencyInversion.Models.Strategies
{
	public class AdditionStrategy : Strategy
    {
        public override int Calculate(int firstOperand, int secondOperand)
        {
            return firstOperand + secondOperand;
        }
    }
}
