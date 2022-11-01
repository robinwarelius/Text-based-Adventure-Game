using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Escape.Interfaces;

namespace Escape.Classes
{
    public class Mission02 : IMission
    {
        public string Name { get; private set; }
        public string Player { get; private set; }
        public int DecreaseLife { get; private set; }

        private Random _random = new Random();

        private int _roll01;
        private int _roll02;
        private int _number;
        private int _count;

        public Mission02()
        {
            Name = "Roll Dice";
            DecreaseLife = 2;
            _roll01 = 0;
            _roll02 = 1;
            _number = 1;
        }

        public void GameOn()
        {
            Console.WriteLine($"Game-Type: {Name}.");
            Console.WriteLine($"Information: Roll your two dices at the same time & get equal numbers to complete the mission. Press any key to make your first move...");
            Console.ReadKey();
            Console.Clear();

            for (_count = 0; _roll01 != _roll02; _count++)
            {
                _roll01 = _random.Next(1, 7);
                _roll02 = _random.Next(1, 7);
                Console.WriteLine($"ROUND {_number}.\nDice ONE: {_roll01}\nDice TWO: {_roll02}");
                _number++;
                Program.currentPlayer.DecreaseLife(DecreaseLife);

                if (_roll01 != _roll02)
                {
                    Console.WriteLine($"Life decreased by: {DecreaseLife}%. Current life: {Program.currentPlayer.Life}%");
                }

                Console.ReadKey();

            }

            Console.WriteLine($"RESULTS: it took you {_count} attempts to roll two dices with equal numbers. MISSION COMPLETED!");
            Console.ReadKey();

        }

    }
}
