using System;
using System.Collections.Generic;
using System.Text;

namespace 俄罗斯方块_优化版
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
        /// 控制台窗口宽高
        /// </summary>
        public const int w = 53, h = 35;
        /// <summary>
        /// 当前游戏场景
        /// </summary>
        public static ISceneUpdate sceneState;

        //游戏开始运行方法
        //
        public void GameStart()
        {
            //游戏大循环
            while (true)
            {
                sceneState.Update();
            }
        }

        //切换游戏场景方法
        //
        public static void ChangeScene(E_GameState gameState)
        {
            Console.Clear();
            switch (gameState)
            {
                case E_GameState.Begin:
                    sceneState = new Begin();
                    sceneState.Update();
                    break;
                case E_GameState.Run:
                    sceneState = new GameScene();
                    sceneState.Update();
                    break;
                case E_GameState.End:
                    sceneState = new End();
                    sceneState.Update();
                    break;
                default:
                    break;
            }
        }

        public Game()
        {
            Console.SetWindowSize(w, h);
            Console.CursorVisible = false;

            ChangeScene(E_GameState.Begin);
        }
    }
}
