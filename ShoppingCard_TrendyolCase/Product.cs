namespace ShoppingCart_TrendyolCase
{
    public class Product
    {
        public string Name { get;}

        public double Price { get;}

        public Category Category { get;}

        public Product(string prdoductName, double productPrice, Category productCategory)
        {
            Name = prdoductName;
            Price = productPrice;
            Category = productCategory;
        }


    }
}
