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

public class FODiscountController : ApiController
{
	[HttpPost]
	[FoMobileAuthorize]
	public ServiceResult<List<FOMobspSelectDiscountCodeByCmpId_Result>> GetDiscountCode(int cmpId, int pageNumber, int pageSize, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		List<FOMobspSelectDiscountCodeByCmpId_Result> data = null;
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
				if (new FoCommon().GetToken(token) != null)
				{
					cRMSpEntities = new CRMSpEntities();
					data = new List<FOMobspSelectDiscountCodeByCmpId_Result>();
					List<FOMobspSelectDiscountCodeByCmpId_Result> list = Enumerable.ToList<FOMobspSelectDiscountCodeByCmpId_Result>((IEnumerable<FOMobspSelectDiscountCodeByCmpId_Result>)cRMSpEntities.FOMobspSelectDiscountCodeByCmpId(cmpId, DateTime.Now, result, result2, pageNumber, pageSize));
					if (list != null)
					{
						data = list;
						message = Messages.MobMsgSuccessAction;
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
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<List<FOMobspSelectDiscountCodeByCmpId_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}
}
