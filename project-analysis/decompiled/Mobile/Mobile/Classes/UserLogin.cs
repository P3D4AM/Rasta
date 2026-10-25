using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Threading;
using Elmah;
using Mobile.Cache.Setting;
using Mobile.Cache.User;
using Mobile.Models;

namespace Mobile.Classes;

public static class UserLogin
{
	public static UserLoginInfo CurrentUser
	{
		get
		{
			UserLoginInfo result = null;
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

	public static bool IsUserAccess(string formName, string actionName, UserLoginInfo user = null, int? cId = null)
	{
		if (user == null)
		{
			user = CurrentUser;
		}
		return Enumerable.Any<MobspSelectUserRollPermission_Result>((IEnumerable<MobspSelectUserRollPermission_Result>)Permissions.Get(user.UserId, cId), (Func<MobspSelectUserRollPermission_Result, bool>)((MobspSelectUserRollPermission_Result c) => c.ActionName == actionName && c.FormName == formName));
	}

	public static bool IsUserAccessByUserId(string formName, string actionName, int userId, int userLastCId = 0)
	{
		bool result = false;
		CRMSpEntities cRMSpEntities = null;
		try
		{
			cRMSpEntities = new CRMSpEntities();
			ObjectParameter objectParameter = new ObjectParameter("HasAction", false);
			cRMSpEntities.MobspCheckActionForUser(formName, actionName, userId, objectParameter, userLastCId);
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
			cRMSpEntities?.Dispose();
		}
		return result;
	}

	public static UserLoginInfo User(int? id = null)
	{
		UserLoginInfo result = null;
		CRMEntities cRMEntities = null;
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			cRMEntities = new CRMEntities();
			MobspLoadUserLoginInfo_Result mobspLoadUserLoginInfo_Result = Enumerable.FirstOrDefault<MobspLoadUserLoginInfo_Result>((IEnumerable<MobspLoadUserLoginInfo_Result>)cRMEntities.MobspLoadUserLoginInfo(id, "", "", Thread.CurrentThread.CurrentCulture.LCID, result2));
			result = new UserLoginInfo
			{
				FullName = mobspLoadUserLoginInfo_Result.FullName,
				IsActive = mobspLoadUserLoginInfo_Result.IsActive,
				RollName = mobspLoadUserLoginInfo_Result.RollName,
				UserId = mobspLoadUserLoginInfo_Result.UserId,
				RollId = mobspLoadUserLoginInfo_Result.UserRollId
			};
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return result;
	}
}
