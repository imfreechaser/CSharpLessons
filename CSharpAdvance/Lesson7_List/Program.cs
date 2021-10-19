using System;
using System.Collections.Generic;

namespace Lesson7_List
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Practice2
            List<int> list = new List<int>();
            list.AddRange(new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 });
            foreach (int item in list)
            {
                Console.WriteLine(item);
            }
            list.RemoveAt(4);
            foreach (int item in list)
            {
                Console.WriteLine(item);
            }
            #endregion
            #region Practice3
            Boss boss1 = new Boss();
            Boss boss2 = new Boss();
            Gablin gablin1 = new Gablin();
            Gablin gablin2 = new Gablin();
            Boss boss3 = new Boss();
            Boss boss4 = new Boss();
            Gablin gablin3 = new Gablin();

            foreach (Monster item in Monster.monsters)
            {
                item.Atk();
            }
            #endregion
        }
    }
    abstract class Monster
    {
        protected string name;
        protected int atk;
        public static List<Monster> monsters = new List<Monster>();

        public Monster()
        {
            monsters.Add(this);
        }
        public abstract void Atk(); 
    }
    class Boss : Monster
    {
        public override void Atk()
        {
            Console.WriteLine("Boss攻击");
        }
    }
    class Gablin : Monster
    {
        public override void Atk()
        {
            Console.WriteLine("Gablin攻击");
        }
    }
}
