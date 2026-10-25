using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using CRM.Models;
using CRM.Models.ViewModel.FormBase;
using CRM.Models.ViewModel.Leave.LeaveStep;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.GSD.Globalization;

namespace CRMIdeal.Areas.Leave.Controllers;

public class LeaveStepController : Controller
{
	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMSpIIEntities _dbII = new CRMSpIIEntities();

	public ActionResult Index(int leaveStepGroupId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		base.ViewBag.LeaveStepGroupId = leaveStepGroupId;
		CRMspSelectLeaveStepGroupWithId_Result cRMspSelectLeaveStepGroupWithId_Result = Enumerable.FirstOrDefault<CRMspSelectLeaveStepGroupWithId_Result>((IEnumerable<CRMspSelectLeaveStepGroupWithId_Result>)_dbII.CRMspSelectLeaveStepGroupWithId(leaveStepGroupId, lCID, result));
		base.ViewBag.LeaveStepGroupTitle = ((!string.IsNullOrEmpty(cRMspSelectLeaveStepGroupWithId_Result.lsgTitle)) ? cRMspSelectLeaveStepGroupWithId_Result.lsgTitle : "");
		return View();
	}

	public ActionResult GetLeaveSteps(int leaveStepGroupId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspSelectLeaveSteps_Result> items = Enumerable.ToList<CRMspSelectLeaveSteps_Result>((IEnumerable<CRMspSelectLeaveSteps_Result>)_dbII.CRMspSelectLeaveSteps(leaveStepGroupId, lCID, result));
		return Json(new { items }, JsonRequestBehavior.AllowGet);
	}

	public ActionResult InsertEdit(int leaveStepGroupId = 0, int leaveStepId = 0)
	{
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			CrmLeaveStepLanguageViewModel crmLeaveStepLanguageViewModel = new CrmLeaveStepLanguageViewModel();
			if (leaveStepId > 0)
			{
				CRMspSelectLeaveStepWithId_Result cRMspSelectLeaveStepWithId_Result = Enumerable.FirstOrDefault<CRMspSelectLeaveStepWithId_Result>((IEnumerable<CRMspSelectLeaveStepWithId_Result>)_dbII.CRMspSelectLeaveStepWithId(leaveStepId, lCID, result));
				if (cRMspSelectLeaveStepWithId_Result == null)
				{
					base.ViewBag.Error = Messages.MsgErrorNotFound;
					return View(crmLeaveStepLanguageViewModel);
				}
				crmLeaveStepLanguageViewModel = new CrmLeaveStepLanguageViewModel
				{
					LeaveStepID = cRMspSelectLeaveStepWithId_Result.LeaveStepID,
					LeaveStepGroupId = cRMspSelectLeaveStepWithId_Result.LeaveStepGroupId,
					lsTitle = cRMspSelectLeaveStepWithId_Result.lsTitle,
					lsInActive = cRMspSelectLeaveStepWithId_Result.lsInActive,
					lsIsRequired = cRMspSelectLeaveStepWithId_Result.lsIsRequired,
					OrderView = cRMspSelectLeaveStepWithId_Result.OrderView,
					lsTitle_Lang = cRMspSelectLeaveStepWithId_Result.LeaveStepLangJson
				};
			}
			else
			{
				crmLeaveStepLanguageViewModel.LeaveStepGroupId = leaveStepGroupId;
				ObjectParameter objectParameter = new ObjectParameter("OrderView", 0);
				_dbII.CRMspReturnLeaveStepOrderView(leaveStepGroupId, objectParameter);
				crmLeaveStepLanguageViewModel.OrderView = int.Parse(objectParameter.Value.ToString());
			}
			return View(crmLeaveStepLanguageViewModel);
		}
		catch (Exception)
		{
			CrmLeaveStepLanguageViewModel model = new CrmLeaveStepLanguageViewModel();
			base.ViewBag.Error = Messages.msgErrorOperationFailed;
			return View(model);
		}
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmLeaveStepDataEntry", ActionName = "actPost")]
	public ActionResult InsertEdit(CrmLeaveStepLanguageViewModel model)
	{
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0179: Unknown result type (might be due to invalid IL or missing references)
		new CommonResultViewModel<string>();
		DateTime now = DateTime.Now;
		DateTime value = now;
		string text = now.ToString("yyyyMMdd", new PersianCulture());
		int userId = UserLogin.CurrentUser.UserId;
		string appType = Configuration.AppType;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
		short value3 = short.Parse(Financial.Get().Id.ToString());
		string text2 = "";
		try
		{
			if (base.ModelState.IsValid)
			{
				int num = 0;
				List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(model.lsTitle_Lang))
				{
					list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.lsTitle_Lang);
				}
				if (!string.IsNullOrEmpty(model.lsTitle))
				{
					list.Add(new CommonMultiLanguageViewModel
					{
						Value = model.lsTitle,
						LanguageId = lCID
					});
				}
				if (!string.IsNullOrEmpty(model.lsTitle) && !Public.CheckMultiLanguage(model.lsTitle, list))
				{
					text2 = text2 + Messages.ErrorShiftWorkingTitleLang + "<br>";
					num++;
				}
				if (num == 0)
				{
					if (model.LeaveStepID != 0)
					{
						_dbII.CRMspUpdateLeaveStep(model.LeaveStepID, new JavaScriptSerializer().Serialize((object)list), model.lsInActive, model.lsIsRequired, model.OrderView, userId, value, text, appType, languageID: lCID, defaultLanguageID: result, year1: value3, month1: value2);
					}
					else
					{
						ObjectParameter objectParameter = new ObjectParameter("InsertedId", 0);
						_dbII.CRMspInsertLeaveStep(model.LeaveStepGroupId, new JavaScriptSerializer().Serialize((object)list), model.lsInActive, model.lsIsRequired, model.OrderView, userId, value, text, appType, languageID: lCID, defaultLanguageID: result, year1: value3, month1: value2, insertedId: objectParameter);
						if (objectParameter.Value != null)
						{
							Convert.ToInt32(objectParameter.Value);
						}
					}
					base.ViewBag.Successfull = Messages.msgSuccessAction;
					return View(model);
				}
			}
			if (text2 != "")
			{
				base.ViewBag.Error = text2;
			}
			return View(model);
		}
		catch (Exception)
		{
			base.ViewBag.Error = Messages.msgErrorRunFunction;
			return View(model);
		}
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmLeaveStep", ActionName = "actDelete")]
	public ActionResult Delete(int leaveStepId)
	{
		CommonResultViewModel<string> commonResultViewModel = new CommonResultViewModel<string>();
		commonResultViewModel = ((leaveStepId <= 0) ? new CommonResultViewModel<string>
		{
			Data = "",
			Message = Messages.ErrorNotFound,
			Status = CommonResultStatusViewModel.Error
		} : ((Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)_dbII.CRMspDeleteLeaveStep(leaveStepId)).GetValueOrDefault() != 1) ? new CommonResultViewModel<string>
		{
			Data = "",
			Message = Messages.frmErrorDelete,
			Status = CommonResultStatusViewModel.Error
		} : new CommonResultViewModel<string>
		{
			Data = "",
			Message = Messages.DeleteSuccessMessage,
			Status = CommonResultStatusViewModel.Success
		}));
		return Json(commonResultViewModel, JsonRequestBehavior.AllowGet);
	}

	public ActionResult LeaveStepGroups()
	{
		return View();
	}

	public ActionResult GetLeaveStepGroups()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspSelectLeaveStepGroups_Result> items = Enumerable.ToList<CRMspSelectLeaveStepGroups_Result>((IEnumerable<CRMspSelectLeaveStepGroups_Result>)_dbII.CRMspSelectLeaveStepGroups(lCID, result));
		return Json(new { items }, JsonRequestBehavior.AllowGet);
	}

	public ActionResult LeaveStepGroupInsertEdit(int leaveStepGroupId = 0)
	{
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			CrmLeaveStepGroupLanguageViewModel crmLeaveStepGroupLanguageViewModel = new CrmLeaveStepGroupLanguageViewModel();
			if (leaveStepGroupId > 0)
			{
				CRMspSelectLeaveStepGroupWithId_Result cRMspSelectLeaveStepGroupWithId_Result = Enumerable.FirstOrDefault<CRMspSelectLeaveStepGroupWithId_Result>((IEnumerable<CRMspSelectLeaveStepGroupWithId_Result>)_dbII.CRMspSelectLeaveStepGroupWithId(leaveStepGroupId, lCID, result));
				if (cRMspSelectLeaveStepGroupWithId_Result == null)
				{
					base.ViewBag.Error = Messages.MsgErrorNotFound;
					return View(crmLeaveStepGroupLanguageViewModel);
				}
				crmLeaveStepGroupLanguageViewModel = new CrmLeaveStepGroupLanguageViewModel
				{
					lsgTitle = cRMspSelectLeaveStepGroupWithId_Result.lsgTitle,
					LeaveStepGroupId = leaveStepGroupId,
					OrderView = cRMspSelectLeaveStepGroupWithId_Result.OrderView,
					lsgTitle_Lang = cRMspSelectLeaveStepGroupWithId_Result.LeaveStepGroupLangJson
				};
			}
			else
			{
				ObjectParameter objectParameter = new ObjectParameter("OrderView", 0);
				_dbII.CRMspReturnLeaveStepGroupOrderView(objectParameter);
				crmLeaveStepGroupLanguageViewModel.OrderView = int.Parse(objectParameter.Value.ToString());
			}
			return View(crmLeaveStepGroupLanguageViewModel);
		}
		catch (Exception)
		{
			CrmShiftWorkingLanguageViewModel model = new CrmShiftWorkingLanguageViewModel();
			base.ViewBag.Error = Messages.msgErrorOperationFailed;
			return View(model);
		}
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmLeaveStepGroupDataEntry", ActionName = "actPost")]
	public ActionResult LeaveStepGroupInsertEdit(CrmLeaveStepGroupLanguageViewModel model)
	{
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_0179: Unknown result type (might be due to invalid IL or missing references)
		new CommonResultViewModel<string>();
		DateTime now = DateTime.Now;
		DateTime value = now;
		string text = now.ToString("yyyyMMdd", new PersianCulture());
		int userId = UserLogin.CurrentUser.UserId;
		string appType = Configuration.AppType;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
		short value3 = short.Parse(Financial.Get().Id.ToString());
		string text2 = "";
		try
		{
			if (base.ModelState.IsValid)
			{
				int num = 0;
				List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(model.lsgTitle_Lang))
				{
					list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.lsgTitle_Lang);
				}
				list.Add(new CommonMultiLanguageViewModel
				{
					Value = model.lsgTitle,
					LanguageId = lCID
				});
				if (string.IsNullOrEmpty(model.lsgTitle))
				{
					text2 = text2 + string.Format(Messages.ErrorShiftWorkingFieldEmpty, Labels.Title) + "<br>";
					num++;
				}
				else if (!Public.CheckMultiLanguage(model.lsgTitle, list))
				{
					num++;
				}
				if (num == 0)
				{
					if (model.LeaveStepGroupId != 0)
					{
						_dbII.CRMspUpdateLeaveStepGroup(model.LeaveStepGroupId, new JavaScriptSerializer().Serialize((object)list), model.OrderView, userId, value, text, appType, languageID: lCID, defaultLanguageID: result, year1: value3, month1: value2);
					}
					else
					{
						ObjectParameter objectParameter = new ObjectParameter("InsertedId", 0);
						_dbII.CRMspInsertLeaveStepGroup(model.OrderView, new JavaScriptSerializer().Serialize((object)list), userId, value, text, appType, languageID: lCID, defaultLanguageID: result, year1: value3, month1: value2, insertedId: objectParameter);
						if (objectParameter.Value != null)
						{
							Convert.ToInt32(objectParameter.Value);
						}
					}
					base.ViewBag.Successfull = Messages.msgSuccessAction;
					return View(model);
				}
			}
			if (text2 != "")
			{
				base.ViewBag.Error = text2;
			}
			return View(model);
		}
		catch (Exception)
		{
			base.ViewBag.Error = Messages.msgErrorRunFunction;
			return View(model);
		}
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmLeaveStepGroup", ActionName = "actDelete")]
	public ActionResult LeaveStepGroupDelete(int leaveStepGroupId)
	{
		CommonResultViewModel<string> commonResultViewModel = new CommonResultViewModel<string>();
		commonResultViewModel = ((leaveStepGroupId <= 0) ? new CommonResultViewModel<string>
		{
			Data = "",
			Message = Messages.ErrorNotFound,
			Status = CommonResultStatusViewModel.Error
		} : ((Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)_dbII.CRMspDeleteLeaveStepGroup(leaveStepGroupId)).GetValueOrDefault() != 1) ? new CommonResultViewModel<string>
		{
			Data = "",
			Message = Messages.frmErrorDelete,
			Status = CommonResultStatusViewModel.Error
		} : new CommonResultViewModel<string>
		{
			Data = "",
			Message = Messages.DeleteSuccessMessage,
			Status = CommonResultStatusViewModel.Success
		}));
		return Json(commonResultViewModel, JsonRequestBehavior.AllowGet);
	}
}
