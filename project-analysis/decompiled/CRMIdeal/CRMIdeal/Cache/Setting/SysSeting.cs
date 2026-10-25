using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using CRM.General.Cache;
using CRM.Models;
using CRMIdeal.Classes.Common;
using Elmah;

namespace CRMIdeal.Cache.Setting;

public static class SysSeting
{
	private static readonly string MainCacheName = Configuration.CacheDefaultName + Configuration.CacheUniqueName + "-Setting-SysSeting";

	private static readonly int DefaultTimeInMinutes = Configuration.CacheDefaultTimeInMinutes;

	public static CRMspSelectCrmsysSetting_Result Get()
	{
		CRMspSelectCrmsysSetting_Result value = null;
		try
		{
			if (!CacheManager.Get<CRMspSelectCrmsysSetting_Result>(MainCacheName, out value))
			{
				CRMSpEntities cRMSpEntities = new CRMSpEntities();
				int result = 1065;
				CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<CRMspSelectCrmsysSetting_Result>((IEnumerable<CRMspSelectCrmsysSetting_Result>)Enumerable.ToList<CRMspSelectCrmsysSetting_Result>((IEnumerable<CRMspSelectCrmsysSetting_Result>)cRMSpEntities.CRMspSelectCrmsysSetting(Thread.CurrentThread.CurrentCulture.LCID, result)));
				if (cRMspSelectCrmsysSetting_Result != null)
				{
					int.TryParse(cRMspSelectCrmsysSetting_Result.DefaultLanguageID.ToString(), out result);
				}
				value = Enumerable.FirstOrDefault<CRMspSelectCrmsysSetting_Result>((IEnumerable<CRMspSelectCrmsysSetting_Result>)Enumerable.ToList<CRMspSelectCrmsysSetting_Result>((IEnumerable<CRMspSelectCrmsysSetting_Result>)cRMSpEntities.CRMspSelectCrmsysSetting(Thread.CurrentThread.CurrentCulture.LCID, result)));
				cRMSpEntities.Dispose();
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
			CRMSpEntities cRMSpEntities = new CRMSpEntities();
			int result = 1065;
			CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<CRMspSelectCrmsysSetting_Result>((IEnumerable<CRMspSelectCrmsysSetting_Result>)Enumerable.ToList<CRMspSelectCrmsysSetting_Result>((IEnumerable<CRMspSelectCrmsysSetting_Result>)cRMSpEntities.CRMspSelectCrmsysSetting(Thread.CurrentThread.CurrentCulture.LCID, result)));
			if (cRMspSelectCrmsysSetting_Result != null)
			{
				int.TryParse(cRMspSelectCrmsysSetting_Result.DefaultLanguageID.ToString(), out result);
			}
			CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result2 = Enumerable.FirstOrDefault<CRMspSelectCrmsysSetting_Result>((IEnumerable<CRMspSelectCrmsysSetting_Result>)Enumerable.ToList<CRMspSelectCrmsysSetting_Result>((IEnumerable<CRMspSelectCrmsysSetting_Result>)cRMSpEntities.CRMspSelectCrmsysSetting(Thread.CurrentThread.CurrentCulture.LCID, result)));
			cRMSpEntities.Dispose();
			if (cRMspSelectCrmsysSetting_Result2 != null)
			{
				CacheManager.Clear(MainCacheName);
				CacheManager.Add(cRMspSelectCrmsysSetting_Result2, MainCacheName, DefaultTimeInMinutes);
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
