namespace BasketLib;

public class Basket
{
	// todo: Convert products to list of basket items with product + discount so we have somewhere to store discounts, update total calcs to include them
	// todo: Add a discount method, pass in a IDiscounter that takes actions with some kind of callback (to avoid tight coupling or embedding the discount code in the basket)
	// todo: Make a discounter that walks the basket list applies the discounts - danger, mutation, maybe yield a discount
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
