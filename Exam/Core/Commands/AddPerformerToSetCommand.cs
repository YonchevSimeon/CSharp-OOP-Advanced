namespace FestivalManager.Core.Commands
{
    using Core.Controllers.Contracts;

    public class AddPerformerToSetCommand : Command
    {
        private IFestivalController festivalController;

        public AddPerformerToSetCommand(IFestivalController festivalController)
        {
            this.festivalController = festivalController;
        }

        public override string Execute(params string[] args)
        {
            string result = this.festivalController.AddPerformerToSet(args);

            return result;
        }
    }
}
