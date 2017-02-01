using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PricingBasket.Classes;
namespace PricingBasket.Test
{
    [TestClass]
    public class ShoppingBasketTest
    {
        ShoppingBasket shoppingBasket = new ShoppingBasket();

        [TestMethod]
        public void AddShoppingItemsToBasketTest()
        {
            string[] shoppingItems = new string[]{"Milk", "Apples", "Bread"};
            Assert.IsTrue(shoppingBasket.InputItems(shoppingItems));
           
        }

        [TestMethod]
        public void GetProductListTest()
        {
            ProductsList productPriceList = XMLHandlers.XMLProducts();
            Assert.IsNotNull(productPriceList);
        }

        [TestMethod]
        public void CalculateSubTotalTest()
        {
            string[] shoppingitems = new string[] { "milk", "apples" };
            shoppingBasket.InputItems(shoppingitems);
            shoppingBasket.CalculateSubTotal();
            Assert.AreEqual(shoppingBasket._SubTotal, 2.30m);

        }

    }
}
