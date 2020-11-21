using System;
namespace LINQSAMRAB
{
    public class Product
    {
        public string type;
        public string name;
        public string supplier;
        public double cost;
        public DateTime deliveryDate;

        public Product(string type, string name, double cost, string supplier, DateTime deliveryDate)
        {
            this.type = type;
            this.name = name;
            this.cost = cost;
            this.supplier = supplier;
            this.deliveryDate = deliveryDate;
        }

        public override string ToString()
        {
            return $"{type}. {name}. {supplier}. {cost}. {deliveryDate}.";
        }
    }
}
