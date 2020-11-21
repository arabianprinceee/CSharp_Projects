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
    public class OnlineStore : Shop
    {
        public override void AcceptItem(Item item)
        {
            item.Cost *= 1.05;
            item.Weight += 0.9;
            AppendItem(item);
        }
    }
}
