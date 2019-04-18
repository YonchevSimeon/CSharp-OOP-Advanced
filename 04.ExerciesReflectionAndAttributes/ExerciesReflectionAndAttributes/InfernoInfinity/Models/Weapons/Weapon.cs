namespace InfernoInfinity.Models.Weapons
{
    using InfernoInfinity.Models.Contracts;
    using InfernoInfinity.Models.Enums;
    using System;
    using System.Linq;

    public abstract class Weapon : IWeapon
    {
        protected Weapon(string weaponType, string quality, string name)
        {
            this.WeaponType = (WeaponType)Enum.Parse(typeof(WeaponType), weaponType);
            this.Quality = (Quality)Enum.Parse(typeof(Quality), quality);
            this.Name = name;
        }

        public string Name { get; protected set; }

        public int MinDamage { get; protected set; } 

        public int MaxDamage { get; protected set; }

        public int Strength { get; protected set; }

        public int Agility { get; protected set; }

        public int Vitality { get; protected set; }

        public IGem[] Sockets { get; protected set; }

        public Quality Quality { get; protected set; }

        public WeaponType WeaponType { get; protected set; }

        public void AddGem(int index, IGem gem)
        {
            if(this.Sockets.Length > 0 && index < this.Sockets.Length)
            {
                this.Sockets[index] = gem;
            }
        }

        public void RemoveGem(int index)
        {
            if(this.Sockets.Length > 0 && index < this.Sockets.Length)
            {
                this.Sockets[index] = null;
            }
        }

        public void UseQualityBonuses()
        {
            int qualityBonus = (int)this.Quality;

            this.MinDamage *= qualityBonus;
            this.MaxDamage *= qualityBonus;
        }

        public override string ToString()
        {
            int minDamage = this.MinDamage;
            int maxDamage = this.MaxDamage;
            int strBonus = 0;
            int agiBonus = 0;
            int vitBonus = 0;

            foreach (IGem gem in this.Sockets.Where(s => s != null))
            {
                int[] gemBonuses = gem.DamageBoost();

                minDamage += gemBonuses[0];
                maxDamage += gemBonuses[1];

                strBonus += gem.StrengthValue;
                agiBonus += gem.AgilityValue;
                vitBonus += gem.VitalityValue;
            }

            return $"{this.Name}: {minDamage}-{maxDamage} Damage, +{strBonus} Strength, +{agiBonus} Agility, +{vitBonus} Vitality";
        }
    }
}
