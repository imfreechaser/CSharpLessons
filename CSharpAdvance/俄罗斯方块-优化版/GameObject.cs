using System;
using System.Collections.Generic;
using System.Text;

namespace 俄罗斯方块_优化版
{
    /// <summary>
    /// 位置结构体
    /// </summary>
    struct Position
    {
        public int posX;
        public int posY;

        public Position(int x, int y)
        {
            posX = x;
            posY = y;
        }

        //判断位置是否相等运算符重载
        //
        public static bool operator == (Position p1, Position p2)
        {
            if (p1.posX == p2.posX && p1.posY == p2.posY)
                return true;
            return false;
        }
        public static bool operator != (Position p1, Position p2)
        {
            if (p1.posX == p2.posX && p1.posY == p2.posY)
                return false;
            return true;
        }

        //位置相加运算符重载
        //
        public static Position operator +(Position p1, Position p2)
        {
            Position p;
            p.posX = p1.posX + p2.posX;
            p.posY = p1.posY + p2.posY;
            return p;
        }
    }

    /// <summary>
    /// 小方块类
    /// </summary>
    class GameObject:IPrint
    {
        public Position pos;
        E_BrickShape shape;

        //绘制小方块方法
        //
        public void Print()
        {
            if(pos.posY >= 0)
            {
                switch (shape)
                {
                    case E_BrickShape.a:
                        Console.ForegroundColor = ConsoleColor.Gray;
                        break;
                    case E_BrickShape.b:
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        break;
                    case E_BrickShape.c:
                        Console.ForegroundColor = ConsoleColor.Blue;
                        break;
                    case E_BrickShape.d:
                        Console.ForegroundColor = ConsoleColor.Green;
                        break;
                    case E_BrickShape.e:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        break;
                    case E_BrickShape.f:
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        break;
                    case E_BrickShape.g:
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case E_BrickShape.wall:
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;
                    case E_BrickShape.dynWall:
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        break;
                    default:
                        break;

                }
                Console.SetCursorPosition(pos.posX, pos.posY);
                Console.Write("■");
            } 
        }

        //类型切换方法
        //
        public void SwitchShape(E_BrickShape shape)
        {
            this.shape = shape;
        }

        public GameObject(Position pos,E_BrickShape shape)
        {
            this.pos = pos;
            this.shape = shape;
        }
    }
}
