using System;
namespace StoreLib
{
    public class Potato : Food
    {
        public override float GetCost(float coef)
        {
            return Quantity * coef + (float)0.5;
        }

        public Potato(string name, float quantity) : base(name, quantity)
        {

        }

        public override string ToString()
        {
            return "Potato." + base.ToString();
        }
    }
}
