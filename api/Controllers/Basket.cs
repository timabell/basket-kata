using BasketLib;

using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("[controller]")]
public class BasketController : ControllerBase
{
	private static Basket basket = new(); // stub in-memory storage for the basket. Todo: real persistence

	[HttpGet("")]
	public object Index() // todo: use a real type and check it shows in swagger
	{
		basket.ApplyDiscounts(new Discounter());

		return new
		{
			basket.Products,
			basket.Discounts,
			total = basket.Total(),
		};
	}

	[HttpPost("Add")]
	public void Add(Product product)
	{
		// todo: obviously the client shouldn't be able to set the price of the product. The product/basket modelling needs work.
		basket.Add(product);
		basket.ApplyDiscounts(new Discounter());
	}

	[HttpPost("Clear")]
	public void Clear()
	{
		basket.Clear();
	}
}
