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
            sUpperBodyItemName = "empty";
            bUpperBodyItemEquipped = false;
            iUpperBodyItemArmour = 0;
            sLowerBodyItemName = "empty";
            bLowerBodyItemEquipped = false;
            iLowerBodyItemArmour = 0;
            sArmItemName = "empty";
            bArmItemEquipped = false;
            iArmItemArmour = 0;
            sLegItemName = "empty";
            bLegItemEquipped = false;
            iLegItemArmour = 0;
            sHeadItemName = "empty";
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

        public void checkStatus()
        {

            if (bLeftHandItemEquipped == false)
            {
                Console.WriteLine("You have nothing equipped in your left hand");
            }
            else if (iLeftHandItemDamage != 0)
            {
                Console.WriteLine("You have " + sLeftHandItemName + " equipped.");
                Console.WriteLine("It cannot be used in combat");
            }
            else
            {
                Console.WriteLine("You have " + sLeftHandItemName + " equipped.");
                Console.WriteLine("It does " + iLeftHandItemDamage + " damage when attacking.");
                Console.WriteLine("It provides " + iLeftHandItemArmour + " when blocking.");
            }

            if (bRightHandItemEquipped == false)
            {
                Console.WriteLine("You have nothing equipped in your right hand");
            }
            else if (iRightHandItemDamage != 0)
            {
                Console.WriteLine("You have " + sRightHandItemName + " equipped.");
                Console.WriteLine("It cannot be used in combat");
            }
            else
            {
                Console.WriteLine("You have " + sRightHandItemName + " equipped.");
                Console.WriteLine("It does " + iRightHandItemDamage + " damage when attacking.");
                Console.WriteLine("It provides " + iRightHandItemArmour + " when blocking.");
            }

            if (bUpperBodyItemEquipped == false)
            {
                Console.WriteLine("You have nothing equipped on your upper body.");
            }
            else
            {
                Console.WriteLine("You are currently wearing " + sUpperBodyItemName + ".");
                Console.WriteLine("It provides " + iUpperBodyItemArmour + " armour.");
            }


            if (bLowerBodyItemEquipped == false)
            {
                Console.WriteLine("You have nothing equipped on your lower body.");
            }
            else
            {
                Console.WriteLine("You are currently wearing " + sLowerBodyItemName + ".");
                Console.WriteLine("It provides " + iLowerBodyItemArmour + " armour.");
            }

            if (bArmItemEquipped == false)
            {
                Console.WriteLine("You are not wearing anything on your arms");
            }
            else
            {
                Console.WriteLine("You are currently wearing " + sArmItemName + ".");
                Console.WriteLine("It provides " + iArmItemArmour + " armour.");
            }

            if (bLegItemEquipped == false)
            {
                Console.WriteLine("You are not wearing anything on your legs");
            }
            else
            {
                Console.WriteLine("You are currently wearing " + sLegItemName + ".");
                Console.WriteLine("It provides " + iLegItemArmour + " armour.");
            }

            if (bHeadItemEquipped == false)
            {
                Console.WriteLine("You are not wearing anything on your head");
            }
            else
            {
                Console.WriteLine("You are currently wearing " + sHeadItemName + ".");
                Console.WriteLine("It provides " + iHeadItemArmour + " armour.");
            }

        }

    }
}
