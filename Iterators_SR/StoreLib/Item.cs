using System;
namespace StoreLib
{
    public abstract class Item
    {
        private float quantity;
        private string name;

        public float Quantity
        {
            get
            {
                return quantity;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Quantity should be bigger than 0");
                }
                else
                {
                    quantity = value;
                }
            }
        }

        public abstract float GetCost(float coef);

        public Item(string name, float quantity)
        {
            Quantity = quantity;
            Name = name;
        }

        public override string ToString()
        {
            return $"Name : {Name}, Quantity : {Quantity}. ";
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (Char.IsUpper(value[0]))
                {
                    for (int i = 0; i < value.Length; i++)
                    {
                        if (!((value[i] >= 'A' && value[i] <= 'Z') || (value[i] >= 'a' && value[i] <= 'z') || (value[i] >= 'а' && value[i] <= 'я') || (value[i] >= 'А' && value[i] <= 'Я') || value[i] == ' '))
                        {
                            throw new ArgumentException("you must have only latin chars");
                        }
                    }
                    name = value;
                }
                else { throw new ArgumentException("First char is not upper case"); }
            }
        }


    }
}
