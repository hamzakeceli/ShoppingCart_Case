namespace ShoppingCart_TrendyolCase
{
    public class Campaign
    {
        public Category CategoryName { get;}

        public double DiscountValue { get;}

        public int MinProductCount { get;}

        public DiscountType DiscountType { get;}


        public Campaign(Category categoryName, double discountValue, int minProductCount, DiscountType discountType)
        {
            CategoryName = categoryName;
            DiscountValue = discountValue;
            MinProductCount = minProductCount;
            DiscountType = discountType;

        }

    }


}
