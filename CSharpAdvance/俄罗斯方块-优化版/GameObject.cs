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
    }

    /// <summary>
    /// 小方块类
    /// </summary>
    class GameObject:IPrint
    {
        public Position pos;
        
        //绘制小方块方法
        //
        public void Print()
        {
            Console.SetCursorPosition(pos.posX,pos.posY);
            Console.Write("■");
        }

        public GameObject(Position pos)
        {
            this.pos = pos;
        }
    }
}
