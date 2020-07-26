using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace ShoppingBasketApp
{
	class ShoppingBasket
	{
		private HashSet<IProduct> products;
		private List<IDiscount> discounts;
		private double totalSum;
		private InfoLogger logger;

		internal ShoppingBasket(InfoLogger logger) 
		{
			this.logger = logger;
			discounts = new List<IDiscount>();
			products = new HashSet<IProduct>();
		}

		internal void AddProduct(ProductType type, int count = 1)
		{
			var product = products.First(p => p.Type == type);
			if (null == product || count < 1)
				return;
			product.Count += count;
			totalSum += count * product.Price;
		}

		internal void RemoveProduct(ProductType type, int count = 1)
		{
			var product = products.First(p => p.Type == type);
			if (null == product || count < 1 || count > product.Count)
				return;
			product.Count -= count;
			totalSum -= count * product.Price;
		}

		internal void AddDiscount(IDiscount discount)
		{
			discounts.Add(discount);
		}

		internal void RemoveDiscount(DiscountType type)
		{
			discounts.Remove(discounts.First(discount => discount.Type == type));
		}

		internal void CreateProduct(ProductType type, double price)
		{
			Product product = new Product(type, price);
			if (products.Any(p => p.Type == type))
				return;
			products.Add(product);
		}

		internal void DeleteProduct(ProductType type)
		{
			var product = products.First(p => p.Type == type);
			if (product == null)
				return;
			products.Remove(product);		
		}

		internal void ProcessOrder()
		{
			foreach (IProduct product in products)
				logger.Log(product.Type.ToString() + " " + product.Count + " " + product.Price + "\n");
			logger.Log(totalSum.ToString());
			foreach (IDiscount discount in discounts)
			{
				var discountResult = discount.Apply(products);
				logger.Log("\n" + discount.Type.ToString() + "" + "-" + discountResult);
				totalSum -= discountResult;
			}
			logger.Log("\n" + totalSum.ToString());
			
		}

	}
}
