using System;
using System.Collections.Generic;
using System.Text;

namespace RPG_Game
{
    class Weapon
    {
        public String WeaponName;
        public int Damage;

        public Weapon(String name, int damage)
        {
            this.WeaponName = name;
            this.Damage = damage;
        }
    }
}
