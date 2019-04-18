namespace InfernoInfinity.Models.Weapons
{
    using InfernoInfinity.Models.Gems;

    public class Sword : Weapon
    {
        private const int DEFAULT_MIN_DAMAGE = 4;
        private const int DEFAULT_MAX_DAMAGE = 6;
        private const int DEFAULT_SOCKETS_COUNT = 3;

        public Sword(string weaponType, string quality, string name)
            : base(weaponType, quality, name)
        {
            this.MinDamage = DEFAULT_MIN_DAMAGE;
            this.MaxDamage = DEFAULT_MAX_DAMAGE;
            this.Sockets = new Gem[DEFAULT_SOCKETS_COUNT];
            this.UseQualityBonuses();
        }
    }
}
