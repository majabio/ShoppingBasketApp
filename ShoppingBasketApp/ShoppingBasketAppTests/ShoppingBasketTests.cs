using Microsoft.VisualStudio.TestTools.UnitTesting;

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
		public void AddProductAddsProductToTheBasket()
		{
			ILogger logger = new InfoLogger();
			ShoppingBasket basket = new ShoppingBasket(IInfoLogger logger);
			IProduct bread = new Product(ProductType.Bread, 1.0);
			basket.AddProduct(bread);
			var products = basket.Products;
			Assert.IsTrue(products.Contains(bread));
		}

		[TestMethod]
		public void RemoveProductRemovesProductFromTheBasket()
		{
			ILogger logger = new InfoLogger();
			ShoppingBasket basket = new ShoppingBasket(IInfoLogger logger);
			IProduct bread = new Product(ProductType.Bread, 1.0);
			basket.AddProduct(bread);
			basket.RemoveProduct(ProductType.Bread);
			var products = basket.Products;
			Assert.IsFalse(products.Contains(bread));
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
