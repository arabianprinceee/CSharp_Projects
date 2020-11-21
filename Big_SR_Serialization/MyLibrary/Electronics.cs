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
    public class Electronics : Item, IComparable<Electronics>
    {
        // Вольтаж электроустройства
        [DataMember]
        public double Voltage { get; set; }

        public override string ToString()
        {
            return base.ToString() + $", Voltage = {Voltage}";
        }

        public Electronics(string name, double cost, double weight, double voltage) : base(name, cost, weight)
        {
            Voltage = voltage;
        }

        public Electronics() { }

        /// <summary>
        /// Сравнение объектов типа "электроника"
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(Electronics other)
        {
            if (Cost == other.Cost)
            {
                if (Voltage == other.Voltage)
                    return 0;
                else if (Voltage < other.Voltage)
                    return 1;
                else
                    return -1;
            }
            else if (Cost < other.Cost)
                return 1;
            else
                return -1;
        }
    }
}
