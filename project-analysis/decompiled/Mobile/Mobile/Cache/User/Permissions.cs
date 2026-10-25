using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using CRM.General.Cache;
using Elmah;
using Mobile.Classes;
using Mobile.Classes.Helper;
using Mobile.Models;

namespace Mobile.Cache.User;

public static class Permissions
{
	private static readonly object obj = new object();

	private static readonly string MainCacheName = Configuration.CacheDefaultName + Configuration.CacheUniqueName + "-Mob-User-Permissions-";

	private static readonly int DefaultTimeInMinutes = Configuration.CacheDefaultTimeInMinutes;

	public static List<MobspSelectUserRollPermission_Result> Get(int? userId = null, int? cId = null)
	{
		IIdentity identity = Thread.CurrentPrincipal.Identity;
		Common common = new Common();
		List<MobspSelectUserRollPermission_Result> value = new List<MobspSelectUserRollPermission_Result>();
		lock (obj)
		{
			try
			{
				int result = 0;
				if (!userId.HasValue)
				{
					if (identity.Name != null)
					{
						result = common.GetToken(identity.Name).userId;
					}
				}
				else
				{
					int.TryParse(userId.ToString(), out result);
				}
				if (result != 0)
				{
					string key = MainCacheName + result;
					if (!CacheManager.Get<List<MobspSelectUserRollPermission_Result>>(key, out value))
					{
						CRMEntities cRMEntities = new CRMEntities();
						value = Enumerable.ToList<MobspSelectUserRollPermission_Result>((IEnumerable<MobspSelectUserRollPermission_Result>)cRMEntities.MobspSelectUserRollPermission(result, cId));
						cRMEntities.Dispose();
						CacheManager.Add(value, key, DefaultTimeInMinutes);
					}
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
			Common common = new Common();
			int result = 0;
			if (!userId.HasValue)
			{
				if (identity.Name != null)
				{
					result = common.GetToken(identity.Name).userId;
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

	public static bool Update(int? userId = null, int? cId = null)
	{
		lock (obj)
		{
			try
			{
				IIdentity identity = Thread.CurrentPrincipal.Identity;
				Common common = new Common();
				int result = 0;
				if (!userId.HasValue)
				{
					if (identity.Name != null)
					{
						result = common.GetToken(identity.Name).userId;
					}
				}
				else
				{
					int.TryParse(userId.ToString(), out result);
				}
				if (result != 0)
				{
					string key = MainCacheName + result;
					CRMEntities cRMEntities = new CRMEntities();
					List<MobspSelectUserRollPermission_Result> o = Enumerable.ToList<MobspSelectUserRollPermission_Result>((IEnumerable<MobspSelectUserRollPermission_Result>)cRMEntities.MobspSelectUserRollPermission(result, cId));
					cRMEntities.Dispose();
					CacheManager.Clear(key);
					CacheManager.Add(o, key, DefaultTimeInMinutes);
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
