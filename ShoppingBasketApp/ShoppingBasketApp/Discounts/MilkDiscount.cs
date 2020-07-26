using System.Collections.Generic;
using System.Linq;

namespace ShoppingBasketApp
{
	class MilkDiscount : IDiscount
	{
		private const int appliable_amount = 4;

		internal MilkDiscount()
		{
			Type = DiscountType.Milk;
		}
		public DiscountType Type { get; set; }

		public double Apply(IEnumerable<IProduct> products)
		{
			IProduct milk = products.First(p => p.Type == ProductType.Milk);
			if (milk == null)
				return 0.0;
			return milk.Count / appliable_amount * milk.Price;
		}
	}
}
