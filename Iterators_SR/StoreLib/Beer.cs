using System;
namespace StoreLib
{
    public class Beer : Food
    {
        public override float GetCost(float coef)
        {
            return ((Quantity * coef) + (float)0.3) * 2;
        }

        public Beer(string name, float quantity) : base(name, quantity)
        {

        }

        public override string ToString()
        {
            return "Beer." + base.ToString();
        }
    }
}
