using System;
using System.Collections;
using System.Collections.Generic;

namespace StoreLib
{
    public class StoreInteraction : IEnumerator<Item>
    {
        Item[] items;
        int position = -1;

        public Item Current
        {
            get
            {
                if (position == -1 || position >= items.Length)
                    throw new InvalidOperationException("Something wrong in ItemCurrent");
                //while(!(items[position] is Item && items[position].GetType() != typeof(Item)))
                //{
                //    MoveNext();
                //}
                return items[position];
            }
        }

        public StoreInteraction(Item[] items)
        {
            this.items = items;
        }

        object IEnumerator.Current
        {
            get
            {
                if (position == -1 || position >= items.Length)
                    throw new InvalidOperationException("Something wrong in ItemCurrent");
                //while(!(items[position] is Item && items[position].GetType() != typeof(Item)))
                //{
                //    MoveNext();
                //}
                return items[position];
            }
        }

        public void Dispose()
        {
            
        }

        public bool MoveNext()
        {
            if (position < items.Length - 1)
            {
                position++;
                return true;
            }
            else
                return false;
        }

        public void Reset()
        {
            position = -1;
        }
    }
}
