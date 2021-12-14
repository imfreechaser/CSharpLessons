using System;

namespace Lesson15_Lambda表达式
{
    class Program
    {
        static void Main(string[] args)
        {
            Test test = new Test();
            test.SomeMethod()();
        }
    }
    class Test
    {        
        public Action SomeMethod()
        {
            Action action = null;
            for (int i = 1; i < 11; i++)
            {
                int index = i;
                action += () =>
                {
                    Console.WriteLine(index);
                };
            }
            return action;
        }
    }
}
