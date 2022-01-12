using System.Collections.Generic;
using System.Linq;

using BasketLib;

using FluentAssertions;

using NUnit.Framework;

namespace specs;

public class DiscounterTests
{
	[Test]
	public void AppliesMilkDiscount()
	{
		var discounter = new Discounter();
		var milk = new Product("milk", 1.15m);
		var basketItems = new List<Product>();
		4.Times(()=> basketItems.Add(milk));
		var discounts = discounter.Calculate(basketItems);
		discounts.Should().ContainSingle();
		discounts.Single().Amount.Should().Be(1.15m);
		discounts.Single().Description.Should().Be("Free 4th milk");
	}
}
