using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PricingBasket.Classes;

namespace PricingBasket
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ShoppingBasket myShoppingBasket = new ShoppingBasket();

                myShoppingBasket.InputItems(args);
                myShoppingBasket.ProcessList();
                //myShoppingBasket.OutputMessage();
            }
            catch(Exception ex)
            {
                Console.WriteLine("An error occured trying to Price you basket - " + ex.Message);
            }

            

        }
    }
}
