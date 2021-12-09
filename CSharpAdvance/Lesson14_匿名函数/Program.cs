using System;

namespace Lesson14_匿名函数
{
    class Program
    {
        static void Main(string[] args)
        {
            Test t = new Test();
            Console.WriteLine(t.func1(5));
        }
        
  
    }
    class Test
    {  
        public static Func<int, int> Fun1(int a)
        {
            //改变了a的生命周期
            return delegate (int b)
            {
                return a * b;
            };
        }
        public Func<int, int> func1 = Fun1(5);
    }

}
