using System;
using System.Collections.Generic;
using System.Linq;
using CRM.General.Cache;
using Elmah;
using Mobile.Classes;
using Mobile.Models;

namespace Mobile.Cache.Setting;

public static class Financial
{
	private static readonly string MainCacheName = Configuration.CacheDefaultName + Configuration.CacheUniqueName + "-Mob-Setting-Financial";

	private static readonly int DefaultTimeInMinutes = Configuration.CacheDefaultTimeInMinutes;

	public static CacheViewModel Get()
	{
		CacheViewModel value = null;
		try
		{
			if (!CacheManager.Get<CacheViewModel>(MainCacheName, out value))
			{
				CRMEntities cRMEntities = new CRMEntities();
				WSspSelectFinancialPeriod_Result wSspSelectFinancialPeriod_Result = Enumerable.LastOrDefault<WSspSelectFinancialPeriod_Result>((IEnumerable<WSspSelectFinancialPeriod_Result>)Enumerable.ToList<WSspSelectFinancialPeriod_Result>((IEnumerable<WSspSelectFinancialPeriod_Result>)cRMEntities.WSspSelectFinancialPeriod()));
				cRMEntities.Dispose();
				if (wSspSelectFinancialPeriod_Result != null)
				{
					value = new CacheViewModel
					{
						Name = wSspSelectFinancialPeriod_Result.Name,
						Id = wSspSelectFinancialPeriod_Result.ID
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
			CRMEntities cRMEntities = new CRMEntities();
			WSspSelectFinancialPeriod_Result wSspSelectFinancialPeriod_Result = Enumerable.LastOrDefault<WSspSelectFinancialPeriod_Result>((IEnumerable<WSspSelectFinancialPeriod_Result>)Enumerable.ToList<WSspSelectFinancialPeriod_Result>((IEnumerable<WSspSelectFinancialPeriod_Result>)cRMEntities.WSspSelectFinancialPeriod()));
			cRMEntities.Dispose();
			if (wSspSelectFinancialPeriod_Result != null)
			{
				CacheViewModel o = new CacheViewModel
				{
					Name = wSspSelectFinancialPeriod_Result.Name,
					Id = wSspSelectFinancialPeriod_Result.ID
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
