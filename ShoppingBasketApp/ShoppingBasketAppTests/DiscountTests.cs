using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ShoppingBasketAppTests
{
	[TestClass]
	public class DiscountTests
	{
		[TestMethod]
		public void ConstructorSetsTheCorrectValueForType()
		{
			IDiscount milkDiscount = new MilkDiscount();
			IDiscount butterBreadDiscount = new ButterBreadDiscount();
			Assert.AreEqual(milkDiscount.Type, DiscountType.Milk);
			Assert.AreEqual(butterBreadDiscount.Type, DiscountType.Bread);
		}


		[TestMethod]
		public void TestApplyButterBreadDiscountForTwoButtersAndOneBread()
		{
			List<IProducts> products = new List<IProducts>() { new Product(ProductType.Butter, 0.8),
																new Product(ProductType.Bread, 1.0),
																new Product(ProductType.Butter, 0.8)};
			IDiscount butterBreadDiscount = new ButterBreadDiscount();
			double result = butterBreadDiscount.Apply(products);
			Assert.AreEqual(result, -0.5);
		}

		[TestMethod]
		public void TestApplyButterBreadDiscountForTwoButtersAndTwoBreads()
		{
			List<IProducts> products = new List<IProducts>() { new Product(ProductType.Butter, 0.8),
																new Product(ProductType.Bread, 1.0),
																new Product(ProductType.Butter, 0.8),
																new Product(ProductType.Bread, 1.0)};
			IDiscount butterBreadDiscount = new ButterBreadDiscount();
			double result = butterBreadDiscount.Apply(products);
			Assert.AreEqual(result, -0.5);
		}

		[TestMethod]
		public void TestApplyButterBreadDiscountForThreeButtersAndOneBread()
		{
			List<IProducts> products = new List<IProducts>() { new Product(ProductType.Butter, 0.8),
																new Product(ProductType.Bread, 1.0),
																new Product(ProductType.Butter, 0.8),
																new Product(ProductType.Bread, 1.0)};
			IDiscount butterBreadDiscount = new ButterBreadDiscount();
			double result = butterBreadDiscount.Apply(products);
			Assert.AreEqual(result, -0.5);
		}

		[TestMethod]
		public void TestApplyMilkDiscountForFourMilks()
		{
			List<IProducts> products = new List<IProducts>() { new Product(ProductType.Milk, 1.15),
																new Product(ProductType.Milk, 1.15),
																new Product(ProductType.Milk, 1.15), 
																new Product(ProductType.Milk, 1.15)};
			IDiscount milkDiscount = new MilkDiscount();
			double result = milkDiscount.Apply(products);
			Assert.AreEqual(result, -1.15);
		}

		[TestMethod]
		public void TestApplyMilkDiscountForThreeMilks()
		{
			List<IProducts> products = new List<IProducts>() { new Product(ProductType.Milk, 1.15),
																new Product(ProductType.Milk, 1.15),
																new Product(ProductType.Milk, 1.15)};
			IDiscount milkDiscount = new MilkDiscount();
			double result = milkDiscount.Apply(products);
			Assert.AreEqual(result, 0);
		}

		[TestMethod]
		public void TestApplyMilkDiscountForFiveMilks()
		{
			List<IProducts> products = new List<IProducts>() { new Product(ProductType.Milk, 1.15),
																new Product(ProductType.Milk, 1.15),
																new Product(ProductType.Milk, 1.15),
																new Product(ProductType.Milk, 1.15),
																new Product(ProductType.Milk, 1.15)};
			IDiscount milkDiscount = new MilkDiscount();
			double result = milkDiscount.Apply(products);
			Assert.AreEqual(result, -1.15);
		}

	}
}
