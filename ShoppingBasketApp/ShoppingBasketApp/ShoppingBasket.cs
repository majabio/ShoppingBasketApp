using System;
using System.Collections.Generic;
using System.Linq;


namespace ShoppingBasketApp
{
	class ShoppingBasket
	{
		private HashSet<IProduct> products;
		private List<IDiscount> discounts;
		private double totalSum;
		private InfoLogger logger;

		ShoppingBasket(InfoLogger logger) 
		{
			this.logger = logger;
			discounts = new List<IDiscount>();
			products = new HashSet<IProduct>();
		}

		void AddProduct(ProductType type, int count = 1)
		{
			var product = products.First(p => p.Type == type);
			if (null == product || count < 1)
				return;
			product.Count += count;
			totalSum += count * product.Price;
		}

		void RemoveProduct(ProductType type, int count = 1)
		{
			var product = products.First(p => p.Type == type);
			if (null == product || count < 1 || count > product.Count)
				return;
			product.Count -= count;
			totalSum -= count * product.Price;
		}

		void AddDiscount(IDiscount discount)
		{
			discounts.Add(discount);
		}

		void RemoveDiscount(DiscountType type)
		{
			discounts.Remove(discounts.First(discount => discount.Type == type));
		}

		void CreateProduct(ProductType type, double price)
		{
			Product product = new Product(type, price);
			if (products.Any(p => p.Type == type))
				return;
			products.Add(product);
		}

		void DeleteProduct(ProductType type)
		{
			var product = products.First(p => p.Type == type);
			if (product == null)
				return;
			products.Remove(product);		
		}

		void Calculate()
		{

		}

	}
}
