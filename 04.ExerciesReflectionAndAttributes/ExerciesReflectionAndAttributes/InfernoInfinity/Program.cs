namespace InfernoInfinity
{
    using InfernoInfinity.Core;
    using InfernoInfinity.Core.Factories;
    using InfernoInfinity.Models.Contracts;

    public class Program
    {
        static void Main(string[] args)
        {
            IRunnable engine = new Engine();
            engine.Run();
        }
    }
}
