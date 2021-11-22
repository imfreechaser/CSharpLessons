using System;

namespace Lesson12_委托
{
    class Program
    {
        static void Main(string[] args)
        {
            Monster m1 = new Monster();
            Monster m2 = new Monster();
            Player p1 = new Player();
            UISurface panel = new UISurface();
            Achievements avm = new Achievements();

            void KillMonster(Monster m)
            {
                m.deadDoSomething += p1.MonsterDiedAddCoins;
                m.deadDoSomething += panel.RefreshData;
                m.deadDoSomething += avm.AddMonsterKilledAmt;
                m.Dead();
            }
            KillMonster(m1);
            KillMonster(m2);
        }
        
    }

    class Monster
    {
        //当怪物死亡时，把自己作为参数传出去
        public Action<Monster> deadDoSomething;
        public int deadPrice = 10;
        public void Dead()
        {
            if(deadDoSomething != null)
            {
                deadDoSomething(this);
            }
            deadDoSomething = null;//每次调用完委托之后将委托和方法之间的联系断开，防止同个实例再次调用
        }
    }
    class Player
    {
        public int coins = 0;
        public void MonsterDiedAddCoins(Monster m)
        {
            coins += m.deadPrice;
            Console.WriteLine("玩家金币数:{0}",coins);
        }
    }
    class UISurface
    {
        public void RefreshData(Monster m)
        {
            Console.WriteLine("\"怪物死亡，玩家金币数+{0}\"",m.deadPrice);
        }
    }
     class Achievements
    {
        public  int MonsterKilledAmt = 0;
        public  void AddMonsterKilledAmt(Monster m)
        {
            MonsterKilledAmt++;
            Console.WriteLine("怪物击杀成就：{0}",MonsterKilledAmt);
        }
    }

}
