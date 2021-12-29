using System;
using System.Collections;
using System.Collections.Generic;

namespace Lesson21_迭代器
{
    class Program
    {
        static void Main(string[] args)
        {
            MyClass mc = new MyClass();
            //方法一
            foreach (string str in mc)
            {
                Console.WriteLine(str);
            }
            Console.WriteLine("**********************************************");
            //方法二
            foreach (string str in mc.GetMyEnumerable())
            {
                Console.WriteLine(str);
            }
        }
    }
    class MyClass : IEnumerable
    {
        string[] array = new string[] { "12","23","34","45","56"};
        #region 创建枚举类型-既可以自身实现可枚举类型也可以自身不实现
        public IEnumerator GetEnumerator()
        {
            return GetMyEnumerable().GetEnumerator();
        }
        public IEnumerable GetMyEnumerable()
        {
            for (int i = 0; i < array.Length; i++)
            {
                yield return array[i];
            }
        }

        #endregion
        #region 创建枚举器-必须自身实现可枚举类型
        //public IEnumerator GetEnumerator()
        //{
        //    return GetMyEnumerator();
        //}
        //public IEnumerator GetMyEnumerator()
        //{
        //    for (int i = 0; i < array.Length; i++)
        //    {
        //        yield return array[i];
        //    }
        //}
        ////可以简化为：
        //public IEnumerator GetEnumerator()
        //{
        //    for (int i = 0; i < array.Length; i++)
        //    {
        //        yield return array[i];
        //    }
        //}
        #endregion
        #region 最简版本-必须且只能实现自身可枚举类型
        //public IEnumerator GetEnumerator()
        //{
        //    for (int i = 0; i < array.Length; i++)
        //    {
        //        yield return array[i];
        //    }
        //}
        #endregion

    }
}
