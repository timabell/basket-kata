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
		basket.Total().Should().Be(3.45m);
	}
}
