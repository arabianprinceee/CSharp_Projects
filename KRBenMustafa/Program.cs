using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Linq;
using System.IO;
using System.Xml.Serialization;


namespace KRBenMustafa
{
    [Serializable]
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person()
        { }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public static Person operator +(Person p1, Person p2)
        {
            return new Person(p1.Name + p2.Name, p1.Age + p2.Age);
        }

        public override string ToString()
        {
            return $"{Name}, {Age}";
        }
    }

    class MainClass
    {
        public static void Main()
        {
            do
            {
                Console.OutputEncoding = System.Text.Encoding.UTF8;
                //int n;
                //Help.EnterTheNumber(out n);

                Person person = new Person("Riadovich Anas", 14);
                Person person1 = new Person(" Ben Mustafa", 5);

                Person person2 = person + person1;
                Console.WriteLine(person2.ToString()); 

                //List<Person> people = new List<Person>();
                //List<Person> people1 = new List<Person>();
                //for (int i = 0; i < 5; i++)
                //{
                //    people.Add(new Person(Help.StringGenerationInDiaposon(10, 20, true), 19));
                //}
                //BINSer<List<Person>>.BINSerializer("people.txt", people);
                //people1 = BINSer<List<Person>>.BINDeserializer("people.txt");
                //foreach (var item in people1)
                //{
                //    Console.WriteLine(item.Name);
                //}

                //Console.WriteLine();

                //Person person = new Person("Anas", 19);
                //Person person1 = new Person();
                //BINSer<Person>.BINSerializer("Anas.txt", person);
                //person1 = BINSer<Person>.BINDeserializer("Anas.txt");

                //try
                //{
                //    Console.WriteLine(person1.Name + " " + person1.Age);
                //}
                //catch (Exception ex)
                //{
                //    Console.WriteLine(ex.Message);
                //}
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);

        }
    }
}
