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
		return new List<Discount>();
	}
}
