using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingCart_TrendyolCase;
using System.Collections.Generic;

namespace ShoppingCart_UnitTests
{
    [TestClass]
    public class Test_ShoppingCart
    {
        ShoppingCart cartTest = new ShoppingCart();
        Category category1;
        Category category2;
        Category category3;

        Product product1;
        Product product2;
        Product product3;

        Campaign campaignPercent20;
        Campaign campaignPercent50;
        Campaign campaign5tl;

        Coupon coupon1;

        public void ProductsAndCategoryCreateForTest()
        {
            category1 = new Category("category1");
            category2 = new Category("category2");
            category3 = new Category("category3", category2);

            product1 = new Product("product1", 10.0, category1);
            product2 = new Product("product2", 20.0, category2);
            product3 = new Product("product3", 30.0, category3);

        }

        public void ProductsAddToCartForTest()
        {
            cartTest.AddItem(product1, 10);    //10*10=100
            cartTest.AddItem(product2, 5);    //20*5=100            
            cartTest.AddItem(product3, 5);    //30*5=150

        }

        public void CampaignsForTests()
        {

            campaignPercent20 = new Campaign(category1, 20.0, 3, DiscountType.Rate);
            campaignPercent50 = new Campaign(category2, 50.0, 5, DiscountType.Rate);
            campaign5tl = new Campaign(category3, 5.0, 5, DiscountType.Amount);
            cartTest.ApplyDiscounts(campaignPercent20, campaignPercent50, campaign5tl);


        }

        [TestMethod]
        public void TestGetCampaignDiscount()
        {
            ProductsAndCategoryCreateForTest();
            ProductsAddToCartForTest();
            CampaignsForTests();

            double expected = 75;      //20+50+5=75  total campaign discount
            double actual = cartTest.GetCampaignDiscount();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestGetCouponDiscount()
        {
            ProductsAndCategoryCreateForTest();
            ProductsAddToCartForTest();
            CampaignsForTests();               //350-75=275

            coupon1 = new Coupon(100, 10.0, DiscountType.Rate);
            cartTest.ApplyCoupon(coupon1);    //275*0,10=27.5


            double expected = 27.5;  //275*0.10=27,7 
            double actual = cartTest.GetCouponDiscount();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestGetTotalAmountAfterDiscounts()
        {
            ProductsAndCategoryCreateForTest();
            ProductsAddToCartForTest();
            CampaignsForTests();               //350-75=275

            coupon1 = new Coupon(100, 10.0, DiscountType.Rate);
            cartTest.ApplyCoupon(coupon1);    //275*0,10=27.5   

            double expected = 247.5;  //  275-27.5=247.5
            double actual = cartTest.GetTotalAmountAfterDiscounts();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestAddItem()
        {
            ProductsAndCategoryCreateForTest();
            ProductsAddToCartForTest();
            double expected = 3;  // added 3 product
            double actual = cartTest.ProductsInCart.Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCalculateTotalAmount()
        {
            ProductsAndCategoryCreateForTest();
            ProductsAddToCartForTest();

            double expected = 350;     //100+100+150      
            double actual = cartTest.CalculateTotalAmount();
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void TestCalculateDiscountFor20RateCampaigns()
        {
            ProductsAndCategoryCreateForTest();
            ProductsAddToCartForTest();
            CampaignsForTests();

            double expected = 20;      //100*0.2=20  for Rate campaignPercent20 discount
            double actual = cartTest.CalculateDiscountForAmountCampaigns(campaignPercent20, category1);
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void TestCalculateDiscountFor50RateCampaigns()
        {
            ProductsAndCategoryCreateForTest();
            ProductsAddToCartForTest();
            CampaignsForTests();

            double expected = 50;      //100*0.5=50  for Rate campaignPercent50 discount
            double actual = cartTest.CalculateDiscountForAmountCampaigns(campaignPercent50, category2);
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void TestCalculateDiscountAmountCampaigns()
        {
            ProductsAndCategoryCreateForTest();
            ProductsAddToCartForTest();
            CampaignsForTests();

            double expected = 5;      //5  for Rate campaignPercent20 discount
            double actual = cartTest.CalculateDiscountForAmountCampaigns(campaign5tl, category3);
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void TestApplyDiscounts()
        {
            ProductsAndCategoryCreateForTest();
            ProductsAddToCartForTest();
            CampaignsForTests();

            double expected = 275;      //350-(20+50+5)=275  apply the highest discount in all categories
            double actual = cartTest.GetTotalAmountAfterDiscounts();
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void TestProductCountACategory()
        {
            ProductsAndCategoryCreateForTest();
            cartTest.AddItem(product1, 10);
            cartTest.AddItem(product1, 10);
            cartTest.AddItem(product1, 10);


            double expected = 30;  //category1 added 30 product1 
            double actual = cartTest.ProductCountACategory(category1);
            Assert.AreEqual(expected, actual);


        }

        [TestMethod]
        public void TestCalculateTotalAmountAcategory()
        {
            ProductsAndCategoryCreateForTest();

            cartTest.AddItem(product1, 10); //10*10=100
            cartTest.AddItem(product1, 10); //10*10=100          

            double expected = 200;  //category1 added 30 product1 
            double actual = cartTest.CalculateTotalAmountAcategory(category1);
            Assert.AreEqual(expected, actual);


        }

        [TestMethod]
        public void ApplyCoupon()
        {
            ProductsAndCategoryCreateForTest();
            ProductsAddToCartForTest();
            CampaignsForTests();               //350-75=275

            coupon1 = new Coupon(100, 10.0, DiscountType.Rate);
            cartTest.ApplyCoupon(coupon1);    //275*0,10=27.5


            double expected = 27.5;  //275*0.10=27,7 
            double actual = cartTest.GetCouponDiscount();
            Assert.AreEqual(expected, actual);

        }
        
       
    }
}
