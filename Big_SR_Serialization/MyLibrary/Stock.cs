using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;

namespace MyLibrary
{
    [Serializable]
    [DataContract]
    public class Stock
    {
        public List<Item> allitems = new List<Item>();
        List<Item> gruz = new List<Item>();
        List<Item> airplane = new List<Item>();
        List<Item> korabl = new List<Item>();

        List<Item> gruz2 = new List<Item>();
        List<Item> airplane2 = new List<Item>();
        List<Item> korabl2 = new List<Item>();

        public Stock(List<Item> items)
        {
            allitems = items; // Получаем общий список всех товаров
        }

        /// <summary>
        /// Сериализация в ХМL
        /// </summary>
        /// <param name="items"></param>
        /// <param name="path">Путь к файлу</param>
        public static void XMLSer(List<Item> items, string path)
        {
            try
            {
                XmlSerializer format = new XmlSerializer(typeof(List<Item>));

                using (FileStream bas = new FileStream(path, FileMode.Create))
                {
                    format.Serialize(bas, items);
                }
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Argument null Exception");
            }
            catch (System.Security.SecurityException)
            {
                Console.WriteLine("Security exception");
            }
            catch (IOException)
            {
                Console.WriteLine("IOException");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine($"Выполнена запись в файл {path}");
        }

        /// <summary>
        /// Бинарная сериализация
        /// </summary>
        /// <param name="items"></param>
        /// <param name="path">Путь к файлу</param>
        public static void BinarySer(List<Item> items, string path)
        {
            try
            {
                BinaryFormatter format = new BinaryFormatter();

                using (FileStream bas = new FileStream(path, FileMode.Create))
                {
                    format.Serialize(bas, items);
                }
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Argument null Exception");
            }
            catch (System.Security.SecurityException)
            {
                Console.WriteLine("Security exception");
            }
            catch (IOException)
            {
                Console.WriteLine("IOException");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine($"Выполнена запись в файл {path}");

        }

        /// <summary>
        /// JSON сериализация
        /// </summary>
        /// <param name="items"></param>
        /// <param name="path">Путь к файлу</param>
        public static void JSONSer(List<Item> items, string path)
        {
            DataContractJsonSerializer formater = new DataContractJsonSerializer(typeof(List<Item>));

            try
            {
                using (FileStream bas = new FileStream(path, FileMode.Create))
                {
                    formater.WriteObject(bas, items);
                }
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Argument null Exception");
            }
            catch (System.Security.SecurityException)
            {
                Console.WriteLine("Security exception");
            }
            catch (IOException)
            {
                Console.WriteLine("IOException");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine($"Выполнена запись в файл {path}");
        }

        /// <summary>
        /// Бинарная десериализация
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        public static List<Item> BinaryDeSer(string path)
        {
            List<Item> gruz2 = new List<Item>();
            try
            {
                BinaryFormatter format = new BinaryFormatter();

                using (FileStream bas = new FileStream(path, FileMode.Open))
                {
                    while (true)
                    {
                        try
                        {
                            gruz2 = (List<Item>)format.Deserialize(bas);
                            foreach (var item in gruz2)
                            {
                                Console.WriteLine(item.ToString());
                            }
                        }
                        catch (Exception)
                        {
                            return gruz2;
                        }
                    }
                }
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Argument null Exception");
            }
            catch (System.Security.SecurityException)
            {
                Console.WriteLine("Security exception");
            }
            catch (IOException)
            {
                Console.WriteLine("IOException");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return gruz2;
        }

        /// <summary>
        /// ХМL десериализация
        /// </summary>
        /// <param name="korabl2"></param>
        /// <param name="path">Путь к файлу</param>
        public static List<Item> XMLDeSer(string path)
        {
            XmlSerializer format = new XmlSerializer(typeof(List<Item>));
            List<Item> korabl2 = new List<Item>();
            try
            {
                using (FileStream bas = new FileStream(path, FileMode.Open))
                {
                    while (true)
                    {
                        try
                        {
                            korabl2 = (List<Item>)format.Deserialize(bas);
                            foreach (var item in korabl2)
                            {
                                Console.WriteLine(item.ToString());
                            }
                        }
                        catch (Exception)
                        {
                            return korabl2;
                        }
                    }
                }
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Argument null Exception");
            }
            catch (System.Security.SecurityException)
            {
                Console.WriteLine("Security exception");
            }
            catch (IOException)
            {
                Console.WriteLine("IOException");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return korabl2;
        }

        /// <summary>
        /// JSON десериализация
        /// </summary>
        /// <param name="airplane2"></param>
        /// <param name="path">Путь к файлу</param>
        public static List<Item> JSONDeSer(string path)
        {
            DataContractJsonSerializer formater = new DataContractJsonSerializer(typeof(List<Item>));
            List<Item> airplane2 = new List<Item>();

            try
            {
                using (FileStream fs = new FileStream(path, FileMode.Open))
                {
                    while (true)
                    {
                        try
                        {
                            airplane2 = (List<Item>)formater.ReadObject(fs); ;
                        }
                        catch (Exception)
                        {
                            return airplane2;
                        }
                    }
                }
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Argument null Exception");
            }
            catch (System.Security.SecurityException)
            {
                Console.WriteLine("Security exception");
            }
            catch (IOException)
            {
                Console.WriteLine("IOException");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return airplane2;
        }

        public void SendItems()
        {
            // Рассортировываем товары по разным листам
            for (int i = 0; i < allitems.Count; i++)
            {
                if (allitems[i].Weight < 5)
                    gruz.Add(allitems[i]); // Отправляем в грузовик
                else if (allitems[i].Weight < 100)
                    korabl.Add(allitems[i]); // Отправляем в корабль
                else
                    airplane.Add(allitems[i]); // Отправляем в самолет
            }

            // Процесс сериализации
            BinarySer(gruz, "BINdoc.txt");
            XMLSer(korabl, "XMLdoc.txt");
            JSONSer(airplane, "JSONdoc.txt");
        }

        public void ReceiveItems()
        {
            // Процесс десериализации
            gruz2 = BinaryDeSer("BINdoc.txt");
            korabl2 = XMLDeSer("XMLdoc.txt");
            airplane2 = JSONDeSer("JSONdoc.txt");

            // Создание нового списка из десериализованных объектов
            allitems = new List<Item>();
            allitems.AddRange(gruz2);
            allitems.AddRange(korabl2);
            allitems.AddRange(airplane2);
        }
    }
}
