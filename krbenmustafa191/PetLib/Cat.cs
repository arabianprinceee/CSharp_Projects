using System;
namespace PetLib
{
    public class Cat : Pet
    {
        public Cat(string name, double mass) : base(name, mass)
        {

        }

        public override string ToString()
        {
            return $"Cat with name : {Name}, with mass: {Math.Round(Mass, 2)}";
        }
    }
}
