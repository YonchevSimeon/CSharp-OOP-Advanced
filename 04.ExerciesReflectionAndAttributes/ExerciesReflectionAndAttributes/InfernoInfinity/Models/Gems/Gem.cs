namespace InfernoInfinity.Models.Gems
{
    using InfernoInfinity.Models.Contracts;
    using InfernoInfinity.Models.Enums;
    using System;

    public abstract class Gem : IGem
    {
        protected Gem(string clarity)
        {
            this.Clarity = (Clarity)Enum.Parse(typeof(Clarity), clarity);
        }

        public void AddClarityToStats()
        {
            int clarityMultiplier = (int)this.Clarity;

            this.StrengthValue += clarityMultiplier;
            this.AgilityValue += clarityMultiplier;
            this.VitalityValue += clarityMultiplier;
        }

        public int StrengthValue { get; protected set; } = 1;

        public int AgilityValue { get; protected set; } = 1;

        public int VitalityValue { get; protected set; } = 1;

        public Clarity Clarity { get; private set; }

        public int[] DamageBoost()
        {
            int minDamage = this.StrengthValue * 2;
            int maxDamage = this.StrengthValue * 3;
            minDamage += this.AgilityValue;
            maxDamage += this.AgilityValue * 4;

            return new int[] { minDamage, maxDamage };
        }
    }
}
