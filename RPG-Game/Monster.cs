using System;
using System.Collections.Generic;
using System.Text;

namespace RPG_Game
{
    class Monster
    {
        public String MonsterName;
        public int Strength;
        public int Defense;
        public int OriginalHealth;
        public int CurrentHealth;

        public Monster(String name, int strength, int defense)
        {
            this.MonsterName = name;
            this.Strength = strength;
            this.Defense = defense;
            OriginalHealth = 100;
            CurrentHealth = OriginalHealth;
        }
    }
}
