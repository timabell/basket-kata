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
}
