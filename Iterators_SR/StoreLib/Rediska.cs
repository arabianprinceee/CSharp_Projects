using System;
namespace StoreLib
{
    public class Rediska : Food
    {
        public override float GetCost(float coef)
        {
            return (Quantity * coef)*(float)(1/2) + (float)0.5;
        }

        public Rediska(string name, float quantity) : base(name, quantity)
        {

        }

        public override string ToString()
        {
            return "Rediska." + base.ToString();
        }
    }
}
