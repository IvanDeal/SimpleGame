using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGame
{
    class Room
    {
        public string northExit;
        public string eastExit;
        public string southExit;
        public string westExit;
        public string upExit;
        public string downExit;
        public string roomName;
        public Monster monster;
        public bool monsterDeadFlag = false;
        public Item item;
        public bool itemHasBeenTakenFlag = false;

        public Room(string name, string north, string east, string south, string west, string up, string down, Monster monster, Item item)
        {
            /* Set the object's exit variables with the passed in strings */
            roomName = name;
            northExit = north;
            eastExit = east;
            southExit = south;
            westExit = west;
            upExit = up;
            downExit = down;
            this.monster = monster;
            this.item = item;
        }

        public string TryToExit(string direction)
        {
            /* Make the response empty by default (to be overwritten with the exit variable) */
            string response = "empty";
            switch (direction)
            {
                case "north":
                    response = northExit;
                    break;
                case "east":
                    response = eastExit;
                    break;
                case "south":
                    response = southExit;
                    break;
                case "west":
                    response = westExit;
                    break;
                case "up":
                    response = upExit;
                    break;
                case "down":
                    response = downExit;
                    break;
            }

            return response;
        }
        
        public bool IsMonsterDead()
        {
            // if monster name is not null and monsterdeadflag is false
            if (monster != null && !monsterDeadFlag)
            {
                Console.WriteLine("There is a " + monster.monsterName + " here!");
                return false;
                //combatus
            } else
            {
                Console.WriteLine("No monster for you!");
                return true;
            }
        }

        public bool HasItemBeenTaken()
        {
            if (item != null && !itemHasBeenTakenFlag)
            {

                return false;
            } else
            {
                Console.WriteLine("You have already taken that!");
                return true;
            }
        }

     }

}

