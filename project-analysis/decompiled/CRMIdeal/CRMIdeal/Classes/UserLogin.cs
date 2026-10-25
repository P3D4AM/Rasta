using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Threading;
using CRM.Models;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Cache.User;
using Elmah;

namespace CRMIdeal.Classes;

public static class UserLogin
{
	public const int LoginType_CRM = 1;

	public const int LoginType_ActiveDirectory = 2;

	public const int LoginType_Karamad = 3;

	public static CRMspLoadUserLoginInfoViewModel CurrentUser
	{
		get
		{
			CRMspLoadUserLoginInfoViewModel result = null;
			try
			{
				result = Info.Get();
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
			}
			return result;
		}
	}

	public static bool IsCurrentUserAllowCopyOtherLanguage => CurrentUser.AllowCopyOtherLanguage ?? false;

	public static bool IsUserAccess(string formName, string actionName, CRMspLoadUserLoginInfoViewModel user = null)
	{
		if (user == null)
		{
			user = CurrentUser;
		}
		return Enumerable.Any<CRMspSelectUserRollPermissionJustForCash_Result>((IEnumerable<CRMspSelectUserRollPermissionJustForCash_Result>)Permissions.Get(user.UserId), (Func<CRMspSelectUserRollPermissionJustForCash_Result, bool>)((CRMspSelectUserRollPermissionJustForCash_Result c) => c.ActionName == actionName && c.FormName == formName));
	}

	public static bool IsCurrentUserLogin()
	{
		return Thread.CurrentPrincipal.Identity?.IsAuthenticated ?? false;
	}

	public static CRMspLoadUserLoginInfoViewModel User(int? id = null)
	{
		CRMspLoadUserLoginInfoViewModel result = new CRMspLoadUserLoginInfoViewModel();
		if (id.HasValue)
		{
			CRMSpEntities cRMSpEntities = new CRMSpEntities();
			try
			{
				CRMspLoadUserLoginInfo_Result cRMspLoadUserLoginInfo_Result = Enumerable.FirstOrDefault<CRMspLoadUserLoginInfo_Result>((IEnumerable<CRMspLoadUserLoginInfo_Result>)cRMSpEntities.CRMspLoadUserLoginInfo(id, "", "", Thread.CurrentThread.CurrentCulture.LCID, SysSeting.Get().DefaultLanguageID, null));
				if (cRMspLoadUserLoginInfo_Result != null)
				{
					result = new CRMspLoadUserLoginInfoViewModel
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
						Password = cRMspLoadUserLoginInfo_Result.Password,
						UserName = cRMspLoadUserLoginInfo_Result.UserName,
						RollId = -1,
						DefCmpPrjTitle = cRMspLoadUserLoginInfo_Result.DefCmpPrjTitle,
						DefCmpPrjTitle_Lang = cRMspLoadUserLoginInfo_Result.DefCmpPrjTitle_Lang
					};
				}
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
			}
			finally
			{
				cRMSpEntities.Dispose();
			}
		}
		return result;
	}

	public static bool IsUserAccessByUserId(string formName, string actionName, int userId, int userLastCId = 0)
	{
		bool result = false;
		CRMSpIEntities cRMSpIEntities = null;
		try
		{
			cRMSpIEntities = new CRMSpIEntities();
			ObjectParameter objectParameter = new ObjectParameter("HasAction", false);
			cRMSpIEntities.CRMspCheckActionForUser(formName, actionName, userId, objectParameter, userLastCId);
			if (objectParameter != null && objectParameter.Value != null)
			{
				bool.TryParse(objectParameter.Value.ToString(), out result);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpIEntities?.Dispose();
		}
		return result;
	}
}
