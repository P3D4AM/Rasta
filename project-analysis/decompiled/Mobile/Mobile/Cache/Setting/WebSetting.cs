using System;
using System.Collections.Generic;
using System.Linq;
using CRM.General.Cache;
using Elmah;
using Mobile.Classes;
using Mobile.Models;

namespace Mobile.Cache.Setting;

public static class WebSetting
{
	private static readonly string MainCacheName = Configuration.CacheDefaultName + Configuration.CacheUniqueName + "-Mob-Setting-WebSetting";

	private static readonly int DefaultTimeInMinutes = Configuration.CacheDefaultTimeInMinutes;

	public static List<MobspSelectCrmWebSetting_Result> Get()
	{
		List<MobspSelectCrmWebSetting_Result> value = null;
		try
		{
			if (!CacheManager.Get<List<MobspSelectCrmWebSetting_Result>>(MainCacheName, out value))
			{
				CRMEntities cRMEntities = new CRMEntities();
				value = Enumerable.ToList<MobspSelectCrmWebSetting_Result>((IEnumerable<MobspSelectCrmWebSetting_Result>)cRMEntities.MobspSelectCrmWebSetting());
				cRMEntities.Dispose();
				if (value.Count > 0)
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
			List<MobspSelectCrmWebSetting_Result> list = Enumerable.ToList<MobspSelectCrmWebSetting_Result>((IEnumerable<MobspSelectCrmWebSetting_Result>)cRMEntities.MobspSelectCrmWebSetting());
			cRMEntities.Dispose();
			if (list.Count > 0)
			{
				CacheManager.Clear(MainCacheName);
				CacheManager.Add(list, MainCacheName, DefaultTimeInMinutes);
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
