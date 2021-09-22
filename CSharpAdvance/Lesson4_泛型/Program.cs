using System;
using System.Collections;
using System.Collections.Generic;

namespace Lesson5_泛型
{
    class Program
    {
        static void Main(string[] args)
        {
            Practice<double> p = new Practice<double>();
            Console.WriteLine(p.TypeJudge<int>());
            Console.WriteLine(p.TypeJudge<float>());
            Console.WriteLine(p.TypeJudge<char>());
            Console.WriteLine(p.TypeJudge<string>());
            Console.WriteLine(p.TypeJudge<double>());
            Stack<int> stack = new Stack<int>();
            Queue<float> queue = new Queue<float>();
        }
    }
    class Practice<K>
    {
        K k = default(K);
        public string TypeJudge<T>()
        {
            if (typeof(T) == typeof(int))
            {
                return string.Format("{0},{1}字节", "整型", sizeof(int));
            }
            else if (typeof(T) == typeof(float))
            {
                return string.Format("{0},{1}字节", "单精度浮点数", sizeof(float));
            }
            else if (typeof(T) == typeof(char))
            {
                return string.Format("{0},{1}字节", "字符类型", sizeof(char));
            }
            else if (typeof(T) == typeof(string))
            {
                return string.Format("{0},{1}字节", "字符串类型", "?");
            }
            else
            {
                return "其他类型";
            }
        }
    }
}
