using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Text.Json;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.IO;

namespace KRBenMustafa
{
    public static class BINSer<T>
    {
        /// <summary>
        /// Бинарная сериализация
        /// Атрибуты [Serializable], [NonSerialized]. 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="ObjToSer"></param>
        public static void BINSerializer(string path, T ObjToSer)
        {
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();

                using (FileStream fs = new FileStream(path, FileMode.Create))
                {
                    formatter.Serialize(fs, ObjToSer);
                }

                Console.WriteLine("Файл успешно сериализован!");

            }
            catch (IOException)
            {
                Console.WriteLine("Проблемы с файлом при BIN сериализации...");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Бинарная десериализация
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        /// <returns>Возвращает десериализованный объект</returns>
        public static T BINDeserializer(string path)
        {
            T ObjToDeser = default;

            try
            {
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                {
                    BinaryFormatter formatter = new BinaryFormatter();

                    ObjToDeser = (T)formatter.Deserialize(fs);
                }

                Console.WriteLine("Файл успешно десериализован!");

            }
            catch (IOException)
            {
                Console.WriteLine("Проблемы с файлом при BIN десериализации...");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return ObjToDeser;
        }
    }
}
