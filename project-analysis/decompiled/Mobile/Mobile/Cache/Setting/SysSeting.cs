using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using CRM.General.Cache;
using Elmah;
using Mobile.Classes;
using Mobile.Models;

namespace Mobile.Cache.Setting;

public static class SysSeting
{
	private static readonly string MainCacheName = Configuration.CacheDefaultName + Configuration.CacheUniqueName + "-Mob-Setting-SysSeting";

	private static readonly int DefaultTimeInMinutes = Configuration.CacheDefaultTimeInMinutes;

	public static MobspSelectCrmsysSetting_Result Get()
	{
		MobspSelectCrmsysSetting_Result value = null;
		try
		{
			if (!CacheManager.Get<MobspSelectCrmsysSetting_Result>(MainCacheName, out value))
			{
				CRMEntities cRMEntities = new CRMEntities();
				int result = 1065;
				MobspSelectCrmsysSetting_Result mobspSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<MobspSelectCrmsysSetting_Result>((IEnumerable<MobspSelectCrmsysSetting_Result>)Enumerable.ToList<MobspSelectCrmsysSetting_Result>((IEnumerable<MobspSelectCrmsysSetting_Result>)cRMEntities.MobspSelectCrmsysSetting(Thread.CurrentThread.CurrentCulture.LCID, result)));
				if (mobspSelectCrmsysSetting_Result != null)
				{
					int.TryParse(mobspSelectCrmsysSetting_Result.DefaultLanguageID.ToString(), out result);
				}
				value = Enumerable.FirstOrDefault<MobspSelectCrmsysSetting_Result>((IEnumerable<MobspSelectCrmsysSetting_Result>)Enumerable.ToList<MobspSelectCrmsysSetting_Result>((IEnumerable<MobspSelectCrmsysSetting_Result>)cRMEntities.MobspSelectCrmsysSetting(Thread.CurrentThread.CurrentCulture.LCID, result)));
				cRMEntities.Dispose();
				if (value != null)
				{
					CacheManager.Add(value, MainCacheName, DefaultTimeInMinutes);
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return value;
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

	public static bool Update()
	{
		try
		{
			CRMEntities cRMEntities = new CRMEntities();
			int result = 1065;
			MobspSelectCrmsysSetting_Result mobspSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<MobspSelectCrmsysSetting_Result>((IEnumerable<MobspSelectCrmsysSetting_Result>)Enumerable.ToList<MobspSelectCrmsysSetting_Result>((IEnumerable<MobspSelectCrmsysSetting_Result>)cRMEntities.MobspSelectCrmsysSetting(Thread.CurrentThread.CurrentCulture.LCID, result)));
			if (mobspSelectCrmsysSetting_Result != null)
			{
				int.TryParse(mobspSelectCrmsysSetting_Result.DefaultLanguageID.ToString(), out result);
			}
			MobspSelectCrmsysSetting_Result mobspSelectCrmsysSetting_Result2 = Enumerable.FirstOrDefault<MobspSelectCrmsysSetting_Result>((IEnumerable<MobspSelectCrmsysSetting_Result>)Enumerable.ToList<MobspSelectCrmsysSetting_Result>((IEnumerable<MobspSelectCrmsysSetting_Result>)cRMEntities.MobspSelectCrmsysSetting(Thread.CurrentThread.CurrentCulture.LCID, result)));
			cRMEntities.Dispose();
			if (mobspSelectCrmsysSetting_Result2 != null)
			{
				CacheManager.Clear(MainCacheName);
				CacheManager.Add(mobspSelectCrmsysSetting_Result2, MainCacheName, DefaultTimeInMinutes);
				return true;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return false;
	}
}
