using System;
using System.Collections.Generic;
using System.Text;

namespace 实践小项目_俄罗斯方块
{
    class GameScene : ISceneUpdate
    {
        public void Update()
        {
            while (true)
            {
                Console.Write("游戏场景");
                if(Console.ReadKey().Key == ConsoleKey.Enter)
                {
                    Game.gameState = E_GameState.End;
                    break;
                }
                
            }
        }
    }
}
