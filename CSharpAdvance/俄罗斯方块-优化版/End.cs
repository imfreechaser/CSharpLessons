using System;
using System.Collections.Generic;
using System.Text;

namespace 俄罗斯方块_优化版
{
    class End:BeginOrEnd
    {
        public static int finalScore = 0;
        public End()
        {
            btn1 = "重新开始";
            btn2 = "结束游戏";
            title = "游戏结束";

            PrintTitle();
        }

        //切换游戏状态枚举
        //
        public override void ChangeScene()
        {
            if (selectedBtnId == 1)
            {
                Game.ChangeScene(E_GameState.Begin);
            }
            else
            {
                Environment.Exit(0);
            }
        }

        //打印标题和分数
        //
        public override void PrintTitle()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(Game.w / 2 - 4, Game.h / 5);
            Console.Write(title);

            Console.SetCursorPosition(Game.w / 2 - 6, Game.h / 5 + 4);
            Console.Write($"本局分数：{finalScore}");
        }
    }
}
