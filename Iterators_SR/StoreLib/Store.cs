using System;
using System.Collections.Generic;
using System.Collections;

namespace StoreLib
{
    public class Store : IEnumerable
    {
        Item[] items = new Item[] { };

        public void Add(Item item)
        {
            Array.Resize(ref items, items.Length + 1);
            items[items.Length - 1] = item;
        }

        public Item this[int index]
        {


            get { return items[index]; }
        }

        public IEnumerator GetEnumerator()
        {
            return new StoreInteraction(items);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
