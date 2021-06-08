using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console2DGame
{
    class Program
    {
        const int newGame = 0;
        const int howToPlay = 1;
        const int end = 2;

        static void Main(string[] args)
        {
            bool gameContinues = true;

            while (gameContinues)
            {
                int result = MainMenu.ShowMainMenu();

                switch (result)
                {
                    case newGame:

                        break;
                    case howToPlay:
                        Console.Clear();
                        MainMenu.Instructions();
                        Console.ReadKey(true);
                        break;
                    case end:
                        gameContinues = false;
                        break;

                    default:
                        break;
                }

            }
        }
    }
}
