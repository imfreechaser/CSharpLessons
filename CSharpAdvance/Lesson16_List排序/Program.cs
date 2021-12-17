using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Lesson16_List排序
{
    class Program
    {
        static void Main(string[] args)
        {
            //#region Practice1
            //List<Monster> monsters = new List<Monster>();
            //monsters.Add(new Monster("青龙", 79, 57, 100));
            //monsters.Add(new Monster("白虎", 88, 49, 90));
            //monsters.Add(new Monster("朱雀", 68, 76, 80));
            //monsters.Add(new Monster("玄武", 78, 75, 90));

            //bool sort = false;

            //string sortSymbol;

            //int chosenNum = 0;
            //bool wrongNum;
            //string sortName = "";

            //while (true)
            //{
            //    wrongNum = false;

            //    Console.WriteLine("请选择排序方式：1.攻击排序，2.防御排序，3.血量排序，4.反转");
            //    switch (Console.ReadKey(true).Key)
            //    {
            //        case ConsoleKey.D1:
            //            chosenNum = 1;
            //            sort = false;
            //            monsters.Sort(Monster.AtkSort(sort));
            //            sortName = "攻击";
            //            break;

            //        case ConsoleKey.D2:
            //            chosenNum = 2;
            //            sort = false;
            //            monsters.Sort(Monster.DfdSort(sort));
            //            sortName = "防御";
            //            break;

            //        case ConsoleKey.D3:
            //            chosenNum = 3;
            //            sort = false;
            //            monsters.Sort(Monster.HpSort(sort));
            //            sortName = "血量";

            //            break;
            //        case ConsoleKey.D4:
            //            if (chosenNum == 0)
            //            {
            //                Console.WriteLine("请先选择排序方式！");
            //                wrongNum = true;
            //                break;
            //            }
            //            monsters.Reverse();
            //            sort = !sort;
            //            break;

            //        default:
            //            Console.WriteLine("请输入正确格式的数字！");
            //            wrongNum = true;
            //            break;
            //    }
            //    sortSymbol = sort ? "<" : ">";
            //    if (wrongNum)
            //        continue;
            //    else
            //    {
            //        Console.WriteLine($"青龙、朱雀、白虎、玄武四个怪兽的{sortName}排序为：" +
            //        $"{monsters[0].Name}{sortSymbol}{monsters[1].Name}{sortSymbol}{monsters[2].Name}" +
            //        $"{sortSymbol}{monsters[3].Name}\n");
            //    }
            //}
            //#endregion
            //#region Practice2
            //List<Thing> thingList = new List<Thing>();
            //thingList.Add(new Thing(1, 3, "ad"));
            //thingList.Add(new Thing(2, 4, "ads"));
            //thingList.Add(new Thing(3, 2, "pens"));
            //thingList.Add(new Thing(4, 1, "apple"));
            //thingList.Add(new Thing(5, 6, "banana"));
            //thingList.Add(new Thing(6, 9, "penguin"));
            //thingList.Add(new Thing(7, 10, "elevator"));//3.5+3+1.6 = 8.1
            //thingList.Add(new Thing(8, 8, "valentine"));//4+2.4+1.8=8.2
            //thingList.Add(new Thing(9, 5, "watermelon"));//4.5+1.5+2 = 8
            //thingList.Add(new Thing(10, 7, "strawberry"));//5+2.1+2.2 = 9.3

            //thingList.Sort(Thing.IntegratedSort);
            //for (int i = 0; i < thingList.Count; i++)
            //{
            //    Console.WriteLine(thingList[i].Name);
            //}
            //#endregion
            #region Practice3
            Dictionary<int, string> mydic = new Dictionary<int, string>();
            mydic.Add(4, "Tom");
            mydic.Add(2, "Jerry");
            mydic.Add(3, "Marry");
            mydic.Add(1, "Tobby");
            List<Dic> dicList = new List<Dic>();

            foreach (int item in mydic.Keys)
            {
                dicList.Add(new Dic(item, mydic[item]));
            }
            dicList.Sort(Dic.Sort);
            for (int i = 0; i < dicList.Count; i++)
            {
                Console.WriteLine(dicList[i].Key + dicList[i].Value);
            }
            #endregion
        }
    }

   
    class Monster
    {
        public string Name { get; }
        public int Atk { get; }
        public int Dfd { get; }
        public int Hp { get; }
        public Monster(string name,int atk,int dfd,int hp)
        {
            Name = name;
            Atk = atk;
            Dfd = dfd;
            Hp = hp;
        }
        public static Comparison<Monster> AtkSort(bool sort)
        {
            if (sort)
            {
                return (a, b) => { return a.Atk > b.Atk ? 1 : -1; };
            }
            else
            {
                return (a, b) => { return a.Atk > b.Atk ? -1 : 1; };
            }
        }
        public static Comparison<Monster> DfdSort(bool sort)
        {
            if (sort)
            {
                return (a, b) => { return a.Dfd > b.Dfd ? 1 : -1; };
            }
            else
            {
                return (a, b) => { return a.Dfd > b.Dfd ? -1 : 1; };
            }
        }
        public static Comparison<Monster> HpSort(bool sort)
        {
            if (sort)
            {
                return (a, b) => { return a.Hp > b.Hp ? 1 : -1; };
            }
            else
            {
                return (a, b) => { return a.Hp > b.Hp ? -1 : 1; };
            }
        }
    }
    class Thing
    {
        public int Type { get; }
        public int Quality { get; }
        public string Name { get; }

        public Thing(int type,int quality,string name)
        {
            Type = type;
            Quality = quality;
            Name = name;
        }
        public static int IntegratedSort(Thing a, Thing b)
        {
            float proportionA = a.Type * 0.5f + a.Quality * 0.3f + a.Name.Length * 0.2f;
            float proportionB = b.Type * 0.5f + b.Quality * 0.3f + b.Name.Length * 0.2f;

            return proportionA > proportionB ? -1 : 1;
        }
    }
    class Dic
    {
        public int Key { get;set; }
        public string Value { get; set; }
        public Dic(int key, string value)
        {
            Key = key;
            Value = value;
        }
        public static int Sort(Dic a, Dic b)
        {
            return a.Key > b.Key ? 1 : -1;
        }
    }
}
