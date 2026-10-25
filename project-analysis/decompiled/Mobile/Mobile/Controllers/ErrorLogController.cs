using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using CRM.Resources;
using Elmah;
using GSD.Globalization;
using Mobile.Cache.Setting;
using Mobile.Classes.Helper;
using Mobile.DataType;
using Mobile.Models;

namespace Mobile.Controllers;

public class ErrorLogController : ApiController
{
	[HttpPost]
	public ServiceResult<string> Insert(InsertErrorLogViewModel parameters)
	{
		string data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		CRMEntities cRMEntities = null;
		try
		{
			int result = 1065;
			_ = parameters.LanguageId;
			int.TryParse(parameters.LanguageId.ToString(), out result);
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			BaseInfo baseInfo = new BaseInfo();
			int culture = ((result > 0) ? result : result2);
			baseInfo.SetCulture(culture);
			cRMEntities = new CRMEntities();
			string registerDatePersian = parameters.RegisterDate.ToString("yyyyMMdd", new PersianCulture());
			int? num = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.MobspInsertErrorLogs(parameters.ActivityName, parameters.Cause, parameters.Discription, parameters.AndroidVersion, parameters.ApplicationVersion, parameters.ApiVersion, parameters.InternetType, parameters.DeviceResolution, parameters.UserId, parameters.UserName, parameters.CompanyId, parameters.CompanyName, parameters.CompanyPersonId, parameters.PersonName, parameters.RegisterDate, registerDatePersian, result));
			int result3 = 0;
			int.TryParse(num.ToString(), out result3);
			if (result3 > 0)
			{
				data = "Ok";
				message = "Ok";
				status = ServiceResultStatus.Success;
			}
			else
			{
				data = "NO";
				message = "Error";
				status = ServiceResultStatus.Fail;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = "NO";
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<string>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}
}
