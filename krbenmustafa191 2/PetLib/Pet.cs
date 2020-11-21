using System;
namespace PetLib
{
    public abstract class Pet : Ipet
    {
        string name;
        double mass;
        public string Name
        {
            get => name;
            set
            {
                if (value.Length < 3 || value.Length > 10) // Проверяем, что длина имени входит в нужный интервал
                {
                    throw new PetException($"Недопустимая кличка {value}");
                }

                char[] nameofpet = value.ToCharArray();

                if (nameofpet[0] < 'A' || nameofpet[0] > 'Z')
                {
                    throw new PetException($"Недопустимая кличка {value}");
                }

                for (int i = 1; i < nameofpet.Length; i++)
                {
                    if (nameofpet[i] < 'a' || nameofpet[i] > 'z')
                    {
                        throw new PetException($"Недопустимая кличка {value}");
                    }
                }
                name = value;
            }
        }

        public double Mass
        {
            get => mass;
            set
            {
                if (value < 0) // Проверяем, что масса не отрицательная
                {
                    throw new PetException("Масса не может быть отрицательной");
                }
                else
                {
                    mass = value;
                }
            }
        }

        public override string ToString()
        {
            return $"Name : {Name}, mass : {Mass}";
        }

        protected Pet(string name, double mass)
        {
            Name = name;
            Mass = mass;
        }

        public int CompareTo(Ipet other)
        {
            return this.Mass == other.Mass ? this.Name.CompareTo(other.Name) : this.Mass.CompareTo(other.Mass);
        }
    }
}
