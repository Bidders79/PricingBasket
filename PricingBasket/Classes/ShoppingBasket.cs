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
        public decimal _TotalDiscounts { get; set; }
        public decimal _TotalPrice { get; set; }
       
        public ProductsList _ProductPriceList;
        public PriceDiscountList _PriceDiscountList;

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
            LoadPriceDiscountList();          
        }

#region IShoppingbasket
        //Interface - required
        //Add items entered by user into the basket
        public bool InputItems(string[] items)
        {
            try
            {
                foreach (string item in items){
                _BasketItems.Add(item.ToLower());
            }
            }
            catch(Exception ex){
                _LogError.LogError("Error inputtting items", ex);
            }

            
            return ValidateItems();
        }

        //interface required
        public void ProcessList()
        {
            if(_BasketItems.Count > 0 && _Validate.InvalidItems.Count() > 0 )
            {
                _LogError.LogError("Unable to process list errors occured in validation");
                return;
            }
            CalculatePriceDiscounts();
            CalculateSubTotal();
            CalculateTotal();
            OutputMessage();
        }

        //Output Messag?
        public void OutputMessage()
        {
            Console.WriteLine("SubTotal: £{0}", _SubTotal.ToString("0.00"));
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
            Console.WriteLine("Total price: £{0}", _TotalPrice.ToString("0.00"));
        }

#endregion //IShoppingbasket

        //
        private bool ValidateItems()
        {   
            if(!_Validate.ValidateItemList(_ProductPriceList, _BasketItems))
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
                _ProductPriceList = XMLHandlers.XMLProducts();
            }
            catch (Exception ex)
            {
                _LogError.LogError("Error trying to load product list - ", ex);
            }
        }

        private void LoadPriceDiscountList()
        {
            try
            {
                _PriceDiscountList = XMLHandlers.XMLPriceDiscountsList();
            }
            catch (Exception ex)
            {
                _LogError.LogError("Error trying to load price discount list - ", ex);
            }
        }
       
        public void CalculatePriceDiscounts()
        {
            if (_PriceDiscountList == null) { return; }

            foreach (KeyValuePair<string, string> p in _Validate.ValidItems)
            {
                decimal discount = 0.00m;
                 var Items = from discounts in _PriceDiscountList.pricediscount
                             where discounts.ProductName.ToString().ToLower() == p.Key.ToLower()
                        select discounts.PercntageDiscount;
                    
                        foreach (string pd in Items)
                        {
                            discount = Convert.ToDecimal(pd) * Convert.ToDecimal(p.Value);
                            _TotalDiscounts += discount;
                        }
	        }
            return ;
        }

        public void CalculateSubTotal()
        {
            foreach (KeyValuePair<string, string> p in _Validate.ValidItems)
            {
                //check the current item is in the product list
                var Items = from prod in _ProductPriceList.product
                            where prod.Type.ToLower() == p.Key.ToLower()
                            select prod;

                foreach (Product prod in Items)
                {
                    _SubTotal += Convert.ToDecimal(p.Value);
                }

            }
        }

        public void CalculateTotal()
        {
            _TotalPrice = _SubTotal - _TotalDiscounts;
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
