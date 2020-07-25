using System;
using System.Collections.Generic;

namespace ShoppingBasketApp
{
	class ButterBreadDiscount : IDiscount
	{
		ButterBreadDiscount()
		{
			Type = DiscountType.ButterBread;
		}

		public DiscountType Type { get; set; }

		public double Apply(IEnumerable<IProduct> products)
		{
			throw new NotImplementedException();
		}
	}
}
