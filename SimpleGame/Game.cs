using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices;

namespace SimpleGame
{
    class Game
    {
        private Player player;

        /* Variable to store game rooms */
        private Dictionary<string, Room> roomList;
        private Dictionary<string, Item> itemList;
        private Dictionary<string, Weapon> weaponList;
        private Dictionary<string, Armour> armourList;

        /* Variable to store the room we are currently in */
        private string currentRoomName = "Hallway";

        //Weapon and item core variables

        public bool combatRunning = false;

        public string currentItemName;

        public Game()
        {
            /* This is the game constructor, create the rooms as we create the game */
            loadRooms();
            loadItems();
            loadWeapons();
            loadArmour();
            player = new Player();

        }

        private void loadRooms()
        {
            Monster goblin = null;
            Random rnd = new Random();
            int goblinappearence = rnd.Next(1, 3);
            if (goblinappearence == 1)
            {
                goblin = new Monster("Goblin", 5, 0, "Sword", null, null, null);
            }
            //Monster goblin = new Monster("Goblin", 5, 0, "Sword", null, null, null);

            Monster dragon = new Monster("Dragon", 50, 20, "Bite", "Tail Whip", "Fire Breath", null);

            Item potion = new Item("Potion", "A simple healing potion");
            Item apple = new Item("Apple", "It looks juicy and delicious");

            //Create Rooms
            /* Each room will be created with their name and the names of the rooms connected */
            Room hallway = new Room("Hallway", "Kitchen", "empty", "empty", "empty", "empty", "empty", null, potion);
            Room kitchen = new Room("Kitchen", "Lounge", "empty", "Hallway", "empty", "empty", "empty", goblin, apple);
            Room lounge = new Room("Lounge", "empty", "empty", "Kitchen", "empty", "empty", "empty", dragon, null);

            /* Add rooms to the Dictionary, we'll need this later when changing rooms */
            roomList = new Dictionary<string, Room>();
            roomList.Add("Hallway", hallway);
            roomList.Add("Kitchen", kitchen);
            roomList.Add("Lounge", lounge);
        }

        private void loadItems()
        {
            Item potion = new Item("Potion","Restores Health");
            Item ether = new Item("Ether", "Restores Magic");
            Item apple = new Item("Apple", "Juicy");
            Item dagger = new Item("Dagger", "This item has many uses");
            Item key = new Item("Key", "I wonder what this unlocks");

            itemList = new Dictionary<string, Item>();
            itemList.Add("Potion", potion);
            itemList.Add("Ether", ether);
            itemList.Add("Apple", apple);
            itemList.Add("Dagger", dagger);
            itemList.Add("Key", key);
        }

        private void loadWeapons()
        {
            Weapon sword = new Weapon("Sword", "A basic iron sword", 1);
            Weapon axe = new Weapon("Axe", "A basic iron axe", 2);
            Weapon lance = new Weapon("Lance", "A Lance", 3);

            weaponList = new Dictionary<string, Weapon>();
            weaponList.Add("Sword", sword);
            weaponList.Add("Axe", axe);
            weaponList.Add("Lance", lance);
        }

        private void loadArmour()
        {
            Armour leatherArmour = new Armour("Leather Armour", "A basic leather chest piece", 1, false, true, false, false, false);
            Armour leatherLegs = new Armour("Leather Greaves","", 1, false, false, true, false, false);
            Armour leatherGloves = new Armour("Leather Gloves", "", 1, false, false, false, false, true);
            Armour leatherBoots = new Armour("Leather Boots", "", 1, false, false, false, true, false);
            Armour leatherHelm = new Armour("Leather Helmet", "", 1, true, false, false, false, false);

            Armour ironArmour = new Armour("Iron Armour", "An Iron breastplate", 3, false, true, false, false, false);
            Armour ironLegs = new Armour("Iron Greaves","", 3, false, false, true, false, false);
            Armour ironGloves = new Armour("Iron Gloves","", 2, false, false, false, false, true);
            Armour ironBoots = new Armour("Iron Boots","", 2, false, false, false, true, false);
            Armour ironHelm = new Armour("Iron Helm", "",2, true, false, false, false, false);

            Armour steelArmour = new Armour("Steel Armour", "A Steel Breastplate", 5, false, true, false, false, false);
            Armour steelLegs = new Armour("Steel Greaves", "A Steel Breastplate", 5, false, false, true, false, false);
            Armour steelGloves = new Armour("Steel Gloves", "A Steel Breastplate", 5, false, false, false, false, true);
            Armour steelBoots = new Armour("Steel Boots", "A Steel Breastplate", 5, false, false, false, true, false);
            Armour steelHelm = new Armour("Steel Helm", "A Steel Breastplate", 5, true, false, false, false, false);

            armourList = new Dictionary<string, Armour>();
            armourList.Add("Leather Armour",leatherArmour);
            armourList.Add("Leather Greaves",leatherLegs);
            armourList.Add("Leather Gloves", leatherGloves);
            armourList.Add("Leather Boots", leatherBoots);
            armourList.Add("Leather Helm", leatherHelm);
            armourList.Add("Iron Armour", ironArmour);
            armourList.Add("Iron Greaves", ironLegs);
            armourList.Add("Iron Gloves", ironGloves);
            armourList.Add("Iron Boots", ironBoots);
            armourList.Add("Iron Helm", ironHelm);
            armourList.Add("Steel Armour", steelArmour);
            armourList.Add("Steel Greaves", steelLegs);
            armourList.Add("Steel Gloves", steelGloves);
            armourList.Add("Steel Boots", steelBoots);
            armourList.Add("Steel Helm", steelHelm);
        }

        private void AttemptRoomMove(string direction)
        {
            /* Get the current room object */
            Room currentRoom = roomList[currentRoomName];
            Monster currentMonster = roomList[currentRoomName].monster;

            /* Ask the room object what is in the entered direction */
            String roomMoveResult = currentRoom.TryToExit(direction);

            /* If the response is not "empty", update the current room string */
            if (roomMoveResult != "empty")
            {
                currentRoomName = roomMoveResult;
                Console.WriteLine("You are in the " + currentRoomName);
                if (!roomList[currentRoomName].IsMonsterDead())
                {
                    combatRunning = true;
                    combat(currentMonster, player);
                }
            }
        }

        public void combat(Monster monster, Player player)
        {

            while (combatRunning)
            {
                Console.WriteLine("You are in combat. What would you like to do?");
                string combatInput = Console.ReadLine();
                switch (combatInput)
                {
                    case "attack":
                        break;
                    case "defend":
                        break;
                    case "north":
                    case "east":
                    case "south":
                    case "west":
                    case "up":
                    case "down":
                        Console.WriteLine("If you try to run, the monster will kill you");
                        break;
                }
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

        public void equipItem()
        {

            Console.WriteLine("What would you like to equip?");
            string equipItemInput = Console.ReadLine();

            currentItemName = equipItemInput;

            //body part of if
            if (equipItemInput == "Leather Armour" || equipItemInput == "Iron Armour" || equipItemInput == "Steel Armour")
            {
                Armour currentItem = armourList[currentItemName];

                player.sUpperBodyItemName = currentItem.sArmourName;
                
                //player.sUpperBodyItemName = equipItemInput;
                player.bUpperBodyItemEquipped = true;
                player.iUpperBodyItemArmour = currentItem.iArmourDefenceValue;

            }
            //leg part of if
            else if (equipItemInput == "Leather Greaves" || equipItemInput == "Iron Greaves" || equipItemInput == "Steel Greaves")
            {
                Armour currentItem = armourList[currentItemName];

                player.sLowerBodyItemName = currentItem.sArmourName;
                player.bLowerBodyItemEquipped = true;
                player.iLowerBodyItemArmour = currentItem.iArmourDefenceValue;

            }
            //head part of if
            else if (equipItemInput == "Leather Helm" || equipItemInput == "Iron Helm" || equipItemInput == "Steel Helm")
            {
                Armour currentItem = armourList[currentItemName];

                player.sHeadItemName = currentItem.sArmourName;
                player.bHeadItemEquipped = true;
                player.iHeadItemArmour = currentItem.iArmourDefenceValue;
 
            }
            //feet part of if
            else if (equipItemInput == "Leather Boots" || equipItemInput == "Iron Boots" || equipItemInput == "Steel Boots")
            {
                Armour currentItem = armourList[currentItemName];

                player.sLegItemName = currentItem.sArmourName;
                player.bLegItemEquipped = true;
                player.iLegItemArmour = currentItem.iArmourDefenceValue;
            }
            //hand part of if
            else if (equipItemInput == "Leather Gloves" || equipItemInput == "Iron Gloves" || equipItemInput == "Steel  Gloves")
            {
                Armour currentItem = armourList[currentItemName];

                player.sArmItemName = currentItem.sArmourName;
                player.bArmItemEquipped = true;
                player.iArmItemArmour = currentItem.iArmourDefenceValue;
            }
            //what happens when player trries to equip weapon
            else if (equipItemInput == "Sword" || equipItemInput == "Axe" || equipItemInput == "Lance")
            {
                Weapon currentItem = weaponList[currentItemName];

            }
            //what happens when player tries to equip non equippable item
            else if (equipItemInput == "Apple" || equipItemInput == "Ether" || equipItemInput == "Apple" || equipItemInput == "Dagger" || equipItemInput == "Key")
            {
               
                Console.WriteLine("This item cannot be equipped");
            }
            //what happens when an invalid entry is tried
            else
            {
                Console.WriteLine("Not a valid choice");
            }

            Console.WriteLine("You equipped the " + equipItemInput);
            Console.WriteLine("");

        }

        /*public struct SaveData
        {
            public string headItemName;
            public string headItemValue;
            public string thirdLine;
        }

        byte[] getBytes(SaveData SaveData)
        {
            int length = Marshal.SizeOf(SaveData);
            byte[] arr = new byte[length];

            IntPtr ptr = Marshal.AllocHGlobal(length);
            Marshal.StructureToPtr(length, ptr, true);
            Marshal.Copy(ptr, arr, 0, length);
            Marshal.FreeHGlobal(ptr);

            return arr;
        }*/

        public void SaveGame()
        {
            /*SaveData SaveData;

            SaveData.headItemName = player.sHeadItemName;
            SaveData.headItemValue = player.iHeadItemArmour.ToString();
            SaveData.thirdLine = "Last Piece of Test Data";*/

            string headItemName;
            string headItemValue;

            string[] lines = { headItemName = player.sHeadItemName, headItemValue = player.iHeadItemArmour.ToString(), "Last Piece of Test" };

            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "IvansSaveGameTest.txt")))
            {
                foreach (string line in lines)
                    outputFile.WriteLine(line);
            }
        }

        public void TakeItem()
        {
            /*get the current room and item objects*/
            Room currentRoom = roomList[currentRoomName];
            Item currentItem = roomList[currentRoomName].item;

            Console.WriteLine("What would you like to take?");
            string itemToBeTaken = Console.ReadLine();

            currentItemName = itemToBeTaken;
            /*Check whether an item exists in the room*/
            bool checkItemExists = currentRoom.HasItemBeenTaken();

            /*check player input matches the item that is there*/
            for each(line in dict){

            }

            if (checkItemExists == false)
            {
                switch (currentItemName)
                {
                    case "potion":

                        break;
                    case "Ether":
                        break;
                    case "Apple":
                        break;
                    case "Dagger":
                        break;
                    case "key":
                        break;
                }
            }
            else if (checkItemExists == true)
            {
                Console.WriteLine("You have already taken " + currentItemName + "!");
            }
            else
            {
                Console.WriteLine("There is no " + currentItemName + " to take.");
            }


            

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
                    case "drop":
                        break;
                    case "equip":
                        equipItem();
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
                        SaveGame();
                        break;
                    case "status":
                        player.checkStatus();
                        break;
                    case "take":
                        TakeItem();
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
