using System;
using System.Linq;
using System.Web.Http;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Areas.Company.Controllers;
using CRMIdeal.Areas.OtherSystems.Controllers;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.Classes.Helper;
using Elmah;

namespace CRMIdeal.Controllers;

public class CompanyApiController : ApiController
{
	[HttpPost]
	public ServiceResult<dynamic> ShpGetCompanyAllPayRemain(int cmpId = 0, int linkAccSettingDBId = 0, int? cId = null, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		int culture = ((result > 0) ? result : result2);
		new BaseInfo().SetCulture(culture);
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		decimal? num = default(decimal);
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			num = ((CurrentCompanyRemainAmountViewModel)new CompanyInfoController().GetRemainAmountFromAccLink(cmpId).Data).AllPayRemain;
			message = Messages.msgSuccessAction;
			status = ServiceResultStatus.Success;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			message = Messages.MobMsgErrorDoneOperation;
			status = ServiceResultStatus.Error;
			num = null;
		}
		finally
		{
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<object>
		{
			Message = message,
			Data = num,
			Status = status
		};
	}

	[HttpPost]
	[MobileApiAuthorize]
	public ServiceResult<CurrentCompanyRemainAmountViewModel> GetCompanyPayRemain(int cmpId = 0, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		int culture = ((result > 0) ? result : result2);
		new BaseInfo().SetCulture(culture);
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		CurrentCompanyRemainAmountViewModel data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new MobileApi().GetToken(token) != null)
				{
					data = (CurrentCompanyRemainAmountViewModel)new CompanyInfoController().GetRemainAmountFromAccLink(cmpId).Data;
					message = Messages.msgSuccessAction;
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
			ErrorSignal.FromCurrentContext().Raise(e);
			message = Messages.MobMsgErrorDoneOperation;
			status = ServiceResultStatus.Error;
			data = null;
		}
		finally
		{
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<CurrentCompanyRemainAmountViewModel>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<CurrentCompanyCreditAmountViewModel> GetCmpCreditFromAccLink(int cmpId, bool checkAction = true, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		int culture = ((result > 0) ? result : result2);
		new BaseInfo().SetCulture(culture);
		CurrentCompanyCreditAmountViewModel currentCompanyCreditAmountViewModel = null;
		string text = "";
		ServiceResultStatus serviceResultStatus = ServiceResultStatus.Fail;
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new MobileApi().GetToken(token) != null)
				{
					currentCompanyCreditAmountViewModel = new CurrentCompanyCreditAmountViewModel();
					CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
					bool flag = false;
					int num = 0;
					if (cRMspSelectCrmsysSetting_Result != null)
					{
						flag = ((cRMspSelectCrmsysSetting_Result.CmpAccFromLink.HasValue && cRMspSelectCrmsysSetting_Result.CmpAccFromLink.GetValueOrDefault()) ? true : false);
						num = cRMspSelectCrmsysSetting_Result.LinkAccSystemId.GetValueOrDefault();
					}
					decimal creditAccount = default(decimal);
					string creditFormated = Labels.lblCmpAccSummaryCreditNull;
					string creditInSummery = "";
					string creditFormatedForTitle = Labels.lblCmpAccSummaryCreditNull;
					if (flag && num > 0)
					{
						CompanyController companyController = new CompanyController();
						string linkAccSystemTitle = Setting.GetLinkAccSystemTitle();
						if (companyController.LinkAccGetCmpCredit(num, 0, cmpId, ref creditAccount) != "no_credit_in-sysacc")
						{
							creditFormated = string.Format(Labels.lblCmpAccSummaryCredit, "", $"{creditAccount:N2}");
							creditInSummery = string.Format(Labels.lblCmpAccSummaryCreditInSummary, "(" + linkAccSystemTitle + ")", $"{creditAccount:N0}");
							creditFormatedForTitle = string.Format(Labels.lblCmpAccSummaryCredit, "(" + linkAccSystemTitle + ")", $"{creditAccount:N2}");
						}
					}
					currentCompanyCreditAmountViewModel.Credit = creditAccount;
					currentCompanyCreditAmountViewModel.CreditFormated = creditFormated;
					currentCompanyCreditAmountViewModel.CreditInSummery = creditInSummery;
					currentCompanyCreditAmountViewModel.CreditFormatedForTitle = creditFormatedForTitle;
					text = "";
					serviceResultStatus = ServiceResultStatus.Success;
				}
				else
				{
					text = Messages.MobMsgErrorAccessingToken;
					currentCompanyCreditAmountViewModel = null;
					serviceResultStatus = ServiceResultStatus.Error;
				}
			}
			else
			{
				text = Messages.MobMsgErrorAccessingToken;
				currentCompanyCreditAmountViewModel = null;
				serviceResultStatus = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			text = Messages.MobMsgErrorDoneOperation;
			serviceResultStatus = ServiceResultStatus.Error;
			currentCompanyCreditAmountViewModel = null;
		}
		return new ServiceResult<CurrentCompanyCreditAmountViewModel>
		{
			Message = text,
			Data = currentCompanyCreditAmountViewModel,
			Status = serviceResultStatus
		};
	}
}
