namespace InfernoInfinity.Core
{
    using InfernoInfinity.Core.Factories;
    using InfernoInfinity.Models.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Engine : IRunnable
    {
        private IList<IWeapon> weapons;
        private GemFactory gemFactory;
        private WeaponFactory weaponFactory;

        public Engine()
        {
            this.gemFactory = new GemFactory();
            this.weaponFactory = new WeaponFactory();
            this.weapons = new List<IWeapon>();
        }

        public void Run()
        {
            string input;
            while((input = Console.ReadLine()) != "END")
            {
                string[] inputArgs = input.Split(';');

                string command = inputArgs[0];

                switch (command)
                {
                    case "Create":
                        string[] weaponArgs = inputArgs[1].Split();
                        string weaponType = weaponArgs[1];
                        string quality = weaponArgs[0];
                        string name = inputArgs[2];
                        IWeapon weapon = this.weaponFactory.CreateWeapon(weaponType, quality, name);
                        this.weapons.Add(weapon);
                        break;
                    case "Add":
                        string[] addGemArgs = inputArgs[3].Split();
                        string addGemClarity = addGemArgs[0];
                        string addGemType = addGemArgs[1];

                        IGem gem = this.gemFactory.CreateGem(addGemType, addGemClarity);

                        IWeapon addGemWeapon = this.weapons.First(w => w.Name == inputArgs[1]);

                        addGemWeapon.AddGem(int.Parse(inputArgs[2]), gem);
                        break;

                    case "Remove":
                        IWeapon removeGemWeapon = this.weapons.First(w => w.Name == inputArgs[1]);

                        removeGemWeapon.RemoveGem(int.Parse(inputArgs[2]));

                        break;

                    case "Print":

                        IWeapon printWeapon = this.weapons.First(w => w.Name == inputArgs[1]);


                        Console.WriteLine(printWeapon.ToString());
                        break;
                }
            }
        }
    }
}
