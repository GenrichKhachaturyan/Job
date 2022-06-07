using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace TaskManager
{
    class Program
    {


        static Process[] procList = Process.GetProcesses();



        static void Main(string[] args)
        {


            ShowMenu();

        }



        public static void ShowMenu()
        {

            while (true)
            {
                Console.WriteLine("============Домашняя работа №6============");
                Console.WriteLine("1 - Вывести на экран список всех процессов");
                Console.WriteLine("2 - Завершить работу процесса [по ID]");
                Console.WriteLine("3 - Завершить работу процесса [по имени]\n");
                Console.WriteLine("0 - завершение работы программы");
                Console.WriteLine("==========================================");
                Console.Write("Пожалуйста, выберите пункт меню: ");

                if (int.TryParse(Console.ReadLine(), out int num))
                {


                    if(num < 0 || num > 3)
                    {
                        Console.WriteLine("Вы ввели некорректный номер задания!");
                        Console.ReadKey(true);
                        Console.Clear();
                    }
                    switch (num)
                    {
                        case 0:
                            Console.WriteLine("Завершение работы приложения ...");
                            return;
                        case 1:
                            ShowProcess();
                            break;
                        case 2:
                            KillProcByID();
                            break;
                        case 3:
                            KillProcByName();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Вы ввели неккоректные значения!");
                    Console.ReadKey(true);
                    Console.Clear();
                }

            }

        }

        public static void ShowProcess()
        {
            foreach (Process proc in procList)
            {
                Console.WriteLine($"{proc.Id} {proc.ProcessName}");
            }
        }

        public static void KillProcByName()
        {

            Console.Write("Введите имя процесса который хотитете остановить: ");
            string name = Console.ReadLine();
            try
            {
                procList.First(p => p.ProcessName == name).Kill();
                Console.WriteLine($"Процес {name} остановлен!");
                Console.ReadKey(true);
                Console.Clear();

            }
            catch (InvalidOperationException)
            {
                Console.WriteLine($"Процесс {name} не найден!");
                Console.ReadKey(true);
                Console.Clear();
            }


        }

        public static void KillProcByID()
        {
            Console.Write("Введите ID процесса который хотитете остановить: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                try
                {
                    procList.First(p => p.Id == id).Kill();
                    Console.WriteLine($"Процесс  под id[{id}] остановлен!");
                    Console.ReadKey(true);
                    Console.Clear();

                }
                catch 
                {
                    Console.WriteLine($"Процесс под id[{id}] не найден!");
                    Console.ReadKey(true);
                    Console.Clear();
                }

            }
            else
            {
                Console.WriteLine("Введен не корректный ID");
                Console.Clear();
            }


        }

    }

}
