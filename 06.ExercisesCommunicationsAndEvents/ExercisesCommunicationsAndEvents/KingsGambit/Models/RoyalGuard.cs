namespace KingsGambit.Models
{
    using System;

    public class RoyalGuard : Guard
    {
        public RoyalGuard(string name)
            : base(name, 3) { }

        public override void RespondToAttack()
        {
            Console.WriteLine($"Royal Guard {this.Name} is defending!");
        }
    }
}
