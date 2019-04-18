namespace InfernoInfinity.Models.Weapons
{
    using InfernoInfinity.Models.Gems;

    public class Axe : Weapon
    {
        private const int DEFAULT_MIN_DAMAGE = 5;
        private const int DEFAULT_MAX_DAMAGE = 10;
        private const int DEFAULT_SOCKETS_COUNT = 4;

        public Axe(string weaponType, string quality, string name) 
            : base(weaponType, quality, name)
        {
            this.MinDamage = DEFAULT_MIN_DAMAGE;
            this.MaxDamage = DEFAULT_MAX_DAMAGE;
            this.Sockets = new Gem[DEFAULT_SOCKETS_COUNT];
            this.UseQualityBonuses();
        }
    }
}
