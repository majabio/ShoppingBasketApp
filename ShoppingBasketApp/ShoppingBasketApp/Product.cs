using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBasketApp
{
	class Product : IProduct
	{
		Product(ProductType type )
		{
			Type = type;
		}

		private double price;
		private const double min_price = 0.0;
		public ProductType Type { get; set; }
		public double Price 
		{ 
			get { return price; }
			set 
			{
				if (price == value || price < min_price)
					return;
				price = value;
			} 
		}
	}
}