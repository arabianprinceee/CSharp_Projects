using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace EKRLib
{
    public class CollectionEnumerator<T> : IEnumerator<T>
        where T : Item
    {
        int position = -1;
        List<T> items;

        public T Current => items[position];

        object IEnumerator.Current => items[position];

        public CollectionEnumerator(List<T> items)
        {
            this.items =
                new List<T>(items.AsEnumerable().Where((item) => item.Weight > 0.01));
        }

        public void Dispose()
        {
            
        }

        public bool MoveNext()
        {
            if (++position < items.Count)
                return true;
            return false;
        }

        public void Reset()
        {
            position = -1;
        }
    }
}
