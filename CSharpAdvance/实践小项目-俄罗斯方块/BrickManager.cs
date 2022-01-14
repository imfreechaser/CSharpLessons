using System;
using System.Collections.Generic;
using System.Text;

namespace 实践小项目_俄罗斯方块
{
    class BrickManager : IPrint
    {
        //当前方块形状
        //
        public E_BrickShape brickShape;

        //方块当前位置
        //
        Position instantPos;

        //方块信息
        //
        BrickInfo brickInfo;

        //方块集合
        //
        public GameObject[] bricks;

        //当前方向id
        //
        int dir;

        //随机创建方块方法
        //
        public void ProduceBrick()
        {
            //随机决定形状、方向
            Random r = new Random();
            brickShape = (E_BrickShape)r.Next(0,7);
            dir = r.Next(1,5);

            //重置位置信息
            instantPos = new Position(Game.w / 2, 2);

            //创建方块信息对象
            brickInfo = new BrickInfo(brickShape,dir, instantPos);

            //获取方块信息，创建方块并打印
            for (int i = 0; i < bricks.Length; i++)
            {
                bricks[i] = new GameObject(brickInfo.positions[i]);
            }
            Print();
        }

        //擦除上一帧砖块痕迹
        //
        public void ClearLastFrame()
        {
            for (int i = 0; i < bricks.Length; i++)
            {
                Console.SetCursorPosition(bricks[i].pos.posX, bricks[i].pos.posY);
                Console.Write("  ");
            }
        }

        //砖块下落方法
        //
        public void MoveDown()
        { 
            //改变原点方块的位置
            instantPos.posY = bricks[0].pos.posY + 1; 

            //改变方块信息
            brickInfo.Move(brickShape,dir, instantPos);

            //更新方块信息，创建方块并打印
            for (int i = 0; i < bricks.Length; i++)
            {
                bricks[i].pos = brickInfo.positions[i];
            }
        }

        //绘制方块
        //
        public void Print()
        {
            for (int i = 0; i < bricks.Length; i++)
            {
                bricks[i].Print();
            }
        }

        //用户输入方法
        //包括横向移动、切换方向、加速下落
        public void UserInput()
        {
            while (true)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.LeftArrow:
                        if(brickInfo.leftPosX > 2 && !TouchLDynWall())
                        {
                            instantPos.posX -= 2;
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if((brickInfo.rightPosX < (Game.w / 2) * 2 - 4) && !TouchRDynWall())
                        {
                            instantPos.posX += 2;
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        dir++;
                        if (dir > 4)
                        {
                            dir = 1;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        GameScene.sleepTime = 100;
                        break;
                    default:
                        break;
                }
            }
        }

        //判断方块触底
        //
        public bool TouchBotWall()
        {
            //固定墙壁判断
            if ((Game.h - 5) - brickInfo.bottomposY <= 1)
            {
                return true;
            }
            //动态墙壁判断
            Position p;
            for (int i = 0; i < bricks.Length; i++)
            {
                p = new Position(bricks[i].pos.posX, bricks[i].pos.posY + 1);
                for (int j = 0; j < Map.dynMaplist.Count; j++)
                {
                    if (p == Map.dynMaplist[j].pos)
                        return true;
                }
            }
            return false;
        }

        //判断方块左侧和动态墙壁接触
        //
        public bool TouchLDynWall()
        {
            Position pL;
            for (int i = 0; i < bricks.Length; i++)
            {
                pL = new Position(bricks[i].pos.posX - 2, bricks[i].pos.posY);
                for (int j = 0; j < Map.dynMaplist.Count; j++)
                {
                    if (pL == Map.dynMaplist[j].pos)
                        return true;
                }
            }
            return false;
        }

        //判断方块右侧和动态墙壁接触
        //
        public bool TouchRDynWall()
        {
            Position pR;
            for (int i = 0; i < bricks.Length; i++)
            {
                pR = new Position(bricks[i].pos.posX + 2, bricks[i].pos.posY);
                for (int j = 0; j < Map.dynMaplist.Count; j++)
                {
                    if (pR == Map.dynMaplist[j].pos)
                        return true;
                }
            }
            return false;
        }

        public BrickManager()
        {
            bricks = new GameObject[4];
        }
    }
}
