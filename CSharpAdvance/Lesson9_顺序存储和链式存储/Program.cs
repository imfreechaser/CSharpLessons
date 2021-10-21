using System;

namespace Lesson9_顺序存储和链式存储
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int> link = new LinkedList<int>();
            link.Add(1);
            link.Add(2);
            link.Add(3);
            link.Add(4);

            LinkedNode<int> node = link.head;
            while (node != null)
            {
                Console.WriteLine(node.value);
                node = node.nextNode;
            }

            link.Remove(3);
            node = link.head;
            while (node != null)
            {
                Console.WriteLine(node.value);
                node = node.nextNode;
            }
        }
    }
    class LinkedNode<T>
    {
        public T value;
        public LinkedNode<T> nextNode;

        public LinkedNode(T value)
        {
            this.value = value;
        }
    }
    class LinkedList<T>
    {
        public LinkedNode<T> head;
        public LinkedNode<T> last;
        public void Add(T value)
        {
            LinkedNode<T> node = new LinkedNode<T>(value);
            if(head == null)
            {
                head = node;
                last = node;
            }
            else
            {
                last.nextNode = node;
                last = node;
            }
        }
        public void Remove(T value)
        {
            if(head == null)//如果链表为空
            {
                return;
            }
            if(head.value.Equals(value))//如果是头部元素
            {
                head = head.nextNode;
                if (head == null)//如果原来只有头部元素，移除之后链表为空了
                    last = null;
            }
            LinkedNode<T> node = head;
            while(node.nextNode != null)//依次往后遍历，直到最后一个为null
            {
                if (node.nextNode.value.Equals(value))
                {
                    node.nextNode = node.nextNode.nextNode;
                    break;
                }
                node = node.nextNode;
            }
        }
    }
}
