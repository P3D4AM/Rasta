using System;
using System.Collections.Generic;
using System.Linq;
using CRM.General.Cache;
using CRM.Models;
using CRMIdeal.Classes.Common;
using Elmah;

namespace CRMIdeal.Cache.Setting;

public static class WebSetting
{
	private static readonly string MainCacheName = Configuration.CacheDefaultName + Configuration.CacheUniqueName + "-Setting-WebSetting";

	private static readonly int DefaultTimeInMinutes = Configuration.CacheDefaultTimeInMinutes;

	public static List<CrmWebSetting> Get()
	{
		List<CrmWebSetting> value = null;
		try
		{
			if (!CacheManager.Get<List<CrmWebSetting>>(MainCacheName, out value))
			{
				CRMTabelEntities cRMTabelEntities = new CRMTabelEntities();
				value = Enumerable.ToList<CrmWebSetting>((IEnumerable<CrmWebSetting>)cRMTabelEntities.CrmWebSetting);
				cRMTabelEntities.Dispose();
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
			CRMTabelEntities cRMTabelEntities = new CRMTabelEntities();
			List<CrmWebSetting> list = Enumerable.ToList<CrmWebSetting>((IEnumerable<CrmWebSetting>)cRMTabelEntities.CrmWebSetting);
			cRMTabelEntities.Dispose();
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
