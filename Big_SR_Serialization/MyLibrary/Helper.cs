using System;
namespace MyLibrary
{
    public static class Helper
    {
        public static Random rnd = new Random();

        /// <summary>
        /// Метод, генерирующий имена из латинских букв
        /// </summary>
        /// <param name="length">Длина имени</param>
        /// <returns>Сгенерированное имя</returns>
        public static string RandomName(int length)
        {
            string name = "";

            for (int i = 0; i < length; i++)
            {
                name += (i == 0) ? (char)rnd.Next(65, 91) : (char)rnd.Next(97, 123);
            }

            return name;
        }

        /// <summary>
        /// Метод, с вероятностью 0.3 возвращающий тру для антибиотика
        /// </summary>
        /// <returns>True или False</returns>
        public static bool IsAntibio()
        {
            if (rnd.Next(0, 10) > 2)
                return false;
            return true;
        }
    }
}
