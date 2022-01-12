namespace specs;

internal class Product
{
	public string Name { get; }
	public decimal Price { get; }

	public Product(string name, decimal price)
	{
		Name = name;
		Price = price;
	}
}
