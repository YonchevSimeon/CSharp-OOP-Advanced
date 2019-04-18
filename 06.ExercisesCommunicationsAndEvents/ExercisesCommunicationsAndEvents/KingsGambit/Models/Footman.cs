namespace KingsGambit.Models
{
    using System;

    public class Footman : Guard
    {
        public Footman(string name)
            : base(name, 2) { }

        public override void RespondToAttack()
        {
            Console.WriteLine($"{this.GetType().Name} {this.Name} is panicking!");
        }
    }
}
