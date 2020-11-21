using System;
namespace PetLib
{
    public interface Ipet : IComparable<Ipet>
    {
        string Name { get; set; }
        double Mass { get; set; }
    }
}
