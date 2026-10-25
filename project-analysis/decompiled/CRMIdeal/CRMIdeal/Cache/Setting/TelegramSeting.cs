using System;
using System.Collections.Generic;
using System.Linq;
using CRM.General.Cache;
using CRM.Models;
using CRMIdeal.Classes.Common;
using Elmah;

namespace CRMIdeal.Cache.Setting;

public static class TelegramSeting
{
	private static readonly string MainCacheName = Configuration.CacheDefaultName + Configuration.CacheUniqueName + "-Setting-TelegramSeting";

	private static readonly int DefaultTimeInMinutes = Configuration.CacheDefaultTimeInMinutes;

	public static List<CRMspSelectTelegSetting_Result> Get()
	{
		List<CRMspSelectTelegSetting_Result> value = null;
		try
		{
			if (!CacheManager.Get<List<CRMspSelectTelegSetting_Result>>(MainCacheName, out value))
			{
				CRMSpEntities cRMSpEntities = new CRMSpEntities();
				List<CRMspSelectTelegSetting_Result> list = Enumerable.ToList<CRMspSelectTelegSetting_Result>(Enumerable.Where<CRMspSelectTelegSetting_Result>((IEnumerable<CRMspSelectTelegSetting_Result>)cRMSpEntities.CRMspSelectTelegSetting(), (Func<CRMspSelectTelegSetting_Result, bool>)((CRMspSelectTelegSetting_Result m) => m.IsActive)));
				cRMSpEntities.Dispose();
				if (list != null)
				{
					CacheManager.Add(list, MainCacheName, DefaultTimeInMinutes);
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
			CRMSpEntities cRMSpEntities = new CRMSpEntities();
			List<CRMspSelectTelegSetting_Result> list = Enumerable.ToList<CRMspSelectTelegSetting_Result>(Enumerable.Where<CRMspSelectTelegSetting_Result>((IEnumerable<CRMspSelectTelegSetting_Result>)cRMSpEntities.CRMspSelectTelegSetting(), (Func<CRMspSelectTelegSetting_Result, bool>)((CRMspSelectTelegSetting_Result m) => m.IsActive)));
			cRMSpEntities.Dispose();
			if (list != null)
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
