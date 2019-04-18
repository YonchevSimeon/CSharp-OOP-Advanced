namespace FestivalManager.Core.Commands.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;

    using Contracts;
    using FestivalManager.Core.Commands.Contracts;

    public class CommandFactory : ICommandFactory
    {
        private IServiceProvider serviceProvider;

        public CommandFactory(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public ICommand CreateCommand(string commandName)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            Type commandType = assembly.GetTypes().FirstOrDefault(t => t.Name == commandName + "Command");

            if(commandType == null)
            {
                throw new InvalidOperationException($"{commandName}Command not found!");
            }

            if (!typeof(ICommand).IsAssignableFrom(commandType))
            {
                throw new InvalidOperationException($"{commandType}Command is not an ICommand!");
            }

            ParameterInfo[] ctorParams = commandType.GetConstructors().First().GetParameters();

            object[] args = new object[ctorParams.Length];

            for (int index = 0; index < args.Length; index++)
            {
                args[index] = this.serviceProvider.GetService(ctorParams[index].ParameterType);
            }

            ICommand command = (ICommand)Activator.CreateInstance(commandType, args);

            return command;
        }
    }
}
