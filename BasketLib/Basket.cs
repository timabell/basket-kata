namespace BasketLib;

public class Basket
{
	public List<Product> Products { get; } = new();
	private readonly List<Discount> _discounts = new();

	public void Add(Product product)
	{
		Products.Add(product);
	}

	public decimal Total()
	{
		var subtotal = Products.Sum(p => p.Price);
		var discountSubtotal = _discounts.Sum(d => d.Amount);
		return subtotal - discountSubtotal;
	}

	public void ApplyDiscounts(IDiscounter discounter)
	{
		_discounts.AddRange(discounter.Calculate(Products));
	}
}
