using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console2DGame
{
    class MainMenu
    {
        public static int ShowMainMenu()
        {
            int selectedItem = 0;
            bool selectionFinished = false;
            ConsoleKeyInfo PressedKey;

            string[] itemsOfList = new string[4];
            itemsOfList[0] = "New Game";
            itemsOfList[1] = "How to play";
            itemsOfList[2] = "Select difficulty";
            itemsOfList[3] = "End";

            Console.Clear();

            while (!selectionFinished)
            {
                Console.SetCursorPosition(0, 3);

                for (int i = 0; i < itemsOfList.Length; i++)
                {
                    if (selectedItem == i)
                        Console.BackgroundColor = ConsoleColor.Blue;

                    Console.WriteLine(itemsOfList[i]);
                    Console.ResetColor();
                }

                PressedKey = Console.ReadKey(true); //when true => character wont show in console

                if (PressedKey.Key == ConsoleKey.DownArrow && selectedItem < itemsOfList.Length -1)
                    selectedItem++;

                else if (PressedKey.Key == ConsoleKey.UpArrow && selectedItem > 0)
                    selectedItem--;

                else if (PressedKey.Key == ConsoleKey.Enter)
                    selectionFinished = true;
            }
            return selectedItem;
        }

        public static void Instructions()
        {
            Console.WriteLine("Use arrows on keyboad to move around.");
            Console.WriteLine("Goal of this game is to take all green points and get to the door.");
            Console.WriteLine("But you need to be careful because you can't step twice onto the same place.\n");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("0");
            Console.ResetColor();
            Console.Write(" is point, you have to pick up all of them\n");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("X");
            Console.ResetColor();
            Console.Write(" is Exit, after you picked up all points you have to get here. It's a finish\n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nPress any key to continue.");
            Console.ResetColor();
        }

        public static (int, int) Difficulty()
        {
            int points, obstacles;
            Console.Write("\nSelect number of point between numbers 1 - 30: ");

            while (!int.TryParse(Console.ReadLine(), out points))
                Console.WriteLine("Invalid input!");

            if (points > 30 || points < 1)
                points = 30;

            Console.Write("\nSelect number of added obstacles between numbers 1 - 120: ");

            while (!int.TryParse(Console.ReadLine(), out obstacles))
                Console.WriteLine("Invalid nput!");

            if (obstacles > 120 || obstacles < 1)
                obstacles = 120;

            return (obstacles, points);
        }
    }
}
