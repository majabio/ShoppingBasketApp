using System;
using System.Collections.Generic;
using System.Linq;


namespace ShoppingBasketApp
{
	class ShoppingBasket
	{
		private HashSet<IProduct> products;
		private HashSet<IDiscount> discounts;
		private InfoLogger logger;

		internal IEnumerable<IProduct> Products { get { return products; } }

		internal IEnumerable<IDiscount> Discounts { get { return discounts; } }

		internal double TotalSum { get; private set; }

		internal ShoppingBasket(InfoLogger logger) 
		{
			this.logger = logger;
			discounts = new HashSet<IDiscount>();
			products = new HashSet<IProduct>();
		}

		internal void AddProduct(ProductType type, int count = 1)
		{
			var product = products.FirstOrDefault(p => p.Type == type);
			if (count < 1 || null == product)
				return;
			product.Count += count;
			TotalSum += count * product.Price;
		}

		internal void RemoveProduct(ProductType type, int count = 1)
		{
			var product = products.FirstOrDefault(p => p.Type == type);
			if (count < 1 || count > product.Count || null == product)
				return;
			product.Count -= count;
			TotalSum -= count * product.Price;
		}

		internal void AddDiscount(IDiscount discount)
		{
			discounts.Add(discount);
		}

		internal void RemoveDiscount(DiscountType type)
		{
			IDiscount discount = discounts.FirstOrDefault(d => d.Type == type);
			if (null == discount)
				return;
			discounts.Remove(discount);
		}

		internal void CreateProduct(ProductType type, double price)
		{
			Product product = new Product(type, price);
			products.Add(product);
		}

		internal void DeleteProduct(ProductType type)
		{
			var product = products.FirstOrDefault(p => p.Type == type);
			if (null == product)
				return;
			products.Remove(product);
		}

		internal void ProcessOrder()
		{
			foreach (IProduct product in products)
				logger?.Log(String.Format("{0, -10} \t {1} \t {2, 6:N2}$\n", product.Type.ToString(), product.Count, product.Price));
			logger?.Log("----------------------------------");
			logger?.Log(String.Format("\nTotal: {0}$", TotalSum.ToString()));
			logger?.Log("\n----------------------------------");
			foreach (IDiscount discount in discounts)
			{
				var discountResult = discount.Apply(products);
				logger?.Log(String.Format("\n{0, -10} discount \t -{1, 5:N2}$", discount.Type.ToString(), discountResult));
				logger?.Log("\n----------------------------------");
				TotalSum -= discountResult;
			}
			logger?.Log(String.Format("\nTotal: {0}$", TotalSum.ToString()));
			
		}

	}
}
