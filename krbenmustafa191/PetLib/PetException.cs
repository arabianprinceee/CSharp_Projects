using System;
using System.Runtime.Serialization;

namespace PetLib
{
    [Serializable]
    public class PetException : Exception
    {
        public PetException()
        {
        }

        public PetException(string message) : base(message)
        {
        }

        public PetException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected PetException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}