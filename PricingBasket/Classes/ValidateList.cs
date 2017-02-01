using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PricingBasket.Classes
{
   
    public class Validate
    {
        private List<string> _InvalidItems;
        private List<string> _ValidItems;


        public List<string> InvalidItems { get { return _InvalidItems; } }
        public List<string> ValidItems { get { return _ValidItems; } }

         //Interface - required
        public bool ValidateItemList(ProductsList productList, List<string> basketItems)
        {
            _InvalidItems = new List<string>();
            _ValidItems = new List<string>();

            bool isValidList = true;
            //select items from thhe basket that are contained in the product list
            foreach (string p in basketItems)
            {
                //check the current item is in the product list
                var validItems = from prod in productList.product
                                 where prod.Type.ToLower() == p.ToLower()
                                 select prod;
                //if the basket item isn't valid add it to the invalid list else its valid
                if (validItems.Count() <= 0)
                {
                    _InvalidItems.Add(p);
                    isValidList = false;
                }
                else
                {
                    _ValidItems.Add(p);
                    
                }                       
            }
            return isValidList;
        }  
    }
}
