using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escape.Classes
{
    public class Player
    {
        public string Name { get; set; }
        public int Life { get; set; } = 100;

        public List<Item> BagOfItems = new List<Item>();

        public int DecreaseLife(int damage)
        {
            Life -= damage;

            if (Life < 1)
            {
                Story story = new Story();
                story.GameOver();
            }
            return Life;
        }

        public void Look()
        {
            Console.WriteLine($"Name: {Name.ToUpper()}");
            Console.WriteLine($"Life: {Life}%");
        }

        public void InspectBackPack()
        {
            Console.Clear();
            foreach (Item i in BagOfItems)
            {
                Console.WriteLine($"{i.Name}, Amount: {i.Amount}");
            }

        }

        public void UpdateBagWithItem(string item)
        {
            if (item != null)
            {
                Item newItem = Repository.GetAllItems().Where(x => x.Name.ToLower() == item.ToLower()).SingleOrDefault();
                BagOfItems.Add(newItem);
                Console.WriteLine($"Added to backpack: {newItem.Name}");
            }

        }
        public void RemoveItemFromBag(string item)
        {
            if (item != null)
            {
                var newItem = BagOfItems
                       .SingleOrDefault(x => x.Name.ToLower().Contains(item.ToLower()));
                BagOfItems.Remove(newItem);
                Console.WriteLine($"Removed from backpack: {newItem.Name}");
            }

        }




    }
}
