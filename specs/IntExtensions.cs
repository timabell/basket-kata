using System;

namespace specs;

public static class IntExtensions
{
	public static void Times(this int count, Action action)
	{
		// https://stackoverflow.com/questions/3932413/is-there-a-shorter-simpler-version-of-the-for-loop-to-anything-x-times/3932432#3932432
		for (int i = 0; i < count; i++)
		{
			action();
		}
	}
}
