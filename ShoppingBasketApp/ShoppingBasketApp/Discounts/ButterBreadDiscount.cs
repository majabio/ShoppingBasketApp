using System.Collections.Generic;
using System.Linq;

namespace ShoppingBasketApp
{
	class ButterBreadDiscount : IDiscount
	{
		private const int appliable_amount = 2;
		private const double discount = 0.5;

		internal ButterBreadDiscount()
		{
			Type = DiscountType.ButterBread;
		}

		public DiscountType Type { get; set; }

		public double Apply(IEnumerable<IProduct> products)
		{
			IProduct bread = products?.FirstOrDefault(p => p.Type == ProductType.Bread);
			IProduct butter = products?.FirstOrDefault(p => p.Type == ProductType.Butter);

			if (null == butter|| null == bread)
				return 0.0;

			return butter.Count / appliable_amount * discount * bread.Price;
		}
	}
}
