
namespace ShoppingCart_TrendyolCase
{
    public class Category
    {
        public string Name { get;}

        public Category UpperCategory { get;}


        public Category(string categoryName)
        {
            Name = categoryName;
        }

        public Category(string categoryName, Category upperCategory)
        {
            Name = categoryName;
            UpperCategory = upperCategory;

        }

    }
}
