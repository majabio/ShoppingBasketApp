using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingBasketApp;
using System.Linq;

namespace ShoppingBasketAppTests
{
	[TestClass]
	public class ShoppingBasketTests
	{
		[TestMethod]
		public void ShoppingBasketConstructorCreatesEmptyBasket()
		{
			ShoppingBasket basket = new ShoppingBasket(null);
			Assert.AreEqual(basket.Products.Count(), 0);
		}

		[TestMethod]
		public void ShoppingBasketConstructorCreatesBasketWithoutDiscounts()
		{
			ShoppingBasket basket = new ShoppingBasket(null);
			var discounts = basket.Discounts;
			Assert.AreEqual(basket.Discounts.Count(), 0);
		}

		[TestMethod]
		public void CreateProductAddsProductToTheBasket()
		{
			ShoppingBasket basket = new ShoppingBasket(null);
			basket.CreateProduct(ProductType.Bread, 1.0);
			Assert.IsTrue(basket.Products.Any(p => p.Type == ProductType.Bread));
		}

		[TestMethod]
		public void DeleteProductDeletesProductFromTheBasket()
		{
			ShoppingBasket basket = new ShoppingBasket(null);
			basket.CreateProduct(ProductType.Bread, 1.0);
			basket.DeleteProduct(ProductType.Bread);
			Assert.IsFalse(basket.Products.Any(p => p.Type == ProductType.Bread));
		}

		[TestMethod]
		public void AddProductIncrementsProductCount()
		{ 
			ShoppingBasket basket = new ShoppingBasket(null);
			basket.CreateProduct(ProductType.Bread, 1.0);
			basket.AddProduct(ProductType.Bread);
			var product = basket.Products.First(p => p.Type == ProductType.Bread);
			Assert.AreEqual(product.Count, 1);
		}

		[TestMethod]
		public void AddMultipleProductsIncrementsProductCount()
		{
			ShoppingBasket basket = new ShoppingBasket(null);
			basket.CreateProduct(ProductType.Bread, 1.0);
			basket.AddProduct(ProductType.Bread, 2);
			var product = basket.Products.First(p => p.Type == ProductType.Bread);
			Assert.AreEqual(product.Count, 2);
		}

		[TestMethod]
		public void AddProductUpdatesTotalSum()
		{
			ShoppingBasket basket = new ShoppingBasket(null);
			basket.CreateProduct(ProductType.Bread, 1.0);
			basket.AddProduct(ProductType.Bread);
			var product = basket.Products.First(p => p.Type == ProductType.Bread);
			Assert.AreEqual(basket.TotalSum, 1.0);
		}

		[TestMethod]
		public void RemoveProductDecrementsProductCount()
		{
			ShoppingBasket basket = new ShoppingBasket(null);
			basket.CreateProduct(ProductType.Bread, 1.0);
			basket.AddProduct(ProductType.Bread);
			basket.RemoveProduct(ProductType.Bread);
			var product = basket.Products.First(p => p.Type == ProductType.Bread);
			Assert.AreEqual(product.Count, 0);
		}

		[TestMethod]
		public void RemoveMultipleProductsDecrementesProductCount()
		{
			ShoppingBasket basket = new ShoppingBasket(null);
			basket.CreateProduct(ProductType.Bread, 1.0);
			basket.AddProduct(ProductType.Bread, 2);
			basket.RemoveProduct(ProductType.Bread, 2);
			var product = basket.Products.First(p => p.Type == ProductType.Bread);
			Assert.AreEqual(product.Count, 0);
		}

		[TestMethod]
		public void RemoveMultipleProductsDoesNothingIfMoreProductsThanThatExistTriesToBeRemoved()
		{
			ShoppingBasket basket = new ShoppingBasket(null);
			basket.CreateProduct(ProductType.Bread, 1.0);
			basket.AddProduct(ProductType.Bread, 2);
			basket.RemoveProduct(ProductType.Bread, 5);
			var product = basket.Products.First(p => p.Type == ProductType.Bread);
			Assert.AreEqual(product.Count, 2);
		}

		[TestMethod]
		public void RemoveProductUpdatesTotalSum()
		{
			ShoppingBasket basket = new ShoppingBasket(null);
			basket.CreateProduct(ProductType.Bread, 1.0);
			basket.AddProduct(ProductType.Bread);
			basket.RemoveProduct(ProductType.Bread);
			var product = basket.Products.First(p => p.Type == ProductType.Bread);
			Assert.AreEqual(basket.TotalSum, 0);
		}

		[TestMethod]
		public void AddDiscountAddsDiscountToTheBasket()
		{

			ShoppingBasket basket = new ShoppingBasket(null);
			IDiscount milkDiscount = new MilkDiscount();
			basket.AddDiscount(milkDiscount);
			Assert.IsTrue(basket.Discounts.Contains(milkDiscount));
		}

		[TestMethod]
		public void RemoveDiscountRemovesDiscountFromTheBasket()
		{
			ShoppingBasket basket = new ShoppingBasket(null);
			IDiscount milkDiscount = new MilkDiscount();
			basket.AddDiscount(milkDiscount);
			basket.RemoveDiscount(DiscountType.Milk);
			Assert.IsFalse(basket.Discounts.Contains(milkDiscount));
		}


	}
}
