using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace ShoppingBasketAppTests
{
	[TestClass]
	public class ShoppingBasketTests
	{
		[TestMethod]
		public void ShoppingBasketConstructorCreatesEmptyBasket()
		{
			ILogger logger = new InfoLogger();
			ShoppingBasket basket = new ShoppingBasket(IInfoLogger logger);
			var products = basket.Products;
			Assert.AreEqual(products.Count, 0);
		}

		[TestMethod]
		public void ShoppingBasketConstructorCreatesBasketWithoutDiscounts()
		{
			ILogger logger = new InfoLogger();
			ShoppingBasket basket = new ShoppingBasket(IInfoLogger logger);
			var discounts = basket.Discounts;
			Assert.AreEqual(discounts.Count, 0);
		}

		[TestMethod]
		public void CreateProductAddsProductToTheBasket()
		{
			ILogger logger = new InfoLogger();
			ShoppingBasket basket = new ShoppingBasket(IInfoLogger logger);
			basket.CreateProduct(ProductType.Bread);
			var products = basket.Products;
			Assert.IsTrue(products.Any(p => p.Type == ProductType.Bread));
		}

		[TestMethod]
		public void DeleteProductDeletesProductFromTheBasket()
		{
			ILogger logger = new InfoLogger();
			ShoppingBasket basket = new ShoppingBasket(IInfoLogger logger);
			basket.CreateProduct(ProductType.Bread);
			basket.DeleteProduct(ProductType.Bread);
			Assert.IsFalse(products.Any(p => p.Type == ProductType.Bread));
		}

		[TestMethod]
		public void AddProductIncrementsProductCount()
		{
			ILogger logger = new InfoLogger();
			ShoppingBasket basket = new ShoppingBasket(IInfoLogger logger);
			basket.CreateProduct(ProductType.Bread, 0.8);
			basket.AddProduct(ProductType.Bread);
			var product = basket.Products.First(p => p.Type == ProductType.Bread);
			Assert.AreEqual(product.Count, 1);
		}

		[TestMethod]
		public void AddMultipleProductsIncrementsProductCount()
		{
			ILogger logger = new InfoLogger();
			ShoppingBasket basket = new ShoppingBasket(IInfoLogger logger);
			basket.CreateProduct(ProductType.Bread, 0.8);
			basket.AddProduct(ProductType.Bread, 2);
			var product = basket.Products.First(p => p.Type == ProductType.Bread);
			Assert.AreEqual(product.Count, 2);
		}

		[TestMethod]
		public void AddProductUpdatesTotalSum()
		{
			ILogger logger = new InfoLogger();
			ShoppingBasket basket = new ShoppingBasket(IInfoLogger logger);
			basket.CreateProduct(ProductType.Bread, 0.8);
			basket.AddProduct(ProductType.Bread);
			var product = basket.Products.First(p => p.Type == ProductType.Bread);
			Assert.AreEqual(basket.TotalSum, 0.8);
		}

		[TestMethod]
		public void RemoveProductDecrementsProductCount()
		{
			ILogger logger = new InfoLogger();
			ShoppingBasket basket = new ShoppingBasket(IInfoLogger logger);
			basket.CreateProduct(ProductType.Bread, 0.8);
			basket.AddProduct(ProductType.Bread);
			basket.RemoveProduct(ProductType.Bread);
			var product = basket.Products.First(p => p.Type == ProductType.Bread);
			Assert.AreEqual(product.Count, 0);
		}

		[TestMethod]
		public void RemoveMultipleProductsDecrementesProductCount()
		{
			ILogger logger = new InfoLogger();
			ShoppingBasket basket = new ShoppingBasket(IInfoLogger logger);
			basket.CreateProduct(ProductType.Bread, 0.8);
			basket.AddProduct(ProductType.Bread, 2);
			basket.RemoveProduct(ProductType.Bread, 2);
			var product = basket.Products.First(p => p.Type == ProductType.Bread);
			Assert.AreEqual(product.Count, 0);
		}

		[TestMethod]
		public void RemoveMultipleProductsDoesNothingIfMoreProductsThanThatExistTriesToBeRemoved()
		{
			ILogger logger = new InfoLogger();
			ShoppingBasket basket = new ShoppingBasket(IInfoLogger logger);
			basket.CreateProduct(ProductType.Bread, 0.8);
			basket.AddProduct(ProductType.Bread, 2);
			basket.RemoveProduct(ProductType.Bread, 5);
			var product = basket.Products.First(p => p.Type == ProductType.Bread);
			Assert.AreEqual(product.Count, 2);
		}

		[TestMethod]
		public void RemoveProductUpdatesTotalSum()
		{
			ILogger logger = new InfoLogger();
			ShoppingBasket basket = new ShoppingBasket(IInfoLogger logger);
			basket.CreateProduct(ProductType.Bread, 0.8);
			basket.AddProduct(ProductType.Bread);
			basket.RemoveProduct(ProductType.Bread);
			var product = basket.Products.First(p => p.Type == ProductType.Bread);
			Assert.AreEqual(basket.TotalSum, 0);
		}

		[TestMethod]
		public void AddDiscountAddsDiscountToTheBasket()
		{
			ILogger logger = new InfoLogger();
			ShoppingBasket basket = new ShoppingBasket(IInfoLogger logger);
			IDiscount milkDiscount = new Discount(DiscountType.MilkDiscount);
			basket.AddDiscount(milkDiscount);
			var discounts = basket.Discounts;
			Assert.IsTrue(discounts.Contains(milkDiscount));
		}

		[TestMethod]
		public void RemoveDiscountRemovesDiscountFromTheBasket()
		{
			ILogger logger = new InfoLogger();
			ShoppingBasket basket = new ShoppingBasket(IInfoLogger logger);
			IDiscount milkDiscount = new Discount(DiscountType.Milk);
			basket.AddDiscount(milkDiscount);
			basket.RemoveDiscount(DiscountType.Milk);
			var discounts = basket.Discounts;
			Assert.IsFalse(discounts.Contains(milkDiscount));
		}

		//TODO: Tests for Calculation


	}
}
