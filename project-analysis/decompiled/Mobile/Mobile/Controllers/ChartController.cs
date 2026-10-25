using System;
using System.Collections.Generic;
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

namespace Mobile.Controllers;

public class ChartController : ApiController
{
	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<ChartDailyOrderViewModel> ChartDailyOrders(int userId, string fromDate, string toDate, string lastFromDate, string lastToDate, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		ChartDailyOrderViewModel chartDailyOrderViewModel = null;
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
					chartDailyOrderViewModel = new ChartDailyOrderViewModel();
					chartDailyOrderViewModel.ThisYear = new List<MobspChartDailyOrders_Result>();
					chartDailyOrderViewModel.LastYear = new List<MobspChartDailyOrders_Result>();
					DateTime now = DateTime.Now;
					DateTime now2 = DateTime.Now;
					DateTime now3 = DateTime.Now;
					DateTime now4 = DateTime.Now;
					try
					{
						if (string.IsNullOrEmpty(fromDate))
						{
							ServiceResult<ChartDailyOrderViewModel> result3 = new ServiceResult<ChartDailyOrderViewModel>
							{
								Message = Messages.MobMsgErrorDateNotEntered,
								Data = null,
								Status = ServiceResultStatus.Fail
							};
							cRMEntities?.Dispose();
							return result3;
						}
						now = DateTime.Parse(fromDate, new CultureInfo("en-US"));
						if (string.IsNullOrEmpty(toDate))
						{
							ServiceResult<ChartDailyOrderViewModel> result4 = new ServiceResult<ChartDailyOrderViewModel>
							{
								Message = Messages.MobMsgErrorDateNotEntered,
								Data = null,
								Status = ServiceResultStatus.Fail
							};
							cRMEntities?.Dispose();
							return result4;
						}
						now2 = DateTime.Parse(toDate, new CultureInfo("en-US"));
						if (string.IsNullOrEmpty(lastFromDate))
						{
							ServiceResult<ChartDailyOrderViewModel> result5 = new ServiceResult<ChartDailyOrderViewModel>
							{
								Message = Messages.MobMsgErrorDateNotEntered,
								Data = null,
								Status = ServiceResultStatus.Fail
							};
							cRMEntities?.Dispose();
							return result5;
						}
						now3 = DateTime.Parse(lastFromDate, new CultureInfo("en-US"));
						if (string.IsNullOrEmpty(lastToDate))
						{
							ServiceResult<ChartDailyOrderViewModel> result6 = new ServiceResult<ChartDailyOrderViewModel>
							{
								Message = Messages.MobMsgErrorDateNotEntered,
								Data = null,
								Status = ServiceResultStatus.Fail
							};
							cRMEntities?.Dispose();
							return result6;
						}
						now4 = DateTime.Parse(lastToDate, new CultureInfo("en-US"));
					}
					catch (Exception e)
					{
						ErrorSignal.FromCurrentContext().Raise(e);
						ServiceResult<ChartDailyOrderViewModel> result7 = new ServiceResult<ChartDailyOrderViewModel>
						{
							Message = Messages.MobMsgErrorDateFormatIncorrect,
							Data = null,
							Status = ServiceResultStatus.Error
						};
						cRMEntities?.Dispose();
						return result7;
					}
					MobspChartUserAccess_Result mobspChartUserAccess_Result = Enumerable.FirstOrDefault<MobspChartUserAccess_Result>((IEnumerable<MobspChartUserAccess_Result>)cRMEntities.MobspChartUserAccess(token2.userId));
					if ((!mobspChartUserAccess_Result.UserAccessSaleChrtAllUsers.HasValue || mobspChartUserAccess_Result.UserAccessSaleChrtAllUsers == false) && userId == 0)
					{
						userId = token2.userId;
					}
					chartDailyOrderViewModel.ThisYear = Enumerable.ToList<MobspChartDailyOrders_Result>((IEnumerable<MobspChartDailyOrders_Result>)cRMEntities.MobspChartDailyOrders(now, now2, userId));
					chartDailyOrderViewModel.LastYear = Enumerable.ToList<MobspChartDailyOrders_Result>((IEnumerable<MobspChartDailyOrders_Result>)cRMEntities.MobspChartDailyOrders(now3, now4, userId));
					message = "";
					status = ServiceResultStatus.Success;
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					chartDailyOrderViewModel = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				chartDailyOrderViewModel = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e2)
		{
			message = Messages.MobMsgErrorDoneOperation;
			chartDailyOrderViewModel = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<ChartDailyOrderViewModel>
		{
			Message = message,
			Data = chartDailyOrderViewModel,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<ChartMonthlyOrderViewModel> ChartMonthlyOrders(int userId, string fromDate, string toDate, string lastFromDate, string lastToDate, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		ChartMonthlyOrderViewModel chartMonthlyOrderViewModel = null;
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
					chartMonthlyOrderViewModel = new ChartMonthlyOrderViewModel();
					chartMonthlyOrderViewModel.ThisYear = new List<MobspChartMonthlyOrders_Result>();
					chartMonthlyOrderViewModel.LastYear = new List<MobspChartMonthlyOrders_Result>();
					DateTime now = DateTime.Now;
					DateTime now2 = DateTime.Now;
					DateTime now3 = DateTime.Now;
					DateTime now4 = DateTime.Now;
					try
					{
						if (string.IsNullOrEmpty(fromDate))
						{
							ServiceResult<ChartMonthlyOrderViewModel> result3 = new ServiceResult<ChartMonthlyOrderViewModel>
							{
								Message = Messages.MobMsgErrorDateNotEntered,
								Data = null,
								Status = ServiceResultStatus.Fail
							};
							cRMEntities?.Dispose();
							return result3;
						}
						now = DateTime.Parse(fromDate, new CultureInfo("en-US"));
						if (string.IsNullOrEmpty(toDate))
						{
							ServiceResult<ChartMonthlyOrderViewModel> result4 = new ServiceResult<ChartMonthlyOrderViewModel>
							{
								Message = Messages.MobMsgErrorDateNotEntered,
								Data = null,
								Status = ServiceResultStatus.Fail
							};
							cRMEntities?.Dispose();
							return result4;
						}
						now2 = DateTime.Parse(toDate, new CultureInfo("en-US"));
						if (string.IsNullOrEmpty(lastFromDate))
						{
							ServiceResult<ChartMonthlyOrderViewModel> result5 = new ServiceResult<ChartMonthlyOrderViewModel>
							{
								Message = Messages.MobMsgErrorDateNotEntered,
								Data = null,
								Status = ServiceResultStatus.Fail
							};
							cRMEntities?.Dispose();
							return result5;
						}
						now3 = DateTime.Parse(lastFromDate, new CultureInfo("en-US"));
						if (string.IsNullOrEmpty(lastToDate))
						{
							ServiceResult<ChartMonthlyOrderViewModel> result6 = new ServiceResult<ChartMonthlyOrderViewModel>
							{
								Message = Messages.MobMsgErrorDateNotEntered,
								Data = null,
								Status = ServiceResultStatus.Fail
							};
							cRMEntities?.Dispose();
							return result6;
						}
						now4 = DateTime.Parse(lastToDate, new CultureInfo("en-US"));
					}
					catch (Exception e)
					{
						ErrorSignal.FromCurrentContext().Raise(e);
						ServiceResult<ChartMonthlyOrderViewModel> result7 = new ServiceResult<ChartMonthlyOrderViewModel>
						{
							Message = Messages.MobMsgErrorDateFormatIncorrect,
							Data = null,
							Status = ServiceResultStatus.Error
						};
						cRMEntities?.Dispose();
						return result7;
					}
					MobspChartUserAccess_Result mobspChartUserAccess_Result = Enumerable.FirstOrDefault<MobspChartUserAccess_Result>((IEnumerable<MobspChartUserAccess_Result>)cRMEntities.MobspChartUserAccess(token2.userId));
					if ((!mobspChartUserAccess_Result.UserAccessSaleChrtAllUsers.HasValue || mobspChartUserAccess_Result.UserAccessSaleChrtAllUsers == false) && userId == 0)
					{
						userId = token2.userId;
					}
					chartMonthlyOrderViewModel.ThisYear = Enumerable.ToList<MobspChartMonthlyOrders_Result>((IEnumerable<MobspChartMonthlyOrders_Result>)cRMEntities.MobspChartMonthlyOrders(now, now2, userId));
					chartMonthlyOrderViewModel.LastYear = Enumerable.ToList<MobspChartMonthlyOrders_Result>((IEnumerable<MobspChartMonthlyOrders_Result>)cRMEntities.MobspChartMonthlyOrders(now3, now4, userId));
					message = "";
					status = ServiceResultStatus.Success;
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					chartMonthlyOrderViewModel = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				chartMonthlyOrderViewModel = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e2)
		{
			message = Messages.MobMsgErrorDoneOperation;
			chartMonthlyOrderViewModel = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<ChartMonthlyOrderViewModel>
		{
			Message = message,
			Data = chartMonthlyOrderViewModel,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<ChartDailyPreOrderViewModel> ChartDailyPreOrders(int userId, string fromDate, string toDate, string lastFromDate, string lastToDate, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		ChartDailyPreOrderViewModel chartDailyPreOrderViewModel = null;
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
					chartDailyPreOrderViewModel = new ChartDailyPreOrderViewModel();
					chartDailyPreOrderViewModel.ThisYear = new List<MobspChartDailyPreOrders_Result>();
					chartDailyPreOrderViewModel.LastYear = new List<MobspChartDailyPreOrders_Result>();
					DateTime now = DateTime.Now;
					DateTime now2 = DateTime.Now;
					DateTime now3 = DateTime.Now;
					DateTime now4 = DateTime.Now;
					try
					{
						if (string.IsNullOrEmpty(fromDate))
						{
							ServiceResult<ChartDailyPreOrderViewModel> result3 = new ServiceResult<ChartDailyPreOrderViewModel>
							{
								Message = Messages.MobMsgErrorDateNotEntered,
								Data = null,
								Status = ServiceResultStatus.Fail
							};
							cRMEntities?.Dispose();
							return result3;
						}
						now = DateTime.Parse(fromDate, new CultureInfo("en-US"));
						if (string.IsNullOrEmpty(toDate))
						{
							ServiceResult<ChartDailyPreOrderViewModel> result4 = new ServiceResult<ChartDailyPreOrderViewModel>
							{
								Message = Messages.MobMsgErrorDateNotEntered,
								Data = null,
								Status = ServiceResultStatus.Fail
							};
							cRMEntities?.Dispose();
							return result4;
						}
						now2 = DateTime.Parse(toDate, new CultureInfo("en-US"));
						if (string.IsNullOrEmpty(lastFromDate))
						{
							ServiceResult<ChartDailyPreOrderViewModel> result5 = new ServiceResult<ChartDailyPreOrderViewModel>
							{
								Message = Messages.MobMsgErrorDateNotEntered,
								Data = null,
								Status = ServiceResultStatus.Fail
							};
							cRMEntities?.Dispose();
							return result5;
						}
						now3 = DateTime.Parse(lastFromDate, new CultureInfo("en-US"));
						if (string.IsNullOrEmpty(lastToDate))
						{
							ServiceResult<ChartDailyPreOrderViewModel> result6 = new ServiceResult<ChartDailyPreOrderViewModel>
							{
								Message = Messages.MobMsgErrorDateNotEntered,
								Data = null,
								Status = ServiceResultStatus.Fail
							};
							cRMEntities?.Dispose();
							return result6;
						}
						now4 = DateTime.Parse(lastToDate, new CultureInfo("en-US"));
					}
					catch (Exception e)
					{
						ErrorSignal.FromCurrentContext().Raise(e);
						ServiceResult<ChartDailyPreOrderViewModel> result7 = new ServiceResult<ChartDailyPreOrderViewModel>
						{
							Message = Messages.MobMsgErrorDateFormatIncorrect,
							Data = null,
							Status = ServiceResultStatus.Error
						};
						cRMEntities?.Dispose();
						return result7;
					}
					MobspChartUserAccess_Result mobspChartUserAccess_Result = Enumerable.FirstOrDefault<MobspChartUserAccess_Result>((IEnumerable<MobspChartUserAccess_Result>)cRMEntities.MobspChartUserAccess(token2.userId));
					if ((!mobspChartUserAccess_Result.UserAccessSaleChrtAllUsers.HasValue || mobspChartUserAccess_Result.UserAccessSaleChrtAllUsers == false) && userId == 0)
					{
						userId = token2.userId;
					}
					chartDailyPreOrderViewModel.ThisYear = Enumerable.ToList<MobspChartDailyPreOrders_Result>((IEnumerable<MobspChartDailyPreOrders_Result>)cRMEntities.MobspChartDailyPreOrders(now, now2, userId));
					chartDailyPreOrderViewModel.LastYear = Enumerable.ToList<MobspChartDailyPreOrders_Result>((IEnumerable<MobspChartDailyPreOrders_Result>)cRMEntities.MobspChartDailyPreOrders(now3, now4, userId));
					message = "";
					status = ServiceResultStatus.Success;
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					chartDailyPreOrderViewModel = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				chartDailyPreOrderViewModel = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e2)
		{
			message = Messages.MobMsgErrorDoneOperation;
			chartDailyPreOrderViewModel = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<ChartDailyPreOrderViewModel>
		{
			Message = message,
			Data = chartDailyPreOrderViewModel,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<ChartDailyExtraOrderViewModel> ChartDailyExtraOrder(int userId, string fromDate, string toDate, int? cId, short horizontalField = 1, short verticalMode = 1, string selectedValues = "", int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		ChartDailyExtraOrderViewModel chartDailyExtraOrderViewModel = null;
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
					cRMSpEntities = new CRMSpEntities();
					chartDailyExtraOrderViewModel = new ChartDailyExtraOrderViewModel();
					DateTime dateTime = DateTime.Now;
					DateTime dateTime2 = DateTime.Now;
					if (!string.IsNullOrEmpty(fromDate))
					{
						dateTime = DateTime.Parse(PersianDate.GetFormatetdDate(fromDate.Replace("/", "")) + " 00:00:00", num switch
						{
							1025 => new CultureInfo("ar-SA"), 
							1065 => new PersianCulture(), 
							_ => new CultureInfo("en-US"), 
						});
					}
					if (!string.IsNullOrEmpty(toDate))
					{
						dateTime2 = DateTime.Parse(PersianDate.GetFormatetdDate(toDate.Replace("/", "")) + " 23:59:59", num switch
						{
							1025 => new CultureInfo("ar-SA"), 
							1065 => new PersianCulture(), 
							_ => new CultureInfo("en-US"), 
						});
					}
					if (dateTime > dateTime2)
					{
						ServiceResult<ChartDailyExtraOrderViewModel> result3 = new ServiceResult<ChartDailyExtraOrderViewModel>
						{
							Message = Messages.msgErrorChartInvalidDateRangeOrder,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
						cRMSpEntities?.Dispose();
						return result3;
					}
					if ((horizontalField == 1 || horizontalField == 21) && dateTime2.AddYears(-1) > dateTime)
					{
						ServiceResult<ChartDailyExtraOrderViewModel> result4 = new ServiceResult<ChartDailyExtraOrderViewModel>
						{
							Message = Messages.msgErrorChartInvalidDateRangeMaxOneYear,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
						cRMSpEntities?.Dispose();
						return result4;
					}
					if (horizontalField == 21)
					{
						List<DateTime> firstDayOfMonths = DateTimeClass.GetFirstDayOfMonths(dateTime, dateTime2, num);
						selectedValues = string.Join(",", Enumerable.Select<DateTime, string>((IEnumerable<DateTime>)firstDayOfMonths, (Func<DateTime, string>)((DateTime d) => d.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture))));
					}
					List<MobspChartDailyOrdersExtra_Result> list = Enumerable.ToList<MobspChartDailyOrdersExtra_Result>((IEnumerable<MobspChartDailyOrdersExtra_Result>)cRMSpEntities.MobspChartDailyOrdersExtra(horizontalField, verticalMode, selectedValues, dateTime, dateTime2, userId, UserLogin.CurrentUser.UserId, cId, num, result2));
					if (horizontalField == 1)
					{
						foreach (MobspChartDailyOrdersExtra_Result item in list)
						{
							DateTime dateTime3 = DateTime.ParseExact(item.XLabelText, "yyyy-MM-dd", CultureInfo.InvariantCulture);
							item.XLabelText = ((item.XLabelText != null) ? dateTime3.ToString("yyyy/MM/dd") : "");
						}
					}
					foreach (MobspChartDailyOrdersExtra_Result item2 in list)
					{
						item2.YSaleOrderLabelText = item2.YSaleOrderLabelText.GetValueOrDefault();
						item2.YReturnOrderLabelText = item2.YReturnOrderLabelText.GetValueOrDefault();
						item2.YNetOrderLabelText = item2.YNetOrderLabelText.GetValueOrDefault();
					}
					if (verticalMode == 2 || verticalMode == 4)
					{
						decimal valueOrDefault = Enumerable.Sum<MobspChartDailyOrdersExtra_Result>((IEnumerable<MobspChartDailyOrdersExtra_Result>)list, (Func<MobspChartDailyOrdersExtra_Result, decimal?>)((MobspChartDailyOrdersExtra_Result x) => x.YSaleOrderLabelText)).GetValueOrDefault();
						if (valueOrDefault > 0m && Math.Abs(valueOrDefault - 100m) > 0.001m)
						{
							decimal value = 100m - valueOrDefault;
							MobspChartDailyOrdersExtra_Result mobspChartDailyOrdersExtra_Result = Enumerable.FirstOrDefault<MobspChartDailyOrdersExtra_Result>((IEnumerable<MobspChartDailyOrdersExtra_Result>)Enumerable.OrderByDescending<MobspChartDailyOrdersExtra_Result, decimal?>((IEnumerable<MobspChartDailyOrdersExtra_Result>)list, (Func<MobspChartDailyOrdersExtra_Result, decimal?>)((MobspChartDailyOrdersExtra_Result x) => x.YSaleOrderLabelText)));
							if (mobspChartDailyOrdersExtra_Result != null)
							{
								mobspChartDailyOrdersExtra_Result.YSaleOrderLabelText += (decimal?)value;
							}
						}
						decimal valueOrDefault2 = Enumerable.Sum<MobspChartDailyOrdersExtra_Result>((IEnumerable<MobspChartDailyOrdersExtra_Result>)list, (Func<MobspChartDailyOrdersExtra_Result, decimal?>)((MobspChartDailyOrdersExtra_Result x) => x.YReturnOrderLabelText)).GetValueOrDefault();
						if (valueOrDefault2 > 0m && Math.Abs(valueOrDefault2 - 100m) > 0.001m)
						{
							decimal value2 = 100m - valueOrDefault2;
							MobspChartDailyOrdersExtra_Result mobspChartDailyOrdersExtra_Result2 = Enumerable.FirstOrDefault<MobspChartDailyOrdersExtra_Result>((IEnumerable<MobspChartDailyOrdersExtra_Result>)Enumerable.OrderByDescending<MobspChartDailyOrdersExtra_Result, decimal?>((IEnumerable<MobspChartDailyOrdersExtra_Result>)list, (Func<MobspChartDailyOrdersExtra_Result, decimal?>)((MobspChartDailyOrdersExtra_Result x) => x.YReturnOrderLabelText)));
							if (mobspChartDailyOrdersExtra_Result2 != null)
							{
								mobspChartDailyOrdersExtra_Result2.YReturnOrderLabelText += (decimal?)value2;
							}
						}
					}
					if (horizontalField == 21)
					{
						CultureInfo cultureInfo = new CultureInfo(num);
						Calendar calendar = cultureInfo.Calendar;
						string[] monthNames = cultureInfo.DateTimeFormat.MonthNames;
						foreach (MobspChartDailyOrdersExtra_Result item3 in list)
						{
							if (!string.IsNullOrEmpty(item3.XLabelText))
							{
								DateTime time = DateTime.ParseExact(item3.XLabelText, "yyyy-MM-dd", CultureInfo.InvariantCulture);
								int month = calendar.GetMonth(time);
								calendar.GetYear(time);
								item3.XLabelText = monthNames[month - 1] ?? "";
							}
						}
					}
					DateTime dateTime4 = dateTime2;
					DateTime dateTime5 = dateTime;
					if (!string.IsNullOrEmpty(fromDate))
					{
						string s = fromDate.Replace("/", "").Substring(0, 4);
						string text = string.Concat(str1: fromDate.Replace("/", "").Substring(4, 4), str0: (long.Parse(s) - 1).ToString());
						dateTime5 = ((num != 1065) ? dateTime.AddYears(-1) : DateTime.Parse(PersianDate.GetFormatetdDate(text.Replace("/", "")) + " 00:00:00", num switch
						{
							1025 => new CultureInfo("ar-SA"), 
							1065 => new PersianCulture(), 
							_ => new CultureInfo("en-US"), 
						}));
					}
					if (!string.IsNullOrEmpty(toDate))
					{
						string s2 = toDate.Replace("/", "").Substring(0, 4);
						string text2 = toDate.Replace("/", "").Substring(4, 4);
						string text3 = toDate.Replace("/", "").Substring(4, 2);
						string s3 = toDate.Replace("/", "").Substring(6, 2);
						long num2 = long.Parse(s2) - 1;
						string text4 = num2 + text2;
						if (num == 1065)
						{
							try
							{
								dateTime4 = DateTime.Parse(PersianDate.GetFormatetdDate(text4.Replace("/", "")) + " 23:59:59", num switch
								{
									1025 => new CultureInfo("ar-SA"), 
									1065 => new PersianCulture(), 
									_ => new CultureInfo("en-US"), 
								});
							}
							catch (Exception)
							{
								text4 = num2 + text3 + (int.Parse(s3) - 1);
								dateTime4 = DateTime.Parse(PersianDate.GetFormatetdDate(text4.Replace("/", "")) + " 23:59:59", num switch
								{
									1025 => new CultureInfo("ar-SA"), 
									1065 => new PersianCulture(), 
									_ => new CultureInfo("en-US"), 
								});
							}
						}
						else
						{
							dateTime4 = dateTime2.AddYears(-1);
						}
					}
					if (horizontalField == 21)
					{
						List<DateTime> firstDayOfMonths2 = DateTimeClass.GetFirstDayOfMonths(dateTime5, dateTime4, num);
						selectedValues = string.Join(",", Enumerable.Select<DateTime, string>((IEnumerable<DateTime>)firstDayOfMonths2, (Func<DateTime, string>)((DateTime d) => d.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture))));
					}
					List<MobspChartDailyOrdersExtra_Result> list2 = Enumerable.ToList<MobspChartDailyOrdersExtra_Result>((IEnumerable<MobspChartDailyOrdersExtra_Result>)cRMSpEntities.MobspChartDailyOrdersExtra(horizontalField, verticalMode, selectedValues, dateTime5, dateTime4, userId, UserLogin.CurrentUser.UserId, cId, num, result2));
					if (horizontalField == 1)
					{
						foreach (MobspChartDailyOrdersExtra_Result item4 in list2)
						{
							DateTime dateTime6 = DateTime.ParseExact(item4.XLabelText, "yyyy-MM-dd", CultureInfo.InvariantCulture);
							item4.XLabelText = ((item4.XLabelText != null) ? dateTime6.ToString("yyyy/MM/dd") : "");
						}
					}
					foreach (MobspChartDailyOrdersExtra_Result item5 in list2)
					{
						item5.YSaleOrderLabelText = item5.YSaleOrderLabelText.GetValueOrDefault();
						item5.YReturnOrderLabelText = item5.YReturnOrderLabelText.GetValueOrDefault();
						item5.YNetOrderLabelText = item5.YNetOrderLabelText.GetValueOrDefault();
					}
					if (verticalMode == 2 || verticalMode == 4)
					{
						decimal valueOrDefault3 = Enumerable.Sum<MobspChartDailyOrdersExtra_Result>((IEnumerable<MobspChartDailyOrdersExtra_Result>)list2, (Func<MobspChartDailyOrdersExtra_Result, decimal?>)((MobspChartDailyOrdersExtra_Result x) => x.YSaleOrderLabelText)).GetValueOrDefault();
						if (valueOrDefault3 > 0m && Math.Abs(valueOrDefault3 - 100m) > 0.001m)
						{
							decimal value3 = 100m - valueOrDefault3;
							MobspChartDailyOrdersExtra_Result mobspChartDailyOrdersExtra_Result3 = Enumerable.FirstOrDefault<MobspChartDailyOrdersExtra_Result>((IEnumerable<MobspChartDailyOrdersExtra_Result>)Enumerable.OrderByDescending<MobspChartDailyOrdersExtra_Result, decimal?>((IEnumerable<MobspChartDailyOrdersExtra_Result>)list2, (Func<MobspChartDailyOrdersExtra_Result, decimal?>)((MobspChartDailyOrdersExtra_Result x) => x.YSaleOrderLabelText)));
							if (mobspChartDailyOrdersExtra_Result3 != null)
							{
								mobspChartDailyOrdersExtra_Result3.YSaleOrderLabelText += (decimal?)value3;
							}
						}
						decimal valueOrDefault4 = Enumerable.Sum<MobspChartDailyOrdersExtra_Result>((IEnumerable<MobspChartDailyOrdersExtra_Result>)list2, (Func<MobspChartDailyOrdersExtra_Result, decimal?>)((MobspChartDailyOrdersExtra_Result x) => x.YReturnOrderLabelText)).GetValueOrDefault();
						if (valueOrDefault4 > 0m && Math.Abs(valueOrDefault4 - 100m) > 0.001m)
						{
							decimal value4 = 100m - valueOrDefault4;
							MobspChartDailyOrdersExtra_Result mobspChartDailyOrdersExtra_Result4 = Enumerable.FirstOrDefault<MobspChartDailyOrdersExtra_Result>((IEnumerable<MobspChartDailyOrdersExtra_Result>)Enumerable.OrderByDescending<MobspChartDailyOrdersExtra_Result, decimal?>((IEnumerable<MobspChartDailyOrdersExtra_Result>)list2, (Func<MobspChartDailyOrdersExtra_Result, decimal?>)((MobspChartDailyOrdersExtra_Result x) => x.YReturnOrderLabelText)));
							if (mobspChartDailyOrdersExtra_Result4 != null)
							{
								mobspChartDailyOrdersExtra_Result4.YReturnOrderLabelText += (decimal?)value4;
							}
						}
					}
					list2 = Enumerable.ToList<MobspChartDailyOrdersExtra_Result>(Enumerable.Where<MobspChartDailyOrdersExtra_Result>((IEnumerable<MobspChartDailyOrdersExtra_Result>)list2, (Func<MobspChartDailyOrdersExtra_Result, bool>)delegate(MobspChartDailyOrdersExtra_Result c)
					{
						decimal? ySaleOrderLabelText = c.YSaleOrderLabelText;
						return (ySaleOrderLabelText.GetValueOrDefault() > default(decimal)) & ySaleOrderLabelText.HasValue;
					}));
					if (horizontalField == 21)
					{
						CultureInfo cultureInfo2 = new CultureInfo(num);
						Calendar calendar2 = cultureInfo2.Calendar;
						string[] monthNames2 = cultureInfo2.DateTimeFormat.MonthNames;
						foreach (MobspChartDailyOrdersExtra_Result item6 in list2)
						{
							if (!string.IsNullOrEmpty(item6.XLabelText))
							{
								DateTime time2 = DateTime.ParseExact(item6.XLabelText, "yyyy-MM-dd", CultureInfo.InvariantCulture);
								int month2 = calendar2.GetMonth(time2);
								calendar2.GetYear(time2);
								item6.XLabelText = monthNames2[month2 - 1] ?? "";
							}
						}
					}
					chartDailyExtraOrderViewModel.ThisYear = list;
					chartDailyExtraOrderViewModel.LastYear = list2;
					message = "";
					status = ServiceResultStatus.Success;
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					chartDailyExtraOrderViewModel = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				chartDailyExtraOrderViewModel = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			chartDailyExtraOrderViewModel = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<ChartDailyExtraOrderViewModel>
		{
			Message = message,
			Data = chartDailyExtraOrderViewModel,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<MobspProductsTreeByLevel_Result>> SelectProductTreeView(ChartDialyProductTreeViewModel model)
	{
		int result = 1065;
		if (model.Ln.HasValue)
		{
			int.TryParse(model.Ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		List<MobspProductsTreeByLevel_Result> data = new List<MobspProductsTreeByLevel_Result>();
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
					cRMSpEntities = new CRMSpEntities();
					if (model.ProductId.HasValue && model.ProductId != 0)
					{
						model.TextSearch = "";
					}
					model.TextSearch = (model.TextSearch ?? "").Trim();
					model.ParentId = ((model.ParentId.HasValue && model.ParentId.GetValueOrDefault() == -1) ? new int?(0) : model.ParentId);
					data = Enumerable.ToList<MobspProductsTreeByLevel_Result>((IEnumerable<MobspProductsTreeByLevel_Result>)cRMSpEntities.MobspProductsTreeByLevel(model.Mode, num, result2, model.PrdKind, model.PrdInActive, model.CmpId, model.PrjId, model.Level, model.TextSearch, model.MaxLevel, model.ParentId, model.ProductId, model.PageSize, model.PageNumber));
					message = "";
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
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<List<MobspProductsTreeByLevel_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}
}
