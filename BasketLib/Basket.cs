namespace BasketLib;

public class Basket
{
	private readonly List<Product> _products = new();
	private readonly List<Discount> _discounts = new();

	public void Add(Product product)
	{
		_products.Add(product);
	}

	public decimal Total()
	{
		var subtotal = _products.Sum(p => p.Price);
		var discountSubtotal = _discounts.Sum(d => d.Amount);
		return subtotal - discountSubtotal;
	}

	public void ApplyDiscounts(IDiscounter discounter)
	{
		_discounts.AddRange(discounter.Calculate(_products));
	}
}
