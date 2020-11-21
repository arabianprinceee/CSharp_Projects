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
    [XmlRoot(ElementName = "Cake")]
    public class Cake : Item, IComparable<Cake>
    {
        public Cake() { }

        // Дата создания тортика
        [DataMember]
        public DateTime ExpirationDate { get; set; }

        /// <summary>
        /// Сравнение объектов типа "торт"
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(Cake other)
        {
            if (ExpirationDate == other.ExpirationDate)
                return 0;
            else if (ExpirationDate > other.ExpirationDate)
                return 1;
            else
                return -1;
        }

        public Cake(string name, double cost, double weight, DateTime date) : base(name, cost, weight)
        {
            ExpirationDate = date;
        }

        public override string ToString()
        {
            return base.ToString() + $", ExpirationDate = {ExpirationDate}";
        }
    }
}
