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
		basket.ApplyDiscounts(new FakeDiscounter());
		basket.ApplyDiscounts(new FakeDiscounter()); // duplicate call shouldn't double-up discounts
		basket.Total().Should().Be(8.89m);
	}

	[Test]
	public void TestDiscountItemAccess()
	{
		var basket = new Basket();
		basket.Add(new Product("example", 10m));
		basket.ApplyDiscounts(new FakeDiscounter());
		basket.ApplyDiscounts(new FakeDiscounter()); // duplicate call shouldn't double-up discounts
		basket.Discounts.Should().ContainSingle(d => d == FakeDiscounter.FakeDiscount);
	}

	[Test]
	public void TestClear()
	{
		// arrange
		var basket = new Basket();
		var product = new Product("foo", 1.23m);
		basket.Add(product);
		basket.ApplyDiscounts(new FakeDiscounter()); // make sure there's a discount so we can be sure it was actually cleared
		// double-check setup created the expected state:
		basket.Discounts.Should().ContainSingle(d => d == FakeDiscounter.FakeDiscount);
		basket.Products.Should().ContainSingle(p => p == product);

		// Act
		basket.Clear();

		// Assert
		basket.Discounts.Should().BeEmpty();
		basket.Products.Should().BeEmpty();
		basket.Total().Should().Be(0m);
	}
}

public class FakeDiscounter : IDiscounter
{
	public static readonly Discount FakeDiscount = new Discount { Amount = 1.11m, Description = "stub discount"};

	public IEnumerable<Discount> Calculate(List<Product> products)
	{
		return new List<Discount> { FakeDiscount };
	}
}
