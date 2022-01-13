using BasketLib;

using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("[controller]")]
public class BasketController : ControllerBase
{
	// GET
	[HttpGet("")]
	public IEnumerable<Product> Index()
	{
		Basket basket = new();
		basket.Add(new Product("cheese", 2.99m));
		basket.Add(new Product("apple", 0.3m));
		return basket.Products;
	}
}
