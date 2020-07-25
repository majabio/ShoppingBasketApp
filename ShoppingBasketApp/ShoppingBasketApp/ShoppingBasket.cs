using System.Collections.Generic;
using System.Linq;

namespace ShoppingBasketApp
{
	class ShoppingBasket
	{
		private List<IProduct> products;
		private List<IDiscount> discounts;
		private double totalPrice;
		private InfoLogger logger;

		ShoppingBasket(InfoLogger logger) 
		{
			this.logger = logger;
		}

		void AddProduct(IProduct product)
		{
			products.Add(product);
			totalPrice += product.Price;
		}

		void RemoveProduct(ProductType type)
		{
			IProduct product = products.First(p => p.Type == type);
			products.Remove(product);
			totalPrice -= product.Price;
		}

		void AddDiscount(IDiscount discount)
		{
			discounts.Add(discount);
		}

		void RemoveDiscount(DiscountType type)
		{
			discounts.Remove(discounts.First(discount => discount.Type == type));
		}

		void Calculate()
		{

		}

	}
}
