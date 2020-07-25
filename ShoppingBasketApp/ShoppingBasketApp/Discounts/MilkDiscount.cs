using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingBasketApp
{
	class MilkDiscount : IDiscount
	{
		MilkDiscount()
		{
			Type = DiscountType.Milk;
		}
		public DiscountType Type { get; set; }

		public double Apply(IEnumerable<IProduct> products)
		{

			return 0.0;
		}
	}
}
