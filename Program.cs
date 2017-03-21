using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeProject
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    public class Snake
    {
     
        private int LEFT = 1, RIGHT = 2; //togtmoliig ihewchlen tomoor bichne
        private Point[] body;
        private int len {get;set;}
      /*  public int Len
        {
            get
            {
                return this.len;
            }
            set
            {
                this.len = value;
            }
        }*/
        public Snake()
        {
            Point head = new Point(10, 10);
        }

        public void go(int direction = 0)
        {
            turn(direction);
        }


        public void die()
        {
            for (int i = 0; i < Level.HEIGHT; i++)
            {
                for (int j = 0; j < Level.WIDTH; j++)
                {
                    if (i == 0 && body[0].Y != i || i == Level.HEIGHT - 1 && body[0].Y != i || j == 0 && body[0].X != i || j == Level.WIDTH - 1 && body[0].X != i)
                    {
                    }
                }
            }
        }

        public void eat(Food food)
        {

        }

        private void grow()
        {
        }

        private void turn(int direction)
        {

        }
    }

    public class Food
    {
        
    }

    public class Level
    {
        public static int HEIGHT = 25, WIDTH = 80;
        public static int speed = 300;
        public static int[,] map = new int[HEIGHT, WIDTH];
        public Level()
        {
            
        }

        private void level1()
        {
            for (int i = 0; i < HEIGHT; i++)
            {
                for (int j = 0; j < WIDTH; j++)
                {
                    if (i == 0 || i == HEIGHT - 1 || j == 0 || j == WIDTH - 1)
                    {
                        map[i, j] = 1; // hana
                    }
                    else
                        map[i, j] = 0; // hooson talbai
                }
            }
            speed = 300;
        }
        private void level2()
        {
            level1();
            speed = 250;
            //nemj hana zurj bolno
        }
    }

    public class Display
    {
        public void drawSnake(Snake snake)
        {

        }
    }
    public class Point
    {
        public int X,Y;
        public Point(int x,int y)
        {
            this.X = x;
            this.Y = y;
        }

    }
    public class Game
    {
        public Game()
        {
        }
        public void Start()
        { }
        public void Resume()
        { }
        public void Pause()
        { }
        public void End()
        {}
    }
}
