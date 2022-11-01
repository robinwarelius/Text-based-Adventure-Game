
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;
using System.Net.Http.Headers;

namespace Escape.Classes
{
    public static class Repository
    {
        public static List<Item> GetAllItems()
        {
            List<Item> items = new List<Item>();
            items.Add(new Item("match of fire", 1));
            items.Add(new Item("dry wooden stick", 1));
            items.Add(new Item("torch of light", 1));
            items.Add(new Item("the ancient key", 1));
            items.Add(new Item("the fire key", 1));
            items.Add(new Item("the dice of fury", 1));
            items.Add(new Item("the dice of death", 1));
            return items;
        }
       
    
        public static List <Room> GetAllRooms()
        {
            Item key = GetAllItems().Where(x => x.Name.ToLower() == "the ancient key").SingleOrDefault();
            List <Item> key01 = new List<Item> { key };

            Item dice01 = GetAllItems().Where(x => x.Name.ToLower() == "the dice of fury").SingleOrDefault();
            Item dice02 = GetAllItems().Where(x => x.Name.ToLower() == "the dice of death").SingleOrDefault();
            List <Item> dice = new List<Item> { dice01, dice02 };

            List<Room> rooms = new List<Room>();
            rooms.Add (new Room("Room of hell, (1/2)", false, 1, 1, key01));
            rooms.Add (new Room("Room of TEARS, (2/2)", true, 1, 1, dice));
            return rooms;
        }

       
    }
}
