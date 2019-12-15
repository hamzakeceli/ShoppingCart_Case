namespace ShoppingCart_TrendyolCase
{
    public class Coupon
    {
        public double MinPurchaseAmount { get; set; }

        public double DiscountValue { get; set; }

        public DiscountType DiscountType { get; set; }

        public Coupon(double minPurchaseAmount, double discountValue, DiscountType discountType)
        {
            MinPurchaseAmount = minPurchaseAmount;
            DiscountValue = discountValue;
            DiscountType = discountType;

        }

    }



}
