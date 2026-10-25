using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using CRM.General.Cache;
using CRM.Models;
using CRMIdeal.Classes.Common;
using CRMIdeal.Classes.Helper;
using Elmah;

namespace CRMIdeal.Cache.User;

public static class Permissions
{
	private static readonly object obj = new object();

	private static readonly string MainCacheName = Configuration.CacheDefaultName + Configuration.CacheUniqueName + "-User-Permissions-";

	private static readonly int DefaultTimeInMinutes = Configuration.CacheDefaultTimeInMinutes;

	public static List<CRMspSelectUserRollPermissionJustForCash_Result> Get(int? userId = null, int? centerId = null)
	{
		IIdentity identity = Thread.CurrentPrincipal.Identity;
		List<CRMspSelectUserRollPermissionJustForCash_Result> value = new List<CRMspSelectUserRollPermissionJustForCash_Result>();
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
				int result2 = 0;
				if (!centerId.HasValue)
				{
					result2 = CRMIdeal.Classes.Helper.User.GetUserLastCId(result, 1065, 1065);
				}
				else
				{
					int.TryParse(centerId.ToString(), out result2);
				}
				if (result != 0 && result2 != 0)
				{
					string key = MainCacheName + result;
					if (!CacheManager.Get<List<CRMspSelectUserRollPermissionJustForCash_Result>>(key, out value))
					{
						CRMSpEntities cRMSpEntities = new CRMSpEntities();
						value = Enumerable.ToList<CRMspSelectUserRollPermissionJustForCash_Result>((IEnumerable<CRMspSelectUserRollPermissionJustForCash_Result>)cRMSpEntities.CRMspSelectUserRollPermissionJustForCash(result, result2));
						cRMSpEntities.Dispose();
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

	public static bool Update(int? userId = null, int? centerId = null)
	{
		lock (obj)
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
				int result2 = 0;
				if (!centerId.HasValue)
				{
					result2 = CRMIdeal.Classes.Helper.User.GetUserLastCId(result, 1065, 1065);
				}
				else
				{
					int.TryParse(centerId.ToString(), out result2);
				}
				if (result != 0 && result2 != 0)
				{
					string key = MainCacheName + result;
					CRMSpEntities cRMSpEntities = new CRMSpEntities();
					List<CRMspSelectUserRollPermissionJustForCash_Result> o = Enumerable.ToList<CRMspSelectUserRollPermissionJustForCash_Result>((IEnumerable<CRMspSelectUserRollPermissionJustForCash_Result>)cRMSpEntities.CRMspSelectUserRollPermissionJustForCash(result, result2));
					cRMSpEntities.Dispose();
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
