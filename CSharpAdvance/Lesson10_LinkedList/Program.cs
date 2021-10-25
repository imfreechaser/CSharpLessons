using System;
using System.Collections.Generic;

namespace Lesson10_LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int> intList = new LinkedList<int>();
            Random r = new Random();
            for (int i = 0; i < 10; i++)
            {
                intList.AddFirst(r.Next(-100, 100));
            }
            LinkedListNode<int> tempNode = intList.First;
            while (tempNode != null)
            {
                Console.WriteLine(tempNode.Value);
                tempNode = tempNode.Next;
            }
            Console.WriteLine("**********************************");
            tempNode = intList.Last;
            while (tempNode != null)
            {
                Console.WriteLine(tempNode.Value);
                tempNode = tempNode.Previous;
            }
        }
    }
}
