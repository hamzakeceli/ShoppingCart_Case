namespace ShoppingCart_TrendyolCase
{
    public class Coupon
    {
        public double MinPurchaseAmount { get;}

        public double DiscountValue { get;}

        public DiscountType DiscountType { get;}

        public Coupon(double minPurchaseAmount, double discountValue, DiscountType discountType)
        {
            MinPurchaseAmount = minPurchaseAmount;
            DiscountValue = discountValue;
            DiscountType = discountType;

        }

    }



}
