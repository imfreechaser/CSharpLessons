using System;

namespace Lesson17_协变逆变
{
    class Program
    {
        delegate T TestOut<out T>();
        delegate void TestIn<in T>(T value);

        static void Main(string[] args)
        {
            //协变
            TestOut<Derived> OD = () =>
            {
                return new Derived();
            };
            TestOut<Base> OB = OD;
            Base baseVar = OB();
            //逆变
            TestIn<Base> IB = (a) =>
            {

            };
            TestIn<Derived> ID = IB;
            ID(new Derived());

        }
        public void Test()
        {

        }
    }
    class Base
    {

    }
    class Derived : Base
    {

    }
}
