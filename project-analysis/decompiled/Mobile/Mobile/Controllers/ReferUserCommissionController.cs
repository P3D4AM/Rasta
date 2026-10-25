using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Http;
using CRM.General.Calendar;
using CRM.Resources;
using Elmah;
using Mobile.Cache.Setting;
using Mobile.Classes;
using Mobile.Classes.Helper;
using Mobile.DataType;
using Mobile.Models;

namespace Mobile.Controllers;

public class ReferUserCommissionController : ApiController
{
	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<MobspSelectUserOrderCommissions_Result>> UserOrderCommissions(UserOrderCommissionsViewModel model)
	{
		int result = 1065;
		if (model.LanguageId.HasValue)
		{
			int.TryParse(model.LanguageId.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<MobspSelectUserOrderCommissions_Result> data = null;
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
					string text = now.ToString("yyyy/MM/dd HH:mm:ss");
					string text2 = now.ToString("dddd");
					DateTime? dateTime = null;
					DateTime? dateTime2 = null;
					try
					{
						if (string.IsNullOrEmpty(model.fromDate))
						{
							ServiceResult<List<MobspSelectUserOrderCommissions_Result>> result3 = new ServiceResult<List<MobspSelectUserOrderCommissions_Result>>
							{
								Message = Messages.MobMsgErrorDateNotEntered,
								Data = null,
								Status = ServiceResultStatus.Fail
							};
							cRMEntities?.Dispose();
							return result3;
						}
						model.fromDate = model.fromDate.Replace("/", "").Replace("-", "").Replace("\\", "")
							.Replace(" ", "")
							.Replace("_", "");
						dateTime = ((result != 1065) ? new DateTime?(DateTime.Parse(PersianDate.GetFormatetdDate(model.fromDate) + " 00:00:00", new CultureInfo("en-US"), DateTimeStyles.None)) : new DateTime?(DateTime.Parse(PersianDate.GetFormatetdDate(model.fromDate) + " 00:00:00")));
						if (string.IsNullOrEmpty(model.toDate))
						{
							ServiceResult<List<MobspSelectUserOrderCommissions_Result>> result4 = new ServiceResult<List<MobspSelectUserOrderCommissions_Result>>
							{
								Message = Messages.MobMsgErrorDateNotEntered,
								Data = null,
								Status = ServiceResultStatus.Fail
							};
							cRMEntities?.Dispose();
							return result4;
						}
						model.toDate = model.toDate.Replace("/", "").Replace("-", "").Replace("\\", "")
							.Replace(" ", "")
							.Replace("_", "");
						dateTime2 = ((result != 1065) ? new DateTime?(DateTime.Parse(PersianDate.GetFormatetdDate(model.toDate) + " 23:59:59", new CultureInfo("en-US"), DateTimeStyles.None)) : new DateTime?(DateTime.Parse(PersianDate.GetFormatetdDate(model.toDate) + " 23:59:59")));
					}
					catch (Exception e)
					{
						ErrorSignal.FromCurrentContext().Raise(e);
						ServiceResult<List<MobspSelectUserOrderCommissions_Result>> result5 = new ServiceResult<List<MobspSelectUserOrderCommissions_Result>>
						{
							Message = Messages.MobMsgErrorDateFormatIncorrect,
							Data = null,
							Status = ServiceResultStatus.Error
						};
						cRMEntities?.Dispose();
						return result5;
					}
					data = Enumerable.ToList<MobspSelectUserOrderCommissions_Result>((IEnumerable<MobspSelectUserOrderCommissions_Result>)cRMEntities.MobspSelectUserOrderCommissions(token2.userId, text, text2, token2.userId, dateTime, dateTime2, languageID: result, defaultLanguageID: result2, pageNumber: model.PageNumber, pageSize: model.PageSize, crmUserIds: model.CrmUserIds, isShowSameOrder: model.IsShowSameOrder, commissionKindId: model.CommissionKindId, companyId: model.CompanyId, isVerified: model.IsVerified, isNotVerified: model.IsNotVerified, isPaied: model.IsPaied, isNotPaied: model.IsNotPaied, effectiveFromDate: model.EffectiveFromDate, effectiveToDate: model.EffectiveToDate, ordFromDate: model.OrdFromDate, ordToDate: model.OrdToDate, percentFrom: model.PercentFrom, percentTo: model.PercentTo, centerId: model.CenterId, isPreVerified: model.IsPreVerified, isNotPreVerified: model.IsNotPreVerified));
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
		catch (Exception e2)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<List<MobspSelectUserOrderCommissions_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<UserOrderCommissionsChartResultViewModel> UserOrderCommissionsChart(UserOrderCommissionsViewModel model)
	{
		int result = 1065;
		if (model.LanguageId.HasValue)
		{
			int.TryParse(model.LanguageId.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		UserOrderCommissionsChartResultViewModel userOrderCommissionsChartResultViewModel = null;
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
					userOrderCommissionsChartResultViewModel = new UserOrderCommissionsChartResultViewModel();
					DateTime now = DateTime.Now;
					now.ToString("yyyy/MM/dd HH:mm:ss");
					now.ToString("dddd");
					DateTime? dateTime = null;
					DateTime? dateTime2 = null;
					try
					{
						if (!string.IsNullOrEmpty(model.fromDate))
						{
							model.fromDate = model.fromDate.Replace("/", "").Replace("-", "").Replace("\\", "")
								.Replace(" ", "")
								.Replace("_", "");
							dateTime = ((result != 1065) ? new DateTime?(DateTime.Parse(PersianDate.GetFormatetdDate(model.fromDate) + " 00:00:00", new CultureInfo("en-US"), DateTimeStyles.None)) : new DateTime?(DateTime.Parse(PersianDate.GetFormatetdDate(model.fromDate) + " 00:00:00")));
						}
						if (!string.IsNullOrEmpty(model.toDate))
						{
							model.toDate = model.toDate.Replace("/", "").Replace("-", "").Replace("\\", "")
								.Replace(" ", "")
								.Replace("_", "");
							dateTime2 = ((result != 1065) ? new DateTime?(DateTime.Parse(PersianDate.GetFormatetdDate(model.toDate) + " 23:59:59", new CultureInfo("en-US"), DateTimeStyles.None)) : new DateTime?(DateTime.Parse(PersianDate.GetFormatetdDate(model.toDate) + " 23:59:59")));
						}
					}
					catch (Exception e)
					{
						ErrorSignal.FromCurrentContext().Raise(e);
						ServiceResult<UserOrderCommissionsChartResultViewModel> result3 = new ServiceResult<UserOrderCommissionsChartResultViewModel>
						{
							Message = Messages.MobMsgErrorDateFormatIncorrect,
							Data = null,
							Status = ServiceResultStatus.Error
						};
						cRMEntities?.Dispose();
						return result3;
					}
					UserOrderCommissionsChartResultViewModel userOrderCommissionsChartResultViewModel2 = userOrderCommissionsChartResultViewModel;
					CRMEntities cRMEntities2 = cRMEntities;
					int? crmUserId = token2.userId;
					DateTime? fDateTime = dateTime;
					DateTime? tDateTime = dateTime2;
					userOrderCommissionsChartResultViewModel2.CmpChart = Enumerable.ToList<MobspSelectUserOrderCommissionsChartByCmp_Result>((IEnumerable<MobspSelectUserOrderCommissionsChartByCmp_Result>)cRMEntities2.MobspSelectUserOrderCommissionsChartByCmp(crmUserId, model.Mode, fDateTime, tDateTime, result, result2, model.CrmUserIds, model.IsShowSameOrder, model.CommissionKindId, model.CompanyId, model.IsVerified, model.IsNotVerified, model.IsPaied, model.IsNotPaied, model.EffectiveFromDate, model.EffectiveToDate, model.OrdFromDate, model.OrdToDate, model.PercentFrom, model.PercentTo, model.IsPreVerified, model.IsNotPreVerified));
					UserOrderCommissionsChartResultViewModel userOrderCommissionsChartResultViewModel3 = userOrderCommissionsChartResultViewModel;
					CRMEntities cRMEntities3 = cRMEntities;
					int? crmUserId2 = token2.userId;
					tDateTime = dateTime;
					fDateTime = dateTime2;
					userOrderCommissionsChartResultViewModel3.UserChart = Enumerable.ToList<MobspSelectUserOrderCommissionsChartByUser_Result>((IEnumerable<MobspSelectUserOrderCommissionsChartByUser_Result>)cRMEntities3.MobspSelectUserOrderCommissionsChartByUser(crmUserId2, model.Mode, tDateTime, fDateTime, result, result2, model.CrmUserIds, model.IsShowSameOrder, model.CommissionKindId, model.CompanyId, model.IsVerified, model.IsNotVerified, model.IsPaied, model.IsNotPaied, model.EffectiveFromDate, model.EffectiveToDate, model.OrdFromDate, model.OrdToDate, model.PercentFrom, model.PercentTo, model.IsPreVerified, model.IsNotPreVerified));
					message = Messages.MobMsgSuccessAction;
					status = ServiceResultStatus.Success;
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					userOrderCommissionsChartResultViewModel = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				userOrderCommissionsChartResultViewModel = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e2)
		{
			message = Messages.MobMsgErrorDoneOperation;
			userOrderCommissionsChartResultViewModel = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<UserOrderCommissionsChartResultViewModel>
		{
			Message = message,
			Data = userOrderCommissionsChartResultViewModel,
			Status = status
		};
	}
}
