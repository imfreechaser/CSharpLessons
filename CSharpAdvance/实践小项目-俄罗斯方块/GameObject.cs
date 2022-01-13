using System;
using System.Collections.Generic;
using System.Text;

namespace 实践小项目_俄罗斯方块
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
