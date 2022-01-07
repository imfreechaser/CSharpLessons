using System;
using System.Collections.Generic;
using System.Text;

namespace 实践小项目_俄罗斯方块
{
    /// <summary>
    /// 游戏状态枚举
    /// </summary>
    enum E_GameState
    {
        /// <summary>
        /// 开始状态
        /// </summary>
        Begin,
        /// <summary>
        /// 运行状态
        /// </summary>
        Run,
        /// <summary>
        /// 结束状态
        /// </summary>
        End
    }
    class Game
    {
        /// <summary>
        /// 当前游戏状态
        /// </summary>
        public static E_GameState gameState = E_GameState.Begin;
        /// <summary>
        /// 控制台窗口宽高
        /// </summary>
        public const int w = 60, h = 35;
        
        // 游戏初始化
        // 包含控制台的初始设置等内容
        public void Init()
        {
            Console.SetWindowSize(w,h);
            Console.CursorVisible = false;
        }

        //游戏开始运行方法
        //
        public void GameStart()
        {
            while (true)
            {
                Console.Clear();
                switch (gameState)
                {
                    case E_GameState.Begin:
                        BeginOrEnd begin = new Begin();
                        begin.Update();
                        break;
                    case E_GameState.Run:
                        GameScene gs = new GameScene();
                        gs.Update();
                        break;
                    case E_GameState.End:
                        BeginOrEnd end = new End();
                        end.Update();
                        break;
                    default:
                        break;
                }
            }
        }
        public Game()
        {
            Init();
        }
    }
}
