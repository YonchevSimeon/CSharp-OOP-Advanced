namespace InfernoInfinity.Models.Gems
{
    public class Ruby : Gem
    {
        private const int DEFAULT_STRENGTH = 7;
        private const int DEFAULT_AGILITY = 2;
        private const int DEFAULT_VITALITY = 5;

        public Ruby(string clarity)
            : base(clarity)
        {
            this.StrengthValue = DEFAULT_STRENGTH;
            this.AgilityValue = DEFAULT_AGILITY;
            this.VitalityValue = DEFAULT_VITALITY;
            this.AddClarityToStats();
        }
    }
}
