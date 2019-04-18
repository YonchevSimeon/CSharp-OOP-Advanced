namespace DependencyInversion.Models.Contracts
{
    public interface ICalculator
    {
        IStrategy Strategy { get; }

        void ChangeStrategy(IStrategy strategy);

        int PerformCalculation(int firstOperand, int secondOperand);
    }
}
