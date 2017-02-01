using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PricingBasket.Interfaces;

namespace PricingBasket.Classes
{
    public class ErrorLogger: IErrorLogger
    {
        public void LogError(string errorMsg)
        {
            Console.WriteLine(errorMsg);
        }

        public void LogError(string errorMsg, Exception ex)
        {
            Console.WriteLine(errorMsg + " - " + ex.Message);
        }
        public void LogError(string errorMsg, List<string> InvalidItems)
        {
            Console.WriteLine(errorMsg);
            foreach (string iv in InvalidItems)
            {
                Console.WriteLine(iv);
            }
        }
    }
}
