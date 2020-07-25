

using System.Dynamic;

namespace ShoppingBasketApp
{
	interface IProduct
	{
		ProductType Type { get; set; }
		double Price { get; set; }
	}
}
