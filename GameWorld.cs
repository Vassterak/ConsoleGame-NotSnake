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

        //Size of game world
        const int mapWidth = 30; //collums
        const int mapHeight = 24; //rows

        //Block ids
        const int ground = 0;
        const int point = 1;
        const int exit = 2;
        const int obstacle = 3;

        int[,] map;

        public GameWorld(int numberOfObstacles, int numberOfPoints) //setting up a world map
        {
            map = new int[mapWidth, mapHeight];

            for (int x = 0; x < mapWidth; x++) //setting up walls X cordinaties
            {
                map[x, 0] = obstacle;
                map[mapWidth - x, 0] = obstacle;
            }

            for (int x = 0; x < mapWidth; x++) //setting up walls Y cordinaties
            {
                map[x, 0] = obstacle;
                map[mapWidth - x, 0] = obstacle;
            }

            ActiveComponentPlacement(numberOfPoints, 1);
            ActiveComponentPlacement(numberOfObstacles, 3);
        }

        private void ActiveComponentPlacement(int numberOfComponents, int typeOfComponent)
        {
            bool finishedPlacing = false;
            int components = numberOfComponents;

            while (!finishedPlacing) //until all components are placed
            {
                //randomly generates new coordinates
                int randomX = rnd.Next(1, mapWidth);
                int randomY = rnd.Next(1, mapHeight);
                int ObstaclesAroundCom = 0; // number of obstacles around component, to collect component you need at least 2 way to get it. So if point will be surrounded with obstacles around it wont generate.

                //obstacle checking around component
                if (map[randomX, randomY] == ground)
                {
                    for (int x = randomX -1; x <=randomX + 1 ; x+=2)
                    {
                        if (map[x,randomY] != ground)
                        {
                            ObstaclesAroundCom++;
                        }
                    }

                    for (int y = randomY - 1; y <= randomY + 1; y += 2)
                    {
                        if (map[randomX, y] != ground)
                        {
                            ObstaclesAroundCom++;
                        }
                    }

                    if (ObstaclesAroundCom < 2)
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

        private void MapRender()
        {
            for (int x = 0; x < mapWidth; x++)
            {
                for (int y = 0; y < mapHeight; y++)
                {
                    if (map[x,y] == obstacle)
                    {
                        Console.SetCursorPosition(x, y);
                        Console.Write("#");
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
                        Console.SetCursorPosition(24, 23);
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("X");
                        Console.ResetColor();
                    }
                }
            }
        }


    }
}
