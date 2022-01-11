using System;
using System.Collections.Generic;
using System.Text;

namespace 实践小项目_俄罗斯方块
{
    class Map
    {
        //地图数据集合
        //
        List<GameObject> fixedMaplist;
        List<GameObject> dynMaplist;

        //地图行砖块个数
        //
        int horiBrickAmt;

        //绘制固定墙壁方法
        //
        public void PrintFixedWall()
        {
            //添加纵向的固定墙壁
            for (int i = 0; i < Game.h - 5; i++)
            {
                fixedMaplist.Add(new GameObject(0, i));
                fixedMaplist.Add(new GameObject(((int)Game.w / 2) * 2 - 2, i));
            }

            //添加底部横向固定墙壁
            for (int i = 0; i < ((int)Game.w / 2) * 2; i += 2)
            {
                fixedMaplist.Add(new GameObject(i, Game.h - 5));
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
            Console.ForegroundColor = ConsoleColor.Red;

            //添加小方块到动态墙壁地图中
            dynMaplist.AddRange(gameObjects);

            //打印动态添加的小方块
            foreach (GameObject item in dynMaplist)
            {
                item.Print();
            }

            //将新砖块最底层的个数添加到horiBrickAmt里
            //

        }

        //判断是否移除整层动态墙壁
        //
        public void CheckWhetherRemoveHoriWall()
        {
            if (dynMaplist != null && horiBrickAmt >= (int)Game.w / 2 - 2)
            {
                foreach (GameObject item in dynMaplist)
                {
                    if(item.pos.PosY == Game.h - 5)
                    {
                        dynMaplist.Remove(item);
                    }
                }
            }
        }

        public Map()
        {
            Console.ForegroundColor = ConsoleColor.Red;

            fixedMaplist = new List<GameObject>();
            dynMaplist = new List<GameObject>();

            horiBrickAmt = 0;
        }
    }
}
