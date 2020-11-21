using System;
namespace MyLibrary
{
    public class RandomDateTime
    {
        DateTime start = new DateTime();
        DateTime date = new DateTime();
        Random gen;
        int range;

        public RandomDateTime()
        {
            date = DateTime.Now.AddDays(3);
            start = DateTime.Now;
            gen = new Random();
            range = (date - start).Days;
        }

        /// <summary>
        /// Генерация рандомной даты в промежутке сегодня + 3 дня
        /// </summary>
        /// <returns></returns>
        public DateTime Next()
        {
            return start.AddDays(gen.Next(range)).AddHours(gen.Next(0, 24)).AddMinutes(gen.Next(0, 60)).AddSeconds(gen.Next(0, 60));
        }
    }
}
