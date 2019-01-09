using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGame
{
    class Player
    {
        public int iPlayerLevel;
        public int iPlayerHealth;
        public int iPlayerMagic;
        public int iPlayerWeaponDamage;
        public int iPlayerArmourValue;

        public string sLeftHandItemName;
        public bool bLeftHandItemEquipped;
        public int iLeftHandItemDamage;
        public int iLeftHandItemArmour;

        public string sRightHandItemName;
        public bool bRightHandItemEquipped;
        public int iRightHandItemDamage;
        public int iRightHandItemArmour;

        //Apparel variables

        public string sUpperBodyItemName;
        public bool bUpperBodyItemEquipped;
        public int iUpperBodyItemArmour;

        public string sLowerBodyItemName;
        public bool bLowerBodyItemEquipped;
        public int iLowerBodyItemArmour;

        public string sArmItemName;
        public bool bArmItemEquipped;
        public int iArmItemArmour;

        public string sLegItemName;
        public bool bLegItemEquipped;
        public int iLegItemArmour;

        public string sHeadItemName;
        public bool bHeadItemEquipped;
        public int iHeadItemArmour;

        public Player()
        {
            LoadPlayer();
        }

        public void LoadPlayer()
        {
            iPlayerLevel = 1;
            iPlayerHealth = 5;
            iPlayerMagic = 5;
            iPlayerWeaponDamage = 1;
            iPlayerArmourValue = 0;
            sLeftHandItemName = "empty";
            bLeftHandItemEquipped = false;
            iLeftHandItemDamage = 0;
            iLeftHandItemArmour = 0;
            sRightHandItemName = "empty";
            bRightHandItemEquipped = false; 
            iRightHandItemDamage = 0;
            iRightHandItemArmour = 0;
            sUpperBodyItemName = "";
            bUpperBodyItemEquipped = false;
            iUpperBodyItemArmour = 0;
            sLowerBodyItemName = "";
            bLowerBodyItemEquipped = false;
            iLowerBodyItemArmour = 0;
            sArmItemName = "";
            bArmItemEquipped = false;
            iArmItemArmour = 0;
            sLegItemName = "";
            bLegItemEquipped = false;
            iLegItemArmour = 0;
            sHeadItemName = "";
            bHeadItemEquipped = false;
            iHeadItemArmour = 0;
        }

        public void calculatePlayerAttackValue()
        {
            iPlayerWeaponDamage = 1 + iLeftHandItemDamage + iRightHandItemDamage;

        }

        public void calculatePlayerArmourValue()
        {
            iPlayerArmourValue = 0 + iUpperBodyItemArmour + iLowerBodyItemArmour + iArmItemArmour + iLegItemArmour + iHeadItemArmour;

        }

        public void playerAttack()
        {

            
        }

        public void playerExploringControls()
        {

        }

        public void playerCombatControls()
        {

        }

    }
}
