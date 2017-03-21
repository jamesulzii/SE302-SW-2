using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            DrawDisplay d = new DrawDisplay();
            d.DrawRoad();
        }
    }

    class Car
    {
        void move()
        {
            ConsoleKeyInfo keyInfo;
            while ((keyInfo = Console.ReadKey(true)).Key != ConsoleKey.Escape)
            {
                switch (keyInfo.Key)
                {
                    case ConsoleKey.RightArrow:
                        break;

                    case ConsoleKey.LeftArrow:
                        break;
                }
            }

        }
    }

    class Road
    {

    }

    class Problem
    { 
    }

    class Level
    {
    }

    class DrawDisplay
    {
        public void DrawRoad()
        {
            int k = 30;
            String[,] road = new String[k, 20];
            for (int i = 0; i < road.GetLength(0); i++)
            {
                for (int j = 0; j < road.GetLength(1); j++)
                    if (i == 0 || i == road.GetLength(0) - 1 || j == 0 || j == road.GetLength(1) - 1)
                    {
                        road[i, j] = "1";
                        Console.Write(road[i,j]);
                    }
                    else if (i == 28 && j == 9)
                    {
                        road[i, j] = "0";
                        Console.Write(road[i, j]);
                    }
                    else if (i == 28 && j == 10)
                    {
                        road[i, j] = "0";
                        Console.Write(road[i, j]);
                    }
                    else
                    {
                        road[i, j] = " ";
                        Console.Write(road[i,j]);
                    }
                Console.WriteLine();
            }
        }
    }
}
