namespace WorkForce.Models.Contracts
{
    public interface IJob : INameable
    {
        int WorkHoursRequired { get; }
        bool IsJobDone { get; }
        IEmployee Employee { get; }
        void Update();
        void Status();
    }
}
