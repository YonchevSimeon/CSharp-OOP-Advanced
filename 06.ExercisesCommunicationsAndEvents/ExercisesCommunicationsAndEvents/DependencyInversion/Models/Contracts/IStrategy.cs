namespace DependencyInversion.Models.Contracts
{
    public interface IStrategy
    {
        int Calculate(int firstOperand, int secondOperand);
    }
}
