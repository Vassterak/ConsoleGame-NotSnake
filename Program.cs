using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console2DGame
{
    enum GameState
    {
        InProgress, Win, Defeat, End
    }

    class Program
    {
        const int newGame = 0;
        const int howToPlay = 1;
        const int difficulty = 2;
        const int end = 3;

        static void Main(string[] args)
        {
            int numOfPoints = 5, numOfObstacles = 25;
            bool gameContinues = true;

            while (gameContinues)
            {
                int result = MainMenu.ShowMainMenu();

                switch (result)
                {
                    case newGame:
                        Console.Clear();
                        GameWorld gameWorld = new GameWorld(numOfObstacles, numOfPoints);
                        while (gameWorld.gameState == GameState.InProgress)
                        {
                            gameWorld.Movement();
                            gameWorld.PlayerUpdate();
                        }

                        switch (gameWorld.gameState)
                        {
                            case GameState.End:
                                break;

                            case GameState.Win:
                                Console.Clear();
                                Console.WriteLine("You won!");
                                break;

                            case GameState.Defeat:
                                Console.Clear();
                                Console.WriteLine("You lost!");
                                break;
                        }
                        Console.ReadKey();

                        break;

                    case howToPlay:
                        Console.Clear();
                        MainMenu.Instructions();
                        Console.ReadKey(true);
                        break;

                    case difficulty:
                        Console.Clear();
                        var output = MainMenu.Difficulty();
                        numOfObstacles = output.Item1;
                        numOfPoints = output.Item2;
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
