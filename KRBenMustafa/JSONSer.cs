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
    public static class JSONSer<T>
    {
        /// <summary>
        /// Сериализация в формат JSON
        /// Сериализуются публичные свойства.
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        /// <param name="ObjToSer">Объект для сериализации</param>
        public static void JSONSerializer(string path, T ObjToSer)
        {
            try
            {
                string SerStr = JsonSerializer.Serialize(ObjToSer);

                using (StreamWriter sw = new StreamWriter(path, false))
                {
                    sw.Write(SerStr);
                }

                Console.WriteLine("Файл успешно сериализован!");
            }
            catch (IOException)
            {
                Console.WriteLine("Проблемы с файлом при JSON сериализации...");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// JSON десериализация.
        /// Для ДЕсериализации нужен конструктор БЕЗ параметров.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static T JSONDeserializer(string path)
        {
            T ObjToDeser = default;

            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string DeserStr = sr.ReadToEnd();
                    ObjToDeser = JsonSerializer.Deserialize<T>(DeserStr);
                }

                Console.WriteLine("Файл успешно десериализован!");
            }
            catch (IOException)
            {
                Console.WriteLine("Проблемы с файлом при JSON десериализации...");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return ObjToDeser;
        }


    }
}
