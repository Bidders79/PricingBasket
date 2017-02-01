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
        [System.Xml.Serialization.XmlElement("productid")]
        public int ProductID { get; set; }
        [System.Xml.Serialization.XmlElement("quantitytoqualify")]
        public int QuantityToQualify { get; set; }
        [System.Xml.Serialization.XmlElement("percntagediscount")]
        public int PercntageDiscount { get; set; }
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

