using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escape.Classes
{
    public class Room
    {
        public string Name { get; set; }

        public bool Light { get; set; }

        public int AmountOfDoors { get; set; }

        public int AmountOfMissions { get; set; }

        public List<Item> Item { get; set; }

        public Room(string name, bool light, int amountOfDoors, int amountOfMissions, List<Item> item)
        {
            Name = name;
            Light = light;
            AmountOfDoors = amountOfDoors;
            AmountOfMissions = amountOfMissions;
            Item = item;
        }

        public void DoorOpen()
        {
            Console.WriteLine($"The door is OPENED");
        }

        public void DoorClose()
        {
            Console.WriteLine($"The door is ClOSED & LOCKED");
        }

        public void Look()
        {

            Console.WriteLine($"Name: {Name}");
            if (Light == false)
            {
                Console.WriteLine("Light: The room is dark");
            }
            else if (Light == true)
            {
                Console.WriteLine("The room is bright!");
            }
            Console.WriteLine($"Amount of doors: {AmountOfDoors}");
            Console.WriteLine($"Amount of missions: {AmountOfMissions}");
            foreach (Item i in Item)
            {
                Console.WriteLine($"Items: {i.Name}");
            }

        }

    }
}
