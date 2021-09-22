using System;
using System.Collections;

namespace Lesson4_hashtable
{
    class Program
    {
        static void Main(string[] args)
        {
            MonkeyBoss mb = new MonkeyBoss("雪山大猿王", 1);
            Frankanstan fk = new Frankanstan("科学怪人", 2);
            MonsterMng.Instance.createMonster(mb);
            MonsterMng.Instance.printMonster(mb.monsterID);
            MonsterMng.Instance.RemoveMonster(mb.monsterID);
            Console.WriteLine(MonsterMng.Instance.hashtable.Count);
            MonsterMng.Instance.createMonster(mb);
            MonsterMng.Instance.printMonster(mb.monsterID);
            MonsterMng.Instance.createMonster(fk);
            MonsterMng.Instance.printMonster(fk.monsterID);
            Console.WriteLine(MonsterMng.Instance.hashtable.Count);
        }
    }
    class MonsterMng
    {
        private static MonsterMng instance = new MonsterMng();
        private MonsterMng()
        {

        }

        public static MonsterMng Instance
        {
            get
            {
                return instance;
            }
        }
        public Hashtable hashtable = new Hashtable();

        public void createMonster(Monster monster)
        {
            hashtable.Add(monster.monsterID, monster);
        }
        public void printMonster(object key)
        {
            Console.WriteLine($"id为{key}的怪物是{(hashtable[key] as Monster).monsterName}");
        }
        public void RemoveMonster(object key)
        {
            if (hashtable.ContainsKey(key))
            {
                hashtable.Remove(key);
            }
            else
            {
                Console.WriteLine("没有id为{0}的怪物", key);
            }
        }

    }

    class Monster
    {
        public int monsterID;
        public string monsterName;
        int atk;
        int dfd;
        public void showMonster()
        {
            Console.WriteLine(monsterName);
        }
    }
    class MonkeyBoss : Monster
    {
        public MonkeyBoss(string name, int id)
        {
            monsterName = name;
            monsterID = id;
        }
    }
    class Frankanstan : Monster
    {
        public Frankanstan(string name, int id)
        {
            monsterName = name;
            monsterID = id;
        }
    }

}
