using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Globalization;
using System.Linq;
using System.Web.Http;
using CRM.General.Calendar;
using CRM.Resources;
using Elmah;
using GSD.Globalization;
using Mobile.Cache.Setting;
using Mobile.Classes;
using Mobile.Classes.Helper;
using Mobile.DataType;
using Mobile.Models;
using Newtonsoft.Json;

namespace Mobile.Controllers;

public class HRMLeaveController : ApiController
{
	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<HrmLeaveSummaryViewModel> ReturnLeaveSummary(int? typeId = 0, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		HrmLeaveSummaryViewModel hrmLeaveSummaryViewModel = new HrmLeaveSummaryViewModel();
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int num = ((result > 0) ? result : result2);
		baseInfo.SetCulture(num);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					cRMEntities = new CRMEntities();
					string persianDate_YyyyMmDd = DateTime.Now.ToString("yyyy/MM/01");
					persianDate_YyyyMmDd = PersianDate.GetFormatetdDate(persianDate_YyyyMmDd);
					DateTime value = num switch
					{
						1065 => DateTime.Parse(persianDate_YyyyMmDd + " 00:00:00", new PersianCulture()), 
						1025 => DateTime.Parse(persianDate_YyyyMmDd + " 00:00:00", new CultureInfo("ar-SA")), 
						_ => DateTime.Parse(persianDate_YyyyMmDd + " 00:00:00", new CultureInfo("en-US")), 
					};
					persianDate_YyyyMmDd = DateTime.Parse(DateTime.Now.AddMonths(1).ToString("yyyy/MM/01")).AddDays(-1.0).ToString("yyyy/MM/dd");
					persianDate_YyyyMmDd = PersianDate.GetFormatetdDate(persianDate_YyyyMmDd);
					DateTime value2 = num switch
					{
						1065 => DateTime.Parse(persianDate_YyyyMmDd + " 23:59:59", new PersianCulture()), 
						1025 => DateTime.Parse(persianDate_YyyyMmDd + " 23:59:59", new CultureInfo("ar-SA")), 
						_ => DateTime.Parse(persianDate_YyyyMmDd + " 23:59:59", new CultureInfo("en-US")), 
					};
					persianDate_YyyyMmDd = DateTime.Now.ToString("yyyy/01/01");
					persianDate_YyyyMmDd = PersianDate.GetFormatetdDate(persianDate_YyyyMmDd);
					DateTime value3 = num switch
					{
						1065 => DateTime.Parse(persianDate_YyyyMmDd + " 00:00:00", new PersianCulture()), 
						1025 => DateTime.Parse(persianDate_YyyyMmDd + " 00:00:00", new CultureInfo("ar-SA")), 
						_ => DateTime.Parse(persianDate_YyyyMmDd + " 00:00:00", new CultureInfo("en-US")), 
					};
					persianDate_YyyyMmDd = DateTime.Parse(DateTime.Now.AddYears(1).ToString("yyyy/01/01")).AddDays(-1.0).ToString("yyyy/MM/dd");
					persianDate_YyyyMmDd = PersianDate.GetFormatetdDate(persianDate_YyyyMmDd);
					DateTime value4 = num switch
					{
						1065 => DateTime.Parse(persianDate_YyyyMmDd + " 23:59:59", new PersianCulture()), 
						1025 => DateTime.Parse(persianDate_YyyyMmDd + " 23:59:59", new CultureInfo("ar-SA")), 
						_ => DateTime.Parse(persianDate_YyyyMmDd + " 23:59:59", new CultureInfo("en-US")), 
					};
					HRMMobspReturnLeaveSummary_Result hRMMobspReturnLeaveSummary_Result = Enumerable.FirstOrDefault<HRMMobspReturnLeaveSummary_Result>((IEnumerable<HRMMobspReturnLeaveSummary_Result>)cRMEntities.HRMMobspReturnLeaveSummary(typeId, token2.userId, value, value2, value3, value4));
					hrmLeaveSummaryViewModel.MonthlyDailySum = hRMMobspReturnLeaveSummary_Result.MonthlyDailySum.GetValueOrDefault();
					hrmLeaveSummaryViewModel.MonthlyHourlySumInMin = hRMMobspReturnLeaveSummary_Result.MonthlyHourlySumInMin.GetValueOrDefault();
					hrmLeaveSummaryViewModel.MonthlyHourlySumTxt = hRMMobspReturnLeaveSummary_Result.MonthlyHourlySumTxt;
					hrmLeaveSummaryViewModel.YearlyDailySum = hRMMobspReturnLeaveSummary_Result.YearlyDailySum.GetValueOrDefault();
					hrmLeaveSummaryViewModel.YearlyHourlySumInMin = hRMMobspReturnLeaveSummary_Result.YearlyHourlySumInMin.GetValueOrDefault();
					hrmLeaveSummaryViewModel.YealyHourlySumTxt = hRMMobspReturnLeaveSummary_Result.YealyHourlySumTxt;
					hrmLeaveSummaryViewModel.TotallyDailySum = hRMMobspReturnLeaveSummary_Result.TotallyDailySum.GetValueOrDefault();
					hrmLeaveSummaryViewModel.TotallyHourlySumInMin = hRMMobspReturnLeaveSummary_Result.TotallyHourlySumInMin.GetValueOrDefault();
					hrmLeaveSummaryViewModel.TotallyHourlySumTxt = hRMMobspReturnLeaveSummary_Result.TotallyHourlySumTxt;
					if (hrmLeaveSummaryViewModel.MonthlyDailySum > 0)
					{
						hrmLeaveSummaryViewModel.MonthlyLeaveStr = hrmLeaveSummaryViewModel.MonthlyDailySum + " " + Labels.lblDay;
					}
					if (hrmLeaveSummaryViewModel.MonthlyHourlySumInMin > 0)
					{
						if (!string.IsNullOrEmpty(hrmLeaveSummaryViewModel.MonthlyLeaveStr))
						{
							HrmLeaveSummaryViewModel hrmLeaveSummaryViewModel2 = hrmLeaveSummaryViewModel;
							hrmLeaveSummaryViewModel2.MonthlyLeaveStr = hrmLeaveSummaryViewModel2.MonthlyLeaveStr + " " + Labels.lblAnd + " ";
						}
						hrmLeaveSummaryViewModel.MonthlyLeaveStr += DateTimeClass.ConvertMinToHourAndMin(hrmLeaveSummaryViewModel.MonthlyHourlySumInMin);
					}
					if (hrmLeaveSummaryViewModel.YearlyDailySum > 0)
					{
						hrmLeaveSummaryViewModel.YearlyLeaveStr = hrmLeaveSummaryViewModel.YearlyDailySum + " " + Labels.lblDay;
					}
					if (hrmLeaveSummaryViewModel.YearlyHourlySumInMin > 0)
					{
						if (!string.IsNullOrEmpty(hrmLeaveSummaryViewModel.YearlyLeaveStr))
						{
							HrmLeaveSummaryViewModel hrmLeaveSummaryViewModel3 = hrmLeaveSummaryViewModel;
							hrmLeaveSummaryViewModel3.YearlyLeaveStr = hrmLeaveSummaryViewModel3.YearlyLeaveStr + " " + Labels.lblAnd + " ";
						}
						hrmLeaveSummaryViewModel.YearlyLeaveStr += DateTimeClass.ConvertMinToHourAndMin(hrmLeaveSummaryViewModel.YearlyHourlySumInMin);
					}
					if (hrmLeaveSummaryViewModel.TotallyDailySum > 0)
					{
						hrmLeaveSummaryViewModel.TotallyLeaveStr = hrmLeaveSummaryViewModel.TotallyDailySum + " " + Labels.lblDay;
					}
					if (hrmLeaveSummaryViewModel.TotallyHourlySumInMin > 0)
					{
						if (!string.IsNullOrEmpty(hrmLeaveSummaryViewModel.TotallyLeaveStr))
						{
							HrmLeaveSummaryViewModel hrmLeaveSummaryViewModel4 = hrmLeaveSummaryViewModel;
							hrmLeaveSummaryViewModel4.TotallyLeaveStr = hrmLeaveSummaryViewModel4.TotallyLeaveStr + " " + Labels.lblAnd + " ";
						}
						hrmLeaveSummaryViewModel.TotallyLeaveStr += DateTimeClass.ConvertMinToHourAndMin(hrmLeaveSummaryViewModel.TotallyHourlySumInMin);
					}
					message = Messages.MobMsgSuccessAction;
					status = ServiceResultStatus.Success;
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					hrmLeaveSummaryViewModel = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				hrmLeaveSummaryViewModel = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			hrmLeaveSummaryViewModel = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<HrmLeaveSummaryViewModel>
		{
			Message = message,
			Data = hrmLeaveSummaryViewModel,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<HRMMobspReturnLeaveSummaryCalendar_Result>> ReturnLeaveSummaryCalendar(int typeOpr, DateTime fromDate, DateTime toDate, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		List<HRMMobspReturnLeaveSummaryCalendar_Result> data;
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					cRMEntities = new CRMEntities();
					data = Enumerable.ToList<HRMMobspReturnLeaveSummaryCalendar_Result>((IEnumerable<HRMMobspReturnLeaveSummaryCalendar_Result>)cRMEntities.HRMMobspReturnLeaveSummaryCalendar(typeOpr, token2.userId, fromDate, toDate));
					message = Messages.MobMsgSuccessAction;
					status = ServiceResultStatus.Success;
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					data = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				data = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<List<HRMMobspReturnLeaveSummaryCalendar_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<HRMMobspSelectClosedCalendarEvents_Result>> SelectClosedCalendarEvents(DateTime fromDate, DateTime toDate, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		List<HRMMobspSelectClosedCalendarEvents_Result> data;
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new Common().GetToken(token) != null)
				{
					cRMEntities = new CRMEntities();
					data = Enumerable.ToList<HRMMobspSelectClosedCalendarEvents_Result>((IEnumerable<HRMMobspSelectClosedCalendarEvents_Result>)cRMEntities.HRMMobspSelectClosedCalendarEvents(fromDate, toDate, result, result2));
					message = Messages.MobMsgSuccessAction;
					status = ServiceResultStatus.Success;
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					data = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				data = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<List<HRMMobspSelectClosedCalendarEvents_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<HrmLeaveInsertEditResaultViewModel> HourlyLeaveInsertEdit(HrmLeaveInsertEditViewModel model)
	{
		int result = 1065;
		if (model.LanguageId.HasValue)
		{
			int.TryParse(model.LanguageId.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangId);
		CRMEntities cRMEntities = null;
		HrmLeaveInsertEditResaultViewModel hrmLeaveInsertEditResaultViewModel = new HrmLeaveInsertEditResaultViewModel();
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int num = ((result > 0) ? result : defLangId);
		baseInfo.SetCulture(num);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					cRMEntities = new CRMEntities();
					DateTime now = DateTime.Now;
					int userId = token2.userId;
					DateTime value = now;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					short value2 = short.Parse(now.ToString("yyyy", new PersianCulture()));
					short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
					string appType = Mobile.Classes.Configuration.AppType;
					List<HRMMobspSelectLanguages_Result> list = Enumerable.ToList<HRMMobspSelectLanguages_Result>((IEnumerable<HRMMobspSelectLanguages_Result>)cRMEntities.HRMMobspSelectLanguages());
					if (string.IsNullOrEmpty(model.RequestDate))
					{
						ServiceResult<HrmLeaveInsertEditResaultViewModel> result2 = new ServiceResult<HrmLeaveInsertEditResaultViewModel>
						{
							Message = Messages.msgErrorLeaveRequestDateNotEntered,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
						cRMEntities?.Dispose();
						return result2;
					}
					if (string.IsNullOrEmpty(model.FromTime))
					{
						ServiceResult<HrmLeaveInsertEditResaultViewModel> result3 = new ServiceResult<HrmLeaveInsertEditResaultViewModel>
						{
							Message = Messages.msgErrorLeaveFromTimeNotEntered,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
						cRMEntities?.Dispose();
						return result3;
					}
					if (string.IsNullOrEmpty(model.ToTime))
					{
						ServiceResult<HrmLeaveInsertEditResaultViewModel> result4 = new ServiceResult<HrmLeaveInsertEditResaultViewModel>
						{
							Message = Messages.msgErrorLeaveToTimeNotEntered,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
						cRMEntities?.Dispose();
						return result4;
					}
					DateTime dateTime = default(DateTime);
					string text = "";
					try
					{
						string text2 = "00:00:00";
						if (!string.IsNullOrEmpty(model.RequestDate))
						{
							text2 = model.FromTime + ":00";
						}
						text = PersianDate.GetFormatetdDate(model.RequestDate.Replace("/", ""));
						dateTime = num switch
						{
							1065 => DateTime.Parse(text + " " + text2, new PersianCulture()), 
							1025 => DateTime.Parse(text + " " + text2, new CultureInfo("ar-SA")), 
							_ => DateTime.Parse(text + " " + text2, new CultureInfo("en-US")), 
						};
						model.FromDateTime = dateTime;
						model.FromDate = dateTime.ToString("yyyyMMdd", new CultureInfo("fa-IR"));
					}
					catch (Exception e)
					{
						ErrorSignal.FromCurrentContext().Raise(e);
						ServiceResult<HrmLeaveInsertEditResaultViewModel> result5 = new ServiceResult<HrmLeaveInsertEditResaultViewModel>
						{
							Message = Messages.ErrorFormatTime,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
						cRMEntities?.Dispose();
						return result5;
					}
					try
					{
						string text3 = "00:00:00";
						if (!string.IsNullOrEmpty(model.RequestDate))
						{
							text3 = model.ToTime + ":00";
						}
						text = PersianDate.GetFormatetdDate(model.RequestDate.Replace("/", ""));
						dateTime = num switch
						{
							1065 => DateTime.Parse(text + " " + text3, new PersianCulture()), 
							1025 => DateTime.Parse(text + " " + text3, new CultureInfo("ar-SA")), 
							_ => DateTime.Parse(text + " " + text3, new CultureInfo("en-US")), 
						};
						model.ToDateTime = dateTime;
						model.ToDate = dateTime.ToString("yyyyMMdd", new CultureInfo("fa-IR"));
					}
					catch (Exception e2)
					{
						ErrorSignal.FromCurrentContext().Raise(e2);
						ServiceResult<HrmLeaveInsertEditResaultViewModel> result6 = new ServiceResult<HrmLeaveInsertEditResaultViewModel>
						{
							Message = Messages.ErrorFormatTime,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
						cRMEntities?.Dispose();
						return result6;
					}
					List<HrmLeaveMultiLanguageViewModel> list2 = new List<HrmLeaveMultiLanguageViewModel>();
					foreach (HRMMobspSelectLanguages_Result item in list)
					{
						HrmLeaveMultiLanguageViewModel hrmLeaveMultiLanguageViewModel = new HrmLeaveMultiLanguageViewModel();
						hrmLeaveMultiLanguageViewModel.LanguageId = item.LanguageID;
						hrmLeaveMultiLanguageViewModel.Reason = model.Reason;
						list2.Add(hrmLeaveMultiLanguageViewModel);
					}
					model.MsgLangValue = JsonConvert.SerializeObject(Enumerable.ToList<HrmLeaveMultiLanguageViewModel>((IEnumerable<HrmLeaveMultiLanguageViewModel>)list2));
					model.Reason = ((Enumerable.FirstOrDefault<HrmLeaveMultiLanguageViewModel>((IEnumerable<HrmLeaveMultiLanguageViewModel>)list2, (Func<HrmLeaveMultiLanguageViewModel, bool>)((HrmLeaveMultiLanguageViewModel c) => c.LanguageId == defLangId)) != null) ? Enumerable.FirstOrDefault<HrmLeaveMultiLanguageViewModel>((IEnumerable<HrmLeaveMultiLanguageViewModel>)list2, (Func<HrmLeaveMultiLanguageViewModel, bool>)((HrmLeaveMultiLanguageViewModel c) => c.LanguageId == defLangId)).Reason : null);
					if (!model.IsEdit)
					{
						if (!VersionBuyer.Leave && Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.HRMMobspSelectLeaveCnt()).GetValueOrDefault() > 5)
						{
							ServiceResult<HrmLeaveInsertEditResaultViewModel> result7 = new ServiceResult<HrmLeaveInsertEditResaultViewModel>
							{
								Message = Messages.MobMsgSimpleVersionBuy,
								Data = null,
								Status = ServiceResultStatus.Fail
							};
							cRMEntities?.Dispose();
							return result7;
						}
						model.LeaveTypeId = 1;
						model.DayCount = 1;
						model.LeaveStatusId = 1;
					}
					model.RequestUserId = userId;
					ObjectParameter objectParameter = new ObjectParameter("Result", -1);
					Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.HRMMobspInsertUpdateLeave(model.LeaveId, model.LeaveTypeId, model.RequestUserId, model.ReplaceUserId, model.FromDateTime, model.FromDate, model.ToDateTime, model.ToDate, model.DayCount, model.FromTime, model.ToTime, model.HourCount, model.Reason, null, null, null, null, null, null, null, null, null, null, null, null, model.LeaveStatusId, null, model.MsgLangValue, userId, value2, value3, value, registerDatePersian, appType, num, defLangId, objectParameter));
					if (objectParameter != null)
					{
						if (objectParameter.Value.ToString() == "-1")
						{
							message = Messages.msgErrorRunFunction;
							status = ServiceResultStatus.Error;
						}
						else
						{
							int value4 = Convert.ToInt32(objectParameter.Value);
							HRMMobspSelectLeave_Result hRMMobspSelectLeave_Result = Enumerable.FirstOrDefault<HRMMobspSelectLeave_Result>((IEnumerable<HRMMobspSelectLeave_Result>)cRMEntities.HRMMobspSelectLeave(userId, value4, null, userId, null, null, 1, 1, num, defLangId, null));
							if (hRMMobspSelectLeave_Result != null)
							{
								hrmLeaveInsertEditResaultViewModel.LeaveId = hRMMobspSelectLeave_Result.LeaveId;
								hrmLeaveInsertEditResaultViewModel.VerificationWorkFlowId = hRMMobspSelectLeave_Result.VerificationWorkFlowId;
								hrmLeaveInsertEditResaultViewModel.UserDepartmentLeaveVerificationWorkFlowId = hRMMobspSelectLeave_Result.UserDepartmentLeaveVerificationWorkFlowId;
								hrmLeaveInsertEditResaultViewModel.UserDepartmentMissionVerificationWorkFlowId = hRMMobspSelectLeave_Result.UserDepartmentMissionVerificationWorkFlowId;
								hrmLeaveInsertEditResaultViewModel.LeaveTypeOpr = hRMMobspSelectLeave_Result.LeaveTypeOpr;
							}
							message = Messages.MobMsgSuccessAction;
							status = ServiceResultStatus.Success;
						}
					}
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					hrmLeaveInsertEditResaultViewModel = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				hrmLeaveInsertEditResaultViewModel = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e3)
		{
			message = Messages.MobMsgErrorDoneOperation;
			hrmLeaveInsertEditResaultViewModel = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e3);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<HrmLeaveInsertEditResaultViewModel>
		{
			Message = message,
			Data = hrmLeaveInsertEditResaultViewModel,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<HrmLeaveInsertEditResaultViewModel> DailyLeaveInsertEdit(HrmLeaveInsertEditViewModel model)
	{
		int result = 1065;
		if (model.LanguageId.HasValue)
		{
			int.TryParse(model.LanguageId.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangId);
		CRMEntities cRMEntities = null;
		HrmLeaveInsertEditResaultViewModel hrmLeaveInsertEditResaultViewModel = new HrmLeaveInsertEditResaultViewModel();
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int num = ((result > 0) ? result : defLangId);
		baseInfo.SetCulture(num);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					cRMEntities = new CRMEntities();
					DateTime now = DateTime.Now;
					int userId = token2.userId;
					DateTime value = now;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					short value2 = short.Parse(now.ToString("yyyy", new PersianCulture()));
					short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
					string appType = Mobile.Classes.Configuration.AppType;
					List<HRMMobspSelectLanguages_Result> list = Enumerable.ToList<HRMMobspSelectLanguages_Result>((IEnumerable<HRMMobspSelectLanguages_Result>)cRMEntities.HRMMobspSelectLanguages());
					if (string.IsNullOrEmpty(model.FromDate))
					{
						ServiceResult<HrmLeaveInsertEditResaultViewModel> result2 = new ServiceResult<HrmLeaveInsertEditResaultViewModel>
						{
							Message = Messages.msgErrorLeaveFromTimeNotEntered,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
						cRMEntities?.Dispose();
						return result2;
					}
					if (string.IsNullOrEmpty(model.ToDate))
					{
						ServiceResult<HrmLeaveInsertEditResaultViewModel> result3 = new ServiceResult<HrmLeaveInsertEditResaultViewModel>
						{
							Message = Messages.msgErrorLeaveToTimeNotEntered,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
						cRMEntities?.Dispose();
						return result3;
					}
					DateTime dateTime = default(DateTime);
					string text = "";
					try
					{
						string text2 = "00:00:00";
						text = PersianDate.GetFormatetdDate(model.FromDate.Replace("/", ""));
						dateTime = num switch
						{
							1065 => DateTime.Parse(text + " " + text2, new PersianCulture()), 
							1025 => DateTime.Parse(text + " " + text2, new CultureInfo("ar-SA")), 
							_ => DateTime.Parse(text + " " + text2, new CultureInfo("en-US")), 
						};
						model.FromDateTime = dateTime;
						model.FromDate = dateTime.ToString("yyyyMMdd", new CultureInfo("fa-IR"));
					}
					catch (Exception e)
					{
						ErrorSignal.FromCurrentContext().Raise(e);
						ServiceResult<HrmLeaveInsertEditResaultViewModel> result4 = new ServiceResult<HrmLeaveInsertEditResaultViewModel>
						{
							Message = Messages.ErrorFormatTime,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
						cRMEntities?.Dispose();
						return result4;
					}
					try
					{
						string text3 = "23:59:59";
						text = PersianDate.GetFormatetdDate(model.ToDate.Replace("/", ""));
						dateTime = num switch
						{
							1065 => DateTime.Parse(text + " " + text3, new PersianCulture()), 
							1025 => DateTime.Parse(text + " " + text3, new CultureInfo("ar-SA")), 
							_ => DateTime.Parse(text + " " + text3, new CultureInfo("en-US")), 
						};
						model.ToDateTime = dateTime;
						model.ToDate = dateTime.ToString("yyyyMMdd", new CultureInfo("fa-IR"));
					}
					catch (Exception e2)
					{
						ErrorSignal.FromCurrentContext().Raise(e2);
						ServiceResult<HrmLeaveInsertEditResaultViewModel> result5 = new ServiceResult<HrmLeaveInsertEditResaultViewModel>
						{
							Message = Messages.ErrorFormatTime,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
						cRMEntities?.Dispose();
						return result5;
					}
					if (model.FromDateTime.Value.Date > model.ToDateTime.Value.Date)
					{
						ServiceResult<HrmLeaveInsertEditResaultViewModel> result6 = new ServiceResult<HrmLeaveInsertEditResaultViewModel>
						{
							Message = Messages.MsgStartDateCanNotBeAfterToDate,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
						cRMEntities?.Dispose();
						return result6;
					}
					List<HrmLeaveMultiLanguageViewModel> list2 = new List<HrmLeaveMultiLanguageViewModel>();
					foreach (HRMMobspSelectLanguages_Result item in list)
					{
						HrmLeaveMultiLanguageViewModel hrmLeaveMultiLanguageViewModel = new HrmLeaveMultiLanguageViewModel();
						hrmLeaveMultiLanguageViewModel.LanguageId = item.LanguageID;
						hrmLeaveMultiLanguageViewModel.Reason = model.Reason;
						list2.Add(hrmLeaveMultiLanguageViewModel);
					}
					model.MsgLangValue = JsonConvert.SerializeObject(Enumerable.ToList<HrmLeaveMultiLanguageViewModel>((IEnumerable<HrmLeaveMultiLanguageViewModel>)list2));
					model.Reason = ((Enumerable.FirstOrDefault<HrmLeaveMultiLanguageViewModel>((IEnumerable<HrmLeaveMultiLanguageViewModel>)list2, (Func<HrmLeaveMultiLanguageViewModel, bool>)((HrmLeaveMultiLanguageViewModel c) => c.LanguageId == defLangId)) != null) ? Enumerable.FirstOrDefault<HrmLeaveMultiLanguageViewModel>((IEnumerable<HrmLeaveMultiLanguageViewModel>)list2, (Func<HrmLeaveMultiLanguageViewModel, bool>)((HrmLeaveMultiLanguageViewModel c) => c.LanguageId == defLangId)).Reason : null);
					if (!model.IsEdit)
					{
						if (!VersionBuyer.Leave && Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.HRMMobspSelectLeaveCnt()).GetValueOrDefault() > 5)
						{
							ServiceResult<HrmLeaveInsertEditResaultViewModel> result7 = new ServiceResult<HrmLeaveInsertEditResaultViewModel>
							{
								Message = Messages.MobMsgSimpleVersionBuy,
								Data = null,
								Status = ServiceResultStatus.Fail
							};
							cRMEntities?.Dispose();
							return result7;
						}
						model.LeaveTypeId = 2;
						model.LeaveStatusId = 1;
					}
					model.RequestUserId = userId;
					ObjectParameter objectParameter = new ObjectParameter("Result", -1);
					Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.HRMMobspInsertUpdateLeave(model.LeaveId, model.LeaveTypeId, model.RequestUserId, model.ReplaceUserId, model.FromDateTime, model.FromDate, model.ToDateTime, model.ToDate, model.DayCount, model.FromTime, model.ToTime, model.HourCount, model.Reason, null, null, null, null, null, null, null, null, null, null, null, null, model.LeaveStatusId, null, model.MsgLangValue, userId, value2, value3, value, registerDatePersian, appType, num, defLangId, objectParameter));
					if (objectParameter != null)
					{
						if (objectParameter.Value.ToString() == "-1")
						{
							message = Messages.msgErrorRunFunction;
							status = ServiceResultStatus.Error;
						}
						else
						{
							int value4 = Convert.ToInt32(objectParameter.Value);
							HRMMobspSelectLeave_Result hRMMobspSelectLeave_Result = Enumerable.FirstOrDefault<HRMMobspSelectLeave_Result>((IEnumerable<HRMMobspSelectLeave_Result>)cRMEntities.HRMMobspSelectLeave(userId, value4, null, userId, null, null, 1, 1, num, defLangId, null));
							if (hRMMobspSelectLeave_Result != null)
							{
								hrmLeaveInsertEditResaultViewModel.LeaveId = hRMMobspSelectLeave_Result.LeaveId;
								hrmLeaveInsertEditResaultViewModel.VerificationWorkFlowId = hRMMobspSelectLeave_Result.VerificationWorkFlowId;
								hrmLeaveInsertEditResaultViewModel.UserDepartmentLeaveVerificationWorkFlowId = hRMMobspSelectLeave_Result.UserDepartmentLeaveVerificationWorkFlowId;
								hrmLeaveInsertEditResaultViewModel.UserDepartmentMissionVerificationWorkFlowId = hRMMobspSelectLeave_Result.UserDepartmentMissionVerificationWorkFlowId;
								hrmLeaveInsertEditResaultViewModel.LeaveTypeOpr = hRMMobspSelectLeave_Result.LeaveTypeOpr;
							}
							message = Messages.MobMsgSuccessAction;
							status = ServiceResultStatus.Success;
						}
					}
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					hrmLeaveInsertEditResaultViewModel = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				hrmLeaveInsertEditResaultViewModel = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e3)
		{
			message = Messages.MobMsgErrorDoneOperation;
			hrmLeaveInsertEditResaultViewModel = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e3);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<HrmLeaveInsertEditResaultViewModel>
		{
			Message = message,
			Data = hrmLeaveInsertEditResaultViewModel,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<HrmLeaveInsertEditResaultViewModel> HourlyMissionInsertEdit(HrmLeaveInsertEditViewModel model)
	{
		int result = 1065;
		if (model.LanguageId.HasValue)
		{
			int.TryParse(model.LanguageId.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangId);
		CRMEntities cRMEntities = null;
		HrmLeaveInsertEditResaultViewModel hrmLeaveInsertEditResaultViewModel = new HrmLeaveInsertEditResaultViewModel();
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int num = ((result > 0) ? result : defLangId);
		baseInfo.SetCulture(num);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					cRMEntities = new CRMEntities();
					DateTime now = DateTime.Now;
					int userId = token2.userId;
					DateTime value = now;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					short value2 = short.Parse(now.ToString("yyyy", new PersianCulture()));
					short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
					string appType = Mobile.Classes.Configuration.AppType;
					List<HRMMobspSelectLanguages_Result> list = Enumerable.ToList<HRMMobspSelectLanguages_Result>((IEnumerable<HRMMobspSelectLanguages_Result>)cRMEntities.HRMMobspSelectLanguages());
					if (string.IsNullOrEmpty(model.RequestDate))
					{
						ServiceResult<HrmLeaveInsertEditResaultViewModel> result2 = new ServiceResult<HrmLeaveInsertEditResaultViewModel>
						{
							Message = Messages.msgErrorLeaveRequestDateNotEntered,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
						cRMEntities?.Dispose();
						return result2;
					}
					if (string.IsNullOrEmpty(model.FromTime))
					{
						ServiceResult<HrmLeaveInsertEditResaultViewModel> result3 = new ServiceResult<HrmLeaveInsertEditResaultViewModel>
						{
							Message = Messages.msgErrorLeaveFromTimeNotEntered,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
						cRMEntities?.Dispose();
						return result3;
					}
					if (string.IsNullOrEmpty(model.ToTime))
					{
						ServiceResult<HrmLeaveInsertEditResaultViewModel> result4 = new ServiceResult<HrmLeaveInsertEditResaultViewModel>
						{
							Message = Messages.msgErrorLeaveToTimeNotEntered,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
						cRMEntities?.Dispose();
						return result4;
					}
					DateTime dateTime = default(DateTime);
					string text = "";
					try
					{
						string text2 = "00:00:00";
						if (!string.IsNullOrEmpty(model.RequestDate))
						{
							text2 = model.FromTime + ":00";
						}
						text = PersianDate.GetFormatetdDate(model.RequestDate.Replace("/", ""));
						dateTime = num switch
						{
							1065 => DateTime.Parse(text + " " + text2, new PersianCulture()), 
							1025 => DateTime.Parse(text + " " + text2, new CultureInfo("ar-SA")), 
							_ => DateTime.Parse(text + " " + text2, new CultureInfo("en-US")), 
						};
						model.FromDateTime = dateTime;
						model.FromDate = dateTime.ToString("yyyyMMdd", new CultureInfo("fa-IR"));
					}
					catch (Exception e)
					{
						ErrorSignal.FromCurrentContext().Raise(e);
						ServiceResult<HrmLeaveInsertEditResaultViewModel> result5 = new ServiceResult<HrmLeaveInsertEditResaultViewModel>
						{
							Message = Messages.ErrorFormatTime,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
						cRMEntities?.Dispose();
						return result5;
					}
					try
					{
						string text3 = "00:00:00";
						if (!string.IsNullOrEmpty(model.RequestDate))
						{
							text3 = model.ToTime + ":00";
						}
						text = PersianDate.GetFormatetdDate(model.RequestDate.Replace("/", ""));
						dateTime = num switch
						{
							1065 => DateTime.Parse(text + " " + text3, new PersianCulture()), 
							1025 => DateTime.Parse(text + " " + text3, new CultureInfo("ar-SA")), 
							_ => DateTime.Parse(text + " " + text3, new CultureInfo("en-US")), 
						};
						model.ToDateTime = dateTime;
						model.ToDate = dateTime.ToString("yyyyMMdd", new CultureInfo("fa-IR"));
					}
					catch (Exception e2)
					{
						ErrorSignal.FromCurrentContext().Raise(e2);
						ServiceResult<HrmLeaveInsertEditResaultViewModel> result6 = new ServiceResult<HrmLeaveInsertEditResaultViewModel>
						{
							Message = Messages.ErrorFormatTime,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
						cRMEntities?.Dispose();
						return result6;
					}
					List<HrmLeaveMultiLanguageViewModel> list2 = new List<HrmLeaveMultiLanguageViewModel>();
					foreach (HRMMobspSelectLanguages_Result item in list)
					{
						HrmLeaveMultiLanguageViewModel hrmLeaveMultiLanguageViewModel = new HrmLeaveMultiLanguageViewModel();
						hrmLeaveMultiLanguageViewModel.LanguageId = item.LanguageID;
						hrmLeaveMultiLanguageViewModel.Reason = model.Reason;
						hrmLeaveMultiLanguageViewModel.Place = model.Place;
						list2.Add(hrmLeaveMultiLanguageViewModel);
					}
					model.MsgLangValue = JsonConvert.SerializeObject(Enumerable.ToList<HrmLeaveMultiLanguageViewModel>((IEnumerable<HrmLeaveMultiLanguageViewModel>)list2));
					model.Reason = ((Enumerable.FirstOrDefault<HrmLeaveMultiLanguageViewModel>((IEnumerable<HrmLeaveMultiLanguageViewModel>)list2, (Func<HrmLeaveMultiLanguageViewModel, bool>)((HrmLeaveMultiLanguageViewModel c) => c.LanguageId == defLangId)) != null) ? Enumerable.FirstOrDefault<HrmLeaveMultiLanguageViewModel>((IEnumerable<HrmLeaveMultiLanguageViewModel>)list2, (Func<HrmLeaveMultiLanguageViewModel, bool>)((HrmLeaveMultiLanguageViewModel c) => c.LanguageId == defLangId)).Reason : null);
					model.Place = ((Enumerable.FirstOrDefault<HrmLeaveMultiLanguageViewModel>((IEnumerable<HrmLeaveMultiLanguageViewModel>)list2, (Func<HrmLeaveMultiLanguageViewModel, bool>)((HrmLeaveMultiLanguageViewModel c) => c.LanguageId == defLangId)) != null) ? Enumerable.FirstOrDefault<HrmLeaveMultiLanguageViewModel>((IEnumerable<HrmLeaveMultiLanguageViewModel>)list2, (Func<HrmLeaveMultiLanguageViewModel, bool>)((HrmLeaveMultiLanguageViewModel c) => c.LanguageId == defLangId)).Place : null);
					if (!model.IsEdit)
					{
						if (!VersionBuyer.Leave && Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.HRMMobspSelectLeaveCnt()).GetValueOrDefault() > 5)
						{
							ServiceResult<HrmLeaveInsertEditResaultViewModel> result7 = new ServiceResult<HrmLeaveInsertEditResaultViewModel>
							{
								Message = Messages.MobMsgSimpleVersionBuy,
								Data = null,
								Status = ServiceResultStatus.Fail
							};
							cRMEntities?.Dispose();
							return result7;
						}
						model.LeaveTypeId = 3;
						model.DayCount = 1;
						model.LeaveStatusId = 1;
					}
					model.RequestUserId = userId;
					ObjectParameter objectParameter = new ObjectParameter("Result", -1);
					Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.HRMMobspInsertUpdateLeave(model.LeaveId, model.LeaveTypeId, model.RequestUserId, model.ReplaceUserId, model.FromDateTime, model.FromDate, model.ToDateTime, model.ToDate, model.DayCount, model.FromTime, model.ToTime, model.HourCount, model.Reason, null, model.KindId, model.Place, model.PlaceCoordinateLatitude, model.PlaceCoordinateLongitude, model.PlaceCoordinateZoomLevel, model.CompanyId, model.CountryId, model.ProvinceId, model.CityId, model.VehicleTypeId, model.StayTypeId, model.LeaveStatusId, null, model.MsgLangValue, userId, value2, value3, value, registerDatePersian, appType, num, defLangId, objectParameter));
					if (objectParameter != null)
					{
						if (objectParameter.Value.ToString() == "-1")
						{
							message = Messages.msgErrorRunFunction;
							status = ServiceResultStatus.Error;
						}
						else
						{
							int value4 = Convert.ToInt32(objectParameter.Value);
							HRMMobspSelectLeave_Result hRMMobspSelectLeave_Result = Enumerable.FirstOrDefault<HRMMobspSelectLeave_Result>((IEnumerable<HRMMobspSelectLeave_Result>)cRMEntities.HRMMobspSelectLeave(userId, value4, null, userId, null, null, 1, 1, num, defLangId, null));
							if (hRMMobspSelectLeave_Result != null)
							{
								hrmLeaveInsertEditResaultViewModel.LeaveId = hRMMobspSelectLeave_Result.LeaveId;
								hrmLeaveInsertEditResaultViewModel.VerificationWorkFlowId = hRMMobspSelectLeave_Result.VerificationWorkFlowId;
								hrmLeaveInsertEditResaultViewModel.UserDepartmentLeaveVerificationWorkFlowId = hRMMobspSelectLeave_Result.UserDepartmentLeaveVerificationWorkFlowId;
								hrmLeaveInsertEditResaultViewModel.UserDepartmentMissionVerificationWorkFlowId = hRMMobspSelectLeave_Result.UserDepartmentMissionVerificationWorkFlowId;
								hrmLeaveInsertEditResaultViewModel.LeaveTypeOpr = hRMMobspSelectLeave_Result.LeaveTypeOpr;
							}
							message = Messages.MobMsgSuccessAction;
							status = ServiceResultStatus.Success;
						}
					}
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					hrmLeaveInsertEditResaultViewModel = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				hrmLeaveInsertEditResaultViewModel = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e3)
		{
			message = Messages.MobMsgErrorDoneOperation;
			hrmLeaveInsertEditResaultViewModel = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e3);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<HrmLeaveInsertEditResaultViewModel>
		{
			Message = message,
			Data = hrmLeaveInsertEditResaultViewModel,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<HrmLeaveInsertEditResaultViewModel> DailyMissionInsertEdit(HrmLeaveInsertEditViewModel model)
	{
		int result = 1065;
		if (model.LanguageId.HasValue)
		{
			int.TryParse(model.LanguageId.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangId);
		CRMEntities cRMEntities = null;
		HrmLeaveInsertEditResaultViewModel hrmLeaveInsertEditResaultViewModel = new HrmLeaveInsertEditResaultViewModel();
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int num = ((result > 0) ? result : defLangId);
		baseInfo.SetCulture(num);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					cRMEntities = new CRMEntities();
					DateTime now = DateTime.Now;
					int userId = token2.userId;
					DateTime value = now;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					short value2 = short.Parse(now.ToString("yyyy", new PersianCulture()));
					short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
					string appType = Mobile.Classes.Configuration.AppType;
					List<HRMMobspSelectLanguages_Result> list = Enumerable.ToList<HRMMobspSelectLanguages_Result>((IEnumerable<HRMMobspSelectLanguages_Result>)cRMEntities.HRMMobspSelectLanguages());
					if (string.IsNullOrEmpty(model.FromDate))
					{
						ServiceResult<HrmLeaveInsertEditResaultViewModel> result2 = new ServiceResult<HrmLeaveInsertEditResaultViewModel>
						{
							Message = Messages.msgErrorLeaveFromTimeNotEntered,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
						cRMEntities?.Dispose();
						return result2;
					}
					if (string.IsNullOrEmpty(model.ToDate))
					{
						ServiceResult<HrmLeaveInsertEditResaultViewModel> result3 = new ServiceResult<HrmLeaveInsertEditResaultViewModel>
						{
							Message = Messages.msgErrorLeaveToTimeNotEntered,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
						cRMEntities?.Dispose();
						return result3;
					}
					DateTime dateTime = default(DateTime);
					string text = "";
					try
					{
						string text2 = "00:00:00";
						text = PersianDate.GetFormatetdDate(model.FromDate.Replace("/", ""));
						dateTime = num switch
						{
							1065 => DateTime.Parse(text + " " + text2, new PersianCulture()), 
							1025 => DateTime.Parse(text + " " + text2, new CultureInfo("ar-SA")), 
							_ => DateTime.Parse(text + " " + text2, new CultureInfo("en-US")), 
						};
						model.FromDateTime = dateTime;
						model.FromDate = dateTime.ToString("yyyyMMdd", new CultureInfo("fa-IR"));
					}
					catch (Exception e)
					{
						ErrorSignal.FromCurrentContext().Raise(e);
						ServiceResult<HrmLeaveInsertEditResaultViewModel> result4 = new ServiceResult<HrmLeaveInsertEditResaultViewModel>
						{
							Message = Messages.ErrorFormatTime,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
						cRMEntities?.Dispose();
						return result4;
					}
					try
					{
						string text3 = "23:59:59";
						text = PersianDate.GetFormatetdDate(model.ToDate.Replace("/", ""));
						dateTime = num switch
						{
							1065 => DateTime.Parse(text + " " + text3, new PersianCulture()), 
							1025 => DateTime.Parse(text + " " + text3, new CultureInfo("ar-SA")), 
							_ => DateTime.Parse(text + " " + text3, new CultureInfo("en-US")), 
						};
						model.ToDateTime = dateTime;
						model.ToDate = dateTime.ToString("yyyyMMdd", new CultureInfo("fa-IR"));
					}
					catch (Exception e2)
					{
						ErrorSignal.FromCurrentContext().Raise(e2);
						ServiceResult<HrmLeaveInsertEditResaultViewModel> result5 = new ServiceResult<HrmLeaveInsertEditResaultViewModel>
						{
							Message = Messages.ErrorFormatTime,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
						cRMEntities?.Dispose();
						return result5;
					}
					if (model.FromDateTime.Value.Date > model.ToDateTime.Value.Date)
					{
						ServiceResult<HrmLeaveInsertEditResaultViewModel> result6 = new ServiceResult<HrmLeaveInsertEditResaultViewModel>
						{
							Message = Messages.MsgStartDateCanNotBeAfterToDate,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
						cRMEntities?.Dispose();
						return result6;
					}
					List<HrmLeaveMultiLanguageViewModel> list2 = new List<HrmLeaveMultiLanguageViewModel>();
					foreach (HRMMobspSelectLanguages_Result item in list)
					{
						HrmLeaveMultiLanguageViewModel hrmLeaveMultiLanguageViewModel = new HrmLeaveMultiLanguageViewModel();
						hrmLeaveMultiLanguageViewModel.LanguageId = item.LanguageID;
						hrmLeaveMultiLanguageViewModel.Reason = model.Reason;
						hrmLeaveMultiLanguageViewModel.Place = model.Place;
						list2.Add(hrmLeaveMultiLanguageViewModel);
					}
					model.MsgLangValue = JsonConvert.SerializeObject(Enumerable.ToList<HrmLeaveMultiLanguageViewModel>((IEnumerable<HrmLeaveMultiLanguageViewModel>)list2));
					model.Reason = ((Enumerable.FirstOrDefault<HrmLeaveMultiLanguageViewModel>((IEnumerable<HrmLeaveMultiLanguageViewModel>)list2, (Func<HrmLeaveMultiLanguageViewModel, bool>)((HrmLeaveMultiLanguageViewModel c) => c.LanguageId == defLangId)) != null) ? Enumerable.FirstOrDefault<HrmLeaveMultiLanguageViewModel>((IEnumerable<HrmLeaveMultiLanguageViewModel>)list2, (Func<HrmLeaveMultiLanguageViewModel, bool>)((HrmLeaveMultiLanguageViewModel c) => c.LanguageId == defLangId)).Reason : null);
					model.Place = ((Enumerable.FirstOrDefault<HrmLeaveMultiLanguageViewModel>((IEnumerable<HrmLeaveMultiLanguageViewModel>)list2, (Func<HrmLeaveMultiLanguageViewModel, bool>)((HrmLeaveMultiLanguageViewModel c) => c.LanguageId == defLangId)) != null) ? Enumerable.FirstOrDefault<HrmLeaveMultiLanguageViewModel>((IEnumerable<HrmLeaveMultiLanguageViewModel>)list2, (Func<HrmLeaveMultiLanguageViewModel, bool>)((HrmLeaveMultiLanguageViewModel c) => c.LanguageId == defLangId)).Place : null);
					if (!model.IsEdit)
					{
						if (!VersionBuyer.Leave && Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.HRMMobspSelectLeaveCnt()).GetValueOrDefault() > 5)
						{
							ServiceResult<HrmLeaveInsertEditResaultViewModel> result7 = new ServiceResult<HrmLeaveInsertEditResaultViewModel>
							{
								Message = Messages.MobMsgSimpleVersionBuy,
								Data = null,
								Status = ServiceResultStatus.Fail
							};
							cRMEntities?.Dispose();
							return result7;
						}
						model.LeaveTypeId = 4;
						model.LeaveStatusId = 1;
					}
					model.RequestUserId = userId;
					ObjectParameter objectParameter = new ObjectParameter("Result", -1);
					Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.HRMMobspInsertUpdateLeave(model.LeaveId, model.LeaveTypeId, model.RequestUserId, model.ReplaceUserId, model.FromDateTime, model.FromDate, model.ToDateTime, model.ToDate, model.DayCount, null, null, null, model.Reason, null, model.KindId, model.Place, model.PlaceCoordinateLatitude, model.PlaceCoordinateLongitude, model.PlaceCoordinateZoomLevel, model.CompanyId, model.CountryId, model.ProvinceId, model.CityId, model.VehicleTypeId, model.StayTypeId, model.LeaveStatusId, null, model.MsgLangValue, userId, value2, value3, value, registerDatePersian, appType, num, defLangId, objectParameter));
					if (objectParameter != null)
					{
						if (objectParameter.Value.ToString() == "-1")
						{
							message = Messages.msgErrorRunFunction;
							status = ServiceResultStatus.Error;
						}
						else
						{
							int value4 = Convert.ToInt32(objectParameter.Value);
							HRMMobspSelectLeave_Result hRMMobspSelectLeave_Result = Enumerable.FirstOrDefault<HRMMobspSelectLeave_Result>((IEnumerable<HRMMobspSelectLeave_Result>)cRMEntities.HRMMobspSelectLeave(userId, value4, null, userId, null, null, 1, 1, num, defLangId, null));
							if (hRMMobspSelectLeave_Result != null)
							{
								hrmLeaveInsertEditResaultViewModel.LeaveId = hRMMobspSelectLeave_Result.LeaveId;
								hrmLeaveInsertEditResaultViewModel.VerificationWorkFlowId = hRMMobspSelectLeave_Result.VerificationWorkFlowId;
								hrmLeaveInsertEditResaultViewModel.UserDepartmentLeaveVerificationWorkFlowId = hRMMobspSelectLeave_Result.UserDepartmentLeaveVerificationWorkFlowId;
								hrmLeaveInsertEditResaultViewModel.UserDepartmentMissionVerificationWorkFlowId = hRMMobspSelectLeave_Result.UserDepartmentMissionVerificationWorkFlowId;
								hrmLeaveInsertEditResaultViewModel.LeaveTypeOpr = hRMMobspSelectLeave_Result.LeaveTypeOpr;
							}
							message = Messages.MobMsgSuccessAction;
							status = ServiceResultStatus.Success;
						}
					}
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					hrmLeaveInsertEditResaultViewModel = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				hrmLeaveInsertEditResaultViewModel = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e3)
		{
			message = Messages.MobMsgErrorDoneOperation;
			hrmLeaveInsertEditResaultViewModel = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e3);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<HrmLeaveInsertEditResaultViewModel>
		{
			Message = message,
			Data = hrmLeaveInsertEditResaultViewModel,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<HRMMobspSelectLeave_Result>> SelectLeave(HrmSelectLeaveParamsViewModel model)
	{
		int result = 1065;
		if (model.LanguageID.HasValue)
		{
			int.TryParse(model.LanguageID.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		List<HRMMobspSelectLeave_Result> data;
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new Common().GetToken(token) != null)
				{
					cRMEntities = new CRMEntities();
					data = Enumerable.ToList<HRMMobspSelectLeave_Result>((IEnumerable<HRMMobspSelectLeave_Result>)cRMEntities.HRMMobspSelectLeave(model.CrmUserId, model.LeaveId, model.LeaveTypeId, model.UserId, model.FDateTime, model.TDateTime, model.PageNumber, model.PageSize, result, result2, model.CenterId));
					message = Messages.MobMsgSuccessAction;
					status = ServiceResultStatus.Success;
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					data = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				data = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<List<HRMMobspSelectLeave_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<string> DeleteLeave(int leaveId, int? ln = 1065)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		string data;
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new Common().GetToken(token) != null)
				{
					cRMEntities = new CRMEntities();
					if (Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.HRMMobspDeleteLeave(leaveId)).GetValueOrDefault() == 1)
					{
						data = null;
						message = Messages.HrmMobMsgSuccessAction;
						status = ServiceResultStatus.Success;
					}
					else
					{
						data = null;
						message = Messages.msgErrorRunFunction;
						status = ServiceResultStatus.Fail;
					}
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					data = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				data = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<string>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<int> SelectLeaveCnt()
	{
		int num = 1065;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		CRMEntities cRMEntities = null;
		int data = 0;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((num > 0) ? num : result);
		baseInfo.SetCulture(culture);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new Common().GetToken(token) != null)
				{
					cRMEntities = new CRMEntities();
					data = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.HRMMobspSelectLeaveCnt()).GetValueOrDefault();
					message = Messages.MobMsgSuccessAction;
					status = ServiceResultStatus.Success;
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					data = 0;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				data = 0;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = 0;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<int>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}
}
