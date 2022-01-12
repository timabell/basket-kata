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

		// we could potentially go polymorphic with this, but that ties us further in to pure code rather than
		// data-driven discount systems which will be harder to iterate fast on or let non-coders modify.
		discounts.AddRange(MilkDiscount(products));
		discounts.AddRange(BreadDiscount(products));

		return discounts;
	}

	private IEnumerable<Discount> BreadDiscount(List<Product> products)
	{
		// todo: replace string matching with some better referencing system
		var butters = products.Where(p => p.Name.Equals("butter", StringComparison.InvariantCultureIgnoreCase));
		var bread = products.FirstOrDefault(p => p.Name.Equals("bread", StringComparison.InvariantCultureIgnoreCase));

		// half price bread with 2x butter (todo: validate if this is one offer per customer or if they can stack em up)
		if ((butters.Count() >= 2) && bread != null)
		{
			return new List<Discount> { new() { Amount = bread.Price * 0.5m, Description = "Half price bread with 2x butter" } };
		}

		return new List<Discount>();
	}

	private static IEnumerable<Discount> MilkDiscount(IEnumerable<Product> products)
	{
		var discounts = new List<Discount>();
		// todo: replace string matching with some better referencing system
		var milks = products.Where(p => p.Name.Equals("milk", StringComparison.InvariantCultureIgnoreCase)).ToList();

		int milkDiscounts = (int)Math.Floor(milks.Count / 4m); // every 4th milk free
		for (int i = 0; i < milkDiscounts ; i++)
		{
			discounts.Add(new Discount { Amount = milks.First().Price, Description = "Free 4th milk" });
		}

		return discounts;

	}
}
