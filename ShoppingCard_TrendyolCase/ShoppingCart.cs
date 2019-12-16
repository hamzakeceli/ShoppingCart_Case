using System.Collections.Generic;
using System.Linq;

namespace ShoppingCart_TrendyolCase
{
    public class ShoppingCart
    {
        private double TotalAmount = 0;
        private double CampaignDiscount = 0;
        private double CouponDiscount = 0;
        private double TotalAmountAfterDiscounts = 0;
        public double DeliverCost { get; set; }
        private bool AppliedCoupon = false;
        bool AppliedDiscounts = false;

        public Dictionary<Product, int> ProductsInCart = new Dictionary<Product, int>();
        public HashSet<Category> categoriesInCart = new HashSet<Category>();

        public double GetTotalAmount()
        {
            return CalculateTotalAmount();
        }

        public double GetCampaignDiscount()
        {
            return CampaignDiscount;
        }

        public double GetCouponDiscount()
        {
            return CouponDiscount;
        }
        public double GetTotalAmountAfterDiscounts()
        {
            TotalAmountAfterDiscounts = GetTotalAmount() - (CampaignDiscount + CouponDiscount);
            return TotalAmountAfterDiscounts;
        }

        public double GetDeliverCost()
        {
            return DeliverCost;
        }

        public void AddItem(Product product, int quantity)
        {
            if (!ProductsInCart.ContainsKey(product))
            {
                ProductsInCart.Add(product, quantity);
            }
            else
            {
                ProductsInCart[product] = ProductsInCart.First(item => item.Key == product).Value + quantity;
            }
        }

        public double CalculateTotalAmount()
        {
            TotalAmount = 0;
            foreach (KeyValuePair<Product, int> product in ProductsInCart)
            {
                TotalAmount += (product.Key.Price) * (product.Value);
            }

            return TotalAmount;
        }

        public HashSet<Category> GetCategoriesInCart(Dictionary<Product, int> ProductsInCart)
        {
            foreach (Product product in ProductsInCart.Keys)
            {

                categoriesInCart.Add(product.Category);

            }

            return categoriesInCart;
        }

        public void ApplyDiscounts(params Campaign[] campaigns)
        {
            GetCategoriesInCart(ProductsInCart);
            AppliedDiscounts = true;
            //CalculateTotalAmount();
            double discountMax = 0, discountEmpty = 0;

            foreach (Category category in categoriesInCart)
            {
                foreach (Campaign campaign in campaigns)
                {
                    if (campaign.CategoryName == category)
                    {
                        if (campaign.DiscountType == DiscountType.Rate)
                        {
                            discountEmpty = CalculateDiscountForRateCampaigns(campaign, category);

                            if (discountMax < discountEmpty)
                            {
                                discountMax = discountEmpty;
                            }
                        }

                        else
                        {

                            discountEmpty = CalculateDiscountForAmountCampaigns(campaign, category);

                            if (discountMax < discountEmpty)
                            {
                                discountMax = discountEmpty;
                            }
                        }
                    }

                }
                CampaignDiscount += discountMax;
                // TotalAmount -= discountMax;
                discountMax = 0;
                discountEmpty = 0;


            }

            // TotalAmount -= CampaignDiscount;


        }

        public double CalculateDiscountForRateCampaigns(Campaign campaign, Category category)
        {
            double categoryDiscountAmount = 0;

            if (ProductCountACategory(category) >= campaign.MinProductCount)
            {
                categoryDiscountAmount = CalculateTotalAmountAcategory(category) * (campaign.DiscountValue / 100);
                return categoryDiscountAmount;
            }
            else
            {
                return 0;
            }

        }

        public double CalculateDiscountForAmountCampaigns(Campaign campaign, Category category)
        {

            if (ProductCountACategory(category) >= campaign.MinProductCount)
            {
                return campaign.DiscountValue;
            }
            else
            {
                return 0;
            }

        }

        public int ProductCountACategory(Category category)
        {
            int productNumberInAcategory = 0;

            foreach (KeyValuePair<Product, int> product in ProductsInCart)
            {
                if (product.Key.Category == category)
                {
                    productNumberInAcategory += product.Value;
                }
            }

            return productNumberInAcategory;
        }

        public double CalculateTotalAmountAcategory(Category category)
        {
            double totalAmountAcategory = 0;
            foreach (var product in ProductsInCart)
            {
                if (product.Key.Category == category)
                {
                    totalAmountAcategory += (product.Key.Price * product.Value);
                }
            }

            return totalAmountAcategory;
        }

        public void ApplyCoupon(Coupon coupon)
        {
            if (AppliedDiscounts)
            {
                if (!AppliedCoupon)
                {
                      CalculateTotalAmount();
                    if (TotalAmount >= coupon.MinPurchaseAmount)
                    {
                        AppliedCoupon = true;
                        if (coupon.DiscountType == DiscountType.Amount)
                        {
                            CouponDiscount = coupon.DiscountValue;
                            // TotalAmount -= CouponDiscount;
                        }
                        else
                        {
                            CouponDiscount = (TotalAmount - CampaignDiscount) * (coupon.DiscountValue) / 100;
                            //  TotalAmount-= CouponDiscount;
                        }

                    }
                    else
                    {
                        System.Console.WriteLine("Insufficient shopping for coupon use");
                    }
                }
                else
                {
                    System.Console.WriteLine("A coupon can be applied to a cart");
                }


            }
            else
            {
                System.Console.WriteLine("Campaign discount must be applied first");
            }
        }
        
        public void Print()
        {
            System.Console.WriteLine();
            ProductsInCart = ProductsInCart.OrderBy(product => product.Key.Category.Name).ToDictionary(product => product.Key, product => product.Value);
            System.Console.WriteLine("Category-Name\tProduct-Name\tQuantity\tUnit-Price\tTotal-Price");

            foreach (KeyValuePair<Product, int> product in ProductsInCart)
            {
                double totalPrice = product.Key.Price * product.Value;
                System.Console.WriteLine("{0}\t\t{1}\t{2}\t\t{3}\t\t{4}", product.Key.Category.Name, product.Key.Name, product.Key.Price, product.Value, totalPrice);
            }
            System.Console.WriteLine();

            System.Console.WriteLine("Total-Amount\tTotal-Discount\tTotalAmountAfterDiscounts\tDelivery-Cost");
            System.Console.WriteLine("{0}\t\t{1}+{2}={3}\t{4}\t\t\t\t{5}", GetTotalAmount(), CampaignDiscount ,CouponDiscount, CampaignDiscount+CouponDiscount, GetTotalAmountAfterDiscounts(), DeliverCost);

        }


    }
}