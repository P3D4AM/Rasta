using System;
using CRM.General.Cache;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Cache.User;
using Elmah;

namespace CRMIdeal.Cache;

public static class Manager
{
	public static bool ClearAllCach()
	{
		return CacheManager.ClearAll();
	}

	public static bool ClearAllUserCach(int? userId = null)
	{
		try
		{
			Alarms.Clear(userId);
			Permissions.Clear(userId);
			Info.Clear(userId);
			CRMIdeal.Cache.User.Language.Clear(userId);
			TelegramMsg.Clear(userId);
			TelegramBotMsg.Clear(userId);
			UserAIInProccess.Clear(userId);
			return true;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return false;
	}

	public static bool ClearAllSettingCach()
	{
		try
		{
			Financial.Clear();
			SysSeting.Clear();
			Warehouse.Clear();
			SmsSeting.Clear();
			WebSetting.Clear();
			Versions.Clear();
			EmailSettings.Clear();
			CIPopUpSetting.Clear();
			CRMIdeal.Cache.Setting.Language.Clear();
			TelegramSeting.Clear();
			CISetting.Clear();
			return true;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return false;
	}

	public static bool UpdateAllSettingCach()
	{
		try
		{
			WebSetting.Update();
			SmsSeting.Update();
			Financial.Update();
			SysSeting.Update();
			Warehouse.Update();
			Versions.Update();
			EmailSettings.Update();
			CIPopUpSetting.Update();
			CRMIdeal.Cache.Setting.Language.Update();
			TelegramSeting.Update();
			TelegramBotSeting.Update();
			CISetting.Update();
			return true;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return false;
	}

	public static bool UpdateAllUserCach(int? userId = null)
	{
		try
		{
			Info.Update(userId);
			Permissions.Update(userId);
			Alarms.Update(userId);
			CRMIdeal.Cache.User.Language.Update(userId);
			return true;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return false;
	}
}
