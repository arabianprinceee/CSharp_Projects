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
    public class Help
    {

        static Random rnd = new Random();

        /// <summary>
        /// Метод ввода числа
        /// </summary>
        /// <param name="n">Само число</param>
        public static void EnterTheNumber(out int n)
        {

            Console.Write("\nВведите число : ");
            while (!int.TryParse(Console.ReadLine(), out n))
            {
                Console.Write("Вы ввели не число, введите значение повторно : ");
            }

            Console.WriteLine("Число принято!");

        }

        /// <summary>
        /// Генерация строки
        /// </summary>
        /// <param name="MinLength">Минимальная длина слова</param>
        /// <param name="MaxLength">Максимальная длина слова</param>
        /// <param name="FirstSymbolIsUpper">Нужна ли первая заглавная буква</param>
        /// <returns>Возвращает сгенерированную строку</returns>
        public static string StringGenerationInDiaposon(int MinLength, int MaxLength, bool FirstSymbolIsUpper)
        {
            string GenStr = "";
            int length = rnd.Next(MinLength, MaxLength + 1);

            if (FirstSymbolIsUpper) // Если первый символ должен быть заглавным
            {
                for (int i = 0; i < length; i++)
                {
                    if (i == 0)
                    {
                        GenStr += Convert.ToChar(rnd.Next(65, 91)); // Первый символ генерится большим
                        continue;
                    }
                    GenStr += Convert.ToChar(rnd.Next(97, 123)); // Далее добавляем строчные буквы
                }
            }
            else
            {
                for (int i = 0; i < length; i++)
                {
                    GenStr += Convert.ToChar(rnd.Next(97, 123)); // Далее добавляем строчные буквы
                }
            }

            return GenStr;
        }
    }
}
