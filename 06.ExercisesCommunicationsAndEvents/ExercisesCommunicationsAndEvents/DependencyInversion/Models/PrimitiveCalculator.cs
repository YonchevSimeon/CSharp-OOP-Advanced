namespace DependencyInversion.Models
{
    using Strategies;
    using Contracts;

    public class PrimitiveCalculator : ICalculator
    {
        public PrimitiveCalculator()
        {
            this.Strategy = new AdditionStrategy();
        }

        public IStrategy Strategy { get; private set; }

        public void ChangeStrategy(IStrategy strategy)
        {
            this.Strategy = strategy;
        }

        public int PerformCalculation(int firstOperand, int secondOperand)
        {
            return this.Strategy.Calculate(firstOperand, secondOperand);
        }
    }
}
