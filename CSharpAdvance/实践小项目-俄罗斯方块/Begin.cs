using System;
using System.Collections.Generic;
using System.Text;

namespace 实践小项目_俄罗斯方块
{
    class Begin:BeginOrEnd
    {
        public Begin()
        {
            btn1 = "开始游戏";
            btn2 = "结束游戏";
            title = "俄罗斯方块";
        }

        //切换游戏状态枚举
        //
        public override void ChangeScene()
        {
            if (selectedBtnId == 1)
            {
                Game.gameState = E_GameState.Run;
                brkInnerLoop = true;
            }
            else
            {
                Environment.Exit(0);
            }
        }

        //打印标题
        //
        public override void PrintTitle()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(Game.w / 2 - 5, Game.h / 5);
            Console.Write(title);
        }
    }
}
