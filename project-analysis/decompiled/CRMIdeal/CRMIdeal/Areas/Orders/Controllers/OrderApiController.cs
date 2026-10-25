using System;
using System.Linq;
using System.Web.Http;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.Classes.Helper;
using Elmah;

namespace CRMIdeal.Areas.Orders.Controllers;

public class OrderApiController : ApiController
{
	[MobileApiAuthorize]
	public ServiceResult<string> IssueDraftAuto(int orderId, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		int num = ((result > 0) ? result : result2);
		CRMSpEntities cRMSpEntities = null;
		string data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		new BaseInfo().SetCulture(num);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				MobileApiTokenViewModel token2 = new MobileApi().GetToken(token);
				if (token2 != null)
				{
					string refResult = null;
					if (Order.IssueDraftAuto(orderId, token2.userId, ref refResult, num))
					{
						status = ServiceResultStatus.Success;
						data = refResult;
						message = Messages.msgSuccessAction;
					}
					else
					{
						status = ServiceResultStatus.Error;
						data = null;
						message = refResult;
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
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<string>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}
}
