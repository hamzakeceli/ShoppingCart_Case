using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingCart_TrendyolCase;

namespace ShoppingCart_UnitTests
{
    [TestClass]
    public class Test_DeliverCostCalculator
    {
        DeliveryCostCalculator deliveryCostCalculator = new DeliveryCostCalculator(2, 1, 2.99);

        [TestMethod]
        public void TestCalculateFor()
        {
            ShoppingCart cartTest = new ShoppingCart();
            //Create category
            Category category1 = new Category("category1");
            Category category2 = new Category("category2");
            Category category3 = new Category("category3", category2);

            //Crete Product
            Product product1 = new Product("product1", 10.0, category1);
            Product product2 = new Product("product2", 20.0, category2);
            Product product3 = new Product("product3", 30.0, category3);

            //Product add to Cart           
            cartTest.AddItem(product1, 10);    //10*10=100
            cartTest.AddItem(product2, 5);    //20*5=100            
            cartTest.AddItem(product3, 5);    //30*5=150


            double expected = 11.99;      //(2*3)+(1*3)+2.99=11.99 (cat*count)+(prod*count)+fixedcost
            double actual = deliveryCostCalculator.CalculateFor(cartTest);

            Assert.AreEqual(expected, actual);
        }
    }
}
