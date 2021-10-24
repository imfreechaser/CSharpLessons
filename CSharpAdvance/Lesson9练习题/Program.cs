using System;

namespace Lesson9练习题
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedListBothSides<int> myLinkedList = new LinkedListBothSides<int>();
            myLinkedList.Add(1);
            myLinkedList.Add(2);
            myLinkedList.Add(3);
            myLinkedList.Add(4);
            myLinkedList.Add(5);
            Console.WriteLine("链表中一共有"+ myLinkedList.nodeCount +"个元素");
            LinkedNode<int> node = myLinkedList.FirstNode;
            while(node != null)
            {
                node.PrintValue();
                node = node.nextNode;
            }

            myLinkedList.RemoveAt(3);
            Console.WriteLine("链表中一共有" + myLinkedList.nodeCount + "个元素");
            LinkedNode<int> node2 = myLinkedList.FirstNode;
            while (node2 != null)
            {
                node2.PrintValue();
                node2 = node2.nextNode;
            }
        }
    }
    class LinkedNode<T>
    {
        public T value;
        public LinkedNode(T value)
        {
            this.value = value;
        }
        public LinkedNode<T> lastNode;
        public LinkedNode<T> nextNode;
        public void PrintValue()
        {
            Console.WriteLine(value);
        }
    }
    class LinkedListBothSides<T>
    {
        LinkedNode<T> firstNode;
        LinkedNode<T> lastNode;
        public int nodeCount = 0;

        public LinkedNode<T> FirstNode
        {
            get
            {
                return firstNode;
            }
        }
        public LinkedNode<T> LastNode
        {
            get
            {
                return lastNode;
            }
        }
        public void Add(T value)
        {
            LinkedNode<T> newNode = new LinkedNode<T>(value);
            if(firstNode == null)
            {
                firstNode = newNode;
                lastNode = newNode;
            }
            else
            {
                lastNode.nextNode = newNode;
                newNode.lastNode = lastNode;
                lastNode = newNode;
            }
            nodeCount++;
        }
        public void RemoveAt(int index)
        {
            int count = 0;
            LinkedNode<T> node = lastNode;
            while(node != null)
            {
                if(index == 0)//删除第一个节点
                {
                    if(firstNode.nextNode == null)//只有一个节点时
                    {
                        firstNode = null;
                        lastNode = null;
                    }
                    else//不止一个节点时
                    {
                        firstNode = firstNode.nextNode;
                        firstNode.lastNode.nextNode = null;
                        firstNode.lastNode = null;
                    }
                    nodeCount--;
                    break;
                }
                if(index == nodeCount - 1)//删除最后一个节点时
                {
                    lastNode = lastNode.lastNode;
                    lastNode.nextNode.lastNode = null;
                    lastNode.nextNode = null;
                    nodeCount--;
                    break;
                }
                if(index == count)//删除中间节点的情况
                {
                    node.lastNode.nextNode = node.nextNode;
                    node.nextNode.lastNode = node.lastNode;
                    nodeCount--;
                    break;
                }
                if(index > nodeCount - 1 || index < 0)//索引器不合法
                {
                    Console.WriteLine("请输入正确的索引值！");
                    break;
                }
                node = node.lastNode;
                count++;
            }
        }
    }
}
