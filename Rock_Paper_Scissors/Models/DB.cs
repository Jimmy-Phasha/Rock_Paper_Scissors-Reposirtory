using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rock_Paper_Scissors.Models
{
    public class DB
    {
        public static List<Item> GetAllItems()
        {
            List<Item> Items = new List<Item>
            {
                new Item
                {
                    ID = 1,
                    Name = "ROCK"
                },

                new Item
                {
                    ID = 2,
                    Name = "PAPER"
                },

                new Item
                {
                    ID = 3,
                    Name = "SCISSORS"
                }
            };

            return Items;
        }
        

        public static Item GetItem(int id)
        {
            List<Item> Items = DB.GetAllItems();
            foreach(Item i in Items)
            {
                if (i.ID == id)
                    return i;
            }

            return null;
        }
    }
}
