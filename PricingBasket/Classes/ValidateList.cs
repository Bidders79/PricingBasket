using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PricingBasket.Classes
{
   
    public class Validate
    {
        private Dictionary<string, string> _InvalidItems;
        private Dictionary<string, string> _ValidItems;

        public Dictionary<string, string> InvalidItems { get { return _InvalidItems; } }
        public Dictionary<string, string> ValidItems { get { return _ValidItems; } }

         //Interface - required
        public bool ValidateItemList(ProductsList productList, List<string> basketItems)
        {
            _InvalidItems = new Dictionary<string, string>();
            _ValidItems = new Dictionary<string, string>();

            bool isValidList = true;
            string price = string.Empty;
            //select items from thhe basket that are contained in the product list
            foreach (string p in basketItems)
            {
                //check the current item is in the product list
                var validItems = from prod in productList.product
                                 where prod.Type.ToLower() == p.ToLower()
                                 select prod.Price;
                //if the basket item isn't valid add it to the invalid list else its valid
                //store the item name and price

                foreach (string prod in validItems)
                {
                    price = prod;
                }

                if (validItems.Count() <= 0)
                {
                    _InvalidItems.Add(p, price);
                    isValidList = false;
                }
                else
                {
                    _ValidItems.Add(p, price);
                    
                }                       
            }
            return isValidList;
        }  
    }
}
