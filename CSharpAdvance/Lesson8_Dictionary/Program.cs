using System;
using System.Collections.Generic;

namespace Lesson8_Dictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            //#region Practice1
            //Console.WriteLine("请输入一个不超过3位数的数：");
            //try
            //{
            //    int input = int.Parse(Console.ReadLine());
            //    Console.WriteLine(ChineseNumber.TurnToChn(input));
            //}
            //catch (Exception)
            //{
            //    Console.WriteLine("请输入正确格式的数字！");
            //}
            //#endregion
            #region Practice2
            MyClass mc = new MyClass();
            mc.coreLogic();
            #endregion

        }

    }
    //#region Practice1
    //class ChineseNumber
    //{
    //    static Dictionary<int, string> dic = new Dictionary<int, string>();
    //    static ChineseNumber()
    //    {
    //        dic.Add(0, "零");
    //        dic.Add(1, "壹");
    //        dic.Add(2, "贰");
    //        dic.Add(3, "叁");
    //        dic.Add(4, "肆");
    //        dic.Add(5, "伍");
    //        dic.Add(6, "陆");
    //        dic.Add(7, "柒");
    //        dic.Add(8, "捌");
    //        dic.Add(9, "玖");
    //    }
    //    public static string TurnToChn(int num)
    //    {
    //        if (num >= 0 && num < 1000)
    //        {
    //            if (num < 10)
    //            {
    //                return dic[num];
    //            }
    //            else if (num >= 10 && num < 100)
    //            {
    //                return dic[(int)(num / 10)] + dic[num % 10];
    //            }
    //            else
    //            {
    //                return dic[(int)(num / 100)] + dic[(int)(num % 100 / 10)] + dic[num % 10];
    //            }
    //        }
    //        else
    //        {
    //            return "请输入正确格式的数字！";
    //        }
    //    }
    //}
    //#endregion
    #region Practice2
    class MyClass
    {
        Dictionary<char, int> crtAmt = new Dictionary<char, int>();
        string str = "Welcome to Unity world!";
        public void coreLogic()
        {
            str = str.ToLower();
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] >= 97 && str[i] <= 122)
                {
                    if (crtAmt.ContainsKey(str[i]))
                    {
                        crtAmt[str[i]]++;
                    }
                    else
                    {
                        crtAmt.Add(str[i], 1);
                    }
                }
            }

            foreach(char item in crtAmt.Keys)
            {
                Console.WriteLine("键："+ item +"\t值:"+ crtAmt[item]);
            }
        }
    }
    #endregion
}
