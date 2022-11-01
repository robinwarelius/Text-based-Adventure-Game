using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;

namespace Escape.Classes
{
    public class Story
    {
        Room room01;
        Room room02;
        public bool OwnKey;
        public bool InspectTheDoor;

        public Story()
        {
            room01 = Repository.GetAllRooms().Where(x => x.Name.ToLower() == "room of hell, (1/2)").SingleOrDefault();
            room02 = Repository.GetAllRooms().Where(x => x.Name.ToLower() == "room of tears, (2/2)").SingleOrDefault();
        }

        public void Part01Room01()
        {
            Program.currentPlayer.UpdateBagWithItem("Match Of Fire");
            Program.currentPlayer.UpdateBagWithItem("Dry Wooden Stick");
            Inspectation(room01);

            string result1 = string.Empty;
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"The {room01.Name} is dark. Use your items in your backpack to light a torch.");
                Console.WriteLine("Press 1. To inspect backpack | Press 2. To light a torch");
                result1 = Console.ReadLine();

                if (result1 == "1")
                {
                    Program.currentPlayer.InspectBackPack();
                    Console.ReadKey();
                }
                else if (result1 == "2")
                {
                    Console.Clear();
                    Program.currentPlayer.RemoveItemFromBag("Match Of Fire");
                    Program.currentPlayer.RemoveItemFromBag("Dry Wooden stick");
                    Program.currentPlayer.UpdateBagWithItem("Torch Of Light");
                    room01.Light = true;
                    Console.ReadKey();
                    break;
                }
            }

            while (true)
            {
                Console.Clear();
                Console.WriteLine("The room is now light and in front of you there is a small vampire.");
                Console.WriteLine("The vampire would like to play a game with you. Would you like to play? (y/n)");
                string result2 = Console.ReadLine();

                if (result2.ToLower() == "y")
                {
                    Console.Clear();
                    Mission01 mission01 = new Mission01();
                    mission01.GameOn();
                    break;
                }
                else
                {
                    Console.Clear();
                    Program.currentPlayer.DecreaseLife(10);
                    Console.WriteLine("Wrong answer. The vampire bit you!");
                    Console.WriteLine($"Life decreased by: {10}%. Current life: {Program.currentPlayer.Life}%");
                    Console.ReadKey();

                }
            }

            Console.WriteLine("You made it! The vampire ran away and dropped a key on the floor.");
            Console.ReadKey();
            Part02Room01();

        }

        public void Part02Room01()
        {
            Console.WriteLine("Would you like to pick up the key? (y/n)");
            string result = Console.ReadLine();

            if (result.ToLower() == "y")
            {
                KeyYes01();
            }
            else
            {
                KeyNo01();
            }
        }

        public void KeyNo01()
        {
            OwnKey = false;
            Console.Clear();
            InspectDoor();
        }

        public void KeyYes01()
        {
            Console.Clear();
            OwnKey = true;
            Program.currentPlayer.UpdateBagWithItem("the ancient key");
            Console.WriteLine("Would you like to inspect backpack?(y/n)");
            string result1 = Console.ReadLine();

            if (result1.ToLower() == "y")
            {
                Program.currentPlayer.InspectBackPack();
                Console.ReadKey();
            }

            Console.Clear();
            InspectDoor();
        }

        public void InspectDoor()
        {
            if (InspectTheDoor == false)
            {
                Console.WriteLine("You now see a door at the end of the room. Would you like to inspect it? (y/n)");
                string result2 = Console.ReadLine();

                if (result2.ToLower() == "y")
                {
                    Console.Clear();
                    InspectDoorRoom01();
                    room01.DoorClose();
                    Console.ReadKey();
                }
                InspectTheDoor = true;
                Console.Clear();
            }

            if (OwnKey == true)
            {
                ExitTheRoom();
            }
            else
            {
                Console.WriteLine("Go back and pick up the key on the floor, stupid...");
                Console.ReadKey();
                Part02Room01();
            }
        }

        public void ExitTheRoom()
        {
            Console.WriteLine($"Would you like to try if the key fits to the door? (y/n)");
            string result = Console.ReadLine();
            if (result.ToLower() == "y")
            {
                Console.Clear();
                Program.currentPlayer.RemoveItemFromBag("the ancient key");
                room01.DoorOpen();
                Console.WriteLine("Congratulations! You are now entering the last room. Good luck & may GOD be with you!");
                Console.ReadKey();
                Part01Room02();
            }
            else
            {
                Console.WriteLine("Your stupidity amazes me. Good bye!");
                Console.ReadKey();
                Console.Clear();
                GameOver();
            }
        }

        public void Part01Room02()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the last and final room!");
            Console.ReadKey();
            Inspectation(room02);
            Console.WriteLine("On the floor you now see a wizard sitting down with a sad face.");
            Console.WriteLine($"It's time to play a game {Program.currentPlayer.Name.ToUpper()}. Survive this and you will gain your freedom, the Wizard said.");
            Console.WriteLine("Here you have two dices for the game.");
            Console.ReadKey();


            Program.currentPlayer.UpdateBagWithItem("the dice of fury");
            Program.currentPlayer.UpdateBagWithItem("the dice of death");
            Console.ReadKey();
            Console.Clear();
            Mission02 mission02 = new Mission02();
            mission02.GameOn();
            Console.Clear();
            Console.WriteLine("While the WIZARD congratulates you, he grabs your backpack and steels your dices.");
            Console.ReadKey();
            Program.currentPlayer.RemoveItemFromBag("the dice of fury");
            Program.currentPlayer.RemoveItemFromBag("the dice of death");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Would you like to have the KEY to the last door, so you can finish the game? The WIZARD then said...(y/n)");
            string result = Console.ReadLine();

            if (result.ToLower() == "y")
            {
                OwnKey = true;
                KeyYes02();
            }
            else
            {
                OwnKey = false;
                KeyNo02();
            }
        }

        public void KeyNo02()
        {
            Console.WriteLine("The Wizard shakes his head of confusion, raises his magic wand and slapps you hard in the face.");
            Console.ReadKey();
            Program.currentPlayer.DecreaseLife(10);
            Console.WriteLine($"Life decreased by: {10}%. Current life: {Program.currentPlayer.Life}%");
            Console.ReadKey();
            Console.WriteLine("!PUFF! And the Wizard was gone with the key.");
            Console.ReadKey();
            InspectExitDoor();
        }

        public void KeyYes02()
        {
            Program.currentPlayer.UpdateBagWithItem("the fire key");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Would you like to inspect your backpack? (y/n)");
            string result = Console.ReadLine();

            if (result.ToLower() == "y")
            {
                Program.currentPlayer.InspectBackPack();
                Console.ReadKey();
            }

            InspectExitDoor();
        }

        public void InspectExitDoor()
        {
            Console.Clear();
            Console.WriteLine("At the end of the room you finally see a door. Could it be the EXIT?...");
            Console.WriteLine("Would you like to inspect the door? (y/n)");
            string result = Console.ReadLine();

            if (result.ToLower() == "y")
            {
                Console.Clear();
                InspectDoorRoom02();
                room02.DoorClose();
                Console.ReadKey();
            }

            OpenExitDoor();
        }

        public void OpenExitDoor()
        {
            if (OwnKey == true)
            {
                Console.WriteLine($"You decide to open the door with the key.");
                Console.WriteLine("Great decision and good bye, you could hear both the Wizard and Vampire yelling from somewhere in the facility...");
                Console.ReadKey();
                TheEnd();
            }
            else
            {
                NoKey();
            }
        }

        public void NoKey()
        {
            Console.Clear();
            Console.WriteLine("You don't possess the key for the door!");
            Console.ReadKey();
            Console.WriteLine("A lepercon arises from nowhere");
            Console.WriteLine("I will help you to open the door if you can solve this riddle, the lepercon said...");
            Console.WriteLine("What does the human body have in common with a prison? Write down the answer. You only have ONE attempt...");
            string result = Console.ReadLine();

            if (result.ToLower() == "cell" || result.ToLower() == "cells")
            {
                Console.WriteLine("You are correct!");
                Console.ReadKey();
                TheEnd();
            }
            else
            {
                Console.WriteLine("Wrong answer...");
                Console.ReadKey();
                GameOver();
            }

            Console.ReadKey();
        }

        public void TheEnd()
        {
            Console.Clear();
            Console.WriteLine("GAME COMPLETE! We Are The Champions by Queen is playing in the background...........");

            for (int i = 10; i >= 0; i--)
            {
                Thread.Sleep(800);
                Console.WriteLine(i);
            }

            Environment.Exit(0);
        }

        public void Inspectation(Room room)
        {
            string result = string.Empty;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\t\tINSPECTATION\n");
                Console.WriteLine("Press 1. To inspect the room | Press 2. To inspect backpack | Press 3. To inspect player | Press 4. To continue the game");
                result = Console.ReadLine();
                Console.Clear();

                if (result == "1")
                {

                    room.Look();
                    Console.ReadKey();
                }
                else if (result == "2")
                {
                    Program.currentPlayer.InspectBackPack();
                    Console.ReadKey();
                }
                else if (result == "3")
                {
                    Program.currentPlayer.Look();
                    Console.ReadKey();
                }
                else if (result == "4")
                {
                    break;
                }

            }
        }
        public void InspectDoorRoom01()
        {
            Console.WriteLine($"It's a brown wooden door with some inscriptions: THE DOOR OFF HELL.");
        }

        public void InspectDoorRoom02()
        {
            Console.WriteLine($"It's a high and wide golden door with some inscriptions: THE DOOR OF FREEDOM.");
        }

        public void GameOver()
        {
            Console.WriteLine("You Are Dead. GAME OVER!");
            Environment.Exit(0);
        }

    }

}
