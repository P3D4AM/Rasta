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

public class FOProfileController : ApiController
{
	[HttpPost]
	[FoMobileAuthorize]
	public ServiceResult<FOMobspSelectCompanyById_Result> SelectCompanyById(int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		FOMobspSelectCompanyById_Result fOMobspSelectCompanyById_Result = null;
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
				FoToken token2 = new FoCommon().GetToken(token);
				if (token2 != null)
				{
					cRMEntities = new CRMEntities();
					fOMobspSelectCompanyById_Result = Enumerable.FirstOrDefault<FOMobspSelectCompanyById_Result>((IEnumerable<FOMobspSelectCompanyById_Result>)cRMEntities.FOMobspSelectCompanyById(token2.CompanyId, result, result2, cId));
					if (fOMobspSelectCompanyById_Result != null)
					{
						message = Messages.MobMsgSuccessAction;
						status = ServiceResultStatus.Success;
					}
					else
					{
						message = Messages.MobMsgErrorCompanyNotFound;
						status = ServiceResultStatus.Error;
					}
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					fOMobspSelectCompanyById_Result = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				fOMobspSelectCompanyById_Result = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			fOMobspSelectCompanyById_Result = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<FOMobspSelectCompanyById_Result>
		{
			Message = message,
			Data = fOMobspSelectCompanyById_Result,
			Status = status
		};
	}
}
