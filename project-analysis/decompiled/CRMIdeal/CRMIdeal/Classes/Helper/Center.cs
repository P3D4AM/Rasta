using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using CRM.Models;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes.Common;
using Newtonsoft.Json;

namespace CRMIdeal.Classes.Helper;

public class Center
{
	private static List<CRMspSelectCenters_Result> _Get { get; set; }

	public static int TotalCnt => Get().Count;

	public static int MaxAllowedCnt => Configuration.MaxCenterCount;

	public static int RemainsCnt
	{
		get
		{
			if (!VersionBuyer.Center)
			{
				return 0;
			}
			int num = Configuration.MaxCenterCount - ActiveCnt();
			if (num <= 0)
			{
				num = 0;
			}
			return num;
		}
	}

	public static bool HaveModule => VersionBuyer.Center;

	[LoginAuthorize]
	public static List<CRMspSelectCenters_Result> Get()
	{
		if (_Get != null && _Get.Count > 0)
		{
			return _Get;
		}
		List<CRMspSelectCenters_Result> result = new List<CRMspSelectCenters_Result>();
		CRMSpIIEntities cRMSpIIEntities = null;
		try
		{
			cRMSpIIEntities = new CRMSpIIEntities();
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspSelectCenters_Result> list = Enumerable.ToList<CRMspSelectCenters_Result>((IEnumerable<CRMspSelectCenters_Result>)cRMSpIIEntities.CRMspSelectCenters(lCID, result2));
			if (list != null)
			{
				result = list;
				_Get = list;
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		finally
		{
			cRMSpIIEntities?.Dispose();
		}
		return result;
	}

	[LoginAuthorize]
	public static List<SelectListItem> Get_SelectListItem(int? selectedId = null, bool? selectUserLastCId = false)
	{
		if (selectUserLastCId.GetValueOrDefault() && selectedId.GetValueOrDefault() == 0)
		{
			selectedId = ((UserLogin.CurrentUser != null) ? UserLogin.CurrentUser.UserLastCId.GetValueOrDefault() : 0);
		}
		return Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectCenters_Result, SelectListItem>((IEnumerable<CRMspSelectCenters_Result>)Get(), (Func<CRMspSelectCenters_Result, SelectListItem>)((CRMspSelectCenters_Result x) => new SelectListItem
		{
			Text = x.CenterName,
			Value = x.CenterID.ToString(),
			Selected = (x.CenterID == selectedId)
		})));
	}

	[LoginAuthorize]
	public static string Get_SelectListItem_Json(int? selectedId = null)
	{
		return JsonConvert.SerializeObject(Get_SelectListItem(selectedId, false));
	}

	[LoginAuthorize]
	public static string Get_Json()
	{
		return JsonConvert.SerializeObject(Get());
	}

	[LoginAuthorize]
	public static List<CRMspSelectActiveCenters_Result> GetActives(int? selectedId = null)
	{
		List<CRMspSelectActiveCenters_Result> result = new List<CRMspSelectActiveCenters_Result>();
		CRMSpIIEntities cRMSpIIEntities = null;
		try
		{
			cRMSpIIEntities = new CRMSpIIEntities();
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspSelectActiveCenters_Result> list = Enumerable.ToList<CRMspSelectActiveCenters_Result>((IEnumerable<CRMspSelectActiveCenters_Result>)cRMSpIIEntities.CRMspSelectActiveCenters(lCID, result2));
			if (list != null)
			{
				result = list;
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		finally
		{
			cRMSpIIEntities?.Dispose();
		}
		return result;
	}

	[LoginAuthorize]
	public static string GetActives_Json(int? selectedId = null)
	{
		return JsonConvert.SerializeObject(GetActives(selectedId));
	}

	[LoginAuthorize]
	public static List<SelectListItem> GetActives_SelectListItem(int? selectedId = null)
	{
		return Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectActiveCenters_Result, SelectListItem>((IEnumerable<CRMspSelectActiveCenters_Result>)GetActives(), (Func<CRMspSelectActiveCenters_Result, SelectListItem>)((CRMspSelectActiveCenters_Result x) => new SelectListItem
		{
			Text = x.CenterName,
			Value = x.CenterID.ToString(),
			Selected = (x.CenterID == selectedId)
		})));
	}

	[LoginAuthorize]
	public static string GetActives_SelectListItem_Json(int? selectedId = null)
	{
		return JsonConvert.SerializeObject(GetActives_SelectListItem(selectedId));
	}

	[LoginAuthorize]
	public static int ActiveCnt(int excptId = 0)
	{
		return Enumerable.ToList<CRMspSelectActiveCenters_Result>(Enumerable.Where<CRMspSelectActiveCenters_Result>((IEnumerable<CRMspSelectActiveCenters_Result>)GetActives(), (Func<CRMspSelectActiveCenters_Result, bool>)((CRMspSelectActiveCenters_Result x) => x.CenterID != excptId))).Count;
	}

	[LoginAuthorize]
	public static List<CRMspSelectCentersWithIds_Result> GetWithIds(string userCIds)
	{
		CRMSpIIEntities cRMSpIIEntities = null;
		List<CRMspSelectCentersWithIds_Result> result = new List<CRMspSelectCentersWithIds_Result>();
		try
		{
			cRMSpIIEntities = new CRMSpIIEntities();
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspSelectCentersWithIds_Result> list = Enumerable.ToList<CRMspSelectCentersWithIds_Result>((IEnumerable<CRMspSelectCentersWithIds_Result>)cRMSpIIEntities.CRMspSelectCentersWithIds(userCIds, ",", lCID, result2));
			if (list != null)
			{
				result = list;
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		finally
		{
			cRMSpIIEntities?.Dispose();
		}
		return result;
	}

	[LoginAuthorize]
	public static List<SelectListItem> GetWithIds_SelectListItem(string selectedIds = "", string userCIds = "")
	{
		List<string> sellst = Enumerable.ToList<string>((IEnumerable<string>)selectedIds.Split(new char[1] { ',' }));
		return Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectCentersWithIds_Result, SelectListItem>((IEnumerable<CRMspSelectCentersWithIds_Result>)GetWithIds(userCIds), (Func<CRMspSelectCentersWithIds_Result, SelectListItem>)((CRMspSelectCentersWithIds_Result x) => new SelectListItem
		{
			Text = x.CenterName,
			Value = x.CenterID.ToString(),
			Selected = (Enumerable.FirstOrDefault<string>((IEnumerable<string>)sellst, (Func<string, bool>)((string s) => s == x.CenterID.ToString())) != null)
		})));
	}

	[LoginAuthorize]
	public static string GetWithIds_SelectListItem_Json(string selectedIds = "", string userCIds = "")
	{
		return JsonConvert.SerializeObject(GetWithIds_SelectListItem(selectedIds, userCIds));
	}

	[LoginAuthorize]
	public static List<CRMspSelectCentersWithIds_Result> GetWithIds_Actives(string userCIds = "")
	{
		return Enumerable.ToList<CRMspSelectCentersWithIds_Result>(Enumerable.Where<CRMspSelectCentersWithIds_Result>((IEnumerable<CRMspSelectCentersWithIds_Result>)GetWithIds(userCIds), (Func<CRMspSelectCentersWithIds_Result, bool>)((CRMspSelectCentersWithIds_Result x) => !x.CenterInActive.GetValueOrDefault())));
	}

	[LoginAuthorize]
	public static List<SelectListItem> GetWithIds_Actives_SelectListItem(string userCIds = "", string selectedIds = "")
	{
		string[] selList = selectedIds.Split(new char[1] { ',' });
		return Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectCentersWithIds_Result, SelectListItem>(Enumerable.Where<CRMspSelectCentersWithIds_Result>((IEnumerable<CRMspSelectCentersWithIds_Result>)GetWithIds(userCIds), (Func<CRMspSelectCentersWithIds_Result, bool>)((CRMspSelectCentersWithIds_Result x) => !x.CenterInActive.GetValueOrDefault())), (Func<CRMspSelectCentersWithIds_Result, SelectListItem>)((CRMspSelectCentersWithIds_Result x) => new SelectListItem
		{
			Text = x.CenterName,
			Value = x.CenterID.ToString(),
			Selected = (Enumerable.FirstOrDefault<string>((IEnumerable<string>)selList, (Func<string, bool>)((string s) => s == x.CenterID.ToString())) != null)
		})));
	}

	[LoginAuthorize]
	public static string GetWithIds_Actives_Json(string userCIds = "")
	{
		return JsonConvert.SerializeObject(GetWithIds_Actives(userCIds));
	}

	[LoginAuthorize]
	public static List<CRMspSelectActiveCenters_Result> GetCurrUserActives(string userCIds)
	{
		List<CRMspSelectActiveCenters_Result> actives = GetActives();
		List<CRMspSelectCentersWithIds_Result> userCenters = GetWithIds(userCIds);
		return Enumerable.ToList<CRMspSelectActiveCenters_Result>(Enumerable.Where<CRMspSelectActiveCenters_Result>((IEnumerable<CRMspSelectActiveCenters_Result>)actives, (Func<CRMspSelectActiveCenters_Result, bool>)((CRMspSelectActiveCenters_Result x) => Enumerable.FirstOrDefault<CRMspSelectCentersWithIds_Result>((IEnumerable<CRMspSelectCentersWithIds_Result>)userCenters, (Func<CRMspSelectCentersWithIds_Result, bool>)((CRMspSelectCentersWithIds_Result u) => u.CenterID == x.CenterID)) != null)));
	}

	[LoginAuthorize]
	public static string GetCurrUserActives_Json(string userCIds)
	{
		return JsonConvert.SerializeObject(GetCurrUserActives(userCIds));
	}

	[LoginAuthorize]
	public static List<SelectListItem> GetCurrUserActives_SelectListItem(string userCIds)
	{
		return Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectActiveCenters_Result, SelectListItem>((IEnumerable<CRMspSelectActiveCenters_Result>)GetCurrUserActives(userCIds), (Func<CRMspSelectActiveCenters_Result, SelectListItem>)((CRMspSelectActiveCenters_Result x) => new SelectListItem
		{
			Text = x.CenterName,
			Value = x.CenterID.ToString()
		})));
	}

	[LoginAuthorize]
	public static string GetCurrUserActivesSelectListItem_Json(string userCIds = "")
	{
		return JsonConvert.SerializeObject(GetCurrUserActives_SelectListItem(userCIds));
	}

	[LoginAuthorize]
	public static List<SelectListItem> GetCurrUserActives_SelectListItemById(string userCIds, int? selectedId = null, bool? selectUserLastCId = false)
	{
		if (string.IsNullOrWhiteSpace(userCIds) && UserLogin.CurrentUser != null)
		{
			userCIds = UserLogin.CurrentUser.UserCIds ?? "";
		}
		if (selectUserLastCId.GetValueOrDefault() && selectedId.GetValueOrDefault() == 0)
		{
			selectedId = ((UserLogin.CurrentUser != null) ? UserLogin.CurrentUser.UserLastCId.GetValueOrDefault() : 0);
		}
		return Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectActiveCenters_Result, SelectListItem>((IEnumerable<CRMspSelectActiveCenters_Result>)GetCurrUserActives(userCIds), (Func<CRMspSelectActiveCenters_Result, SelectListItem>)((CRMspSelectActiveCenters_Result x) => new SelectListItem
		{
			Text = x.CenterName,
			Value = x.CenterID.ToString(),
			Selected = (x.CenterID == selectedId)
		})));
	}

	public static string GetNames(string cIds = "")
	{
		return string.Join(", ", Enumerable.Select<CRMspSelectCentersWithIds_Result, string>((IEnumerable<CRMspSelectCentersWithIds_Result>)GetWithIds(cIds), (Func<CRMspSelectCentersWithIds_Result, string>)((CRMspSelectCentersWithIds_Result x) => x.CenterName)));
	}

	public static List<CRMspSelectFoSettingRegister_Result> SelectFoSettingRegister(int centerId = 0)
	{
		List<CRMspSelectFoSettingRegister_Result> result = new List<CRMspSelectFoSettingRegister_Result>();
		CRMSpIIEntities cRMSpIIEntities = new CRMSpIIEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (centerId != 0)
			{
				List<CRMspSelectFoSettingRegister_Result> list = Enumerable.ToList<CRMspSelectFoSettingRegister_Result>((IEnumerable<CRMspSelectFoSettingRegister_Result>)cRMSpIIEntities.CRMspSelectFoSettingRegister(centerId, lCID, result2));
				if (list != null)
				{
					result = list;
				}
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		finally
		{
			cRMSpIIEntities?.Dispose();
		}
		return result;
	}
}
