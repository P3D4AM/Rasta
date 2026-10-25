using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using CRM.Resources;
using Elmah;
using Mobile.Cache.Setting;
using Mobile.Classes;
using Mobile.Classes.Helper;
using Mobile.DataType;
using Mobile.Models;

namespace Mobile.Controllers;

public class HRMPayRollController : ApiController
{
	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<HRMMobPayRollspSelectUserCycle_Result>> UserCycleList(DateTime fromDate, DateTime toDate, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<HRMMobPayRollspSelectUserCycle_Result> data = null;
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
					data = Enumerable.ToList<HRMMobPayRollspSelectUserCycle_Result>((IEnumerable<HRMMobPayRollspSelectUserCycle_Result>)cRMEntities.HRMMobPayRollspSelectUserCycle(token2.userId, 0, fromDate, toDate, result, result2));
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
		return new ServiceResult<List<HRMMobPayRollspSelectUserCycle_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<HrmUserPayRollDetailsViewModel> UserPayRollDetails(int cycleId, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		HrmUserPayRollDetailsViewModel hrmUserPayRollDetailsViewModel = null;
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
					hrmUserPayRollDetailsViewModel = new HrmUserPayRollDetailsViewModel();
					HRMMobPayRollspSelectUserCycle_Result hRMMobPayRollspSelectUserCycle_Result = Enumerable.FirstOrDefault<HRMMobPayRollspSelectUserCycle_Result>((IEnumerable<HRMMobPayRollspSelectUserCycle_Result>)cRMEntities.HRMMobPayRollspSelectUserCycle(0, cycleId, null, null, result, result2));
					if (hRMMobPayRollspSelectUserCycle_Result != null)
					{
						hrmUserPayRollDetailsViewModel.Details = hRMMobPayRollspSelectUserCycle_Result;
						hrmUserPayRollDetailsViewModel.Payments = Enumerable.ToList<HRMMobPayRollspSelectUserPayments_Result>((IEnumerable<HRMMobPayRollspSelectUserPayments_Result>)cRMEntities.HRMMobPayRollspSelectUserPayments(cycleId, result, result2));
						hrmUserPayRollDetailsViewModel.ItemsAdditive = Enumerable.ToList<HRMMobPayRollspSelectUserCycleItemValues_Result>((IEnumerable<HRMMobPayRollspSelectUserCycleItemValues_Result>)cRMEntities.HRMMobPayRollspSelectUserCycleItemValues(cycleId, 1, result, result2));
						hrmUserPayRollDetailsViewModel.ItemsReduction = Enumerable.ToList<HRMMobPayRollspSelectUserCycleItemValues_Result>((IEnumerable<HRMMobPayRollspSelectUserCycleItemValues_Result>)cRMEntities.HRMMobPayRollspSelectUserCycleItemValues(cycleId, 2, result, result2));
						hrmUserPayRollDetailsViewModel.Commissions = Enumerable.ToList<HRMMobPayRollspSelectUserCycleOrderCommissions_Result>((IEnumerable<HRMMobPayRollspSelectUserCycleOrderCommissions_Result>)cRMEntities.HRMMobPayRollspSelectUserCycleOrderCommissions(cycleId, token2.userId, result, result2));
						HRMMobPayRollspReturnUserCycleFinalAmount_Result hRMMobPayRollspReturnUserCycleFinalAmount_Result = Enumerable.FirstOrDefault<HRMMobPayRollspReturnUserCycleFinalAmount_Result>((IEnumerable<HRMMobPayRollspReturnUserCycleFinalAmount_Result>)cRMEntities.HRMMobPayRollspReturnUserCycleFinalAmount(cycleId));
						if (hRMMobPayRollspReturnUserCycleFinalAmount_Result == null)
						{
							hrmUserPayRollDetailsViewModel.FinalAmount = new HRMMobPayRollspReturnUserCycleFinalAmount_Result();
						}
						else
						{
							hrmUserPayRollDetailsViewModel.FinalAmount = hRMMobPayRollspReturnUserCycleFinalAmount_Result;
						}
						message = Messages.MobMsgSuccessAction;
						status = ServiceResultStatus.Success;
					}
					else
					{
						message = Messages.MobMsgErorrNotFound;
						status = ServiceResultStatus.Error;
					}
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					hrmUserPayRollDetailsViewModel = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				hrmUserPayRollDetailsViewModel = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			hrmUserPayRollDetailsViewModel = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<HrmUserPayRollDetailsViewModel>
		{
			Message = message,
			Data = hrmUserPayRollDetailsViewModel,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<HrmUserPayRollSummaryViewModel>> UserPayRollSummary(DateTime fromDate, DateTime toDate, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<HrmUserPayRollSummaryViewModel> list = null;
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
					list = new List<HrmUserPayRollSummaryViewModel>();
					foreach (HRMMobPayRollspSelectUserCycle_Result item2 in Enumerable.ToList<HRMMobPayRollspSelectUserCycle_Result>((IEnumerable<HRMMobPayRollspSelectUserCycle_Result>)cRMEntities.HRMMobPayRollspSelectUserCycle(token2.userId, 0, fromDate, toDate, result, result2)))
					{
						HRMMobPayRollspReturnUserCycleFinalAmount_Result hRMMobPayRollspReturnUserCycleFinalAmount_Result = Enumerable.FirstOrDefault<HRMMobPayRollspReturnUserCycleFinalAmount_Result>((IEnumerable<HRMMobPayRollspReturnUserCycleFinalAmount_Result>)cRMEntities.HRMMobPayRollspReturnUserCycleFinalAmount(item2.PayRollUserCycleId));
						if (hRMMobPayRollspReturnUserCycleFinalAmount_Result != null)
						{
							HrmUserPayRollSummaryViewModel item = new HrmUserPayRollSummaryViewModel
							{
								Cycle = item2,
								FinalAmount = hRMMobPayRollspReturnUserCycleFinalAmount_Result
							};
							list.Add(item);
						}
					}
					message = Messages.MobMsgSuccessAction;
					status = ServiceResultStatus.Success;
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					list = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				list = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			list = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<List<HrmUserPayRollSummaryViewModel>>
		{
			Message = message,
			Data = list,
			Status = status
		};
	}
}
