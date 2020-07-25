using System.Collections.Generic;


namespace ShoppingBasketApp
{
	interface IDiscount
	{
		 DiscountType Type { get; set; }
		 double Apply(IEnumerable<IProduct> products);
	}
}
