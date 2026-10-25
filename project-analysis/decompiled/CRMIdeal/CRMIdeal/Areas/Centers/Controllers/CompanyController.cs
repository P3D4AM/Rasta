using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.Classes.Helper;
using CRMIdeal.GSD.Globalization;
using Elmah;

namespace CRMIdeal.Areas.Centers.Controllers;

public class CompanyController : Controller
{
	private CRMSpEntities _db = new CRMSpEntities();

	private CRMSpIIEntities _dbII = new CRMSpIIEntities();

	[DynamicAuthorize(ControllerName = "frmCompanyI", ActionName = "actManageCenterCompany")]
	public ActionResult ManageCenterCompany(int cmpId)
	{
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		List<CommonFoInfoByNameViewModel> list = new List<CommonFoInfoByNameViewModel>();
		try
		{
			string cmpFoInfoJsonByCmpId = CRMIdeal.Classes.Helper.Company.GetCmpFoInfoJsonByCmpId(cmpId);
			if (!string.IsNullOrWhiteSpace(cmpFoInfoJsonByCmpId))
			{
				list = new JavaScriptSerializer().Deserialize<List<CommonFoInfoByNameViewModel>>(cmpFoInfoJsonByCmpId);
			}
			if (list == null)
			{
				list = new List<CommonFoInfoByNameViewModel>();
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		base.ViewBag.CompanyCenterList = list;
		base.ViewBag.CompanyId = cmpId;
		CRMspSelectCompanyById_Result companyById = CRMIdeal.Classes.Helper.Company.GetCompanyById(cmpId);
		base.ViewBag.CompanyInfo = companyById;
		return View();
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmCompanyI", ActionName = "actManageCenterCompany")]
	public string UpdateCompanyFOInfoAndCIds(int cmpId, string cIds, string foinfoJson)
	{
		string text = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			int userId = UserLogin.CurrentUser.UserId;
			short value2 = short.Parse(Financial.Get().Id.ToString());
			short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			_ = Financial.Get().Id;
			if (cmpId != 0)
			{
				CRMspSelectCompanyById_Result companyById = CRMIdeal.Classes.Helper.Company.GetCompanyById(cmpId);
				if (companyById != null)
				{
					_ = companyById.cmpCIds;
					string oldFoInfo = companyById.cmpFOInfo ?? "";
					bool haveEroroFoCnt = false;
					string foInfoJson = CRMIdeal.Classes.Helper.Company.GetFoInfoJson(foinfoJson, oldFoInfo, cIds, ref haveEroroFoCnt, 0, 0, isCmp: true);
					if (haveEroroFoCnt)
					{
						int maxFOCount = Configuration.MaxFOCount;
						text = text + string.Format(Messages.msgErrorSaveCmpFOIsActiveMoreThanMaxCount, maxFOCount.ToString()) + "<br>";
					}
					if (string.IsNullOrWhiteSpace(text))
					{
						_dbII.CRMspUpdateCompanyFOInfoAndCIds(cmpId, cIds, foInfoJson, userId, value3, value2, value, registerDatePersian, appType);
						string errorMsg = "";
						if (!CRMIdeal.Classes.Helper.Company.SendCmpToLinkAccByShpIsActive(cmpId, ref errorMsg))
						{
							int result2 = 0;
							string text2 = "";
							CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
							if (cRMspSelectCrmsysSetting_Result != null)
							{
								int.TryParse(cRMspSelectCrmsysSetting_Result.LinkAccSystemId.ToString(), out result2);
							}
							text2 = CRMIdeal.Classes.Helper.Setting.GetLinkAccSystemTitle();
							text = Messages.msgSuccessAction + "<br>" + string.Format(Messages.msgErrorSendCmpToOtherSystem, text2) + "<br>" + errorMsg;
						}
					}
				}
				else
				{
					text = string.Format(Messages.msgErrorIsNotSelectedItem, Labels.lblCmp);
				}
			}
			else
			{
				text = string.Format(Messages.msgErrorIsNotSelectedItem, Labels.lblCmp);
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
			text = Messages.MsgErrorDoneOperation;
		}
		return text;
	}

	[DynamicAuthorize(ControllerName = "frmCompanyI", ActionName = "actManageCenterCompanyPerson")]
	public ActionResult ManageCenterCompanyPerson(int cmpId)
	{
		GetCmpPersons(cmpId);
		base.ViewBag.CompanyId = cmpId;
		return View();
	}

	public ActionResult _PartialCenterCompanyPerson(int prsId)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		List<CommonFoInfoByNameViewModel> list = new List<CommonFoInfoByNameViewModel>();
		try
		{
			string prsFoInfoJsonByCmpId = CRMIdeal.Classes.Helper.Company.GetPrsFoInfoJsonByCmpId(prsId);
			if (!string.IsNullOrWhiteSpace(prsFoInfoJsonByCmpId))
			{
				list = new JavaScriptSerializer().Deserialize<List<CommonFoInfoByNameViewModel>>(prsFoInfoJsonByCmpId);
			}
			if (list == null)
			{
				list = new List<CommonFoInfoByNameViewModel>();
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		base.ViewBag.PrsonCenterList = list;
		base.ViewBag.PersonId = prsId;
		return PartialView();
	}

	public void GetCmpPersons(int cmpId = 0)
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspSelectCompanyPersons_Result> list2 = CRMIdeal.Classes.Helper.Company.SelectCompanyPersons(cmpId);
			if (list2 != null && Enumerable.Any<CRMspSelectCompanyPersons_Result>((IEnumerable<CRMspSelectCompanyPersons_Result>)list2))
			{
				foreach (CRMspSelectCompanyPersons_Result item in list2)
				{
					list.Add(new SelectListItem
					{
						Text = item.PersonTitleName,
						Value = item.CompanyPersonID.ToString()
					});
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.PersonList = list;
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmCompanyI", ActionName = "actManageCenterCompanyPerson")]
	public string UpdateCompanyPersonFOInfoAndCIds(int prsId, string cIds, string foinfoJson)
	{
		string text = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			int userId = UserLogin.CurrentUser.UserId;
			short value2 = short.Parse(Financial.Get().Id.ToString());
			short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			_ = Financial.Get().Id;
			if (prsId != 0)
			{
				CRMspSelectCompanyPersonsByID_Result cRMspSelectCompanyPersonsByID_Result = Enumerable.FirstOrDefault<CRMspSelectCompanyPersonsByID_Result>((IEnumerable<CRMspSelectCompanyPersonsByID_Result>)_db.CRMspSelectCompanyPersonsByID(prsId, lCID, result));
				if (cRMspSelectCompanyPersonsByID_Result != null)
				{
					_ = cRMspSelectCompanyPersonsByID_Result.prsCIds;
					string oldFoInfo = cRMspSelectCompanyPersonsByID_Result.prsFOInfo ?? "";
					bool haveEroroFoCnt = false;
					string foInfoJson = CRMIdeal.Classes.Helper.Company.GetFoInfoJson(foinfoJson, oldFoInfo, cIds, ref haveEroroFoCnt);
					if (haveEroroFoCnt)
					{
						int maxFOCount = Configuration.MaxFOCount;
						text = text + string.Format(Messages.msgErrorSaveCmpFOIsActiveMoreThanMaxCount, maxFOCount.ToString()) + "<br>";
					}
					if (string.IsNullOrWhiteSpace(text))
					{
						_dbII.CRMspUpdateCompanyPersonFOInfoAndCIds(prsId, cIds, foInfoJson, userId, value3, value2, value, registerDatePersian, appType);
					}
				}
				else
				{
					text = string.Format(Messages.msgErrorIsNotSelectedItem, Labels.lblCmp);
				}
			}
			else
			{
				text = string.Format(Messages.msgErrorIsNotSelectedItem, Labels.lblCmp);
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
			text = Messages.MsgErrorDoneOperation;
		}
		return text;
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbII.Dispose();
		base.Dispose(disposing);
	}
}
