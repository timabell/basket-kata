using System.Collections.Generic;
using System.Linq;

using BasketLib;

using FluentAssertions;

using NUnit.Framework;

namespace specs;

public class DiscounterTests
{
	[Test]
	// boundary checks
	[TestCase(3, 1.15, 0)]
	[TestCase(4, 1.15, 1)]
	[TestCase(5, 1.15, 1)]
	// ...
	[TestCase(7, 1.15, 1)]
	[TestCase(8, 1.15, 2)]
	[TestCase(9, 1.15, 2)]
	public void AppliesMilkDiscount(int milkQty, decimal milkPrice, int expectedFreeMilkCount)
	{
		var discounter = new Discounter();
		var milk = new Product("milk", milkPrice);
		var basketItems = new List<Product>();
		milkQty.Times(() => basketItems.Add(milk));
		var discounts = discounter.Calculate(basketItems).ToList();
		discounts.Should().HaveCount(expectedFreeMilkCount);
		if (expectedFreeMilkCount > 0)
		{
			discounts.Should().OnlyContain(
				d => d.Amount == milkPrice
				     && d.Description == "Free 4th milk"
			);
		}
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
