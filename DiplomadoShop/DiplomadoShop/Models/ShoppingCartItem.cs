using Newtonsoft.Json;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiplomadoShop.Models
{

    public class ShoppingCartItem
    {

        public int ShoppingCartItemId { get; set; }
        public Product Product { get; set; }
     
        public int ProductId { get; set; }
        public int? Quantity { get; set; }
        public double TaxRate { get; set; }

        public decimal Price { get; set; }

      

        public decimal Total { get { return Price * (decimal)Quantity; } }
        // public double Total => Quantity.Value * Product.Price;
    }
}


//public class SingleValueArrayConverter<T> : JsonConverter
//{
//    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
//    {
       
//    }

//    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
//    {
//        object retVal = new Object();
//        if (reader.TokenType == JsonToken.StartObject)
//        {
//            T instance = (T)serializer.Deserialize(reader, typeof(T));
//            retVal = new List<T>() { instance };
//        }
//        else if (reader.TokenType == JsonToken.StartArray)
//        {
//            retVal = serializer.Deserialize(reader, objectType);
//        }
//        return retVal;
//    }

//    public override bool CanConvert(Type objectType)
//    {
//        return true;
//    }
//}


