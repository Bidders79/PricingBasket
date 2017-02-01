using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PricingBasket.Classes;
using PricingBasket.Interfaces;

namespace PricingBasket.Classes
{
    public class ShoppingBasket : IShoppingBasket
    {
        private ErrorLogger _LogError;
        private List<string> _BasketItems;
        private Validate _Validate;
        private Dictionary<string, string> _SpecialOffers;
        public decimal _SubTotal { get; set; }
        public decimal _TotalPrice { get; set; }
       
        public ProductsList productPriceList;
        public PriceDiscountList pricediscountlist;

        //Constructor
        public ShoppingBasket()
        {
            _BasketItems = new List<string>();
            _Validate = new Validate();
            _SpecialOffers= new Dictionary<string, string>();
            _LogError = new ErrorLogger();
            _SubTotal = 0.00m;
            _TotalPrice = 0.00m;
            LoadProductsList();
            //pricediscountlist = XMLHandlers.XMLPriceDiscountsList();
        }

#region IShoppingbasket
        //Interface - required
        //Add items entered by user into the basket
        public bool InputItems(string[] items)
        {
            foreach (string item in items){
                _BasketItems.Add(item.ToLower());
            }
            return ValidateItems();
        }

        //interface required
        public void ProcessList()
        {
            if(_BasketItems.Count > 0 && _Validate.InvalidItems.Count > 0 )
            {
                _LogError.LogError("Unable to process list errors occured in validation");
            }

            ProcessList proceeslist = new ProcessList();

        }

        //Output Messag?
        public void OutputMessage()
        {


            Console.WriteLine("SubTotal: £{0}", _SubTotal);
            if (_SpecialOffers.Count == 0)
            {
                Console.WriteLine("(No offers available)");
            }
            else
            {
                foreach (KeyValuePair<string, string> kvp in _SpecialOffers)
                {
                    Console.WriteLine("{0}: {1}", kvp.Key, kvp.Value);
                }
            }

            Console.WriteLine("Total price: £{0}", _TotalPrice);
        }

#endregion //IShoppingbasket

        //
        private bool ValidateItems()
        {   
            if(!_Validate.ValidateItemList(productPriceList, _BasketItems))
            {
                _LogError.LogError("There are some invalid items in your basket, please remove and try again! ", _Validate.InvalidItems);
                return false;
            }

            return true;
        }

        private void LoadProductsList()
        {
            try
            {
                productPriceList = XMLHandlers.XMLProducts();
            }
            catch (Exception ex)
            {
                _LogError.LogError("Error trying to load product list - ", ex);
            }
        }
        


      


       
        
        private bool CheckForDiscounts()
        {
            return false;
        }

        public void CalculateSubTotal()
        {
            ValidateItems();
            foreach (string p in _Validate.ValidItems)
            {
                //check the current item is in the product list
                var Items = from prod in productPriceList.product
                            where prod.Type.ToLower() == p.ToLower()
                            select prod;

                foreach (Product prod in Items)
                {
                    _SubTotal += Convert.ToDecimal(prod.Price);
                }
            }
            _TotalPrice = _SubTotal;
        }



        //To Action - check special offers
        public Dictionary<string, string> SpecialOffer()
        {           
            return _SpecialOffers;
        }

 

    }

    


#region calculations


#endregion
}
