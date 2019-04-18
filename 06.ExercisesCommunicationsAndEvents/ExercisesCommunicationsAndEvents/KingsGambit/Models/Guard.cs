namespace KingsGambit.Models
{
    using System;
    using Contracts;

    public abstract class Guard : IFigure
    {
        protected Guard(string name, int lives)
        {
            this.Name = name;
            this.Lives = lives;
        }

        public bool IsAlive { get; private set; } = true;

        public int Lives { get; private set; }

        public string Name { get; private set; }

        public abstract void RespondToAttack();

        public void DecreaseLives()
        {
            this.Lives--;
            if(this.Lives == 0)
            {
                this.IsAlive = false;
            }
        }
    }
}
