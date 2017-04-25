using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
         private static int screenWidth = 20;
        private static int screenHeight = 30;
        private static int livesCount = 3;
        private static int score = 0;
        private static int timerSpeed = 200;
        private static int speed = 0;
        private static List<Problem> problems = new List<Problem>();
        public static void Main(string[] args)
        {
            Console.BufferHeight = Console.WindowHeight = 31;
            Console.BufferWidth = Console.WindowWidth = 50;
            //Console.CursorVisible = false;
            //Console.SetBufferSize(50, 31);

            String title = "Console Application Car";
            Console.Title = title;
            while (!Console.KeyAvailable)
            {
                Console.BackgroundColor = ConsoleColor.Cyan;
                Console.Clear();
                Console.SetCursorPosition((Console.WindowWidth - title.Length) / 2, Console.WindowHeight / 2);
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write(title);
                Thread.Sleep(1500);

                Console.BackgroundColor = ConsoleColor.DarkCyan;
                Console.Clear();
                Console.SetCursorPosition((Console.WindowWidth - title.Length) / 2, Console.WindowHeight / 2);
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write(title);
                Thread.Sleep(1500);
            }
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Console.Clear();


            Console.BufferHeight = Console.WindowHeight = 31;
            Console.BufferWidth = Console.WindowWidth = 50;
            Console.CursorVisible = false;

            DrawDisplay d = new DrawDisplay();
            d.DrawRoad(screenHeight, screenWidth);

            Car car = new Car((screenWidth/2) - Car.WIDTH/2 ,screenHeight- Car.LENGTH);
            d.DrawCar(car);

            MoveGame(car);
        }
        public static void MoveGame(Car car)
        {
            DrawDisplay d = new DrawDisplay();
            Random rand = new Random();
            int newXCoordinat = 0;
            int q = 0;
            while (true)
            {
                int lvladd = 2000;
                int lvl = 1;
                if (score == lvladd && lvl< 4)
                {
                    d.DrawInformation(10, 4, "Level " + lvl, ConsoleColor.White);
                    lvl += 1;
                    timerSpeed -= 100;
                    lvladd += 2000;
                }
                score += 10;
                speed += 20;
                if (speed > 400)
                {
                    speed = 400;
                }
                bool suirel = false;
                {
                    if (q % 4 == 0)
                    {
                        newXCoordinat = rand.Next(1, screenWidth - 4);
                        Level l = new Level();
                        Problem proObj;
                        switch(lvl)
                        {
                            case 1:
                                proObj = l.levelOne(newXCoordinat);
                                problems.Add(proObj);
                                break;
                            case 2:
                                proObj = l.levelTwo(newXCoordinat);
                                problems.Add(proObj);
                                break;
                            case 3:
                                proObj = l.levelThree(newXCoordinat);
                                problems.Add(proObj);
                                break;
                            default:
                                break;
                        }
                    }
                }
                q++;
                while (Console.KeyAvailable)
                {
                    ConsoleKeyInfo pressedKey = Console.ReadKey();
                    switch (pressedKey.Key)
                    {
                        case ConsoleKey.RightArrow:
                            if (car.X < (screenWidth - 1) - Car.WIDTH)
                            {
                                car.Move(1, 0);
                            }
                            break;

                        case ConsoleKey.LeftArrow:
                            if (car.X > screenWidth - (screenWidth - 1))
                            {
                                car.Move(-1, 0);
                            }
                            break;
                    }
                }
                List<Problem> newList = new List<Problem>();
                for (int i = 0; i < problems.Count; i++)
                {
                    Problem oldProblem = problems[i];
                    Problem newproObj = new Problem(oldProblem.coordinatX, oldProblem.coordinatY + 1, oldProblem.color, oldProblem.problem);
                    for (int j = 0; j < newproObj.problem.Length; j++)
                    {
                        if ((newproObj.coordinatY == car.Y || newproObj.coordinatY == car.Y + 1 || newproObj.coordinatY == car.Y + 2) && (newproObj.coordinatX == car.X || newproObj.coordinatX == car.X + 1 || newproObj.coordinatX == car.X + 2 || newproObj.coordinatX == car.X + 3 || newproObj.coordinatX + 1 == car.X || newproObj.coordinatX + 1 == car.X + 1 || newproObj.coordinatX + 1 == car.X + 2 || newproObj.coordinatX + 1 == car.X + 3 || newproObj.coordinatX + 2 == car.X || newproObj.coordinatX + 2 == car.X + 1 || newproObj.coordinatX + 2 == car.X + 2 || newproObj.coordinatX + 2 == car.X + 3 || newproObj.coordinatX + 3 == car.X || newproObj.coordinatX + 3 == car.X + 1 || newproObj.coordinatX + 3 == car.X + 2 || newproObj.coordinatX + 3 == car.X + 3))
                        {
                            suirel = true;
                            speed = 0;
                            if (livesCount <= 0)
                            {
                                d.DrawInformation(23, 17, "GAME OVER", ConsoleColor.Red);
                                d.DrawInformation(23, 18, "Press [enter] to exit", ConsoleColor.Red);
                                d.DestroyDrawCar(car);
                                Console.ReadLine();
                                Environment.Exit(0);
                            }
                        }
                    }
                    if (newproObj.coordinatY < Console.WindowHeight)
                    {
                        newList.Add(newproObj);
                    }
                }
                problems = newList;
                d.ClearConsole(screenHeight,screenWidth);
                if (suirel)
                {
                    livesCount--;
                    problems.Clear();
                    d.DestroyDrawCar(car);
                }
                else
                {
                    d.DrawCar(car);
                }
                foreach (Problem pro in problems)
                {
                    d.DrawProblem(pro);
                }
                d.DrawInformation(23, 7, "Lives: " + livesCount, ConsoleColor.White);
                d.DrawInformation(23, 8, "Speed: " + speed, ConsoleColor.White);
                d.DrawInformation(23, 9, "Score: " + score, ConsoleColor.White);
                System.Threading.Thread.Sleep(timerSpeed);
            }
        }
    }

    class Car
    {
        public int X { get; set; } // x coordinat
        public int Y { get; set; } // y coordinat
        public static int LENGTH = 3; // mashinii urt
        public static int WIDTH = 4;// mashinii orgon

        public string[,] carbody = new string[,]
        {
            {"0"," "," ","0"},
            {" ","(",")"," "},
            {"0"," "," ","0"}
        };
        public string[,] carDestroyBody = new string[,]
        {
            {"X"," "," ","X"},
            {" ","X","X"," "},
            {"X"," "," ","X"}
        };
        public Car(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
        public void Move(int x, int y)
        {
            X += x;
            DrawDisplay d = new DrawDisplay();
            d.DrawCar(this);

            for (int i = 0; i < LENGTH; i++)
            {
                if (x == -1)
                    Console.SetCursorPosition(X + WIDTH, Y + i);
                else
                    Console.SetCursorPosition(X - 1, Y + i);
                Console.Write(" ");
            }
        }
    }

    class Road
    {
 public static string[,] roadarr;
    }

    class Problem
    { 
         public string[] problem { get; set; }
        public ConsoleColor color { get; set; }
        public int coordinatX { get; set; }
        public int coordinatY { get; set; }
        public Problem(int x,int y,ConsoleColor c,string[] p)
        {
            problem = p;
            color = c;
            coordinatX = x;
            coordinatY = y;
        }
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
