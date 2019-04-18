namespace WorkForce.Models.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Contracts;

    public class EmployeeFactory
    {
        public IEmployee CreateEmployee(string[] args)
        {
            string type = args[0];
            string name = args[1];

            Assembly assembly = Assembly.GetExecutingAssembly();

            Type model = assembly.GetTypes().FirstOrDefault(m => m.Name == type);

            if(model == null)
            {
                throw new ArgumentException("Invalid Employee Type!");
            }

            if (!typeof(IEmployee).IsAssignableFrom(model))
            {
                throw new ArgumentException($"{type} is Not a IEmployee Type!");
            }

            IEmployee employee = (IEmployee)Activator.CreateInstance(model, new object[] { name });

            return employee;
        }
    }
}
