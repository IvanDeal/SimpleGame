using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGame
{
    class Game
    {
        /* Variable to store game rooms */
        private Dictionary<string, Room> roomList;

        /* Variable to store the room we are currently in */
        private string currentRoomName = "Hallway";

        //Weapon and item core variables

        static string leftHandItemName;
        static bool leftHandItemEquipped = false;
        static int leftHandItemDamage;
        static int leftHandItemArmour;

        static string rightHandItemName;
        static bool rightHandItemEquipped = false;
        static int rightHandItemDamage;
        static int rightHandItemArmour;

        //Apparel variables

        static string upperBodyItemName;
        static bool upperBodyItemEquipped = false;
        static int upperBodyItemArmour;

        static string lowerBodyItemName;
        static bool lowerBodyItemEquipped = false;
        static int lowerBodyItemArmour;

        static string armItemName;
        static bool armItemEquipped = false;
        static int armItemArmour;

        static string legItemName;
        static bool legItemEquipped = false;
        static int legItemArmour;

        static string headItemName;
        static bool headItemEquipped = false;
        static int headItemArmour;

        public Game()
        {
            /* This is the game constructor, create the rooms as we create the game */
            loadRooms();
        }

        private void loadRooms()
        {
            Monster goblin = new Monster("Goblin", 5, 0, "Sword", null, null, null);
            Monster dragon = new Monster("Dragon", 50, 20, "Bite", "Tail Whip", "Fire Breath", null);

            //Create Rooms
            /* Each room will be created with their name and the names of the rooms connected */
            Room hallway = new Room("Hallway", "Kitchen", "empty", "empty", "empty", "empty", "empty", null);
            Room kitchen = new Room("Kitchen", "Lounge", "empty", "Hallway", "empty", "empty", "empty", goblin);
            Room lounge = new Room("Lounge", "empty", "empty", "Kitchen", "empty", "empty", "empty", null);

            /* Add rooms to the Dictionary, we'll need this later when changing rooms */
            roomList = new Dictionary<string, Room>();
            roomList.Add("Hallway", hallway);
            roomList.Add("Kitchen", kitchen);
            roomList.Add("Lounge", lounge);
        }

        private void loadItems()
        {

        }

        private void loadWeapons()
        {

        }

        private void loadArmour()
        {

        }

        private void AttemptRoomMove(string direction)
        {
            /* Get the current room object */
            Room currentRoom = roomList[currentRoomName];

            /* Ask the room object what is in the entered direction */
            String roomMoveResult = currentRoom.TryToExit(direction);

            /* If the response is not "empty", update the current room string */
            if (roomMoveResult != "empty")
            {
                currentRoomName = roomMoveResult;
                Console.WriteLine("You are in the " + currentRoomName);
                if (!roomList[currentRoomName].IsMonsterDead())
                {
                    combat();
                }
            }
        }

        public void combat()
        {

        }

        public void checkStatus()
        {
            if (leftHandItemEquipped == false)
            {
                Console.WriteLine("You have nothing equipped in your left hand");
            }
            else if (leftHandItemDamage != 0)
            {
                Console.WriteLine("You have " + leftHandItemName + " equipped.");
                Console.WriteLine("It cannot be used in combat");
            }
            else
            {
                Console.WriteLine("You have " + leftHandItemName + " equipped.");
                Console.WriteLine("It does " + leftHandItemDamage + " damage when attacking.");
                Console.WriteLine("It provides " + leftHandItemArmour + " when blocking.");
            }

            if (rightHandItemEquipped == false)
            {
                Console.WriteLine("You have nothing equipped in your right hand");
            }
            else if (rightHandItemDamage != 0)
            {
                Console.WriteLine("You have " + rightHandItemName + " equipped.");
                Console.WriteLine("It cannot be used in combat");
            }
            else
            {
                Console.WriteLine("You have " + rightHandItemName + " equipped.");
                Console.WriteLine("It does " + rightHandItemDamage + " damage when attacking.");
                Console.WriteLine("It provides " + rightHandItemArmour + " when blocking.");
            }

            if (upperBodyItemEquipped == false)
            {
                Console.WriteLine("You have nothing equipped on your upper body.");
            }
            else
            {
                Console.WriteLine("You are currently wearing " + upperBodyItemName + ".");
                Console.WriteLine("It provides " + upperBodyItemArmour + " armour.");
            }


            if (lowerBodyItemEquipped == false)
            {
                Console.WriteLine("You have nothing equipped on your lower body.");
            }
            else
            {
                Console.WriteLine("You are currently wearing " + lowerBodyItemName + ".");
                Console.WriteLine("It provides " + lowerBodyItemArmour + " armour.");
            }

            if (armItemEquipped == false)
            {
                Console.WriteLine("You are not wearing anything on your arms");
            }
            else
            {
                Console.WriteLine("You are currently wearing " + armItemName + ".");
                Console.WriteLine("It provides " + armItemArmour + " armour.");
            }

            if (legItemEquipped == false)
            {
                Console.WriteLine("You are not wearing anything on your legs");
            }
            else
            {
                Console.WriteLine("You are currently wearing " + legItemName + ".");
                Console.WriteLine("It provides " + legItemArmour + " armour.");
            }

            if (headItemEquipped == false)
            {
                Console.WriteLine("You are not wearing anything on your head");
            }
            else
            {
                Console.WriteLine("You are currently wearing " + headItemName + ".");
                Console.WriteLine("It provides " + headItemArmour + " armour.");
            }

        }

        public void helpList()
        {
            Console.WriteLine("Attack: Type Attack and then type the name of what you want to attack. Damage done will be based on your equipped weapon(s) E.g. Attack Goblin");
            Console.WriteLine("Defend: Type Defend. ");
            Console.WriteLine("Drop: Type Drop followed by the item you wish to drop E.g. Drop Sword");
            Console.WriteLine("Equip: Type Equip followed by the item you would like to equip E.g. Equip Sword");
            Console.WriteLine("Examine: Type Examine followed by what you would like to look at E.g. Examine Door");
            Console.WriteLine("Exit: Type Exit to quit the game");
            Console.WriteLine("Go: Type Go followed by the direction (North, South, East, West) you would like to travel E.g. Go North");
            Console.WriteLine("Inventory: Type Inventory to see a list of all items in your posession");
            Console.WriteLine("Load: Type Load to load the recent save file");
            Console.WriteLine("Save: Type Save to save your progress");
            Console.WriteLine("Status: Type Status to view equipped items and check your characters status");
            Console.WriteLine("Take: Type Take followed by the item you wish to take to add the item to your inventory E.g. Take Sword");
            Console.WriteLine("Talk: Type Talk followed by the character youwould like to talk to E.g. Talk Wizard");
            Console.WriteLine("Throw: Type Throw followed the item you wish to throw E.G. Throw Dart");
            Console.WriteLine("Use: Type Use followed by the item you wish to use E.g. Use Potion");
        }

        public void checkInventory()
        {
            IDictionary<string, int> dict = new Dictionary<string, int>()
            {
                {"Potion", 0 },
                {"Ether", 0 },
                {"Apple", 0 },
                {"Dagger", 0 },
                {"Key", 0 }
            };

            foreach (KeyValuePair<string, int> pair in dict)
            {
                if (pair.Value > 0)
                {
                    Console.WriteLine(pair.Key.ToString() + " - " + pair.Value.ToString());
                }

            }

        }

        public void equipItem(string itemName)
        {

        }

        public static void exitGame()
        {
            Environment.Exit(0);
        }

        public void GameLoop()
        {

            while (true)
            {
                Console.WriteLine("Welcome! What would you like to do?");
                Console.WriteLine("Type HELP if you would like some suggestions.");
                

                string userInput = Console.ReadLine();

                string trimmedInput = userInput.Trim();
                string convertedInput = trimmedInput.ToLower();

                //string currentLevelDescription = currentRoom.room

                switch (convertedInput)
                {
                    case "attack":
                        break;
                    case "defend":
                        break;
                    case "drop":
                        break;
                    case "equip":
                        break;
                    case "examine":
                        break;
                    case "exit":
                        exitGame();
                        break;
                    case "help":
                        helpList();
                        break;
                    case "inventory":
                        checkInventory();
                        break;
                    case "load":
                        break;
                    case "save":
                        break;
                    case "status":
                        checkStatus();
                        break;
                    case "take":
                        break;
                    case "talk":
                        break;
                    case "throw":
                        break;
                    case "use":
                        break;
                    /* Moving through rooms */
                    case "north":
                    case "east":
                    case "south":
                    case "west":
                    case "up":
                    case "down":
                        AttemptRoomMove(convertedInput);
                        break;
                }

            }
        }
    }
}
