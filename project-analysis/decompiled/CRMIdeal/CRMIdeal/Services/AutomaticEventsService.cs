using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.ServiceModel.Activation;
using System.Threading;
using System.Web.Mvc;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Areas.Emails.Controllers;
using CRMIdeal.Areas.Sms.Controllers;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes.Common;
using CRMIdeal.Classes.Helper;
using CRMIdeal.GSD.Globalization;
using Elmah;
using Newtonsoft.Json;

namespace CRMIdeal.Services;

[AspNetCompatibilityRequirements(/*Could not decode attribute arguments.*/)]
public class AutomaticEventsService : IAutomaticEventsService
{
	public bool CallAutomaticEvents(string username, string password)
	{
		bool result = false;
		CRMSpEntities cRMSpEntities = null;
		try
		{
			if (username == "Shir" && password == "Palang")
			{
				new Thread(AutoCloseTicketAfterDay).Start();
				if (VersionBuyer.SMS || VersionBuyer.GSM)
				{
					new Thread(AutoSendSMSBirthCongratulate).Start();
					new Thread(AutoSendSMSMarriageCongratulate).Start();
					new Thread(ReceivedSms).Start();
					new Thread(AutoSendSMSReceiveAnswer).Start();
					new Thread(SendAutoSMSFromTankByWeb).Start();
				}
				if (VersionBuyer.Emails)
				{
					new Thread(ReceivedEmail).Start();
					new Thread(SendEmailsFromTank).Start();
				}
				result = true;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			result = false;
		}
		finally
		{
			cRMSpEntities?.Dispose();
		}
		return result;
	}

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
			string appType = Configuration.AppType;
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
			string appType = Configuration.AppType;
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

	public void ReceivedSms()
	{
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			_ = Configuration.AppType;
			if (SmsSeting.Get() != null)
			{
				new SmsInfoController().GetAllReceivedSms();
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
			string appType = Configuration.AppType;
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
			_ = Configuration.AppType;
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

	public void ReceivedEmail()
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
			_ = Configuration.AppType;
			if (EmailSettings.Get() == null)
			{
				return;
			}
			DateTime now = DateTime.Now;
			string text = now.ToString("yyyyMMdd", new PersianCulture());
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
				JsonResult jsonResult = new ReceiveEmailController().ReceiveAllEmailsFromServer(item.EmailUsersInfoId, text, text, useInJob: true);
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
						string text2 = commonResultViewModel.Message ?? "";
						new Exception(Messages.msgErrorRunFunction + "(ReceivedEmail in Webservice: " + text2 + ")");
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
			_ = Configuration.AppType;
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
			string appType = Configuration.AppType;
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
}
