using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;

namespace LINQSAMRAB
{
    class MainClass
    {
        /// <summary>
        /// Сортировка после применения фильтров
        /// </summary>
        /// <param name="products">Отфильтрованный массив данных</param>
        public static void SortAfterSort(IEnumerable<Product> products)
        {
            int res;
            Console.WriteLine("\n1. По стоимости (по возрастанию)\n" +
                              "2. По дате поставки(от более ближайшей до более старшей)\n" +
                              "3. По названию продукта(в лексикографическом порядке по возрастанию)\n");

            while (true)
            {
                Console.WriteLine("Выберите нужную сортировку:\n");
                if (!int.TryParse(Console.ReadLine(), out res) || res < 1 || res > 3)
                    Console.WriteLine("\nВведи подходящее значение");
                else
                    break;
            }

            if (res == 1)
            {
                var sortedproducts = from t in products
                                     orderby (t.cost)
                                     select t;
                foreach (var item in sortedproducts)
                {
                    Console.WriteLine(item);
                }

                Console.WriteLine("\nНажмите ESC для выхода или ENTER для повтора");
            }
            if (res == 2)
            {
                var sortedproducts = from t in products
                                     orderby t.deliveryDate descending 
                                     select t;
                foreach (var item in sortedproducts)
                {
                    Console.WriteLine(item);
                }

                Console.WriteLine("\nНажмите ESC для выхода или ENTER для повтора");
            }
            if (res == 3)
            {
                var sortedproducts = from t in products
                                     orderby (t.name)
                                     select t;
                foreach (var item in sortedproducts)
                {
                    Console.WriteLine(item);
                }

                Console.WriteLine("\nНажмите ESC для выхода или ENTER для повтора");
            }

        }




        /// <summary>
        /// Главное меню с сортировками
        /// </summary>
        /// <param name="products">Массив продуктов</param>
        public static void MainMenu(List<Product> products)
        {
            int res;

            Console.WriteLine("Вы можете выбрать разные типы фильтровки предстаавленных товаров!\n" +
                "1. По типу продукта\n" +
                "2. По стоимости продукта(все три варианта <, ==, >)\n" +
                "3. По поставщику\n" +
                "4. По дате поставки\n" +
                "5. По названию продукта");

            while (true)
            {
                Console.WriteLine("Выберите нужную фильтрацию:\n");
                if (!int.TryParse(Console.ReadLine(), out res) || res < 1 || res > 5)
                    Console.WriteLine("\nВведи подходящее значение");
                else
                    break;
            }

            if (res == 1) // 1 сортировка
            {
                Console.WriteLine("Введите тип товара:");
                string typeofproduct = Console.ReadLine();
                Console.WriteLine();
                var sortedproducts = from t in products
                                     where (t.type == typeofproduct)
                                     select t;
                foreach (var item in sortedproducts)
                {
                    Console.WriteLine(item);
                }
                if (sortedproducts.Count() == 0) // Если нет подходящих товаров, говорим об этом
                {
                    Console.WriteLine("Товаров такого типа нет!");
                    Console.WriteLine("\nНажмите ESC для выхода или ENTER для повтора");
                }
                else
                {
                    SortAfterSort(sortedproducts);
                }
            }
            if (res == 2) // 2 сортировка
            {
                int res1;

                Console.WriteLine("\nПо какому принципу фильтровать?\n" +
                    "1. По возрастанию цены\n" +
                    "2. По убыванию цены\n" +
                    "3. По равенству цены\n");

                while (true)
                {
                    Console.WriteLine("Выберите нужную фильтрацию:\n");
                    if (!int.TryParse(Console.ReadLine(), out res1) || res1 < 1 || res1 > 5)
                        Console.WriteLine("\nВведи подходящее значение");
                    else
                        break;
                }

                if (res1 == 1)
                {
                    var sortedproducts = from t in products
                                         orderby t.cost
                                         select t;
                    foreach (var item in sortedproducts)
                    {
                        Console.WriteLine(item);
                    }
                    SortAfterSort(sortedproducts);
                }
                if (res1 == 2)
                {
                    var sortedproducts = from t in products
                                         orderby t.cost descending
                                         select t;
                    foreach (var item in sortedproducts)
                    {
                        Console.WriteLine(item);
                    }
                    SortAfterSort(sortedproducts);
                }
                if (res1 == 3)
                {
                    double cost1;

                    while (true)
                    {
                        Console.WriteLine("Введи цену для фильтрации:\n");
                        if (!double.TryParse(Console.ReadLine(), out cost1))
                            Console.WriteLine("\nВведи подходящее значение");
                        else
                            break;
                    }

                    var sortedproducts = from t in products
                                         where (t.cost == cost1)
                                         select t;
                    foreach (var item in sortedproducts)
                    {
                        Console.WriteLine(item);
                    }
                    if (sortedproducts.Count() == 0) // Если нет подходящих товаров, говорим об этом
                    {
                        Console.WriteLine("Нет подходящих элементов");
                        Console.WriteLine("\nНажмите ESC для выхода или ENTER для повтора");
                    }
                    else
                    {
                        SortAfterSort(sortedproducts);
                    }
                }

            }
            if (res == 3) // 3 сортировка
            {
                Console.WriteLine("Введите имя поставщика");
                string suppliername = Console.ReadLine();
                Console.WriteLine();
                var sortedproducts = from t in products
                                     where (t.supplier == suppliername)
                                     select t;
                foreach (var item in sortedproducts)
                {
                    Console.WriteLine(item);
                }
                if (sortedproducts.Count() == 0) // Если нет подходящих товаров, говорим об этом
                {
                    Console.Write("Товаров с таким поставщиком нет!");
                    Console.WriteLine("\nНажмите ESC для выхода или ENTER для повтора");
                }
                else
                {
                    SortAfterSort(sortedproducts);
                }

            }
            if (res == 4) // 4 сортировка
            {
                Console.WriteLine("Введите дату поставки");
                string dateofdelivery = Console.ReadLine();
                Console.WriteLine();
                var sortedproducts = from t in products
                                     where (t.deliveryDate == DateTime.Parse(dateofdelivery))
                                     select t;
                foreach (var item in sortedproducts)
                {
                    Console.WriteLine(item);
                } 
                if (sortedproducts.Count() == 0) // Если нет подходящих товаров, говорим об этом
                {
                    Console.Write("Товаров с такой датой поставки нет!");
                    Console.WriteLine("\nНажмите ESC для выхода или ENTER для повтора");
                }
                else
                {
                    SortAfterSort(sortedproducts);
                }
            }
            if (res == 5) // 5 сортировка
            {
                Console.WriteLine("Введите имя продукта");
                string nameofproduct = Console.ReadLine();
                Console.WriteLine();
                var sortedproducts = from t in products
                                     where (t.name == nameofproduct)
                                     select t;
                foreach (var item in sortedproducts)
                {
                    Console.WriteLine(item);
                }
                if (sortedproducts.Count() == 0) // Если нет подходящих товаров, говорим об этом
                {
                    Console.WriteLine("Товаров с таким именем нет!");
                    Console.WriteLine("\nНажмите ESC для выхода или ENTER для повтора");
                }
                else
                {
                    SortAfterSort(sortedproducts);
                }
            }
        }




        /// <summary>
        /// Метод, считывающий по строкам информацию из CSV файла
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        /// <returns>В результате работы возвращает массив строк</returns>
        public static List<Product> ReadCSV(string path)
        {
            List<Product> products = new List<Product>(); // Сюда записываем наши продукты
            string line;

            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    sr.ReadLine(); // Пропускаем первую строку с названием столбцов

                    while (!sr.EndOfStream)
                    {
                        line = sr.ReadLine();
                        string[] lines = line.Split(';');

                        foreach (var item in lines) // Проверяем, что в ячейках нет пропусков
                        {
                            if (item == "")
                                throw new ArgumentException("В таблице не должно быть пропусков!");
                        }

                        products.Add(new Product(lines[0], lines[1], double.Parse(lines[2]), lines[3], DateTime.Parse(lines[4])));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return products;
        }


        public static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;
            bool isread = false;
            List<Product> products = new List<Product>();

            
            do
            {
                Console.WriteLine("Укажите путь к файлу:");
                string path = Console.ReadLine();
                if (File.Exists(path)) // Проверка на правильность введенного пути к файлу
                {
                    products = ReadCSV(path);
                    isread = true;
                }
                else
                    Console.WriteLine("Укажите правильный путь к файлу!\n");
            }
            while (!isread);

            try
            {
                do
                {
                    Console.Clear();
                    MainMenu(products); // Вызов главного меню
                }
                while (Console.ReadKey().Key != ConsoleKey.Escape);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
