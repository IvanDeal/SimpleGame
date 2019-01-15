using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGame
{
    class Weapon
    {
        public string sWeaponName;
        public string sWeaponDescription;
        public int iWeaponDamage;

        public Weapon(string name, string description, int damage)
        {
            sWeaponName = name;
            sWeaponDescription = description;
            iWeaponDamage = damage;

        }
    }
}
