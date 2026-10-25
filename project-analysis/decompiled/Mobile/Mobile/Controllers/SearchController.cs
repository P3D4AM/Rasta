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

public class SearchController : ApiController
{
	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<mct_MobspMainSearchQuick_Result>> MainSearchQuick(string value, int type = 1, string formName = null, int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<mct_MobspMainSearchQuick_Result> data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		try
		{
			if (string.IsNullOrEmpty(formName))
			{
				formName = "frmPreOrderDataEntry";
			}
			if (!UserLogin.IsUserAccess(formName, "actSearchCompany", UserLogin.CurrentUser, cId))
			{
				return new ServiceResult<List<mct_MobspMainSearchQuick_Result>>
				{
					Message = Messages.MobMsgErrorAccessLimited,
					Data = null,
					Status = ServiceResultStatus.Fail
				};
			}
			_ = Labels.MobPersonLabel;
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					cRMEntities = new CRMEntities();
					List<mct_MobspMainSearchQuick_Result> list = Enumerable.ToList<mct_MobspMainSearchQuick_Result>((IEnumerable<mct_MobspMainSearchQuick_Result>)cRMEntities.mfi_MobspMainSearchQuick(value, token2.userId, type, result, result2));
					foreach (mct_MobspMainSearchQuick_Result item in list)
					{
						item.CompanyID = item.CompanyID.GetValueOrDefault();
						item.cmpNumber = item.cmpNumber.GetValueOrDefault();
						item.cmpReferUserId = item.cmpReferUserId.GetValueOrDefault();
						item.prsId = item.prsId.GetValueOrDefault();
						item.prjId = item.prjId.GetValueOrDefault();
					}
					data = list;
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
			cRMEntities?.Dispose();
		}
		return new ServiceResult<List<mct_MobspMainSearchQuick_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<MobspSelectCompanyPersons_Result>> SelectCompanyPersons(int cmpId = 0, int? cId = null, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<MobspSelectCompanyPersons_Result> data = null;
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
					data = Enumerable.ToList<MobspSelectCompanyPersons_Result>((IEnumerable<MobspSelectCompanyPersons_Result>)cRMEntities.MobspSelectCompanyPersons(cmpId, result, result2, token2.userId, cId, null));
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
			cRMEntities?.Dispose();
		}
		return new ServiceResult<List<MobspSelectCompanyPersons_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}
}
