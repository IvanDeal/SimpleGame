using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGame
{
    class Monster
    {
        public string monsterName;
        public int monsterHealthPoints;
        public int monsterMagicPoints;
        public string attackOneName;
        public string attackTwoName;
        public string attackThreeName;
        public string attackFourName;

        public Monster(string name, int health, int magic, string attackOne, string attackTwo, string attackThree, string attackFour)
        {
            monsterName = name;
            monsterHealthPoints = health;
            monsterMagicPoints = magic;
            attackOneName = attackOne;
            attackTwoName = attackTwo;
            attackThreeName = attackThree;
            attackFourName = attackFour;

        }

    }
}
