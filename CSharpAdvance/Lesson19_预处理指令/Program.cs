//#define Unity5
//#define Unity2017
#undef Unity2020
using System;

namespace Lesson19_预处理指令
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(CountUnderDifVersion(1, 5));

        }

        static int CountUnderDifVersion(int a, int b)
        {
#if Unity5
            return a + b;
#elif Unity2017
            return a * b;
#elif Unity2020
            return a - b;
#else 
            return 0;
#endif
        }
    }
}
