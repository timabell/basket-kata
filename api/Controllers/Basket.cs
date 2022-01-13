using BasketLib;

using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("[controller]")]
public class BasketController : ControllerBase
{
	// GET
	[HttpGet("")]
	public object Index()
	{
		Basket basket = new();
		basket.Add(new Product("cheese", 2.99m));
		basket.Add(new Product("apple", 0.3m));
		basket.Add(new Product("milk", .9m));
		basket.Add(new Product("milk", .9m));
		basket.Add(new Product("milk", .9m));
		basket.Add(new Product("milk", .9m)); // magic string, 4th milk free
		basket.ApplyDiscounts(new Discounter());

		return new
		{
			basket.Products,
			basket.Discounts,
			total = basket.Total(),
		};
	}
}
