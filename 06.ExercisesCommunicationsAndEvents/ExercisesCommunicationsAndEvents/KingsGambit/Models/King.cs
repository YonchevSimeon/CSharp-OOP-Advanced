namespace KingsGambit.Models
{
    using System;
    using Contracts;

    public delegate void GetAttackedEventHandler();

    public class King : IFigure
    {
        public event GetAttackedEventHandler GetAttackedEvent;

        public King(string name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }

        public void GetAttacked()
        {
            Console.WriteLine($"{this.GetType().Name} {this.Name} is under attack!");

            this.GetAttackedEvent?.Invoke();
        }
    }
}
