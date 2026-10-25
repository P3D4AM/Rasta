using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Web.Http;
using CRM.Resources;
using Elmah;
using GSD.Globalization;
using Mobile.Cache.Setting;
using Mobile.Classes;
using Mobile.Classes.Helper;
using Mobile.DataType;
using Mobile.Models;

namespace Mobile.Controllers;

public class CICCallHistoryController : ApiController
{
	[HttpPost]
	public ServiceResult<CicInsertCallHistoryResultViewModel> InsertCallHistory(CicInsertCallHistoryViewModel model)
	{
		int result = 1065;
		if (model.LanguageId.HasValue)
		{
			int.TryParse(model.LanguageId.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		CicInsertCallHistoryResultViewModel cicInsertCallHistoryResultViewModel;
		try
		{
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			short value2 = short.Parse(now.ToString("yyyy", new PersianCulture()));
			short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Mobile.Classes.Configuration.AppType;
			int.Parse(Financial.Get().Id.ToString());
			DateTime value4 = model.CallDateTime ?? DateTime.Now;
			string callDate = value4.ToString("yyyyMMdd", new PersianCulture());
			string callDay = value4.ToString("dddd", new PersianCulture());
			string callTime = value4.ToString("HH:mm:ss", new PersianCulture());
			cRMSpEntities = new CRMSpEntities();
			CICMobspCallerIDSearch_Result cICMobspCallerIDSearch_Result = Enumerable.FirstOrDefault<CICMobspCallerIDSearch_Result>((IEnumerable<CICMobspCallerIDSearch_Result>)cRMSpEntities.CICMobspCallerIDSearch(model.TelNumber, result, result2));
			ObjectParameter objectParameter = new ObjectParameter("InsertedId", 0);
			CRMSpEntities cRMSpEntities2 = cRMSpEntities;
			int? callTypeId = model.CallType;
			int? lineNumber = 100;
			string telNumber = model.TelNumber;
			int? companyID = cICMobspCallerIDSearch_Result?.CompanyID;
			DateTime? callDateTime = value4;
			int? userID = model.UserId;
			short? year = value2;
			short? month = value3;
			DateTime? registerDate = value;
			string duration = model.Duration;
			int? companyPersonID = cICMobspCallerIDSearch_Result?.CompanyPersonID;
			int? defaultLanguageID = result2;
			ObjectParameter insertedId = objectParameter;
			Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMSpEntities2.CICMobspInsertCallHistory(callTypeId, lineNumber, telNumber, companyID, callDateTime, callTime, callDate, callDay, userID, year, month, registerDate, registerDatePersian, "", "", duration, companyPersonID, null, null, appType, defaultLanguageID, null, null, null, null, null, null, null, null, null, insertedId));
			int result3 = 0;
			if (objectParameter.Value != null && objectParameter.Value.ToString() != null)
			{
				int.TryParse(objectParameter.Value.ToString(), out result3);
			}
			if (result3 <= 0)
			{
				cicInsertCallHistoryResultViewModel = null;
				message = Messages.MobMsgErrorSubmitCallInfo;
				status = ServiceResultStatus.Fail;
			}
			else
			{
				cicInsertCallHistoryResultViewModel = new CicInsertCallHistoryResultViewModel();
				cicInsertCallHistoryResultViewModel.InsertedId = result3;
				cicInsertCallHistoryResultViewModel.CallerIdInfo = cICMobspCallerIDSearch_Result;
				message = Messages.MobMsgSuccessAction;
				status = ServiceResultStatus.Success;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			cicInsertCallHistoryResultViewModel = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<CicInsertCallHistoryResultViewModel>
		{
			Message = message,
			Data = cicInsertCallHistoryResultViewModel,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<CICMobspCallerIDSearch_Result> CallerIDSearch(string telNumber, int? ln = 1065)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		CICMobspCallerIDSearch_Result data;
		try
		{
			cRMSpEntities = new CRMSpEntities();
			data = Enumerable.FirstOrDefault<CICMobspCallerIDSearch_Result>((IEnumerable<CICMobspCallerIDSearch_Result>)cRMSpEntities.CICMobspCallerIDSearch(telNumber, result, result2));
			message = Messages.MobMsgSuccessAction;
			status = ServiceResultStatus.Success;
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
		return new ServiceResult<CICMobspCallerIDSearch_Result>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}
}
