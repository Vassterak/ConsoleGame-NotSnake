using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console2DGame
{
    class GameWorld
    {
        Random rnd = new Random();
        public GameState gameState = GameState.InProgress;

        //Size of game world
        int[,] map;
        private const int mapWidth = 30; //collums
        private const int mapHeight = 24; //rows

        //Block ids
        private const int ground = 0;
        private const int point = 1;
        private const int exit = 2;
        private const int obstacle = 3;

        //Player
        private int x = 1, y = 1;
        private int LastX = 1, LastY = 1;
        private int numberOfPoints = 0;

        public int X
        {
            get { return x; }

            set
            {
                if (value >= 1 && value < mapWidth - 1)
                {
                    if (map[value, y] == obstacle) //cannot move if there is an obstacle
                        return;

                    map[x, y] = obstacle; //if there is not an obstacle then you can set the position tu obstacle
                    x = value; //set x the new value
                }
            }
        }

        public int Y
        {
            get { return y; }

            set
            {
                if (value >= 1 && value < mapHeight - 1)
                {
                    if (map[x, value] == obstacle) //cannot move if there is an obstacle
                        return;

                    map[x, y] = obstacle; //if there is not an obstacle then you can set the position tu obstacle
                    y = value; //set x the new value
                }
            }
        }

        public GameWorld(int numberOfObstacles, int numberOfPoints) //setting up a world map
        {
            this.numberOfPoints = numberOfPoints;
            map = new int[mapWidth, mapHeight];

            for (int x = 0; x < mapWidth; x++) //setting up walls X cordinaties
            {
                map[x, 0] = obstacle;
                map[x, mapHeight-1] = obstacle;
            }

            for (int y = 0; y < mapHeight; y++) //setting up walls Y cordinaties
            {
                map[0, y] = obstacle;
                map[mapWidth-1, y] = obstacle;
            }

            ActiveComponentPlacement(numberOfObstacles, 3);
            ActiveComponentPlacement(numberOfPoints, 1);
            ActiveComponentPlacement(1, 2); //exit door
            MapRender();
        }

        private void ActiveComponentPlacement(int numberOfComponents, int typeOfComponent)
        {
            bool finishedPlacing = false;
            int components = numberOfComponents;

            while (!finishedPlacing) //until all components are placed
            {
                //randomly generates new coordinates
                int randomX = rnd.Next(2, mapWidth);
                int randomY = rnd.Next(2, mapHeight);
                int ObstaclesAroundCom = 0; // number of obstacles around component, to collect component you need at least 2 way to get it. So if point will be surrounded with obstacles around it wont generate.

                //obstacle checking around component
                if (map[randomX, randomY] == ground)
                {
                    for (int x = randomX -1; x <=randomX + 1 ; x+=2)
                    {
                        if (map[x,randomY] != ground)
                            ObstaclesAroundCom++;
                    }

                    for (int y = randomY - 1; y <= randomY + 1; y += 2)
                    {
                        if (map[randomX, y] != ground)
                            ObstaclesAroundCom++;
                    }

                    if (ObstaclesAroundCom > 2)
                        continue;

                    else
                    {
                        map[randomX, randomY] = typeOfComponent;
                        components--;
                    }
                }

                if (components == 0)
                    finishedPlacing = true;
            }
        }

        public void Movement()
        {
            ConsoleKeyInfo pressedKey = Console.ReadKey(true);

            switch (pressedKey.Key)
            {
                case ConsoleKey.DownArrow:
                    Y++;
                    break;

                case ConsoleKey.UpArrow:
                    Y--;
                    break;

                case ConsoleKey.LeftArrow:
                    X--;
                    break;

                case ConsoleKey.RightArrow:
                    X++;
                    break;

                case ConsoleKey.Escape:
                    gameState = GameState.End;
                    break;
            }

            GameInfoUpdate();
        }

        private void GameInfoUpdate() //how many points are left
        {
            if (map[x,y] == point)
            {
                map[x, y] = 0;
                numberOfPoints--;
            }
            else if (map[x, y] == exit && numberOfPoints == 0)
            {
                gameState = GameState.Win;
            }

            if (map[x - 1, y] == obstacle && map[x + 1, y] == obstacle && map[x, y - 1] == obstacle && map[x, y + 1] == obstacle)
                gameState = GameState.Defeat;

            Console.SetCursorPosition(0, mapHeight + 1);

            if (numberOfPoints == 0)
                Console.WriteLine("Find exit to win the game!");

            else
                Console.WriteLine($"Points to go: {numberOfPoints} ");

            Console.WriteLine("Pres ESC to leave the game and enter the menu.");
        }

        public void PlayerUpdate()
        {
            Console.SetCursorPosition(LastX, LastY);
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write(" ");

            Console.SetCursorPosition(x, y);
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write(" ");
            Console.ResetColor();

            LastX = x;
            LastY = y;
        }

        private void MapRender()
        {
            for (int x = 0; x < mapWidth; x++)
            {
                for (int y = 0; y < mapHeight; y++)
                {
                    if (map[x,y] == obstacle)
                    {
                        Console.SetCursorPosition(x, y);
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                        Console.Write(" ");
                        Console.ResetColor();
                    }
                    else if (map[x,y] == point)
                    {
                        Console.SetCursorPosition(x, y);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("o");
                        Console.ResetColor();
                    }
                    else if (map[x,y] == exit)
                    {
                        Console.SetCursorPosition(x, y);
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("X");
                        Console.ResetColor();
                    }
                }
            }
        }


    }
}
