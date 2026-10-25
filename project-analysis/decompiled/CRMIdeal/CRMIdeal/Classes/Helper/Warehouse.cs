using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes.Common;
using Elmah;

namespace CRMIdeal.Classes.Helper;

public class Warehouse
{
	public static List<CRMspSelectWareHouseForRepParam_Result> SelectWareHouseForRepParam(int userLastCId = 0, int userId = 0)
	{
		List<CRMspSelectWareHouseForRepParam_Result> list = new List<CRMspSelectWareHouseForRepParam_Result>();
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
			if (currentUser != null)
			{
				if (userId == 0)
				{
					userId = currentUser.UserId;
				}
				if (userLastCId == 0)
				{
					int.TryParse(currentUser.UserLastCId.ToString(), out userLastCId);
				}
			}
			string all = Labels.All;
			list = Enumerable.ToList<CRMspSelectWareHouseForRepParam_Result>((IEnumerable<CRMspSelectWareHouseForRepParam_Result>)cRMSpEntities.CRMspSelectWareHouseForRepParam(lCID, result, all, userId, userLastCId));
			if (list == null)
			{
				list = new List<CRMspSelectWareHouseForRepParam_Result>();
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
		return list;
	}

	public static List<WSspSelectActiveWareHouse_Result> SelectActiveWareHouse(int userLastCId = 0, int userId = 0)
	{
		List<WSspSelectActiveWareHouse_Result> list = new List<WSspSelectActiveWareHouse_Result>();
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
			if (currentUser != null)
			{
				if (userId == 0)
				{
					userId = currentUser.UserId;
				}
				if (userLastCId == 0)
				{
					int.TryParse(currentUser.UserLastCId.ToString(), out userLastCId);
				}
			}
			list = Enumerable.ToList<WSspSelectActiveWareHouse_Result>((IEnumerable<WSspSelectActiveWareHouse_Result>)cRMSpEntities.WSspSelectActiveWareHouse(lCID, result, userId, userLastCId));
			if (list == null)
			{
				list = new List<WSspSelectActiveWareHouse_Result>();
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
		return list;
	}

	public static List<WSspSelectWareHouse_Result> SelectWareHouse(int userLastCId = 0, int userId = 0)
	{
		List<WSspSelectWareHouse_Result> list = new List<WSspSelectWareHouse_Result>();
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
			if (currentUser != null)
			{
				if (userId == 0 && userId != -1)
				{
					userId = currentUser.UserId;
				}
				if (userLastCId == 0 && userLastCId != -1)
				{
					int.TryParse(currentUser.UserLastCId.ToString(), out userLastCId);
				}
			}
			if (userId == -1)
			{
				userId = 0;
			}
			if (userLastCId == -1)
			{
				userLastCId = 0;
			}
			list = Enumerable.ToList<WSspSelectWareHouse_Result>((IEnumerable<WSspSelectWareHouse_Result>)cRMSpEntities.WSspSelectWareHouse(lCID, result, userId, userLastCId));
			if (list == null)
			{
				list = new List<WSspSelectWareHouse_Result>();
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
		return list;
	}

	public static WSspSelectWareHouseWithId_Result SelectWareHouseWithId(int whId, int defLangId = 0, int currLangId = 0)
	{
		CRMSpIIIEntities cRMSpIIIEntities = new CRMSpIIIEntities();
		WSspSelectWareHouseWithId_Result wSspSelectWareHouseWithId_Result = new WSspSelectWareHouseWithId_Result();
		try
		{
			if (defLangId == 0)
			{
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out defLangId);
				if (defLangId <= 0)
				{
					defLangId = 1065;
				}
			}
			if (currLangId == 0)
			{
				currLangId = Thread.CurrentThread.CurrentCulture.LCID;
			}
			wSspSelectWareHouseWithId_Result = Enumerable.FirstOrDefault<WSspSelectWareHouseWithId_Result>((IEnumerable<WSspSelectWareHouseWithId_Result>)cRMSpIIIEntities.WSspSelectWareHouseWithId(whId, currLangId, defLangId));
			if (wSspSelectWareHouseWithId_Result == null)
			{
				wSspSelectWareHouseWithId_Result = new WSspSelectWareHouseWithId_Result();
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		finally
		{
			cRMSpIIIEntities.Dispose();
		}
		return wSspSelectWareHouseWithId_Result;
	}

	public static string GetWarehouseNameAndCode(int whId, string wrhsFormat = "", int defLangId = 0, int currLangId = 0)
	{
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		string text = "";
		try
		{
			if (defLangId == 0)
			{
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out defLangId);
				if (defLangId <= 0)
				{
					defLangId = 1065;
				}
			}
			if (currLangId == 0)
			{
				currLangId = Thread.CurrentThread.CurrentCulture.LCID;
			}
			if (string.IsNullOrWhiteSpace(wrhsFormat))
			{
				wrhsFormat = "{0} ({1})";
			}
			WSspSelectWareHouseWithId_Result wSspSelectWareHouseWithId_Result = SelectWareHouseWithId(whId, defLangId, currLangId);
			if (wSspSelectWareHouseWithId_Result != null)
			{
				string arg = wSspSelectWareHouseWithId_Result.WrhsName ?? "";
				string arg2 = wSspSelectWareHouseWithId_Result.WrhsCode ?? "";
				text = string.Format(wrhsFormat, arg, arg2);
				if (!string.IsNullOrWhiteSpace(text))
				{
					text = text.Replace("()", "").Replace("( )", "");
				}
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		finally
		{
			cRMSpEntities.Dispose();
		}
		return text;
	}
}
