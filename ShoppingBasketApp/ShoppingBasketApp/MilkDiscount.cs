using System;
using System.Collections.Generic;


namespace ShoppingBasketApp
{
	class MilkDiscount : IDiscount
	{
		MilkDiscount()
		{
			Type = DiscountType.Milk;
		}
		public DiscountType Type { get; set; }

		public void Apply(IEnumerable<IProduct> products)
		{
			throw new NotImplementedException();
		}
	}
}
