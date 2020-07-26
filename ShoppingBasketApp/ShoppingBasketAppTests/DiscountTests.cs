using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingBasketApp;

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
			Assert.AreEqual(butterBreadDiscount.Type, DiscountType.ButterBread);
		}


		[TestMethod]
		public void TestApplyButterBreadDiscountForTwoButtersAndOneBread()
		{ 
			IProduct butter = new Product(ProductType.Butter, 0.8);
			butter.Count = 2;
			IProduct bread = new Product(ProductType.Bread, 1.0);
			bread.Count = 1;
			HashSet<IProduct> products = new HashSet<IProduct>() { butter, bread };

			IDiscount butterBreadDiscount = new ButterBreadDiscount();
			double result = butterBreadDiscount.Apply(products);
			Assert.AreEqual(result, 0.5);
		}

		[TestMethod]
		public void TestApplyButterBreadDiscountForTwoButtersAndTwoBreads()
		{
			IProduct butter = new Product(ProductType.Butter, 0.8, 2);
			IProduct bread = new Product(ProductType.Bread, 1.0, 2);
			HashSet<IProduct> products = new HashSet<IProduct>() { butter, bread };

			IDiscount butterBreadDiscount = new ButterBreadDiscount();
			double result = butterBreadDiscount.Apply(products);
			Assert.AreEqual(result, 0.5);
		}

		[TestMethod]
		public void TestApplyButterBreadDiscountForThreeButtersAndOneBread()
		{
			IProduct butter = new Product(ProductType.Butter, 0.8, 3);
			IProduct bread = new Product(ProductType.Bread, 1.0, 1);
			HashSet<IProduct> products = new HashSet<IProduct>() { butter, bread };

			IDiscount butterBreadDiscount = new ButterBreadDiscount();
			double result = butterBreadDiscount.Apply(products);
			Assert.AreEqual(result, 0.5);
		}

		[TestMethod]
		public void TestApplyMilkDiscountForFourMilks()
		{
			IProduct milk = new Product(ProductType.Milk, 1.15, 4);
			HashSet<IProduct> products = new HashSet<IProduct>() { milk};

			IDiscount milkDiscount = new MilkDiscount();
			double result = milkDiscount.Apply(products);
			Assert.AreEqual(result, 1.15);
		}

		[TestMethod]
		public void TestApplyMilkDiscountForThreeMilks()
		{
			IProduct milk = new Product(ProductType.Milk, 1.15, 3);
			HashSet<IProduct> products = new HashSet<IProduct>() { milk };

			IDiscount milkDiscount = new MilkDiscount();
			double result = milkDiscount.Apply(products);
			Assert.AreEqual(result, 0);
		}

		[TestMethod]
		public void TestApplyMilkDiscountForFiveMilks()
		{
			IProduct milk = new Product(ProductType.Milk, 1.15, 5);
			HashSet<IProduct> products = new HashSet<IProduct>() { milk };

			IDiscount milkDiscount = new MilkDiscount();
			double result = milkDiscount.Apply(products);
			Assert.AreEqual(result, 1.15);
		}

	}
}
