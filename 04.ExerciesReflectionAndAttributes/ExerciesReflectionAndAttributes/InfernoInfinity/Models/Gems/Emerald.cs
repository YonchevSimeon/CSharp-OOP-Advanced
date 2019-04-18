namespace InfernoInfinity.Models.Gems
{
    public class Emerald : Gem
    {
        private const int DEFAULT_STRENGTH = 1;
        private const int DEFAULT_AGILITY = 4;
        private const int DEFAULT_VITALITY = 9;

        public Emerald(string clarity)
            : base(clarity)
        {
            this.StrengthValue = DEFAULT_STRENGTH;
            this.AgilityValue = DEFAULT_AGILITY;
            this.VitalityValue = DEFAULT_VITALITY;
            this.AddClarityToStats();
        }
    }
}
