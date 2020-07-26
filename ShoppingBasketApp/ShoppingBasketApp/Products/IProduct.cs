namespace ShoppingBasketApp
{
	//not really needed
	interface IProduct
	{
		ProductType Type { get; set; }
		double Price { get; set; }	
		int Count { get; set; }
	}
}
