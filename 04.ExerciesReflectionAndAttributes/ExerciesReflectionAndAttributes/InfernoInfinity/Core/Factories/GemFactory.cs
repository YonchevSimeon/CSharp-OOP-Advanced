namespace InfernoInfinity.Core.Factories
{
    using InfernoInfinity.Models.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class GemFactory
    {
        public IGem CreateGem(string gemType, string clarity)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            Type model = assembly.GetTypes().FirstOrDefault(m => m.Name == gemType);

            if(model == null)
            {
                throw new ArgumentException("Invalid Gem Type!");
            }

            if (!typeof(IGem).IsAssignableFrom(model))
            {
                throw new ArgumentException($"{gemType} is Not a IGem Type!");
            }

            IGem gem = (IGem)Activator.CreateInstance(model, new object[] { clarity });

            return gem;
        }
    }
}
