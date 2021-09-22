using System;
using System.Collections;

namespace Lesson2_Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            uint num = 56;
            Calc(num);
        }
        static void Calc(uint num)
        {
            Stack stack = new Stack();

            while (num > 0)
            {
                stack.Push(num % 2);
                num = num / 2;
            }
            Console.WriteLine(stack.Count);
            foreach (object item in stack)
            {
                Console.Write(item);
            }
        }
    }
}
