namespace InfernoInfinity.Models.Weapons
{
    using InfernoInfinity.Models.Gems;

    public class Knife : Weapon
    {
        private const int DEFAULT_MIN_DAMAGE = 3;
        private const int DEFAULT_MAX_DAMAGE = 4;
        private const int DEFAULT_SOCKETS_COUNT = 2;

        public Knife(string weaponType, string quality, string name)
            : base(weaponType, quality, name)
        {
            this.MinDamage = DEFAULT_MIN_DAMAGE;
            this.MaxDamage = DEFAULT_MAX_DAMAGE;
            this.Sockets = new Gem[DEFAULT_SOCKETS_COUNT];
            this.UseQualityBonuses();
        }
    }
}
