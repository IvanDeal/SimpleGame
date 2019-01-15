using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGame
{
    class Armour
    {
        public string sArmourName;
        public string sArmourDescription;
        public int iArmourDefenceValue;
        public bool bHeadArmour;
        public bool bUpperBodyArmour;
        public bool bLowerBodyArmour;
        public bool bLegArmour;
        public bool bArmArmour;

        public Armour (string name, string description, int defence, bool headItem, bool upperBodyItem, bool lowerBodyItem, bool legItem, bool armItem)
        {
            sArmourName = name;
            sArmourDescription = description;
            iArmourDefenceValue = defence;
            bHeadArmour = headItem;
            bUpperBodyArmour = upperBodyItem;
            bLowerBodyArmour = lowerBodyItem;
            bLegArmour = legItem;
            bArmArmour = armItem;
        }
    }
}
