using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart_TrendyolCase
{
    public class DeliveryCostCalculator
    {

        private double CostPerDelivery { get; }
        private double CostPerProduct { get; }
        private double FixedCost { get; }
        private double CostTotalDelivery { get; set; }

        public double GetCostTotalDelivery()
        {
            return CostTotalDelivery;
        }

        public DeliveryCostCalculator(double costPerDelivery, double costPerProduct, double fixedCost)
        {
            CostPerDelivery = costPerDelivery;
            CostPerProduct = costPerProduct;
            FixedCost = fixedCost;

        }

        public double CalculateFor(ShoppingCart cart)
        {

            cart.GetCategoriesInCart(cart.ProductsInCart);
            double numberOfDelivers = cart.categoriesInCart.Count();
            double numberOfProduct = cart.ProductsInCart.Count();

            CostTotalDelivery = (CostPerDelivery * numberOfDelivers) + (CostPerProduct * numberOfProduct) + FixedCost;
            cart.DeliverCost = CostTotalDelivery;
            return CostTotalDelivery;
        }

    }
}
