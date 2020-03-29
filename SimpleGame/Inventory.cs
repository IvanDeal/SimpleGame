using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGame
{
    class Inventory
    {
        public string sItemName;
        public string sItemDescription;
        public int iItemQuantity;
        public Dictionary<string, int> inventoryList;

        public Inventory()
        {
            createInventory();
        }

        public void createInventory()
        {
            inventoryList = new Dictionary<string, int>();
        }

        public void checkInventory()
        {

            foreach (KeyValuePair<string, int> pair in inventoryList)
            {
                if (pair.Value > 0)
                {
                    Console.WriteLine(pair.Key.ToString() + " - " + pair.Value.ToString());
                }

            }
        }

        public int addItemtoInventory(Item item)
        {
            if (inventoryList != null)
            {
                for (int i = 0; i < inventoryList.Length; i++)
                {
                    if (inventoryList[i] == null)
                    {
                        inventoryList[i] = item;
                        return i;
                    }
                }
            }
            return -1;

        }

        public void removeItemFromInventory()
        {

        }

    }
}
