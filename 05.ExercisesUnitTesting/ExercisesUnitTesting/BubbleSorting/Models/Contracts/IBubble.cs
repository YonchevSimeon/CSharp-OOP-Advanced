namespace BubbleSorting.Models.Contracts
{
    public interface IBubble
    {
        int[] Arr { get; }

        void Sort();
    }
}
