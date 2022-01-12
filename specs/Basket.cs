using System.Collections.Generic;

namespace specs;

internal class Basket
{
	private List<Product> _products = new();
	public void Add(Product product)
	{
		_products.Add(product);
	}

	public decimal Total()
	{
		return 1234.56m; // temporary failing result
	}
}
