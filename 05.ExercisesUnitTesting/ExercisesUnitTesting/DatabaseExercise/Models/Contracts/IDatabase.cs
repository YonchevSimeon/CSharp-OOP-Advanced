namespace DatabaseExercise.Models.Contracts
{
    public interface IDatabase
    {
        int[] Array { get; }
        int ArraySize { get; }
        void Add(int element);
        void Remove();
        int[] Fetch();
    }
}
