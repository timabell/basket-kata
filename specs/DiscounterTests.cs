using System.Collections.Generic;
using System.Linq;

using BasketLib;

using FluentAssertions;

using NUnit.Framework;

namespace specs;

public class DiscounterTests
{
	[Test]
	public void TestDiscountedTotal()
	{
		var basket = new Basket();
		var milk = new Product("milk", 1.15m);
		4.Times(()=> basket.Add(milk));
		var discounter = new Discounter();
		basket.ApplyDiscounts(discounter);
		basket.Total().Should().Be(3.45m);
	}

	[Test]
	public void TestDiscounter()
	{
		var discounter = new Discounter();
		var milk = new Product("milk", 1.15m);
		var basketItems = new List<Product>
		{
			milk,
			milk,
			milk,
			milk,
		};
		var discounts = discounter.Calculate(basketItems);
		discounts.Should().ContainSingle();
		discounts.Single().Amount.Should().Be(1.15m);
		discounts.Single().Description.Should().Be("Free 4th milk");
	}
}
