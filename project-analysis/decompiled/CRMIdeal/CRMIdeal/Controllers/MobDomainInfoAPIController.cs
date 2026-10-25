using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web.Http;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using Elmah;

namespace CRMIdeal.Controllers;

public class MobDomainInfoAPIController : ApiController
{
	[HttpPost]
	public ServiceResult<List<WSspSelectAllCrossOriginUrlPwaOrderItems_Result>> GetAllCrossOrgURLPWA()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		CRMSpIIEntities cRMSpIIEntities = new CRMSpIIEntities();
		List<WSspSelectAllCrossOriginUrlPwaOrderItems_Result> data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			string text = "MobCRMCrm1@3";
			string text2 = "";
			if (base.Request.Headers.Contains("token"))
			{
				text2 = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
			}
			if (string.IsNullOrWhiteSpace(text2))
			{
				message = Messages.msgErrorNotEnteredToken;
				data = null;
				status = ServiceResultStatus.Error;
			}
			else if (text2 != text)
			{
				message = Messages.msgErrorAccessingToken;
				data = null;
				status = ServiceResultStatus.Error;
			}
			else
			{
				List<WSspSelectAllCrossOriginUrlPwaOrderItems_Result> list = Enumerable.ToList<WSspSelectAllCrossOriginUrlPwaOrderItems_Result>((IEnumerable<WSspSelectAllCrossOriginUrlPwaOrderItems_Result>)cRMSpIIEntities.WSspSelectAllCrossOriginUrlPwaOrderItems());
				if (list == null)
				{
					list = new List<WSspSelectAllCrossOriginUrlPwaOrderItems_Result>();
				}
				message = Messages.msgSuccessAction;
				data = list;
				status = ServiceResultStatus.Success;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpIIEntities?.Dispose();
		}
		return new ServiceResult<List<WSspSelectAllCrossOriginUrlPwaOrderItems_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<WSspSelectMobAppInfoOrderItem_Result> GetCompanyModDomainInfo(MobDomainRequestVireModel model)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		CRMSpIIEntities cRMSpIIEntities = new CRMSpIIEntities();
		WSspSelectMobAppInfoOrderItem_Result data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			string text = "MobCRMCrm1@3";
			string text2 = "";
			if (base.Request.Headers.Contains("token"))
			{
				text2 = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
			}
			if (string.IsNullOrWhiteSpace(text2))
			{
				message = Messages.msgErrorNotEnteredToken;
				data = null;
				status = ServiceResultStatus.Error;
			}
			else if (text2 != text)
			{
				message = Messages.msgErrorAccessingToken;
				data = null;
				status = ServiceResultStatus.Error;
			}
			else if (!string.IsNullOrWhiteSpace(model.AppName) && !string.IsNullOrWhiteSpace(model.AppDomain))
			{
				WSspSelectMobAppInfoOrderItem_Result wSspSelectMobAppInfoOrderItem_Result = Enumerable.FirstOrDefault<WSspSelectMobAppInfoOrderItem_Result>((IEnumerable<WSspSelectMobAppInfoOrderItem_Result>)cRMSpIIEntities.WSspSelectMobAppInfoOrderItem(model.AppName, model.AppDomain, model.DevTypeId));
				message = Messages.msgSuccessAction;
				data = wSspSelectMobAppInfoOrderItem_Result;
				status = ServiceResultStatus.Success;
			}
			else
			{
				message = Messages.msgErrorRunFunction;
				data = null;
				status = ServiceResultStatus.Fail;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpIIEntities?.Dispose();
		}
		return new ServiceResult<WSspSelectMobAppInfoOrderItem_Result>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}
}
