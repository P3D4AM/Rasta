using System;
using CRM.General.Cache;
using Elmah;
using Mobile.Classes;
using Mobile.Classes.Helper;
using Mobile.Models;

namespace Mobile.Cache.Setting;

public static class FoSettingShareInfo
{
	private static readonly string MainCacheName = Configuration.CacheDefaultName + Configuration.CacheUniqueName + "-Setting-FoSettingShareInfo";

	private static readonly int DefaultTimeInMinutes = Configuration.CacheDefaultTimeInMinutes;

	public static FoSettingShareInfoViewModel Get()
	{
		FoSettingShareInfoViewModel value = null;
		try
		{
			if (!CacheManager.Get<FoSettingShareInfoViewModel>(MainCacheName, out value))
			{
				value = FoCenter.GetFoSettingShareInfo(isSetCache: true);
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
			FoSettingShareInfoViewModel foSettingShareInfo = FoCenter.GetFoSettingShareInfo(isSetCache: true);
			if (foSettingShareInfo != null)
			{
				CacheManager.Clear(MainCacheName);
				CacheManager.Add(foSettingShareInfo, MainCacheName, DefaultTimeInMinutes);
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
