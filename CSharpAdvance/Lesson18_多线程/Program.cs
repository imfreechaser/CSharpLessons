using System;
using System.Threading;

namespace Lesson18_多线程
{
    enum E_dir
    {
        Up,
        Down,
        Left,
        Right
    }
    class Program
    {
        static void Main(string[] args)
        {
            Box b = new Box(10, 0, E_dir.Down);
            Thread t = new Thread(Box.ChangeDir);
            t.IsBackground = true;

            Console.CursorVisible = false;
            b.SetColor();
            b.Print();
            t.Start();

            while (true)
            {
                b.Clear();
                b.Move();
                b.Print();
                Thread.Sleep(500);
            }
        }
    }
    class Box
    {
        //位置
        public int x,  y;
        //当前方向
        static E_dir myDir;
        //绘制
        public void Print()
        {
            Console.SetCursorPosition(x, y);
            Console.Write("■");
        }
        //移动
        public void Move()
        {
            switch (myDir)
            {
                case E_dir.Up:
                    y--;
                    break;
                case E_dir.Down:
                    y++;
                    break;
                case E_dir.Left:
                    x -= 2;
                    break;
                case E_dir.Right:
                    x += 2;
                    break;
                default:
                    break;
            }
        }
        //设置颜色
        public void SetColor()
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }
        //改变方向
        public static void ChangeDir()
        {
            while (true)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.UpArrow:
                    case ConsoleKey.W:
                        myDir = E_dir.Up;
                        break;
                    case ConsoleKey.DownArrow:
                    case ConsoleKey.S:
                        myDir = E_dir.Down;
                        break;
                    case ConsoleKey.LeftArrow:
                    case ConsoleKey.A:
                        myDir = E_dir.Left;
                        break;
                    case ConsoleKey.D:
                    case ConsoleKey.RightArrow:
                        myDir = E_dir.Right;
                        break;
                    default:
                        break;
                }
            }
        }
        //擦除
        public void Clear()
        {
            Console.SetCursorPosition(x, y);
            Console.Write("  ");
        }

        public Box(int x ,int y, E_dir dir)
        {
            this.x = x;
            this.y = y;
            myDir = dir;
        }
    }
}
