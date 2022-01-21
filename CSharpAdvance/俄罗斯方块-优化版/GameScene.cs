using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace 俄罗斯方块_优化版
{
    class GameScene : ISceneUpdate
    {
        Map map;
        BrickManager bm;
        public static int sleepTime;
        public static bool Dead;
        public static int instantScore;
        
        public void Update()
        {
            //添加新线程
            Thread tUserInput = new Thread(bm.UserInput);
            tUserInput.IsBackground = true;
            tUserInput.Start();

            while (!Dead)
            {
                //产生方块
                bm.ProduceBrick();

                //方块下落过程循环
                while (!bm.TouchBotWall())
                {
                    Thread.Sleep(sleepTime);
                    bm.ClearLastFrame();
                    bm.MoveDown();
                    bm.Print();
                }

                //地图添加动态墙壁
                map.AddDynWall(bm.bricks);

                Thread.Sleep(100);

                //判断动态墙壁是否可消除
                map.CheckWhetherRemoveHoriWall();

                //打印分数
                printScore();

                //死亡判断
                map.CheckIsDead();
            }

            tUserInput = null;
        }

        public GameScene()
        {
            map = new Map();
            map.PrintFixedWall();
            bm = new BrickManager();
            sleepTime = 500;
            instantScore = 0;
            printScore();
        }

        public void printScore()
        {
            Console.SetCursorPosition(2, Game.h - 3);
            Console.Write("                           ");
            Console.SetCursorPosition(2, Game.h - 3);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"当前分数：{instantScore}");
        }
    }
}
