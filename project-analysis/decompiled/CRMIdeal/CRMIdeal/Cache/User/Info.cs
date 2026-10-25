using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using CRM.General.Cache;
using CRM.Models;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes.Common;
using Elmah;

namespace CRMIdeal.Cache.User;

public static class Info
{
	private static readonly object obj = new object();

	private static readonly string MainCacheName = Configuration.CacheDefaultName + Configuration.CacheUniqueName + "-User-Info-";

	private static readonly int DefaultTimeInMinutes = Configuration.CacheDefaultTimeInMinutes;

	public static CRMspLoadUserLoginInfoViewModel Get(int? userId = null)
	{
		IIdentity identity = Thread.CurrentPrincipal.Identity;
		CRMspLoadUserLoginInfoViewModel value = null;
		lock (obj)
		{
			try
			{
				int result = 0;
				if (!userId.HasValue)
				{
					if (identity.Name != null)
					{
						int.TryParse(identity.Name, out result);
					}
				}
				else
				{
					int.TryParse(userId.ToString(), out result);
				}
				if (result != 0)
				{
					string key = MainCacheName + result;
					if (!CacheManager.Get<CRMspLoadUserLoginInfoViewModel>(key, out value))
					{
						CRMSpEntities cRMSpEntities = new CRMSpEntities();
						CRMspLoadUserLoginInfo_Result cRMspLoadUserLoginInfo_Result = Enumerable.FirstOrDefault<CRMspLoadUserLoginInfo_Result>((IEnumerable<CRMspLoadUserLoginInfo_Result>)cRMSpEntities.CRMspLoadUserLoginInfo(result, "", "", Thread.CurrentThread.CurrentCulture.LCID, SysSeting.Get().DefaultLanguageID, null));
						cRMSpEntities.Dispose();
						if (cRMspLoadUserLoginInfo_Result != null)
						{
							value = new CRMspLoadUserLoginInfoViewModel
							{
								UserId = cRMspLoadUserLoginInfo_Result.UserId,
								IsActive = cRMspLoadUserLoginInfo_Result.IsActive,
								CallreIdDeActive = cRMspLoadUserLoginInfo_Result.CallreIdDeActive,
								CallreIdDeActiveLines = cRMspLoadUserLoginInfo_Result.CallreIdDeActiveLines,
								ComputerName = cRMspLoadUserLoginInfo_Result.ComputerName,
								DisableInternalMessageAllarmVoice = cRMspLoadUserLoginInfo_Result.DisableInternalMessageAllarmVoice,
								DisableReceiveCNVSInfoAllarm = cRMspLoadUserLoginInfo_Result.DisableReceiveCNVSInfoAllarm,
								EmailAttachFileLocation = cRMspLoadUserLoginInfo_Result.EmailAttachFileLocation,
								FName = cRMspLoadUserLoginInfo_Result.FName,
								FullName = cRMspLoadUserLoginInfo_Result.FullName,
								IPAddress = cRMspLoadUserLoginInfo_Result.IPAddress,
								IsAdmin = cRMspLoadUserLoginInfo_Result.IsAdmin,
								LName = cRMspLoadUserLoginInfo_Result.LName,
								UserName = cRMspLoadUserLoginInfo_Result.UserName,
								RollId = cRMspLoadUserLoginInfo_Result.UserRollId,
								FromLoginPage = false,
								AllowCopyOtherLanguage = cRMspLoadUserLoginInfo_Result.AllowCopyOtherLanguage,
								CanSetFree = cRMspLoadUserLoginInfo_Result.CanSetFree,
								UserIsActiveInWinApp = cRMspLoadUserLoginInfo_Result.UserIsActiveInWinApp,
								UserIsActiveInWebApp = cRMspLoadUserLoginInfo_Result.UserIsActiveInWebApp,
								UserIsActiveInMobApp = cRMspLoadUserLoginInfo_Result.UserIsActiveInMobApp,
								UserExtensions = cRMspLoadUserLoginInfo_Result.UserExtensions,
								DeActiveSmartTimeAttendance = cRMspLoadUserLoginInfo_Result.DeActiveSmartTimeAttendance,
								DefCmpPrjTitle = cRMspLoadUserLoginInfo_Result.DefCmpPrjTitle,
								DefCmpPrjTitle_Lang = cRMspLoadUserLoginInfo_Result.DefCmpPrjTitle_Lang,
								SumUserMoneyBagAmount = cRMspLoadUserLoginInfo_Result.SumUserMoneyBagAmount.GetValueOrDefault(),
								UserCIds = cRMspLoadUserLoginInfo_Result.UserCIds,
								UserLastCId = cRMspLoadUserLoginInfo_Result.UserLastCId,
								MobHRMLoginMode = cRMspLoadUserLoginInfo_Result.MobHRMLoginMode,
								UserLoginCheckLocationType = cRMspLoadUserLoginInfo_Result.UserLoginCheckLocationType,
								UserLoginCheckLocations = cRMspLoadUserLoginInfo_Result.UserLoginCheckLocations,
								ShiftWorkingId = cRMspLoadUserLoginInfo_Result.ShiftWorkingId,
								DeActiveLoginWithoutShift = cRMspLoadUserLoginInfo_Result.DeActiveLoginWithoutShift,
								CallPreNumber = cRMspLoadUserLoginInfo_Result.CallPreNumber,
								UserRollName = cRMspLoadUserLoginInfo_Result.UserRollName
							};
						}
						CacheManager.Add(value, key, DefaultTimeInMinutes);
					}
				}
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
			}
		}
		return value;
	}

	public static bool Clear(int? userId = null)
	{
		try
		{
			IIdentity identity = Thread.CurrentPrincipal.Identity;
			int result = 0;
			if (!userId.HasValue)
			{
				if (identity.Name != null)
				{
					int.TryParse(identity.Name, out result);
				}
			}
			else
			{
				int.TryParse(userId.ToString(), out result);
			}
			if (result != 0)
			{
				CacheManager.Clear(MainCacheName + result);
				return true;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return false;
	}

	public static bool Update(int? userId = null, bool? fromLoginPage = null)
	{
		lock (obj)
		{
			try
			{
				IIdentity identity = Thread.CurrentPrincipal.Identity;
				int result = 0;
				if (!userId.HasValue)
				{
					if (identity.Name != null)
					{
						int.TryParse(identity.Name, out result);
					}
				}
				else
				{
					int.TryParse(userId.ToString(), out result);
				}
				if (result != 0)
				{
					string key = MainCacheName + result;
					CRMSpEntities cRMSpEntities = new CRMSpEntities();
					CRMspLoadUserLoginInfo_Result cRMspLoadUserLoginInfo_Result = Enumerable.FirstOrDefault<CRMspLoadUserLoginInfo_Result>((IEnumerable<CRMspLoadUserLoginInfo_Result>)cRMSpEntities.CRMspLoadUserLoginInfo(result, "", "", Thread.CurrentThread.CurrentCulture.LCID, SysSeting.Get().DefaultLanguageID, null));
					cRMSpEntities.Dispose();
					if (cRMspLoadUserLoginInfo_Result != null)
					{
						CacheManager.Clear(key);
						CacheManager.Add(new CRMspLoadUserLoginInfoViewModel
						{
							UserId = cRMspLoadUserLoginInfo_Result.UserId,
							IsActive = cRMspLoadUserLoginInfo_Result.IsActive,
							CallreIdDeActive = cRMspLoadUserLoginInfo_Result.CallreIdDeActive,
							CallreIdDeActiveLines = cRMspLoadUserLoginInfo_Result.CallreIdDeActiveLines,
							ComputerName = cRMspLoadUserLoginInfo_Result.ComputerName,
							DisableInternalMessageAllarmVoice = cRMspLoadUserLoginInfo_Result.DisableInternalMessageAllarmVoice,
							DisableReceiveCNVSInfoAllarm = cRMspLoadUserLoginInfo_Result.DisableReceiveCNVSInfoAllarm,
							EmailAttachFileLocation = cRMspLoadUserLoginInfo_Result.EmailAttachFileLocation,
							FName = cRMspLoadUserLoginInfo_Result.FName,
							FullName = cRMspLoadUserLoginInfo_Result.FullName,
							IPAddress = cRMspLoadUserLoginInfo_Result.IPAddress,
							IsAdmin = cRMspLoadUserLoginInfo_Result.IsAdmin,
							LName = cRMspLoadUserLoginInfo_Result.LName,
							UserName = cRMspLoadUserLoginInfo_Result.UserName,
							RollId = cRMspLoadUserLoginInfo_Result.UserRollId,
							FromLoginPage = (fromLoginPage ?? false),
							AllowCopyOtherLanguage = cRMspLoadUserLoginInfo_Result.AllowCopyOtherLanguage,
							CanSetFree = cRMspLoadUserLoginInfo_Result.CanSetFree,
							UserIsActiveInWinApp = cRMspLoadUserLoginInfo_Result.UserIsActiveInWinApp,
							UserIsActiveInWebApp = cRMspLoadUserLoginInfo_Result.UserIsActiveInWebApp,
							UserIsActiveInMobApp = cRMspLoadUserLoginInfo_Result.UserIsActiveInMobApp,
							UserExtensions = cRMspLoadUserLoginInfo_Result.UserExtensions,
							DeActiveSmartTimeAttendance = cRMspLoadUserLoginInfo_Result.DeActiveSmartTimeAttendance,
							DefCmpPrjTitle = cRMspLoadUserLoginInfo_Result.DefCmpPrjTitle,
							DefCmpPrjTitle_Lang = cRMspLoadUserLoginInfo_Result.DefCmpPrjTitle_Lang,
							SumUserMoneyBagAmount = cRMspLoadUserLoginInfo_Result.SumUserMoneyBagAmount.GetValueOrDefault(),
							UserCIds = cRMspLoadUserLoginInfo_Result.UserCIds,
							UserLastCId = cRMspLoadUserLoginInfo_Result.UserLastCId,
							MobHRMLoginMode = cRMspLoadUserLoginInfo_Result.MobHRMLoginMode,
							UserLoginCheckLocationType = cRMspLoadUserLoginInfo_Result.UserLoginCheckLocationType,
							UserLoginCheckLocations = cRMspLoadUserLoginInfo_Result.UserLoginCheckLocations,
							ShiftWorkingId = cRMspLoadUserLoginInfo_Result.ShiftWorkingId,
							DeActiveLoginWithoutShift = cRMspLoadUserLoginInfo_Result.DeActiveLoginWithoutShift,
							CallPreNumber = cRMspLoadUserLoginInfo_Result.CallPreNumber,
							UserRollName = cRMspLoadUserLoginInfo_Result.UserRollName
						}, key, DefaultTimeInMinutes);
						return true;
					}
				}
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
			}
		}
		return false;
	}
}
