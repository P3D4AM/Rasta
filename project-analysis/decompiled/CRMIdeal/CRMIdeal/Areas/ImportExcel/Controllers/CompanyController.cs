using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using CRM.General.Security;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.Classes.Helper;
using CRMIdeal.GSD.Globalization;
using Elmah;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CRMIdeal.Areas.ImportExcel.Controllers;

public class CompanyController : Controller
{
	private CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	[HttpPost]
	[LoginAuthorize]
	public string CmpImportExcelToCrm(int totalRecsCnt = 0, int currRecsCnt = 0, string recs = "", string requiredFieldsJs = "", bool chkDupCmpName = false, bool chkDupCmpTel = false, bool chkDupCmpNationalCode = false, bool chkDupCmpEconomicCode = false, bool chkDupCmpCode = false, bool chkDupCmpNumber = false, bool chkDupCmpMobile = false, bool chkDupCmpEmail = false, bool chkDupPrsLName = false, bool chkDupPrsTel = false, bool chkDupPrsMobile = false, bool chkDupPrsNationalCode = false)
	{
		bool flag = false;
		ImpExcelData impExcelData = new ImpExcelData();
		impExcelData.StartReq = DateTime.Now;
		impExcelData.StartReqStr = impExcelData.StartReq.ToString("yyyy/MM/dd HH:mm:ss");
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			string registerDatePersian = DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
			int userId = UserLogin.CurrentUser.UserId;
			short value = short.Parse(Financial.Get().Id.ToString());
			short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			recs = ((recs == "[]" || recs == "{}") ? "" : recs);
			requiredFieldsJs = ((requiredFieldsJs == "[]" || requiredFieldsJs == "{}") ? "" : requiredFieldsJs);
			if (currRecsCnt == 1)
			{
				flag = true;
			}
			if (string.IsNullOrWhiteSpace(recs))
			{
				impExcelData.Messages += Messages.ErrorNotFindRecord;
			}
			else
			{
				List<CRMspImportFromExcelMultiRecWeb_Result> list = Enumerable.ToList<CRMspImportFromExcelMultiRecWeb_Result>((IEnumerable<CRMspImportFromExcelMultiRecWeb_Result>)_dbI.CRMspImportFromExcelMultiRecWeb(recs, requiredFieldsJs, chkDupCmpName, chkDupCmpTel, chkDupCmpNationalCode, chkDupCmpEconomicCode, chkDupCmpCode, chkDupCmpNumber, chkDupCmpMobile, chkDupCmpEmail, chkDupPrsLName, chkDupPrsMobile, chkDupPrsTel, chkDupPrsNationalCode, userId, userId, value, value2, registerDatePersian, appType, result, result));
				if (list != null)
				{
					impExcelData.Data = JsonConvert.SerializeObject(list);
				}
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
			impExcelData.Messages = impExcelData.Messages + "\n" + ex.Message;
		}
		impExcelData.EndReq = DateTime.Now;
		impExcelData.EndReqStr = impExcelData.EndReq.ToString("yyyy/MM/dd HH:mm:ss");
		if (flag)
		{
			double totalSeconds = (impExcelData.EndReq - impExcelData.StartReq).TotalSeconds;
			impExcelData.EndTotalReq = impExcelData.StartReq.AddSeconds(totalSeconds);
			impExcelData.EndTotalReqStr = impExcelData.EndTotalReq.ToString();
		}
		return JsonConvert.SerializeObject(impExcelData);
	}

	[HttpPost]
	[LoginAuthorize]
	public string ImportFromExcelToCmpTankWeb(string js = "", bool deleteTank = false)
	{
		ImpExcelData impExcelData = new ImpExcelData();
		impExcelData.StartReq = DateTime.Now;
		impExcelData.StartReqStr = impExcelData.StartReq.ToString("yyyy/MM/dd HH:mm:ss");
		try
		{
			if (deleteTank)
			{
				_db.CRMspDeleteImportFromExcel();
			}
			if (!string.IsNullOrWhiteSpace(js))
			{
				JArray jArray = JsonConvert.DeserializeObject<JArray>(js);
				foreach (JToken item in jArray)
				{
					JToken jToken = item["cmpPassword"];
					if (jToken != null && !string.IsNullOrWhiteSpace(jToken.ToString()))
					{
						string text = XorCipher.EncryptByPublicKey(jToken.ToString());
						item["cmpPassword"] = text;
					}
				}
				string js2 = JsonConvert.SerializeObject(jArray);
				_dbI.CRMspImportFromExcelToCmpTankWeb(js2);
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		impExcelData.EndReq = DateTime.Now;
		impExcelData.EndReqStr = impExcelData.EndReq.ToString("yyyy/MM/dd HH:mm:ss");
		return JsonConvert.SerializeObject(impExcelData);
	}

	[HttpPost]
	[LoginAuthorize]
	public string SelectImportExcelCmpTank()
	{
		string result = "";
		try
		{
			ObjectResult<CRMspSelectImportFromExcelTank_Result> objectResult = _dbI.CRMspSelectImportFromExcelTank();
			if (objectResult != null)
			{
				result = JsonConvert.SerializeObject(Enumerable.ToList<CRMspSelectImportFromExcelTank_Result>((IEnumerable<CRMspSelectImportFromExcelTank_Result>)objectResult));
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
	public string DeleteImportExcelFromCmp()
	{
		string text = "";
		try
		{
			_db.CRMspDeleteImportExcelFromCrm();
			return "";
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			return ex.Message;
		}
	}

	[HttpPost]
	[LoginAuthorize]
	public string SelectPersonTitleHelp()
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspSelectPersonTitle_Result> list2 = Enumerable.ToList<CRMspSelectPersonTitle_Result>((IEnumerable<CRMspSelectPersonTitle_Result>)_db.CRMspSelectPersonTitle(lCID, result));
			if (list2 != null)
			{
				list.AddRange(Enumerable.Select<CRMspSelectPersonTitle_Result, SelectListItem>((IEnumerable<CRMspSelectPersonTitle_Result>)list2, (Func<CRMspSelectPersonTitle_Result, SelectListItem>)((CRMspSelectPersonTitle_Result item) => new SelectListItem
				{
					Text = item.PersonTitle + " (" + item.PersonTitleID + ")",
					Value = item.PersonTitleID.ToString(),
					Selected = false
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
	public string SelectCmpTitle()
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspSelectCompanyTitle_Result> list2 = Enumerable.ToList<CRMspSelectCompanyTitle_Result>((IEnumerable<CRMspSelectCompanyTitle_Result>)_db.CRMspSelectCompanyTitle(lCID, result));
			list.AddRange(Enumerable.Select<CRMspSelectCompanyTitle_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyTitle_Result>)list2, (Func<CRMspSelectCompanyTitle_Result, SelectListItem>)((CRMspSelectCompanyTitle_Result item) => new SelectListItem
			{
				Text = item.CompanyTitle,
				Value = item.CompanyTitleID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return JsonConvert.SerializeObject(list);
	}

	[HttpPost]
	[LoginAuthorize]
	public string SelectCmpPresentation()
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspSelectCompanyPresentation_Result> list2 = Enumerable.ToList<CRMspSelectCompanyPresentation_Result>((IEnumerable<CRMspSelectCompanyPresentation_Result>)_db.CRMspSelectCompanyPresentation(lCID, result));
			list.AddRange(Enumerable.Select<CRMspSelectCompanyPresentation_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyPresentation_Result>)list2, (Func<CRMspSelectCompanyPresentation_Result, SelectListItem>)((CRMspSelectCompanyPresentation_Result item) => new SelectListItem
			{
				Text = item.Presentation,
				Value = item.CompanyPresentationID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return JsonConvert.SerializeObject(list);
	}

	[HttpPost]
	[LoginAuthorize]
	public string SelectCmpType()
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspSelectCompanyType_Result> list2 = Enumerable.ToList<CRMspSelectCompanyType_Result>((IEnumerable<CRMspSelectCompanyType_Result>)_db.CRMspSelectCompanyType(lCID, result));
			list.AddRange(Enumerable.Select<CRMspSelectCompanyType_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyType_Result>)list2, (Func<CRMspSelectCompanyType_Result, SelectListItem>)((CRMspSelectCompanyType_Result item) => new SelectListItem
			{
				Text = item.CompanyTypeName,
				Value = item.CompanyTypeID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return JsonConvert.SerializeObject(list);
	}

	[HttpPost]
	[LoginAuthorize]
	public string SelectCountry()
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspSelectCountry_Result> list2 = Enumerable.ToList<CRMspSelectCountry_Result>((IEnumerable<CRMspSelectCountry_Result>)_db.CRMspSelectCountry(lCID, result));
			list.AddRange(Enumerable.Select<CRMspSelectCountry_Result, SelectListItem>((IEnumerable<CRMspSelectCountry_Result>)list2, (Func<CRMspSelectCountry_Result, SelectListItem>)((CRMspSelectCountry_Result item) => new SelectListItem
			{
				Text = item.Country,
				Value = item.CountryID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return JsonConvert.SerializeObject(list);
	}

	[HttpPost]
	[LoginAuthorize]
	public string SelectProvince(int countryId = 0)
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
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
			List<CRMspSelectCompanyProvince_Result> list2 = Enumerable.ToList<CRMspSelectCompanyProvince_Result>((IEnumerable<CRMspSelectCompanyProvince_Result>)_db.CRMspSelectCompanyProvince(UserLogin.CurrentUser.UserId, countryId, lCID, result, result2));
			list.AddRange(Enumerable.Select<CRMspSelectCompanyProvince_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyProvince_Result>)list2, (Func<CRMspSelectCompanyProvince_Result, SelectListItem>)((CRMspSelectCompanyProvince_Result item) => new SelectListItem
			{
				Text = item.Province,
				Value = item.ProvinceID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return JsonConvert.SerializeObject(list);
	}

	[HttpPost]
	[LoginAuthorize]
	public string SelectCity(int provinceId = 0)
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
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
			List<CRMspSelectCompanyCity_Result> list2 = Enumerable.ToList<CRMspSelectCompanyCity_Result>((IEnumerable<CRMspSelectCompanyCity_Result>)_db.CRMspSelectCompanyCity(UserLogin.CurrentUser.UserId, provinceId, lCID, result, result2));
			list.AddRange(Enumerable.Select<CRMspSelectCompanyCity_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyCity_Result>)list2, (Func<CRMspSelectCompanyCity_Result, SelectListItem>)((CRMspSelectCompanyCity_Result item) => new SelectListItem
			{
				Text = item.City,
				Value = item.CityID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return JsonConvert.SerializeObject(list);
	}

	[HttpPost]
	[LoginAuthorize]
	public string SelectFirstGroup()
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
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
			List<CRMspSelectCompanyGroup_Result> list2 = Enumerable.ToList<CRMspSelectCompanyGroup_Result>((IEnumerable<CRMspSelectCompanyGroup_Result>)_db.CRMspSelectCompanyGroup(UserLogin.CurrentUser.UserId, lCID, result, result2));
			list.AddRange(Enumerable.Select<CRMspSelectCompanyGroup_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyGroup_Result>)list2, (Func<CRMspSelectCompanyGroup_Result, SelectListItem>)((CRMspSelectCompanyGroup_Result item) => new SelectListItem
			{
				Text = item.GroupName,
				Value = item.CompanyGroupID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return JsonConvert.SerializeObject(list);
	}

	[HttpPost]
	[LoginAuthorize]
	public string SelectSubGroup(int firstGroupId = 0)
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
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
			List<CRMspSelectCompanySubGroup_Result> list2 = Enumerable.ToList<CRMspSelectCompanySubGroup_Result>((IEnumerable<CRMspSelectCompanySubGroup_Result>)_db.CRMspSelectCompanySubGroup(UserLogin.CurrentUser.UserId, firstGroupId, lCID, result, result2));
			list.AddRange(Enumerable.Select<CRMspSelectCompanySubGroup_Result, SelectListItem>((IEnumerable<CRMspSelectCompanySubGroup_Result>)list2, (Func<CRMspSelectCompanySubGroup_Result, SelectListItem>)((CRMspSelectCompanySubGroup_Result item) => new SelectListItem
			{
				Text = item.SubGroupName,
				Value = item.CompanySubGroupID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return JsonConvert.SerializeObject(list);
	}

	[HttpPost]
	[LoginAuthorize]
	public string SelectGroupII()
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspSelectCompanyGroupsII_Result> list2 = Enumerable.ToList<CRMspSelectCompanyGroupsII_Result>((IEnumerable<CRMspSelectCompanyGroupsII_Result>)_db.CRMspSelectCompanyGroupsII(lCID, result));
			list.AddRange(Enumerable.Select<CRMspSelectCompanyGroupsII_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyGroupsII_Result>)list2, (Func<CRMspSelectCompanyGroupsII_Result, SelectListItem>)((CRMspSelectCompanyGroupsII_Result item) => new SelectListItem
			{
				Text = item.GroupIIName,
				Value = item.CompanyGroupIIID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return JsonConvert.SerializeObject(list);
	}

	[HttpPost]
	[LoginAuthorize]
	public string SelectGroupIII()
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspSelectCompanyGroupsIII_Result> list2 = Enumerable.ToList<CRMspSelectCompanyGroupsIII_Result>((IEnumerable<CRMspSelectCompanyGroupsIII_Result>)_db.CRMspSelectCompanyGroupsIII(lCID, result));
			list.AddRange(Enumerable.Select<CRMspSelectCompanyGroupsIII_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyGroupsIII_Result>)list2, (Func<CRMspSelectCompanyGroupsIII_Result, SelectListItem>)((CRMspSelectCompanyGroupsIII_Result item) => new SelectListItem
			{
				Text = item.GroupIIIName,
				Value = item.CompanyGroupIIIID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return JsonConvert.SerializeObject(list);
	}

	[HttpPost]
	[LoginAuthorize]
	public string SelectGroupIV()
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
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
			List<CRMspSelectCompanyGroupsIV_Result> list2 = Enumerable.ToList<CRMspSelectCompanyGroupsIV_Result>((IEnumerable<CRMspSelectCompanyGroupsIV_Result>)_db.CRMspSelectCompanyGroupsIV(UserLogin.CurrentUser.UserId, lCID, result, result2));
			list.AddRange(Enumerable.Select<CRMspSelectCompanyGroupsIV_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyGroupsIV_Result>)list2, (Func<CRMspSelectCompanyGroupsIV_Result, SelectListItem>)((CRMspSelectCompanyGroupsIV_Result item) => new SelectListItem
			{
				Text = item.GroupIVName,
				Value = item.CompanyGroupIVID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return JsonConvert.SerializeObject(list);
	}

	[HttpPost]
	[LoginAuthorize]
	public string SelectReferUser()
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
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
			List<CRMspSelectCompanyReferUsers_Result> list2 = Enumerable.ToList<CRMspSelectCompanyReferUsers_Result>((IEnumerable<CRMspSelectCompanyReferUsers_Result>)_db.CRMspSelectCompanyReferUsers(UserLogin.CurrentUser.UserId, lCID, result, result2));
			list.AddRange(Enumerable.Select<CRMspSelectCompanyReferUsers_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyReferUsers_Result>)list2, (Func<CRMspSelectCompanyReferUsers_Result, SelectListItem>)((CRMspSelectCompanyReferUsers_Result item) => new SelectListItem
			{
				Text = item.USER,
				Value = item.UserId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return JsonConvert.SerializeObject(list);
	}

	[HttpPost]
	[LoginAuthorize]
	public string SelectLinkAccSettingDBAllHelp()
	{
		return JsonConvert.SerializeObject(Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectLinkAccSettingDBAll_Result, SelectListItem>((IEnumerable<CRMspSelectLinkAccSettingDBAll_Result>)CRMIdeal.Classes.Helper.OtherSystems.SelectLinkAccSettingDBAll(), (Func<CRMspSelectLinkAccSettingDBAll_Result, SelectListItem>)((CRMspSelectLinkAccSettingDBAll_Result x) => new SelectListItem
		{
			Text = x.LinkAccSettingDbTitle + " ( " + x.LinkAccSettingDBId + " ) ",
			Value = x.LinkAccSettingDBId.ToString()
		}))));
	}

	[HttpPost]
	[LoginAuthorize]
	public string SelectPrsJobs()
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspSelectPersonJobs_Result> list2 = Enumerable.ToList<CRMspSelectPersonJobs_Result>((IEnumerable<CRMspSelectPersonJobs_Result>)_db.CRMspSelectPersonJobs(lCID, result));
			list.AddRange(Enumerable.Select<CRMspSelectPersonJobs_Result, SelectListItem>((IEnumerable<CRMspSelectPersonJobs_Result>)list2, (Func<CRMspSelectPersonJobs_Result, SelectListItem>)((CRMspSelectPersonJobs_Result item) => new SelectListItem
			{
				Text = item.Jobs,
				Value = item.PersonJobID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return JsonConvert.SerializeObject(list);
	}

	[HttpPost]
	[LoginAuthorize]
	public string SelectPrsDepartmants()
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspSelectPersonDepartments_Result> list2 = Enumerable.ToList<CRMspSelectPersonDepartments_Result>((IEnumerable<CRMspSelectPersonDepartments_Result>)_db.CRMspSelectPersonDepartments(lCID, result));
			list.AddRange(Enumerable.Select<CRMspSelectPersonDepartments_Result, SelectListItem>((IEnumerable<CRMspSelectPersonDepartments_Result>)list2, (Func<CRMspSelectPersonDepartments_Result, SelectListItem>)((CRMspSelectPersonDepartments_Result item) => new SelectListItem
			{
				Text = item.PersonDepartment,
				Value = item.PersonDepartmentId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return JsonConvert.SerializeObject(list);
	}

	[HttpPost]
	[LoginAuthorize]
	public string SelectCnvsStatusGroup()
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspSelectActiveConversationStatusGroups_Result> list2 = Enumerable.ToList<CRMspSelectActiveConversationStatusGroups_Result>((IEnumerable<CRMspSelectActiveConversationStatusGroups_Result>)_dbI.CRMspSelectActiveConversationStatusGroups(lCID, result));
			list.AddRange(Enumerable.Select<CRMspSelectActiveConversationStatusGroups_Result, SelectListItem>((IEnumerable<CRMspSelectActiveConversationStatusGroups_Result>)list2, (Func<CRMspSelectActiveConversationStatusGroups_Result, SelectListItem>)((CRMspSelectActiveConversationStatusGroups_Result item) => new SelectListItem
			{
				Text = item.ConversationStatusGroup,
				Value = item.ConversationStatusGroupID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return JsonConvert.SerializeObject(list);
	}

	[HttpPost]
	[LoginAuthorize]
	public string SelectPrjGroups()
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspSelectProjectGroups_Result> list2 = Enumerable.ToList<CRMspSelectProjectGroups_Result>((IEnumerable<CRMspSelectProjectGroups_Result>)_db.CRMspSelectProjectGroups(lCID, result));
			list.AddRange(Enumerable.Select<CRMspSelectProjectGroups_Result, SelectListItem>((IEnumerable<CRMspSelectProjectGroups_Result>)list2, (Func<CRMspSelectProjectGroups_Result, SelectListItem>)((CRMspSelectProjectGroups_Result item) => new SelectListItem
			{
				Text = item.ProjectGroup,
				Value = item.ProjectGroupID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return JsonConvert.SerializeObject(list);
	}

	[HttpPost]
	[LoginAuthorize]
	public string SelectPrjGrade()
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspSelectProjectGrade_Result> list2 = Enumerable.ToList<CRMspSelectProjectGrade_Result>((IEnumerable<CRMspSelectProjectGrade_Result>)_db.CRMspSelectProjectGrade(lCID, result));
			list.AddRange(Enumerable.Select<CRMspSelectProjectGrade_Result, SelectListItem>((IEnumerable<CRMspSelectProjectGrade_Result>)list2, (Func<CRMspSelectProjectGrade_Result, SelectListItem>)((CRMspSelectProjectGrade_Result item) => new SelectListItem
			{
				Text = item.ProjectGrade,
				Value = item.ProjectGradeID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return JsonConvert.SerializeObject(list);
	}

	[HttpPost]
	[LoginAuthorize]
	public string SelectPrjPriority()
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspSelectProjectPriority_Result> list2 = Enumerable.ToList<CRMspSelectProjectPriority_Result>((IEnumerable<CRMspSelectProjectPriority_Result>)_db.CRMspSelectProjectPriority(lCID, result));
			list.AddRange(Enumerable.Select<CRMspSelectProjectPriority_Result, SelectListItem>((IEnumerable<CRMspSelectProjectPriority_Result>)list2, (Func<CRMspSelectProjectPriority_Result, SelectListItem>)((CRMspSelectProjectPriority_Result item) => new SelectListItem
			{
				Text = item.Priority,
				Value = item.ProjectPriorityID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return JsonConvert.SerializeObject(list);
	}

	[HttpPost]
	[LoginAuthorize]
	public string SelectPrjStartUser()
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
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
			List<CRMspSelectUserForLinkedType_Result> list2 = Enumerable.ToList<CRMspSelectUserForLinkedType_Result>((IEnumerable<CRMspSelectUserForLinkedType_Result>)_db.CRMspSelectUserForLinkedType(UserLogin.CurrentUser.UserId, 11, lCID, result, result2));
			list.AddRange(Enumerable.Select<CRMspSelectUserForLinkedType_Result, SelectListItem>((IEnumerable<CRMspSelectUserForLinkedType_Result>)list2, (Func<CRMspSelectUserForLinkedType_Result, SelectListItem>)((CRMspSelectUserForLinkedType_Result item) => new SelectListItem
			{
				Text = item.UserName,
				Value = item.LinkedUserId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return JsonConvert.SerializeObject(list);
	}

	[HttpPost]
	[LoginAuthorize]
	public string SelectCnvsStatus(int groupId = 0)
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspSelectActiveConversationStatus_Result> list2 = Enumerable.ToList<CRMspSelectActiveConversationStatus_Result>((IEnumerable<CRMspSelectActiveConversationStatus_Result>)_dbI.CRMspSelectActiveConversationStatus(groupId, lCID, result));
			list.AddRange(Enumerable.Select<CRMspSelectActiveConversationStatus_Result, SelectListItem>((IEnumerable<CRMspSelectActiveConversationStatus_Result>)list2, (Func<CRMspSelectActiveConversationStatus_Result, SelectListItem>)((CRMspSelectActiveConversationStatus_Result item) => new SelectListItem
			{
				Text = item.Status,
				Value = item.ConversationStatusID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return JsonConvert.SerializeObject(list);
	}

	[HttpPost]
	[LoginAuthorize]
	public string SelectCnvsTopic()
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspSelectConversationTopics_Result> list2 = Enumerable.ToList<CRMspSelectConversationTopics_Result>((IEnumerable<CRMspSelectConversationTopics_Result>)_db.CRMspSelectConversationTopics(lCID, result));
			list.AddRange(Enumerable.Select<CRMspSelectConversationTopics_Result, SelectListItem>((IEnumerable<CRMspSelectConversationTopics_Result>)list2, (Func<CRMspSelectConversationTopics_Result, SelectListItem>)((CRMspSelectConversationTopics_Result item) => new SelectListItem
			{
				Text = item.Topic,
				Value = item.ConversationTopicsID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return JsonConvert.SerializeObject(list);
	}

	[HttpPost]
	[LoginAuthorize]
	public string SelectCnvsUsers()
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
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
			List<CRMspSelectUserForLinkedType_Result> list2 = Enumerable.ToList<CRMspSelectUserForLinkedType_Result>((IEnumerable<CRMspSelectUserForLinkedType_Result>)_db.CRMspSelectUserForLinkedType(UserLogin.CurrentUser.UserId, 8, lCID, result, result2));
			list.AddRange(Enumerable.Select<CRMspSelectUserForLinkedType_Result, SelectListItem>((IEnumerable<CRMspSelectUserForLinkedType_Result>)list2, (Func<CRMspSelectUserForLinkedType_Result, SelectListItem>)((CRMspSelectUserForLinkedType_Result item) => new SelectListItem
			{
				Text = item.UserName,
				Value = item.LinkedUserId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return JsonConvert.SerializeObject(list);
	}

	[HttpPost]
	[LoginAuthorize]
	public string SelectCnvsReferUsers()
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
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
			List<CRMspSelectUserForLinkedType_Result> list2 = Enumerable.ToList<CRMspSelectUserForLinkedType_Result>((IEnumerable<CRMspSelectUserForLinkedType_Result>)_db.CRMspSelectUserForLinkedType(UserLogin.CurrentUser.UserId, 7, lCID, result, result2));
			list.AddRange(Enumerable.Select<CRMspSelectUserForLinkedType_Result, SelectListItem>((IEnumerable<CRMspSelectUserForLinkedType_Result>)list2, (Func<CRMspSelectUserForLinkedType_Result, SelectListItem>)((CRMspSelectUserForLinkedType_Result item) => new SelectListItem
			{
				Text = item.UserName,
				Value = item.LinkedUserId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return JsonConvert.SerializeObject(list);
	}

	[HttpPost]
	[LoginAuthorize]
	public string SelectCnvsPriority()
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspSelectConversationPriority_Result> list2 = Enumerable.ToList<CRMspSelectConversationPriority_Result>((IEnumerable<CRMspSelectConversationPriority_Result>)_db.CRMspSelectConversationPriority(lCID, result));
			list.AddRange(Enumerable.Select<CRMspSelectConversationPriority_Result, SelectListItem>((IEnumerable<CRMspSelectConversationPriority_Result>)list2, (Func<CRMspSelectConversationPriority_Result, SelectListItem>)((CRMspSelectConversationPriority_Result item) => new SelectListItem
			{
				Text = item.Priority,
				Value = item.ConversationPriorityID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return JsonConvert.SerializeObject(list);
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetCmpTitleHelpList()
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspSelectCompanyTitle_Result> list2 = Enumerable.ToList<CRMspSelectCompanyTitle_Result>((IEnumerable<CRMspSelectCompanyTitle_Result>)_db.CRMspSelectCompanyTitle(lCID, result));
			list.AddRange(Enumerable.Select<CRMspSelectCompanyTitle_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyTitle_Result>)list2, (Func<CRMspSelectCompanyTitle_Result, SelectListItem>)((CRMspSelectCompanyTitle_Result item) => new SelectListItem
			{
				Text = item.CompanyTitle + " ( " + item.CompanyTitleID + " )",
				Value = item.CompanyTitleID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return JsonConvert.SerializeObject(list);
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetCmpPresentationHelpList()
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspSelectCompanyPresentation_Result> list2 = Enumerable.ToList<CRMspSelectCompanyPresentation_Result>((IEnumerable<CRMspSelectCompanyPresentation_Result>)_db.CRMspSelectCompanyPresentation(lCID, result));
			list.AddRange(Enumerable.Select<CRMspSelectCompanyPresentation_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyPresentation_Result>)list2, (Func<CRMspSelectCompanyPresentation_Result, SelectListItem>)((CRMspSelectCompanyPresentation_Result item) => new SelectListItem
			{
				Text = item.Presentation + " ( " + item.CompanyPresentationID + " )",
				Value = item.CompanyPresentationID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return JsonConvert.SerializeObject(list);
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetCmpTypeHelpList()
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspSelectCompanyType_Result> list2 = Enumerable.ToList<CRMspSelectCompanyType_Result>((IEnumerable<CRMspSelectCompanyType_Result>)_db.CRMspSelectCompanyType(lCID, result));
			list.AddRange(Enumerable.Select<CRMspSelectCompanyType_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyType_Result>)list2, (Func<CRMspSelectCompanyType_Result, SelectListItem>)((CRMspSelectCompanyType_Result item) => new SelectListItem
			{
				Text = item.CompanyTypeName + " ( " + item.CompanyTypeID + " )",
				Value = item.CompanyTypeID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return JsonConvert.SerializeObject(list);
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetCountryHelpList()
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspSelectCountry_Result> list2 = Enumerable.ToList<CRMspSelectCountry_Result>((IEnumerable<CRMspSelectCountry_Result>)_db.CRMspSelectCountry(lCID, result));
			list.AddRange(Enumerable.Select<CRMspSelectCountry_Result, SelectListItem>((IEnumerable<CRMspSelectCountry_Result>)list2, (Func<CRMspSelectCountry_Result, SelectListItem>)((CRMspSelectCountry_Result item) => new SelectListItem
			{
				Text = item.Country + " ( " + item.CountryID + " )",
				Value = item.CountryID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return JsonConvert.SerializeObject(list);
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetProvinceHelpList(int countryId = 0)
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
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
			List<CRMspSelectCompanyProvince_Result> list2 = Enumerable.ToList<CRMspSelectCompanyProvince_Result>((IEnumerable<CRMspSelectCompanyProvince_Result>)_db.CRMspSelectCompanyProvince(UserLogin.CurrentUser.UserId, countryId, lCID, result, result2));
			list.AddRange(Enumerable.Select<CRMspSelectCompanyProvince_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyProvince_Result>)list2, (Func<CRMspSelectCompanyProvince_Result, SelectListItem>)((CRMspSelectCompanyProvince_Result item) => new SelectListItem
			{
				Text = item.Province + " ( " + item.ProvinceID + " )",
				Value = item.ProvinceID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return JsonConvert.SerializeObject(list);
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetCityHelpList(int provinceId = 0)
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
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
			List<CRMspSelectCompanyCity_Result> list2 = Enumerable.ToList<CRMspSelectCompanyCity_Result>((IEnumerable<CRMspSelectCompanyCity_Result>)_db.CRMspSelectCompanyCity(UserLogin.CurrentUser.UserId, provinceId, lCID, result, result2));
			list.AddRange(Enumerable.Select<CRMspSelectCompanyCity_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyCity_Result>)list2, (Func<CRMspSelectCompanyCity_Result, SelectListItem>)((CRMspSelectCompanyCity_Result item) => new SelectListItem
			{
				Text = item.City + " ( " + item.CityID + " )",
				Value = item.CityID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return JsonConvert.SerializeObject(list);
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetGroupHelpList()
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
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
			List<CRMspSelectCompanyGroup_Result> list2 = Enumerable.ToList<CRMspSelectCompanyGroup_Result>((IEnumerable<CRMspSelectCompanyGroup_Result>)_db.CRMspSelectCompanyGroup(UserLogin.CurrentUser.UserId, lCID, result, result2));
			list.AddRange(Enumerable.Select<CRMspSelectCompanyGroup_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyGroup_Result>)list2, (Func<CRMspSelectCompanyGroup_Result, SelectListItem>)((CRMspSelectCompanyGroup_Result item) => new SelectListItem
			{
				Text = item.GroupName + " ( " + item.CompanyGroupID + " )",
				Value = item.CompanyGroupID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return JsonConvert.SerializeObject(list);
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetSubGroupHelpList(int groupId = 0)
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
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
			List<CRMspSelectCompanySubGroup_Result> list2 = Enumerable.ToList<CRMspSelectCompanySubGroup_Result>((IEnumerable<CRMspSelectCompanySubGroup_Result>)_db.CRMspSelectCompanySubGroup(UserLogin.CurrentUser.UserId, groupId, lCID, result, result2));
			list.AddRange(Enumerable.Select<CRMspSelectCompanySubGroup_Result, SelectListItem>((IEnumerable<CRMspSelectCompanySubGroup_Result>)list2, (Func<CRMspSelectCompanySubGroup_Result, SelectListItem>)((CRMspSelectCompanySubGroup_Result item) => new SelectListItem
			{
				Text = item.SubGroupName + " ( " + item.CompanySubGroupID + " )",
				Value = item.CompanySubGroupID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return JsonConvert.SerializeObject(list);
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetGroupIIHelpList()
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspSelectCompanyGroupsII_Result> list2 = Enumerable.ToList<CRMspSelectCompanyGroupsII_Result>((IEnumerable<CRMspSelectCompanyGroupsII_Result>)_db.CRMspSelectCompanyGroupsII(lCID, result));
			list.AddRange(Enumerable.Select<CRMspSelectCompanyGroupsII_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyGroupsII_Result>)list2, (Func<CRMspSelectCompanyGroupsII_Result, SelectListItem>)((CRMspSelectCompanyGroupsII_Result item) => new SelectListItem
			{
				Text = item.GroupIIName + " ( " + item.CompanyGroupIIID + " )",
				Value = item.CompanyGroupIIID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return JsonConvert.SerializeObject(list);
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetGroupIIIHelpList()
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspSelectCompanyGroupsIII_Result> list2 = Enumerable.ToList<CRMspSelectCompanyGroupsIII_Result>((IEnumerable<CRMspSelectCompanyGroupsIII_Result>)_db.CRMspSelectCompanyGroupsIII(lCID, result));
			list.AddRange(Enumerable.Select<CRMspSelectCompanyGroupsIII_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyGroupsIII_Result>)list2, (Func<CRMspSelectCompanyGroupsIII_Result, SelectListItem>)((CRMspSelectCompanyGroupsIII_Result item) => new SelectListItem
			{
				Text = item.GroupIIIName + " ( " + item.CompanyGroupIIIID + " )",
				Value = item.CompanyGroupIIIID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return JsonConvert.SerializeObject(list);
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetGroupIVHelpList()
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
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
			List<CRMspSelectCompanyGroupsIV_Result> list2 = Enumerable.ToList<CRMspSelectCompanyGroupsIV_Result>((IEnumerable<CRMspSelectCompanyGroupsIV_Result>)_db.CRMspSelectCompanyGroupsIV(UserLogin.CurrentUser.UserId, lCID, result, result2));
			list.AddRange(Enumerable.Select<CRMspSelectCompanyGroupsIV_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyGroupsIV_Result>)list2, (Func<CRMspSelectCompanyGroupsIV_Result, SelectListItem>)((CRMspSelectCompanyGroupsIV_Result item) => new SelectListItem
			{
				Text = item.GroupIVName + " ( " + item.CompanyGroupIVID + " )",
				Value = item.CompanyGroupIVID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return JsonConvert.SerializeObject(list);
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetReferUserHelpList()
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
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
			List<CRMspSelectCompanyReferUsers_Result> list2 = Enumerable.ToList<CRMspSelectCompanyReferUsers_Result>((IEnumerable<CRMspSelectCompanyReferUsers_Result>)_db.CRMspSelectCompanyReferUsers(UserLogin.CurrentUser.UserId, lCID, result, result2));
			list.AddRange(Enumerable.Select<CRMspSelectCompanyReferUsers_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyReferUsers_Result>)list2, (Func<CRMspSelectCompanyReferUsers_Result, SelectListItem>)((CRMspSelectCompanyReferUsers_Result item) => new SelectListItem
			{
				Text = item.USER + " ( " + item.UserId + " )",
				Value = item.UserId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return JsonConvert.SerializeObject(list);
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetPrsJobsHelpList()
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspSelectPersonJobs_Result> list2 = Enumerable.ToList<CRMspSelectPersonJobs_Result>((IEnumerable<CRMspSelectPersonJobs_Result>)_db.CRMspSelectPersonJobs(lCID, result));
			list.AddRange(Enumerable.Select<CRMspSelectPersonJobs_Result, SelectListItem>((IEnumerable<CRMspSelectPersonJobs_Result>)list2, (Func<CRMspSelectPersonJobs_Result, SelectListItem>)((CRMspSelectPersonJobs_Result item) => new SelectListItem
			{
				Text = item.Jobs + " ( " + item.PersonJobID + " )",
				Value = item.PersonJobID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return JsonConvert.SerializeObject(list);
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetPrsDepartmentsHelpList()
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspSelectPersonDepartments_Result> list2 = Enumerable.ToList<CRMspSelectPersonDepartments_Result>((IEnumerable<CRMspSelectPersonDepartments_Result>)_db.CRMspSelectPersonDepartments(lCID, result));
			list.AddRange(Enumerable.Select<CRMspSelectPersonDepartments_Result, SelectListItem>((IEnumerable<CRMspSelectPersonDepartments_Result>)list2, (Func<CRMspSelectPersonDepartments_Result, SelectListItem>)((CRMspSelectPersonDepartments_Result item) => new SelectListItem
			{
				Text = item.PersonDepartment + " ( " + item.PersonDepartmentId + " )",
				Value = item.PersonDepartmentId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return JsonConvert.SerializeObject(list);
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetCnvsStatusGroupHelpList()
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspSelectActiveConversationStatusGroups_Result> list2 = Enumerable.ToList<CRMspSelectActiveConversationStatusGroups_Result>((IEnumerable<CRMspSelectActiveConversationStatusGroups_Result>)_dbI.CRMspSelectActiveConversationStatusGroups(lCID, result));
			list.AddRange(Enumerable.Select<CRMspSelectActiveConversationStatusGroups_Result, SelectListItem>((IEnumerable<CRMspSelectActiveConversationStatusGroups_Result>)list2, (Func<CRMspSelectActiveConversationStatusGroups_Result, SelectListItem>)((CRMspSelectActiveConversationStatusGroups_Result item) => new SelectListItem
			{
				Text = item.ConversationStatusGroup + " ( " + item.ConversationStatusGroupID + " )",
				Value = item.ConversationStatusGroupID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return JsonConvert.SerializeObject(list);
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetPrjGroupsHelpList()
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspSelectProjectGroups_Result> list2 = Enumerable.ToList<CRMspSelectProjectGroups_Result>((IEnumerable<CRMspSelectProjectGroups_Result>)_db.CRMspSelectProjectGroups(lCID, result));
			list.AddRange(Enumerable.Select<CRMspSelectProjectGroups_Result, SelectListItem>((IEnumerable<CRMspSelectProjectGroups_Result>)list2, (Func<CRMspSelectProjectGroups_Result, SelectListItem>)((CRMspSelectProjectGroups_Result item) => new SelectListItem
			{
				Text = item.ProjectGroup + " ( " + item.ProjectGroupID + " )",
				Value = item.ProjectGroupID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return JsonConvert.SerializeObject(list);
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetPrjGradeHelpList()
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspSelectProjectGrade_Result> list2 = Enumerable.ToList<CRMspSelectProjectGrade_Result>((IEnumerable<CRMspSelectProjectGrade_Result>)_db.CRMspSelectProjectGrade(lCID, result));
			list.AddRange(Enumerable.Select<CRMspSelectProjectGrade_Result, SelectListItem>((IEnumerable<CRMspSelectProjectGrade_Result>)list2, (Func<CRMspSelectProjectGrade_Result, SelectListItem>)((CRMspSelectProjectGrade_Result item) => new SelectListItem
			{
				Text = item.ProjectGrade + " ( " + item.ProjectGradeID + " )",
				Value = item.ProjectGradeID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return JsonConvert.SerializeObject(list);
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetPrjPriorityHelpList()
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspSelectProjectPriority_Result> list2 = Enumerable.ToList<CRMspSelectProjectPriority_Result>((IEnumerable<CRMspSelectProjectPriority_Result>)_db.CRMspSelectProjectPriority(lCID, result));
			list.AddRange(Enumerable.Select<CRMspSelectProjectPriority_Result, SelectListItem>((IEnumerable<CRMspSelectProjectPriority_Result>)list2, (Func<CRMspSelectProjectPriority_Result, SelectListItem>)((CRMspSelectProjectPriority_Result item) => new SelectListItem
			{
				Text = item.Priority + " ( " + item.ProjectPriorityID + " )",
				Value = item.ProjectPriorityID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return JsonConvert.SerializeObject(list);
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetPrjStarterUserHelpList()
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
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
			List<CRMspSelectUserForLinkedType_Result> list2 = Enumerable.ToList<CRMspSelectUserForLinkedType_Result>((IEnumerable<CRMspSelectUserForLinkedType_Result>)_db.CRMspSelectUserForLinkedType(UserLogin.CurrentUser.UserId, 11, lCID, result, result2));
			list.AddRange(Enumerable.Select<CRMspSelectUserForLinkedType_Result, SelectListItem>((IEnumerable<CRMspSelectUserForLinkedType_Result>)list2, (Func<CRMspSelectUserForLinkedType_Result, SelectListItem>)((CRMspSelectUserForLinkedType_Result item) => new SelectListItem
			{
				Text = item.UserName + " ( " + item.LinkedUserId + " )",
				Value = item.LinkedUserId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return JsonConvert.SerializeObject(list);
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetCnvsTopicHelpList()
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspSelectConversationTopics_Result> list2 = Enumerable.ToList<CRMspSelectConversationTopics_Result>((IEnumerable<CRMspSelectConversationTopics_Result>)_db.CRMspSelectConversationTopics(lCID, result));
			list.AddRange(Enumerable.Select<CRMspSelectConversationTopics_Result, SelectListItem>((IEnumerable<CRMspSelectConversationTopics_Result>)list2, (Func<CRMspSelectConversationTopics_Result, SelectListItem>)((CRMspSelectConversationTopics_Result item) => new SelectListItem
			{
				Text = item.Topic + " ( " + item.ConversationTopicsID + " )",
				Value = item.ConversationTopicsID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return JsonConvert.SerializeObject(list);
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetCnvsUsersHelpList()
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
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
			List<CRMspSelectUserForLinkedType_Result> list2 = Enumerable.ToList<CRMspSelectUserForLinkedType_Result>((IEnumerable<CRMspSelectUserForLinkedType_Result>)_db.CRMspSelectUserForLinkedType(UserLogin.CurrentUser.UserId, 8, lCID, result, result2));
			list.AddRange(Enumerable.Select<CRMspSelectUserForLinkedType_Result, SelectListItem>((IEnumerable<CRMspSelectUserForLinkedType_Result>)list2, (Func<CRMspSelectUserForLinkedType_Result, SelectListItem>)((CRMspSelectUserForLinkedType_Result item) => new SelectListItem
			{
				Text = item.UserName + " ( " + item.LinkedUserId + " )",
				Value = item.LinkedUserId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return JsonConvert.SerializeObject(list);
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetCnvsReferUsersHelpList()
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
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
			List<CRMspSelectUserForLinkedType_Result> list2 = Enumerable.ToList<CRMspSelectUserForLinkedType_Result>((IEnumerable<CRMspSelectUserForLinkedType_Result>)_db.CRMspSelectUserForLinkedType(UserLogin.CurrentUser.UserId, 7, lCID, result, result2));
			list.AddRange(Enumerable.Select<CRMspSelectUserForLinkedType_Result, SelectListItem>((IEnumerable<CRMspSelectUserForLinkedType_Result>)list2, (Func<CRMspSelectUserForLinkedType_Result, SelectListItem>)((CRMspSelectUserForLinkedType_Result item) => new SelectListItem
			{
				Text = item.UserName + " ( " + item.LinkedUserId + " )",
				Value = item.LinkedUserId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return JsonConvert.SerializeObject(list);
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetCnvsPriorityHelpList()
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspSelectConversationPriority_Result> list2 = Enumerable.ToList<CRMspSelectConversationPriority_Result>((IEnumerable<CRMspSelectConversationPriority_Result>)_db.CRMspSelectConversationPriority(lCID, result));
			list.AddRange(Enumerable.Select<CRMspSelectConversationPriority_Result, SelectListItem>((IEnumerable<CRMspSelectConversationPriority_Result>)list2, (Func<CRMspSelectConversationPriority_Result, SelectListItem>)((CRMspSelectConversationPriority_Result item) => new SelectListItem
			{
				Text = item.Priority + " ( " + item.ConversationPriorityID + " )",
				Value = item.ConversationPriorityID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return JsonConvert.SerializeObject(list);
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetCnvsStatusHelpList(int groupId = 0)
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspSelectActiveConversationStatus_Result> list2 = Enumerable.ToList<CRMspSelectActiveConversationStatus_Result>((IEnumerable<CRMspSelectActiveConversationStatus_Result>)_dbI.CRMspSelectActiveConversationStatus(groupId, lCID, result));
			list.AddRange(Enumerable.Select<CRMspSelectActiveConversationStatus_Result, SelectListItem>((IEnumerable<CRMspSelectActiveConversationStatus_Result>)list2, (Func<CRMspSelectActiveConversationStatus_Result, SelectListItem>)((CRMspSelectActiveConversationStatus_Result item) => new SelectListItem
			{
				Text = item.Status + " ( " + item.ConversationStatusID + " )",
				Value = item.ConversationStatusID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return JsonConvert.SerializeObject(list);
	}
}
