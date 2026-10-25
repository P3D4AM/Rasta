using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using CRM.General.Cache;
using CRMIdeal.Classes.Common;
using Elmah;

namespace CRMIdeal.Cache.Setting;

public static class LoginCount
{
	private static readonly string MainCacheName = Configuration.CacheDefaultName + Configuration.CacheUniqueName + "-Setting-LoginCount";

	private static readonly int DefaultTimeInMinutes = Configuration.CacheDefaultTimeInMinutes;

	public static Dictionary<int, int> Get()
	{
		if (!CacheManager.Get<Dictionary<int, int>>(MainCacheName, out var value))
		{
			value = new Dictionary<int, int>();
			CacheManager.Add(value, MainCacheName, DefaultTimeInMinutes);
		}
		return value;
	}

	public static bool Update(LoginCountType type, int? userId = null)
	{
		try
		{
			IIdentity identity = Thread.CurrentPrincipal.Identity;
			int result = 0;
			if (!userId.HasValue)
			{
				if (identity.Name != null)
				{
					int.TryParse(identity.Name, out result);
				}
			}
			else
			{
				int.TryParse(userId.ToString(), out result);
			}
			if (result > 0)
			{
				Dictionary<int, int> dictionary = Get();
				if (!dictionary.ContainsKey(result))
				{
					switch (type)
					{
					case LoginCountType.Plus:
						dictionary.Add(result, 1);
						break;
					case LoginCountType.Minus:
						dictionary[result] = 0;
						break;
					}
				}
				else
				{
					int num = dictionary[result];
					switch (type)
					{
					case LoginCountType.Plus:
						dictionary[result] = num + 1;
						break;
					case LoginCountType.Minus:
						dictionary[result] = 0;
						break;
					}
				}
				CacheManager.Clear(MainCacheName);
				CacheManager.Add(dictionary, MainCacheName, DefaultTimeInMinutes);
				return true;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return false;
	}

	public static bool Clear()
	{
		try
		{
			CacheManager.Clear(MainCacheName);
			return true;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return false;
	}

	public static int Count()
	{
		int num = 0;
		try
		{
			Dictionary<int, int> dictionary = Get();
			num += Enumerable.Sum<KeyValuePair<int, int>>((IEnumerable<KeyValuePair<int, int>>)dictionary, (Func<KeyValuePair<int, int>, int>)((KeyValuePair<int, int> entry) => entry.Value));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return num;
	}
}
