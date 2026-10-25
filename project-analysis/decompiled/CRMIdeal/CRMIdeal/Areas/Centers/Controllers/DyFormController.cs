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

public class DyFormController : Controller
{
	private CRMSpEntities _db = new CRMSpEntities();

	private CRMSpIEntities _dbI = new CRMSpIEntities();

	private CRMSpIIEntities _dbII = new CRMSpIIEntities();

	[DynamicAuthorize(ControllerName = "frmDyDefineForm", ActionName = "actManageCenterForm")]
	public ActionResult ManageCenterForm()
	{
		GetSystemParts();
		GetDyForm();
		return View();
	}

	public ActionResult _PartialCenterForm(int formId)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		List<FormCenterInfoJsByNameViewModel> list = new List<FormCenterInfoJsByNameViewModel>();
		try
		{
			string formCenterInfoJsByFormId = DyForm.GetFormCenterInfoJsByFormId(formId);
			if (!string.IsNullOrWhiteSpace(formCenterInfoJsByFormId))
			{
				list = new JavaScriptSerializer().Deserialize<List<FormCenterInfoJsByNameViewModel>>(formCenterInfoJsByFormId);
			}
			if (list == null)
			{
				list = new List<FormCenterInfoJsByNameViewModel>();
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		base.ViewBag.FromCenterList = list;
		base.ViewBag.FormId = formId;
		return PartialView();
	}

	public void GetSystemParts()
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
			List<CRMspSelectActiveSystemParts_Result> list2 = Enumerable.ToList<CRMspSelectActiveSystemParts_Result>((IEnumerable<CRMspSelectActiveSystemParts_Result>)_dbI.CRMspSelectActiveSystemParts(lCID, result, "1,10,11,12,13,20,30,40,50,51,60,61,62,70,100,105,110,111,112,120,130,45"));
			list.AddRange(Enumerable.Select<CRMspSelectActiveSystemParts_Result, SelectListItem>((IEnumerable<CRMspSelectActiveSystemParts_Result>)Enumerable.ToList<CRMspSelectActiveSystemParts_Result>((IEnumerable<CRMspSelectActiveSystemParts_Result>)list2), (Func<CRMspSelectActiveSystemParts_Result, SelectListItem>)((CRMspSelectActiveSystemParts_Result i) => new SelectListItem
			{
				Text = ((i.Type == "CRM") ? Labels.DyFrmCrmSysPart : Labels.DyFrmFOSysPart) + " - " + i.PartTitle,
				Value = ((i.Type == "CRM") ? (i.SystemPartId + "-0") : ("0-" + i.SystemPartId)),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.SystemPartList = list;
	}

	public JsonResult GetDyForm(string sysPartId = "")
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
			int value = 0;
			int value2 = 0;
			if (!string.IsNullOrEmpty(sysPartId))
			{
				string[] array = sysPartId.Split(new char[1] { '-' });
				if (array != null)
				{
					if (Enumerable.Count<string>((IEnumerable<string>)array) == 2)
					{
						value = int.Parse(array[0]);
					}
					value2 = int.Parse(array[1]);
				}
			}
			List<CRMspDySelectFormsWithSysPartId_Result> list2 = Enumerable.ToList<CRMspDySelectFormsWithSysPartId_Result>((IEnumerable<CRMspDySelectFormsWithSysPartId_Result>)_db.CRMspDySelectFormsWithSysPartId(value, value2, UserLogin.CurrentUser.UserId, lCID, result, result2));
			if (list2 != null && Enumerable.Any<CRMspDySelectFormsWithSysPartId_Result>((IEnumerable<CRMspDySelectFormsWithSysPartId_Result>)list2))
			{
				foreach (CRMspDySelectFormsWithSysPartId_Result item in list2)
				{
					list.Add(new SelectListItem
					{
						Text = item.FormName,
						Value = item.FormId.ToString()
					});
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.FormList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmDyDefineForm", ActionName = "actManageCenterForm")]
	public string UpdateFormAndSunFormsCIds(int formId, string cIds, string centerinfoJson)
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
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			int userId = UserLogin.CurrentUser.UserId;
			short value2 = short.Parse(Financial.Get().Id.ToString());
			short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			_ = Financial.Get().Id;
			if (formId != 0)
			{
				CRMspDySelectForms_Result cRMspDySelectForms_Result = Enumerable.FirstOrDefault<CRMspDySelectForms_Result>((IEnumerable<CRMspDySelectForms_Result>)_db.CRMspDySelectForms(formId, 0, lCID, result2, result3));
				if (cRMspDySelectForms_Result != null)
				{
					_ = cRMspDySelectForms_Result.FormCIds;
					string oldCenterInfo = cRMspDySelectForms_Result.FormCenterInfoJs ?? "";
					string formCenterInfoJs = DyForm.GetFormCenterInfoJs(centerinfoJson, oldCenterInfo, cIds, -1);
					_dbII.CRMspDyUpdateFormAndSunFormsCIds(formId, cIds, formCenterInfoJs, userId, month1: value3, year1: value2, registerDate: value, registerDatePersian: registerDatePersian, appType: appType);
				}
				else
				{
					result = string.Format(Messages.msgErrorIsNotSelectedItem, Labels.lblForm);
				}
			}
			else
			{
				result = string.Format(Messages.msgErrorIsNotSelectedItem, Labels.lblForm);
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
			result = Messages.MsgErrorDoneOperation;
		}
		return result;
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbI.Dispose();
		_dbII.Dispose();
		base.Dispose(disposing);
	}
}
