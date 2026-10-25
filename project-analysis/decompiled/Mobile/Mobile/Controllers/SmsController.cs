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

public class SmsController : ApiController
{
	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<ConversationViewModel> SelectSmsSendedWithId(int smsid, int prjid, int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		ConversationViewModel data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		try
		{
			if (!UserLogin.IsUserAccess("frmMain", "actCompany", UserLogin.CurrentUser, cId))
			{
				return new ServiceResult<ConversationViewModel>
				{
					Message = Messages.MobMsgErrorAccessLimited,
					Data = null,
					Status = ServiceResultStatus.Fail
				};
			}
			cRMEntities = new CRMEntities();
			MobspSelectSmsSendedWithID_Result mobspSelectSmsSendedWithID_Result = Enumerable.FirstOrDefault<MobspSelectSmsSendedWithID_Result>((IEnumerable<MobspSelectSmsSendedWithID_Result>)Enumerable.ToList<MobspSelectSmsSendedWithID_Result>((IEnumerable<MobspSelectSmsSendedWithID_Result>)cRMEntities.MobspSelectSmsSendedWithID(smsid, result, result2)));
			if (mobspSelectSmsSendedWithID_Result != null)
			{
				Dictionary<string, object> otherFields = Enumerable.ToDictionary<string[], string, object>(Enumerable.Select<string, string[]>((IEnumerable<string>)mobspSelectSmsSendedWithID_Result.otherFields.Split(new string[1] { "@|$|@" }, StringSplitOptions.None), (Func<string, string[]>)((string oi) => oi.Split(new string[1] { "@^$|@" }, StringSplitOptions.None))), (Func<string[], string>)((string[] arrOi) => arrOi[0]), (Func<string[], object>)((string[] arrOi) => arrOi[1]));
				Dictionary<string, object> otherFieldsHeader = Enumerable.ToDictionary<string[], string, object>(Enumerable.Select<string, string[]>((IEnumerable<string>)mobspSelectSmsSendedWithID_Result.otherFieldsHeader.Split(new string[1] { "@|$|@" }, StringSplitOptions.None), (Func<string, string[]>)((string oi) => oi.Split(new string[1] { "@^$|@" }, StringSplitOptions.None))), (Func<string[], string>)((string[] arrOi) => arrOi[0]), (Func<string[], object>)((string[] arrOi) => arrOi[1]));
				int result3 = 0;
				int.TryParse(mobspSelectSmsSendedWithID_Result.CompanyId.ToString(), out result3);
				data = new ConversationViewModel
				{
					CompanyID = result3,
					ProjectID = prjid,
					OprTypeId = 4,
					Opr = "SSms",
					OprId = mobspSelectSmsSendedWithID_Result.ID,
					otherFields = otherFields,
					otherFieldsHeader = otherFieldsHeader,
					CountPage = 0,
					CoordinateLatitude = "",
					CoordinateLongitude = "",
					CnvsFiles = null
				};
			}
			message = "";
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
			cRMEntities?.Dispose();
		}
		return new ServiceResult<ConversationViewModel>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<ConversationViewModel> SelectSmsReceivedWithId(int smsid, int prjid, int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		ConversationViewModel data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		try
		{
			if (!UserLogin.IsUserAccess("frmMain", "actCompany", UserLogin.CurrentUser, cId))
			{
				return new ServiceResult<ConversationViewModel>
				{
					Message = Messages.MobMsgErrorAccessLimited,
					Data = null,
					Status = ServiceResultStatus.Fail
				};
			}
			cRMEntities = new CRMEntities();
			MobspSelectSmsReceivedWithID_Result mobspSelectSmsReceivedWithID_Result = Enumerable.FirstOrDefault<MobspSelectSmsReceivedWithID_Result>((IEnumerable<MobspSelectSmsReceivedWithID_Result>)Enumerable.ToList<MobspSelectSmsReceivedWithID_Result>((IEnumerable<MobspSelectSmsReceivedWithID_Result>)cRMEntities.MobspSelectSmsReceivedWithID(smsid, result, result2)));
			if (mobspSelectSmsReceivedWithID_Result != null)
			{
				Dictionary<string, object> otherFields = Enumerable.ToDictionary<string[], string, object>(Enumerable.Select<string, string[]>((IEnumerable<string>)mobspSelectSmsReceivedWithID_Result.otherFields.Split(new string[1] { "@|$|@" }, StringSplitOptions.None), (Func<string, string[]>)((string oi) => oi.Split(new string[1] { "@^$|@" }, StringSplitOptions.None))), (Func<string[], string>)((string[] arrOi) => arrOi[0]), (Func<string[], object>)((string[] arrOi) => arrOi[1]));
				Dictionary<string, object> otherFieldsHeader = Enumerable.ToDictionary<string[], string, object>(Enumerable.Select<string, string[]>((IEnumerable<string>)mobspSelectSmsReceivedWithID_Result.otherFieldsHeader.Split(new string[1] { "@|$|@" }, StringSplitOptions.None), (Func<string, string[]>)((string oi) => oi.Split(new string[1] { "@^$|@" }, StringSplitOptions.None))), (Func<string[], string>)((string[] arrOi) => arrOi[0]), (Func<string[], object>)((string[] arrOi) => arrOi[1]));
				int result3 = 0;
				int.TryParse(mobspSelectSmsReceivedWithID_Result.CompanyId.ToString(), out result3);
				data = new ConversationViewModel
				{
					CompanyID = result3,
					ProjectID = prjid,
					OprTypeId = 6,
					Opr = "RSms",
					OprId = mobspSelectSmsReceivedWithID_Result.Id,
					otherFields = otherFields,
					otherFieldsHeader = otherFieldsHeader,
					CountPage = 0,
					CoordinateLatitude = "",
					CoordinateLongitude = "",
					CnvsFiles = null
				};
			}
			message = "";
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
			cRMEntities?.Dispose();
		}
		return new ServiceResult<ConversationViewModel>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<bool> SendSmsSingleWeb(SmsSendViewModel newSms)
	{
		int result = 1065;
		if (newSms.LangId.HasValue)
		{
			int.TryParse(newSms.LangId.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		bool data = false;
		string text = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		try
		{
			newSms.SendType = 1;
			newSms.Sid = -1;
			newSms.SmsNumberCount = 1;
			text = new Sms().SendSmsSingle(newSms);
			if (string.IsNullOrEmpty(text))
			{
				data = true;
				status = ServiceResultStatus.Success;
			}
			else
			{
				data = false;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			text = Messages.MobMsgErrorDoneOperation;
			data = false;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<bool>
		{
			Message = text,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<bool> SendSmsSingleGsm(SmsSendViewModel newSms)
	{
		int result = 1065;
		if (newSms.LangId.HasValue)
		{
			int.TryParse(newSms.LangId.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		bool data = false;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		try
		{
			Sms.GetSmsSetting(out var _);
			if (newSms != null)
			{
				Sms sms = new Sms();
				newSms.SendType = 21;
				newSms.Sid = -1;
				newSms.SmsNumberCount = 1;
				if (string.IsNullOrEmpty(sms.SendSmsToGsmServer(newSms)))
				{
					data = true;
					status = ServiceResultStatus.Success;
				}
				else
				{
					data = false;
					status = ServiceResultStatus.Error;
					message = "ارسال پیام با مشکل مواجه شد";
				}
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = false;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<bool>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	public long ReturnRemainCredit()
	{
		long result = 0L;
		try
		{
			new CRMEntities();
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}
}
