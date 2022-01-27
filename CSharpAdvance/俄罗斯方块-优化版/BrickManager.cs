using System;
using System.Collections.Generic;
using System.Text;

namespace 俄罗斯方块_优化版
{
    class BrickManager : IPrint
    {
        //当前方块形状
        //
        E_BrickShape brickShape;

        //方块信息
        //
        BrickInfo brickInfo;

        //方块信息字典
        //
        Dictionary<E_BrickShape, BrickInfo> brickDic;

        //方块集合
        //
        GameObject[] bricks;

        //当前方向id
        //
        int dir;

        //随机创建方块方法
        //
        public void ProduceBrick()
        {
            //随机决定形状
            Random r = new Random();
            brickShape = (E_BrickShape)r.Next(0,7);

            //提取方块信息对象
            brickInfo = brickDic[brickShape];

            //随机决定方向
            dir = r.Next(0, brickInfo.BrickListCount);

            //重置位置信息
            bricks[0] = new GameObject(new Position(Game.w / 2, -4), brickShape);

            //提取方块位置信息
            for (int i = 1; i < bricks.Length; i++)
            {
                bricks[i] = new GameObject(bricks[0].pos + brickInfo[dir][i - 1], brickShape);
            }
            Print();
        }

        //擦除上一帧砖块痕迹
        //
        public void ClearLastFrame()
        {
            for (int i = 0; i < bricks.Length; i++)
            {
                if(bricks[i].pos.posY >= 0)
                {
                    Console.SetCursorPosition(bricks[i].pos.posX, bricks[i].pos.posY);
                    Console.Write("  ");
                }
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

        //平移方块
        //
        public void HoriMove(bool left)
        {
            Position deltaP;
            if (left)
                deltaP = new Position(-2, 0);
            else
                deltaP = new Position(2, 0);

            ClearLastFrame();

            for (int i = 0; i < bricks.Length; i++)
            {
                bricks[i].pos += deltaP;
            }
            Print();
        }

        //是否可平移判断
        //
        public bool CanHoriMove(bool left, Map map)
        {
            Position p;
            if (left)
            {
                //左侧固定墙壁判断
                for (int i = 0; i < bricks.Length; i++)
                {
                    p = bricks[i].pos + new Position(-2, 0);
                    if (p.posX < 2)
                        return false;
                }

                //左侧动态墙壁判断
                for (int i = 0; i < bricks.Length; i++)
                {
                    p = bricks[i].pos + new Position(-2, 0);
                    for (int j = 0; j < map.dynMaplist.Count; j++)
                    {
                        if (p == map.dynMaplist[j].pos)
                            return false;
                    }
                }
            }
            if (!left)
            {
                //右侧固定墙壁判断
                for (int i = 0; i < bricks.Length; i++)
                {
                    p = bricks[i].pos + new Position(2, 0);
                    if (p.posX >= Game.w / 2 * 2 - 2)
                        return false;
                }

                //右侧动态墙壁判断
                for (int i = 0; i < bricks.Length; i++)
                {
                    p = bricks[i].pos + new Position(2, 0);
                    for (int j = 0; j < map.dynMaplist.Count; j++)
                    {
                        if (p == map.dynMaplist[j].pos)
                            return false;
                    }
                }
            }
            
            return true;
        }
        
        //变方向方法
        //
        public void ChangeDir(bool left)
        {
            //修改方向索引
            if (left)
            {
                dir--;
                if (dir < 0)
                    dir = brickInfo.BrickListCount - 1;
            }
            if (!left)
            {
                dir++;
                if (dir > brickInfo.BrickListCount - 1)
                    dir = 0;
            }

            //擦除上一帧痕迹
            ClearLastFrame();

            //提取新方向的位置信息
            for (int i = 1; i < bricks.Length; i++)
            {
                bricks[i].pos = bricks[0].pos + brickInfo[dir][i - 1];
            }

            Print();
        }

        //是否可变形判断
        //
        public bool CanChangeDir(bool left, Map map)
        {
            Position p;
            int dirTemp = dir;

            if (left)
            {
                dirTemp--;
                if (dirTemp < 0)
                    dirTemp = brickInfo.BrickListCount - 1;
            }
            if (!left)
            {
                dirTemp++;
                if (dirTemp > brickInfo.BrickListCount - 1)
                    dirTemp = 0;
            }

            //固定墙壁判断
            for (int i = 1; i < bricks.Length; i++)
            {
                p = bricks[0].pos + brickInfo[dirTemp][i - 1];
                if (p.posX < 2 || p.posX >= Game.w / 2 * 2 - 2)
                    return false;
            }
            //动态墙壁判断
            for (int i = 1; i < bricks.Length; i++)
            {
                p = bricks[0].pos + brickInfo[dirTemp][i - 1];
                for (int j = 0; j < map.dynMaplist.Count; j++)
                {
                    if (p == map.dynMaplist[j].pos)
                        return false;
                }
            }
            return true;
        }

        //砖块下落方法
        //
        public void MoveDown()
        {
            ClearLastFrame();

            for (int i = 0; i < bricks.Length; i++)
            {
                bricks[i].pos += new Position(0, 1); ;
            }

            Print();
        }

        //判断是否能下落
        //
        public bool CanMoveDown(Map map)
        {
            Position p;
            //固定墙壁底边判断
            for (int i = 0; i < bricks.Length; i++)
            {
                p = bricks[i].pos + new Position(0, 1);
                if (p.posY == Game.h - 5)
                {
                    map.AddDynWall(bricks);

                    ProduceBrick();

                    return false;
                }
            }
            //动态墙壁边界判断
            for (int i = 0; i < bricks.Length; i++)
            {
                p = bricks[i].pos + new Position(0, 1);
                for (int j = 0; j < map.dynMaplist.Count; j++)
                {
                    if (p == map.dynMaplist[j].pos)
                    {
                        map.AddDynWall(bricks);

                        ProduceBrick();

                        return false;
                    }
                }
            }
            return true;
        }

        public BrickManager()
        {
            //初始化方块字典
            //把每种方块对象的形状记录起来，提前存在字典里，这样就不用每次创建新方块时都要创建该方块信息对象，节省内存
            brickDic = new Dictionary<E_BrickShape, BrickInfo>() 
            {
                {E_BrickShape.a, new BrickInfo(E_BrickShape.a)},
                {E_BrickShape.b, new BrickInfo(E_BrickShape.b)},
                {E_BrickShape.c, new BrickInfo(E_BrickShape.c)},
                {E_BrickShape.d, new BrickInfo(E_BrickShape.d)},
                {E_BrickShape.e, new BrickInfo(E_BrickShape.e)},
                {E_BrickShape.f, new BrickInfo(E_BrickShape.f)},
                {E_BrickShape.g, new BrickInfo(E_BrickShape.g)}
            };

            brickShape = E_BrickShape.wall;

            //给每个小方块一个默认位置
            bricks = new GameObject[4]
            {
                new GameObject(new Position(Game.w / 2, 2), brickShape),
                new GameObject(new Position(Game.w / 2, 2), brickShape),
                new GameObject(new Position(Game.w / 2, 2), brickShape),
                new GameObject(new Position(Game.w / 2, 2), brickShape)
            };
        }
    }
}
