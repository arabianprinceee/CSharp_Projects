using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using MyLibrary;
using System.Threading;

namespace SRSerialization
{
    class MainClass
    {
        public static Random rnd = new Random();

        public static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            do
            {
                Console.Clear();
                List<Item> items = new List<Item>();
                RandomDateTime randomDate = new RandomDateTime();

                for (int i = 0; i < 100; i++)
                {
                    int choice = rnd.Next(0, 3);
                    try
                    {
                        // Равновероятностное создание объектов разных типов
                        if (choice == 0)
                        {
                            items.Add(new Cake(Helper.RandomName(rnd.Next(5, 15)), rnd.Next(0, 100001), rnd.Next(0, 201), randomDate.Next())); ;
                        }
                        else if (choice == 1)
                        {
                            items.Add(new Electronics(Helper.RandomName(rnd.Next(5, 15)), rnd.Next(0, 100001), rnd.Next(0, 201), 14.1 * rnd.NextDouble() + 0.9));
                        }
                        else
                        {
                            items.Add(new Medicine(Helper.RandomName(rnd.Next(5, 15)), rnd.Next(0, 100001), rnd.Next(0, 201), Helper.IsAntibio()));
                        }
                    }
                    catch (NullReferenceException)
                    {
                        Console.WriteLine("NullReferenceException found...");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                try
                {
                    Stock stock = new Stock(items);

                    Console.WriteLine("Список созданных объектов: \n");
                    Thread.Sleep(1000);
                    foreach (var item in items)
                    {
                        Console.WriteLine(item.ToString());
                    }

                    stock.SendItems(); // Отправка (сериализация) объектов
                    items = null;

                    Stock stock1 = new Stock(items); // Создание нового склада

                    Console.WriteLine("\n\nРезультат десериализации:\n");
                    Thread.Sleep(1500);
                    stock1.ReceiveItems(); // Получение (десериализация) объектов

                    SuperMarket superMarket = new SuperMarket();
                    OnlineStore onlineStore = new OnlineStore();
                    Mall mall = new Mall();


                    // Распределение объектов по различным типам магазинов
                    foreach (var item in stock1.allitems)
                    {
                        if (item.GetType() == typeof(Cake))
                            superMarket.AcceptItem(item);
                        else if (item.Name.Length < 10)
                            mall.AcceptItem(item);
                        else
                            onlineStore.AcceptItem(item);
                    }

                    // Сортировка объектов в разных магазинах согласно спецификации
                    superMarket.SortItems();
                    mall.SortItems();
                    onlineStore.SortItems();

                    // Вывод всех объектов на экран
                    Console.WriteLine("\n\n\nПредметы в онлайн магазине: \n");
                    Thread.Sleep(1500);
                    for (int i = 0; i < onlineStore.Count; i++)
                    {
                        Console.WriteLine(onlineStore[i]);
                    }
                    Console.WriteLine("\n\nПредметы в торговом центре:\n");
                    Thread.Sleep(1500);
                    for (int i = 0; i < mall.Count; i++)
                    {
                        Console.WriteLine(mall[i]);
                    }
                    Console.WriteLine("\n\nПредметы в супермаркете: \n");
                    Thread.Sleep(1500);
                    for (int i = 0; i < superMarket.Count; i++)
                    {
                        Console.WriteLine(superMarket[i]);
                    }
                }
                catch (NullReferenceException)
                {
                    Console.WriteLine("NullReferenceException found...");
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("ArgumentNullException found");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                 
                Console.WriteLine("\nНажмите ESC для завершения программы или другую клавишу для нового запуска\n");
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);

        }
    }
}
