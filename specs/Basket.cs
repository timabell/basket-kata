using System.Collections.Generic;
using System.Linq;

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
		return _products.Sum(p => p.Price);
	}
}
