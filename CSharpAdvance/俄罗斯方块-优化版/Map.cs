using System;
using System.Collections.Generic;
using System.Text;

namespace 俄罗斯方块_优化版
{
    class Map
    {
        //地图数据集合
        //
        List<GameObject> fixedMaplist;
        public List<GameObject> dynMaplist;

        //动态墙壁每行方块数数组
        //
        int[] amtEvyRow = new int[Game.h - 5];

        //当前分数
        //
        public static int InstantScore{ get; private set;}

        //绘制固定墙壁方法
        //
        void PrintFixedWall()
        {
            //添加纵向的固定墙壁
            for (int i = 0; i < Game.h - 5; i++)
            {
                fixedMaplist.Add(new GameObject(new Position(0, i), E_BrickShape.wall));
                fixedMaplist.Add(new GameObject(new Position((Game.w / 2) * 2 - 2, i), E_BrickShape.wall));
            }

            //添加底部横向固定墙壁
            for (int i = 0; i < (Game.w / 2) * 2; i += 2)
            {
                fixedMaplist.Add(new GameObject(new Position(i, Game.h - 5), E_BrickShape.wall));
            }

            //打印固定墙壁
            foreach (GameObject item in fixedMaplist)
            {
                item.Print();
            }
        }

        //绘制动态墙壁方法
        //
        public void AddDynWall(GameObject[] gameObjects)
        {
            //改变动态墙壁颜色
            Console.ForegroundColor = ConsoleColor.Cyan;

            //添加小方块到动态墙壁地图中
            dynMaplist.AddRange(gameObjects);

            //打印动态添加的小方块,更新动态墙壁的最高行位置
            foreach (GameObject item in dynMaplist)
            {
                item.SwitchShape(E_BrickShape.dynWall);
                item.Print();
            }

            //针对这次添加进来的方块，更新行数量数组
            for (int i = 0; i < gameObjects.Length; i++)
            {
                if(gameObjects[i].pos.posY >= 0)
                {
                    amtEvyRow[Game.h - 6 - gameObjects[i].pos.posY]++;
                }
            }

            //检查是否能消除
            CheckWhetherRemoveHoriWall();

            //死亡判断
            CheckIsDead();
        }

        //判断是否移除整层动态墙壁
        //
        void CheckWhetherRemoveHoriWall()
        {
            if (dynMaplist != null)
            {
                //查看每行是否铺满
                for (int i = 0; i < amtEvyRow.Length; i++)
                {
                    //如果该行铺满
                    if (amtEvyRow[i] == Game.w / 2 - 2)
                    {
                        //清除该行
                        for (int j = 0; j < dynMaplist.Count; j++)
                        {
                            if (dynMaplist[j].pos.posY == Game.h - 6 - i)
                            {
                                Console.SetCursorPosition(dynMaplist[j].pos.posX, dynMaplist[j].pos.posY);
                                Console.Write("  ");

                                dynMaplist.Remove(dynMaplist[j]);
                                j--;
                            }
                        }

                        //该行上方的墙壁全部擦除
                        for (int j = 0; j < dynMaplist.Count; j++)
                        {
                            if (dynMaplist[j].pos.posY < Game.h - 6 - i)
                            {
                                Console.SetCursorPosition(dynMaplist[j].pos.posX, dynMaplist[j].pos.posY);
                                Console.Write("  ");
                            }
                        }

                        //该行上方的墙壁全部下移一行
                        for (int j = 0; j < dynMaplist.Count; j++)
                        {
                            if (dynMaplist[j].pos.posY < Game.h - 6 - i)
                            {
                                dynMaplist[j].pos.posY++;
                                dynMaplist[j].Print();
                            }
                        }   

                        //每行方块计数数组的值往前推一位
                        for (int j = i; j < amtEvyRow.Length - 1; j++)
                        {
                            amtEvyRow[j] = amtEvyRow[j + 1];
                        }
                        amtEvyRow[amtEvyRow.Length - 1] = 0;

                        //计分
                        InstantScore += 10;
                        PrintScore();

                        //下一次循环索引保持不变
                        //i--;
                        CheckWhetherRemoveHoriWall();
                        break;
                    }
                }         
            }
        }

        //打印分数方法
        //
        public void PrintScore()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(Game.w / 2 - 5, Game.h - 1);
            Console.Write("                           ");
            Console.SetCursorPosition(Game.w / 2 - 5, Game.h - 1);
            Console.Write($"当前分数：{InstantScore}");
        }

        //打印操作提示
        //
        void PrintHint()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(1, Game.h - 4);
            Console.Write("键盘← →键平移方块，↓加速方块下落");
            Console.SetCursorPosition(1, Game.h - 3);
            Console.Write("A/D键旋转方块方向，Esc键结束游戏");
        }

        //死亡判断
        //
        public void CheckIsDead()
        {
            if (amtEvyRow[Game.h - 6] > 0)
            {
                GameScene.Dead = true;
                //End.finalScore = instantScore;
            }
        }

        public Map()
        {
            Console.ForegroundColor = ConsoleColor.Red;

            fixedMaplist = new List<GameObject>();
            dynMaplist = new List<GameObject>();

            PrintFixedWall();

            //重置分数
            InstantScore = 0;

            //打印操作提示
            PrintHint();
        }
    }
}
