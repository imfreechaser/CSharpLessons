using System;
using System.Collections.Generic;
using System.Text;

namespace 实践小项目_俄罗斯方块
{
    class GameScene : ISceneUpdate
    {
        Map map;
        public void Update()
        {
            while (true)
            {
                
                if(Console.ReadKey().Key == ConsoleKey.Enter)
                {
                    Game.gameState = E_GameState.End;
                    break;
                }
                
            }
        }

        public GameScene()
        {
            map = new Map();
            map.PrintFixedWall();
        }
    }
}
