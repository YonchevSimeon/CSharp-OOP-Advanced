namespace FestivalManager.Core.Commands
{
    using Core.Controllers.Contracts;

    public class SignUpPerformerCommand : Command
    {
        private IFestivalController festivalController;

        public SignUpPerformerCommand (IFestivalController festivalController)
        {
            this.festivalController = festivalController;
        }

        public override string Execute(params string[] args)
        {
            string result = this.festivalController.SignUpPerformer(args);

            return result;
        }
    }
}
