namespace FestivalManager.Core.Commands.Contracts
{
    public interface ICommand
    {
        string Execute(params string[] args);
    }
}
