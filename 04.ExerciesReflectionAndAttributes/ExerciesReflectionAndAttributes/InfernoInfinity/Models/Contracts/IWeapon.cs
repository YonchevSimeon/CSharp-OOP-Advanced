namespace InfernoInfinity.Models.Contracts
{
    using InfernoInfinity.Models.Enums;

    public interface IWeapon
    {
        string Name { get; }
        int MinDamage { get; }
        int MaxDamage { get; }
        int Strength { get; }
        int Agility { get; }
        int Vitality { get; }
        IGem[] Sockets { get; }
        Quality Quality { get; }
        WeaponType WeaponType { get; }
        void AddGem(int index, IGem gem);
        void RemoveGem(int index);
    }
}
