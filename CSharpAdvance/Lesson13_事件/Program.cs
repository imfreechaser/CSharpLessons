using System;

namespace Lesson13_事件
{
    class Program
    {
        static void Main(string[] args)
        {
            Heater heater = new Heater();
            Alertor alertor = new Alertor(heater);
            Screen screen = new Screen(heater);

            heater.TempOver95dgr(96f);

        }
    }
    class Heater
    {
        public delegate void BoilingInformation(float waterTemp);

        public event BoilingInformation boil;
        
        public void TempOver95dgr(float waterTemp)
        {
            if(boil != null && waterTemp > 95f)
            {
                boil.Invoke(waterTemp);
            }
        }
    }
    class Alertor
    {
        public Alertor(Heater heater)
        {
            heater.boil += AlertorWork;
        }
        public void AlertorWork(float waterTemp)
        {
            Console.WriteLine("\n语音播报：\n目前水的温度为：{0}度", waterTemp);
        }
    }
    class Screen
    {
        public Screen(Heater heater)
        {
            heater.boil += ShowBoil;
        }
        public void ShowBoil(float waterTemp)
        {
            Console.WriteLine("\n显示器显示：\n水烧开了！");
        }
    }
}
