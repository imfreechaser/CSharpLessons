using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace 俄罗斯方块_优化版
{
    class InputThread
    {
        //单例模式
        private static InputThread instance = new InputThread();
        public static InputThread Instance
        {
            get => instance;
        }

        //创建输入线程
        Thread inputT;

        //创建输入事件
        public event Action UserInputEvent; 

        private InputThread()
        {
            inputT = new Thread(InputEvent);
            inputT.IsBackground = true;
            inputT.Start();
        }

        public void InputEvent()
        {
            while (true)
            {
                UserInputEvent?.Invoke();
            }
        }
    }
}
