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

        /* Variables to use going forward The above variables apart from name and health will be replaced*/
        public string sMonsterType;
        public string sMonsterAlignment;
        public string sMonsterSize;

        public int iMonsterArmourClass;
        public int iMonsterGroundSpeed;
        public int iMonsterFlySpeed;
        public int iMonsterLevel; /*AKA Challenge Rating */
        public int iMonsterExperienceReward;
        public int iMonsterHitDie; /* will be 4,6,8, 10 or 12 depending on the monster */

        public int iMonsterStrength;
        public int iMonsterConstitution;
        public int iMonsterDexterity;
        public int iMonsterIntelligence;
        public int iMonsterWisdom;
        public int iMonsterCharisma;

        public int iMonsterStrengthSavingThrow;
        public int iMonsterConstitutionSavingThrow;
        public int iMonsterDexteritySavingThrow;
        public int IMonsterIntelligenceSavingThrow;
        public int iMonsterWisdomSavingThrow;
        public int iMonsterCharismaSavingThrow;

        public int iMonsterAcrobaticsBonus;
        public int iMonsterAnimalHandlingBonus;
        public int iMonsterArcanaBonus;
        public int iMonsterAthleticsBonus;
        public int iMonsterDeceptionBonus;
        public int iMonsterHistoryBonus;
        public int iMonsterInsightBonus;
        public int iMonsterIntimidationBonus;
        public int iMonsterInvestigationBonus;
        public int iMonsterMedicineBonus;
        public int iMonsterNatureBonus;
        public int iMonsterPerceptionBonus;
        public int iMonsterPerformanceBonus;
        public int iMonsterPersuasionBonus;
        public int iMonsterReligionBonus;
        public int iMonsterSleightOfHandBonus;
        public int iMonsterStealthBonus;
        public int imonsterSurvivalBonus;

        public bool bMonsterAcidResistance = false;
        public bool bMonsterBludgeoningResistance = false;
        public bool bMonsterColdResistance = false;
        public bool bMonsterFireResistance = false;
        public bool bMonsterForceResistance = false;
        public bool bMonsterLightningResistance = false;
        public bool bMonsterNecroticResistance = false;
        public bool bMonsterPiercingResistance = false;
        public bool bMonsterPoisonResistance = false;
        public bool bMonsterPsychicResistance = false;
        public bool bMonsterRadiantResistance = false;
        public bool bMonsterSlashingResistance = false;
        public bool bMonsterThunderResistance = false;

        public bool bMonsterAcidImmunity = false;
        public bool bMonsterBludgeoningImmunity = false;
        public bool bMonsterColdImmunity = false;
        public bool bMonsterFireImmunity = false;
        public bool bMonsterForceImmunity = false;
        public bool bMonsterLightningImmunity = false;
        public bool bMonsterNecroticImmunity = false;
        public bool bMonsterPiercingImmunity = false;
        public bool bMonsterPoisonImmunity = false;
        public bool bMonsterPsychicImmunity = false;
        public bool bMonsterRadiantImmunity = false;
        public bool bMonsterSlashingImmunity = false;
        public bool bMonsterThunderImmunity = false;

        public bool bMonsterAcidVulneerability = false;
        public bool bMonsterBludgeoningVulnerability = false;
        public bool bMonsterColdVulnerability = false;
        public bool bMonsterFireVulnerability = false;
        public bool bMonsterForceVulnerability = false;
        public bool bMonsterLightningVulnerability = false;
        public bool bMonsterNecroticVulnerability = false;
        public bool bMonsterPiercingVulnerability = false;
        public bool bMonsterPoisonVulnerability = false;
        public bool bMonsterPsychicVulnerability = false;
        public bool bMonsterRadiantVulnerability = false;
        public bool bMonsterSlashingVulnerability = false;
        public bool bMonsterThunderVulnerability = false;

        public bool bMonsterBlindedImmunity = false;
        public bool bMonsterCharmedImmunity = false;
        public bool bMonsterDeafenedImmunity = false;
        public bool bMonsterExhaustionImmunity = false;
        public bool bMonsterFrightenedImmunity = false;
        public bool bMonsterGrappledImmunity = false;
        public bool bMonsterIncapacitatedImmunity = false;
        public bool bMonsterInvisibleImmunity = false;
        public bool bMonsterParalyzedImmunity = false;
        public bool bMonsterPetrifiedImmunity = false;
        public bool bMonsterPoisonedImmunity = false;
        public bool bMonsterProneImmunity = false;
        public bool bMonsterRestrainedImmunity = false;
        public bool bMonsterStunnedImmunity = false;
        public bool bMonsterUnconsciousImmunity = false;

        public bool bMonsterKnowsCommon = false;
        public bool bMonsterKnowsDwarvish = false;
        public bool bMonsterKnowsElvish = false;
        public bool bMonsterKnowsGiant = false;
        public bool bMonsterKnowsGnomish = false;
        public bool bMonsterKnowsGoblin = false;
        public bool bMonsterKnowsHalfling = false;
        public bool bMonsterKnowsOrc = false;
        public bool bMonsterKnowsAbyssal = false;
        public bool bMonsterKnowsCelestial = false;
        public bool bMonsterKnowsDraconic = false;
        public bool bMonsterKnowsDeepSpeech = false;
        public bool bMonsterKnowsInfernal = false;
        public bool bMonsterKnowsPrimordial = false;
        public bool bMonsterKnowsSlyvan = false;
        public bool bMonsterKnowsundercommon = false;

        public Monster(string name, int hitDie, int magic, string attackOne, string attackTwo, string attackThree, string attackFour)
        {
            monsterName = name;
            monsterHealthPoints = generateHitPoints(hitDie, 112, 16);
            monsterMagicPoints = magic;
            attackOneName = attackOne;
            attackTwoName = attackTwo;
            attackThreeName = attackThree;
            attackFourName = attackFour;

        }

        public void printMonsterStatBlock()
        {
            Console.WriteLine(monsterName + " total health equals: " + monsterHealthPoints);
        }

        public int generateHitPoints(int hitDie, int hitPointBonus, int monsterLevel)
        {
            Random rnd = new Random();
            /* creating a new variable with hitdie + 1 as CSharp dice rolling requires you to go between 1 and the number above the number you want. I.e. a D6 would be rnd.Nest(1,7) */
            int UpperRandom = hitDie + 1;

            monsterHealthPoints = (monsterLevel * rnd.Next(1, UpperRandom)) + hitPointBonus;


            return monsterHealthPoints;
        }

    }
}
