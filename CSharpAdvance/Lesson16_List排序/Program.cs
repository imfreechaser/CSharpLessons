using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Lesson16_List排序
{
    class Program
    {
        static void Main(string[] args)
        {
            List<MyClass> myList = new List<MyClass>();
            myList.Add(new MyClass(20));
            myList.Add(new MyClass(10));
            myList.Add(new MyClass(50));
            myList.Add(new MyClass(30));
            myList.Add(new MyClass(40));

            myList.Sort((a, b) => { return (a.value > b.value ? 1 : -1); });

            for (int i = 0; i < myList.Count; i++)
            {
                Console.WriteLine(myList[i].value);
            }
        }
    }

    class MyClass//:IComparable<MyClass>
    {
        public int value;
        public MyClass(int value)
        {
            this.value = value;
        }

        //public int CompareTo(MyClass other)
        //{
        //    if(value > other.value)
        //    {
        //        return -1;
        //    }
        //    else if(value < other.value)
        //    {
        //        return 1;
        //    }
        //    return 0;
        //}
    }

}
