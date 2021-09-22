using System;
using System.Collections;
//using System.Collections.Generic;

namespace Lesson6_泛型约束
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList<int> arrayList = new ArrayList<int>();
            arrayList.Add(10);
            arrayList.Add(20);
            arrayList.Add(30);
            arrayList.Add(40);
            arrayList.Add(50);
            arrayList.Add(10);
            Console.WriteLine(arrayList.Count);
            Console.WriteLine(arrayList.Capacity);
            arrayList.RemoveAt(3);
            Console.WriteLine(arrayList.Count);
            Console.WriteLine(arrayList.Capacity);
            Console.WriteLine(arrayList[9]);
            Console.WriteLine("************");
            Console.WriteLine(arrayList.IndexOf(50));
            arrayList[13] = 9;


        }
    }
    class Test
    {

    }
    class ExampleBase<T> where T : new()
    {
        private static T instance = new T();
        public static T Instance
        {
            get
            {
                return instance;
            }
        }
    }
    class GameMng : ExampleBase<GameMng>
    {

    }
    class ArrayList<T> where T : new()
    {
        private int capacity;
        private int count;
        private T[] ts;

        public ArrayList()
        {
            capacity = 10;
            count = 0;
            ts = new T[capacity];
        }
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= count)
                {
                    Console.WriteLine("索引不合法");
                    return default(T);
                }
                return ts[index];
            }
            set
            {
                if (index < 0 || index >= count)
                {
                    Console.WriteLine("索引不合法");
                }
                else
                {
                    ts[index] = value;
                }
            }
        }
        public int Capacity
        {
            get
            {
                return capacity;
            }
        }
        public int Count
        {
            get
            {
                return count;
            }
        }
        public void Add(T t)
        {
            if (count >= capacity)
            {
                T[] newArrayList = new T[capacity * 2];
                for (int i = 0; i < ts.Length; i++)
                {
                    newArrayList[i] = ts[i];
                }
                ts = newArrayList;
                capacity = ts.Length;
            }
            ts[count] = t;
            count++;
        }
        public void RemoveAt(int index)
        {
            if (index < 0 || index >= count)
            {
                Console.WriteLine("索引不合法");
                return;
            }
            for (int i = index; i < count - 1; i++)
            {
                ts[i] = ts[i + 1];
            }
            ts[count - 1] = default(T);
            count--;
        }
        public void Remove(T t)
        {
            for (int i = 0; i < count; i++)
            {
                if (ts[i].Equals(t))
                {
                    for (int j = i; j < count - 1; j++)
                    {
                        ts[j] = ts[j + 1];
                    }
                    ts[count - 1] = default(T);
                    count--;
                    break;
                }
            }
        }
        public int IndexOf(T t)
        {
            for (int i = 0; i < count; i++)
            {
                if (ts[i].Equals(t))
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
