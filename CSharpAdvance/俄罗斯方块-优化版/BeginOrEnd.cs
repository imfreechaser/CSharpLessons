using System;
using System.Collections.Generic;
using System.Text;

namespace 俄罗斯方块_优化版
{
    class BeginOrEnd : ISceneUpdate
    {
        protected string title = "123";
        protected string btn1, btn2;
        protected int selectedBtnId = 1;
        protected bool brkInnerLoop = false;

        //帧更新方法
        //
        public void Update()
        { 
            //开始/结束场景内容
                Console.SetCursorPosition(Game.w / 2 - 4, Game.h / 5 + 8);
                Console.ForegroundColor = selectedBtnId == 1 ? ConsoleColor.Red : ConsoleColor.White;
                Console.Write(btn1);

                Console.SetCursorPosition(Game.w / 2 - 4, Game.h / 5 + 10);
                Console.ForegroundColor = selectedBtnId == 2 ? ConsoleColor.Red : ConsoleColor.White;
                Console.Write(btn2);

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.W:
                    case ConsoleKey.UpArrow:
                        selectedBtnId--;
                        if(selectedBtnId < 1)
                        {
                            selectedBtnId = 1;
                        }
                        break;
                    case ConsoleKey.S:
                    case ConsoleKey.DownArrow:
                        selectedBtnId++;
                        if(selectedBtnId > 2)
                        {
                            selectedBtnId = 2;
                        }
                        break;
                    case ConsoleKey.Enter:
                        ChangeScene();
                        break;
                }
            }  
        

        //切换游戏状态枚举值方法
        //
        public virtual void ChangeScene() { }

        //打印标题
        //开始和结束场景中的标题不同，在子类构造函数中设置相应的值
        public virtual void PrintTitle() { }
        
    }
}
