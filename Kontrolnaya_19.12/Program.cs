using System;
using MyClasses; // AnimalLib
using static System.Console;
using System.IO;
using System.Threading;

// Контрольная работа, 14 декабря
// Бен Мустафа Анас БПИ 191
// Вариант 1

namespace CW_14._BenMustafa_191
{
    class MainClass
    {
        public static void Main()
        {
            do
            {
                Clear();
                Thread.Sleep(150);
                string pathToDogs = "Dogs.txt", pathToCats = "Cats.txt"; // Пути к файлам

                try // Очищаем текстовые файлы перед новым запуском программы
                {
                    using (FileStream fs = new FileStream(pathToCats, FileMode.Truncate)) { }
                    using (FileStream fs = new FileStream(pathToDogs, FileMode.Truncate)) { }
                }
                catch (IOException) { WriteLine("Something went wrong!"); }
                catch (Exception ex) { WriteLine("Little problem here : \n" + ex.Message); }


                Random rnd = new Random();
                int quantityOfAnimals = rnd.Next(5, 11); // Количество животных
                Animal[] animals = new Animal[quantityOfAnimals]; // Массив, в котором будут животные
                Cat[] cats = new Cat[5];

                try
                {
                    for (int i = 0; i < quantityOfAnimals; ++i) // Создаем "базу" питомцев
                    {
                        if (rnd.Next(1, 11) > 5) animals[i] = new Dog(); // Создаем объекты с равной вероятнсотью
                        else animals[i] = new Cat();
                    }
                }
                catch (ArgumentException) { WriteLine("Something went wrong!"); }
                catch (Exception ex) { WriteLine(ex.Message + "\nSomething went wrong!"); }


                try
                {
                    for (int i = 0; i < quantityOfAnimals; ++i) // Для каждого животного генерируем его имя и возраст
                    {
                        // Генерируем возраст питомца
                        int ageofanimal = rnd.Next(-5, 16);
                        if (ageofanimal < 0)
                        {
                            i -= 1; // Если возраст нам не подходит, еще раз с тем же питомцем запускаем попытку создания
                            continue; 
                        }

                        animals[i].Age = ageofanimal;

                        int lengthOfName = rnd.Next(4, 11); // Длина имени питомца
                        string nameOfAnimal = "";

                        for (int j = 0; j < lengthOfName; ++j) // Создаем имя питомца
                        {
                            int simbol;
                            if (j == 0)
                            {
                                simbol = rnd.Next(65, 91); // Первая буква - заглавная
                                nameOfAnimal += Convert.ToChar(simbol);
                                continue;
                            }
                            simbol = rnd.Next(97, 123); // Далее добавляем в имя животного строчные буквы
                            nameOfAnimal += Convert.ToChar(simbol);
                        }
                        animals[i].Name = nameOfAnimal;
                        WriteLine(animals[i].MakeSound(nameOfAnimal)); // При создании объекта выводим на экран гав или мяу
                    }
                }
                catch (ArgumentNullException) { WriteLine("Something went wrong!"); }
                catch (ArgumentOutOfRangeException) { WriteLine("Something went wrong!"); }
                catch (ArgumentException) { WriteLine("Something went wrong!"); }
                catch (Exception ex) { WriteLine("Little problem here : \n" + ex.Message); }


                try
                {
                    foreach (var animal in animals)
                    {
                        if (animal is Dog)
                        {
                            try
                            {
                                using (StreamWriter sw = new StreamWriter(pathToDogs, true))
                                {
                                    sw.WriteLine($"{((Dog)animal).Name}, dog's age is {((Dog)animal).Age}");
                                }
                            }
                            catch (IOException) { WriteLine("Something went wrong"); }
                            catch (Exception ex) { WriteLine("Little problem here : \n" + ex.Message); }
                        }

                        if (animal is Cat)
                        {
                            try
                            {
                                using (StreamWriter sw = new StreamWriter(pathToCats, true))
                                {
                                    sw.WriteLine($"{((Cat)animal).Name}, cat's age is {((Cat)animal).Age}");
                                }
                            }
                            catch (IOException) { WriteLine("Something went wrong"); }
                            catch (Exception ex) { WriteLine("Little problem here : \n" + ex.Message); }
                        }
                    }
                }
                catch (Exception ex) { WriteLine("Little problem here : \n" + ex.Message); }


                WriteLine("\nTap ENTER to restart or ESC to end programm \n\nATTENTION!\n\n" +
                    "When you restart the programm, files become clear!");
            }
            while (ReadKey().Key != ConsoleKey.Escape);
        }
    }
}
