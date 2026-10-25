using System;
using System.Linq;
using CRM.General.Cache;
using CRM.Models;
using CRMIdeal.Classes.Common;
using Elmah;

namespace CRMIdeal.Cache.Setting;

public static class EmailSettings
{
	private static readonly string MainCacheName = Configuration.CacheDefaultName + Configuration.CacheUniqueName + "-Setting-EmailSetting";

	private static readonly int DefaultTimeInMinutes = Configuration.CacheDefaultTimeInMinutes;

	public static EmailSetting Get()
	{
		EmailSetting value = null;
		try
		{
			if (!CacheManager.Get<EmailSetting>(MainCacheName, out value))
			{
				CRMTabelEntities cRMTabelEntities = new CRMTabelEntities();
				value = Queryable.FirstOrDefault<EmailSetting>((IQueryable<EmailSetting>)cRMTabelEntities.EmailSetting);
				cRMTabelEntities.Dispose();
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
			CRMTabelEntities cRMTabelEntities = new CRMTabelEntities();
			EmailSetting emailSetting = Queryable.FirstOrDefault<EmailSetting>((IQueryable<EmailSetting>)cRMTabelEntities.EmailSetting);
			cRMTabelEntities.Dispose();
			if (emailSetting != null)
			{
				CacheManager.Clear(MainCacheName);
				CacheManager.Add(emailSetting, MainCacheName, DefaultTimeInMinutes);
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
