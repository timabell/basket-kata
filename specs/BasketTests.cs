using System.Collections.Generic;

using BasketLib;

using FluentAssertions;
using NUnit.Framework;

namespace specs;

public class BasketTests
{
	[Test]
	public void TestTotal()
	{
		var basket = new Basket();
		basket.Add(new Product("foo", 1.23m));
		basket.Add(new Product("bar", 6.98m));
		basket.Total().Should().Be(8.21m);
	}

	[Test]
	public void TestItemAccess()
	{
		var basket = new Basket();
		var product = new Product("foo", 1.23m);
		basket.Add(product);
		basket.Products.Should().ContainSingle(p => p == product);
	}

	[Test]
	public void TestDiscountedBasketTotal()
	{
		var basket = new Basket();
		basket.Add(new Product("example", 10m));
		var discounter = new FakeDiscounter();
		basket.ApplyDiscounts(discounter);
		basket.Total().Should().Be(8.89m);
	}
}

public class FakeDiscounter : IDiscounter
{
	public IEnumerable<Discount> Calculate(List<Product> products)
	{
		return new List<Discount> { new Discount { Amount = 1.11m, Description = "stub discount"} };
	}
}
