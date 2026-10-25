using System;
using CRM.General.Cache;
using Elmah;
using Mobile.Cache.MobUser;
using Mobile.Cache.Setting;
using Mobile.Cache.User;

namespace Mobile.Cache;

public class Manager
{
	public static bool ClearAllCach()
	{
		return CacheManager.ClearAll();
	}

	public static bool ClearAllUserCach(int? userId = null)
	{
		try
		{
			Mobile.Cache.User.Info.Clear(userId);
			Permissions.Clear(userId);
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
			WebSetting.Clear();
			Versions.Clear();
			SmsSeting.Clear();
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
			Financial.Update();
			SysSeting.Update();
			Versions.Update();
			SmsSeting.Update();
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
			Mobile.Cache.User.Info.Update(userId);
			Permissions.Update(userId);
			return true;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return false;
	}

	public static bool ClearAllMobUserCach(int? userId = null)
	{
		try
		{
			Mobile.Cache.MobUser.Info.Clear(userId);
			return true;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return false;
	}

	public static bool UpdateAllMobUserCach(int? userId = null)
	{
		try
		{
			Mobile.Cache.MobUser.Info.Update(userId);
			return true;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return false;
	}
}
