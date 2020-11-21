using System;
using System.Linq;
using System.Collections.Generic;

namespace LINQTraining
{
    class User
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public List<string> Languages { get; set; }
        public User()
        {
            Languages = new List<string>();
        }
    }

    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            List<string> teams = new List<string> { "Реал Бетис", "Реал Мурсия", "Бавария", "Боруссия", "Реал Мадрид", "Манчестер Сити", "ПСЖ", "Барселона", "Реал Сосьедад" };

            var BTeams = from t in teams
                         where t.StartsWith("Реал")
                         select t;

            //foreach (var t in BTeams)
            //{
            //    Console.WriteLine(t);
            //}

            List<int> numbers = new List<int> { 1, 2, 3, 43, 45, 23, 357, 3210, 4791, 831, 684, 921, 5548, 7712 };

            var mynumbers = from t in numbers
                            where (t % 2 == 0)
                            select t;

            //Console.WriteLine(mynumbers.GetType());

            //foreach (var t in mynumbers)
            //{
            //    Console.WriteLine(t);
            //}

            List<User> users = new List<User>
            {
                new User {Name="Том", Age=23, Languages = new List<string> {"английский", "немецкий" }},
                new User {Name="Боб", Age=27, Languages = new List<string> {"английский", "французский" }},
                new User {Name="Джон", Age=29, Languages = new List<string> {"английский", "испанский" }},
                new User {Name="Элис", Age=24, Languages = new List<string> {"испанский", "немецкий" }}
            };

            var SelectedUsers = from user in users
                                where (user.Age > 25 && (user.Languages[0] == "английский" || user.Languages[1] == "английский"))
                                select user;

            // Можно сделать вот так (более правильно)

            var SelectedUsers1 = from user in users
                                 from lang in user.Languages
                                 where user.Age > 22
                                 where lang == "английский"
                                 select user;

            //foreach (var user in SelectedUsers1)
            //{
            //    Console.WriteLine(user.Name);
            //}

            var names = from t in users select t.Name;

            var items = from t in users
                        select new
                        {
                            FirstName = t.Name,
                            UserAge = t.Age
                        };

            //Console.WriteLine(items.Count());

            List<User> users1 = new List<User>()
            {
                new User { Name = "Sam", Age = 43 },
                new User { Name = "Tom", Age = 33 }
            };

            var people = from u in users1
                         let name = "Mr. " + u.Name
                         select new
                         {
                             Name = name,
                             UserAge = u.Age
                         };

            //foreach (var item in people)
            //{
            //    Console.WriteLine(item);
            //}

            List<User> users2 = new List<User>()
            {
                new User { Name = "Tom", Age = 33 },
                new User { Name = "Bob", Age = 30 },
                new User { Name = "Tom", Age = 21 },
                new User { Name = "Sam", Age = 43 }
            };

            var sortedusers2 = from t in users2
                               orderby t.Name, t.Age
                               select t;

            //foreach (User u in sortedusers2)
            //    Console.WriteLine($"{u.Name}, age is {u.Age}");

            List<int> numbers1 = new List<int> { 1, 2, 3, 4, 5 };
            List<int> numbers2 = new List<int> { 1, 2, 3, 4, 6 };

            // Получаем все элементы первого массива без элементов второго
            var ExceptDemo = numbers1.Except(numbers2);

            //foreach (var item in ExceptDemo)
            //{
            //    Console.WriteLine(item);
            //}

            string[] soft = { "Microsoft", "Google", "Apple" };
            string[] hard = { "Apple", "IBM", "Samsung" };

            // Получаем общие элементы двух массивов
            var together = soft.Intersect(hard);

            //foreach (var item in together)
            //{
            //    Console.WriteLine(item);
            //}

            // объединение последовательностей (без повторений)
            // Если просто объединить, то использовать concat
            var result = soft.Union(hard);

            //foreach (var item in result)
            //{
            //    Console.WriteLine(item);
            //}

            //Console.WriteLine(users.All(u => u.Age > 20) ? "Возраст всех пользователей выше 20" : "Не все пользователи достигли 20 лет");


        }
    }
}
