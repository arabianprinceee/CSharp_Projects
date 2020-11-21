using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;

namespace MyLibrary
{
    [Serializable]
    [DataContract]
    [XmlInclude(typeof(Medicine))]
    [XmlInclude(typeof(Cake))]
    [XmlInclude(typeof(Electronics))]
    [KnownType(typeof(Medicine))]
    [KnownType(typeof(Cake))]
    [KnownType(typeof(Electronics))]
    public abstract class Item : IComparable<Item>
    {
        string name;
        double cost;
        double weight;

        public Item() { }

        public Item(string name, double cost, double weight)
        {
            Name = name;
            Cost = cost;
            Weight = weight;
        }

        // Название предмета
        [DataMember]
        public string Name
        {
            get { return name; }
            set
            {
                if (Char.IsUpper(value[0]))
                {
                    for (int i = 0; i < value.Length; i++)
                    {
                        if (!((value[i] >= 'a' && value[i] <= 'z') || (value[i] >= 'A' && value[i] <= 'Z')))
                        {
                            throw new ArgumentException("Допустимы только латинские буквы!");
                        }
                        if (value.Length > 15)
                        {
                            name = (value + " Mall Edition");
                            break;
                        }
                    }
                    name = value;
                }
                else
                {
                    throw new ArgumentException("Первый символ должен быть заглавным!");
                }
            }
        }

        // Цена предмета
        [DataMember]
        public double Cost
        {
            get { return cost; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Значение 'cost' не может быть меньше нуля!");
                }
                else
                {
                    cost = value;
                }
            }
        }

        // Вес предмета
        [DataMember]
        public double Weight
        {
            get { return weight; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Значение 'weight' не может быть меньше нуля!");
                }
                else
                {
                    weight = value;
                }
            }
        }

        public override string ToString()
        {
            return String.Format("{0} Name = {1}, Weight = {2}, Cost = {3}", this.GetType().Name, Name, Weight, Cost);
        }


        /// <summary>
        /// Сравнение объектов типов Item
        /// </summary>
        /// <param name="other">Другой объект для сравнения</param>
        /// <returns>Возвращается результат сравнения</returns>
        public int CompareTo(Item other)
        {
            if (GetType() == other.GetType())
            {
                if (this is Medicine)
                {
                    return ((Medicine)this).CompareTo((Medicine)other);
                }
                else if (this is Electronics)
                {
                    return ((Electronics)this).CompareTo((Electronics)other);
                }
                else
                {

                    return ((Cake)this).CompareTo((Cake)other);
                }
            }
            else if (this is Cake)
                return 1;
            else if (this is Electronics)
                return -1;
            else
            {
                if (other is Cake)
                    return -1;
                else
                    return 1;
            }

        }
    }
}
