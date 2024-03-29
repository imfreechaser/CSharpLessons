﻿using System;
using System.Collections.Generic;
using System.Text;

namespace 实践小项目_俄罗斯方块
{
    class Map
    {
        //地图数据集合
        //
        public static List<GameObject> fixedMaplist;
        public static List<GameObject> dynMaplist;

        //动态墙壁最高行
        //
        int topPosY;

        //绘制固定墙壁方法
        //
        public void PrintFixedWall()
        {
            //添加纵向的固定墙壁
            for (int i = 0; i < Game.h - 5; i++)
            {
                fixedMaplist.Add(new GameObject(new Position(0, i)));
                fixedMaplist.Add(new GameObject(new Position((Game.w / 2) * 2 - 2, i)));
            }

            //添加底部横向固定墙壁
            for (int i = 0; i < (Game.w / 2) * 2; i += 2)
            {
                fixedMaplist.Add(new GameObject(new Position(i, Game.h - 5)));
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
                item.Print();
                if(item.pos.posY < topPosY)
                {
                    topPosY = item.pos.posY;
                }
            }
        }

        //判断是否移除整层动态墙壁
        //
        public void CheckWhetherRemoveHoriWall()
        {
            if (dynMaplist != null)
            {
                //添加检查索引，从topPosY检查到Game.h - 6，查看每行是否铺满
                int indexY = topPosY;
                while(indexY <= Game.h - 6)
                {
                    int horiBrickAmt = 0;
                    for (int i = 0; i < dynMaplist.Count; i++)
                    {
                        if (dynMaplist[i].pos.posY == indexY)
                            horiBrickAmt++;
                    }
                    //如果该行铺满
                    if (horiBrickAmt == Game.w / 2 - 2)
                    {
                        //清除该行
                        for (int i = 0; i < dynMaplist.Count; i++)
                        {
                            if (dynMaplist[i].pos.posY == indexY)
                            {
                                Console.SetCursorPosition(dynMaplist[i].pos.posX, dynMaplist[i].pos.posY);
                                Console.Write("  ");

                                dynMaplist.Remove(dynMaplist[i]);
                                i--;
                            }
                        }
                        //该行上方的墙壁全部擦除
                        for (int i = 0; i < dynMaplist.Count; i++)
                        {
                            if (dynMaplist[i].pos.posY < indexY)
                            {
                                Console.SetCursorPosition(dynMaplist[i].pos.posX, dynMaplist[i].pos.posY);
                                Console.Write("  ");
                            }
                        }
                        //该行上方的墙壁全部下移一行
                        for (int i = 0; i < dynMaplist.Count; i++)
                        {
                            if (dynMaplist[i].pos.posY < indexY)
                            {
                                dynMaplist[i].pos.posY++;
                                dynMaplist[i].Print();
                            }
                        }
                        //最高行位置下移
                        topPosY++;
                        GameScene.instantScore += 10;
                    }
                    //检查索引下移
                    indexY++;
                }            
            }
        }

        //死亡判断
        //
        public void CheckIsDead()
        {
            if (topPosY <= 0)
            {
                GameScene.Dead = true;
                Game.gameState = E_GameState.End;
            }
        }
        public Map()
        {
            Console.ForegroundColor = ConsoleColor.Red;

            fixedMaplist = new List<GameObject>();
            dynMaplist = new List<GameObject>();

            
            topPosY = Game.h - 5;
        }
    }
}
