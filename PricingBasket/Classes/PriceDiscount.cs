using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PricingBasket
{
    [Serializable()]
    public class PriceDiscount
    {
        [System.Xml.Serialization.XmlElement("productname")]
        public string ProductName { get; set; }
        [System.Xml.Serialization.XmlElement("quantitytoqualify")]
        public string QuantityToQualify { get; set; }
        [System.Xml.Serialization.XmlElement("percntagediscount")]
        public string PercntageDiscount { get; set; }
    }

    [Serializable()]
    [System.Xml.Serialization.XmlRoot("pricediscountlist")]
    public class PriceDiscountList
    {
        [XmlArray("pricediscounts")]
        [XmlArrayItem("pricediscount", typeof(PriceDiscount))]
        public PriceDiscount[] pricediscount { get; set; }
    }
 }

