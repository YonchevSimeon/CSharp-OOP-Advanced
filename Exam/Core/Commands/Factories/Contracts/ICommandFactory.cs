namespace FestivalManager.Core.Commands.Factories.Contracts
{
    using Commands.Contracts;

    public interface ICommandFactory
    {
        ICommand CreateCommand(string commandName);
    }
}
