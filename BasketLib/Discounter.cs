namespace BasketLib;

/// <summary>
/// A stateful visitor (pattern) that walks a basket of goods calculating discounts and then returning what to apply
/// with object references.
/// Note that the logic for real discounting is non-trivial so I won't be implementing a bullet-proof version of this,
/// just enough to pass the tests for now as a basis for iterating. I had a friend who worked on a real EPOS system as it happens.
/// </summary>
public class Discounter : IDiscounter
{
	public IEnumerable<Discount> Calculate(List<Product> products)
	{
		var discounts = new List<Discount>();
		// todo: replace string matching with some better referencing system
		// 4th milk free (todo: validate with BA whether this also applies to 8th milk, currently no)
		var milks = products.Where(p => p.Name.Equals("milk", StringComparison.InvariantCultureIgnoreCase));
		if (milks.Count() > 3)
		{
			discounts.Add(new Discount{Amount = milks.First().Price, Description = "Free 4th milk"});
		}
		return discounts;
	}
}
