namespace WorkForce.Models.Contracts
{
    public interface IEmployee : INameable
    {
        int WorkHoursPerWeek { get; }
    }
}
