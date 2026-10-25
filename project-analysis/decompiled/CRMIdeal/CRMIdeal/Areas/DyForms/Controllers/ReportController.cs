using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Xml;
using CRM.General.Calendar;
using CRM.General.Security;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.GSD.Globalization;
using Elmah;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

namespace CRMIdeal.Areas.DyForms.Controllers;

public class ReportController : Controller
{
	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actdyFormsReport")]
	public ActionResult Index()
	{
		DyFormReportsViewModel model = new DyFormReportsViewModel();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		GetSystemParts();
		GetMainForms();
		GetUsers();
		GetVerificationWorkFlow();
		return View(model);
	}

	[AjaxOnly]
	public ActionResult _PartialFields(int formId)
	{
		List<CRMspDySelectForms_Result> list = new List<CRMspDySelectForms_Result>();
		List<CRMspDySelectFormFields_Result> list2 = new List<CRMspDySelectFormFields_Result>();
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
			CRMspDySelectForms_Result cRMspDySelectForms_Result = Enumerable.FirstOrDefault<CRMspDySelectForms_Result>((IEnumerable<CRMspDySelectForms_Result>)_db.CRMspDySelectForms(formId, 0, lCID, result, result2));
			if (cRMspDySelectForms_Result == null)
			{
				base.ViewBag.Error = Messages.MsgFormNotDefined;
			}
			else
			{
				List<CRMspDySelectForms_Result> collection = Enumerable.ToList<CRMspDySelectForms_Result>(Enumerable.Where<CRMspDySelectForms_Result>((IEnumerable<CRMspDySelectForms_Result>)_db.CRMspDySelectForms(0, formId, lCID, result, result2), (Func<CRMspDySelectForms_Result, bool>)((CRMspDySelectForms_Result m) => m.IsActive.GetValueOrDefault())));
				list.Add(cRMspDySelectForms_Result);
				list.AddRange(collection);
				if (Enumerable.Any<CRMspDySelectForms_Result>((IEnumerable<CRMspDySelectForms_Result>)list))
				{
					foreach (CRMspDySelectForms_Result item in list)
					{
						List<CRMspDySelectFormFields_Result> list3 = Enumerable.ToList<CRMspDySelectFormFields_Result>(Enumerable.Where<CRMspDySelectFormFields_Result>((IEnumerable<CRMspDySelectFormFields_Result>)_db.CRMspDySelectFormFields(0, item.FormId, null, lCID, result), (Func<CRMspDySelectFormFields_Result, bool>)((CRMspDySelectFormFields_Result m) => m.FieldTypeId.GetValueOrDefault() != 12)));
						if (list3 != null && Enumerable.Any<CRMspDySelectFormFields_Result>((IEnumerable<CRMspDySelectFormFields_Result>)list3))
						{
							list2.AddRange(list3);
						}
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.Forms = list;
		base.ViewBag.FormFields = list2;
		return PartialView();
	}

	[AjaxOnly]
	public JsonResult LoadFormsAndFields(int formId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		DyFormsInReportsViewModel dyFormsInReportsViewModel = new DyFormsInReportsViewModel();
		dyFormsInReportsViewModel.Forms = new List<CRMspDySelectFormAndSubForms_Result>();
		dyFormsInReportsViewModel.MainForm = new CRMspDySelectFormAndSubForms_Result();
		dyFormsInReportsViewModel.FormFields = new List<CRMspDySelectFormFieldsByParentFormId_Result>();
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			int userId = UserLogin.CurrentUser.UserId;
			List<CRMspDySelectFormAndSubForms_Result> list = Enumerable.ToList<CRMspDySelectFormAndSubForms_Result>((IEnumerable<CRMspDySelectFormAndSubForms_Result>)_dbI.CRMspDySelectFormAndSubForms(formId, userId, lCID, result, result2));
			if (list != null && Enumerable.Any<CRMspDySelectFormAndSubForms_Result>((IEnumerable<CRMspDySelectFormAndSubForms_Result>)list))
			{
				dyFormsInReportsViewModel.IsFind = true;
				dyFormsInReportsViewModel.Message = "";
				CRMspDySelectFormAndSubForms_Result mainForm = Enumerable.FirstOrDefault<CRMspDySelectFormAndSubForms_Result>((IEnumerable<CRMspDySelectFormAndSubForms_Result>)list, (Func<CRMspDySelectFormAndSubForms_Result, bool>)((CRMspDySelectFormAndSubForms_Result m) => m.ParentFormId == 0));
				dyFormsInReportsViewModel.MainForm = mainForm;
				dyFormsInReportsViewModel.Forms.AddRange(list);
				List<CRMspDySelectFormFieldsByParentFormId_Result> collection = Enumerable.ToList<CRMspDySelectFormFieldsByParentFormId_Result>(Enumerable.Where<CRMspDySelectFormFieldsByParentFormId_Result>((IEnumerable<CRMspDySelectFormFieldsByParentFormId_Result>)_dbI.CRMspDySelectFormFieldsByParentFormId(formId, lCID, result), (Func<CRMspDySelectFormFieldsByParentFormId_Result, bool>)((CRMspDySelectFormFieldsByParentFormId_Result m) => m.FieldTypeId.GetValueOrDefault() != 12)));
				dyFormsInReportsViewModel.FormFields.AddRange(collection);
			}
			else
			{
				dyFormsInReportsViewModel.IsFind = false;
				dyFormsInReportsViewModel.Message = Messages.MsgFormNotDefined;
			}
		}
		catch (DbEntityValidationException ex)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)ex);
			dyFormsInReportsViewModel.Message = Messages.frmErrorMessage + "<br />" + ((Exception)(object)ex).Message;
		}
		catch (Exception ex2)
		{
			ErrorSignal.FromCurrentContext().Raise(ex2);
			dyFormsInReportsViewModel.Message = Messages.frmErrorMessage + "<br />" + ex2.Message;
		}
		JsonResult jsonResult = Json(dyFormsInReportsViewModel, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public JsonResult GetMainForms(string sysPartId = "")
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
			list.AddRange(Enumerable.Select<CRMspDySelectFormsWithSysPartId_Result, SelectListItem>((IEnumerable<CRMspDySelectFormsWithSysPartId_Result>)list2, (Func<CRMspDySelectFormsWithSysPartId_Result, SelectListItem>)((CRMspDySelectFormsWithSysPartId_Result item) => new SelectListItem
			{
				Text = item.FormName,
				Value = item.FormId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.MainFormList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
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

	[DynamicAuthorize(ControllerName = "frmDyFormsReport", ActionName = "actConfirm")]
	[AjaxOnly]
	public JsonResult FormReports(string model)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		DyFormReportsViewModel model2 = new JavaScriptSerializer().Deserialize<DyFormReportsViewModel>(model);
		JsonResult jsonResult = Json(FormReportsItem(model2), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public List<mct_CRMspDyFormsReport_Result> FormReportsItem(DyFormReportsViewModel model)
	{
		//IL_0503: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<mct_CRMspDyFormsReport_Result> list = new List<mct_CRMspDyFormsReport_Result>();
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			if (model != null)
			{
				model.FromFirstRegisterDate = ((!string.IsNullOrEmpty(model.FromFirstRegisterDate)) ? model.FromFirstRegisterDate.Replace("/", "") : "");
				model.ToFirstRegisterDate = ((!string.IsNullOrEmpty(model.ToFirstRegisterDate)) ? model.ToFirstRegisterDate.Replace("/", "") : "");
				model.FromRegisterDate = ((!string.IsNullOrEmpty(model.FromRegisterDate)) ? model.FromRegisterDate.Replace("/", "") : "");
				model.ToRegisterDate = ((!string.IsNullOrEmpty(model.ToRegisterDate)) ? model.ToRegisterDate.Replace("/", "") : "");
				model.CheckedStatusId = (string.IsNullOrEmpty(model.CheckedStatusId) ? "0" : model.CheckedStatusId);
				model.FirstRegisterUserId = (string.IsNullOrEmpty(model.FirstRegisterUserId) ? "0" : model.FirstRegisterUserId);
				model.RegisterUserId = (string.IsNullOrEmpty(model.RegisterUserId) ? "0" : model.RegisterUserId);
				model.MasterValueId = model.MasterValueId.GetValueOrDefault();
				model.CheckerUserId = (string.IsNullOrEmpty(model.CheckerUserId) ? "0" : model.CheckerUserId);
				model.DyFormNumber = (string.IsNullOrEmpty(model.DyFormNumber) ? "0" : model.DyFormNumber);
				model.VerificationWorkFlowId = (string.IsNullOrEmpty(model.VerificationWorkFlowId) ? "0" : model.VerificationWorkFlowId);
				model.VerificationWorkFlowSetpId = (string.IsNullOrEmpty(model.VerificationWorkFlowSetpId) ? "0" : model.VerificationWorkFlowSetpId);
				DateTime value = default(DateTime);
				DateTime value2 = default(DateTime);
				DateTime value3 = default(DateTime);
				DateTime value4 = default(DateTime);
				if (!string.IsNullOrEmpty(model.FromFirstRegisterDate))
				{
					value = DateTime.Parse(PersianDate.GetFormatetdDate(model.FromFirstRegisterDate.Replace("/", "")) + " 00:00:00", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				if (!string.IsNullOrEmpty(model.ToFirstRegisterDate))
				{
					value2 = DateTime.Parse(PersianDate.GetFormatetdDate(model.ToFirstRegisterDate.Replace("/", "")) + " 23:59:59", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				if (!string.IsNullOrEmpty(model.FromRegisterDate))
				{
					value3 = DateTime.Parse(PersianDate.GetFormatetdDate(model.FromRegisterDate.Replace("/", "")) + " 00:00:00", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				if (!string.IsNullOrEmpty(model.ToRegisterDate))
				{
					value4 = DateTime.Parse(PersianDate.GetFormatetdDate(model.ToRegisterDate.Replace("/", "")) + " 23:59:59", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				DateTime value5 = default(DateTime);
				DateTime value6 = default(DateTime);
				if (!string.IsNullOrEmpty(model.FromCheckedDate))
				{
					value5 = DateTime.Parse(PersianDate.GetFormatetdDate(model.FromCheckedDate.Replace("/", "")) + " 00:00:00", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				if (!string.IsNullOrEmpty(model.ToCheckedDate))
				{
					value6 = DateTime.Parse(PersianDate.GetFormatetdDate(model.ToCheckedDate.Replace("/", "")) + " 23:59:59", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				List<IdKeyValueItemViewModel> list2 = new List<IdKeyValueItemViewModel>();
				if (!string.IsNullOrEmpty(model.ValueDetails))
				{
					list2 = new JavaScriptSerializer().Deserialize<List<IdKeyValueItemViewModel>>(model.ValueDetails);
				}
				string text = "";
				string text2 = "";
				string text3 = "";
				foreach (IdKeyValueItemViewModel obj in list2)
				{
					if (string.IsNullOrEmpty(obj.Value))
					{
						continue;
					}
					string text4 = obj.Id ?? "";
					int num = 0;
					int num2 = 0;
					string text5 = "";
					if (text4 != "")
					{
						string[] array = text4.Split(new char[1] { '_' });
						if (array != null)
						{
							num = int.Parse(array[0]);
							num2 = int.Parse(array[1]);
							if (Enumerable.Count<string>((IEnumerable<string>)array) > 2)
							{
								text5 = ((!string.IsNullOrEmpty(array[2])) ? array[2] : "");
								continue;
							}
						}
					}
					text += ((num != 0 && text.IndexOf(num + ",", StringComparison.Ordinal) == -1) ? (num + ",") : "");
					text2 += ((num2 != 0 && text2.IndexOf(num2 + ",", StringComparison.Ordinal) == -1) ? (num2 + ",") : "");
					switch (obj.Key)
					{
					case "numeric":
					{
						obj.Value = obj.Value.Replace(".", "");
						IdKeyValueItemViewModel idKeyValueItemViewModel5 = Enumerable.FirstOrDefault<IdKeyValueItemViewModel>((IEnumerable<IdKeyValueItemViewModel>)list2, (Func<IdKeyValueItemViewModel, bool>)((IdKeyValueItemViewModel m) => m.Id == obj.Id + "_To"));
						if (idKeyValueItemViewModel5 != null)
						{
							text5 = idKeyValueItemViewModel5.Value;
							if (!string.IsNullOrEmpty(text5))
							{
								text5 = text5.Replace(".", "");
								IdKeyValueItemViewModel idKeyValueItemViewModel6 = obj;
								idKeyValueItemViewModel6.Value = idKeyValueItemViewModel6.Value + "@:@" + text5;
							}
							else
							{
								IdKeyValueItemViewModel idKeyValueItemViewModel7 = obj;
								idKeyValueItemViewModel7.Value = idKeyValueItemViewModel7.Value + "@:@" + obj.Value;
							}
						}
						else
						{
							IdKeyValueItemViewModel idKeyValueItemViewModel8 = obj;
							idKeyValueItemViewModel8.Value = idKeyValueItemViewModel8.Value + "@:@" + obj.Value;
						}
						obj.Value += "@T:T@2";
						break;
					}
					case "date":
					{
						IdKeyValueItemViewModel idKeyValueItemViewModel9 = Enumerable.FirstOrDefault<IdKeyValueItemViewModel>((IEnumerable<IdKeyValueItemViewModel>)list2, (Func<IdKeyValueItemViewModel, bool>)((IdKeyValueItemViewModel m) => m.Id == obj.Id + "_To"));
						if (idKeyValueItemViewModel9 != null)
						{
							text5 = idKeyValueItemViewModel9.Value;
						}
						if (!string.IsNullOrEmpty(obj.Value))
						{
							obj.Value = obj.Value.Replace("/", "").Replace("-", "").Replace("\\", "")
								.Replace(" ", "")
								.Replace("_", "");
							string formatetdDate = PersianDate.GetFormatetdDate(obj.Value.Replace("/", ""));
							switch (lCID)
							{
							case 1065:
							{
								DateTime dateTime3 = DateTime.Parse(formatetdDate + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture());
								obj.Value = dateTime3.ToString("yyyyMMdd");
								break;
							}
							case 1025:
							{
								DateTime dateTime2 = DateTime.Parse(formatetdDate + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA"));
								obj.Value = dateTime2.ToString("yyyyMMdd", new PersianCulture());
								break;
							}
							default:
							{
								DateTime dateTime = DateTime.Parse(formatetdDate + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US"));
								obj.Value = dateTime.ToString("yyyyMMdd", new PersianCulture());
								break;
							}
							}
						}
						if (!string.IsNullOrEmpty(text5))
						{
							text5 = text5.Replace("/", "").Replace("-", "").Replace("\\", "")
								.Replace(" ", "")
								.Replace("_", "");
							string formatetdDate2 = PersianDate.GetFormatetdDate(text5.Replace("/", ""));
							text5 = lCID switch
							{
								1065 => DateTime.Parse(formatetdDate2 + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture()).ToString("yyyyMMdd"), 
								1025 => DateTime.Parse(formatetdDate2 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA")).ToString("yyyyMMdd", new PersianCulture()), 
								_ => DateTime.Parse(formatetdDate2 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US")).ToString("yyyyMMdd", new PersianCulture()), 
							};
							IdKeyValueItemViewModel idKeyValueItemViewModel10 = obj;
							idKeyValueItemViewModel10.Value = idKeyValueItemViewModel10.Value + "@:@" + text5;
						}
						else
						{
							IdKeyValueItemViewModel idKeyValueItemViewModel11 = obj;
							idKeyValueItemViewModel11.Value = idKeyValueItemViewModel11.Value + "@:@" + obj.Value;
						}
						obj.Value += "@T:T@4";
						break;
					}
					case "time":
					{
						obj.Value = obj.Value.Replace(":", "");
						IdKeyValueItemViewModel idKeyValueItemViewModel = Enumerable.FirstOrDefault<IdKeyValueItemViewModel>((IEnumerable<IdKeyValueItemViewModel>)list2, (Func<IdKeyValueItemViewModel, bool>)((IdKeyValueItemViewModel m) => m.Id == obj.Id + "_To"));
						if (idKeyValueItemViewModel != null)
						{
							text5 = idKeyValueItemViewModel.Value;
							if (!string.IsNullOrEmpty(text5))
							{
								text5 = text5.Replace(":", "");
								IdKeyValueItemViewModel idKeyValueItemViewModel2 = obj;
								idKeyValueItemViewModel2.Value = idKeyValueItemViewModel2.Value + "@:@" + text5;
							}
							else
							{
								IdKeyValueItemViewModel idKeyValueItemViewModel3 = obj;
								idKeyValueItemViewModel3.Value = idKeyValueItemViewModel3.Value + "@:@" + obj.Value;
							}
						}
						else
						{
							IdKeyValueItemViewModel idKeyValueItemViewModel4 = obj;
							idKeyValueItemViewModel4.Value = idKeyValueItemViewModel4.Value + "@:@" + obj.Value;
						}
						obj.Value += "@T:T@5";
						break;
					}
					case "checkbox":
						obj.Value += "@T:T@8";
						break;
					default:
					{
						CRMspDySelectFormFields_Result cRMspDySelectFormFields_Result = Enumerable.FirstOrDefault<CRMspDySelectFormFields_Result>((IEnumerable<CRMspDySelectFormFields_Result>)_db.CRMspDySelectFormFields(num2, 0, 0, lCID, result));
						if (cRMspDySelectFormFields_Result != null && cRMspDySelectFormFields_Result.FieldTypeId.HasValue)
						{
							if (cRMspDySelectFormFields_Result.FieldTypeId.GetValueOrDefault() == 6)
							{
								obj.Value += "@T:T@6";
							}
							else if (cRMspDySelectFormFields_Result.FieldTypeId.GetValueOrDefault() == 7)
							{
								obj.Value += "@T:T@7";
							}
							else if (cRMspDySelectFormFields_Result.FieldTypeId.GetValueOrDefault() == 9)
							{
								obj.Value += "@T:T@9";
							}
							else if (cRMspDySelectFormFields_Result.FieldTypeId.GetValueOrDefault() == 10)
							{
								obj.Value += "@T:T@10";
							}
							else if (cRMspDySelectFormFields_Result.FieldTypeId.GetValueOrDefault() == 11)
							{
								obj.Value += "@T:T@11";
							}
						}
						break;
					}
					}
					text3 = text3 + obj.Value + "|@Rpt^Frm@|";
				}
				text = model.FormId + ",";
				text = Enumerable.Aggregate<CRMspDySelectForms_Result, string>((IEnumerable<CRMspDySelectForms_Result>)Enumerable.ToList<CRMspDySelectForms_Result>(Enumerable.Where<CRMspDySelectForms_Result>((IEnumerable<CRMspDySelectForms_Result>)_db.CRMspDySelectForms(0, model.FormId, lCID, result, result2), (Func<CRMspDySelectForms_Result, bool>)((CRMspDySelectForms_Result m) => m.IsActive.GetValueOrDefault()))), text, (Func<string, CRMspDySelectForms_Result, string>)((string current, CRMspDySelectForms_Result cf) => current + cf.FormId + ","));
				text = ((text == "") ? model.FormId.ToString() : text.TrimEnd(new char[1] { ',' }));
				if (text2 != "")
				{
					text2 = text2.TrimEnd(new char[1] { ',' });
				}
				DateTime now = DateTime.Now;
				list = Enumerable.ToList<mct_CRMspDyFormsReport_Result>((IEnumerable<mct_CRMspDyFormsReport_Result>)_db.mfi_CRMspDyFormsReport(text, text2, text3, UserLogin.CurrentUser.UserId, now.ToString("yyyy/MM/dd"), now.ToString("dddd"), (!string.IsNullOrEmpty(model.FromFirstRegisterDate)) ? new DateTime?(value) : null, (!string.IsNullOrEmpty(model.ToFirstRegisterDate)) ? new DateTime?(value2) : null, (!string.IsNullOrEmpty(model.FromRegisterDate)) ? new DateTime?(value3) : null, (!string.IsNullOrEmpty(model.ToRegisterDate)) ? new DateTime?(value4) : null, model.CompanyId, model.FirstRegisterUserId, model.RegisterUserId, model.CheckedStatusId, lCID, result, model.MasterValueId, (!string.IsNullOrEmpty(model.FromCheckedDate)) ? new DateTime?(value5) : null, (!string.IsNullOrEmpty(model.ToCheckedDate)) ? new DateTime?(value6) : null, model.CheckerUserId, model.DyFormNumber, model.VerificationWorkFlowId, model.VerificationWorkFlowSetpId, result2));
				if (list != null && Enumerable.Any<mct_CRMspDyFormsReport_Result>((IEnumerable<mct_CRMspDyFormsReport_Result>)list))
				{
					foreach (mct_CRMspDyFormsReport_Result item in list)
					{
						item.FirstRegisterDatePersian = (item.FirstRegisterDate.HasValue ? item.FirstRegisterDate.Value.ToString("yyyy/MM/dd") : "");
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	public ActionResult FormReports_Read([DataSourceRequest] DataSourceRequest request, string model)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		DyFormReportsViewModel model2 = new JavaScriptSerializer().Deserialize<DyFormReportsViewModel>(model);
		List<mct_CRMspDyFormsReport_Result> enumerable = FormReportsItem(model2);
		JsonResult jsonResult = Json(((IEnumerable)enumerable).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[DynamicAuthorize(ControllerName = "frmDyFormsReport", ActionName = "actGetXmlFile")]
	public ActionResult GetXml(string model)
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected O, but got Unknown
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		string text = Guid.NewGuid().ToString();
		MemoryStream memoryStream = new MemoryStream();
		XmlWriterSettings val = new XmlWriterSettings();
		val.OmitXmlDeclaration = true;
		val.Indent = true;
		List<FieldValueItemViewModel> list = new List<FieldValueItemViewModel>();
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		try
		{
			DyFormReportsViewModel model2 = new JavaScriptSerializer().Deserialize<DyFormReportsViewModel>(model);
			List<mct_CRMspDyFormsReport_Result> list2 = FormReportsItem(model2);
			foreach (mct_CRMspDyFormsReport_Result item2 in list2)
			{
				if (string.IsNullOrEmpty(item2.FieldValue))
				{
					continue;
				}
				string[] array = item2.FieldValue.Split(new string[1] { "|^,^|" }, StringSplitOptions.None);
				if (array == null)
				{
					continue;
				}
				int num = array.Length;
				for (int i = 0; i < num; i++)
				{
					if (array[i] == null || !(array[i] != ""))
					{
						continue;
					}
					string[] array2 = array[i].Split(new string[1] { "|^:^|" }, StringSplitOptions.None);
					if (array2 == null || !Enumerable.Any<string>((IEnumerable<string>)array2) || Enumerable.Count<string>((IEnumerable<string>)array2) <= 3)
					{
						continue;
					}
					FieldValueItemViewModel fieldValueItemViewModel = new FieldValueItemViewModel
					{
						FormId = item2.FormId.GetValueOrDefault(),
						CompanyId = item2.CompanyId,
						CompanyPersonId = item2.CompanyPersonId,
						ProjectId = item2.ProjectId,
						ConversationId = item2.ConversationId,
						MasterObjectId = item2.MasterObjectId,
						DetailObjectId = item2.DetailObjectId,
						SubDetailObjectId = item2.SubDetailObjectId,
						MasterValueId = item2.MasterValueId,
						FieldTitle = array2[0],
						Value = array2[1],
						FieldType = ((array2[2] != null) ? array2[2].Trim() : array2[2]),
						FieldRepeatId = ((!string.IsNullOrWhiteSpace(array2[3])) ? long.Parse(array2[3].Trim() ?? "0") : 0)
					};
					if (fieldValueItemViewModel.FieldType == "4" && !string.IsNullOrEmpty(fieldValueItemViewModel.Value))
					{
						fieldValueItemViewModel.Value = fieldValueItemViewModel.Value.Replace("/", "").Replace("-", "").Replace("\\", "")
							.Replace(" ", "")
							.Replace("_", "");
						if (fieldValueItemViewModel.Value != "" && fieldValueItemViewModel.Value != "")
						{
							string formatetdDate = PersianDate.GetFormatetdDate(fieldValueItemViewModel.Value.Replace("/", ""));
							switch (lCID)
							{
							case 1065:
								fieldValueItemViewModel.Value = DateTime.Parse(formatetdDate + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture()).ToString("yyyy/MM/dd");
								break;
							case 1025:
								fieldValueItemViewModel.Value = DateTime.Parse(PersianDate.GetShamsi2Miladi(fieldValueItemViewModel.Value.Replace("/", ""))).ToString("yyyy/MM/dd", new CultureInfo("ar-SA"));
								break;
							default:
								fieldValueItemViewModel.Value = DateTime.Parse(PersianDate.GetShamsi2Miladi(fieldValueItemViewModel.Value.Replace("/", ""))).ToString("yyyy/MM/dd", new CultureInfo("en-US"));
								break;
							}
						}
					}
					else if (fieldValueItemViewModel.FieldType == "8")
					{
						if (fieldValueItemViewModel.Value != "" && fieldValueItemViewModel.Value != "")
						{
							fieldValueItemViewModel.Value = fieldValueItemViewModel.Value.Replace("|", ",");
							fieldValueItemViewModel.Value = fieldValueItemViewModel.Value.TrimEnd(new char[1] { ',' });
						}
						fieldValueItemViewModel.Value.TrimEnd(new char[1] { ',' });
					}
					list.Add(fieldValueItemViewModel);
				}
			}
			if (list != null && Enumerable.Any<FieldValueItemViewModel>((IEnumerable<FieldValueItemViewModel>)list))
			{
				bool flag = true;
				XmlWriter val2 = XmlWriter.Create((Stream)memoryStream, val);
				try
				{
					val2.WriteStartDocument();
					val2.WriteStartElement("Container");
					foreach (mct_CRMspDyFormsReport_Result item in list2)
					{
						List<FieldValueItemViewModel> list3 = Enumerable.ToList<FieldValueItemViewModel>(Enumerable.Where<FieldValueItemViewModel>((IEnumerable<FieldValueItemViewModel>)list, (Func<FieldValueItemViewModel, bool>)((FieldValueItemViewModel m) => m.MasterValueId == item.MasterValueId && m.FieldRepeatId == 0)));
						if (list3 == null || !Enumerable.Any<FieldValueItemViewModel>((IEnumerable<FieldValueItemViewModel>)list3))
						{
							continue;
						}
						FieldValueItemViewModel fieldValueItemViewModel2 = Enumerable.FirstOrDefault<FieldValueItemViewModel>((IEnumerable<FieldValueItemViewModel>)list3);
						if (fieldValueItemViewModel2 == null)
						{
							continue;
						}
						if (list2.Count == 1 && flag)
						{
							flag = false;
							val2.WriteStartElement("Row");
							foreach (FieldValueItemViewModel item3 in list3)
							{
								if (!string.IsNullOrEmpty(item3.FieldTitle))
								{
									string text2 = item3.FieldTitle.Trim();
									text2 = text2.Replace(" ", "_");
									text2 = ConvertCharacter.RemoveSpecialCharactersWithoutDot(text2);
									val2.WriteElementString(text2, "");
								}
							}
							val2.WriteElementString("CompanyId", "0");
							val2.WriteElementString("CompanyPersonId", "0");
							val2.WriteElementString("ProjectId", "0");
							val2.WriteElementString("ConversationId", "0");
							val2.WriteElementString("MasterObjectId", "0");
							val2.WriteElementString("DetailObjectId", "0");
							val2.WriteElementString("SubDetailObjectId", "0");
							val2.WriteElementString("MasterValueId", "0");
							val2.WriteEndElement();
						}
						val2.WriteStartElement("Row");
						foreach (FieldValueItemViewModel item4 in list3)
						{
							if (!string.IsNullOrEmpty(item4.FieldTitle))
							{
								string text3 = item4.FieldTitle.Trim();
								text3 = text3.Replace(" ", "_");
								text3 = ConvertCharacter.RemoveSpecialCharactersWithoutDot(text3);
								val2.WriteElementString(text3, item4.Value ?? "");
							}
						}
						val2.WriteElementString("CompanyId", fieldValueItemViewModel2.CompanyId.ToString());
						val2.WriteElementString("CompanyPersonId", fieldValueItemViewModel2.CompanyPersonId.ToString());
						val2.WriteElementString("ProjectId", fieldValueItemViewModel2.ProjectId.ToString());
						val2.WriteElementString("ConversationId", fieldValueItemViewModel2.ConversationId.ToString());
						val2.WriteElementString("MasterObjectId", fieldValueItemViewModel2.MasterObjectId.ToString());
						val2.WriteElementString("DetailObjectId", fieldValueItemViewModel2.DetailObjectId.ToString());
						val2.WriteElementString("SubDetailObjectId", fieldValueItemViewModel2.SubDetailObjectId.ToString());
						val2.WriteElementString("MasterValueId", fieldValueItemViewModel2.MasterValueId.ToString());
						val2.WriteEndElement();
						List<FieldValueItemViewModel> list4 = new List<FieldValueItemViewModel>();
						List<FieldValueItemViewModel> list5 = Enumerable.ToList<FieldValueItemViewModel>(Enumerable.Where<FieldValueItemViewModel>((IEnumerable<FieldValueItemViewModel>)list, (Func<FieldValueItemViewModel, bool>)((FieldValueItemViewModel m) => m.MasterValueId == item.MasterValueId && m.FieldRepeatId != 0)));
						if (list5 == null || !Enumerable.Any<FieldValueItemViewModel>((IEnumerable<FieldValueItemViewModel>)list5))
						{
							continue;
						}
						foreach (FieldValueItemViewModel repeateItem in list5)
						{
							FieldValueItemViewModel fieldValueItemViewModel3 = null;
							if (list4 != null && Enumerable.Any<FieldValueItemViewModel>((IEnumerable<FieldValueItemViewModel>)list4))
							{
								fieldValueItemViewModel3 = Enumerable.FirstOrDefault<FieldValueItemViewModel>((IEnumerable<FieldValueItemViewModel>)list4, (Func<FieldValueItemViewModel, bool>)((FieldValueItemViewModel m) => m.MasterValueId == item.MasterValueId && m.FieldRepeatId == repeateItem.FieldRepeatId));
							}
							if (fieldValueItemViewModel3 != null)
							{
								continue;
							}
							list3 = Enumerable.ToList<FieldValueItemViewModel>(Enumerable.Where<FieldValueItemViewModel>((IEnumerable<FieldValueItemViewModel>)list, (Func<FieldValueItemViewModel, bool>)((FieldValueItemViewModel m) => m.MasterValueId == item.MasterValueId && m.FieldRepeatId == repeateItem.FieldRepeatId)));
							val2.WriteStartElement("Row");
							foreach (FieldValueItemViewModel item5 in list3)
							{
								if (!string.IsNullOrEmpty(item5.FieldTitle))
								{
									string text4 = item5.FieldTitle.Trim();
									text4 = text4.Replace(" ", "_");
									text4 = ConvertCharacter.RemoveSpecialCharactersWithoutDot(text4);
									val2.WriteElementString(text4, item5.Value ?? "");
								}
							}
							val2.WriteElementString("CompanyId", fieldValueItemViewModel2.CompanyId.ToString());
							val2.WriteElementString("CompanyPersonId", fieldValueItemViewModel2.CompanyPersonId.ToString());
							val2.WriteElementString("ProjectId", fieldValueItemViewModel2.ProjectId.ToString());
							val2.WriteElementString("ConversationId", fieldValueItemViewModel2.ConversationId.ToString());
							val2.WriteElementString("MasterObjectId", fieldValueItemViewModel2.MasterObjectId.ToString());
							val2.WriteElementString("DetailObjectId", fieldValueItemViewModel2.DetailObjectId.ToString());
							val2.WriteElementString("SubDetailObjectId", fieldValueItemViewModel2.SubDetailObjectId.ToString());
							val2.WriteElementString("MasterValueId", fieldValueItemViewModel2.MasterValueId.ToString());
							val2.WriteEndElement();
							list4.Add(repeateItem);
						}
					}
					val2.WriteEndElement();
					val2.WriteEndDocument();
					val2.Flush();
					val2.Close();
				}
				finally
				{
					((IDisposable)val2)?.Dispose();
				}
				memoryStream.Position = 0L;
				base.TempData[text] = memoryStream.ToArray();
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return new JsonResult
		{
			Data = new
			{
				FileGuid = text,
				FileName = "DyFormsReportOutput.xml"
			}
		};
	}

	[HttpGet]
	public virtual ActionResult Download(string fileGuid, string fileName)
	{
		if (base.TempData[fileGuid] != null)
		{
			byte[] fileContents = base.TempData[fileGuid] as byte[];
			return File(fileContents, "application/xml", fileName);
		}
		return new EmptyResult();
	}

	[AjaxOnly]
	public JsonResult GetCompany(string value = "")
	{
		List<CRMspDyFormsReportSearchCompany_Result> data = new List<CRMspDyFormsReportSearchCompany_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			data = Enumerable.ToList<CRMspDyFormsReportSearchCompany_Result>((IEnumerable<CRMspDyFormsReportSearchCompany_Result>)_db.CRMspDyFormsReportSearchCompany(value, lCID, result));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetUsers()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			List<CRMspSelectUserForLinkedType_Result> list2 = Enumerable.ToList<CRMspSelectUserForLinkedType_Result>((IEnumerable<CRMspSelectUserForLinkedType_Result>)_db.CRMspSelectUserForLinkedType(UserLogin.CurrentUser.UserId, 2, lCID, result, result2));
			list.Add(new SelectListItem
			{
				Text = Labels.SelectedListDefValue,
				Value = "0",
				Selected = false
			});
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
		base.ViewBag.UsersList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetVerificationWorkFlow()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			List<WSspSelectVerificationWorkFlowWithObjectType_Result> list2 = Enumerable.ToList<WSspSelectVerificationWorkFlowWithObjectType_Result>((IEnumerable<WSspSelectVerificationWorkFlowWithObjectType_Result>)_db.WSspSelectVerificationWorkFlowWithObjectType(80, lCID, result));
			list.Add(new SelectListItem
			{
				Text = Labels.SelectedListDefValue,
				Value = "0",
				Selected = false
			});
			list.AddRange(Enumerable.Select<WSspSelectVerificationWorkFlowWithObjectType_Result, SelectListItem>((IEnumerable<WSspSelectVerificationWorkFlowWithObjectType_Result>)list2, (Func<WSspSelectVerificationWorkFlowWithObjectType_Result, SelectListItem>)((WSspSelectVerificationWorkFlowWithObjectType_Result item) => new SelectListItem
			{
				Text = item.VerificationWorkFlowTitle,
				Value = item.VerificationWorkFlowId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.VerificationWorkFlowList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetVerificationWorkflowStep(int workflowId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			List<WSspSelectVerificationWorkFlowSteps_Result> list2 = Enumerable.ToList<WSspSelectVerificationWorkFlowSteps_Result>((IEnumerable<WSspSelectVerificationWorkFlowSteps_Result>)_db.WSspSelectVerificationWorkFlowSteps(workflowId, lCID, result));
			list.Add(new SelectListItem
			{
				Text = Labels.SelectedListDefValue,
				Value = "0",
				Selected = false
			});
			list.AddRange(Enumerable.Select<WSspSelectVerificationWorkFlowSteps_Result, SelectListItem>((IEnumerable<WSspSelectVerificationWorkFlowSteps_Result>)list2, (Func<WSspSelectVerificationWorkFlowSteps_Result, SelectListItem>)((WSspSelectVerificationWorkFlowSteps_Result item) => new SelectListItem
			{
				Text = item.VerificationWorkFlowStepTitle,
				Value = item.VerificationWorkFlowStepId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(list, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbI.Dispose();
		base.Dispose(disposing);
	}
}
