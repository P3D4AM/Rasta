using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using CRM.General.Calendar;
using CRM.General.Utilities;
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

public class LeaveController : ApiController
{
	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<LeaveDetailsResultViewModel> GetLeaveDetails(int leaveId, int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		LeaveDetailsResultViewModel leaveDetailsResultViewModel = null;
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
				if (new Common().GetToken(token) != null)
				{
					cRMEntities = new CRMEntities();
					leaveDetailsResultViewModel = new LeaveDetailsResultViewModel();
					MobspSelectLeave_Result mobspSelectLeave_Result = Enumerable.FirstOrDefault<MobspSelectLeave_Result>((IEnumerable<MobspSelectLeave_Result>)cRMEntities.MobspSelectLeave(null, leaveId, null, null, null, null, null, null, result, result2, null, cId));
					if (mobspSelectLeave_Result != null)
					{
						leaveDetailsResultViewModel.Leave = mobspSelectLeave_Result;
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
						MobspReturnLeaveSummary_Result mobspReturnLeaveSummary_Result = Enumerable.FirstOrDefault<MobspReturnLeaveSummary_Result>((IEnumerable<MobspReturnLeaveSummary_Result>)cRMEntities.MobspReturnLeaveSummary(mobspSelectLeave_Result.LeaveTypeOpr, mobspSelectLeave_Result.RequestUserId, value, value2, value3, value4));
						LeaveSummaryViewModel leaveSummaryViewModel = new LeaveSummaryViewModel();
						leaveSummaryViewModel.MonthlyDailySum = mobspReturnLeaveSummary_Result.MonthlyDailySum.GetValueOrDefault();
						leaveSummaryViewModel.MonthlyHourlySumInMin = mobspReturnLeaveSummary_Result.MonthlyHourlySumInMin.GetValueOrDefault();
						leaveSummaryViewModel.MonthlyHourlySumTxt = mobspReturnLeaveSummary_Result.MonthlyHourlySumTxt;
						leaveSummaryViewModel.YearlyDailySum = mobspReturnLeaveSummary_Result.YearlyDailySum.GetValueOrDefault();
						leaveSummaryViewModel.YearlyHourlySumInMin = mobspReturnLeaveSummary_Result.YearlyHourlySumInMin.GetValueOrDefault();
						leaveSummaryViewModel.YealyHourlySumTxt = mobspReturnLeaveSummary_Result.YealyHourlySumTxt;
						leaveSummaryViewModel.TotallyDailySum = mobspReturnLeaveSummary_Result.TotallyDailySum.GetValueOrDefault();
						leaveSummaryViewModel.TotallyHourlySumInMin = mobspReturnLeaveSummary_Result.TotallyHourlySumInMin.GetValueOrDefault();
						leaveSummaryViewModel.TotallyHourlySumTxt = mobspReturnLeaveSummary_Result.TotallyHourlySumTxt;
						if (leaveSummaryViewModel.MonthlyDailySum > 0)
						{
							leaveSummaryViewModel.MonthlyLeaveStr = leaveSummaryViewModel.MonthlyDailySum + " " + Labels.lblDay;
						}
						if (leaveSummaryViewModel.MonthlyHourlySumInMin > 0)
						{
							if (!string.IsNullOrEmpty(leaveSummaryViewModel.MonthlyLeaveStr))
							{
								leaveSummaryViewModel.MonthlyLeaveStr = leaveSummaryViewModel.MonthlyLeaveStr + " " + Labels.lblAnd + " ";
							}
							leaveSummaryViewModel.MonthlyLeaveStr += DateTimeClass.ConvertMinToHourAndMin(leaveSummaryViewModel.MonthlyHourlySumInMin);
						}
						if (leaveSummaryViewModel.YearlyDailySum > 0)
						{
							leaveSummaryViewModel.YearlyLeaveStr = leaveSummaryViewModel.YearlyDailySum + " " + Labels.lblDay;
						}
						if (leaveSummaryViewModel.YearlyHourlySumInMin > 0)
						{
							if (!string.IsNullOrEmpty(leaveSummaryViewModel.YearlyLeaveStr))
							{
								leaveSummaryViewModel.YearlyLeaveStr = leaveSummaryViewModel.YearlyLeaveStr + " " + Labels.lblAnd + " ";
							}
							leaveSummaryViewModel.YearlyLeaveStr += DateTimeClass.ConvertMinToHourAndMin(leaveSummaryViewModel.YearlyHourlySumInMin);
						}
						if (leaveSummaryViewModel.TotallyDailySum > 0)
						{
							leaveSummaryViewModel.TotallyLeaveStr = leaveSummaryViewModel.TotallyDailySum + " " + Labels.lblDay;
						}
						if (leaveSummaryViewModel.TotallyHourlySumInMin > 0)
						{
							if (!string.IsNullOrEmpty(leaveSummaryViewModel.TotallyLeaveStr))
							{
								leaveSummaryViewModel.TotallyLeaveStr = leaveSummaryViewModel.TotallyLeaveStr + " " + Labels.lblAnd + " ";
							}
							leaveSummaryViewModel.TotallyLeaveStr += DateTimeClass.ConvertMinToHourAndMin(leaveSummaryViewModel.TotallyHourlySumInMin);
						}
						leaveDetailsResultViewModel.Summary = leaveSummaryViewModel;
						leaveDetailsResultViewModel.CalendarEvents = Enumerable.ToList<MobspSelectClosedCalendarEvents_Result>((IEnumerable<MobspSelectClosedCalendarEvents_Result>)cRMEntities.MobspSelectClosedCalendarEvents(value3, value4, result, result2));
						leaveDetailsResultViewModel.RequestUser = Enumerable.FirstOrDefault<MobspSelectUsersById_Result>((IEnumerable<MobspSelectUsersById_Result>)cRMEntities.MobspSelectUsersById(mobspSelectLeave_Result.RequestUserId, result, result2, cId));
						message = Messages.MobMsgSuccessAction;
						status = ServiceResultStatus.Success;
					}
					else
					{
						message = Messages.MobMsgErorrNotFound;
						leaveDetailsResultViewModel = null;
						status = ServiceResultStatus.Fail;
					}
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					leaveDetailsResultViewModel = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				leaveDetailsResultViewModel = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			leaveDetailsResultViewModel = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<LeaveDetailsResultViewModel>
		{
			Message = message,
			Data = leaveDetailsResultViewModel,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<int> ReturnLeaveType(int leaveId, int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		int data = 0;
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
				if (new Common().GetToken(token) != null)
				{
					cRMEntities = new CRMEntities();
					CRMEntities cRMEntities2 = cRMEntities;
					int? leaveId2 = leaveId;
					int? languageID = num;
					int? defaultLanguageID = result2;
					MobspSelectLeave_Result mobspSelectLeave_Result = Enumerable.FirstOrDefault<MobspSelectLeave_Result>((IEnumerable<MobspSelectLeave_Result>)cRMEntities2.MobspSelectLeave(null, leaveId2, null, null, null, null, null, null, languageID, defaultLanguageID, null, cId));
					if (mobspSelectLeave_Result != null)
					{
						data = mobspSelectLeave_Result.LeaveTypeId.GetValueOrDefault();
						message = Messages.MobMsgSuccessAction;
						status = ServiceResultStatus.Success;
					}
					else
					{
						message = Messages.MobMsgErorrNotFound;
						data = 0;
						status = ServiceResultStatus.Fail;
					}
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
					if (Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.MobspDeleteLeave(leaveId)).GetValueOrDefault() == 1)
					{
						data = null;
						message = Messages.MobMsgSuccessAction;
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
	public ServiceResult<string> LeaveVerifyExit(int leaveId, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		string data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new Common().GetToken(token) != null)
				{
					cRMEntities = new CRMEntities();
					cRMEntities.MobspLeaveVerifyExit(leaveId);
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
		return new ServiceResult<string>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<string> HourlyLeaveInsertEdit(LeaveInsertEditViewModel model)
	{
		int result = 1065;
		if (model.LanguageId.HasValue)
		{
			int.TryParse(model.LanguageId.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangId);
		CRMEntities cRMEntities = null;
		string data = null;
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
					List<MobspSelectLanguages_Result> list = Enumerable.ToList<MobspSelectLanguages_Result>((IEnumerable<MobspSelectLanguages_Result>)cRMEntities.MobspSelectLanguages());
					if (string.IsNullOrEmpty(model.RequestDate))
					{
						ServiceResult<string> result2 = new ServiceResult<string>
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
						ServiceResult<string> result3 = new ServiceResult<string>
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
						ServiceResult<string> result4 = new ServiceResult<string>
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
						ServiceResult<string> result5 = new ServiceResult<string>
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
						ServiceResult<string> result6 = new ServiceResult<string>
						{
							Message = Messages.ErrorFormatTime,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
						cRMEntities?.Dispose();
						return result6;
					}
					List<LeaveMultiLanguageViewModel> list2 = new List<LeaveMultiLanguageViewModel>();
					foreach (MobspSelectLanguages_Result item in list)
					{
						LeaveMultiLanguageViewModel leaveMultiLanguageViewModel = new LeaveMultiLanguageViewModel();
						leaveMultiLanguageViewModel.LanguageId = item.LanguageID;
						leaveMultiLanguageViewModel.Reason = model.Reason;
						list2.Add(leaveMultiLanguageViewModel);
					}
					model.MsgLangValue = JsonConvert.SerializeObject(Enumerable.ToList<LeaveMultiLanguageViewModel>((IEnumerable<LeaveMultiLanguageViewModel>)list2));
					model.Reason = ((Enumerable.FirstOrDefault<LeaveMultiLanguageViewModel>((IEnumerable<LeaveMultiLanguageViewModel>)list2, (Func<LeaveMultiLanguageViewModel, bool>)((LeaveMultiLanguageViewModel c) => c.LanguageId == defLangId)) != null) ? Enumerable.FirstOrDefault<LeaveMultiLanguageViewModel>((IEnumerable<LeaveMultiLanguageViewModel>)list2, (Func<LeaveMultiLanguageViewModel, bool>)((LeaveMultiLanguageViewModel c) => c.LanguageId == defLangId)).Reason : null);
					if (!model.IsEdit)
					{
						if (!VersionBuyer.Leave && Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.MobspSelectLeaveCnt()).GetValueOrDefault() > 6)
						{
							ServiceResult<string> result7 = new ServiceResult<string>
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
						model.RequestUserId = userId;
					}
					ObjectParameter objectParameter = new ObjectParameter("Result", -1);
					Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.MobspInsertUpdateLeave(model.LeaveId, model.LeaveTypeId, model.RequestUserId, model.ReplaceUserId, model.FromDateTime, model.FromDate, model.ToDateTime, model.ToDate, model.DayCount, model.FromTime, model.ToTime, model.HourCount, model.Reason, null, null, null, null, null, null, null, null, null, null, null, null, model.LeaveStatusId, null, model.MsgLangValue, userId, value2, value3, value, registerDatePersian, appType, num, defLangId, objectParameter));
					if (objectParameter != null)
					{
						if (objectParameter.Value.ToString() == "-1")
						{
							message = Messages.msgErrorRunFunction;
							status = ServiceResultStatus.Error;
						}
						else
						{
							message = Messages.MobMsgSuccessAction;
							status = ServiceResultStatus.Success;
						}
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
		catch (Exception e3)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e3);
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
	public ServiceResult<string> DailyLeaveInsertEdit(LeaveInsertEditViewModel model)
	{
		int result = 1065;
		if (model.LanguageId.HasValue)
		{
			int.TryParse(model.LanguageId.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangId);
		CRMEntities cRMEntities = null;
		string data = null;
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
					List<MobspSelectLanguages_Result> list = Enumerable.ToList<MobspSelectLanguages_Result>((IEnumerable<MobspSelectLanguages_Result>)cRMEntities.MobspSelectLanguages());
					if (string.IsNullOrEmpty(model.FromDate))
					{
						ServiceResult<string> result2 = new ServiceResult<string>
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
						ServiceResult<string> result3 = new ServiceResult<string>
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
						ServiceResult<string> result4 = new ServiceResult<string>
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
						ServiceResult<string> result5 = new ServiceResult<string>
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
						ServiceResult<string> result6 = new ServiceResult<string>
						{
							Message = Messages.MsgStartDateCanNotBeAfterToDate,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
						cRMEntities?.Dispose();
						return result6;
					}
					List<LeaveMultiLanguageViewModel> list2 = new List<LeaveMultiLanguageViewModel>();
					foreach (MobspSelectLanguages_Result item in list)
					{
						LeaveMultiLanguageViewModel leaveMultiLanguageViewModel = new LeaveMultiLanguageViewModel();
						leaveMultiLanguageViewModel.LanguageId = item.LanguageID;
						leaveMultiLanguageViewModel.Reason = model.Reason;
						list2.Add(leaveMultiLanguageViewModel);
					}
					model.MsgLangValue = JsonConvert.SerializeObject(Enumerable.ToList<LeaveMultiLanguageViewModel>((IEnumerable<LeaveMultiLanguageViewModel>)list2));
					model.Reason = ((Enumerable.FirstOrDefault<LeaveMultiLanguageViewModel>((IEnumerable<LeaveMultiLanguageViewModel>)list2, (Func<LeaveMultiLanguageViewModel, bool>)((LeaveMultiLanguageViewModel c) => c.LanguageId == defLangId)) != null) ? Enumerable.FirstOrDefault<LeaveMultiLanguageViewModel>((IEnumerable<LeaveMultiLanguageViewModel>)list2, (Func<LeaveMultiLanguageViewModel, bool>)((LeaveMultiLanguageViewModel c) => c.LanguageId == defLangId)).Reason : null);
					if (!model.IsEdit)
					{
						if (!VersionBuyer.Leave && Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.MobspSelectLeaveCnt()).GetValueOrDefault() > 6)
						{
							ServiceResult<string> result7 = new ServiceResult<string>
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
						model.RequestUserId = userId;
					}
					ObjectParameter objectParameter = new ObjectParameter("Result", -1);
					Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.MobspInsertUpdateLeave(model.LeaveId, model.LeaveTypeId, model.RequestUserId, model.ReplaceUserId, model.FromDateTime, model.FromDate, model.ToDateTime, model.ToDate, model.DayCount, model.FromTime, model.ToTime, model.HourCount, model.Reason, null, null, null, null, null, null, null, null, null, null, null, null, model.LeaveStatusId, null, model.MsgLangValue, userId, value2, value3, value, registerDatePersian, appType, num, defLangId, objectParameter));
					if (objectParameter != null)
					{
						if (objectParameter.Value.ToString() == "-1")
						{
							message = Messages.msgErrorRunFunction;
							status = ServiceResultStatus.Error;
						}
						else
						{
							message = Messages.MobMsgSuccessAction;
							status = ServiceResultStatus.Success;
						}
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
		catch (Exception e3)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e3);
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
	public ServiceResult<string> HourlyMissionInsertEdit(LeaveInsertEditViewModel model)
	{
		int result = 1065;
		if (model.LanguageId.HasValue)
		{
			int.TryParse(model.LanguageId.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangId);
		CRMEntities cRMEntities = null;
		string data = null;
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
					List<MobspSelectLanguages_Result> list = Enumerable.ToList<MobspSelectLanguages_Result>((IEnumerable<MobspSelectLanguages_Result>)cRMEntities.MobspSelectLanguages());
					if (string.IsNullOrEmpty(model.RequestDate))
					{
						ServiceResult<string> result2 = new ServiceResult<string>
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
						ServiceResult<string> result3 = new ServiceResult<string>
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
						ServiceResult<string> result4 = new ServiceResult<string>
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
						ServiceResult<string> result5 = new ServiceResult<string>
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
						ServiceResult<string> result6 = new ServiceResult<string>
						{
							Message = Messages.ErrorFormatTime,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
						cRMEntities?.Dispose();
						return result6;
					}
					List<LeaveMultiLanguageViewModel> list2 = new List<LeaveMultiLanguageViewModel>();
					foreach (MobspSelectLanguages_Result item in list)
					{
						LeaveMultiLanguageViewModel leaveMultiLanguageViewModel = new LeaveMultiLanguageViewModel();
						leaveMultiLanguageViewModel.LanguageId = item.LanguageID;
						leaveMultiLanguageViewModel.Reason = model.Reason;
						leaveMultiLanguageViewModel.Place = model.Place;
						list2.Add(leaveMultiLanguageViewModel);
					}
					model.MsgLangValue = JsonConvert.SerializeObject(Enumerable.ToList<LeaveMultiLanguageViewModel>((IEnumerable<LeaveMultiLanguageViewModel>)list2));
					model.Reason = ((Enumerable.FirstOrDefault<LeaveMultiLanguageViewModel>((IEnumerable<LeaveMultiLanguageViewModel>)list2, (Func<LeaveMultiLanguageViewModel, bool>)((LeaveMultiLanguageViewModel c) => c.LanguageId == defLangId)) != null) ? Enumerable.FirstOrDefault<LeaveMultiLanguageViewModel>((IEnumerable<LeaveMultiLanguageViewModel>)list2, (Func<LeaveMultiLanguageViewModel, bool>)((LeaveMultiLanguageViewModel c) => c.LanguageId == defLangId)).Reason : null);
					model.Place = ((Enumerable.FirstOrDefault<LeaveMultiLanguageViewModel>((IEnumerable<LeaveMultiLanguageViewModel>)list2, (Func<LeaveMultiLanguageViewModel, bool>)((LeaveMultiLanguageViewModel c) => c.LanguageId == defLangId)) != null) ? Enumerable.FirstOrDefault<LeaveMultiLanguageViewModel>((IEnumerable<LeaveMultiLanguageViewModel>)list2, (Func<LeaveMultiLanguageViewModel, bool>)((LeaveMultiLanguageViewModel c) => c.LanguageId == defLangId)).Place : null);
					if (!model.IsEdit)
					{
						if (!VersionBuyer.Leave && Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.MobspSelectLeaveCnt()).GetValueOrDefault() > 6)
						{
							ServiceResult<string> result7 = new ServiceResult<string>
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
						model.RequestUserId = userId;
					}
					ObjectParameter objectParameter = new ObjectParameter("Result", -1);
					Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.MobspInsertUpdateLeave(model.LeaveId, model.LeaveTypeId, model.RequestUserId, model.ReplaceUserId, model.FromDateTime, model.FromDate, model.ToDateTime, model.ToDate, model.DayCount, model.FromTime, model.ToTime, model.HourCount, model.Reason, null, model.KindId, model.Place, model.PlaceCoordinateLatitude, model.PlaceCoordinateLongitude, model.PlaceCoordinateZoomLevel, model.CompanyId, model.CountryId, model.ProvinceId, model.CityId, model.VehicleTypeId, model.StayTypeId, model.LeaveStatusId, null, model.MsgLangValue, userId, value2, value3, value, registerDatePersian, appType, num, defLangId, objectParameter));
					if (objectParameter != null)
					{
						if (objectParameter.Value.ToString() == "-1")
						{
							message = Messages.msgErrorRunFunction;
							status = ServiceResultStatus.Error;
						}
						else
						{
							message = Messages.MobMsgSuccessAction;
							status = ServiceResultStatus.Success;
						}
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
		catch (Exception e3)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e3);
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
	public ServiceResult<string> DailyMissionInsertEdit(LeaveInsertEditViewModel model)
	{
		int result = 1065;
		if (model.LanguageId.HasValue)
		{
			int.TryParse(model.LanguageId.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangId);
		CRMEntities cRMEntities = null;
		string data = null;
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
					List<MobspSelectLanguages_Result> list = Enumerable.ToList<MobspSelectLanguages_Result>((IEnumerable<MobspSelectLanguages_Result>)cRMEntities.MobspSelectLanguages());
					if (string.IsNullOrEmpty(model.FromDate))
					{
						ServiceResult<string> result2 = new ServiceResult<string>
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
						ServiceResult<string> result3 = new ServiceResult<string>
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
						ServiceResult<string> result4 = new ServiceResult<string>
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
						ServiceResult<string> result5 = new ServiceResult<string>
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
						ServiceResult<string> result6 = new ServiceResult<string>
						{
							Message = Messages.MsgStartDateCanNotBeAfterToDate,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
						cRMEntities?.Dispose();
						return result6;
					}
					List<LeaveMultiLanguageViewModel> list2 = new List<LeaveMultiLanguageViewModel>();
					foreach (MobspSelectLanguages_Result item in list)
					{
						LeaveMultiLanguageViewModel leaveMultiLanguageViewModel = new LeaveMultiLanguageViewModel();
						leaveMultiLanguageViewModel.LanguageId = item.LanguageID;
						leaveMultiLanguageViewModel.Reason = model.Reason;
						leaveMultiLanguageViewModel.Place = model.Place;
						list2.Add(leaveMultiLanguageViewModel);
					}
					model.MsgLangValue = JsonConvert.SerializeObject(Enumerable.ToList<LeaveMultiLanguageViewModel>((IEnumerable<LeaveMultiLanguageViewModel>)list2));
					model.Reason = ((Enumerable.FirstOrDefault<LeaveMultiLanguageViewModel>((IEnumerable<LeaveMultiLanguageViewModel>)list2, (Func<LeaveMultiLanguageViewModel, bool>)((LeaveMultiLanguageViewModel c) => c.LanguageId == defLangId)) != null) ? Enumerable.FirstOrDefault<LeaveMultiLanguageViewModel>((IEnumerable<LeaveMultiLanguageViewModel>)list2, (Func<LeaveMultiLanguageViewModel, bool>)((LeaveMultiLanguageViewModel c) => c.LanguageId == defLangId)).Reason : null);
					model.Place = ((Enumerable.FirstOrDefault<LeaveMultiLanguageViewModel>((IEnumerable<LeaveMultiLanguageViewModel>)list2, (Func<LeaveMultiLanguageViewModel, bool>)((LeaveMultiLanguageViewModel c) => c.LanguageId == defLangId)) != null) ? Enumerable.FirstOrDefault<LeaveMultiLanguageViewModel>((IEnumerable<LeaveMultiLanguageViewModel>)list2, (Func<LeaveMultiLanguageViewModel, bool>)((LeaveMultiLanguageViewModel c) => c.LanguageId == defLangId)).Place : null);
					if (!model.IsEdit)
					{
						if (!VersionBuyer.Leave && Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.MobspSelectLeaveCnt()).GetValueOrDefault() > 6)
						{
							ServiceResult<string> result7 = new ServiceResult<string>
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
						model.RequestUserId = userId;
					}
					ObjectParameter objectParameter = new ObjectParameter("Result", -1);
					Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.MobspInsertUpdateLeave(model.LeaveId, model.LeaveTypeId, model.RequestUserId, model.ReplaceUserId, model.FromDateTime, model.FromDate, model.ToDateTime, model.ToDate, model.DayCount, null, null, null, model.Reason, null, model.KindId, model.Place, model.PlaceCoordinateLatitude, model.PlaceCoordinateLongitude, model.PlaceCoordinateZoomLevel, model.CompanyId, model.CountryId, model.ProvinceId, model.CityId, model.VehicleTypeId, model.StayTypeId, model.LeaveStatusId, null, model.MsgLangValue, userId, value2, value3, value, registerDatePersian, appType, num, defLangId, objectParameter));
					if (objectParameter != null)
					{
						if (objectParameter.Value.ToString() == "-1")
						{
							message = Messages.msgErrorRunFunction;
							status = ServiceResultStatus.Error;
						}
						else
						{
							message = Messages.MobMsgSuccessAction;
							status = ServiceResultStatus.Success;
						}
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
		catch (Exception e3)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e3);
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
	public ServiceResult<List<MobspReturnLeaveSummaryCalendar_Result>> ReturnLeaveSummaryCalendar(int oprType, int reqUserId, DateTime fromDate, DateTime toDate, int? ln = null, int? mode = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<MobspReturnLeaveSummaryCalendar_Result> data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					cRMEntities = new CRMEntities();
					data = Enumerable.ToList<MobspReturnLeaveSummaryCalendar_Result>((IEnumerable<MobspReturnLeaveSummaryCalendar_Result>)cRMEntities.MobspReturnLeaveSummaryCalendar(oprType, reqUserId, fromDate, toDate, token2.userId, result, result2, mode));
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
		return new ServiceResult<List<MobspReturnLeaveSummaryCalendar_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<string> LeaveCancel(int leaveId, int? cId = null, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		string data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
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
					DateTime value = now;
					string canceledRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					List<MobspSelectLanguages_Result> list = Enumerable.ToList<MobspSelectLanguages_Result>((IEnumerable<MobspSelectLanguages_Result>)cRMEntities.MobspSelectLanguages());
					CRMEntities cRMEntities2 = cRMEntities;
					int? num = leaveId;
					int? userId = null;
					int? leaveTypeId = null;
					int? leaveId2 = num;
					int? languageID = result;
					int? defaultLanguageID = result2;
					MobspSelectLeave_Result mobspSelectLeave_Result = Enumerable.FirstOrDefault<MobspSelectLeave_Result>((IEnumerable<MobspSelectLeave_Result>)cRMEntities2.MobspSelectLeave(null, leaveId2, leaveTypeId, userId, null, null, null, null, languageID, defaultLanguageID, null, cId));
					if (mobspSelectLeave_Result != null)
					{
						cRMEntities.MobspLeaveCancel(leaveId, token2.userId, value, canceledRegisterDatePersian);
						string text = "";
						foreach (MobspSelectLanguages_Result item in list)
						{
							string resourceString = MyResource.GetResourceString("CancelRequest", item.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
							string format = "";
							if (mobspSelectLeave_Result.LeaveTypeOpr.GetValueOrDefault(1) == 1)
							{
								format = MyResource.GetResourceString("msgLeaveCanceledWithNumber", item.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
							}
							else if (mobspSelectLeave_Result.LeaveTypeOpr.GetValueOrDefault(1) == 2)
							{
								format = MyResource.GetResourceString("msgMissionCanceledWithNumber", item.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
							}
							format = string.Format(format, mobspSelectLeave_Result.LeaveId);
							text = text + "MsgSubj=" + resourceString + "|@#@|MsgBody=" + format + "|@#@|LangId=" + item.LanguageID + "|@#@||^#^|";
						}
						int userId2 = UserLogin.CurrentUser.UserId;
						int result3 = 0;
						int.TryParse(mobspSelectLeave_Result.RequestUserId.ToString(), out result3);
						int msgTypeId = 0;
						int num2 = 0;
						if (mobspSelectLeave_Result.LeaveTypeOpr.GetValueOrDefault() == 1)
						{
							msgTypeId = 6;
							num2 = (mobspSelectLeave_Result.VerificationWorkFlowId ?? mobspSelectLeave_Result.UserDepartmentLeaveVerificationWorkFlowId).GetValueOrDefault();
						}
						else if (mobspSelectLeave_Result.LeaveTypeOpr.GetValueOrDefault() == 2)
						{
							msgTypeId = 7;
							num2 = (mobspSelectLeave_Result.VerificationWorkFlowId ?? mobspSelectLeave_Result.UserDepartmentMissionVerificationWorkFlowId).GetValueOrDefault();
						}
						if (userId2 > 0 && result3 > 0 && num2 > 0)
						{
							SendMessage(userId2, result3, msgTypeId, text, token2.userId, mobspSelectLeave_Result.LeaveId, num2, cId, result);
							message = Messages.MobMsgSuccessAction;
							status = ServiceResultStatus.Success;
						}
						else
						{
							message = Messages.MobMsgErrorDoneOperation;
							status = ServiceResultStatus.Fail;
						}
						data = null;
						message = Messages.MobMsgSuccessAction;
						status = ServiceResultStatus.Success;
					}
					else
					{
						data = null;
						message = Messages.MobMsgErorrNotFound;
						status = ServiceResultStatus.Success;
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

	public bool SendMessage(int fromUserId, int toUserId, int msgTypeId, string message, int userId, int objectId, int? workflowStepId = null, int? centerId = null, int? langId = 1065)
	{
		bool result = true;
		try
		{
			int result2 = 1065;
			if (langId.HasValue)
			{
				int.TryParse(langId.ToString(), out result2);
			}
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result3);
			CRMEntities cRMEntities = new CRMEntities();
			DateTime now = DateTime.Now;
			DateTime value = now;
			string text = now.ToString("yyyyMMdd", new PersianCulture());
			string msgdSendTime = now.ToString("HH:mm:ss", new PersianCulture());
			short value2 = short.Parse(now.ToString("yyyy", new PersianCulture()));
			short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Mobile.Classes.Configuration.AppType;
			int.Parse(Financial.Get().Id.ToString());
			ObjectParameter internalMessageID = new ObjectParameter("InternalMessageID", 0);
			int? msgdTypeId = msgTypeId;
			int? msgdFromUserId = fromUserId;
			int? msgdToUserId = toUserId;
			DateTime? msgdSendDateTime = value;
			int? msgdAttachRecId = objectId;
			int? userId2 = userId;
			short? year = value2;
			short? month = value3;
			DateTime? registerDate = value;
			int? languageID = result3;
			int? firstRegisterUserId = userId;
			DateTime? firstRegisterDate = value;
			int? msgdAttachRecIdI = workflowStepId;
			cRMEntities.MobspInsertInternalMessageSingle(null, null, message, null, msgdTypeId, msgdFromUserId, msgdToUserId, text, msgdSendTime, msgdSendDateTime, null, null, msgdAttachRecId, null, null, userId2, year, month, registerDate, text, appType, languageID, firstRegisterUserId, firstRegisterDate, text, null, internalMessageID, msgdAttachRecIdI, null, null, centerId);
			PushNotif.NewIntMsgNotify(withthread: true, centerId);
		}
		catch
		{
			result = false;
		}
		return result;
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<CommonReturnResultViewModel> ExecuteLeave(int leaveId, int leaveTypeId, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		CommonReturnResultViewModel commonReturnResultViewModel = null;
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
				if (new Common().GetToken(token) != null)
				{
					commonReturnResultViewModel = new CommonReturnResultViewModel();
					cRMEntities = new CRMEntities();
					DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
					commonReturnResultViewModel.IsDone = false;
					commonReturnResultViewModel.MessageExtra = "";
					commonReturnResultViewModel = ActExecuteLeave(leaveId, leaveTypeId, result2, num);
					status = ServiceResultStatus.Success;
					message = "";
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					commonReturnResultViewModel = null;
					status = ServiceResultStatus.Error;
					commonReturnResultViewModel.IsDone = false;
					commonReturnResultViewModel.Message = Messages.MobMsgErrorAccessingToken;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				commonReturnResultViewModel = null;
				status = ServiceResultStatus.Error;
				commonReturnResultViewModel.IsDone = false;
				commonReturnResultViewModel.Message = Messages.MobMsgErrorAccessingToken;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			commonReturnResultViewModel = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
			commonReturnResultViewModel.IsDone = false;
			commonReturnResultViewModel.Message = Messages.msgErrorRunFunction;
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<CommonReturnResultViewModel>
		{
			Message = message,
			Data = commonReturnResultViewModel,
			Status = status
		};
	}

	public CommonReturnResultViewModel ActExecuteLeave(int leaveId, int leaveTypeId, int defLangID, int currLangID)
	{
		CommonReturnResultViewModel commonReturnResultViewModel = new CommonReturnResultViewModel();
		commonReturnResultViewModel.IsDone = false;
		commonReturnResultViewModel.MessageExtra = "";
		try
		{
			string arg = "";
			switch (leaveTypeId)
			{
			case 1:
			case 2:
				arg = Labels.lblLeave;
				break;
			case 3:
			case 4:
				arg = Labels.lblMission;
				break;
			}
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
			string appType = Mobile.Classes.Configuration.AppType;
			short value3 = short.Parse(now.ToString("yyyy", new PersianCulture()));
			int userId = UserLogin.CurrentUser.UserId;
			ObjectParameter objectParameter = new ObjectParameter("Result", typeof(int));
			Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)new CRMSpEntities().MobspExecuteLeave(leaveId, userId, value, registerDatePersian, value2, value3, appType, currLangID, defLangID, objectParameter));
			int result = 0;
			if (objectParameter != null && objectParameter.Value != null)
			{
				int.TryParse(objectParameter.Value.ToString(), out result);
			}
			switch (result)
			{
			case 1:
				commonReturnResultViewModel.IsDone = true;
				commonReturnResultViewModel.Message = string.Format(Messages.msgLeaveExecute, arg);
				break;
			case -1:
				commonReturnResultViewModel.IsDone = false;
				commonReturnResultViewModel.Message = string.Format(Messages.msgErrorExecLeaveBeforeVerify, arg);
				break;
			case -2:
				commonReturnResultViewModel.IsDone = false;
				commonReturnResultViewModel.Message = string.Format(Messages.msgErrorExecLeaveCanceled, arg);
				break;
			case -3:
				commonReturnResultViewModel.IsDone = false;
				commonReturnResultViewModel.Message = string.Format(Messages.msgErrorLeaveAlreadyExecute, arg);
				break;
			default:
				commonReturnResultViewModel.IsDone = false;
				commonReturnResultViewModel.Message = string.Format(Messages.msgErrorNotEexcuteLeave, arg);
				break;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			commonReturnResultViewModel.IsDone = false;
			commonReturnResultViewModel.Message = Messages.msgErrorRunFunction;
		}
		return commonReturnResultViewModel;
	}
}
