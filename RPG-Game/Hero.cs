using System;
using System.Collections.Generic;
using System.Text;

namespace RPG_Game
{
    class Hero
    {
        public String HeroName;
        public int BaseStrength;
        public int BaseDefense;
        public int TotalStrength;
        public int TotalDefense;
        public int OriginalHealth;
        public int CurrentHealth;
        public int GamesPlayed;
        public int GamesWon;
        public Weapon EquippedWeapon;
        public Armor EquippedArmor;
        public Armor[] ArmorBag;
        public int ArmorBagSize;
        public Weapon[] WeaponsBag;
        public int WeaponBagSize;

        public Hero(String name)
        {
            this.HeroName = name;
            BaseStrength = 50;
            BaseDefense = 50;
            TotalStrength = BaseStrength;
            TotalDefense = BaseDefense;
            OriginalHealth = 100;
            CurrentHealth = OriginalHealth;
            GamesPlayed = 0;
            GamesWon = 0;
            ArmorBag = new Armor[10];
            ArmorBagSize = 0;
            WeaponsBag = new Weapon[10];
            WeaponBagSize = 0;
            EquippedWeapon = null;
            EquippedArmor = null;
        }

        public void ResetHero()
        {
            BaseStrength = 50;
            BaseDefense = 50;
            TotalStrength = BaseStrength;
            TotalDefense = BaseDefense;
            OriginalHealth = 100;
            CurrentHealth = OriginalHealth;
           
          
            EquippedWeapon = null;
            EquippedArmor = null;
        }

        public void ShowStats()
        {
            String stat = "STAT OF THE HERO:\n GAMES PLAYED: " + GamesPlayed + "\n GAMES WON: " + GamesWon + "\n";

            Console.WriteLine(stat);
        }

        public void ShowInventory()
        {
            String inventory = "INVENTORY:\n WEAPON AVAILABLE:\n";

            for (int i = 0; i < WeaponBagSize; i++)
            {
                inventory += "" + WeaponsBag[i].WeaponName + "\n";
            }

            inventory += "ARMOR AVAILABLE:\n";

            for (int i = 0; i < ArmorBagSize; i++)
            {
                inventory += "" + ArmorBag[i].ArmorName + "\n";
            }

            Console.WriteLine(inventory);
        }

        public void EquipWeapon(Weapon newWeapon)
        {
            this.EquippedWeapon = newWeapon;
            TotalStrength += EquippedWeapon.Damage;
            Console.WriteLine(EquippedWeapon.WeaponName
                    + " WAS SUCESSFULLY EQUIPPED BY THE HERO. HERO TOTAL STRENGTH NOW: " + TotalStrength);
        }

        public void EquipArmor(Armor newArmor)
        {
            this.EquippedArmor = newArmor;
            TotalDefense += EquippedArmor.Defense;
            Console.WriteLine(EquippedArmor.ArmorName + " WAS SUCESSFULLY EQUIPPED BY THE HERO. HERO TOTAL DEFENSE NOW: "
                    + TotalDefense);

        }
    }
}
