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
    public class Medicine : Item, IComparable<Medicine>
    {
        public Medicine() { }

        // Является ли лекарство антибиотиком
        [DataMember]
        public bool IsAntibiotic { get; set; }

        public Medicine(string name, double cost, double weight, bool isantibiotic) : base(name, cost, weight)
        {
            IsAntibiotic = isantibiotic;
        }

        public override string ToString()
        {
            return base.ToString() + $", IsAntibiotik = {IsAntibiotic}";
        }

        /// <summary>
        /// Сравнения объектов "медицинского типа"
        /// </summary>
        /// <param name="other">Иной объект типа медицина</param>
        /// <returns>Возвращает результат сравнения</returns>
        public int CompareTo(Medicine other)
        {
            if (IsAntibiotic == other.IsAntibiotic)
            {
                if (Weight == other.Weight)
                    return 0;
                else if (Weight > other.Weight)
                    return 1;
                else
                    return -1;
            }
            else if (Convert.ToInt32(IsAntibiotic) < Convert.ToInt32(other.IsAntibiotic))
                return -1;
            else
                return 1;
        }
    }
}
