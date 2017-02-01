using PricingBasket.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PricingBasket.Interfaces
{
    interface IErrorLogger
    {
        void LogError(string errorMsg);
    }
}
