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

public class BookMarkCartableController : ApiController
{
	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<MobspResultsBookMarksCartable_Result>> ResultsBookMarksCartable(int referUserId, int? pageNumber = 1, int? pageSize = 10, int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<MobspResultsBookMarksCartable_Result> data = null;
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
					CRMEntities cRMEntities2 = cRMEntities;
					int? cnvsReferUserId = referUserId;
					int? userID = token2.userId;
					int? pageNumber2 = pageNumber;
					data = Enumerable.ToList<MobspResultsBookMarksCartable_Result>((IEnumerable<MobspResultsBookMarksCartable_Result>)cRMEntities2.MobspResultsBookMarksCartable(cnvsReferUserId, userID, result, result2, pageNumber2, pageSize, cId));
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
		return new ServiceResult<List<MobspResultsBookMarksCartable_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}
}
