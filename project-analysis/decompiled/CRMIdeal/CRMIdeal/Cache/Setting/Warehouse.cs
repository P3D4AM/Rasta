using System;
using System.Collections.Generic;
using System.Linq;
using CRM.General.Cache;
using CRM.Models;
using CRMIdeal.Classes.Common;
using Elmah;

namespace CRMIdeal.Cache.Setting;

public static class Warehouse
{
	private static readonly string MainCacheName = Configuration.CacheDefaultName + Configuration.CacheUniqueName + "-Setting-Warehouse";

	private static readonly int DefaultTimeInMinutes = Configuration.CacheDefaultTimeInMinutes;

	public static CacheViewModel Get()
	{
		CacheViewModel value = null;
		try
		{
			if (!CacheManager.Get<CacheViewModel>(MainCacheName, out value))
			{
				CRMSpEntities cRMSpEntities = new CRMSpEntities();
				WSspSelectWareHouse_Result wSspSelectWareHouse_Result = Enumerable.LastOrDefault<WSspSelectWareHouse_Result>((IEnumerable<WSspSelectWareHouse_Result>)Enumerable.ToList<WSspSelectWareHouse_Result>((IEnumerable<WSspSelectWareHouse_Result>)cRMSpEntities.WSspSelectWareHouse(1065, 1065, 0, 0)));
				cRMSpEntities.Dispose();
				if (wSspSelectWareHouse_Result != null)
				{
					value = new CacheViewModel
					{
						Name = wSspSelectWareHouse_Result.WrhsName,
						Id = wSspSelectWareHouse_Result.WareHouseID
					};
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
			CRMSpEntities cRMSpEntities = new CRMSpEntities();
			WSspSelectWareHouse_Result wSspSelectWareHouse_Result = Enumerable.LastOrDefault<WSspSelectWareHouse_Result>((IEnumerable<WSspSelectWareHouse_Result>)Enumerable.ToList<WSspSelectWareHouse_Result>((IEnumerable<WSspSelectWareHouse_Result>)cRMSpEntities.WSspSelectWareHouse(1065, 1065, 0, 0)));
			cRMSpEntities.Dispose();
			if (wSspSelectWareHouse_Result != null)
			{
				CacheViewModel o = new CacheViewModel
				{
					Name = wSspSelectWareHouse_Result.WrhsName,
					Id = wSspSelectWareHouse_Result.WareHouseID
				};
				CacheManager.Clear(MainCacheName);
				CacheManager.Add(o, MainCacheName, DefaultTimeInMinutes);
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
