using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using CRM.Models;
using CRM.Models.ViewModel.FormBase;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.GSD.Globalization;
using Elmah;
using Newtonsoft.Json;

namespace CRMIdeal.Areas.FormBase.Controllers;

public class ShiftWorkingController : Controller
{
	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMSpIIEntities _dbII = new CRMSpIIEntities();

	public ActionResult Index()
	{
		return View();
	}

	public ActionResult GetShiftWorkings(int pageNumber = 1, int pageSize = 50, string title = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspSelectShiftWorkingsWithPaging_Result> list = Enumerable.ToList<CRMspSelectShiftWorkingsWithPaging_Result>((IEnumerable<CRMspSelectShiftWorkingsWithPaging_Result>)_dbII.CRMspSelectShiftWorkingsWithPaging(null, pageNumber, pageSize, title, lCID, result));
		return Json(new
		{
			items = list,
			totalPages = (Enumerable.FirstOrDefault<CRMspSelectShiftWorkingsWithPaging_Result>((IEnumerable<CRMspSelectShiftWorkingsWithPaging_Result>)list)?.AllPage).GetValueOrDefault()
		}, JsonRequestBehavior.AllowGet);
	}

	[DynamicAuthorize(ControllerName = "frmShiftWorking", ActionName = "actInsert,actEdit")]
	public ActionResult InsertEdit(int shiftWorkingId = 0)
	{
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			CrmShiftWorkingLanguageViewModel crmShiftWorkingLanguageViewModel = new CrmShiftWorkingLanguageViewModel();
			if (shiftWorkingId > 0)
			{
				CRMspSelectShiftWorkingById_Result cRMspSelectShiftWorkingById_Result = Enumerable.FirstOrDefault<CRMspSelectShiftWorkingById_Result>((IEnumerable<CRMspSelectShiftWorkingById_Result>)_dbII.CRMspSelectShiftWorkingById(shiftWorkingId, lCID, result));
				if (cRMspSelectShiftWorkingById_Result == null)
				{
					base.ViewBag.Error = Messages.MsgErrorNotFound;
					return View(crmShiftWorkingLanguageViewModel);
				}
				crmShiftWorkingLanguageViewModel = new CrmShiftWorkingLanguageViewModel
				{
					swTitle = cRMspSelectShiftWorkingById_Result.swTitle,
					swMaxSoonEntryTime = cRMspSelectShiftWorkingById_Result.swMaxSoonEntryTime,
					swMaxLateEntryTime = cRMspSelectShiftWorkingById_Result.swMaxLateEntryTime,
					swMaxSoonExitTime = cRMspSelectShiftWorkingById_Result.swMaxSoonExitTime,
					swMaxLateExitTime = cRMspSelectShiftWorkingById_Result.swMaxLateExitTime,
					swMaxIsCloseDurationTime = cRMspSelectShiftWorkingById_Result.swMaxIsCloseDurationTime,
					ShiftWorkingId = cRMspSelectShiftWorkingById_Result.ShiftWorkingID,
					OrderView = cRMspSelectShiftWorkingById_Result.OrderView,
					swTitle_Lang = cRMspSelectShiftWorkingById_Result.ShiftWorkingLangJson
				};
			}
			else
			{
				ObjectParameter objectParameter = new ObjectParameter("OrderView", 0);
				_dbII.CRMspReturnShiftWorkingOrderView(objectParameter);
				crmShiftWorkingLanguageViewModel.OrderView = int.Parse(objectParameter.Value.ToString());
			}
			return View(crmShiftWorkingLanguageViewModel);
		}
		catch (Exception)
		{
			CrmShiftWorkingLanguageViewModel model = new CrmShiftWorkingLanguageViewModel();
			base.ViewBag.Error = Messages.msgErrorOperationFailed;
			return View(model);
		}
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmShiftWorkingDataEntry", ActionName = "actPost")]
	public ActionResult InsertEdit(CrmShiftWorkingLanguageViewModel model)
	{
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0260: Unknown result type (might be due to invalid IL or missing references)
		//IL_01dc: Unknown result type (might be due to invalid IL or missing references)
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
				if (!string.IsNullOrEmpty(model.swTitle_Lang))
				{
					list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.swTitle_Lang);
				}
				list.Add(new CommonMultiLanguageViewModel
				{
					Value = model.swTitle,
					LanguageId = lCID
				});
				if (string.IsNullOrEmpty(model.swTitle))
				{
					text2 = text2 + string.Format(Messages.ErrorShiftWorkingFieldEmpty, Labels.Title) + "<br>";
					num++;
				}
				else if (!Public.CheckMultiLanguage(model.swTitle, list))
				{
					text2 = text2 + Messages.ErrorShiftWorkingTitleLang + "<br>";
					num++;
				}
				if (!VersionBuyer.SmartTimeAttendance && model.ShiftWorkingId == 0)
				{
					num++;
					text2 = text2 + Messages.VersionBuyModule + "<br>";
				}
				if (num == 0)
				{
					if (model.ShiftWorkingId == 0)
					{
						ObjectParameter objectParameter = new ObjectParameter("InsertedId", 0);
						CRMSpIIEntities dbII = _dbII;
						int? orderView = model.OrderView;
						int? swMaxSoonEntryTime = model.swMaxSoonEntryTime;
						int? swMaxLateExitTime = model.swMaxLateExitTime;
						int? swMaxLateEntryTime = model.swMaxLateEntryTime;
						int? swMaxSoonExitTime = model.swMaxSoonExitTime;
						int? swMaxIsCloseDurationTime = model.swMaxIsCloseDurationTime;
						dbII.CRMspInsertShiftWorking(swTitleLangJson: new JavaScriptSerializer().Serialize((object)list), swMaxSoonEntryTime: swMaxSoonEntryTime, swMaxLateExitTime: swMaxLateExitTime, swMaxLateEntryTime: swMaxLateEntryTime, swMaxSoonExitTime: swMaxSoonExitTime, swMaxIsCloseDurationTime: swMaxIsCloseDurationTime, userId: userId, registerDate: value, registerDatePersian: text, appType: appType, languageID: lCID, defaultLanguageID: result, year1: value3, orderView: orderView, month1: value2, insertedId: objectParameter);
						if (objectParameter.Value != null)
						{
							Convert.ToInt32(objectParameter.Value);
						}
					}
					else
					{
						CRMSpIIEntities dbII2 = _dbII;
						int? shiftWorkingID = model.ShiftWorkingId;
						string swTitleLangJson2 = new JavaScriptSerializer().Serialize((object)list);
						int? orderView2 = model.OrderView;
						dbII2.CRMspUpdateShiftWorking(swMaxSoonEntryTime: model.swMaxSoonEntryTime, swMaxLateExitTime: model.swMaxLateExitTime, swMaxLateEntryTime: model.swMaxLateEntryTime, swMaxSoonExitTime: model.swMaxSoonExitTime, swMaxIsCloseDurationTime: model.swMaxIsCloseDurationTime, orderView: orderView2, userId: userId, registerDate: value, registerDatePersian: text, appType: appType, languageID: lCID, defaultLanguageID: result, year1: value3, shiftWorkingID: shiftWorkingID, swTitleLangJson: swTitleLangJson2, month1: value2);
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
	[DynamicAuthorize(ControllerName = "frmShiftWorking", ActionName = "actDelete")]
	public ActionResult Delete(int shiftWorkingId)
	{
		CommonResultViewModel<string> commonResultViewModel = new CommonResultViewModel<string>();
		commonResultViewModel = ((shiftWorkingId <= 0) ? new CommonResultViewModel<string>
		{
			Data = "",
			Message = Messages.ErrorNotFound,
			Status = CommonResultStatusViewModel.Error
		} : ((Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)_dbII.CRMspDeleteShiftWorking(shiftWorkingId)).GetValueOrDefault() != 1) ? new CommonResultViewModel<string>
		{
			Data = "",
			Message = Messages.RedundancyMessage,
			Status = CommonResultStatusViewModel.Error
		} : new CommonResultViewModel<string>
		{
			Data = "",
			Message = Messages.DeleteSuccessMessage,
			Status = CommonResultStatusViewModel.Success
		}));
		return Json(commonResultViewModel, JsonRequestBehavior.AllowGet);
	}

	public ActionResult ShiftWorkingTimes(int shiftWorkingId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		base.ViewBag.ShiftWorkingId = shiftWorkingId;
		CRMspSelectShiftWorkingById_Result cRMspSelectShiftWorkingById_Result = Enumerable.FirstOrDefault<CRMspSelectShiftWorkingById_Result>((IEnumerable<CRMspSelectShiftWorkingById_Result>)_dbII.CRMspSelectShiftWorkingById(shiftWorkingId, lCID, result));
		base.ViewBag.ShiftWorkTitle = ((!string.IsNullOrEmpty(cRMspSelectShiftWorkingById_Result.swTitle)) ? cRMspSelectShiftWorkingById_Result.swTitle : "");
		return View();
	}

	[HttpPost]
	public ActionResult GetShiftWorkingTimes(int shiftWorkingId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspSelectShiftWorkingTimes_Result> list = Enumerable.ToList<CRMspSelectShiftWorkingTimes_Result>((IEnumerable<CRMspSelectShiftWorkingTimes_Result>)_dbII.CRMspSelectShiftWorkingTimes(shiftWorkingId, lCID, result));
		List<CrmShiftWorkingTimeListViewModel> list2 = new List<CrmShiftWorkingTimeListViewModel>();
		foreach (CRMspSelectShiftWorkingTimes_Result item in list)
		{
			List<ShiftWorkingDayViewModel> days = ((!string.IsNullOrEmpty(item.swtWeekDays)) ? JsonConvert.DeserializeObject<List<ShiftWorkingDayViewModel>>(item.swtWeekDays) : new List<ShiftWorkingDayViewModel>());
			CrmShiftWorkingTimeListViewModel crmShiftWorkingTimeListViewModel = new CrmShiftWorkingTimeListViewModel
			{
				ShiftWorkingTimeId = item.ShiftWorkingTimeId,
				swtShiftWorkingId = item.swtShiftWorkingId,
				swtTitle = item.swtTitle,
				swtIsDisabled = item.swtIsDisabled,
				swtCalendareTypeId = item.swtCalendareTypeId,
				swtMonthStartDay = item.swtMonthStartDay,
				swtMonthEndDay = item.swtMonthEndDay,
				swtMonthNums = item.swtMonthNums,
				swtYearStart = item.swtYearStart,
				swtYearEnd = item.swtYearEnd,
				swtSoonEntryTimeNeedVerify = item.swtSoonEntryTimeNeedVerify,
				swtSoonEntryTimeWorkflowId = item.swtSoonEntryTimeWorkflowId,
				swtLateEntryTimeNeedVerify = item.swtLateEntryTimeNeedVerify,
				swtLateEntryTimeWorkflowId = item.swtLateEntryTimeWorkflowId,
				swtSoonExitTimeNeedVerify = item.swtSoonExitTimeNeedVerify,
				swtSoonExitTimeWorkflowId = item.swtSoonExitTimeWorkflowId,
				swtLateExitTimeNeedVerify = item.swtLateExitTimeNeedVerify,
				swtLateExitTimeWorkflowId = item.swtLateExitTimeWorkflowId,
				OrderView = item.OrderView,
				swtSoonEntryTimeWorkflow = item.swtSoonEntryTimeWorkflow,
				swtLateEntryTimeWorkflow = item.swtLateEntryTimeWorkflow,
				swtSoonExitTimeWorkflow = item.swtSoonExitTimeWorkflow,
				swtLateExitTimeWorkflow = item.swtLateExitTimeWorkflow
			};
			crmShiftWorkingTimeListViewModel.Days = days;
			list2.Add(crmShiftWorkingTimeListViewModel);
		}
		return Json(new
		{
			items = list2
		}, JsonRequestBehavior.AllowGet);
	}

	public void GetVerificationWorkFlows()
	{
		List<SelectListItem> list = new List<SelectListItem>();
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		try
		{
			ObjectResult<WSspSelectVerificationWorkFlowWithObjectType_Result> objectResult = _db.WSspSelectVerificationWorkFlowWithObjectType(120, lCID, result);
			if (objectResult != null)
			{
				list.Add(new SelectListItem
				{
					Text = Labels.SelectedListDefValue,
					Value = "",
					Selected = false
				});
			}
			foreach (WSspSelectVerificationWorkFlowWithObjectType_Result item in objectResult)
			{
				list.Add(new SelectListItem
				{
					Value = item.VerificationWorkFlowId.ToString(),
					Text = item.VerificationWorkFlowTitle
				});
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.VerificationWorkFlows = list;
	}

	[DynamicAuthorize(ControllerName = "frmShiftWorkingTime", ActionName = "actInsert,actEdit")]
	public ActionResult ShiftWorkingTimeInsertEdit(int shiftWorkingId = 0, int shiftWorkingTimeId = 0)
	{
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			CrmShiftWorkingTimeLanguageViewModel model = new CrmShiftWorkingTimeLanguageViewModel();
			if (shiftWorkingTimeId > 0)
			{
				CRMspSelectShiftWorkingTimeById_Result cRMspSelectShiftWorkingTimeById_Result = Enumerable.FirstOrDefault<CRMspSelectShiftWorkingTimeById_Result>((IEnumerable<CRMspSelectShiftWorkingTimeById_Result>)_dbII.CRMspSelectShiftWorkingTimeById(shiftWorkingTimeId, lCID, result));
				if (cRMspSelectShiftWorkingTimeById_Result == null)
				{
					base.ViewBag.Error = Messages.MsgErrorNotFound;
					return View(model);
				}
				List<SelectListItem> daysInWeek = DateTimeClass.GetDaysInWeek(lCID);
				model = new CrmShiftWorkingTimeLanguageViewModel
				{
					ShiftWorkingTimeId = shiftWorkingTimeId,
					swtShiftWorkingId = cRMspSelectShiftWorkingTimeById_Result.swtShiftWorkingId,
					swtTitle = cRMspSelectShiftWorkingTimeById_Result.swtTitle,
					swtIsDisabled = cRMspSelectShiftWorkingTimeById_Result.swtIsDisabled,
					swtCalendareTypeId = cRMspSelectShiftWorkingTimeById_Result.swtCalendareTypeId,
					Days = ((!string.IsNullOrEmpty(cRMspSelectShiftWorkingTimeById_Result.swtWeekDays)) ? JsonConvert.DeserializeObject<List<ShiftWorkingDayViewModel>>(cRMspSelectShiftWorkingTimeById_Result.swtWeekDays) : new List<ShiftWorkingDayViewModel>()),
					swtMonthStartDay = cRMspSelectShiftWorkingTimeById_Result.swtMonthStartDay,
					swtMonthEndDay = cRMspSelectShiftWorkingTimeById_Result.swtMonthEndDay,
					swtMonthNums = cRMspSelectShiftWorkingTimeById_Result.swtMonthNums,
					swtYearStart = cRMspSelectShiftWorkingTimeById_Result.swtYearStart,
					swtYearEnd = cRMspSelectShiftWorkingTimeById_Result.swtYearEnd,
					swtSoonEntryTimeNeedVerify = cRMspSelectShiftWorkingTimeById_Result.swtSoonEntryTimeNeedVerify,
					swtSoonEntryTimeWorkflowId = cRMspSelectShiftWorkingTimeById_Result.swtSoonEntryTimeWorkflowId,
					swtLateEntryTimeNeedVerify = cRMspSelectShiftWorkingTimeById_Result.swtLateEntryTimeNeedVerify,
					swtLateEntryTimeWorkflowId = cRMspSelectShiftWorkingTimeById_Result.swtLateEntryTimeWorkflowId,
					swtSoonExitTimeNeedVerify = cRMspSelectShiftWorkingTimeById_Result.swtSoonExitTimeNeedVerify,
					swtSoonExitTimeWorkflowId = cRMspSelectShiftWorkingTimeById_Result.swtSoonExitTimeWorkflowId,
					swtLateExitTimeNeedVerify = cRMspSelectShiftWorkingTimeById_Result.swtLateExitTimeNeedVerify,
					swtLateExitTimeWorkflowId = cRMspSelectShiftWorkingTimeById_Result.swtLateExitTimeWorkflowId,
					OrderView = cRMspSelectShiftWorkingTimeById_Result.OrderView,
					swtTitle_Lang = cRMspSelectShiftWorkingTimeById_Result.ShiftWorkingLangJson
				};
				foreach (ShiftWorkingDayViewModel day in model.Days)
				{
					day.EntryTimeSoon = ((!string.IsNullOrWhiteSpace(day.EntryTimeSoon)) ? ParseTimeToMinutes(day.EntryTimeSoon).ToString() : "");
					day.EntryTimeLate = ((!string.IsNullOrWhiteSpace(day.EntryTimeLate)) ? ParseTimeToMinutes(day.EntryTimeLate).ToString() : "");
					day.ExitTimeLate = ((!string.IsNullOrWhiteSpace(day.ExitTimeLate)) ? ParseTimeToMinutes(day.ExitTimeLate).ToString() : "");
					day.ExitTimeSoon = ((!string.IsNullOrWhiteSpace(day.ExitTimeSoon)) ? ParseTimeToMinutes(day.ExitTimeSoon).ToString() : "");
					day.IsCloseDurationTime = ((!string.IsNullOrWhiteSpace(day.IsCloseDurationTime)) ? ParseTimeToMinutes(day.IsCloseDurationTime).ToString() : "");
				}
				foreach (int item in Enumerable.ToList<int>(Enumerable.Where<int>(Enumerable.Select<SelectListItem, int>((IEnumerable<SelectListItem>)daysInWeek, (Func<SelectListItem, int>)((SelectListItem d) => int.Parse(d.Value))), (Func<int, bool>)((int dayNum) => !Enumerable.Any<ShiftWorkingDayViewModel>((IEnumerable<ShiftWorkingDayViewModel>)model.Days, (Func<ShiftWorkingDayViewModel, bool>)((ShiftWorkingDayViewModel x) => x.DayNum == dayNum))))))
				{
					model.Days.Add(new ShiftWorkingDayViewModel
					{
						DayNum = item,
						IsActive = false,
						IsClose = false
					});
				}
				model.Days = Enumerable.ToList<ShiftWorkingDayViewModel>((IEnumerable<ShiftWorkingDayViewModel>)Enumerable.OrderBy<ShiftWorkingDayViewModel, int>((IEnumerable<ShiftWorkingDayViewModel>)model.Days, (Func<ShiftWorkingDayViewModel, int>)((ShiftWorkingDayViewModel d) => d.DayNum)));
			}
			else
			{
				model.swtShiftWorkingId = shiftWorkingId;
				ObjectParameter objectParameter = new ObjectParameter("OrderView", 0);
				_dbII.CRMspReturnShiftWorkingTimeOrderView(shiftWorkingId, objectParameter);
				model.OrderView = int.Parse(objectParameter.Value.ToString());
			}
			GetVerificationWorkFlows();
			return View(model);
		}
		catch (Exception)
		{
			CrmShiftWorkingTimeLanguageViewModel model2 = new CrmShiftWorkingTimeLanguageViewModel();
			base.ViewBag.Error = Messages.msgErrorOperationFailed;
			return View(model2);
		}
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmShiftWorkingTimeDataEntry", ActionName = "actPost")]
	public ActionResult ShiftWorkingTimeInsertEdit(CrmShiftWorkingTimeLanguageViewModel model)
	{
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dbb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cd8: Unknown result type (might be due to invalid IL or missing references)
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
				if (!string.IsNullOrEmpty(model.swtTitle_Lang))
				{
					list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.swtTitle_Lang);
				}
				if (!string.IsNullOrEmpty(model.swtTitle))
				{
					list.Add(new CommonMultiLanguageViewModel
					{
						Value = model.swtTitle,
						LanguageId = lCID
					});
				}
				if (!string.IsNullOrEmpty(model.swtTitle) && !Public.CheckMultiLanguage(model.swtTitle, list))
				{
					text2 = text2 + Messages.ErrorShiftWorkingTitleLang + "<br>";
					num++;
				}
				if (model.swtYearStart.HasValue && model.swtYearEnd.HasValue && model.swtYearStart > model.swtYearEnd)
				{
					text2 = text2 + string.Format(Messages.ErrorShiftWorkingFieldOutOfOrder, Labels.ShiftWorkingTimeStartYear, Labels.ShiftWorkingTimeEndYear) + "<br>";
					num++;
				}
				if (model.swtMonthStartDay.HasValue && model.swtMonthEndDay.HasValue && model.swtMonthStartDay > model.swtMonthEndDay)
				{
					text2 = text2 + string.Format(Messages.ErrorShiftWorkingFieldOutOfOrder, Labels.ShiftWorkingTimeStartDayOfMonth, Labels.ShiftWorkingTimeEndDayOfMonth) + "<br>";
					num++;
				}
				if (!string.IsNullOrWhiteSpace(model.swtYearStart.ToString()) && !Regex.IsMatch(model.swtYearStart.ToString(), "^\\d{4}$"))
				{
					num++;
					text2 = text2 + string.Format(Messages.ErrorShiftWorkingYearFormatInvalid, Labels.ShiftWorkingTimeStartYear) + "<br>";
				}
				if (!string.IsNullOrWhiteSpace(model.swtYearEnd.ToString()) && !Regex.IsMatch(model.swtYearEnd.ToString(), "^\\d{4}$"))
				{
					num++;
					text2 = text2 + string.Format(Messages.ErrorShiftWorkingYearFormatInvalid, Labels.ShiftWorkingTimeEndYear) + "<br>";
				}
				if (!Enumerable.Any<ShiftWorkingDayViewModel>((IEnumerable<ShiftWorkingDayViewModel>)model.Days, (Func<ShiftWorkingDayViewModel, bool>)((ShiftWorkingDayViewModel d) => d.IsActive || d.IsClose)))
				{
					num++;
					text2 += Messages.ErrorShiftWorkingAtLeastOneDayRequired;
				}
				List<SelectListItem> daysInWeek = DateTimeClass.GetDaysInWeek(lCID);
				foreach (ShiftWorkingDayViewModel day in Enumerable.Where<ShiftWorkingDayViewModel>((IEnumerable<ShiftWorkingDayViewModel>)model.Days, (Func<ShiftWorkingDayViewModel, bool>)((ShiftWorkingDayViewModel d) => d.IsActive || d.IsClose)))
				{
					string text3 = Enumerable.FirstOrDefault<SelectListItem>((IEnumerable<SelectListItem>)daysInWeek, (Func<SelectListItem, bool>)((SelectListItem d) => d.Value == day.DayNum.ToString())).Text;
					if (day.IsActive)
					{
						if (string.IsNullOrEmpty(day.EntryTime))
						{
							text2 = text2 + string.Format(Messages.ErrorShiftWorkingDayFieldEmpty, Labels.tmEntryBase, text3) + "<br>";
							num++;
						}
						else if (!Regex.IsMatch(day.EntryTime, "^(?:[01][0-9]|2[0-3]):[0-5][0-9]$"))
						{
							text2 = text2 + string.Format(Messages.ErrorShiftWorkingDayFieldInvalidFormat, Labels.tmEntryBase, text3) + "<br>";
							num++;
						}
						if (string.IsNullOrEmpty(day.ExitTime))
						{
							text2 = text2 + string.Format(Messages.ErrorShiftWorkingDayFieldEmpty, Labels.tmExitBase, text3) + "<br>";
							num++;
						}
						else if (!Regex.IsMatch(day.ExitTime, "^(?:[01][0-9]|2[0-3]):[0-5][0-9]$"))
						{
							text2 = text2 + string.Format(Messages.ErrorShiftWorkingDayFieldInvalidFormat, Labels.tmExitBase, text3) + "<br>";
							num++;
						}
						if (!string.IsNullOrEmpty(day.EntryTime) && !string.IsNullOrEmpty(day.ExitTime) && TimeSpan.Parse(day.EntryTime) > TimeSpan.Parse(day.ExitTime))
						{
							text2 = text2 + string.Format(Messages.ErrorShiftWorkingDayFieldOutOfOrder, Labels.tmEntryBase, Labels.tmExitBase, text3) + "<br>";
							num++;
						}
						if ((day.EntryTimeSoon ?? "").Replace("0", "").Replace(":", "") == "")
						{
							day.EntryTimeSoon = null;
						}
						else if (!string.IsNullOrEmpty(day.EntryTimeSoon) && !IsValidPositiveNumber(day.EntryTimeSoon))
						{
							text2 = text2 + string.Format(Messages.ErrorShiftWorkingDayFieldEmpty, Labels.ShiftWorkingTimeSoonEntry, text3) + "<br>";
							num++;
						}
						if ((day.EntryTimeLate ?? "").Replace("0", "").Replace(":", "") == "")
						{
							day.EntryTimeLate = null;
						}
						else if (!string.IsNullOrEmpty(day.EntryTimeLate) && !IsValidPositiveNumber(day.EntryTimeLate))
						{
							text2 = text2 + string.Format(Messages.ErrorShiftWorkingDayFieldEmpty, Labels.ShiftWorkingTimeLateEntry, text3) + "<br>";
							num++;
						}
						if ((day.ExitTimeSoon ?? "").Replace("0", "").Replace(":", "") == "")
						{
							day.ExitTimeSoon = null;
						}
						else if (!string.IsNullOrEmpty(day.ExitTimeSoon) && !IsValidPositiveNumber(day.ExitTimeSoon))
						{
							text2 = text2 + string.Format(Messages.ErrorShiftWorkingDayFieldEmpty, Labels.ShiftWorkingTimeSoonExit, text3) + "<br>";
							num++;
						}
						if ((day.ExitTimeLate ?? "").Replace("0", "").Replace(":", "") == "")
						{
							day.ExitTimeLate = null;
						}
						else if (!string.IsNullOrEmpty(day.ExitTimeLate) && !IsValidPositiveNumber(day.ExitTimeLate))
						{
							text2 = text2 + string.Format(Messages.ErrorShiftWorkingDayFieldEmpty, Labels.ShiftWorkingTimeLateExit, text3) + "<br>";
							num++;
						}
					}
					if (day.IsClose)
					{
						if (!string.IsNullOrEmpty(day.IsCloseEntryTime) && !Regex.IsMatch(day.IsCloseEntryTime, "^(?:[01][0-9]|2[0-3]):[0-5][0-9]$"))
						{
							text2 = text2 + string.Format(Messages.ErrorShiftWorkingDayFieldInvalidFormat, Labels.ShiftWorkingTimeIsClosedEntryTime, text3) + "<br>";
							num++;
						}
						if (!string.IsNullOrEmpty(day.IsCloseExitTime) && !Regex.IsMatch(day.IsCloseExitTime, "^(?:[01][0-9]|2[0-3]):[0-5][0-9]$"))
						{
							text2 = text2 + string.Format(Messages.ErrorShiftWorkingDayFieldInvalidFormat, Labels.ShiftWorkingTimeIsClosedExitTime, text3) + "<br>";
							num++;
						}
						if (string.IsNullOrEmpty(day.IsCloseEntryTime) && !string.IsNullOrEmpty(day.IsCloseExitTime))
						{
							text2 = text2 + string.Format(Messages.ErrorShiftWorkingDayFieldEmpty, Labels.ShiftWorkingTimeIsClosedEntryTime, text3) + "<br>";
							num++;
						}
						if (!string.IsNullOrEmpty(day.IsCloseEntryTime) && string.IsNullOrEmpty(day.IsCloseExitTime))
						{
							text2 = text2 + string.Format(Messages.ErrorShiftWorkingDayFieldEmpty, Labels.ShiftWorkingTimeIsClosedExitTime, text3) + "<br>";
							num++;
						}
						if (!string.IsNullOrEmpty(day.IsCloseEntryTime) && !string.IsNullOrEmpty(day.IsCloseExitTime) && TimeSpan.Parse(day.IsCloseEntryTime) > TimeSpan.Parse(day.IsCloseExitTime))
						{
							text2 = text2 + string.Format(Messages.ErrorShiftWorkingDayFieldOutOfOrder, Labels.ShiftWorkingTimeIsClosedEntryTime, Labels.ShiftWorkingTimeIsClosedExitTime, text3) + "<br>";
							num++;
						}
						if ((day.IsCloseDurationTime ?? "").Replace("0", "").Replace(":", "") == "")
						{
							day.IsCloseDurationTime = null;
						}
						else if (!string.IsNullOrEmpty(day.IsCloseDurationTime) && !IsValidPositiveNumber(day.IsCloseDurationTime))
						{
							text2 = text2 + string.Format(Messages.ErrorShiftWorkingDayFieldEmpty, Labels.ShiftWorkingTimeIsClosedTimeDuration, text3) + "<br>";
							num++;
						}
					}
				}
				if (!VersionBuyer.SmartTimeAttendance && model.ShiftWorkingTimeId == 0)
				{
					num++;
					text2 = text2 + Messages.VersionBuyModule + "<bt>";
				}
				if (num == 0)
				{
					foreach (ShiftWorkingDayViewModel item in Enumerable.Where<ShiftWorkingDayViewModel>((IEnumerable<ShiftWorkingDayViewModel>)model.Days, (Func<ShiftWorkingDayViewModel, bool>)((ShiftWorkingDayViewModel d) => d.IsActive || d.IsClose)))
					{
						if (item.IsActive)
						{
							item.EntryTime = ((!string.IsNullOrWhiteSpace(item.EntryTime)) ? item.EntryTime : "");
							item.ExitTime = ((!string.IsNullOrWhiteSpace(item.ExitTime)) ? item.ExitTime : "");
							item.EntryTimeSoon = ((!string.IsNullOrWhiteSpace(item.EntryTimeSoon)) ? ParseMinutesToTime(int.Parse(item.EntryTimeSoon)) : "");
							item.EntryTimeLate = ((!string.IsNullOrWhiteSpace(item.EntryTimeLate)) ? ParseMinutesToTime(int.Parse(item.EntryTimeLate)) : "");
							item.ExitTimeLate = ((!string.IsNullOrWhiteSpace(item.ExitTimeLate)) ? ParseMinutesToTime(int.Parse(item.ExitTimeLate)) : "");
							item.ExitTimeSoon = ((!string.IsNullOrWhiteSpace(item.ExitTimeSoon)) ? ParseMinutesToTime(int.Parse(item.ExitTimeSoon)) : "");
						}
						else
						{
							item.EntryTime = "";
							item.ExitTime = "";
							item.EntryTimeSoon = "";
							item.EntryTimeLate = "";
							item.ExitTimeSoon = "";
							item.ExitTimeLate = "";
						}
						if (item.IsClose)
						{
							item.IsCloseDurationTime = ((!string.IsNullOrWhiteSpace(item.IsCloseDurationTime)) ? ParseMinutesToTime(int.Parse(item.IsCloseDurationTime)) : "");
							item.IsCloseEntryTime = ((!string.IsNullOrWhiteSpace(item.IsCloseEntryTime)) ? item.IsCloseEntryTime : "");
							item.IsCloseExitTime = ((!string.IsNullOrWhiteSpace(item.IsCloseExitTime)) ? item.IsCloseExitTime : "");
						}
						else
						{
							item.IsCloseDurationTime = "";
							item.IsCloseEntryTime = "";
							item.IsCloseExitTime = "";
						}
					}
					string text4 = JsonConvert.SerializeObject(Enumerable.Where<ShiftWorkingDayViewModel>((IEnumerable<ShiftWorkingDayViewModel>)model.Days, (Func<ShiftWorkingDayViewModel, bool>)((ShiftWorkingDayViewModel d) => d.IsActive || d.IsClose)));
					if (model.ShiftWorkingTimeId != 0)
					{
						_dbII.CRMspUpdateShiftWorkingTime(model.ShiftWorkingTimeId, new JavaScriptSerializer().Serialize((object)list), model.swtIsDisabled, model.swtCalendareTypeId, (short)1, text4, model.swtMonthStartDay, model.swtMonthEndDay, model.swtMonthNums, model.swtYearStart, model.swtYearEnd, model.swtSoonEntryTimeNeedVerify, model.swtSoonEntryTimeWorkflowId, model.swtLateEntryTimeNeedVerify, model.swtLateEntryTimeWorkflowId, model.swtSoonExitTimeNeedVerify, model.swtSoonExitTimeWorkflowId, model.swtLateExitTimeNeedVerify, model.swtLateExitTimeWorkflowId, model.OrderView, userId, value, text, appType, languageId: lCID, defaultLanguageId: result, year1: value3, month1: value2);
					}
					else
					{
						ObjectParameter objectParameter = new ObjectParameter("InsertedId", 0);
						_dbII.CRMspInsertShiftWorkingTime(model.swtShiftWorkingId, new JavaScriptSerializer().Serialize((object)list), model.swtIsDisabled, model.swtCalendareTypeId, (short)1, text4, model.swtMonthStartDay, model.swtMonthEndDay, model.swtMonthNums, model.swtYearStart, model.swtYearEnd, model.swtSoonEntryTimeNeedVerify, model.swtSoonEntryTimeWorkflowId, model.swtLateEntryTimeNeedVerify, model.swtLateEntryTimeWorkflowId, model.swtSoonExitTimeNeedVerify, model.swtSoonExitTimeWorkflowId, model.swtLateExitTimeNeedVerify, model.swtLateExitTimeWorkflowId, model.OrderView, userId, value, text, appType, languageId: lCID, defaultLanguageId: result, year1: value3, month1: value2, insertedId: objectParameter);
						if (objectParameter.Value != null)
						{
							Convert.ToInt32(objectParameter.Value);
						}
					}
					base.ViewBag.Successfull = Messages.msgSuccessAction;
					GetVerificationWorkFlows();
					return View(model);
				}
			}
			if (text2 != "")
			{
				base.ViewBag.Error = text2;
			}
			GetVerificationWorkFlows();
			return View(model);
		}
		catch (Exception)
		{
			base.ViewBag.Error = Messages.msgErrorRunFunction;
			GetVerificationWorkFlows();
			return View(model);
		}
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmShiftWorkingTime", ActionName = "actDelete")]
	public ActionResult ShiftWorkingTimeDelete(int shiftWorkingTimeId)
	{
		CommonResultViewModel<string> commonResultViewModel = new CommonResultViewModel<string>();
		commonResultViewModel = ((shiftWorkingTimeId <= 0) ? new CommonResultViewModel<string>
		{
			Data = "",
			Message = Messages.ErrorNotFound,
			Status = CommonResultStatusViewModel.Error
		} : ((Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)_dbII.CRMspDeleteShiftWorkingTime(shiftWorkingTimeId)).GetValueOrDefault() != 1) ? new CommonResultViewModel<string>
		{
			Data = "",
			Message = Messages.RedundancyMessage,
			Status = CommonResultStatusViewModel.Error
		} : new CommonResultViewModel<string>
		{
			Data = "",
			Message = Messages.DeleteSuccessMessage,
			Status = CommonResultStatusViewModel.Success
		}));
		return Json(commonResultViewModel, JsonRequestBehavior.AllowGet);
	}

	public static string ParseMinutesToTime(int totalMinutes)
	{
		int num = totalMinutes / 60;
		int num2 = totalMinutes % 60;
		return $"{num:D2}:{num2:D2}";
	}

	public static int ParseTimeToMinutes(string time)
	{
		string[] array = time.Split(new char[1] { ':' });
		if (array.Length != 2)
		{
			throw new FormatException("فرمت ورودی باید HH:mm باشد");
		}
		int num = int.Parse(array[0]);
		int num2 = int.Parse(array[1]);
		return num * 60 + num2;
	}

	public bool IsValidPositiveNumber(string input)
	{
		if (int.TryParse(input, out var result))
		{
			if (result > 0)
			{
				return true;
			}
			return false;
		}
		return false;
	}
}
