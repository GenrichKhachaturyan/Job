using System;

namespace Homework_1
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.Write("Введите ваше имя: ");

            string name = Console.ReadLine();
            DateTime time = DateTime.Now;

            Console.WriteLine($"Привет,{name},сегодня {time}");


        }
    }
}
