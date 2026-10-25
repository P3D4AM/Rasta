using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web.Http;
using System.Web.Mvc;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Areas.Emails.Controllers;
using CRMIdeal.Areas.Sms.Controllers;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes.Common;
using CRMIdeal.Classes.Helper;
using CRMIdeal.GSD.Globalization;
using Newtonsoft.Json;

namespace CRMIdeal.Controllers;

public class AutomaticEventsController : ApiController
{
	public void AutoSendSMSBirthCongratulate()
	{
		CRMSpIEntities cRMSpIEntities = null;
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			string appType = CRMIdeal.Classes.Common.Configuration.AppType;
			SmsSettingInfoViewModel smsSettingInfoViewModel = SmsSeting.Get();
			if (smsSettingInfoViewModel != null)
			{
				bool result2 = false;
				bool.TryParse(smsSettingInfoViewModel.ActiveSendBirthCongratulate.ToString(), out result2);
				string value = smsSettingInfoViewModel.SendBirthCongratulateText ?? "";
				DateTime now = DateTime.Now;
				string birthDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				if (result2 && !string.IsNullOrWhiteSpace(value))
				{
					cRMSpIEntities = new CRMSpIEntities();
					cRMSpIEntities.CRMspAutoSendSMSBirthCongratulate(now, birthDatePersian, appType, lCID, result);
				}
			}
		}
		catch (Exception)
		{
		}
		finally
		{
			cRMSpIEntities?.Dispose();
		}
	}

	public void AutoSendSMSMarriageCongratulate()
	{
		CRMSpIEntities cRMSpIEntities = null;
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			string appType = CRMIdeal.Classes.Common.Configuration.AppType;
			SmsSettingInfoViewModel smsSettingInfoViewModel = SmsSeting.Get();
			if (smsSettingInfoViewModel != null)
			{
				bool result2 = false;
				bool.TryParse(smsSettingInfoViewModel.ActiveSendMarriageCongratulate.ToString(), out result2);
				string value = smsSettingInfoViewModel.SendMarriageCongratulateText ?? "";
				DateTime now = DateTime.Now;
				string marriageDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				if (result2 && !string.IsNullOrWhiteSpace(value))
				{
					new Sms();
					cRMSpIEntities = new CRMSpIEntities();
					cRMSpIEntities.CRMspAutoSendSMSMarriageCongratulate(now, marriageDatePersian, appType, lCID, result);
				}
			}
		}
		catch (Exception)
		{
		}
		finally
		{
			cRMSpIEntities?.Dispose();
		}
	}

	public void ReceivedSms(int userId = 3)
	{
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			_ = CRMIdeal.Classes.Common.Configuration.AppType;
			if (SmsSeting.Get() != null)
			{
				new SmsInfoController().GetAllReceivedSms(userId);
			}
		}
		catch (Exception)
		{
		}
	}

	public void AutoSendSMSReceiveAnswer()
	{
		CRMSpIEntities cRMSpIEntities = null;
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			string appType = CRMIdeal.Classes.Common.Configuration.AppType;
			SmsSettingInfoViewModel smsSettingInfoViewModel = SmsSeting.Get();
			if (smsSettingInfoViewModel != null)
			{
				bool result2 = false;
				bool.TryParse(smsSettingInfoViewModel.ActiveSendSMSAfterReceive.ToString(), out result2);
				string value = smsSettingInfoViewModel.SendSMSAfterReceiveText ?? "";
				DateTime now = DateTime.Now;
				now.ToString("yyyyMMdd", new PersianCulture());
				if (result2 && !string.IsNullOrWhiteSpace(value))
				{
					cRMSpIEntities = new CRMSpIEntities();
					cRMSpIEntities.CRMspAutoSendSMSReceiveAnswer(now, appType, lCID, result);
				}
			}
		}
		catch (Exception)
		{
		}
		finally
		{
			cRMSpIEntities?.Dispose();
		}
	}

	public void SendAutoSMSFromTankByWeb()
	{
		CRMSpIEntities cRMSpIEntities = null;
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			_ = CRMIdeal.Classes.Common.Configuration.AppType;
			if (SmsSeting.Get() != null)
			{
				new Sms().SendSMSTank();
			}
		}
		catch (Exception)
		{
		}
		finally
		{
			cRMSpIEntities?.Dispose();
		}
	}

	public string GetSMSWebServerCredit(int smsProviderId)
	{
		string text = "";
		try
		{
			string errorMessage = "";
			decimal num = default(decimal);
			decimal smsPanelCreditCount = default(decimal);
			num = new Sms().GetSMSWebServerCredit(smsProviderId, ref errorMessage, ref smsPanelCreditCount);
			text = num + "|";
			text = num + "|" + smsPanelCreditCount + "|";
			if (!string.IsNullOrWhiteSpace(errorMessage))
			{
				text += errorMessage;
			}
			if (!string.IsNullOrWhiteSpace(errorMessage))
			{
				text += errorMessage;
			}
		}
		catch (Exception ex)
		{
			text = "Error: " + ex.Message;
		}
		return text;
	}

	public void ReceivedEmail(DateTime? fromDateTime = null, DateTime? toDateTime = null)
	{
		CRMSpIEntities cRMSpIEntities = null;
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			_ = CRMIdeal.Classes.Common.Configuration.AppType;
			if (EmailSettings.Get() == null)
			{
				return;
			}
			DateTime now = DateTime.Now;
			string text = now.ToString("yyyyMMdd", new PersianCulture());
			string text2 = "";
			if (fromDateTime.HasValue)
			{
				text2 = fromDateTime?.ToString("yyyyMMdd");
			}
			string text3 = "";
			if (toDateTime.HasValue)
			{
				text3 = toDateTime?.ToString("yyyyMMdd");
			}
			text = lCID switch
			{
				1065 => now.ToString("yyyyMMdd", new PersianCulture()), 
				1025 => now.ToString("yyyyMMdd", new CultureInfo("ar-SA")), 
				_ => now.ToString("yyyyMMdd", new CultureInfo("en-US")), 
			};
			cRMSpIEntities = new CRMSpIEntities();
			List<EmailspSelectAllActiveEmailUsersInfo_Result> list = Enumerable.ToList<EmailspSelectAllActiveEmailUsersInfo_Result>((IEnumerable<EmailspSelectAllActiveEmailUsersInfo_Result>)cRMSpIEntities.EmailspSelectAllActiveEmailUsersInfo(lCID, result));
			if (list == null || !Enumerable.Any<EmailspSelectAllActiveEmailUsersInfo_Result>((IEnumerable<EmailspSelectAllActiveEmailUsersInfo_Result>)list))
			{
				return;
			}
			foreach (EmailspSelectAllActiveEmailUsersInfo_Result item in list)
			{
				JsonResult jsonResult = new ReceiveEmailController().ReceiveAllEmailsFromServer(item.EmailUsersInfoId, string.IsNullOrWhiteSpace(text2) ? text : text2, string.IsNullOrWhiteSpace(text3) ? text : text3, useInJob: true);
				if (jsonResult == null || jsonResult.Data == null)
				{
					continue;
				}
				string value = JsonConvert.SerializeObject(jsonResult.Data);
				if (!string.IsNullOrWhiteSpace(value))
				{
					CommonResultViewModel<bool> commonResultViewModel = JsonConvert.DeserializeObject<CommonResultViewModel<bool>>(value);
					if (commonResultViewModel != null && commonResultViewModel.Status != CommonResultStatusViewModel.Success)
					{
						string text4 = commonResultViewModel.Message ?? "";
						new Exception(Messages.msgErrorRunFunction + "(ReceivedEmail in Webservice: " + text4 + ")");
					}
				}
			}
		}
		catch (Exception)
		{
		}
		finally
		{
			cRMSpIEntities?.Dispose();
		}
	}

	public void SendEmailsFromTank()
	{
		CRMSpIEntities cRMSpIEntities = null;
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			_ = CRMIdeal.Classes.Common.Configuration.AppType;
			if (EmailSettings.Get() == null)
			{
				return;
			}
			JsonResult jsonResult = new CRMIdeal.Areas.Emails.Controllers.SendTankController().ActSendEmail();
			if (jsonResult == null || jsonResult.Data == null)
			{
				return;
			}
			string value = JsonConvert.SerializeObject(jsonResult.Data);
			if (!string.IsNullOrWhiteSpace(value))
			{
				CommonResultViewModel<string> commonResultViewModel = JsonConvert.DeserializeObject<CommonResultViewModel<string>>(value);
				if (commonResultViewModel != null && commonResultViewModel.Status != CommonResultStatusViewModel.Success)
				{
					string text = commonResultViewModel.Message ?? "";
					new Exception(Messages.msgErrorRunFunction + "(SendEmailsFromTank in Webservice: " + text + ")");
				}
			}
		}
		catch (Exception)
		{
		}
		finally
		{
			cRMSpIEntities?.Dispose();
		}
	}

	public void AutoCloseTicketAfterDay()
	{
		CRMSpIEntities cRMSpIEntities = null;
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			string appType = CRMIdeal.Classes.Common.Configuration.AppType;
			cRMSpIEntities = new CRMSpIEntities();
			cRMSpIEntities.CRMspAutoCloseTicketAfterDay(appType);
		}
		catch (Exception)
		{
		}
		finally
		{
			cRMSpIEntities?.Dispose();
		}
	}

	public string SendSingleSms(string model)
	{
		string text = "";
		try
		{
			if (!string.IsNullOrWhiteSpace(model.Replace("[]", "").Trim()))
			{
				SmsSendViewModel smsSendViewModel = new SmsSendViewModel();
				smsSendViewModel = JsonConvert.DeserializeObject<SmsSendViewModel>(model);
				smsSendViewModel.SendType = 1;
				smsSendViewModel.Sid = -1;
				smsSendViewModel.SmsNumberCount = 1;
				smsSendViewModel.CompaniesId = smsSendViewModel.CompaniesId ?? "";
				return new Sms().SendSmsSingle(smsSendViewModel);
			}
			return string.Format(Messages.ErrorEmpty, "model");
		}
		catch (Exception ex)
		{
			return "Error: " + ex.Message;
		}
	}

	public string SendGroupSms(int? userId, string model)
	{
		string text = "";
		try
		{
			if (!string.IsNullOrWhiteSpace(model.Replace("[]", "").Trim()))
			{
				SmsSendViewModel smsSendViewModel = new SmsSendViewModel();
				smsSendViewModel = JsonConvert.DeserializeObject<SmsSendViewModel>(model);
				smsSendViewModel.SendType = 2;
				smsSendViewModel.Sid = -1;
				smsSendViewModel.CompaniesId = smsSendViewModel.CompaniesId ?? "";
				smsSendViewModel.SmsNumberCount = smsSendViewModel.Numbers.Split(new char[1] { ',' }).Length;
				return new Sms().SendSms(smsSendViewModel, userId);
			}
			return string.Format(Messages.ErrorEmpty, "model");
		}
		catch (Exception ex)
		{
			return "Error: " + ex.Message;
		}
	}

	public string SendGroupSmsOneToOne(int? userId, string model)
	{
		string text = "";
		try
		{
			if (!string.IsNullOrWhiteSpace(model.Replace("[]", "").Trim()))
			{
				SmsSendViewModel smsSendViewModel = new SmsSendViewModel();
				smsSendViewModel = JsonConvert.DeserializeObject<SmsSendViewModel>(model);
				smsSendViewModel.SendType = 3;
				smsSendViewModel.Sid = -1;
				smsSendViewModel.CompaniesId = smsSendViewModel.CompaniesId ?? "";
				smsSendViewModel.SmsNumberCount = smsSendViewModel.Numbers.Split(new char[1] { ',' }).Length;
				return new Sms().SendSmsOneToOne(smsSendViewModel, userId);
			}
			return string.Format(Messages.ErrorEmpty, "model");
		}
		catch (Exception ex)
		{
			return "Error: " + ex.Message;
		}
	}

	public void PendingOperationsComplete()
	{
		new PendingOperations().StartPendingOperations();
	}
}
