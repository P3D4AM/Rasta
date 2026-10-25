using System;
using System.Collections.Generic;
using System.Linq;
using CRM.General.Cache;
using CRM.Models;
using CRMIdeal.Classes.Common;
using Elmah;

namespace CRMIdeal.Cache.Setting;

public static class CISetting
{
	private static readonly string MainCacheName = Configuration.CacheDefaultName + Configuration.CacheUniqueName + "-Setting-CISetting";

	private static readonly int DefaultTimeInMinutes = Configuration.CacheDefaultTimeInMinutes;

	public static CRMspSelectCrmsysCISetting_Result Get()
	{
		CRMspSelectCrmsysCISetting_Result value = null;
		try
		{
			if (!CacheManager.Get<CRMspSelectCrmsysCISetting_Result>(MainCacheName, out value))
			{
				CRMSpIEntities cRMSpIEntities = new CRMSpIEntities();
				value = Enumerable.FirstOrDefault<CRMspSelectCrmsysCISetting_Result>((IEnumerable<CRMspSelectCrmsysCISetting_Result>)cRMSpIEntities.CRMspSelectCrmsysCISetting());
				cRMSpIEntities.Dispose();
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
			CRMSpIEntities cRMSpIEntities = new CRMSpIEntities();
			CRMspSelectCrmsysCISetting_Result cRMspSelectCrmsysCISetting_Result = Enumerable.FirstOrDefault<CRMspSelectCrmsysCISetting_Result>((IEnumerable<CRMspSelectCrmsysCISetting_Result>)cRMSpIEntities.CRMspSelectCrmsysCISetting());
			cRMSpIEntities.Dispose();
			if (cRMspSelectCrmsysCISetting_Result != null)
			{
				CacheManager.Clear(MainCacheName);
				CacheManager.Add(cRMspSelectCrmsysCISetting_Result, MainCacheName, DefaultTimeInMinutes);
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
