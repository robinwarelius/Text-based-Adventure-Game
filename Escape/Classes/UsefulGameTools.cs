using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Escape.Classes
{
    public static class UsefulGameTools
    {
        public static void Register()
        {
            do
            {
                Console.Clear();
                Console.Write("Enter username: ");
                Program.currentPlayer.Name = Console.ReadLine();
            }
            while (Program.currentPlayer.Name == "");

            Console.WriteLine($"Welcome {Program.currentPlayer.Name.ToUpper()} let the game begin!");
            Console.ReadKey();
            Console.Clear();

        }

        public static void GameIntroduction()
        {
            string answer = string.Empty;
            bool keepGoing = true;

            while (keepGoing == true)
            {
                Console.Clear();
                Console.WriteLine($"{Program.currentPlayer.Name.ToUpper()} you are in a facility placed far away from home and you have been kidnapped.");
                Console.WriteLine("Would you like to know why? (y/n)");
                answer = Console.ReadLine();

                if (answer.ToLower() == "y")
                {
                    Console.Clear();
                    Console.WriteLine("\t\tWHY\n");
                    Console.WriteLine("* You don't take care of yourself or your family.");
                    Console.WriteLine("* Ask yourself: When was the last time you saw your own daughter?");
                    Console.WriteLine("* This is your opportunity to find happiness. But first you need to survive the GAME!");
                    Console.WriteLine("* If you survive you might start to appreciate life again.");
                    Console.WriteLine($"* Remember we are watching you {Program.currentPlayer.Name.ToUpper()}!");
                    Console.ReadKey();
                    keepGoing = false;
                }
                else if (answer.ToLower() == "n")
                {
                    Console.Clear();
                    Console.WriteLine($"Ok you don't wanna know. But remeber we are watching you {Program.currentPlayer.Name.ToUpper()}!");
                    Console.ReadKey();
                    keepGoing = false;
                }
                else
                {
                    Console.Clear();
                    Program.currentPlayer.Life = Program.currentPlayer.DecreaseLife(20);
                    Console.WriteLine($"Invalid answer {Program.currentPlayer.Name.ToUpper()}!");
                    Console.WriteLine($"Your life decreased by: 20%. Your current life is now: {Program.currentPlayer.Life}%!");
                    Console.WriteLine("It's important in this game to make the right decisions!");
                    Console.ReadKey();

                }
            }

            Console.Clear();
            Console.WriteLine("\t\tINFORMATION ABOUT THE GAME\n");
            Console.WriteLine("* The facility you are kept in has two rooms and you start in room one. ");
            Console.WriteLine("* The rules are simple: finish the missions in both rooms without dying and you will gain your freedom!");
            Console.WriteLine("* You have a backpack with items. Use them wisely.");
            Console.ReadKey();
            Console.Clear();
        }
    

    }
}
