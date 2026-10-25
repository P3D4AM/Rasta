using System;
using System.Collections.Generic;
using System.Linq;
using CRM.General.Cache;
using CRM.Models;
using CRMIdeal.Classes.Common;
using Elmah;

namespace CRMIdeal.Cache.Setting;

public static class Financial
{
	private static readonly string MainCacheName = Configuration.CacheDefaultName + Configuration.CacheUniqueName + "-Setting-Financial";

	private static readonly int DefaultTimeInMinutes = Configuration.CacheDefaultTimeInMinutes;

	public static CacheViewModel Get()
	{
		CacheViewModel value = null;
		try
		{
			if (!CacheManager.Get<CacheViewModel>(MainCacheName, out value))
			{
				CRMSpEntities cRMSpEntities = new CRMSpEntities();
				WSspSelectFinancialPeriod_Result wSspSelectFinancialPeriod_Result = Enumerable.LastOrDefault<WSspSelectFinancialPeriod_Result>((IEnumerable<WSspSelectFinancialPeriod_Result>)Enumerable.ToList<WSspSelectFinancialPeriod_Result>((IEnumerable<WSspSelectFinancialPeriod_Result>)cRMSpEntities.WSspSelectFinancialPeriod()));
				cRMSpEntities.Dispose();
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
			CRMTabelEntities cRMTabelEntities = new CRMTabelEntities();
			WSFinancialPeriod wSFinancialPeriod = Enumerable.LastOrDefault<WSFinancialPeriod>((IEnumerable<WSFinancialPeriod>)Enumerable.ToList<WSFinancialPeriod>((IEnumerable<WSFinancialPeriod>)cRMTabelEntities.WSFinancialPeriod));
			cRMTabelEntities.Dispose();
			if (wSFinancialPeriod != null)
			{
				CacheViewModel o = new CacheViewModel
				{
					Name = wSFinancialPeriod.Name,
					Id = wSFinancialPeriod.ID
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
