namespace ShoppingBasketApp
{
	class Product : IProduct
	{
		public Product(ProductType type, double price, int count = 0)
		{
			Type = type;
			Price = price;
			Count = count;
		}

		private double price;
		private const double min_price = 0.0;
		public ProductType Type { get; set; }
		public double Price
		{
			get { return price; }
			set
			{
				if (value == price || value < min_price)
					return;
				price = value;
			}
		}
		public int Count { get; set; }
	}
}