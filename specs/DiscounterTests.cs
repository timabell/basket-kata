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

	[Test]
	public void AppliesBreadDiscount()
	{
		var discounter = new Discounter();
		var basketItems = new List<Product>();
		var butter = new Product("butter", 0.8m);
		2.Times(()=> basketItems.Add(butter));
		basketItems.Add(new Product("bread", 1m));
		var discounts = discounter.Calculate(basketItems);
		discounts.Should().ContainSingle();
		discounts.Single().Amount.Should().Be(new Product("bread", 1m).Price * 0.5m); // 50% off bread
		discounts.Single().Description.Should().Be("Half price bread with 2x butter");
	}
}
