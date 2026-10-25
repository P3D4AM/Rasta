using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using CRM.General.Cache;
using CRM.Models;
using CRMIdeal.Classes.Common;
using Elmah;

namespace CRMIdeal.Cache.Setting;

public static class TelegramBotSeting
{
	private static readonly string MainCacheName = Configuration.CacheDefaultName + Configuration.CacheUniqueName + "-Setting-TelegramBotSeting";

	private static readonly int DefaultTimeInMinutes = Configuration.CacheDefaultTimeInMinutes;

	public static CRMspSelectTelegBotSetting_Result Get()
	{
		CRMspSelectTelegBotSetting_Result value = null;
		try
		{
			if (!CacheManager.Get<CRMspSelectTelegBotSetting_Result>(MainCacheName, out value))
			{
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
				if (result <= 0)
				{
					result = 1065;
				}
				int lCID = Thread.CurrentThread.CurrentCulture.LCID;
				CRMSpEntities cRMSpEntities = new CRMSpEntities();
				CRMspSelectTelegBotSetting_Result cRMspSelectTelegBotSetting_Result = Enumerable.FirstOrDefault<CRMspSelectTelegBotSetting_Result>((IEnumerable<CRMspSelectTelegBotSetting_Result>)cRMSpEntities.CRMspSelectTelegBotSetting(lCID, result));
				cRMSpEntities.Dispose();
				if (cRMspSelectTelegBotSetting_Result != null)
				{
					CacheManager.Add(cRMspSelectTelegBotSetting_Result, MainCacheName, DefaultTimeInMinutes);
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
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			CRMSpEntities cRMSpEntities = new CRMSpEntities();
			CRMspSelectTelegBotSetting_Result cRMspSelectTelegBotSetting_Result = Enumerable.FirstOrDefault<CRMspSelectTelegBotSetting_Result>((IEnumerable<CRMspSelectTelegBotSetting_Result>)cRMSpEntities.CRMspSelectTelegBotSetting(lCID, result));
			cRMSpEntities.Dispose();
			if (cRMspSelectTelegBotSetting_Result != null)
			{
				CacheManager.Clear(MainCacheName);
				CacheManager.Add(cRMspSelectTelegBotSetting_Result, MainCacheName, DefaultTimeInMinutes);
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
