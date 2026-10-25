using System;
using System.Collections.Generic;
using System.Linq;

namespace CRM.General.Utilities;

public class Lists
{
	public static T GetNext<T>(IEnumerable<T> list, T current)
	{
		try
		{
			return Enumerable.First<T>(Enumerable.Skip<T>(Enumerable.SkipWhile<T>(list, (Func<T, bool>)((T c) => !c.Equals(current))), 1));
		}
		catch
		{
			return default(T);
		}
	}

	public static T GetPrevious<T>(IEnumerable<T> list, T current)
	{
		try
		{
			return Enumerable.Last<T>(Enumerable.TakeWhile<T>(list, (Func<T, bool>)((T c) => !c.Equals(current))));
		}
		catch
		{
			return default(T);
		}
	}
}
