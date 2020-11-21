using System;
namespace StoreLib
{
    public class Milk : Food
    {
        public override float GetCost(float coef)
        {
            return (Quantity * coef) + (float)0.8;
        }

        public Milk(string name, float quantity) : base(name, quantity)
        {

        }

        public override string ToString()
        {
            return "Milk. " + base.ToString();
        }
    }
}
