using System;
using System.IO;
using StoreLib;
using System.Collections;
using System.Collections.Generic;

namespace Iterators_SR
{
    class MainClass
    {
        public static Store store;
        public static Store Box = new Store();
        public static string path = "Sample.csv";
        public static bool productsinbox = false;
        public static bool isfilteredbytype = false;


        public static void Main()
        {
            do
            {
                Console.OutputEncoding = System.Text.Encoding.UTF8;
                store = ReadCSV(path);
                MenuView();
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);

        }



        /// <summary>
        /// Чтение Csv файла
        /// </summary>
        /// <param name="path">путь к файлу</param>
        /// <returns>возвращает массив с продуктами</returns>
        public static Store ReadCSV(string path)
        {
            Store store1 = new Store();
            string line;

            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    int i = 0;
                    while (!((line = sr.ReadLine()) == null))
                    {
                        string[] lines = line.Split(';');

                        if (lines[i] == "Beer")
                        {
                            store1.Add(new Beer(lines[i + 1], float.Parse(lines[i + 2].Replace('.', ','))));
                        }
                        else if (lines[i] == "Milk")
                        {
                            store1.Add(new Milk(lines[i + 1], float.Parse(lines[i + 2].Replace('.', ','))));
                        }
                        else if (lines[i] == "Potato")
                        {
                            store1.Add(new Potato(lines[i + 1], float.Parse(lines[i + 2].Replace('.', ','))));
                        }
                        else if (lines[i] == "Rediska")
                        {
                            store1.Add(new Rediska(lines[i + 1], float.Parse(lines[i + 2].Replace('.', ','))));
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\nПерепроверь файл, ошибка в обработке файла");
                Environment.Exit(0);
            }
            return store1;
        }



        /// <summary>
        /// Фильтрация продуктов по цене
        /// </summary>
        public static Store FilterByPrice()
        {
            first:
            Console.WriteLine("Введи левую границу фильтра : ");
            if (!int.TryParse(Console.ReadLine(), out int left))
            {
                Console.WriteLine("Слабо набрать число?");
                goto first;// повтор ввода числа
            }
            Console.WriteLine("Введи правую границу фильтра : ");
            if (!int.TryParse(Console.ReadLine(), out int right))
            {
                Console.WriteLine("Слабо набрать число?");
                goto first;// повтор ввода числа
            }
            Store tmp = new Store();
            Console.WriteLine("Список товаров, подходящих под фильтр : ");
            bool isany = false;
            foreach (Item item in store)
            {
                if (item.GetCost(1.5f) >= left && item.GetCost(1.5f) <= right)
                {
                    Console.WriteLine(item.ToString());
                    tmp.Add(item);
                    isany = true;
                }
            }

            if (isany == false) { Console.WriteLine("Нет товаров, удовлетворяющих условию!\n"); MenuView(); }

            return tmp;
        }



        /// <summary>
        /// Добавление продуктов в корзину
        /// </summary>
        /// <param name="box">корзина</param>
        /// <param name="store">список продуктов</param>
        /// <param name="productsinbox">проверка, что продукты добавлены</param>
        public static void ViborProducta(ref Store box, Store store, ref bool productsinbox)
        {
            Console.WriteLine("Выберете продукт, который хотите добавить\n");

            int i = 1;
            foreach (var item in store)
            {
                Console.WriteLine(i + ". " + item.ToString());
                ++i;
            }

            third:
            Console.WriteLine();

            if (!int.TryParse(Console.ReadLine(), out int input))
            {
                Console.WriteLine("Слабо набрать подходящее число?");
                goto third; // повтор ввода числа
            }

            try
            {
                box.Add(store[input - 1]);
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Слабо набрать подходящее число?");
                goto third;
            }
            productsinbox = true;
            Console.WriteLine("Товар успешно добавлен в корзину");
        }



        /// <summary>
        /// Фильтрация продуктов по типу
        /// </summary>
        public static Store FilterByType(ref bool isfilteredbytype)
        {
            if (isfilteredbytype == true)
            {
                Console.WriteLine("\nФильтрация по типу уже была применена!\n");
                Console.WriteLine("Esc - завершить программу\nEnter - продолжить работу\n");
                if (Console.ReadKey().Key == ConsoleKey.Escape)
                    Environment.Exit(0);
                else
                {
                    Console.Clear();
                    MenuView();
                }
            }
            second:
            Store tmp = new Store();
            Console.Clear();
            Console.WriteLine("Выберете нужный тип товара : \n" +
                "1. Beer\n" +
                "2. Milk\n" +
                "3. Potato\n" +
                "4. Rediska\n");

            if (!int.TryParse(Console.ReadLine(), out int input) || input < 1 || input > 4)
            {
                Console.WriteLine("Слабо набрать подходящее число?");
                goto second;// повтор ввода числа
            }

            Console.WriteLine("Перечень подходящих товаров : ");

            if (input == 1)
            {
                Console.WriteLine(store[3].ToString());
                Console.WriteLine(store[5].ToString());
                Console.WriteLine(store[8].ToString());
                tmp.Add(store[3]);
                tmp.Add(store[5]);
                tmp.Add(store[8]);
                isfilteredbytype = true;
            }
            if (input == 2)
            {
                Console.WriteLine(store[2].ToString());
                Console.WriteLine(store[6].ToString());
                tmp.Add(store[2]);
                tmp.Add(store[6]);
                isfilteredbytype = true;
            }
            if (input == 3)
            {
                Console.WriteLine(store[0].ToString());
                Console.WriteLine(store[4].ToString());
                tmp.Add(store[0]);
                tmp.Add(store[4]);
                isfilteredbytype = true;
            }
            if (input == 4)
            {
                Console.WriteLine(store[1].ToString());
                Console.WriteLine(store[7].ToString());
                tmp.Add(store[1]);
                tmp.Add(store[7]);
                isfilteredbytype = true;
            }

            return tmp;
        }



        /// <summary>
        /// Показ меню
        /// </summary>
        public static void MenuView()
        {
            Console.WriteLine("Выберете нужный пункт : \n" +
                "1. Отфильтровать по стоимости\n" +
                "2. Отфильтровать по типу\n" +
                "3. Добавить товар в корзину\n" +
                "4. Вывести общую стоимость корзины\n" +
                "5. Вывести содержимое корзины\n" +
                "6. Опустошить корзину\n");

            if (!int.TryParse(Console.ReadLine(), out int input) || input < 1 || input > 6)
            {
                Console.WriteLine("Слабо набрать подходящее число?");
                MenuView();
            }

            switch (input)
            {
                case 1:
                    store = FilterByPrice();
                    Console.WriteLine("\nEsc - завершить программу\nEnter - продолжить работу\n");
                    if (Console.ReadKey().Key == ConsoleKey.Escape)
                        Environment.Exit(0);
                    else
                    {
                        Console.Clear();
                        MenuView();
                    }
                    break;

                case 2:
                    store = FilterByType(ref isfilteredbytype);
                    foreach (var item in store)
                    {
                        item.ToString();
                    }
                    Console.WriteLine("\nEsc - завершить программу\nEnter - продолжить работу\n");
                    if (Console.ReadKey().Key == ConsoleKey.Escape)
                        Environment.Exit(0);
                    else
                    {
                        Console.Clear();
                        MenuView();
                    }
                    break;

                case 3:
                    Console.WriteLine("\nЗдесь список продуктов ПОСЛЕ фильтрации: \n");
                    ViborProducta(ref Box, store, ref productsinbox);
                    Console.WriteLine("\nEsc - завершить программу\nEnter - продолжить работу\n");
                    if (Console.ReadKey().Key == ConsoleKey.Escape)
                        Environment.Exit(0);
                    else
                    {
                        Console.Clear();
                        MenuView();
                    }
                    break;

                case 4:
                    float sum = 0;
                    foreach (Item item in Box)
                    {
                        sum += item.GetCost(1.5f);
                    }
                    Console.WriteLine($"Общая стоимость корзины : {sum}");
                    Console.WriteLine("\nEsc - завершить программу\nEnter - продолжить работу\n");
                    if (Console.ReadKey().Key == ConsoleKey.Escape)
                        Environment.Exit(0);
                    else
                    {
                        Console.Clear();
                        MenuView();
                    }
                    break;

                case 5:
                    if (productsinbox == false) Console.WriteLine("Корзина пуста!");
                    foreach (var item in Box)
                    {
                        Console.WriteLine(item.ToString());
                    }
                    Console.WriteLine("\nEsc - завершить программу\nEnter - продолжить работу\n");
                    if (Console.ReadKey().Key == ConsoleKey.Escape)
                        Environment.Exit(0);
                    else
                    {
                        Console.Clear();
                        MenuView();
                    }
                    break;

                case 6:
                    Box = new Store();
                    Console.WriteLine("Корзина очищена!\n");
                    Console.WriteLine("\nEsc - завершить программу\nEnter - продолжить работу\n");
                    if (Console.ReadKey().Key == ConsoleKey.Escape)
                        Environment.Exit(0);
                    else
                    {
                        Console.Clear();
                        MenuView();
                    }
                    break;
            }
        }
    }
}
