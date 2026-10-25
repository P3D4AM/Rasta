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

namespace Mobile.Cache.MobUser;

public static class Info
{
	private static readonly object obj = new object();

	private static readonly string MainCacheName = Configuration.CacheDefaultName + Configuration.CacheUniqueName + "-Mob-User-Info-";

	private static readonly int DefaultTimeInMinutes = Configuration.CacheDefaultTimeInMinutes;

	public static UserLoginInfo Get(int? userId = null)
	{
		IIdentity identity = Thread.CurrentPrincipal.Identity;
		new Common();
		UserLoginInfo value = null;
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
				if (result > 0)
				{
					string key = MainCacheName + result;
					if (!CacheManager.Get<UserLoginInfo>(key, out value))
					{
						CRMEntities cRMEntities = new CRMEntities();
						MobspLoadUserLoginInfo_Result mobspLoadUserLoginInfo_Result = Enumerable.FirstOrDefault<MobspLoadUserLoginInfo_Result>((IEnumerable<MobspLoadUserLoginInfo_Result>)cRMEntities.MobspLoadUserLoginInfo(result, "", "", null, null));
						cRMEntities.Dispose();
						if (mobspLoadUserLoginInfo_Result != null)
						{
							value = new UserLoginInfo
							{
								UserId = mobspLoadUserLoginInfo_Result.UserId,
								IsActive = mobspLoadUserLoginInfo_Result.IsActive,
								FullName = mobspLoadUserLoginInfo_Result.FullName,
								RollName = mobspLoadUserLoginInfo_Result.RollName
							};
							CacheManager.Add(value, key, DefaultTimeInMinutes);
						}
						else
						{
							ErrorSignal.FromCurrentContext().Raise(new Exception("Unable To Find User Info From MobspLoadUserLoginInfo And We Can't Create Cache For User.\n On Mobile.Cache.MobUser.Info.Get()"));
						}
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
			if (result > 0)
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

	public static bool Update(int? userId = null, bool? fromLoginPage = null)
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
				if (result > 0)
				{
					string key = MainCacheName + result;
					CRMEntities cRMEntities = new CRMEntities();
					MobspLoadUserLoginInfo_Result mobspLoadUserLoginInfo_Result = Enumerable.FirstOrDefault<MobspLoadUserLoginInfo_Result>((IEnumerable<MobspLoadUserLoginInfo_Result>)cRMEntities.MobspLoadUserLoginInfo(result, "", "", null, null));
					cRMEntities.Dispose();
					if (mobspLoadUserLoginInfo_Result != null)
					{
						CacheManager.Clear(key);
						CacheManager.Add(new UserLoginInfo
						{
							UserId = mobspLoadUserLoginInfo_Result.UserId,
							IsActive = mobspLoadUserLoginInfo_Result.IsActive,
							FullName = mobspLoadUserLoginInfo_Result.FullName,
							RollName = mobspLoadUserLoginInfo_Result.RollName
						}, key, DefaultTimeInMinutes);
						return true;
					}
					ErrorSignal.FromCurrentContext().Raise(new Exception("Unable To Find User Info From MobspLoadUserLoginInfo And We Can't Create Cache For User.\n On Mobile.Cache.MobUser.Info.Update()"));
					return false;
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
