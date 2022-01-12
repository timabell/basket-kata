using System;
using System.Collections.Generic;
using System.Linq;

using FluentAssertions;

using TechTalk.SpecFlow;

namespace specs;

[Binding]
public class Steps
{
	private readonly Basket _basket = new Basket();
	private readonly List<Product> _products = new List<Product> // list lifted from example spec, would be data driven in reality
	{
		new("Butter", 0.8m),
		new("Milk", 1.15m),
		new("Bread", 1m),
	};

	[Then(@"the total should be £(.*)")]
	public void ThenTheTotalShouldBe(decimal expectedTotal)
	{
		_basket.Total().Should().Be(expectedTotal);
	}

	[When(@"I total the basket")]
	public void WhenITotalTheBasket()
	{
	}

	[Given(@"the basket has (.*) (.*)")]
	public void GivenTheBasketHasBreadButterAndMilk(int qty, string productName)
	{
		// Lookups in a list like this are less efficient than dictionaries etc but is fine for a quick proof of concept, can be optimized later.
		// Would probably be replaced wholesale with a proper data store & cache anyway.
		_basket.Add(_products.Single(p => productName.Equals(p.Name,StringComparison.InvariantCultureIgnoreCase)));
	}
}
