using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace PricingBasket.Classes
{
    [Serializable]
    public class Product
    {
        [System.Xml.Serialization.XmlElement("id")]
        public string ID { get; set; }
        [System.Xml.Serialization.XmlElement("type")]
        public string Type { get; set; }
        [System.Xml.Serialization.XmlElement("price")]
        public string Price { get; set; }
        [System.Xml.Serialization.XmlElement("unitquantity")]
        public string UnitQuantity { get; set; }
    }

    [Serializable()]
    [System.Xml.Serialization.XmlRoot("productlist")]
    public class ProductsList
    {
        [XmlArray("products")]
        [XmlArrayItem("product", typeof(Product))]
        public Product[] product { get; set; }
    }

}
