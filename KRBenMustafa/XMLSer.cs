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
    public static class XMLSer<T>
    {
        /// <summary>
        /// Сериализует в XML формате.
        /// Нужен конструктор БЕЗ ПАРАМЕТРОВ, сериализуем только открытые члены, класс - public, атрибут [Serializable]
        /// </summary>
        /// <param name="path"></param>
        /// <param name="ObjToSer"></param>
        public static void XMLSerializer(string path, T ObjToSer)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(T));

            try
            {
                using (FileStream fs = new FileStream(path, FileMode.Create))
                {
                    formatter.Serialize(fs, ObjToSer);
                }

                Console.WriteLine("Файл успешно сериализован!");

            }
            catch (IOException)
            {
                Console.WriteLine("Проблемы с файлом при XML сериализации...");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Десериализует XML.
        /// </summary>
        /// <param name="path">Путь к файлу с сериализованными объектами</param>
        public static T XMLDeserializer(string path)
        {
            T ObjToDeser = default;

            try
            {
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                {
                    XmlSerializer formatter = new XmlSerializer(typeof(T));

                    ObjToDeser = (T)formatter.Deserialize(fs);
                }

                Console.WriteLine("Файл успешно десериализован!");

            }
            catch (IOException)
            {
                Console.WriteLine("Проблемы с файлом при XML десериализации...");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return ObjToDeser;
        }
    }
}
