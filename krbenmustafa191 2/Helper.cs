using System;
using System.Collections.Generic;
using PetLib;
using System.IO;

namespace krbenmustafa191
{
    public static class Helper
    {
        /// <summary>
        /// Метод, в котором генерируется случайное имя для питомца
        /// </summary>
        /// <param name="minlength">Минимальная длина имени</param>
        /// <param name="maxlength">Максимальная длина имени</param>
        /// <returns>Возвращает сгенерированное имя</returns>
        public static string RandomName(int minlength, int maxlength)
        {
            Random rnd = new Random();
            int length = rnd.Next(minlength, maxlength + 1);
            string name = "";

            for (int i = 0; i < length; i++)
            {
                name += i == 0 ? (char)rnd.Next(65, 91) : (char)rnd.Next(97, 123);
            }

            return name;
        }

        /// <summary>
        /// Метод для записи информации о питомцах в файл
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        /// <param name="listofpets">Список питомцев</param>
        public static void InputToFile(string path, List<Ipet> listofpets)
        {
            using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Unicode))
            {
                foreach (var item in listofpets)
                {
                    sw.WriteLine(item);
                }
            }
        }
    }
}
