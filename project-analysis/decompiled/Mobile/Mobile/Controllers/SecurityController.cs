using System;
using System.Linq;
using System.Web.Http;
using CRM.Resources;
using Elmah;
using GSD.Globalization;
using Microsoft.Ajax.Utilities;
using Mobile.Cache.Setting;
using Mobile.Classes;
using Mobile.Classes.Helper;
using Mobile.Models;
using Mobile.Models.ViewModel.Common;

namespace Mobile.Controllers;

public class SecurityController : ApiController
{
	[HttpPost]
	public string RegisterLoginKey(RegistrationModel model)
	{
		string result = "";
		string text = "";
		string text2 = "";
		string text3 = "";
		int result2 = 0;
		int result3 = 0;
		CRMEntities cRMEntities = null;
		CRMSpEntities cRMSpEntities = null;
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result4);
			int num = 1065;
			if (base.Request.Headers.Contains("imeiCode"))
			{
				text = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("imeiCode"));
			}
			if (base.Request.Headers.Contains("appName"))
			{
				text2 = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("appName"));
			}
			if (base.Request.Headers.Contains("deviceType"))
			{
				int.TryParse(Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("deviceType")), out result3);
			}
			if (base.Request.Headers.Contains("LangId"))
			{
				int.TryParse(Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("LangId")), out result2);
			}
			BaseInfo baseInfo = new BaseInfo();
			num = ((result2 > 0) ? result2 : 1065);
			int culture = ((num > 0) ? num : result4);
			baseInfo.SetCulture(culture);
			cRMEntities = new CRMEntities();
			cRMSpEntities = new CRMSpEntities();
			if (!model.encryptedKey.IsNullOrWhiteSpace() && !text.IsNullOrWhiteSpace() && !text2.IsNullOrWhiteSpace())
			{
				string text4 = new Security().DecryptAesKey(model.encryptedKey);
				if (!text4.IsNullOrWhiteSpace())
				{
					text3 = text4;
				}
				if (text3 != "")
				{
					DateTime now = DateTime.Now;
					DateTime value = now;
					string firstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					string appType = Mobile.Classes.Configuration.AppType;
					cRMEntities.MobspInsertUserAppDeviceInfo(-3, null, result3, text2, value, firstRegisterDatePersian, appType, text, null, text3);
					result = Messages.MobMsgSuccessAction;
				}
				else
				{
					result = Messages.MobUnitKeyNotFound;
				}
			}
		}
		catch (Exception e)
		{
			result = Messages.MobMsgErrorDoneOperation;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
			cRMSpEntities?.Dispose();
		}
		return result;
	}

	[HttpPost]
	public string RegisterFoLoginKey(RegistrationModel model)
	{
		string result = "";
		string text = "";
		string text2 = "";
		string text3 = "";
		int result2 = 0;
		int result3 = 0;
		CRMEntities cRMEntities = null;
		CRMSpEntities cRMSpEntities = null;
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result4);
			int num = 1065;
			if (base.Request.Headers.Contains("imeiCode"))
			{
				text = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("imeiCode"));
			}
			if (base.Request.Headers.Contains("appName"))
			{
				text2 = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("appName"));
			}
			if (base.Request.Headers.Contains("devicetype"))
			{
				int.TryParse(Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("devicetype")), out result3);
			}
			if (base.Request.Headers.Contains("langid"))
			{
				int.TryParse(Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("langid")), out result2);
			}
			BaseInfo baseInfo = new BaseInfo();
			num = ((result2 > 0) ? result2 : 1065);
			int culture = ((num > 0) ? num : result4);
			baseInfo.SetCulture(culture);
			cRMEntities = new CRMEntities();
			cRMSpEntities = new CRMSpEntities();
			if (!model.encryptedKey.IsNullOrWhiteSpace() && !text.IsNullOrWhiteSpace() && !text2.IsNullOrWhiteSpace())
			{
				string text4 = new Security().DecryptAesKey(model.encryptedKey);
				if (!text4.IsNullOrWhiteSpace())
				{
					text3 = text4;
				}
				if (text3 != "")
				{
					DateTime now = DateTime.Now;
					DateTime value = now;
					string firstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					CRMSpEntities cRMSpEntities2 = cRMSpEntities;
					int? deviceType = result3;
					string appName = text2;
					cRMSpEntities2.FOMobspInsertCompanyAppDeviceInfo(null, null, deviceType, value, firstRegisterDatePersian, text, appName, text3);
					result = Messages.MobMsgSuccessAction;
				}
				else
				{
					result = Messages.MobUnitKeyNotFound;
				}
			}
		}
		catch (Exception e)
		{
			result = Messages.MobMsgErrorDoneOperation;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
			cRMSpEntities?.Dispose();
		}
		return result;
	}
}
