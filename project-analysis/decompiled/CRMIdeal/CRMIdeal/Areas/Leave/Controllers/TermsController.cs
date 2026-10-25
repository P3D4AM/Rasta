using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using CRM.General.Security;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using Elmah;
using Newtonsoft.Json;

namespace CRMIdeal.Areas.Leave.Controllers;

public class TermsController : Controller
{
	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	public ActionResult Index()
	{
		GetLeaveTypes();
		return View();
	}

	[AjaxOnly]
	public JsonResult GetLeaveTypes()
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
			List<CRMspSelectLeaveType_Result> list2 = Enumerable.ToList<CRMspSelectLeaveType_Result>((IEnumerable<CRMspSelectLeaveType_Result>)_dbI.CRMspSelectLeaveType(lCID, result));
			list.AddRange(Enumerable.Select<CRMspSelectLeaveType_Result, SelectListItem>((IEnumerable<CRMspSelectLeaveType_Result>)list2, (Func<CRMspSelectLeaveType_Result, SelectListItem>)((CRMspSelectLeaveType_Result item) => new SelectListItem
			{
				Text = (item.LeaveType ?? ""),
				Value = item.LeaveTypeID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.LeaveTypeList = list;
		JsonResult jsonResult = Json(list, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public JsonResult GetLeaveTypeById(int typeId = 0)
	{
		CRMspSelectLeaveTypeById_Result data = new CRMspSelectLeaveTypeById_Result();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			data = Enumerable.FirstOrDefault<CRMspSelectLeaveTypeById_Result>((IEnumerable<CRMspSelectLeaveTypeById_Result>)_dbI.CRMspSelectLeaveTypeById(typeId, lCID, result));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(data, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public ActionResult Edit(int typeId = 0)
	{
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		CrmLeaveTermsEditLanguageViewModel crmLeaveTermsEditLanguageViewModel = new CrmLeaveTermsEditLanguageViewModel();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int currLangID = Thread.CurrentThread.CurrentCulture.LCID;
			CRMspSelectLeaveTypeById_Result cRMspSelectLeaveTypeById_Result = Enumerable.FirstOrDefault<CRMspSelectLeaveTypeById_Result>((IEnumerable<CRMspSelectLeaveTypeById_Result>)_dbI.CRMspSelectLeaveTypeById(typeId, currLangID, result));
			if (cRMspSelectLeaveTypeById_Result != null)
			{
				crmLeaveTermsEditLanguageViewModel = new CrmLeaveTermsEditLanguageViewModel
				{
					LeaveTypeID = cRMspSelectLeaveTypeById_Result.LeaveTypeID,
					TermText = cRMspSelectLeaveTypeById_Result.TermText
				};
				List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrWhiteSpace(cRMspSelectLeaveTypeById_Result.LeaveTypeLang))
				{
					List<CrmLeaveTerms_LangViewModel> list2 = new JavaScriptSerializer().Deserialize<List<CrmLeaveTerms_LangViewModel>>(cRMspSelectLeaveTypeById_Result.LeaveTypeLang);
					if (list2 != null && Enumerable.Any<CrmLeaveTerms_LangViewModel>((IEnumerable<CrmLeaveTerms_LangViewModel>)list2))
					{
						foreach (CrmLeaveTerms_LangViewModel item in list2)
						{
							list.Add(new CommonMultiLanguageViewModel
							{
								Value = item.TermText,
								LanguageId = item.LanguageId
							});
						}
					}
				}
				crmLeaveTermsEditLanguageViewModel.TermText_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID))));
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return View(crmLeaveTermsEditLanguageViewModel);
	}

	[HttpPost]
	public ActionResult Edit(CrmLeaveTermsEditLanguageViewModel model)
	{
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangID);
		if (defLangID <= 0)
		{
			defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		try
		{
			if (model.LeaveTypeID == 0)
			{
				base.ViewBag.Error = Messages.msgNotEntered;
				return View(model);
			}
			List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(model.TermText_Lang))
			{
				list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.TermText_Lang);
			}
			list.Add(new CommonMultiLanguageViewModel
			{
				Value = model.TermText,
				LanguageId = lCID
			});
			List<CrmLeaveTerms_LangViewModel> list2 = Enumerable.ToList<CrmLeaveTerms_LangViewModel>(Enumerable.Select<CommonMultiLanguageViewModel, CrmLeaveTerms_LangViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, CrmLeaveTerms_LangViewModel>)((CommonMultiLanguageViewModel item) => new CrmLeaveTerms_LangViewModel
			{
				TermText = item.Value,
				LanguageId = item.LanguageId
			})));
			model.MsgLangValue = JsonConvert.SerializeObject(Enumerable.ToList<CrmLeaveTerms_LangViewModel>((IEnumerable<CrmLeaveTerms_LangViewModel>)list2));
			model.TermText = ((Enumerable.FirstOrDefault<CrmLeaveTerms_LangViewModel>((IEnumerable<CrmLeaveTerms_LangViewModel>)list2, (Func<CrmLeaveTerms_LangViewModel, bool>)((CrmLeaveTerms_LangViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CrmLeaveTerms_LangViewModel>((IEnumerable<CrmLeaveTerms_LangViewModel>)list2, (Func<CrmLeaveTerms_LangViewModel, bool>)((CrmLeaveTerms_LangViewModel c) => c.LanguageId == defLangID)).TermText : null);
			_dbI.CRMspUpdateLeaveTypeTermText(model.LeaveTypeID, model.TermText, model.MsgLangValue, lCID, defLangID);
			base.ViewBag.Successfull = Messages.msgSuccessAction;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			base.ViewBag.Error = Messages.msgErrorRunFunction;
		}
		return View(model);
	}
}
