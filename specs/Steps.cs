using TechTalk.SpecFlow;

namespace specs;

[Binding]
public class Steps
{
	[Then(@"the total should be £(.*)")]
	public void ThenTheTotalShouldBe(decimal p0)
	{
		ScenarioContext.StepIsPending();
	}

	[When(@"I total the basket")]
	public void WhenITotalTheBasket()
	{
		ScenarioContext.StepIsPending();
	}

	[Given(@"the basket has (.*) (.*)")]
	public void GivenTheBasketHasBreadButterAndMilk(int qty, string what)
	{
		ScenarioContext.StepIsPending();
	}
}
