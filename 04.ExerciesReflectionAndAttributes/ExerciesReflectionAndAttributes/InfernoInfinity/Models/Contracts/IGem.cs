namespace InfernoInfinity.Models.Contracts
{
    using InfernoInfinity.Models.Enums;

    public interface IGem
    {
        int StrengthValue { get; }
        int AgilityValue { get; }
        int VitalityValue { get; }
        Clarity Clarity { get; }
        void AddClarityToStats();
        int[] DamageBoost();
    }
}
