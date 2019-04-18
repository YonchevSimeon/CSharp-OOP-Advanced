namespace FestivalManager.Core.Commands
{
    using Controllers.Contracts;

    public class LetsRockCommand : Command
    {
        private ISetController setController;

        public LetsRockCommand(ISetController setController)
        {
            this.setController = setController;
        }

        public override string Execute(params string[] args)
        {
            string result = this.setController.PerformSets();

            return result;
        }
    }
}
