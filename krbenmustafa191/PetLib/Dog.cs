using System;
namespace PetLib
{
    public class Dog : Pet
    {
        public Dog(string name, double mass) : base(name, mass)
        {

        }

        public override string ToString()
        {
            return $"Dog with name : {Name}, with mass: {Math.Round(Mass, 2)}";
        }
    }
}
