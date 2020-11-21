using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;

namespace MyLibrary
{
    [Serializable]
    [DataContract]
    public abstract class Shop
    {
        List<Item> items = new List<Item>();

        // Индексатор
        public Item this [int index]
        {
            get { return items[index]; }
        }

        /// <summary>
        /// Метод, добавляющий продукт в один из магазинов
        /// </summary>
        /// <\ name="item">Элемент списка</param>
        public void AppendItem(Item item)
        {
            items.Add(item);
        }

        /// <summary>
        /// Метод сортировки объектов с использованием CompareTo
        /// </summary>
        public void SortItems()
        {
            items.Sort((x,y) => x.CompareTo(y));
        }

        public int Count { get { return items.Count; } }

        public abstract void AcceptItem(Item item);
    }
}
