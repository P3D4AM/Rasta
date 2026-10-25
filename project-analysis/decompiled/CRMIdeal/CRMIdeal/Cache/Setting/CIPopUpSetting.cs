using System;
using System.Collections.Generic;
using System.Linq;
using CRM.General.Cache;
using CRM.Models;
using CRMIdeal.Classes.Common;
using Elmah;

namespace CRMIdeal.Cache.Setting;

public static class CIPopUpSetting
{
	private static readonly string MainCacheName = Configuration.CacheDefaultName + Configuration.CacheUniqueName + "-Setting-CIPopUpSetting";

	private static readonly int DefaultTimeInMinutes = Configuration.CacheDefaultTimeInMinutes;

	public static CRMspCallerIDSelectPopUpSetting_Result Get()
	{
		CRMspCallerIDSelectPopUpSetting_Result value = null;
		try
		{
			if (!CacheManager.Get<CRMspCallerIDSelectPopUpSetting_Result>(MainCacheName, out value))
			{
				CRMSpEntities cRMSpEntities = new CRMSpEntities();
				value = Enumerable.FirstOrDefault<CRMspCallerIDSelectPopUpSetting_Result>((IEnumerable<CRMspCallerIDSelectPopUpSetting_Result>)Enumerable.ToList<CRMspCallerIDSelectPopUpSetting_Result>((IEnumerable<CRMspCallerIDSelectPopUpSetting_Result>)cRMSpEntities.CRMspCallerIDSelectPopUpSetting()));
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
			CRMspCallerIDSelectPopUpSetting_Result cRMspCallerIDSelectPopUpSetting_Result = Enumerable.FirstOrDefault<CRMspCallerIDSelectPopUpSetting_Result>((IEnumerable<CRMspCallerIDSelectPopUpSetting_Result>)Enumerable.ToList<CRMspCallerIDSelectPopUpSetting_Result>((IEnumerable<CRMspCallerIDSelectPopUpSetting_Result>)cRMSpEntities.CRMspCallerIDSelectPopUpSetting()));
			cRMSpEntities.Dispose();
			if (cRMspCallerIDSelectPopUpSetting_Result != null)
			{
				CacheManager.Clear(MainCacheName);
				CacheManager.Add(cRMspCallerIDSelectPopUpSetting_Result, MainCacheName, DefaultTimeInMinutes);
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
