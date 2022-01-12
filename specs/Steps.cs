using System;
using System.Collections.Generic;
using System.Linq;

using BasketLib;

using FluentAssertions;

using TechTalk.SpecFlow;

namespace specs;

[Binding]
public class Steps
{
	private readonly Basket _basket = new();
	private readonly List<Product> _products = new() // list lifted from example spec, would be data driven in reality
	{
		new((string)"Butter", 0.8m),
		new((string)"Milk", 1.15m),
		new((string)"Bread", 1m),
	};

	[Then(@"the total should be £(.*)")]
	public void ThenTheTotalShouldBe(decimal expectedTotal)
	{
		_basket.Total().Should().Be(expectedTotal);
	}

	[Given(@"the basket has (.*) (.*)")]
	public void GivenTheBasketHasBreadButterAndMilk(int qty, string productName)
	{
		// note to reader: we could potentially give the basket a method for adding multiples, but this'll do for now, what it looked like would depend on the shape of the real world problem at hand
		qty.Times(() =>
			// Lookups in a list like this are less efficient than dictionaries etc but is fine for a quick proof of concept, can be optimized later.
			// Would probably be replaced wholesale with a proper data store & cache anyway.
			_basket.Add(_products.Single(p => productName.Equals(p.Name, StringComparison.InvariantCultureIgnoreCase)))
		);
	}

	[When(@"I apply discounts")]
	public void WhenIApplyDiscounts()
	{
		_basket.ApplyDiscounts(new Discounter());
	}
}
