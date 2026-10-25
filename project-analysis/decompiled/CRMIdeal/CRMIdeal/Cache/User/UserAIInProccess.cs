using System;
using System.Security.Principal;
using System.Threading;
using CRM.General.Cache;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes.Common;
using Elmah;

namespace CRMIdeal.Cache.User;

public static class UserAIInProccess
{
	private static readonly object obj = new object();

	private static readonly string MainCacheName = Configuration.CacheDefaultName + Configuration.CacheUniqueName + "-User-AIInProccess-";

	private static readonly int DefaultTimeInMinutes = Configuration.CacheDefaultTimeInMinutes;

	public static bool Get(int? userId = null)
	{
		IIdentity identity = Thread.CurrentPrincipal.Identity;
		bool value = false;
		lock (obj)
		{
			try
			{
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
				if (result != 0)
				{
					CacheManager.Get<bool>(MainCacheName + result, out value);
					return value;
				}
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
			}
		}
		return value;
	}

	public static bool Clear(int? userId = null)
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
			if (result != 0)
			{
				CacheManager.Clear(MainCacheName + result);
				return true;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return false;
	}

	public static bool Update(int? userId = null, bool value = false)
	{
		lock (obj)
		{
			try
			{
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
				if (result <= 0)
				{
					result = 1065;
				}
				_ = Thread.CurrentThread.CurrentCulture.LCID;
				IIdentity identity = Thread.CurrentPrincipal.Identity;
				int result2 = 0;
				if (!userId.HasValue)
				{
					if (identity.Name != null)
					{
						int.TryParse(identity.Name, out result2);
					}
				}
				else
				{
					int.TryParse(userId.ToString(), out result2);
				}
				if (result2 != 0)
				{
					string key = MainCacheName + result2;
					CacheManager.Clear(key);
					CacheManager.Add(value, key, DefaultTimeInMinutes);
					return true;
				}
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
			}
		}
		return false;
	}
}
