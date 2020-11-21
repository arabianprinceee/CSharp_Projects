using System;
namespace MyClasses
{
    public class AnimalException : Exception
    {
        public AnimalException (string message) : base(message) 
        {
        }
    }
}
