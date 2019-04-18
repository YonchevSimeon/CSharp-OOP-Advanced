namespace FestivalManager.Core.Commands
{
    using Core.Controllers.Contracts;

    public class RegisterSongCommand : Command
    {
        private IFestivalController festivalController;

        public RegisterSongCommand(IFestivalController festivalController)
        {
            this.festivalController = festivalController;
        }

        public override string Execute(params string[] args)
        {
            string result = this.festivalController.RegisterSong(args);

            return result;
        }
    }
}
