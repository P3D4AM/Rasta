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

public class HRMHistoryController : ApiController
{
	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<TimeAttendanceHistoryResultViewModel> TimeAttendanceHistory(int userId, DateTime fromDate, DateTime toDate, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		TimeAttendanceHistoryResultViewModel timeAttendanceHistoryResultViewModel = null;
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
				if (new Common().GetToken(token) != null)
				{
					cRMEntities = new CRMEntities();
					timeAttendanceHistoryResultViewModel = new TimeAttendanceHistoryResultViewModel();
					timeAttendanceHistoryResultViewModel.Result = Enumerable.ToList<HRMMobspSelectTimeAttendance_Result>((IEnumerable<HRMMobspSelectTimeAttendance_Result>)cRMEntities.HRMMobspSelectTimeAttendance(userID: userId, fDate: fromDate, tDate: toDate, languageID: result, defaultLanguageID: result2));
					timeAttendanceHistoryResultViewModel.Footer = Enumerable.FirstOrDefault<HRMMobspSelectTimeAttendanceFooter_Result>((IEnumerable<HRMMobspSelectTimeAttendanceFooter_Result>)cRMEntities.HRMMobspSelectTimeAttendanceFooter(userID: userId, fDate: fromDate, tDate: toDate, languageID: result, defaultLanguageID: result2));
					message = Messages.MobMsgSuccessAction;
					status = ServiceResultStatus.Success;
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					timeAttendanceHistoryResultViewModel = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				timeAttendanceHistoryResultViewModel = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			timeAttendanceHistoryResultViewModel = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<TimeAttendanceHistoryResultViewModel>
		{
			Message = message,
			Data = timeAttendanceHistoryResultViewModel,
			Status = status
		};
	}
}
