using System;
using System.Collections;

namespace Lesson1_ArrayList
{
    class Program
    {
        static void Main(string[] args)
        {
            Thing thing1 = new Thing("补10%的血",25f);
            Thing thing2 = new Thing("增加10%的攻击力",50f);
            Thing thing3 = new Thing("增加20%的防御力",100f);

            Backpack backpack = new Backpack(150);

            backpack.ShowMoney();

            backpack.Buy(thing2);
            backpack.Buy(thing3);

            backpack.ShowMoney();

            backpack.ShowFunction(thing2);
            backpack.ShowFunction(thing3);

            backpack.Sell(thing3);
            backpack.Sell(thing1);

            backpack.ShowMoney();
            backpack.ShowFunction(thing1);
            Console.WriteLine("**********************************");
            backpack.Buy(thing2);
            backpack.ShowMoney();

            backpack.Buy(thing2);
            backpack.ShowMoney();

            backpack.Buy(thing2);
            backpack.ShowMoney();


        }
    }

    class Thing
    {
        public string function;
        public float price;
        public Thing(string function,float price)
        {
            this.function = function;
            this.price = price;
        }
    } 
    class Backpack
    {
        ArrayList things = new ArrayList();
        float money;

        public void Buy(Thing thing)
        {
            if(money >= thing.price)
            {
                things.Add(thing);
                money -= thing.price;
            }
            else
            {
                Console.WriteLine("您的钱不够支付此商品！");
            }
        }
        public void Sell(Thing thing)
        {
            if(things.Contains(thing))
            {
                things.Remove(thing);
                money += thing.price;
            }
            else
            {
                Console.WriteLine("您没有此商品！");
            }
        }
        public void ShowMoney()
        {
            Console.WriteLine(money);
        }
        public void ShowFunction(Thing thing)
        {
            if (things.Contains(thing))
            {
                Console.WriteLine(thing.function);
            }
            else
            {
                Console.WriteLine("您没有此商品！");
            }
        }
        public Backpack(float money)
        {
            things.Clear();
            this.money = money;
        }
    }
}
