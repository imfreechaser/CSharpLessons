using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace 俄罗斯方块_优化版
{
    class GameScene : ISceneUpdate
    {
        Map map;
        BrickManager bm = new BrickManager();
        public static bool Dead;
        
        public void Update()
        {
            lock (bm)
            {
                //方块下落
                if (bm.CanMoveDown(map))
                {
                    bm.MoveDown();
                }
            }
            Thread.Sleep(200);

            //死亡后切换场景、暂停线程
            if (Dead)
            {
                //此处必须先把输入线程暂停，才能切换场景
                //因为若还检测到了按下键，那么在UserInput的下case里还会调用CanMoveDown方法，
                //检测到满了以后又会调用地图的AddDynWall方法，此方法会把动态墙壁全部打印一次，若先切场景再关闭，那么打印的方块会呈现。
                InputThread.Instance.UserInputEvent -= UserInput;
                Game.ChangeScene(E_GameState.End);
            }
        }

        public GameScene()
        {
            //重置地图
            map = new Map();

            //开启输入线程
            InputThread.Instance.UserInputEvent += UserInput;

            //重置参数
            Dead = false;

            //随机创建方块
            bm.ProduceBrick();

            //打印当前分数
            map.PrintScore();

        }

        //用户输入方法
        //包括横向移动、切换方向、加速下落
        public void UserInput()
        {
            if (Console.KeyAvailable == true)
            {
                lock (bm)
                {
                    switch (Console.ReadKey(true).Key)
                    {
                        case ConsoleKey.LeftArrow:
                            if (bm.CanHoriMove(true, map))
                                bm.HoriMove(true);
                            break;
                        case ConsoleKey.RightArrow:
                            if (bm.CanHoriMove(false, map))
                                bm.HoriMove(false);
                            break;
                        case ConsoleKey.A:
                            if (bm.CanChangeDir(true, map))
                                bm.ChangeDir(true);
                            break;
                        case ConsoleKey.D:
                            if (bm.CanChangeDir(false, map))
                                bm.ChangeDir(false);
                            break;
                        case ConsoleKey.DownArrow:
                            if (bm.CanMoveDown(map))
                                bm.MoveDown();
                            break;
                        case ConsoleKey.Escape:
                            Dead = true;
                            break;
                        default:
                            break;
                    }
                }

            }
        }

        
    }
}
