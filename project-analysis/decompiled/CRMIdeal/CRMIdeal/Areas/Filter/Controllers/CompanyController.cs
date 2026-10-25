using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.Classes.Helper;
using CRMIdeal.GSD.Globalization;
using Elmah;
using Newtonsoft.Json;

namespace CRMIdeal.Areas.Filter.Controllers;

public class CompanyController : Controller
{
	private CRMSpEntities db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	private CRMSpIEntities _dbI = new CRMSpIEntities();

	private CRMSpIIEntities _dbII = new CRMSpIIEntities();

	private static int textItemSeperatorId = -100;

	private static string textNone = Labels.None;

	private static string textHaveNot = Labels.HaveNot;

	private static string textItemSeperators = "-----------";

	private List<string> SysDefs = new List<string> { textNone, textHaveNot, textItemSeperators };

	[HttpPost]
	[LoginAuthorize]
	public string GetCmpTitle(int? selectedId = null)
	{
		string result = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspRpt_cmpSelCompanyTitle_Result> list = Enumerable.ToList<CRMspRpt_cmpSelCompanyTitle_Result>((IEnumerable<CRMspRpt_cmpSelCompanyTitle_Result>)db.CRMspRpt_cmpSelCompanyTitle(textNone, textHaveNot, lCID, result2));
			if (list != null)
			{
				result = JsonConvert.SerializeObject(Enumerable.ToList<nComboBoxListItem>(Enumerable.Select<CRMspRpt_cmpSelCompanyTitle_Result, nComboBoxListItem>((IEnumerable<CRMspRpt_cmpSelCompanyTitle_Result>)list, (Func<CRMspRpt_cmpSelCompanyTitle_Result, nComboBoxListItem>)((CRMspRpt_cmpSelCompanyTitle_Result item) => new nComboBoxListItem
				{
					Text = item.Val,
					Value = item.ID.ToString(),
					Selected = (item.ID == selectedId),
					IsSysDef = (Enumerable.FirstOrDefault<string>((IEnumerable<string>)SysDefs, (Func<string, bool>)((string sd) => sd == item.Val)) != null),
					IsSep = (item.ID == textItemSeperatorId)
				}))));
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return result;
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetCountry(int? selectedId = null)
	{
		string result = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspRpt_cmpSelCompanyCountry_Result> list = Enumerable.ToList<CRMspRpt_cmpSelCompanyCountry_Result>((IEnumerable<CRMspRpt_cmpSelCompanyCountry_Result>)db.CRMspRpt_cmpSelCompanyCountry(textNone, textHaveNot, lCID, result2));
			if (list != null)
			{
				result = JsonConvert.SerializeObject(Enumerable.ToList<nComboBoxListItem>(Enumerable.Select<CRMspRpt_cmpSelCompanyCountry_Result, nComboBoxListItem>((IEnumerable<CRMspRpt_cmpSelCompanyCountry_Result>)list, (Func<CRMspRpt_cmpSelCompanyCountry_Result, nComboBoxListItem>)((CRMspRpt_cmpSelCompanyCountry_Result item) => new nComboBoxListItem
				{
					Text = item.Val,
					Value = item.ID.ToString(),
					Selected = (item.ID == selectedId),
					IsSysDef = (Enumerable.FirstOrDefault<string>((IEnumerable<string>)SysDefs, (Func<string, bool>)((string sd) => sd == item.Val)) != null),
					IsSep = (item.ID == textItemSeperatorId)
				}))));
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return result;
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetProvince(int? id = null, int? selectedId = null)
	{
		string result = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int result3 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result3);
			}
			List<CRMspRpt_cmpSelCompanyProvince_Result> list = Enumerable.ToList<CRMspRpt_cmpSelCompanyProvince_Result>((IEnumerable<CRMspRpt_cmpSelCompanyProvince_Result>)db.CRMspRpt_cmpSelCompanyProvince(UserLogin.CurrentUser.UserId, id, textNone, textHaveNot, lCID, result2, result3));
			if (list != null)
			{
				result = JsonConvert.SerializeObject(Enumerable.ToList<nComboBoxListItem>(Enumerable.Select<CRMspRpt_cmpSelCompanyProvince_Result, nComboBoxListItem>((IEnumerable<CRMspRpt_cmpSelCompanyProvince_Result>)list, (Func<CRMspRpt_cmpSelCompanyProvince_Result, nComboBoxListItem>)((CRMspRpt_cmpSelCompanyProvince_Result item) => new nComboBoxListItem
				{
					Text = item.Val,
					Value = item.ID.ToString(),
					Selected = (item.ID == selectedId),
					IsSysDef = (Enumerable.FirstOrDefault<string>((IEnumerable<string>)SysDefs, (Func<string, bool>)((string sd) => sd == item.Val)) != null),
					IsSep = (item.ID == textItemSeperatorId)
				}))));
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return result;
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetCity(int? id = null, int? selectedId = null)
	{
		string result = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int result3 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result3);
			}
			List<CRMspRpt_cmpSelCompanyCity_Result> list = Enumerable.ToList<CRMspRpt_cmpSelCompanyCity_Result>((IEnumerable<CRMspRpt_cmpSelCompanyCity_Result>)db.CRMspRpt_cmpSelCompanyCity(UserLogin.CurrentUser.UserId, id, textNone, textHaveNot, lCID, result2, result3));
			if (list != null)
			{
				result = JsonConvert.SerializeObject(Enumerable.ToList<nComboBoxListItem>(Enumerable.Select<CRMspRpt_cmpSelCompanyCity_Result, nComboBoxListItem>((IEnumerable<CRMspRpt_cmpSelCompanyCity_Result>)list, (Func<CRMspRpt_cmpSelCompanyCity_Result, nComboBoxListItem>)((CRMspRpt_cmpSelCompanyCity_Result item) => new nComboBoxListItem
				{
					Text = item.Val,
					Value = item.ID.ToString(),
					Selected = (item.ID == selectedId),
					IsSysDef = (Enumerable.FirstOrDefault<string>((IEnumerable<string>)SysDefs, (Func<string, bool>)((string sd) => sd == item.Val)) != null),
					IsSep = (item.ID == textItemSeperatorId)
				}))));
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return result;
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetCmpPresentation(int? selectedId = null)
	{
		string result = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspRpt_cmpSelCompanyPresentation_Result> list = Enumerable.ToList<CRMspRpt_cmpSelCompanyPresentation_Result>((IEnumerable<CRMspRpt_cmpSelCompanyPresentation_Result>)db.CRMspRpt_cmpSelCompanyPresentation(textNone, textHaveNot, lCID, result2));
			if (list != null)
			{
				result = JsonConvert.SerializeObject(Enumerable.ToList<nComboBoxListItem>(Enumerable.Select<CRMspRpt_cmpSelCompanyPresentation_Result, nComboBoxListItem>((IEnumerable<CRMspRpt_cmpSelCompanyPresentation_Result>)list, (Func<CRMspRpt_cmpSelCompanyPresentation_Result, nComboBoxListItem>)((CRMspRpt_cmpSelCompanyPresentation_Result item) => new nComboBoxListItem
				{
					Text = item.Val,
					Value = item.ID.ToString(),
					Selected = (item.ID == selectedId),
					IsSysDef = (Enumerable.FirstOrDefault<string>((IEnumerable<string>)SysDefs, (Func<string, bool>)((string sd) => sd == item.Val)) != null),
					IsSep = (item.ID == textItemSeperatorId)
				}))));
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return result;
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetCmpType(int? selectedId = null)
	{
		string result = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspRpt_cmpSelCompanyType_Result> list = Enumerable.ToList<CRMspRpt_cmpSelCompanyType_Result>((IEnumerable<CRMspRpt_cmpSelCompanyType_Result>)db.CRMspRpt_cmpSelCompanyType(textNone, textHaveNot, lCID, result2));
			if (list != null)
			{
				result = JsonConvert.SerializeObject(Enumerable.ToList<nComboBoxListItem>(Enumerable.Select<CRMspRpt_cmpSelCompanyType_Result, nComboBoxListItem>((IEnumerable<CRMspRpt_cmpSelCompanyType_Result>)list, (Func<CRMspRpt_cmpSelCompanyType_Result, nComboBoxListItem>)((CRMspRpt_cmpSelCompanyType_Result item) => new nComboBoxListItem
				{
					Text = item.Val,
					Value = item.ID.ToString(),
					Selected = (item.ID == selectedId),
					IsSysDef = (Enumerable.FirstOrDefault<string>((IEnumerable<string>)SysDefs, (Func<string, bool>)((string sd) => sd == item.Val)) != null),
					IsSep = (item.ID == textItemSeperatorId)
				}))));
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return result;
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetCmpGroups(int? selectedId = null)
	{
		string result = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int result3 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result3);
			}
			List<CRMspRpt_cmpSelCompanyGroup_Result> list = Enumerable.ToList<CRMspRpt_cmpSelCompanyGroup_Result>((IEnumerable<CRMspRpt_cmpSelCompanyGroup_Result>)db.CRMspRpt_cmpSelCompanyGroup(UserLogin.CurrentUser.UserId, textNone, textHaveNot, lCID, result2, result3));
			if (list != null)
			{
				result = JsonConvert.SerializeObject(Enumerable.ToList<nComboBoxListItem>(Enumerable.Select<CRMspRpt_cmpSelCompanyGroup_Result, nComboBoxListItem>((IEnumerable<CRMspRpt_cmpSelCompanyGroup_Result>)list, (Func<CRMspRpt_cmpSelCompanyGroup_Result, nComboBoxListItem>)((CRMspRpt_cmpSelCompanyGroup_Result item) => new nComboBoxListItem
				{
					Text = item.Val,
					Value = item.ID.ToString(),
					Selected = (item.ID == selectedId),
					IsSysDef = (Enumerable.FirstOrDefault<string>((IEnumerable<string>)SysDefs, (Func<string, bool>)((string sd) => sd == item.Val)) != null),
					IsSep = (item.ID == textItemSeperatorId)
				}))));
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return result;
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetSubGroup(int id, int? selectedId = null)
	{
		string result = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int result3 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result3);
			}
			List<CRMspRpt_cmpSelCompanySubGroup_Result> list = Enumerable.ToList<CRMspRpt_cmpSelCompanySubGroup_Result>((IEnumerable<CRMspRpt_cmpSelCompanySubGroup_Result>)db.CRMspRpt_cmpSelCompanySubGroup(UserLogin.CurrentUser.UserId, id, textNone, textHaveNot, lCID, result2, result3));
			if (list != null)
			{
				result = JsonConvert.SerializeObject(Enumerable.ToList<nComboBoxListItem>(Enumerable.Select<CRMspRpt_cmpSelCompanySubGroup_Result, nComboBoxListItem>((IEnumerable<CRMspRpt_cmpSelCompanySubGroup_Result>)list, (Func<CRMspRpt_cmpSelCompanySubGroup_Result, nComboBoxListItem>)((CRMspRpt_cmpSelCompanySubGroup_Result item) => new nComboBoxListItem
				{
					Text = item.Val,
					Value = item.ID.ToString(),
					Selected = (item.ID == selectedId),
					IsSysDef = (Enumerable.FirstOrDefault<string>((IEnumerable<string>)SysDefs, (Func<string, bool>)((string sd) => sd == item.Val)) != null),
					IsSep = (item.ID == textItemSeperatorId)
				}))));
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return result;
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetCmpGroupsII(int? selectedId = null)
	{
		string result = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspRpt_cmpSelCompanyGroupsII_Result> list = Enumerable.ToList<CRMspRpt_cmpSelCompanyGroupsII_Result>((IEnumerable<CRMspRpt_cmpSelCompanyGroupsII_Result>)db.CRMspRpt_cmpSelCompanyGroupsII(textNone, textHaveNot, lCID, result2));
			if (list != null)
			{
				result = JsonConvert.SerializeObject(Enumerable.ToList<nComboBoxListItem>(Enumerable.Select<CRMspRpt_cmpSelCompanyGroupsII_Result, nComboBoxListItem>((IEnumerable<CRMspRpt_cmpSelCompanyGroupsII_Result>)list, (Func<CRMspRpt_cmpSelCompanyGroupsII_Result, nComboBoxListItem>)((CRMspRpt_cmpSelCompanyGroupsII_Result item) => new nComboBoxListItem
				{
					Text = item.Val,
					Value = item.ID.ToString(),
					Selected = (item.ID == selectedId),
					IsSysDef = (Enumerable.FirstOrDefault<string>((IEnumerable<string>)SysDefs, (Func<string, bool>)((string sd) => sd == item.Val)) != null),
					IsSep = (item.ID == textItemSeperatorId)
				}))));
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return result;
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetCmpGroupsIII(int? selectedId = null)
	{
		string result = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspRpt_cmpSelCompanyGroupsIII_Result> list = Enumerable.ToList<CRMspRpt_cmpSelCompanyGroupsIII_Result>((IEnumerable<CRMspRpt_cmpSelCompanyGroupsIII_Result>)db.CRMspRpt_cmpSelCompanyGroupsIII(textNone, textHaveNot, lCID, result2));
			if (list != null)
			{
				result = JsonConvert.SerializeObject(Enumerable.ToList<nComboBoxListItem>(Enumerable.Select<CRMspRpt_cmpSelCompanyGroupsIII_Result, nComboBoxListItem>((IEnumerable<CRMspRpt_cmpSelCompanyGroupsIII_Result>)list, (Func<CRMspRpt_cmpSelCompanyGroupsIII_Result, nComboBoxListItem>)((CRMspRpt_cmpSelCompanyGroupsIII_Result item) => new nComboBoxListItem
				{
					Text = item.Val,
					Value = item.ID.ToString(),
					Selected = (item.ID == selectedId),
					IsSysDef = (Enumerable.FirstOrDefault<string>((IEnumerable<string>)SysDefs, (Func<string, bool>)((string sd) => sd == item.Val)) != null),
					IsSep = (item.ID == textItemSeperatorId)
				}))));
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return result;
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetCmpGroupsIV(int? selectedId = null)
	{
		string result = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int result3 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result3);
			}
			List<CRMspRpt_cmpSelCompanyGroupsIV_Result> list = Enumerable.ToList<CRMspRpt_cmpSelCompanyGroupsIV_Result>((IEnumerable<CRMspRpt_cmpSelCompanyGroupsIV_Result>)db.CRMspRpt_cmpSelCompanyGroupsIV(UserLogin.CurrentUser.UserId, textNone, textHaveNot, lCID, result2, result3));
			if (list != null)
			{
				result = JsonConvert.SerializeObject(Enumerable.ToList<nComboBoxListItem>(Enumerable.Select<CRMspRpt_cmpSelCompanyGroupsIV_Result, nComboBoxListItem>((IEnumerable<CRMspRpt_cmpSelCompanyGroupsIV_Result>)list, (Func<CRMspRpt_cmpSelCompanyGroupsIV_Result, nComboBoxListItem>)((CRMspRpt_cmpSelCompanyGroupsIV_Result item) => new nComboBoxListItem
				{
					Text = item.Val,
					Value = item.ID.ToString(),
					Selected = (item.ID == selectedId),
					IsSysDef = (Enumerable.FirstOrDefault<string>((IEnumerable<string>)SysDefs, (Func<string, bool>)((string sd) => sd == item.Val)) != null),
					IsSep = (item.ID == textItemSeperatorId)
				}))));
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return result;
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetCmpGroupsMulti(string selectedIds = null)
	{
		string result = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<string> selectedIdsList = new List<string>();
			if (!string.IsNullOrWhiteSpace(selectedIds))
			{
				List<string> list = selectedIdsList;
				object collection;
				if (selectedIds == null)
				{
					collection = null;
				}
				else
				{
					string[] array = selectedIds.Split(new char[1] { ',' });
					if (array == null)
					{
						collection = null;
					}
					else
					{
						IEnumerable<string> enumerable = Enumerable.Where<string>((IEnumerable<string>)array, (Func<string, bool>)((string x) => !string.IsNullOrWhiteSpace(x)));
						collection = ((enumerable != null) ? Enumerable.ToList<string>(enumerable) : null);
					}
				}
				list.AddRange((IEnumerable<string>)collection);
			}
			List<CRMspRpt_cmpSelCompanyGroupsMulti_Result> list2 = Enumerable.ToList<CRMspRpt_cmpSelCompanyGroupsMulti_Result>((IEnumerable<CRMspRpt_cmpSelCompanyGroupsMulti_Result>)db.CRMspRpt_cmpSelCompanyGroupsMulti(textNone, textHaveNot, lCID, result2));
			if (list2 != null)
			{
				result = JsonConvert.SerializeObject(Enumerable.ToList<nComboBoxListItem>(Enumerable.Select<CRMspRpt_cmpSelCompanyGroupsMulti_Result, nComboBoxListItem>((IEnumerable<CRMspRpt_cmpSelCompanyGroupsMulti_Result>)list2, (Func<CRMspRpt_cmpSelCompanyGroupsMulti_Result, nComboBoxListItem>)((CRMspRpt_cmpSelCompanyGroupsMulti_Result item) => new nComboBoxListItem
				{
					Text = item.Val,
					Value = item.ID.ToString(),
					Selected = (Enumerable.FirstOrDefault<string>((IEnumerable<string>)selectedIdsList, (Func<string, bool>)((string x) => x == item.ID.ToString())) != null),
					IsSysDef = (Enumerable.FirstOrDefault<string>((IEnumerable<string>)SysDefs, (Func<string, bool>)((string sd) => sd == item.Val)) != null),
					IsSep = (item.ID == textItemSeperatorId)
				}))));
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return result;
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetCmpReferUsers(int? selectedId = null)
	{
		string result = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int result3 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result3);
			}
			List<CRMspRpt_cmpSelCompanyReferUsers_Result> list = Enumerable.ToList<CRMspRpt_cmpSelCompanyReferUsers_Result>((IEnumerable<CRMspRpt_cmpSelCompanyReferUsers_Result>)Enumerable.OrderBy<CRMspRpt_cmpSelCompanyReferUsers_Result, int>((IEnumerable<CRMspRpt_cmpSelCompanyReferUsers_Result>)db.CRMspRpt_cmpSelCompanyReferUsers(UserLogin.CurrentUser.UserId, textNone, textHaveNot, lCID, result2, result3), (Func<CRMspRpt_cmpSelCompanyReferUsers_Result, int>)((CRMspRpt_cmpSelCompanyReferUsers_Result c) => c.ord)));
			if (list != null)
			{
				result = JsonConvert.SerializeObject(Enumerable.ToList<nComboBoxListItem>(Enumerable.Select<CRMspRpt_cmpSelCompanyReferUsers_Result, nComboBoxListItem>((IEnumerable<CRMspRpt_cmpSelCompanyReferUsers_Result>)list, (Func<CRMspRpt_cmpSelCompanyReferUsers_Result, nComboBoxListItem>)((CRMspRpt_cmpSelCompanyReferUsers_Result item) => new nComboBoxListItem
				{
					Text = item.Val,
					Value = item.ID.ToString(),
					Selected = (item.ID == selectedId),
					IsSysDef = (Enumerable.FirstOrDefault<string>((IEnumerable<string>)SysDefs, (Func<string, bool>)((string sd) => sd == item.Val)) != null),
					IsSep = (item.ID == textItemSeperatorId)
				}))));
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return result;
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetCmpUsers(int? selectedId = null)
	{
		string result = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int result3 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result3);
			}
			List<CRMspRpt_cmpSelCompanyUsers_Result> list = Enumerable.ToList<CRMspRpt_cmpSelCompanyUsers_Result>((IEnumerable<CRMspRpt_cmpSelCompanyUsers_Result>)db.CRMspRpt_cmpSelCompanyUsers(UserLogin.CurrentUser.UserId, textNone, textHaveNot, lCID, result2, result3));
			if (list != null)
			{
				result = JsonConvert.SerializeObject(Enumerable.ToList<nComboBoxListItem>(Enumerable.Select<CRMspRpt_cmpSelCompanyUsers_Result, nComboBoxListItem>((IEnumerable<CRMspRpt_cmpSelCompanyUsers_Result>)list, (Func<CRMspRpt_cmpSelCompanyUsers_Result, nComboBoxListItem>)((CRMspRpt_cmpSelCompanyUsers_Result item) => new nComboBoxListItem
				{
					Text = item.Val,
					Value = item.ID.ToString(),
					Selected = (item.ID == selectedId),
					IsSysDef = (Enumerable.FirstOrDefault<string>((IEnumerable<string>)SysDefs, (Func<string, bool>)((string sd) => sd == item.Val)) != null),
					IsSep = (item.ID == textItemSeperatorId)
				}))));
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return result;
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetPersonUsers(int? selectedId = null)
	{
		string result = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int result3 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result3);
			}
			List<CRMspRpt_cmpSelPersonUsers_Result> list = Enumerable.ToList<CRMspRpt_cmpSelPersonUsers_Result>((IEnumerable<CRMspRpt_cmpSelPersonUsers_Result>)db.CRMspRpt_cmpSelPersonUsers(UserLogin.CurrentUser.UserId, textNone, textHaveNot, lCID, result2, result3));
			if (list != null)
			{
				result = JsonConvert.SerializeObject(Enumerable.ToList<nComboBoxListItem>(Enumerable.Select<CRMspRpt_cmpSelPersonUsers_Result, nComboBoxListItem>((IEnumerable<CRMspRpt_cmpSelPersonUsers_Result>)list, (Func<CRMspRpt_cmpSelPersonUsers_Result, nComboBoxListItem>)((CRMspRpt_cmpSelPersonUsers_Result item) => new nComboBoxListItem
				{
					Text = item.Val,
					Value = item.ID.ToString(),
					Selected = (item.ID == selectedId),
					IsSysDef = (Enumerable.FirstOrDefault<string>((IEnumerable<string>)SysDefs, (Func<string, bool>)((string sd) => sd == item.Val)) != null),
					IsSep = (item.ID == textItemSeperatorId)
				}))));
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return result;
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetSuppUsers(int? selectedId = null)
	{
		string result = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int result3 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result3);
			}
			List<CRMspRpt_cmpSelCompanyReferUsers_Result> list = Enumerable.ToList<CRMspRpt_cmpSelCompanyReferUsers_Result>((IEnumerable<CRMspRpt_cmpSelCompanyReferUsers_Result>)Enumerable.OrderBy<CRMspRpt_cmpSelCompanyReferUsers_Result, int>((IEnumerable<CRMspRpt_cmpSelCompanyReferUsers_Result>)db.CRMspRpt_cmpSelCompanyReferUsers(UserLogin.CurrentUser.UserId, textNone, textHaveNot, lCID, result2, result3), (Func<CRMspRpt_cmpSelCompanyReferUsers_Result, int>)((CRMspRpt_cmpSelCompanyReferUsers_Result c) => c.ord)));
			if (list != null)
			{
				result = JsonConvert.SerializeObject(Enumerable.ToList<nComboBoxListItem>(Enumerable.Select<CRMspRpt_cmpSelCompanyReferUsers_Result, nComboBoxListItem>((IEnumerable<CRMspRpt_cmpSelCompanyReferUsers_Result>)list, (Func<CRMspRpt_cmpSelCompanyReferUsers_Result, nComboBoxListItem>)((CRMspRpt_cmpSelCompanyReferUsers_Result item) => new nComboBoxListItem
				{
					Text = item.Val,
					Value = item.ID.ToString(),
					Selected = (item.ID == selectedId),
					IsSysDef = (Enumerable.FirstOrDefault<string>((IEnumerable<string>)SysDefs, (Func<string, bool>)((string sd) => sd == item.Val)) != null),
					IsSep = (item.ID == textItemSeperatorId)
				}))));
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return result;
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetCompanyCampaignTree()
	{
		string result = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspRpt_cmpSelCompanyCampaignTree_Result> list = Enumerable.ToList<CRMspRpt_cmpSelCompanyCampaignTree_Result>((IEnumerable<CRMspRpt_cmpSelCompanyCampaignTree_Result>)_dbI.CRMspRpt_cmpSelCompanyCampaignTree(lCID, result2));
			if (list != null)
			{
				result = JsonConvert.SerializeObject(list);
			}
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		return result;
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetCmpTspTob()
	{
		List<nComboBoxListItem> list = new List<nComboBoxListItem>();
		try
		{
			list.Add(new nComboBoxListItem
			{
				Text = Labels.SelectItem1,
				Value = "",
				Selected = false
			});
			list.Add(new nComboBoxListItem
			{
				Text = Labels.cmpTspCmpTobI,
				Value = "1",
				Selected = false
			});
			list.Add(new nComboBoxListItem
			{
				Text = Labels.cmpTspCmpTobII,
				Value = "2",
				Selected = false
			});
			list.Add(new nComboBoxListItem
			{
				Text = Labels.cmpTspCmpTobIII,
				Value = "3",
				Selected = false
			});
			list.Add(new nComboBoxListItem
			{
				Text = Labels.cmpTspCmpTobIV,
				Value = "4",
				Selected = false
			});
			list.Add(new nComboBoxListItem
			{
				Text = Labels.cmpTspCmpTobV,
				Value = "5",
				Selected = false
			});
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return JsonConvert.SerializeObject(list);
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetCmpShpSettlementTypes(int? selectedId = null)
	{
		string result = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspSelectShpSettlementTypes_Result> list = Enumerable.ToList<CRMspSelectShpSettlementTypes_Result>((IEnumerable<CRMspSelectShpSettlementTypes_Result>)_dbI.CRMspSelectShpSettlementTypes(lCID, result2));
			if (list != null)
			{
				List<nComboBoxListItem> list2 = new List<nComboBoxListItem>();
				list2.Add(new nComboBoxListItem
				{
					Text = Labels.SelectedListDefValue,
					Value = "",
					IsSysDef = true
				});
				list2.Add(new nComboBoxListItem
				{
					Text = textItemSeperators,
					IsSep = true
				});
				list2.AddRange(Enumerable.ToList<nComboBoxListItem>(Enumerable.Select<CRMspSelectShpSettlementTypes_Result, nComboBoxListItem>((IEnumerable<CRMspSelectShpSettlementTypes_Result>)list, (Func<CRMspSelectShpSettlementTypes_Result, nComboBoxListItem>)((CRMspSelectShpSettlementTypes_Result item) => new nComboBoxListItem
				{
					Text = item.ShpSettlementType,
					Value = item.ShpSettlementTypeId.ToString(),
					Selected = (item.ShpSettlementTypeId == selectedId),
					IsSysDef = (Enumerable.FirstOrDefault<string>((IEnumerable<string>)SysDefs, (Func<string, bool>)((string sd) => sd == item.ShpSettlementTypeId.ToString())) != null),
					IsSep = (item.ShpSettlementTypeId == textItemSeperatorId)
				}))));
				result = JsonConvert.SerializeObject(list2);
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return result;
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetShpSettlementCreditIssueType()
	{
		List<nComboBoxListItem> list = new List<nComboBoxListItem>();
		try
		{
			list.Add(new nComboBoxListItem
			{
				Text = Labels.SelectItem1,
				Value = "",
				Selected = false,
				IsSysDef = true
			});
			list.Add(new nComboBoxListItem
			{
				Text = textItemSeperators,
				IsSep = true
			});
			list.Add(new nComboBoxListItem
			{
				Text = Labels.lblPOrd,
				Value = "20",
				Selected = false
			});
			list.Add(new nComboBoxListItem
			{
				Text = "lblOrd".OrderLabels(),
				Value = "30",
				Selected = false
			});
			list.Add(new nComboBoxListItem
			{
				Text = Labels.lblPOrd + " - " + "lblOrd".OrderLabels(),
				Value = "-100",
				Selected = false
			});
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return JsonConvert.SerializeObject(list);
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetCmpCenters()
	{
		return Center.Get_Json();
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetPrsTitles()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string textNone = Labels.None;
		string textHaveNot = Labels.HaveNot;
		return JsonConvert.SerializeObject(Enumerable.ToList<nComboBoxListItem>(Enumerable.Select<CRMspRpt_cmpSelPersonTitle_Result, nComboBoxListItem>((IEnumerable<CRMspRpt_cmpSelPersonTitle_Result>)Enumerable.ToList<CRMspRpt_cmpSelPersonTitle_Result>((IEnumerable<CRMspRpt_cmpSelPersonTitle_Result>)db.CRMspRpt_cmpSelPersonTitle(textNone, textHaveNot, lCID, result)), (Func<CRMspRpt_cmpSelPersonTitle_Result, nComboBoxListItem>)((CRMspRpt_cmpSelPersonTitle_Result item) => new nComboBoxListItem
		{
			Text = item.Val,
			Value = item.ID.ToString(),
			IsSysDef = ((item.Val == textHaveNot || item.Val == textNone) ? true : false),
			IsSep = (item.Val == textItemSeperators)
		}))));
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetPrsJobs()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		return JsonConvert.SerializeObject(Enumerable.ToList<nComboBoxListItem>(Enumerable.Select<CRMspRpt_cmpSelPersonJobs_Result, nComboBoxListItem>((IEnumerable<CRMspRpt_cmpSelPersonJobs_Result>)Enumerable.ToList<CRMspRpt_cmpSelPersonJobs_Result>((IEnumerable<CRMspRpt_cmpSelPersonJobs_Result>)db.CRMspRpt_cmpSelPersonJobs(textNone, textHaveNot, lCID, result)), (Func<CRMspRpt_cmpSelPersonJobs_Result, nComboBoxListItem>)((CRMspRpt_cmpSelPersonJobs_Result item) => new nComboBoxListItem
		{
			Text = item.Val,
			Value = item.ID.ToString(),
			IsSysDef = ((item.Val == textHaveNot || item.Val == textNone) ? true : false),
			IsSep = (item.Val == textItemSeperators)
		}))));
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetPrsDepartments()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		return JsonConvert.SerializeObject(Enumerable.ToList<nComboBoxListItem>(Enumerable.Select<CRMspRpt_cmpSelPersonDepartments_Result, nComboBoxListItem>((IEnumerable<CRMspRpt_cmpSelPersonDepartments_Result>)Enumerable.ToList<CRMspRpt_cmpSelPersonDepartments_Result>((IEnumerable<CRMspRpt_cmpSelPersonDepartments_Result>)db.CRMspRpt_cmpSelPersonDepartments(textNone, textHaveNot, lCID, result)), (Func<CRMspRpt_cmpSelPersonDepartments_Result, nComboBoxListItem>)((CRMspRpt_cmpSelPersonDepartments_Result item) => new nComboBoxListItem
		{
			Text = item.Val,
			Value = item.ID.ToString(),
			IsSysDef = ((item.Val == textHaveNot || item.Val == textNone) ? true : false),
			IsSep = (item.Val == textItemSeperators)
		}))));
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetPrsType()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		return JsonConvert.SerializeObject(Enumerable.ToList<nComboBoxListItem>(Enumerable.Select<CRMspRpt_cmpSelPersonType_Result, nComboBoxListItem>((IEnumerable<CRMspRpt_cmpSelPersonType_Result>)Enumerable.ToList<CRMspRpt_cmpSelPersonType_Result>((IEnumerable<CRMspRpt_cmpSelPersonType_Result>)db.CRMspRpt_cmpSelPersonType(textNone, textHaveNot, lCID, result)), (Func<CRMspRpt_cmpSelPersonType_Result, nComboBoxListItem>)((CRMspRpt_cmpSelPersonType_Result item) => new nComboBoxListItem
		{
			Text = item.Val,
			Value = item.ID.ToString(),
			IsSysDef = ((item.Val == textHaveNot || item.Val == textNone) ? true : false),
			IsSep = (item.Val == textItemSeperators)
		}))));
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetPrsGroup()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		return JsonConvert.SerializeObject(Enumerable.ToList<nComboBoxListItem>(Enumerable.Select<CRMspRpt_cmpSelPersonGroups_Result, nComboBoxListItem>((IEnumerable<CRMspRpt_cmpSelPersonGroups_Result>)Enumerable.ToList<CRMspRpt_cmpSelPersonGroups_Result>((IEnumerable<CRMspRpt_cmpSelPersonGroups_Result>)db.CRMspRpt_cmpSelPersonGroups(textNone, textHaveNot, lCID, result)), (Func<CRMspRpt_cmpSelPersonGroups_Result, nComboBoxListItem>)((CRMspRpt_cmpSelPersonGroups_Result item) => new nComboBoxListItem
		{
			Text = item.Val,
			Value = item.ID.ToString(),
			IsSysDef = ((item.Val == textHaveNot || item.Val == textNone) ? true : false),
			IsSep = (item.Val == textItemSeperators)
		}))));
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetPrsEducation()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		return JsonConvert.SerializeObject(Enumerable.ToList<nComboBoxListItem>(Enumerable.Select<CRMspRpt_cmpSelPersonEducation_Result, nComboBoxListItem>((IEnumerable<CRMspRpt_cmpSelPersonEducation_Result>)Enumerable.ToList<CRMspRpt_cmpSelPersonEducation_Result>((IEnumerable<CRMspRpt_cmpSelPersonEducation_Result>)db.CRMspRpt_cmpSelPersonEducation(textNone, textHaveNot, lCID, result)), (Func<CRMspRpt_cmpSelPersonEducation_Result, nComboBoxListItem>)((CRMspRpt_cmpSelPersonEducation_Result item) => new nComboBoxListItem
		{
			Text = item.Val,
			Value = item.ID.ToString(),
			IsSysDef = ((item.Val == textHaveNot || item.Val == textNone) ? true : false),
			IsSep = (item.Val == textItemSeperators)
		}))));
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetPrsSex()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		return JsonConvert.SerializeObject(Enumerable.ToList<nComboBoxListItem>(Enumerable.Select<CRMspRpt_cmpSelSex_Result, nComboBoxListItem>((IEnumerable<CRMspRpt_cmpSelSex_Result>)Enumerable.ToList<CRMspRpt_cmpSelSex_Result>((IEnumerable<CRMspRpt_cmpSelSex_Result>)db.CRMspRpt_cmpSelSex(textNone, textHaveNot, lCID, result)), (Func<CRMspRpt_cmpSelSex_Result, nComboBoxListItem>)((CRMspRpt_cmpSelSex_Result item) => new nComboBoxListItem
		{
			Text = item.Val,
			Value = item.ID.ToString(),
			IsSysDef = ((item.Val == textHaveNot || item.Val == textNone) ? true : false),
			IsSep = (item.Val == textItemSeperators)
		}))));
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetPrsCountry()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string textNone = Labels.None;
		string textHaveNot = Labels.HaveNot;
		return JsonConvert.SerializeObject(Enumerable.ToList<nComboBoxListItem>(Enumerable.Select<CRMspRpt_cmpSelPersonCountry_Result, nComboBoxListItem>((IEnumerable<CRMspRpt_cmpSelPersonCountry_Result>)Enumerable.ToList<CRMspRpt_cmpSelPersonCountry_Result>((IEnumerable<CRMspRpt_cmpSelPersonCountry_Result>)db.CRMspRpt_cmpSelPersonCountry(textNone, textHaveNot, lCID, result)), (Func<CRMspRpt_cmpSelPersonCountry_Result, nComboBoxListItem>)((CRMspRpt_cmpSelPersonCountry_Result item) => new nComboBoxListItem
		{
			Text = item.Val,
			Value = item.ID.ToString(),
			IsSysDef = ((item.Val == textHaveNot || item.Val == textNone) ? true : false),
			IsSep = (item.Val == textItemSeperators)
		}))));
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetPrsProvince(int? id = null)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		return JsonConvert.SerializeObject(Enumerable.ToList<nComboBoxListItem>(Enumerable.Select<CRMspRpt_cmpSelPersonProvince_Result, nComboBoxListItem>((IEnumerable<CRMspRpt_cmpSelPersonProvince_Result>)Enumerable.ToList<CRMspRpt_cmpSelPersonProvince_Result>((IEnumerable<CRMspRpt_cmpSelPersonProvince_Result>)db.CRMspRpt_cmpSelPersonProvince(id, textNone, textHaveNot, lCID, result)), (Func<CRMspRpt_cmpSelPersonProvince_Result, nComboBoxListItem>)((CRMspRpt_cmpSelPersonProvince_Result province) => new nComboBoxListItem
		{
			Text = province.Val,
			Value = province.ID.ToString(),
			IsSysDef = ((province.Val == textHaveNot || province.Val == textNone) ? true : false),
			IsSep = (province.Val == textItemSeperators)
		}))));
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetPrsCity(int? id = null)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		return JsonConvert.SerializeObject(Enumerable.ToList<nComboBoxListItem>(Enumerable.Select<CRMspRpt_cmpSelPersonCity_Result, nComboBoxListItem>((IEnumerable<CRMspRpt_cmpSelPersonCity_Result>)Enumerable.ToList<CRMspRpt_cmpSelPersonCity_Result>((IEnumerable<CRMspRpt_cmpSelPersonCity_Result>)db.CRMspRpt_cmpSelPersonCity(id, textNone, textHaveNot, lCID, result)), (Func<CRMspRpt_cmpSelPersonCity_Result, nComboBoxListItem>)((CRMspRpt_cmpSelPersonCity_Result item) => new nComboBoxListItem
		{
			Text = item.Val,
			Value = item.ID.ToString(),
			IsSysDef = ((item.Val == textHaveNot || item.Val == textNone) ? true : false),
			IsSep = (item.Val == textItemSeperators)
		}))));
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetPrjTitle(string selectedId = null)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		int result2 = 0;
		if (UserLogin.CurrentUser != null)
		{
			int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
		}
		return JsonConvert.SerializeObject(Enumerable.ToList<nComboBoxListItem>(Enumerable.Select<CRMspRpt_cmpSelProjects_Result, nComboBoxListItem>((IEnumerable<CRMspRpt_cmpSelProjects_Result>)Enumerable.ToList<CRMspRpt_cmpSelProjects_Result>((IEnumerable<CRMspRpt_cmpSelProjects_Result>)Enumerable.OrderBy<CRMspRpt_cmpSelProjects_Result, string>((IEnumerable<CRMspRpt_cmpSelProjects_Result>)db.CRMspRpt_cmpSelProjects(UserLogin.CurrentUser.UserId, textNone, textHaveNot, lCID, result, result2), (Func<CRMspRpt_cmpSelProjects_Result, string>)((CRMspRpt_cmpSelProjects_Result c) => c.ord))), (Func<CRMspRpt_cmpSelProjects_Result, nComboBoxListItem>)((CRMspRpt_cmpSelProjects_Result item) => new nComboBoxListItem
		{
			Text = item.Val,
			Value = item.ID.ToString(),
			IsSysDef = ((item.Val == textHaveNot || item.Val == textNone) ? true : false),
			IsSep = (item.Val == textItemSeperators)
		}))));
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetPrjStatusGroups()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		return JsonConvert.SerializeObject(Enumerable.ToList<nComboBoxListItem>(Enumerable.Select<CRMspRpt_cmpSelProjectStatusGroups_Result, nComboBoxListItem>((IEnumerable<CRMspRpt_cmpSelProjectStatusGroups_Result>)Enumerable.ToList<CRMspRpt_cmpSelProjectStatusGroups_Result>((IEnumerable<CRMspRpt_cmpSelProjectStatusGroups_Result>)Enumerable.OrderBy<CRMspRpt_cmpSelProjectStatusGroups_Result, int>((IEnumerable<CRMspRpt_cmpSelProjectStatusGroups_Result>)db.CRMspRpt_cmpSelProjectStatusGroups(UserLogin.CurrentUser.UserId, textNone, textHaveNot, lCID, result), (Func<CRMspRpt_cmpSelProjectStatusGroups_Result, int>)((CRMspRpt_cmpSelProjectStatusGroups_Result c) => c.ord))), (Func<CRMspRpt_cmpSelProjectStatusGroups_Result, nComboBoxListItem>)((CRMspRpt_cmpSelProjectStatusGroups_Result item) => new nComboBoxListItem
		{
			Text = item.Val,
			Value = item.ID.ToString(),
			IsSysDef = ((item.Val == textHaveNot || item.Val == textNone) ? true : false),
			IsSep = (item.Val == textItemSeperators)
		}))));
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetPrjPriority()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string textNone = Labels.None;
		string textHaveNot = Labels.HaveNot;
		return JsonConvert.SerializeObject(Enumerable.ToList<nComboBoxListItem>(Enumerable.Select<CRMspRpt_cmpSelProjectPriority_Result, nComboBoxListItem>((IEnumerable<CRMspRpt_cmpSelProjectPriority_Result>)Enumerable.ToList<CRMspRpt_cmpSelProjectPriority_Result>((IEnumerable<CRMspRpt_cmpSelProjectPriority_Result>)db.CRMspRpt_cmpSelProjectPriority(textNone, textHaveNot, lCID, result)), (Func<CRMspRpt_cmpSelProjectPriority_Result, nComboBoxListItem>)((CRMspRpt_cmpSelProjectPriority_Result item) => new nComboBoxListItem
		{
			Text = item.Val,
			Value = item.ID.ToString(),
			IsSysDef = ((item.Val == textHaveNot || item.Val == textNone) ? true : false),
			IsSep = (item.Val == textItemSeperators)
		}))));
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetPrjGrade()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		return JsonConvert.SerializeObject(Enumerable.ToList<nComboBoxListItem>(Enumerable.Select<CRMspRpt_cmpSelProjectGrade_Result, nComboBoxListItem>((IEnumerable<CRMspRpt_cmpSelProjectGrade_Result>)Enumerable.ToList<CRMspRpt_cmpSelProjectGrade_Result>((IEnumerable<CRMspRpt_cmpSelProjectGrade_Result>)db.CRMspRpt_cmpSelProjectGrade(textNone, textHaveNot, lCID, result)), (Func<CRMspRpt_cmpSelProjectGrade_Result, nComboBoxListItem>)((CRMspRpt_cmpSelProjectGrade_Result item) => new nComboBoxListItem
		{
			Text = item.Val,
			Value = item.ID.ToString(),
			IsSysDef = ((item.Val == textHaveNot || item.Val == textNone) ? true : false),
			IsSep = (item.Val == textItemSeperators)
		}))));
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetPrjGroup()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		return JsonConvert.SerializeObject(Enumerable.ToList<nComboBoxListItem>(Enumerable.Select<CRMspRpt_cmpSelProjectGroups_Result, nComboBoxListItem>((IEnumerable<CRMspRpt_cmpSelProjectGroups_Result>)Enumerable.ToList<CRMspRpt_cmpSelProjectGroups_Result>((IEnumerable<CRMspRpt_cmpSelProjectGroups_Result>)db.CRMspRpt_cmpSelProjectGroups(textNone, textHaveNot, lCID, result)), (Func<CRMspRpt_cmpSelProjectGroups_Result, nComboBoxListItem>)((CRMspRpt_cmpSelProjectGroups_Result item) => new nComboBoxListItem
		{
			Text = item.Val,
			Value = item.ID.ToString(),
			IsSysDef = ((item.Val == textHaveNot || item.Val == textNone) ? true : false),
			IsSep = (item.Val == textItemSeperators)
		}))));
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetPrjGroupsMulti(string selectdIds = null)
	{
		string result = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<string> selectedIdsList = new List<string>();
			if (!string.IsNullOrWhiteSpace(selectdIds))
			{
				List<string> list = selectedIdsList;
				object collection;
				if (selectdIds == null)
				{
					collection = null;
				}
				else
				{
					string[] array = selectdIds.Split(new char[1] { ',' });
					if (array == null)
					{
						collection = null;
					}
					else
					{
						IEnumerable<string> enumerable = Enumerable.Where<string>((IEnumerable<string>)array, (Func<string, bool>)((string x) => !string.IsNullOrWhiteSpace(x)));
						collection = ((enumerable != null) ? Enumerable.ToList<string>(enumerable) : null);
					}
				}
				list.AddRange((IEnumerable<string>)collection);
			}
			result = JsonConvert.SerializeObject(Enumerable.ToList<nComboBoxListItem>(Enumerable.Select<CRMspRpt_cmpSelProjectGroupsMulti_Result, nComboBoxListItem>((IEnumerable<CRMspRpt_cmpSelProjectGroupsMulti_Result>)Enumerable.ToList<CRMspRpt_cmpSelProjectGroupsMulti_Result>((IEnumerable<CRMspRpt_cmpSelProjectGroupsMulti_Result>)db.CRMspRpt_cmpSelProjectGroupsMulti(textNone, textHaveNot, lCID, result2)), (Func<CRMspRpt_cmpSelProjectGroupsMulti_Result, nComboBoxListItem>)((CRMspRpt_cmpSelProjectGroupsMulti_Result item) => new nComboBoxListItem
			{
				Text = item.Val,
				Value = item.ID.ToString(),
				Selected = (Enumerable.FirstOrDefault<string>((IEnumerable<string>)selectedIdsList, (Func<string, bool>)((string x) => x == item.ID.ToString())) != null),
				IsSysDef = ((item.Val == textHaveNot || item.Val == textNone) ? true : false),
				IsSep = (item.Val == textItemSeperators)
			}))));
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return result;
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetPrjGroupsMultiI(string selectdIds = null)
	{
		string result = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<string> selectedIdsList = new List<string>();
			if (!string.IsNullOrWhiteSpace(selectdIds))
			{
				List<string> list = selectedIdsList;
				object collection;
				if (selectdIds == null)
				{
					collection = null;
				}
				else
				{
					string[] array = selectdIds.Split(new char[1] { ',' });
					if (array == null)
					{
						collection = null;
					}
					else
					{
						IEnumerable<string> enumerable = Enumerable.Where<string>((IEnumerable<string>)array, (Func<string, bool>)((string x) => !string.IsNullOrWhiteSpace(x)));
						collection = ((enumerable != null) ? Enumerable.ToList<string>(enumerable) : null);
					}
				}
				list.AddRange((IEnumerable<string>)collection);
			}
			result = JsonConvert.SerializeObject(Enumerable.ToList<nComboBoxListItem>(Enumerable.Select<CRMspRpt_cmpSelProjectGroupsMultiI_Result, nComboBoxListItem>((IEnumerable<CRMspRpt_cmpSelProjectGroupsMultiI_Result>)Enumerable.ToList<CRMspRpt_cmpSelProjectGroupsMultiI_Result>((IEnumerable<CRMspRpt_cmpSelProjectGroupsMultiI_Result>)db.CRMspRpt_cmpSelProjectGroupsMultiI(textNone, textHaveNot, lCID, result2)), (Func<CRMspRpt_cmpSelProjectGroupsMultiI_Result, nComboBoxListItem>)((CRMspRpt_cmpSelProjectGroupsMultiI_Result item) => new nComboBoxListItem
			{
				Text = item.Val,
				Value = item.ID.ToString(),
				Selected = (Enumerable.FirstOrDefault<string>((IEnumerable<string>)selectedIdsList, (Func<string, bool>)((string x) => x == item.ID.ToString())) != null),
				IsSysDef = ((item.Val == textHaveNot || item.Val == textNone) ? true : false),
				IsSep = (item.Val == textItemSeperators)
			}))));
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return result;
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetPrjSaveUsers()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		int result2 = 0;
		if (UserLogin.CurrentUser != null)
		{
			int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
		}
		return JsonConvert.SerializeObject(Enumerable.ToList<nComboBoxListItem>(Enumerable.Select<CRMspRpt_cmpSelProjectSaveUsers_Result, nComboBoxListItem>((IEnumerable<CRMspRpt_cmpSelProjectSaveUsers_Result>)Enumerable.ToList<CRMspRpt_cmpSelProjectSaveUsers_Result>((IEnumerable<CRMspRpt_cmpSelProjectSaveUsers_Result>)db.CRMspRpt_cmpSelProjectSaveUsers(UserLogin.CurrentUser.UserId, textNone, textHaveNot, lCID, result, result2)), (Func<CRMspRpt_cmpSelProjectSaveUsers_Result, nComboBoxListItem>)((CRMspRpt_cmpSelProjectSaveUsers_Result item) => new nComboBoxListItem
		{
			Text = item.Val,
			Value = item.ID.ToString(),
			IsSysDef = ((item.Val == textHaveNot || item.Val == textNone) ? true : false),
			IsSep = (item.Val == textItemSeperators)
		}))));
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetPrjEditUsers()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		int result2 = 0;
		if (UserLogin.CurrentUser != null)
		{
			int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
		}
		return JsonConvert.SerializeObject(Enumerable.ToList<nComboBoxListItem>(Enumerable.Select<CRMspRpt_cmpSelProjectEditUsers_Result, nComboBoxListItem>((IEnumerable<CRMspRpt_cmpSelProjectEditUsers_Result>)Enumerable.ToList<CRMspRpt_cmpSelProjectEditUsers_Result>((IEnumerable<CRMspRpt_cmpSelProjectEditUsers_Result>)db.CRMspRpt_cmpSelProjectEditUsers(UserLogin.CurrentUser.UserId, textNone, textHaveNot, lCID, result, result2)), (Func<CRMspRpt_cmpSelProjectEditUsers_Result, nComboBoxListItem>)((CRMspRpt_cmpSelProjectEditUsers_Result item) => new nComboBoxListItem
		{
			Text = item.Val,
			Value = item.ID.ToString(),
			IsSysDef = ((item.Val == textHaveNot || item.Val == textNone) ? true : false),
			IsSep = (item.Val == textItemSeperators)
		}))));
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetPrjTreeInfo()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		return JsonConvert.SerializeObject(Enumerable.ToList<nComboBoxListItem>(Enumerable.Select<CRMspRpt_cmpSelProjectFieldTitle_Result, nComboBoxListItem>((IEnumerable<CRMspRpt_cmpSelProjectFieldTitle_Result>)Enumerable.ToList<CRMspRpt_cmpSelProjectFieldTitle_Result>((IEnumerable<CRMspRpt_cmpSelProjectFieldTitle_Result>)db.CRMspRpt_cmpSelProjectFieldTitle(textNone, textHaveNot, lCID, result)), (Func<CRMspRpt_cmpSelProjectFieldTitle_Result, nComboBoxListItem>)((CRMspRpt_cmpSelProjectFieldTitle_Result item) => new nComboBoxListItem
		{
			Text = item.Val,
			Value = item.ValueType + "|" + item.ID,
			IsSysDef = ((item.Val == textHaveNot || item.Val == textNone) ? true : false),
			IsSep = (item.Val == textItemSeperators)
		}))));
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetPrjCompanyPresentation()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		return JsonConvert.SerializeObject(Enumerable.ToList<nComboBoxListItem>(Enumerable.Select<CRMspRpt_cmpSelCompanyPresentation_Result, nComboBoxListItem>((IEnumerable<CRMspRpt_cmpSelCompanyPresentation_Result>)Enumerable.ToList<CRMspRpt_cmpSelCompanyPresentation_Result>((IEnumerable<CRMspRpt_cmpSelCompanyPresentation_Result>)db.CRMspRpt_cmpSelCompanyPresentation(textNone, textHaveNot, lCID, result)), (Func<CRMspRpt_cmpSelCompanyPresentation_Result, nComboBoxListItem>)((CRMspRpt_cmpSelCompanyPresentation_Result item) => new nComboBoxListItem
		{
			Text = item.Val,
			Value = item.ID.ToString(),
			IsSysDef = ((item.Val == textHaveNot || item.Val == textNone) ? true : false),
			IsSep = (item.Val == textItemSeperators)
		}))));
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetPrjTitleGroup()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<nComboBoxListItem> value = new List<nComboBoxListItem>();
		try
		{
			List<CRMspRpt_cmpSelProjectTitleGroups_Result> list = Enumerable.ToList<CRMspRpt_cmpSelProjectTitleGroups_Result>((IEnumerable<CRMspRpt_cmpSelProjectTitleGroups_Result>)Enumerable.OrderBy<CRMspRpt_cmpSelProjectTitleGroups_Result, string>((IEnumerable<CRMspRpt_cmpSelProjectTitleGroups_Result>)_dbII.CRMspRpt_cmpSelProjectTitleGroups(UserLogin.CurrentUser.UserId, textNone, textHaveNot, lCID, result), (Func<CRMspRpt_cmpSelProjectTitleGroups_Result, string>)((CRMspRpt_cmpSelProjectTitleGroups_Result c) => c.ord)));
			if (list != null && Enumerable.Any<CRMspRpt_cmpSelProjectTitleGroups_Result>((IEnumerable<CRMspRpt_cmpSelProjectTitleGroups_Result>)list))
			{
				value = Enumerable.ToList<nComboBoxListItem>(Enumerable.Select<CRMspRpt_cmpSelProjectTitleGroups_Result, nComboBoxListItem>((IEnumerable<CRMspRpt_cmpSelProjectTitleGroups_Result>)list, (Func<CRMspRpt_cmpSelProjectTitleGroups_Result, nComboBoxListItem>)((CRMspRpt_cmpSelProjectTitleGroups_Result item) => new nComboBoxListItem
				{
					Text = item.Val,
					Value = item.ID.ToString(),
					IsSysDef = ((item.Val == textHaveNot || item.Val == textNone) ? true : false),
					IsSep = (item.Val == textItemSeperators)
				})));
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return JsonConvert.SerializeObject(value);
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetPrjStartDay()
	{
		List<nComboBoxListItem> list = new List<nComboBoxListItem>();
		list.Add(new nComboBoxListItem
		{
			Text = Labels.SelectedListDefValue,
			IsSysDef = true
		});
		list.Add(new nComboBoxListItem
		{
			Text = textItemSeperators,
			IsSep = true
		});
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			DateTimeFormatInfo dateTimeFormat = new CultureInfo(lCID).DateTimeFormat;
			_ = dateTimeFormat.FirstDayOfWeek;
			string[] dayNames = dateTimeFormat.DayNames;
			if (lCID == 1065)
			{
				list.Add(new nComboBoxListItem
				{
					Text = dayNames[6],
					Value = "7"
				});
				for (int i = 0; i < Enumerable.Count<string>((IEnumerable<string>)dayNames) - 1; i++)
				{
					list.Add(new nComboBoxListItem
					{
						Text = dayNames[i],
						Value = (i + 1).ToString()
					});
				}
			}
			else
			{
				for (int j = 0; j < Enumerable.Count<string>((IEnumerable<string>)dayNames); j++)
				{
					list.Add(new nComboBoxListItem
					{
						Text = dayNames[j],
						Value = (j + 1).ToString()
					});
				}
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return JsonConvert.SerializeObject(list);
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetPrjFinishDay()
	{
		List<nComboBoxListItem> list = new List<nComboBoxListItem>();
		list.Add(new nComboBoxListItem
		{
			Text = Labels.SelectedListDefValue,
			IsSysDef = true
		});
		list.Add(new nComboBoxListItem
		{
			Text = textItemSeperators,
			IsSep = true
		});
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			DateTimeFormatInfo dateTimeFormat = new CultureInfo(lCID).DateTimeFormat;
			_ = dateTimeFormat.FirstDayOfWeek;
			string[] dayNames = dateTimeFormat.DayNames;
			if (lCID == 1065)
			{
				list.Add(new nComboBoxListItem
				{
					Text = dayNames[6],
					Value = "7"
				});
				for (int i = 0; i < Enumerable.Count<string>((IEnumerable<string>)dayNames) - 1; i++)
				{
					list.Add(new nComboBoxListItem
					{
						Text = dayNames[i],
						Value = (i + 1).ToString()
					});
				}
			}
			else
			{
				for (int j = 0; j < Enumerable.Count<string>((IEnumerable<string>)dayNames); j++)
				{
					list.Add(new nComboBoxListItem
					{
						Text = dayNames[j],
						Value = (j + 1).ToString()
					});
				}
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return JsonConvert.SerializeObject(list);
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetPrjStarterUser()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<nComboBoxListItem> list = new List<nComboBoxListItem>();
		list.Add(new nComboBoxListItem
		{
			Text = Labels.SelectedListDefValue,
			IsSysDef = true
		});
		list.Add(new nComboBoxListItem
		{
			Text = textItemSeperators,
			IsSep = true
		});
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			List<CRMspSelectUserForLinkedType_Result> list2 = Enumerable.ToList<CRMspSelectUserForLinkedType_Result>((IEnumerable<CRMspSelectUserForLinkedType_Result>)db.CRMspSelectUserForLinkedType(UserLogin.CurrentUser.UserId, 11, lCID, result, result2));
			if (list2 != null)
			{
				list = Enumerable.ToList<nComboBoxListItem>(Enumerable.Select<CRMspSelectUserForLinkedType_Result, nComboBoxListItem>((IEnumerable<CRMspSelectUserForLinkedType_Result>)list2, (Func<CRMspSelectUserForLinkedType_Result, nComboBoxListItem>)((CRMspSelectUserForLinkedType_Result item) => new nComboBoxListItem
				{
					Text = item.UserName,
					Value = item.LinkedUserId.ToString()
				})));
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return JsonConvert.SerializeObject(list);
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetPrjCategoryTree()
	{
		return JsonConvert.SerializeObject(GetProjectCategoryTree());
	}

	[HttpPost]
	[LoginAuthorize]
	public List<CRMspSelectProjectCategoryTree_Result> GetProjectCategoryTree(int currCatId = -1)
	{
		List<CRMspSelectProjectCategoryTree_Result> result = new List<CRMspSelectProjectCategoryTree_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspSelectProjectCategoryTree_Result> list = Enumerable.ToList<CRMspSelectProjectCategoryTree_Result>((IEnumerable<CRMspSelectProjectCategoryTree_Result>)db.CRMspSelectProjectCategoryTree(currCatId, lCID, result2));
			if (list != null)
			{
				result = list;
			}
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		return result;
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetPrjUserDepartment()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<nComboBoxListItem> value = new List<nComboBoxListItem>();
		int result2 = 0;
		if (UserLogin.CurrentUser != null)
		{
			int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
		}
		try
		{
			value = Enumerable.ToList<nComboBoxListItem>(Enumerable.Select<CRMspSelectProjectUserDepartments_Result, nComboBoxListItem>((IEnumerable<CRMspSelectProjectUserDepartments_Result>)Enumerable.ToList<CRMspSelectProjectUserDepartments_Result>((IEnumerable<CRMspSelectProjectUserDepartments_Result>)_dbI.CRMspSelectProjectUserDepartments(lCID, result, result2)), (Func<CRMspSelectProjectUserDepartments_Result, nComboBoxListItem>)((CRMspSelectProjectUserDepartments_Result item) => new nComboBoxListItem
			{
				Text = item.Department,
				Value = item.DepartmentID.ToString()
			})));
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return JsonConvert.SerializeObject(value);
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetPrjIsFinished()
	{
		return JsonConvert.SerializeObject(new List<nComboBoxListItem>
		{
			new nComboBoxListItem
			{
				Text = Labels.SelectedListDefValue,
				IsSysDef = true
			},
			new nComboBoxListItem
			{
				Text = textItemSeperators,
				IsSep = true
			},
			new nComboBoxListItem
			{
				Text = Labels.rptCompanyReportArchive,
				Value = "1"
			},
			new nComboBoxListItem
			{
				Text = Labels.rptCompanyReportNotArchive,
				Value = "0"
			}
		});
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetPrjTreeInfoDrp(string selectedId = null)
	{
		string result = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<nComboBoxListItem> list = Enumerable.ToList<nComboBoxListItem>(Enumerable.Select<CRMspRpt_cmpSelProjectFieldTitle_Result, nComboBoxListItem>((IEnumerable<CRMspRpt_cmpSelProjectFieldTitle_Result>)Enumerable.ToList<CRMspRpt_cmpSelProjectFieldTitle_Result>((IEnumerable<CRMspRpt_cmpSelProjectFieldTitle_Result>)db.CRMspRpt_cmpSelProjectFieldTitle(textNone, textHaveNot, lCID, result2)), (Func<CRMspRpt_cmpSelProjectFieldTitle_Result, nComboBoxListItem>)((CRMspRpt_cmpSelProjectFieldTitle_Result item) => new nComboBoxListItem
			{
				Text = item.Val,
				Value = item.ValueType + "-" + item.ID,
				Selected = (item.Val == selectedId),
				IsSysDef = ((item.Val == textHaveNot || item.Val == textNone) ? true : false),
				IsSep = (item.Val == textItemSeperators)
			})));
			if (list != null)
			{
				result = JsonConvert.SerializeObject(list);
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return result;
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetPrjTreeInfoSearchCompany(string txtSearch = "", int? selectedId = null)
	{
		string result = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			new List<CrmDroupDownItem>();
			int result3 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result3);
			}
			List<CRMspRpt_cmpSelectAndSearchCompany_Result> list = Enumerable.ToList<CRMspRpt_cmpSelectAndSearchCompany_Result>((IEnumerable<CRMspRpt_cmpSelectAndSearchCompany_Result>)db.CRMspRpt_cmpSelectAndSearchCompany(txtSearch, UserLogin.CurrentUser.UserId, lCID, result2, result3));
			List<nComboBoxListItem> list2 = new List<nComboBoxListItem>();
			if (list != null)
			{
				list2.AddRange(Enumerable.Select<CRMspRpt_cmpSelectAndSearchCompany_Result, nComboBoxListItem>((IEnumerable<CRMspRpt_cmpSelectAndSearchCompany_Result>)list, (Func<CRMspRpt_cmpSelectAndSearchCompany_Result, nComboBoxListItem>)((CRMspRpt_cmpSelectAndSearchCompany_Result x) => new nComboBoxListItem
				{
					Value = x.CompanyID.ToString(),
					Text = x.TitleCompany + " " + x.cmpNumber + " " + x.Province + " " + x.City,
					Selected = (x.CompanyID == selectedId)
				})));
				result = JsonConvert.SerializeObject(list2);
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return result;
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetPrjTreeInfoSearchCompanyPersons(string txtSearch = "", int? selectedId = null)
	{
		string result = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			new List<CrmDroupDownItem>();
			int result3 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result3);
			}
			List<CRMspRpt_cmpSelectAndSearchCompanyPersons_Result> list = Enumerable.ToList<CRMspRpt_cmpSelectAndSearchCompanyPersons_Result>((IEnumerable<CRMspRpt_cmpSelectAndSearchCompanyPersons_Result>)db.CRMspRpt_cmpSelectAndSearchCompanyPersons(txtSearch, UserLogin.CurrentUser.UserId, lCID, result2, result3));
			List<nComboBoxListItem> list2 = new List<nComboBoxListItem>();
			if (list != null)
			{
				list2.AddRange(Enumerable.Select<CRMspRpt_cmpSelectAndSearchCompanyPersons_Result, nComboBoxListItem>((IEnumerable<CRMspRpt_cmpSelectAndSearchCompanyPersons_Result>)list, (Func<CRMspRpt_cmpSelectAndSearchCompanyPersons_Result, nComboBoxListItem>)((CRMspRpt_cmpSelectAndSearchCompanyPersons_Result x) => new nComboBoxListItem
				{
					Value = x.CompanyPersonID.ToString(),
					Text = x.Person + " " + x.PersonJob + " " + x.TitleCompany,
					Selected = (x.CompanyPersonID == selectedId)
				})));
				result = JsonConvert.SerializeObject(list2);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetPrjTreeInfoSearchProjectDefualtValue(int id, string txtSearch = "", int? selectedId = null)
	{
		string result = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			new List<CrmDroupDownItem>();
			List<CRMspRpt_cmpSelectAndSearchProjectDefualtValue_Result> list = Enumerable.ToList<CRMspRpt_cmpSelectAndSearchProjectDefualtValue_Result>((IEnumerable<CRMspRpt_cmpSelectAndSearchProjectDefualtValue_Result>)db.CRMspRpt_cmpSelectAndSearchProjectDefualtValue(id, txtSearch, lCID, result2));
			List<nComboBoxListItem> list2 = new List<nComboBoxListItem>();
			if (list != null)
			{
				list2.AddRange(Enumerable.Select<CRMspRpt_cmpSelectAndSearchProjectDefualtValue_Result, nComboBoxListItem>((IEnumerable<CRMspRpt_cmpSelectAndSearchProjectDefualtValue_Result>)list, (Func<CRMspRpt_cmpSelectAndSearchProjectDefualtValue_Result, nComboBoxListItem>)((CRMspRpt_cmpSelectAndSearchProjectDefualtValue_Result x) => new nComboBoxListItem
				{
					Value = x.ProjectDefualtValueId.ToString(),
					Text = x.DefualtValue + " " + x.Description,
					Selected = (x.ProjectDefualtValueId == selectedId)
				})));
				result = JsonConvert.SerializeObject(list2);
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return result;
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetCnvsPriority()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		return JsonConvert.SerializeObject(Enumerable.ToList<nComboBoxListItem>(Enumerable.Select<CRMspRpt_cmpSelConversationPriority_Result, nComboBoxListItem>((IEnumerable<CRMspRpt_cmpSelConversationPriority_Result>)Enumerable.ToList<CRMspRpt_cmpSelConversationPriority_Result>((IEnumerable<CRMspRpt_cmpSelConversationPriority_Result>)db.CRMspRpt_cmpSelConversationPriority(textNone, textHaveNot, lCID, result)), (Func<CRMspRpt_cmpSelConversationPriority_Result, nComboBoxListItem>)((CRMspRpt_cmpSelConversationPriority_Result item) => new nComboBoxListItem
		{
			Text = item.Val,
			Value = item.ID.ToString(),
			IsSysDef = ((item.Val == textHaveNot || item.Val == textNone) ? true : false),
			IsSep = (item.Val == textItemSeperators)
		}))));
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetCnvsTopic()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		return JsonConvert.SerializeObject(Enumerable.ToList<nComboBoxListItem>(Enumerable.Select<CRMspRpt_cmpSelConversationTopics_Result, nComboBoxListItem>((IEnumerable<CRMspRpt_cmpSelConversationTopics_Result>)Enumerable.ToList<CRMspRpt_cmpSelConversationTopics_Result>((IEnumerable<CRMspRpt_cmpSelConversationTopics_Result>)db.CRMspRpt_cmpSelConversationTopics(textNone, textHaveNot, lCID, result)), (Func<CRMspRpt_cmpSelConversationTopics_Result, nComboBoxListItem>)((CRMspRpt_cmpSelConversationTopics_Result item) => new nComboBoxListItem
		{
			Text = item.Val,
			Value = item.ID.ToString(),
			IsSysDef = ((item.Val == textHaveNot || item.Val == textNone) ? true : false),
			IsSep = (item.Val == textItemSeperators)
		}))));
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetCnvsStatus()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		return JsonConvert.SerializeObject(Enumerable.ToList<nComboBoxListItem>(Enumerable.Select<CRMspRpt_cmpSelConversationStatusContain_Result, nComboBoxListItem>((IEnumerable<CRMspRpt_cmpSelConversationStatusContain_Result>)Enumerable.ToList<CRMspRpt_cmpSelConversationStatusContain_Result>((IEnumerable<CRMspRpt_cmpSelConversationStatusContain_Result>)db.CRMspRpt_cmpSelConversationStatusContain(textNone, textHaveNot, lCID, result)), (Func<CRMspRpt_cmpSelConversationStatusContain_Result, nComboBoxListItem>)((CRMspRpt_cmpSelConversationStatusContain_Result item) => new nComboBoxListItem
		{
			Text = (item.Val ?? ""),
			Value = item.ID.ToString(),
			IsSysDef = ((item.Val == textHaveNot || item.Val == textNone) ? true : false),
			IsSep = (item.Val == textItemSeperators)
		}))));
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetCnvsLastStatus(string selectedIds = null)
	{
		string result = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<string> selectedIdsList = new List<string>();
			if (!string.IsNullOrWhiteSpace(selectedIds))
			{
				List<string> list = selectedIdsList;
				string[] array = selectedIds.Split(new char[1] { ',' });
				object collection;
				if (array == null)
				{
					collection = null;
				}
				else
				{
					IEnumerable<string> enumerable = Enumerable.Where<string>((IEnumerable<string>)array, (Func<string, bool>)((string x) => !string.IsNullOrWhiteSpace(x)));
					collection = ((enumerable != null) ? Enumerable.ToList<string>(enumerable) : null);
				}
				list.AddRange((IEnumerable<string>)collection);
			}
			result = JsonConvert.SerializeObject(Enumerable.ToList<nComboBoxListItem>(Enumerable.Select<CRMspRpt_cmpSelConversationStatus_Result, nComboBoxListItem>((IEnumerable<CRMspRpt_cmpSelConversationStatus_Result>)Enumerable.ToList<CRMspRpt_cmpSelConversationStatus_Result>((IEnumerable<CRMspRpt_cmpSelConversationStatus_Result>)db.CRMspRpt_cmpSelConversationStatus(textNone, textHaveNot, lCID, result2)), (Func<CRMspRpt_cmpSelConversationStatus_Result, nComboBoxListItem>)((CRMspRpt_cmpSelConversationStatus_Result item) => new nComboBoxListItem
			{
				Text = (item.Val ?? ""),
				Value = item.ID.ToString(),
				Selected = (Enumerable.FirstOrDefault<string>((IEnumerable<string>)selectedIdsList, (Func<string, bool>)((string x) => x == item.ID.ToString())) != null),
				IsSysDef = ((item.Val == textHaveNot || item.Val == textNone) ? true : false),
				IsSep = (item.Val == textItemSeperators)
			}))));
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return result;
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetCnvsLastStatusResult(string cnvsLastStatusIds, string selectedIds = null)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<nComboBoxListItem> value = new List<nComboBoxListItem>();
		try
		{
			if (!string.IsNullOrWhiteSpace(cnvsLastStatusIds))
			{
				List<string> selectedIdsList = new List<string>();
				if (!string.IsNullOrWhiteSpace(selectedIds))
				{
					List<string> list = selectedIdsList;
					string[] array = selectedIds.Split(new char[1] { ',' });
					object collection;
					if (array == null)
					{
						collection = null;
					}
					else
					{
						IEnumerable<string> enumerable = Enumerable.Where<string>((IEnumerable<string>)array, (Func<string, bool>)((string x) => !string.IsNullOrWhiteSpace(x)));
						collection = ((enumerable != null) ? Enumerable.ToList<string>(enumerable) : null);
					}
					list.AddRange((IEnumerable<string>)collection);
				}
				List<CRMspRpt_cmpSelConversationStatusResult_Result> list2 = Enumerable.ToList<CRMspRpt_cmpSelConversationStatusResult_Result>((IEnumerable<CRMspRpt_cmpSelConversationStatusResult_Result>)_dbII.CRMspRpt_cmpSelConversationStatusResult(cnvsLastStatusIds, textNone, textHaveNot, lCID, result));
				if (list2 != null && Enumerable.Any<CRMspRpt_cmpSelConversationStatusResult_Result>((IEnumerable<CRMspRpt_cmpSelConversationStatusResult_Result>)list2))
				{
					value = Enumerable.ToList<nComboBoxListItem>(Enumerable.Select<CRMspRpt_cmpSelConversationStatusResult_Result, nComboBoxListItem>((IEnumerable<CRMspRpt_cmpSelConversationStatusResult_Result>)list2, (Func<CRMspRpt_cmpSelConversationStatusResult_Result, nComboBoxListItem>)((CRMspRpt_cmpSelConversationStatusResult_Result item) => new nComboBoxListItem
					{
						Text = (item.ResultTitle ?? ""),
						Value = item.ConversationStatusResultId.ToString(),
						Selected = (Enumerable.FirstOrDefault<string>((IEnumerable<string>)selectedIdsList, (Func<string, bool>)((string x) => x == item.ConversationStatusResultId.ToString())) != null),
						IsSysDef = ((item.ResultTitle == textHaveNot || item.ResultTitle == textNone) ? true : false),
						IsSep = (item.ResultTitle == textItemSeperators)
					})));
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return JsonConvert.SerializeObject(value);
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetCnvsStatusContain(string selectedIds = null)
	{
		string result = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<string> selectedIdsList = new List<string>();
			if (!string.IsNullOrWhiteSpace(selectedIds))
			{
				List<string> list = selectedIdsList;
				string[] array = selectedIds.Split(new char[1] { ',' });
				object collection;
				if (array == null)
				{
					collection = null;
				}
				else
				{
					IEnumerable<string> enumerable = Enumerable.Where<string>((IEnumerable<string>)array, (Func<string, bool>)((string x) => !string.IsNullOrWhiteSpace(x)));
					collection = ((enumerable != null) ? Enumerable.ToList<string>(enumerable) : null);
				}
				list.AddRange((IEnumerable<string>)collection);
			}
			List<nComboBoxListItem> list2 = Enumerable.ToList<nComboBoxListItem>(Enumerable.Select<CRMspRpt_cmpSelConversationStatusContain_Result, nComboBoxListItem>((IEnumerable<CRMspRpt_cmpSelConversationStatusContain_Result>)Enumerable.ToList<CRMspRpt_cmpSelConversationStatusContain_Result>((IEnumerable<CRMspRpt_cmpSelConversationStatusContain_Result>)db.CRMspRpt_cmpSelConversationStatusContain(textNone, textHaveNot, lCID, result2)), (Func<CRMspRpt_cmpSelConversationStatusContain_Result, nComboBoxListItem>)((CRMspRpt_cmpSelConversationStatusContain_Result item) => new nComboBoxListItem
			{
				Text = (item.Val ?? ""),
				Value = item.ID.ToString(),
				Selected = (Enumerable.FirstOrDefault<string>((IEnumerable<string>)selectedIdsList, (Func<string, bool>)((string x) => x == item.ID.ToString())) != null),
				IsSysDef = ((item.Val == textHaveNot || item.Val == textNone) ? true : false),
				IsSep = (item.Val == textItemSeperators)
			})));
			if (list2 != null)
			{
				result = JsonConvert.SerializeObject(list2);
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return result;
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetCnvsStatusResultContain(string cnvsStatusIds, string selectedIds = null)
	{
		string result = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<string> selectedIdsList = new List<string>();
			if (!string.IsNullOrWhiteSpace(selectedIds))
			{
				List<string> list = selectedIdsList;
				string[] array = selectedIds.Split(new char[1] { ',' });
				object collection;
				if (array == null)
				{
					collection = null;
				}
				else
				{
					IEnumerable<string> enumerable = Enumerable.Where<string>((IEnumerable<string>)array, (Func<string, bool>)((string x) => !string.IsNullOrWhiteSpace(x)));
					collection = ((enumerable != null) ? Enumerable.ToList<string>(enumerable) : null);
				}
				list.AddRange((IEnumerable<string>)collection);
			}
			new List<nComboBoxListItem>();
			if (!string.IsNullOrWhiteSpace(cnvsStatusIds))
			{
				List<CRMspRpt_cmpSelConversationStatusResultContain_Result> list2 = Enumerable.ToList<CRMspRpt_cmpSelConversationStatusResultContain_Result>((IEnumerable<CRMspRpt_cmpSelConversationStatusResultContain_Result>)_dbII.CRMspRpt_cmpSelConversationStatusResultContain(cnvsStatusIds, textNone, textHaveNot, lCID, result2));
				if (list2 != null && Enumerable.Any<CRMspRpt_cmpSelConversationStatusResultContain_Result>((IEnumerable<CRMspRpt_cmpSelConversationStatusResultContain_Result>)list2))
				{
					result = JsonConvert.SerializeObject(Enumerable.ToList<nComboBoxListItem>(Enumerable.Select<CRMspRpt_cmpSelConversationStatusResultContain_Result, nComboBoxListItem>((IEnumerable<CRMspRpt_cmpSelConversationStatusResultContain_Result>)list2, (Func<CRMspRpt_cmpSelConversationStatusResultContain_Result, nComboBoxListItem>)((CRMspRpt_cmpSelConversationStatusResultContain_Result item) => new nComboBoxListItem
					{
						Text = (item.ResultTitle ?? ""),
						Value = item.ConversationStatusResultId.ToString(),
						Selected = (Enumerable.FirstOrDefault<string>((IEnumerable<string>)selectedIdsList, (Func<string, bool>)((string x) => x == item.ConversationStatusResultId.ToString())) != null),
						IsSysDef = ((item.ResultTitle == textHaveNot || item.ResultTitle == textNone) ? true : false),
						IsSep = (item.ResultTitle == textItemSeperators)
					}))));
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetCnvsDay()
	{
		List<nComboBoxListItem> list = new List<nComboBoxListItem>();
		list.Add(new nComboBoxListItem
		{
			Text = Labels.SelectedListDefValue,
			IsSysDef = true
		});
		list.Add(new nComboBoxListItem
		{
			Text = textItemSeperators,
			IsSep = true
		});
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			DateTimeFormatInfo dateTimeFormat = new CultureInfo(lCID).DateTimeFormat;
			_ = dateTimeFormat.FirstDayOfWeek;
			string[] dayNames = dateTimeFormat.DayNames;
			if (lCID == 1065)
			{
				list.Add(new nComboBoxListItem
				{
					Text = dayNames[6],
					Value = "7"
				});
				for (int i = 0; i < Enumerable.Count<string>((IEnumerable<string>)dayNames) - 1; i++)
				{
					list.Add(new nComboBoxListItem
					{
						Text = dayNames[i],
						Value = (i + 1).ToString()
					});
				}
			}
			else
			{
				for (int j = 0; j < Enumerable.Count<string>((IEnumerable<string>)dayNames); j++)
				{
					list.Add(new nComboBoxListItem
					{
						Text = dayNames[j],
						Value = (j + 1).ToString()
					});
				}
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return JsonConvert.SerializeObject(list);
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetCnvsStatusGroups()
	{
		List<nComboBoxListItem> list = new List<nComboBoxListItem>();
		list.Add(new nComboBoxListItem
		{
			Text = Labels.SelectedListDefValue,
			IsSysDef = true
		});
		list.Add(new nComboBoxListItem
		{
			Text = textItemSeperators,
			IsSep = true
		});
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspSelectConversationStatusGroups_Result> list2 = Enumerable.ToList<CRMspSelectConversationStatusGroups_Result>((IEnumerable<CRMspSelectConversationStatusGroups_Result>)db.CRMspSelectConversationStatusGroups(lCID, result));
			if (list2 != null)
			{
				list = Enumerable.ToList<nComboBoxListItem>(Enumerable.Select<CRMspSelectConversationStatusGroups_Result, nComboBoxListItem>((IEnumerable<CRMspSelectConversationStatusGroups_Result>)list2, (Func<CRMspSelectConversationStatusGroups_Result, nComboBoxListItem>)((CRMspSelectConversationStatusGroups_Result item) => new nComboBoxListItem
				{
					Text = (item.ConversationStatusGroup ?? ""),
					Value = item.ConversationStatusGroupID.ToString()
				})));
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return JsonConvert.SerializeObject(list);
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetCnvsStatusResult(int statusId = 0)
	{
		List<nComboBoxListItem> list = new List<nComboBoxListItem>();
		list.Add(new nComboBoxListItem
		{
			Text = Labels.SelectedListDefValue,
			IsSysDef = true
		});
		list.Add(new nComboBoxListItem
		{
			Text = textItemSeperators,
			IsSep = true
		});
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspSelectConversationStatusResult_Result> list2 = Enumerable.ToList<CRMspSelectConversationStatusResult_Result>((IEnumerable<CRMspSelectConversationStatusResult_Result>)_dbI.CRMspSelectConversationStatusResult(statusId, lCID, result));
			if (list2 != null)
			{
				list = Enumerable.ToList<nComboBoxListItem>(Enumerable.Select<CRMspSelectConversationStatusResult_Result, nComboBoxListItem>((IEnumerable<CRMspSelectConversationStatusResult_Result>)list2, (Func<CRMspSelectConversationStatusResult_Result, nComboBoxListItem>)((CRMspSelectConversationStatusResult_Result item) => new nComboBoxListItem
				{
					Text = item.ResultTitle.ToString(),
					Value = item.ConversationStatusResultId.ToString()
				})));
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return JsonConvert.SerializeObject(list);
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetLinkedUsers()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<nComboBoxListItem> list = new List<nComboBoxListItem>();
		list.Add(new nComboBoxListItem
		{
			Text = Labels.SelectedListDefValue,
			IsSysDef = true
		});
		list.Add(new nComboBoxListItem
		{
			Text = textItemSeperators,
			IsSep = true
		});
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			List<CRMspSelectUserForLinkedType_Result> list2 = Enumerable.ToList<CRMspSelectUserForLinkedType_Result>((IEnumerable<CRMspSelectUserForLinkedType_Result>)db.CRMspSelectUserForLinkedType(UserLogin.CurrentUser.UserId, 33, lCID, result, result2));
			if (list2 != null)
			{
				list = Enumerable.ToList<nComboBoxListItem>(Enumerable.Select<CRMspSelectUserForLinkedType_Result, nComboBoxListItem>((IEnumerable<CRMspSelectUserForLinkedType_Result>)list2, (Func<CRMspSelectUserForLinkedType_Result, nComboBoxListItem>)((CRMspSelectUserForLinkedType_Result item) => new nComboBoxListItem
				{
					Text = item.UserName,
					Value = item.LinkedUserId.ToString()
				})));
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return JsonConvert.SerializeObject(list);
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetCompanyFilterDataWeb(string selectedFieldsJs = "", string dbObjectNames = "")
	{
		string result = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int result3 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result3);
			}
			List<CRMspRpt_CompanyFilterDataWeb_Result> list = Enumerable.ToList<CRMspRpt_CompanyFilterDataWeb_Result>((IEnumerable<CRMspRpt_CompanyFilterDataWeb_Result>)_dbII.CRMspRpt_CompanyFilterDataWeb(selectedFieldsJs, dbObjectNames, UserLogin.CurrentUser.UserId, DateTime.Now.ToString("yyyyMMdd", new PersianCulture()), Configuration.AppType, lCID, result2, result3));
			if (list != null)
			{
				result = JsonConvert.SerializeObject(list);
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return result;
	}

	[LoginAuthorize]
	public ActionResult _PartialOperateOnResult()
	{
		return PartialView();
	}
}
