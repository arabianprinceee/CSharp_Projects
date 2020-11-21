using System;
namespace StoreLib
{
    public abstract class Food : Item
    {
        public override float GetCost(float coef)
        {
            return Quantity * coef;
        }

        public Food(string name, float quantity) : base(name, quantity)
        {
                
        }

        public override string ToString()
        {
            return "Food." + base.ToString() + $"Cost : {GetCost((float)1.5)}";
        }
    }
}
