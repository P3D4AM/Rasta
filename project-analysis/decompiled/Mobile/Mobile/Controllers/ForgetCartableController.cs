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

public class ForgetCartableController : ApiController
{
	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<MobspResultsForgetCompanyCartable_Result>> ResultsForgetCompanyCartable(ForgetCompanyCartableViewModel model)
	{
		int result = 1065;
		if (model.LanguageId.HasValue)
		{
			int.TryParse(model.LanguageId.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<MobspResultsForgetCompanyCartable_Result> data = null;
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
					string text = now.ToString("yyyy/MM/dd");
					string text2 = now.ToString("dddd");
					data = Enumerable.ToList<MobspResultsForgetCompanyCartable_Result>((IEnumerable<MobspResultsForgetCompanyCartable_Result>)cRMEntities.MobspResultsForgetCompanyCartable(model.FDate, model.TDate, model.FDateTime, model.TDateTime, model.CnvsStatusId, model.PrjTitle ?? "", model.CnvsUserId ?? "", model.CnvsReferUserId ?? "", model.NoRemindDate, token2.userId, text, text2, model.PrjPostFix ?? "", pageNumber: model.PageNumber, pageSize: model.PageSize, languageId: result, defaultLanguageId: result2, centerId: model.CenterId));
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
		return new ServiceResult<List<MobspResultsForgetCompanyCartable_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}
}
