namespace InfernoInfinity.Core.Factories
{
    using InfernoInfinity.Models.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class WeaponFactory
    {
        public IWeapon CreateWeapon(string weaponType, string quality, string name)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            Type model = assembly.GetTypes().FirstOrDefault(m => m.Name == weaponType);

            if(model == null)
            {
                throw new ArgumentException("Invalid Weapon Type!");
            }

            if (!typeof(IWeapon).IsAssignableFrom(model))
            {
                throw new ArgumentException($"{weaponType} is Not a IWeapon Type!");
            }

            IWeapon weapon = (IWeapon)Activator.CreateInstance(model, new object[] { weaponType, quality, name });

            return weapon;
        }
    }
}
