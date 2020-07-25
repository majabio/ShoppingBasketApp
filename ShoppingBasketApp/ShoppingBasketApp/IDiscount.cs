using System.Collections.Generic;


namespace ShoppingBasketApp
{
	interface IDiscount
	{
		 DiscountType Type { get; set; }
		 void Apply(IEnumerable<IProduct> products);
	}
}
