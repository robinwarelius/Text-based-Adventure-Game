using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Escape.Interfaces;

namespace Escape.Classes
{
    public class Mission01 : IMission
    {
        public string Name { get; private set; }
        public string Player { get; private set; }
        public int DecreaseLife { get; private set; }

        private Random _random;
        private string _vampire;
        private int _playerScore;

        public Mission01()
        {
            Name = "Rock, paper & scissors";
            DecreaseLife = 5;
            _random = new Random();
            _playerScore = 0;

        }

        public void GameOn()
        {
            Console.WriteLine($"Game-Type: {Name}.");
            Console.WriteLine("Information: win 3 times to complete the mission.");
            Console.ReadKey();
            Console.Clear();

            while (_playerScore < 3)
            {
                _vampire = RandomGenerateInput();
                Player = string.Empty;

                while (Player.ToLower() != "rock" && Player.ToLower() != "paper" && Player.ToLower() != "scissors")
                {
                    Console.WriteLine("Choose: rock, paper or scissors.");
                    Player = Console.ReadLine();

                }

                switch (Player)
                {
                    case "rock":
                        if (_vampire == "rock")
                        {
                            Console.WriteLine($"Vampire: {_vampire}, You: {Player} - DRAW");
                        }
                        else if (_vampire == "paper")
                        {
                            Console.WriteLine($"Vampire: {_vampire}, You: {Player} - VAMPIRE WIN");
                            Program.currentPlayer.DecreaseLife(DecreaseLife);
                            Console.WriteLine($"Life decreased by: {DecreaseLife}%. Current life: {Program.currentPlayer.Life}%");
                        }
                        else if (_vampire == "scissors")
                        {
                            Console.WriteLine($"Vampire: {_vampire}, You: {Player} - YOU WIN");
                            _playerScore++;
                        }
                        break;

                    case "paper":
                        if (_vampire == "rock")
                        {
                            Console.WriteLine($"Vampire: {_vampire}, You: {Player} - YOU WIN");
                            _playerScore++;
                        }
                        else if (_vampire == "paper")
                        {
                            Console.WriteLine($"Vampire: {_vampire}, You: {Player} - DRAW");
                        }
                        else if (_vampire == "scissors")
                        {
                            Console.WriteLine($"Vampire: {_vampire}, You: {Player} - VAMPIRE WIN");
                            Program.currentPlayer.DecreaseLife(DecreaseLife);
                            Console.WriteLine($"Life decreased by: {DecreaseLife}%. Current life: {Program.currentPlayer.Life}%");
                        }
                        break;

                    case "scissors":
                        if (_vampire == "rock")
                        {
                            Console.WriteLine($"Vampire: {_vampire}, You: {Player} - VAMPIRE WIN");
                            Program.currentPlayer.DecreaseLife(DecreaseLife);
                            Console.WriteLine($"Life decreased by: {DecreaseLife}%. Current life: {Program.currentPlayer.Life}%");
                        }
                        else if (_vampire == "paper")
                        {
                            Console.WriteLine($"Vampire: {_vampire}, You: {Player} - YOU WIN");
                            _playerScore++;
                        }
                        else if (_vampire == "scissors")
                        {
                            Console.WriteLine($"Vampire: {_vampire}, You: {Player} - DRAW");
                        }
                        break;

                }
                Console.WriteLine($"Your score: {_playerScore} ");
                Console.ReadKey();
                Console.Clear();
            }

        }

        private string RandomGenerateInput()
        {
            string result = string.Empty;

            switch (_random.Next(1, 4))
            {
                case 1: result = "rock"; break;
                case 2: result = "paper"; break;
                case 3: result = "scissors"; break;
            }

            return result;
        }

    }
}
