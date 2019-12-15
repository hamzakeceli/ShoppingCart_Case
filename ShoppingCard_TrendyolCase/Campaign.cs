namespace ShoppingCart_TrendyolCase
{
    public class Campaign
    {
        public Category CategoryName { get; set; }

        public double DiscountValue { get; set; }

        public int MinProductCount { get; set; }

        public DiscountType DiscountType { get; set; }


        public Campaign(Category categoryName, double discountValue, int minProductCount, DiscountType discountType)
        {
            CategoryName = categoryName;
            DiscountValue = discountValue;
            MinProductCount = minProductCount;
            DiscountType = discountType;

        }

    }


}
