using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console2DGame
{
    class MainMenu
    {
        public int ShowMainMenu()
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
                        Console.BackgroundColor = ConsoleColor.Black;

                    Console.WriteLine(itemsOfList[i]);
                    Console.ResetColor();
                }

                PressedKey = Console.ReadKey(true); //when true => character wont show in console

                if (PressedKey.Key == ConsoleKey.DownArrow && selectedItem > 2 )
                    selectedItem++;
                else if (PressedKey.Key == ConsoleKey.UpArrow && selectedItem < 0 )
                    selectedItem--;
            }

            return selectedItem;
        }
    }
}
