using System;
namespace StoreLib
{
    public abstract class Drink : Item
    {
        public Drink(string name, float quantity) : base(name, quantity)
        {

        }

        public override float GetCost(float coef)
        {
            return Quantity * coef + (float)0.3;
        }

        public override string ToString()
        {
            return "Drink." + base.ToString() + $"Cost : {GetCost((float)1.5)}";
        }
    }
}
