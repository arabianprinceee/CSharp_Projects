using System;
namespace MyClasses
{
    public class Cat : Animal
    {
        protected string name;
        protected int age;

        public override string Name
        {
            get { return name; }

            set // Устанавливаем имя кота
            {
                if (value.Length < 4 || value.Length > 10) throw new AnimalException($"Unavailible length of name - {value.Length}"); // Проверка длины имени

                if ((int)value[0] < 65 || (int)value[0] > 90) // Проверяем, что первая буква - заглавная
                {
                    throw new AnimalException($"Unavailible name - {value}");
                }

                for (int i = 1; i < value.Length; ++i) // Проверяем, что имя (кроме первой буквы) состоит из маленьких букв
                {
                    if (((int)value[i] >= 97 && (int)value[i] <= 122))
                    {
                        name = value;
                    }
                    else throw new AnimalException($"Unavailible name - {value}");
                }
            }
        }

        public override int Age // Устанавливаем возраст
        {
            get
            {
                return age;
            }

            set
            {
                if (value < 0) // Возраст не может быть меньше нуля
                {
                    throw new AnimalException($"Unavailible age - {value}"); 
                }
                age = value;
            }
        }

        public override string MakeSound(string str) // Кричалка
        {
            return ($"{Name} : Meow");
        }

        public override string ToString()
        {
            return ($"Cat's name : {Name}, age : {Age} ");
        }
    }
}
