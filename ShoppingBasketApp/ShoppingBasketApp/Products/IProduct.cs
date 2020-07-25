

using System.Dynamic;
using System.Runtime.InteropServices;

namespace ShoppingBasketApp
{
	interface IProduct
	{
		ProductType Type { get; set; }
		double Price { get; set; }	
		int Count { get; set; }
	}
}
