using Escape.Classes;
using System.Data;


namespace Escape
{
    internal class Program
    {
        // Player instance
        public static Player currentPlayer = new Player();

        static void Main(string[] args)
        {

            Story story = new Story();
            
            // Welcome
            Console.WriteLine("Welcome to ESCAPE!");
            Console.ReadLine();

            // Register
            UsefulGameTools.Register();

            // Introduction
            UsefulGameTools.GameIntroduction();

            // Game-On
            story.Part01Room01();



        }

    }
}