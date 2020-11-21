using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace EKRLib
{
    public class Freight : Item
    {
        private double a, b, c;

        public double A
        {
            get { return a; }
            set { a = value; }
        }

        public double B
        {
            get { return b; }
            set { b = value; }
        }

        public double C
        {
            get { return c; }
            set { c = value; }
        }

        public double GetDemensionWeight()
        {
            return (A * B * C) / (double)50;
        }

        public double GetRealValue()
        {
            return (Weight > GetDemensionWeight()) ? Weight : GetDemensionWeight();
        }

        public override string ToString()
        {
            return base.ToString() + $"A : {A}. B : {B}. C : {C}. Real value : {GetRealValue()}.";
        }
    }
}
