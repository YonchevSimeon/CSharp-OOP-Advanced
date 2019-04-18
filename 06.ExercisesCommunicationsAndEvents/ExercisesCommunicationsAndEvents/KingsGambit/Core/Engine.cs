namespace KingsGambit.Core
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Models;

    public class Engine
    {
        private King king;
        private ICollection<Guard> guards;

        public Engine()
        {
            this.king = new King(Console.ReadLine());
            this.guards = GetGuards();
        }

        public void Run()
        {
            string input;
            while((input = Console.ReadLine()) != "End")
            {
                string[] inputArgs = input.Split();
                string command = inputArgs[0];

                switch (command)
                {
                    case "Attack":
                        this.king.GetAttacked();
                        break;
                    case "Kill":
                        string guardName = inputArgs[1];
                        this.CheckGuardForRemoval(guardName);
                        break;
                }
            }
        }

        private void CheckGuardForRemoval(string guardName)
        {
            Guard guard = this.guards.First(g => g.Name == guardName);
            guard.DecreaseLives();
            if (!guard.IsAlive)
            {
                king.GetAttackedEvent -= guard.RespondToAttack;
                this.guards.Remove(guard);
            }
        }

        private ICollection<Guard> GetGuards()
        {
            List<Guard> guards = new List<Guard>();

            string[] royalGuardNames = Console.ReadLine().Split();

            foreach (string royalGuardName in royalGuardNames)
            {
                RoyalGuard royalGuard = new RoyalGuard(royalGuardName);

                guards.Add(royalGuard);

                this.king.GetAttackedEvent += royalGuard.RespondToAttack;
            }

            string[] footmanNames = Console.ReadLine().Split();

            foreach (string  footmanName in footmanNames)
            {
                Footman footman = new Footman(footmanName);

                guards.Add(footman);

                this.king.GetAttackedEvent += footman.RespondToAttack;
            }

            return guards;
        }
    }
}
