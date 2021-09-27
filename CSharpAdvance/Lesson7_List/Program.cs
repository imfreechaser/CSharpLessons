using System;
using System.Collections.Generic;

namespace Lesson7_List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            list.AddRange(new int[] { 10, 9,8,7,6,5,4,3,2,1 });
            foreach (int item in list)
            {
                Console.WriteLine(item);
            }
            list.RemoveAt(4);
            foreach (int item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}
