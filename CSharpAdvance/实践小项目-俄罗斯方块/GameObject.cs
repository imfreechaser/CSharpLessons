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
        public int PosY;

        public Position(int x, int y)
        {
            posX = x;
            PosY = y;
        }
    }

    /// <summary>
    /// 小方块类
    /// </summary>
    class GameObject
    {
        public Position pos;
        string basicShape = "■";
        
        //绘制小方块方法
        //
        public void Print()
        {
            Console.SetCursorPosition(pos.posX,pos.PosY);
            Console.Write(basicShape);
        }

        public GameObject(int x,int y)
        {
            pos = new Position(x,y);
        }
    }
}
