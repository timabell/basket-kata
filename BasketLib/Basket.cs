namespace BasketLib;

public class Basket
{
	public List<Product> Products { get; } = new();
	public List<Discount> Discounts { get; } = new();

	public void Add(Product product)
	{
		Products.Add(product);
	}

	public decimal Total()
	{
		var subtotal = Products.Sum(p => p.Price);
		var discountSubtotal = Discounts.Sum(d => d.Amount);
		return subtotal - discountSubtotal;
	}

	public void ApplyDiscounts(IDiscounter discounter)
	{
		Discounts.Clear();
		Discounts.AddRange(discounter.Calculate(Products));
	}
}
