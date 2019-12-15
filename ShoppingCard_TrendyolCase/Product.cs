namespace ShoppingCart_TrendyolCase
{
    public class Product
    {
        public string Name { get; set; }

        public double Price { get; set; }

        public Category Category { get; set; }

        public Product(string prdoductName, double productPrice, Category productCategory)
        {
            Name = prdoductName;
            Price = productPrice;
            Category = productCategory;
        }


    }
}
