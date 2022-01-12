Feature: Discounts
	Create a customer basket that allows a customer to add products and provides a total cost of the basket including applicable discounts. Offers can be cumulative
	Setup:
		Available products:
		- Product Cost
		- Butter £0.80
		- Milk £1.15
		- Bread £1.00
		Offers:
		· Buy 2 Butter and get a Bread at 50% off
		· Buy 3 Milk and get the 4th milk for free

Scenario: one of each (no discounts)
	Given the basket has 1 bread
		And the basket has 1 butter
		And the basket has 1 milk
	When I apply discounts
	Then the total should be £2.95

Scenario: two butter (no discounts)
	Given the basket has 2 butter
	When I apply discounts
	Then the total should be £1.60

Scenario: two of each (butter/bread discount)
	Given the basket has 2 butter
		And the basket has 2 bread
	When I apply discounts
	Then the total should be £3.10

Scenario: lots of milk (milk discount)
	Given the basket has 4 milk
	When I apply discounts
	Then the total should be £3.45

Scenario: lots of everything (butter/bread + milk discounts)
	Given the basket has 2 butter
		And the basket has 1 bread
		And the basket has 8 milk
	When I apply discounts
	Then the total should be £9.00
