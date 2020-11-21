using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using PetLib;

// Бен Мустафа Анас
// БПИ191
// Вариант 1

namespace krbenmustafa191
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8; // Чтобы русские символы выводились на консоль(на маке с этим проблема)

            Random rnd = new Random();
            List<Ipet> listofpets = new List<Ipet>(); // Список из питомцев

            for (int i = 0; i < 40; i++) // 40 раз пытаемся создать объекты классов
            {
                try
                {
                    string name = Helper.RandomName(2, 14); // Генерация имени

                    double mass = rnd.NextDouble() * (20) - 5; // Генерация массы

                    if (rnd.Next(2) == 1) // С равной вероятностью создаем объекты Cat и Dog
                    {
                        Cat cat = new Cat(name, mass);
                        listofpets.Add(cat);
                        Console.WriteLine(cat); // Выводим информацию о созданном объекте кота
                    }
                    else
                    {
                        Dog dog = new Dog(name, mass);
                        listofpets.Add(dog);
                        Console.WriteLine(dog); // Выводим информацию о созданном объекте кота
                    }
                }
                catch (PetException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }


            // Сортировка через реализованный IComparable<IPet>
            listofpets.Sort((x, y) => x.CompareTo(y));
            try
            {
                Helper.InputToFile("2PetsByIComparable.txt", listofpets);
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


            // Лесографическая сортировка кличек по возрастанию
            listofpets.Sort((x, y) => x.Name.CompareTo(y.Name));
            try
            {
                Helper.InputToFile("3PetsByName.txt", listofpets);
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


            // Сортировка по группам объектов
            listofpets.Sort(delegate(Ipet x, Ipet y)
            {
                return (x is Cat && y is Dog ? 1 : x is Dog && y is Cat ? -1 : x.CompareTo(y));
            });
            try
            {
                Helper.InputToFile("4PetsByTypeAndIcomparable.txt", listofpets);
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
