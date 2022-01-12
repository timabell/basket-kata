namespace BasketLib;

public interface IDiscounter
{
	public IEnumerable<Discount> Calculate(List<Product> products);
}
