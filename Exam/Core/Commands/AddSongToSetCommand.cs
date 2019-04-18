namespace FestivalManager.Core.Commands
{
    using Core.Controllers.Contracts;

    public class AddSongToSetCommand : Command
    {
        private IFestivalController festivalController;

        public AddSongToSetCommand(IFestivalController festivalController)
        {
            this.festivalController = festivalController;
        }

        public override string Execute(params string[] args)
        {
            string result = this.festivalController.AddSongToSet(args);

            return result;
        }
    }
}
