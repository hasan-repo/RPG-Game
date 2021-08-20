using System;
using System.Collections.Generic;
using System.Text;

namespace RPG_Game
{
    class Armor
    {
        public String ArmorName;
        public int Defense;

        public Armor(String name, int defense)
        {
            this.ArmorName = name;
            this.Defense = defense;
        }
    }
}
