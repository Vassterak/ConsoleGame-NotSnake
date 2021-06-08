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

            string[] itemsOfList = new string[3];
            itemsOfList[0] = "New Game";
            itemsOfList[1] = "How to play";
            itemsOfList[2] = "End";

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

                if (PressedKey.Key == ConsoleKey.DownArrow && selectedItem < 2)
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
            Console.WriteLine("But you need to be careful because you can't return your steps.");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Press any key to continue.");
            Console.ResetColor();
        }
    }
}
