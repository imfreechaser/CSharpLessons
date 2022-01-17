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
                        instantPos.posX -= 2;
                        //边界控制
                        if (CheckTouchLRWall(instantPos.posX - bricks[0].pos.posX, true))
                        {
                            instantPos.posX += 2;
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        instantPos.posX += 2;
                        //边界控制
                        if (CheckTouchLRWall(instantPos.posX - bricks[0].pos.posX, false))
                        {
                            instantPos.posX -= 2;
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        dir++;
                        if (dir > 4)
                        {
                            dir = 1;
                        }
                        ChangeDirHoriModify();
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

        //平移边界控制
        //判断方块左右两侧和动态墙壁接触
        public bool CheckTouchLRWall(int deltaX, bool left)
        {
            Position p;
            for (int i = 0; i < bricks.Length; i++)
            {
                p = new Position(bricks[i].pos.posX + deltaX, bricks[i].pos.posY);
                if (left)
                {
                    if (p.posX <= 0)
                        return true;
                }
                if (!left)
                {
                    if (p.posX >= (Game.w / 2) * 2 - 2)
                        return true;
                }
                for (int j = 0; j < Map.dynMaplist.Count; j++)
                {
                    if (p == Map.dynMaplist[j].pos)
                        return true;
                }
            }
            return false;
        }

        //变方向边界控制
        //超出边界时横向位移修正
        public void ChangeDirHoriModify()
        {
            switch (brickShape)
            {
                case E_BrickShape.a:
                    break;
                case E_BrickShape.b:
                    switch (dir)
                    {
                        case 2:
                            if (instantPos.posX < 6)
                                instantPos.posX = 6;
                            break;
                        case 4:
                            break;
                        default:
                            break;
                    }
                    break;
                case E_BrickShape.c:
                    break;
                case E_BrickShape.d:
                    break;
                case E_BrickShape.e:
                    break;
                case E_BrickShape.f:
                    break;
                case E_BrickShape.g:
                    break;
                default:
                    break;
            }
        }

        public BrickManager()
        {
            bricks = new GameObject[4];
        }
    }
}
