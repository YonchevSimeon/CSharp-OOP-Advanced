namespace InfernoInfinity.Models.Gems
{
    public class Amethyst : Gem
    {
        private const int DEFAULT_STRENGTH = 2;
        private const int DEFAULT_AGILITY = 8;
        private const int DEFAULT_VITALITY = 4;

        public Amethyst(string clarity)
            : base(clarity)
        {
            this.StrengthValue = DEFAULT_STRENGTH;
            this.AgilityValue = DEFAULT_AGILITY;
            this.VitalityValue = DEFAULT_VITALITY;
            this.AddClarityToStats();
        }
    }
}
