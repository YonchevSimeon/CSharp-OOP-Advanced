namespace DependencyInversion.Models.Strategies
{
    using Contracts;

    public abstract class Strategy : IStrategy
    {
        public abstract int Calculate(int firstOperand, int secondOperand);
    }
}
