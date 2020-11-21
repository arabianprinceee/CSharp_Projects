using System;
namespace MyClasses
{
    public abstract class Animal
    {
        public abstract string Name { get; set; }
        public abstract int Age { get; set; }

        public override string ToString()
        {
            return ($"Name : {Name}, age : {Age} ");
        }

        public abstract string MakeSound(string str);
    }
}
