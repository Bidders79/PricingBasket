using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using PricingBasket.Interfaces;

namespace PricingBasket.Classes
{
    public static class XMLHandlers
    {
        private static string productsData = @"C:\Users\james\Documents\Visual Studio 2013\Projects\PricingBasket\PricingBasket\XMLData\Products.xml";
        private static string priceDiscountList = @"C:\Users\james\Documents\Visual Studio 2013\Projects\PricingBasket\PricingBasket\XMLData\PriceDiscount.xml";

        public static ProductsList XMLProducts()
        {
            ProductsList productlist = null;
            try 
            {
                XmlSerializer serializer = new XmlSerializer(typeof(ProductsList));
                using (StreamReader sr = new StreamReader(productsData))
                {
                    productlist = (ProductsList)serializer.Deserialize(sr);
                }

            }
            catch(Exception)
            {
                throw;
            }
           
            return productlist;
        }

        public static PriceDiscountList XMLPriceDiscountsList()
        {
            PriceDiscountList pricediscountlist = null;
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(PriceDiscountList));
                using (StreamReader sr = new StreamReader(priceDiscountList))
                {
                    pricediscountlist = (PriceDiscountList)serializer.Deserialize(sr);
                }

            }
            catch (Exception)
            {
                throw;
            }

            return pricediscountlist;
        }
    }
}
