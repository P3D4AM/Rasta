using System;
using System.Collections;
using System.Web;
using System.Web.Caching;

namespace CRM.General.Cache;

public static class CacheManager
{
	public static void Add<T>(T o, string key, int timeAdd)
	{
		HttpRuntime.Cache.Insert(key, (object)o, (CacheDependency)null, DateTime.Now.AddMinutes(timeAdd), Cache.NoSlidingExpiration, (CacheItemPriority)6, (CacheItemRemovedCallback)null);
	}

	public static void Clear(string key)
	{
		HttpRuntime.Cache.Remove(key);
	}

	public static bool Exists(string key)
	{
		return HttpRuntime.Cache[key] != null;
	}

	public static bool Get<T>(string key, out T value)
	{
		try
		{
			if (!Exists(key))
			{
				value = default(T);
				return false;
			}
			value = (T)HttpRuntime.Cache[key];
		}
		catch
		{
			value = default(T);
			return false;
		}
		return true;
	}

	public static bool ClearAll()
	{
		try
		{
			IDictionaryEnumerator enumerator = HttpRuntime.Cache.GetEnumerator();
			while (enumerator.MoveNext())
			{
				HttpRuntime.Cache.Remove(enumerator.Key.ToString());
			}
			foreach (DictionaryEntry item in HttpRuntime.Cache)
			{
				HttpRuntime.Cache.Remove(item.Key.ToString());
			}
		}
		catch
		{
			return false;
		}
		return true;
	}
}
