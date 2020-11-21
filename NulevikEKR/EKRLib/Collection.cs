using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace EKRLib
{
    public class Collection<T> : IEnumerable<T>
        where T : Item
    {
        private List<T> items;

        public void Add(T item)
        {
            items.Add(item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new CollectionEnumerator<T>(items);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public override string ToString()
        {
            return this.items.Count.ToString();
        }
    }
}
