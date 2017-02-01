using PricingBasket.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PricingBasket
{
    interface IShoppingBasket
    {
        bool InputItems(string[] items);
        void ProcessList();
        void OutputMessage();
    }

    interface IPriceDiscountOffers
    {
        decimal getDiscount(string item);
    }

    interface IProductDiscountOffers
    {

        decimal getDiscount(string item);
    }
    

}
