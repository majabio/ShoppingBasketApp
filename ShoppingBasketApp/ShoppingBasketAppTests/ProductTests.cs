﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingBasketApp;

namespace ShoppingBasketAppTests
{
	[TestClass]
	public class ProductTests
	{
		[TestMethod]
		public void ConstructorSetsTheCorrectValueForTypeProperty()
		{
			Product bread = new Product(ProductType.Bread, 1.0);
			Product milk = new Product(ProductType.Milk, 1.15);
			Product butter = new Product(ProductType.Butter, 0.8);
			Assert.AreEqual(bread.Type, ProductType.Bread);
			Assert.AreEqual(milk.Type, ProductType.Milk);
			Assert.AreEqual(butter.Type, ProductType.Butter);
		}

		[TestMethod]
		public void ConstructorSetsTheCorrectValueForPriceProperty()
		{
			Product bread = new Product(ProductType.Bread, 1.0);
			Product milk = new Product(ProductType.Milk, 1.15);
			Product butter = new Product(ProductType.Butter, 0.8);
			Assert.AreEqual(bread.Price, 1.0);
			Assert.AreEqual(milk.Price, 1.15);
			Assert.AreEqual(butter.Price, 0.8);
		}

		[TestMethod]
		public void ItIsNotPossibleToSetNegativePriceValue()
		{
			Product bread = new Product(ProductType.Bread, -1.0);
			Product milk = new Product(ProductType.Milk, -1.15);
			Product butter = new Product(ProductType.Butter, -0.8);
			Assert.AreEqual(bread.Price, 0.0);
			Assert.AreEqual(milk.Price, 0.0);
			Assert.AreEqual(butter.Price, 0.0);
		}
	}
}
