using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace 实践小项目_俄罗斯方块
{
    class GameScene : ISceneUpdate
    {
        Map map;
        BrickManager bm;
        public static int sleepTime;
        
        public void Update()
        {
            //添加新线程
            Thread tUserInput = new Thread(bm.UserInput);
            tUserInput.IsBackground = true;
            tUserInput.Start();

            while (true)
            {
                //产生方块
                bm.ProduceBrick();

                while (!bm.TouchBotWall())
                {
                    Thread.Sleep(sleepTime);
                    bm.ClearLastFrame();
                    bm.MoveDown();
                    bm.Print();
                }
                //Console.ReadKey();
            }
            
        }

        public GameScene()
        {
            map = new Map();
            map.PrintFixedWall();
            bm = new BrickManager();
            sleepTime = 1000;
        }
    }
}
