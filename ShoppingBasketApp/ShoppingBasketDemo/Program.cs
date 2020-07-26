using ShoppingBasketApp;
using System;
using System.IO;

namespace ShoppingBasketDemo
{
	class Program
	{
		static void Main(string[] args)
		{
			string fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"LogOutput.txt");
			using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
			{
				InfoLogger logger = new InfoLogger(fs);
				ShoppingBasket basket = new ShoppingBasket(logger);

				basket.CreateProduct(ProductType.Bread, 1.0);
				basket.CreateProduct(ProductType.Butter, 0.8);
				basket.CreateProduct(ProductType.Milk, 1.15);

				basket.AddProduct(ProductType.Bread, 1);
				basket.AddProduct(ProductType.Butter, 2);
				basket.AddProduct(ProductType.Milk, 8);

				IDiscount butterBreadDiscount = new ButterBreadDiscount();
				IDiscount milkDiscount = new MilkDiscount();
				basket.AddDiscount(butterBreadDiscount);
				basket.AddDiscount(milkDiscount);

				basket.ProcessOrder();
				}
			{

			}
		}
	}
}
