using System;
using System.Linq;

namespace ShoppingCart_TrendyolCase
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Category category1 = new Category("categ1");
            Category category2 = new Category("categ2");
            Category category3 = new Category("categ3", category2);
            
            Product product1 = new Product("product1", 10.0, category1);
            Product product2 = new Product("product2", 20.0, category2);
            Product product3 = new Product("product3", 30.0, category3);
            Product product4 = new Product("Product4", 20.0, category1);
            
            ShoppingCart cart = new ShoppingCart();
            cart.AddItem(product1, 10);    //10*10=100     20tl discount   %20
            cart.AddItem(product2, 5);    //20*5=100       50tl discount   %50 
            cart.AddItem(product3, 5);    //30*5=150       5 tl discount   5            
            cart.AddItem(product4, 5);    //20*5=100       20tl discount   %20
            
            Campaign campaignpercent20 = new Campaign(category1, 20.0, 3, DiscountType.Rate);
            Campaign campaignpercent50 = new Campaign(category2, 50.0, 5, DiscountType.Rate);
            Campaign campaign5tl = new Campaign(category3, 5.0, 5, DiscountType.Amount);
            cart.ApplyDiscounts(campaignpercent20, campaignpercent50, campaign5tl);
           
            Coupon coupon = new Coupon(100.0, 10, DiscountType.Rate);
            cart.ApplyCoupon(coupon);
           

            const double costPerDelivery = 2, costPerProduct = 1, fixedCost = 2.99;
            
            DeliveryCostCalculator deliveryCostCalculator = new DeliveryCostCalculator(costPerDelivery, costPerProduct, fixedCost);
            deliveryCostCalculator.CalculateFor(cart);

            cart.Print();

            Console.ReadLine();
        }
    }
}
