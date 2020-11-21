using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace EKRLib
{
    public class Item : IComparable<Item>
    {
        public int CompareTo(Item other)
        {
            return Weight.CompareTo(other.Weight);
        }

        private double weight;
        public double Weight
        {
            get { return weight; }
            set
            {
                weight = value;
            }
        }

        public override string ToString()
        {
            return $"Weight : {Weight}. ";
        }

        public static explicit operator double(Item item)
        {
            return item.Weight;
        }
    }
}
