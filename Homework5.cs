using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Linq;

namespace Homework3
{
    class MainClass
    {


        public static void Main()
        {
            ShowMenu();

        }
        /// <summary>
        /// 1. Ввести с клавиатуры произвольный набор данных и сохранить его в текстовый файл.
        /// 2. Написать программу, которая при старте дописывает текущее время в файл
        /// «startup.txt».
        /// </summary>
        /// <param name="word"></param>
        static void Saveinput()
        {
            Console.Write("Input words: ");
            string words = Console.ReadLine();
            string filename = "startup.txt";
            File.WriteAllText(filename, words);
            File.AppendAllText(filename, Environment.NewLine);
            DateTime dateNow = DateTime.Now;
            File.AppendAllText(filename , dateNow.ToString());
            Console.WriteLine("Данные успешно сохранены.");
            Console.ReadKey(true);
        }


        /// <summary>
        /// Ввести с клавиатуры произвольный набор чисел (0...255)
        /// и записать их в бинарный файл.
        /// </summary>
        static void SaveBinNum()
        {
            string filename = "numers.bin";
            Console.Write("Input numbers: ");
            string num = Console.ReadLine();
            byte[] numbers = num.Split(single, StringSplitOptions.RemoveEmptyEntries).Select(byte.Parse).ToArray();
            //Хотелось бы узнать.Есть ли возможность болеее правильной реализации стр №48
            File.WriteAllBytes(filename, numbers);
            Console.WriteLine("Данные успешно сохранены.");
            Console.ReadKey(true);
        }

        static string[] single = { " ", ",", "/", "?", ".", ";", ":", };

        /// <summary>
        /// Сохранить дерево каталогов и файлов по заданному пути в текстовый файл
        /// — с рекурсией и без.
        /// </summary>
        /// <param name="dir"></param>


        static void PrintTree(DirectoryInfo dir, string indent, bool lastDirectory)
        {
            Console.Write(indent);
            Console.Write(lastDirectory ? "└─" : "├─");
            indent += lastDirectory ? " " : "│ ";
            Console.WriteLine(dir.Name);




            DirectoryInfo[] subDirs = dir.GetDirectories();
            for (int i = 0; i < subDirs.Length; i++)
            {
                PrintTree(subDirs[i], indent, i == subDirs.Length - 1);
            }

            FileInfo[] subFiles = dir.GetFiles();
            Console.WriteLine("Файлы принадлежащие текущей дериктории");
            for (int i = 0; i < subFiles.Length; i++)
            {

                Console.WriteLine(subFiles[i]);
            }

        }




        /// <summary>
        /// Основное меню
        /// </summary>
        static void ShowMenu()
        {
            while (true)
            {
                Console.WriteLine("===========Домашняя работа №5==========");
                Console.WriteLine("1 - Задание №1");
                Console.WriteLine("2 - Задание №2");
                Console.WriteLine("3 - Задание №3\n");
                Console.WriteLine("0 - Завершить работу приложения");
                Console.WriteLine("=======================================");
                Console.Write("Введите номер задания: ");
                if (int.TryParse(Console.ReadLine(), out int num))
                {
                    switch (num)
                    {
                        case 0:
                            Console.WriteLine("Всего доброго!");
                            return;
                        case 1:
                            Saveinput();
                            break;
                        case 2:
                            SaveBinNum();
                            break;
                        case 3:
                            DirectoryInfo dir = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
                            PrintTree(dir, "", true);
                            Console.ReadKey(true);
                            break;
                        default:
                            Console.WriteLine("Вы ввели неккоректное значение!");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                    }

                }
                else
                {
                    Console.WriteLine("Вы ввели неккоректное значение!");
                    Console.ReadKey();
                    Console.Clear();
                }
                Console.Clear();

            }

        }

    }
}







