using System;
using System.Reflection;

namespace Lesson20_反射_Assembly_Activator_练习题
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly assembly = Assembly.LoadFrom(@"C:\Users\RayData\source\repos\CSharpLessons\CSharpAdvance\Lesson20\bin\Debug\Lesson20");
            Type[] types = assembly.GetTypes();
            for (int i = 0; i < types.Length; i++)
            {
                Console.WriteLine(types[i]);
            }
            Type playerT = assembly.GetType("Lesson20.Player");
            Type remindNoModify = assembly.GetType("Lesson20.RemindNoModifyAttribute");

            MemberInfo[] members = playerT.GetMembers();
            for (int i = 0; i < members.Length; i++)
            {
                Console.WriteLine(members[i]);
            }
            //ConstructorInfo ctor = playerT.GetConstructor(new Type[0]);
            //object player = ctor.Invoke(null);
            object player = Activator.CreateInstance(playerT,null);

            FieldInfo name = playerT.GetField("name");
            name.SetValue(player,"Zhangsan");
            Console.WriteLine(name.GetValue(player));

            PropertyInfo hp = playerT.GetProperty("Hp");
            if (hp.IsDefined(remindNoModify, false))
            {
                Console.WriteLine("非法操作，随意修改Hp！");
            }
            else
            {
                hp.SetValue(player, 200);
            }
            Console.WriteLine(hp.GetValue(player));

            
            FieldInfo atk = playerT.GetField("atk");
            if (atk.IsDefined(remindNoModify, false))
            {
                Console.WriteLine("非法操作，随意修改atk！");
            }
            else
            {
                atk.SetValue(player, 40);
            }
            Console.WriteLine(atk.GetValue(player));


            FieldInfo dfd = playerT.GetField("dfd");
            dfd.SetValue(player, 20);
            Console.WriteLine(dfd.GetValue(player));


            FieldInfo PosX = playerT.GetField("PosX");
            PosX.SetValue(player, 10);
            Console.WriteLine(PosX.GetValue(player));


            FieldInfo PosY = playerT.GetField("PosY");
            PosY.SetValue(player, 5);
            Console.WriteLine(PosY.GetValue(player));

        }
    }
}
