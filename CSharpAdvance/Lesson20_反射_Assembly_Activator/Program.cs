using System;
using System.Reflection;
using System.Threading;

namespace Lesson20_反射_Assembly_Activator
{
    class Program
    {
        static void Main(string[] args)
        {
            //加载其他文件下的程序集
            Assembly assem = Assembly.LoadFrom(@"C:\Users\RayData\source\repos\CSharpLessons\CSharpAdvance\Lesson18_多线程\bin\Debug\netcoreapp3.1\Lesson18_多线程");
            //获取所有该程序集中的类并打印
            Type[] types = assem.GetTypes();
            for (int i = 0; i < types.Length; i++)
            {
                Console.WriteLine(types[i]);
            }

            //实例化一个box
            Type boxType = assem.GetType("Lesson18_多线程.Box");
            //打印所有成员，找到构造函数来实例化对象
            MemberInfo[] members = boxType.GetMembers();
            for (int i = 0; i < members.Length; i++)
            {
                Console.WriteLine(members[i]);
            }
            //获取构造函数参数中的枚举类型
            Type moveDir = assem.GetType("Lesson18_多线程.E_dir");
            //获取枚举值，也相当于枚举类型的变量
            FieldInfo right = moveDir.GetField("Right");
            object boxObj =  Activator.CreateInstance(boxType, 10, 5, right.GetValue(null));

            MethodInfo clear = boxType.GetMethod("Clear");
            MethodInfo move = boxType.GetMethod("Move");
            MethodInfo print = boxType.GetMethod("Print");

            Console.Clear();
            Console.CursorVisible = false;
            //运行程序
            //while (true)
            //{
            //    Thread.Sleep(1000);
            //    clear.Invoke(boxObj,null);
            //    move.Invoke(boxObj, null);
            //    print.Invoke(boxObj, null);
            //}

            Test t = new Test();
            Type testT = t.GetType();
        }
    }
    class Test
    {

    }
}
