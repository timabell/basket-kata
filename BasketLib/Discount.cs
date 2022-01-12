namespace BasketLib;

/// <summary>
/// Discount to be included in the calculations of a basket's total.
/// Could potentially in future keep a reference to the item that was discounted but for now let's just make a list of numbers
/// </summary>
public class Discount
{
	public decimal Amount { get; set; }
	public string Description { get; set; }
}
