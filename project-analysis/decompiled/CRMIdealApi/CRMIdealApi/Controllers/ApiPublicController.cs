using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Http;
using CRM.General.Security;
using CRMIdealApi.ApiModels;
using CRMIdealApi.Classes;
using CRMIdealApi.Classes.Common;
using CRMIdealApi.Classes.Helper;
using CRMIdealApi.DataType;
using CRMIdealApi.Resources;
using Elmah;
using GSD.Globalization;
using Newtonsoft.Json;

namespace CRMIdealApi.Controllers;

public class ApiPublicController : ApiController
{
	[HttpPost]
	public ServiceResult<string> ApispDelayTicketsInsertTankSMSAndSendIngMsg(string username, string password, DateTime currentDateTime, int userId, int languageId)
	{
		CRMEntities cRMEntities = new CRMEntities();
		ResourceManager resourceManager = new ResourceManager();
		CommonClass commonClass = new CommonClass();
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		DateTime now = DateTime.Now;
		string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
		try
		{
			cRMEntities = new CRMEntities();
			ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
			if (apispSelectCrmsysSetting_Result == null)
			{
				return new ServiceResult<string>
				{
					Message = Messages.ErrorInReadingSysSetting,
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			int.TryParse(apispSelectCrmsysSetting_Result.DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int.TryParse(languageId.ToString(), out var currLangId);
			if (currLangId <= 0)
			{
				currLangId = result;
			}
			List<ApispSelectLanguages_Result> list = Enumerable.ToList<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)cRMEntities.ApispSelectLanguages());
			string rsCollation = "fa-IR";
			ApispSelectLanguages_Result apispSelectLanguages_Result = Enumerable.FirstOrDefault<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result m) => m.LanguageID == currLangId));
			if (apispSelectLanguages_Result != null)
			{
				rsCollation = apispSelectLanguages_Result.LanguageCollation;
			}
			int? num = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.ApispCheckUserAllowed(username, password));
			int result2 = 0;
			int.TryParse(num.ToString(), out result2);
			if (result2 == 0)
			{
				return new ServiceResult<string>
				{
					Message = resourceManager.Get("ErrorUsernamePasswordIncorrect", rsCollation, resourceManager.TypeMsg) + "\r\n" + resourceManager.Get("ErrorTryAgain", rsCollation, resourceManager.TypeMsg),
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			ApispDelayTicketsInsertTankSMSAndSendIngMsg_Result apispDelayTicketsInsertTankSMSAndSendIngMsg_Result = Enumerable.FirstOrDefault<ApispDelayTicketsInsertTankSMSAndSendIngMsg_Result>((IEnumerable<ApispDelayTicketsInsertTankSMSAndSendIngMsg_Result>)cRMEntities.ApispDelayTicketsInsertTankSMSAndSendIngMsg(currentDateTime, userId, 0, short.Parse(now.ToString("yyyy", new PersianCulture())), short.Parse(DateTime.Now.ToString("MM", new PersianCulture())), now, registerDatePersian, CRMIdealApi.Classes.Configuration.AppType, currLangId, result));
			if (apispDelayTicketsInsertTankSMSAndSendIngMsg_Result != null && apispDelayTicketsInsertTankSMSAndSendIngMsg_Result.TotalSmsSendedToTankSeperateByUsers.GetValueOrDefault() != 0)
			{
				status = ServiceResultStatus.Success;
			}
		}
		catch (Exception ex)
		{
			string text = ((!string.IsNullOrEmpty(ex.Message)) ? ex.Message : "");
			if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
			{
				text = text + " - " + ex.InnerException.Message;
			}
			message = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text)) ? (" (" + text + ")") : "");
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(ex);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<string>
		{
			Message = message,
			Data = null,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<string> ApispBusyTicketsInsertTankSMSAndSendIngMsg(string username, string password, DateTime currentDateTime, int userId, int languageId)
	{
		CRMEntities cRMEntities = new CRMEntities();
		ResourceManager resourceManager = new ResourceManager();
		CommonClass commonClass = new CommonClass();
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		DateTime now = DateTime.Now;
		string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
		try
		{
			cRMEntities = new CRMEntities();
			ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
			if (apispSelectCrmsysSetting_Result == null)
			{
				return new ServiceResult<string>
				{
					Message = Messages.ErrorInReadingSysSetting,
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			int.TryParse(apispSelectCrmsysSetting_Result.DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int.TryParse(languageId.ToString(), out var currLangId);
			if (currLangId <= 0)
			{
				currLangId = result;
			}
			List<ApispSelectLanguages_Result> list = Enumerable.ToList<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)cRMEntities.ApispSelectLanguages());
			string rsCollation = "fa-IR";
			ApispSelectLanguages_Result apispSelectLanguages_Result = Enumerable.FirstOrDefault<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result m) => m.LanguageID == currLangId));
			if (apispSelectLanguages_Result != null)
			{
				rsCollation = apispSelectLanguages_Result.LanguageCollation;
			}
			int? num = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.ApispCheckUserAllowed(username, password));
			int result2 = 0;
			int.TryParse(num.ToString(), out result2);
			if (result2 == 0)
			{
				return new ServiceResult<string>
				{
					Message = resourceManager.Get("ErrorUsernamePasswordIncorrect", rsCollation, resourceManager.TypeMsg) + "\r\n" + resourceManager.Get("ErrorTryAgain", rsCollation, resourceManager.TypeMsg),
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			ApispBusyTicketsInsertTankSMSAndSendIngMsg_Result apispBusyTicketsInsertTankSMSAndSendIngMsg_Result = Enumerable.FirstOrDefault<ApispBusyTicketsInsertTankSMSAndSendIngMsg_Result>((IEnumerable<ApispBusyTicketsInsertTankSMSAndSendIngMsg_Result>)cRMEntities.ApispBusyTicketsInsertTankSMSAndSendIngMsg(currentDateTime, userId, 0, short.Parse(now.ToString("yyyy", new PersianCulture())), short.Parse(DateTime.Now.ToString("MM", new PersianCulture())), now, registerDatePersian, CRMIdealApi.Classes.Configuration.AppType, currLangId, result));
			if (apispBusyTicketsInsertTankSMSAndSendIngMsg_Result != null && apispBusyTicketsInsertTankSMSAndSendIngMsg_Result.TotalSmsSendedToTankSeperateByUsers.GetValueOrDefault() != 0)
			{
				status = ServiceResultStatus.Success;
			}
		}
		catch (Exception ex)
		{
			string text = ((!string.IsNullOrEmpty(ex.Message)) ? ex.Message : "");
			if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
			{
				text = text + " - " + ex.InnerException.Message;
			}
			message = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text)) ? (" (" + text + ")") : "");
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(ex);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<string>
		{
			Message = message,
			Data = null,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<string> ApispUnhappyTicketsInsertTankSMSAndSendIngMsg(string username, string password, DateTime currentDateTime, int userId, int languageId)
	{
		CRMEntities cRMEntities = new CRMEntities();
		ResourceManager resourceManager = new ResourceManager();
		CommonClass commonClass = new CommonClass();
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		DateTime now = DateTime.Now;
		string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
		try
		{
			cRMEntities = new CRMEntities();
			ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
			if (apispSelectCrmsysSetting_Result == null)
			{
				return new ServiceResult<string>
				{
					Message = Messages.ErrorInReadingSysSetting,
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			int.TryParse(apispSelectCrmsysSetting_Result.DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int.TryParse(languageId.ToString(), out var currLangId);
			if (currLangId <= 0)
			{
				currLangId = result;
			}
			List<ApispSelectLanguages_Result> list = Enumerable.ToList<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)cRMEntities.ApispSelectLanguages());
			string rsCollation = "fa-IR";
			ApispSelectLanguages_Result apispSelectLanguages_Result = Enumerable.FirstOrDefault<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result m) => m.LanguageID == currLangId));
			if (apispSelectLanguages_Result != null)
			{
				rsCollation = apispSelectLanguages_Result.LanguageCollation;
			}
			int? num = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.ApispCheckUserAllowed(username, password));
			int result2 = 0;
			int.TryParse(num.ToString(), out result2);
			if (result2 == 0)
			{
				return new ServiceResult<string>
				{
					Message = resourceManager.Get("ErrorUsernamePasswordIncorrect", rsCollation, resourceManager.TypeMsg) + "\r\n" + resourceManager.Get("ErrorTryAgain", rsCollation, resourceManager.TypeMsg),
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			ApispUnhappyTicketsInsertTankSMSAndSendIngMsg_Result apispUnhappyTicketsInsertTankSMSAndSendIngMsg_Result = Enumerable.FirstOrDefault<ApispUnhappyTicketsInsertTankSMSAndSendIngMsg_Result>((IEnumerable<ApispUnhappyTicketsInsertTankSMSAndSendIngMsg_Result>)cRMEntities.ApispUnhappyTicketsInsertTankSMSAndSendIngMsg(currentDateTime, userId, 0, short.Parse(now.ToString("yyyy", new PersianCulture())), short.Parse(DateTime.Now.ToString("MM", new PersianCulture())), now, registerDatePersian, CRMIdealApi.Classes.Configuration.AppType, currLangId, result));
			if (apispUnhappyTicketsInsertTankSMSAndSendIngMsg_Result != null && apispUnhappyTicketsInsertTankSMSAndSendIngMsg_Result.TotalSmsSendedToTankSeperateByUsers.GetValueOrDefault() != 0)
			{
				status = ServiceResultStatus.Success;
			}
		}
		catch (Exception ex)
		{
			string text = ((!string.IsNullOrEmpty(ex.Message)) ? ex.Message : "");
			if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
			{
				text = text + " - " + ex.InnerException.Message;
			}
			message = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text)) ? (" (" + text + ")") : "");
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(ex);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<string>
		{
			Message = message,
			Data = null,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<string> AutoSendSMSBirthCongratulate(string username, string password, int userId, int languageId)
	{
		CRMEntities cRMEntities = new CRMEntities();
		ResourceManager resourceManager = new ResourceManager();
		CommonClass commonClass = new CommonClass();
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		DateTime now = DateTime.Now;
		string birthDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
		try
		{
			cRMEntities = new CRMEntities();
			ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
			if (apispSelectCrmsysSetting_Result == null)
			{
				return new ServiceResult<string>
				{
					Message = Messages.ErrorInReadingSysSetting,
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			int.TryParse(apispSelectCrmsysSetting_Result.DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int.TryParse(languageId.ToString(), out var currLangId);
			if (currLangId <= 0)
			{
				currLangId = result;
			}
			List<ApispSelectLanguages_Result> list = Enumerable.ToList<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)cRMEntities.ApispSelectLanguages());
			string rsCollation = "fa-IR";
			ApispSelectLanguages_Result apispSelectLanguages_Result = Enumerable.FirstOrDefault<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result m) => m.LanguageID == currLangId));
			if (apispSelectLanguages_Result != null)
			{
				rsCollation = apispSelectLanguages_Result.LanguageCollation;
			}
			int? num = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.ApispCheckUserAllowed(username, password));
			int result2 = 0;
			int.TryParse(num.ToString(), out result2);
			if (result2 == 0)
			{
				return new ServiceResult<string>
				{
					Message = resourceManager.Get("ErrorUsernamePasswordIncorrect", rsCollation, resourceManager.TypeMsg) + "\r\n" + resourceManager.Get("ErrorTryAgain", rsCollation, resourceManager.TypeMsg),
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			int num2 = cRMEntities.ApispAutoSendSMSBirthCongratulate(now, birthDatePersian, CRMIdealApi.Classes.Configuration.AppType, currLangId, result);
			status = ServiceResultStatus.Success;
		}
		catch (Exception ex)
		{
			string text = ((!string.IsNullOrEmpty(ex.Message)) ? ex.Message : "");
			if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
			{
				text = text + " - " + ex.InnerException.Message;
			}
			message = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text)) ? (" (" + text + ")") : "");
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(ex);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<string>
		{
			Message = message,
			Data = null,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<string> AutoSendSMSMarriageCongratulate(string username, string password, int userId, int languageId)
	{
		CRMEntities cRMEntities = new CRMEntities();
		ResourceManager resourceManager = new ResourceManager();
		CommonClass commonClass = new CommonClass();
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		DateTime now = DateTime.Now;
		string marriageDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
		try
		{
			cRMEntities = new CRMEntities();
			ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
			if (apispSelectCrmsysSetting_Result == null)
			{
				return new ServiceResult<string>
				{
					Message = Messages.ErrorInReadingSysSetting,
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			int.TryParse(apispSelectCrmsysSetting_Result.DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int.TryParse(languageId.ToString(), out var currLangId);
			if (currLangId <= 0)
			{
				currLangId = result;
			}
			List<ApispSelectLanguages_Result> list = Enumerable.ToList<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)cRMEntities.ApispSelectLanguages());
			string rsCollation = "fa-IR";
			ApispSelectLanguages_Result apispSelectLanguages_Result = Enumerable.FirstOrDefault<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result m) => m.LanguageID == currLangId));
			if (apispSelectLanguages_Result != null)
			{
				rsCollation = apispSelectLanguages_Result.LanguageCollation;
			}
			int? num = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.ApispCheckUserAllowed(username, password));
			int result2 = 0;
			int.TryParse(num.ToString(), out result2);
			if (result2 == 0)
			{
				return new ServiceResult<string>
				{
					Message = resourceManager.Get("ErrorUsernamePasswordIncorrect", rsCollation, resourceManager.TypeMsg) + "\r\n" + resourceManager.Get("ErrorTryAgain", rsCollation, resourceManager.TypeMsg),
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			int num2 = cRMEntities.ApispAutoSendSMSMarriageCongratulate(now, marriageDatePersian, CRMIdealApi.Classes.Configuration.AppType, currLangId, result);
			status = ServiceResultStatus.Success;
		}
		catch (Exception ex)
		{
			string text = ((!string.IsNullOrEmpty(ex.Message)) ? ex.Message : "");
			if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
			{
				text = text + " - " + ex.InnerException.Message;
			}
			message = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text)) ? (" (" + text + ")") : "");
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(ex);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<string>
		{
			Message = message,
			Data = null,
			Status = status
		};
	}

	[HttpPost]
	public async Task<ServiceResult<string>> ReceivedSms(string username, int userId, string password, int languageId)
	{
		CRMEntities db = new CRMEntities();
		ResourceManager resourceManager = new ResourceManager();
		new CommonClass();
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
		try
		{
			db = new CRMEntities();
			ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)db.ApispSelectCrmsysSetting());
			if (apispSelectCrmsysSetting_Result == null)
			{
				return new ServiceResult<string>
				{
					Message = Messages.ErrorInReadingSysSetting,
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			int.TryParse(apispSelectCrmsysSetting_Result.DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int.TryParse(languageId.ToString(), out var currLangId);
			if (currLangId <= 0)
			{
				currLangId = result;
			}
			List<ApispSelectLanguages_Result> list = Enumerable.ToList<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)db.ApispSelectLanguages());
			string rsCollation = "fa-IR";
			ApispSelectLanguages_Result apispSelectLanguages_Result = Enumerable.FirstOrDefault<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result m) => m.LanguageID == currLangId));
			if (apispSelectLanguages_Result != null)
			{
				rsCollation = apispSelectLanguages_Result.LanguageCollation;
			}
			int? num = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)db.ApispCheckUserAllowed(username, password));
			int result2 = 0;
			int.TryParse(num.ToString(), out result2);
			if (result2 == 0)
			{
				return new ServiceResult<string>
				{
					Message = resourceManager.Get("ErrorUsernamePasswordIncorrect", rsCollation, resourceManager.TypeMsg) + "\r\n" + resourceManager.Get("ErrorTryAgain", rsCollation, resourceManager.TypeMsg),
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			string urlWithoutEndSlash = Public.GetUrlWithoutEndSlash(Setting.GetSysSetting().ApiDomain);
			HttpClient httpClient = new HttpClient();
			HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, urlWithoutEndSlash + "/Api/AutomaticEvents/ReceivedSms?userId=" + userId);
			(await httpClient.SendAsync(request)).EnsureSuccessStatusCode();
			AutoSendSMSReceiveAnswer(username, password, userId, languageId);
			status = ServiceResultStatus.Success;
		}
		catch (Exception ex)
		{
			string text = ((!string.IsNullOrEmpty(ex.Message)) ? ex.Message : "");
			if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
			{
				text = text + " - " + ex.InnerException.Message;
			}
			message = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text)) ? (" (" + text + ")") : "");
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(ex);
		}
		finally
		{
			db?.Dispose();
		}
		return new ServiceResult<string>
		{
			Message = message,
			Data = null,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<string> AutoSendSMSReceiveAnswer(string username, string password, int userId, int languageId)
	{
		CRMEntities cRMEntities = new CRMEntities();
		ResourceManager resourceManager = new ResourceManager();
		CommonClass commonClass = new CommonClass();
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		DateTime now = DateTime.Now;
		string text = now.ToString("yyyyMMdd", new PersianCulture());
		try
		{
			cRMEntities = new CRMEntities();
			ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
			if (apispSelectCrmsysSetting_Result == null)
			{
				return new ServiceResult<string>
				{
					Message = Messages.ErrorInReadingSysSetting,
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			int.TryParse(apispSelectCrmsysSetting_Result.DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int.TryParse(languageId.ToString(), out var currLangId);
			if (currLangId <= 0)
			{
				currLangId = result;
			}
			List<ApispSelectLanguages_Result> list = Enumerable.ToList<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)cRMEntities.ApispSelectLanguages());
			string rsCollation = "fa-IR";
			ApispSelectLanguages_Result apispSelectLanguages_Result = Enumerable.FirstOrDefault<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result m) => m.LanguageID == currLangId));
			if (apispSelectLanguages_Result != null)
			{
				rsCollation = apispSelectLanguages_Result.LanguageCollation;
			}
			int? num = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.ApispCheckUserAllowed(username, password));
			int result2 = 0;
			int.TryParse(num.ToString(), out result2);
			if (result2 == 0)
			{
				return new ServiceResult<string>
				{
					Message = resourceManager.Get("ErrorUsernamePasswordIncorrect", rsCollation, resourceManager.TypeMsg) + "\r\n" + resourceManager.Get("ErrorTryAgain", rsCollation, resourceManager.TypeMsg),
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			int num2 = cRMEntities.ApispAutoSendSMSReceiveAnswer(now, CRMIdealApi.Classes.Configuration.AppType, currLangId, result);
			status = ServiceResultStatus.Success;
		}
		catch (Exception ex)
		{
			string text2 = ((!string.IsNullOrEmpty(ex.Message)) ? ex.Message : "");
			if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
			{
				text2 = text2 + " - " + ex.InnerException.Message;
			}
			message = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text2)) ? (" (" + text2 + ")") : "");
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(ex);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<string>
		{
			Message = message,
			Data = null,
			Status = status
		};
	}

	[HttpPost]
	public async Task<ServiceResult<string>> SendAutoSMSFromTankByWeb(string username, string password, int userId, int languageId)
	{
		CRMEntities db = new CRMEntities();
		ResourceManager resourceManager = new ResourceManager();
		new CommonClass();
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
		try
		{
			db = new CRMEntities();
			ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)db.ApispSelectCrmsysSetting());
			if (apispSelectCrmsysSetting_Result == null)
			{
				return new ServiceResult<string>
				{
					Message = Messages.ErrorInReadingSysSetting,
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			int.TryParse(apispSelectCrmsysSetting_Result.DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int.TryParse(languageId.ToString(), out var currLangId);
			if (currLangId <= 0)
			{
				currLangId = result;
			}
			List<ApispSelectLanguages_Result> list = Enumerable.ToList<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)db.ApispSelectLanguages());
			string rsCollation = "fa-IR";
			ApispSelectLanguages_Result apispSelectLanguages_Result = Enumerable.FirstOrDefault<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result m) => m.LanguageID == currLangId));
			if (apispSelectLanguages_Result != null)
			{
				rsCollation = apispSelectLanguages_Result.LanguageCollation;
			}
			int? num = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)db.ApispCheckUserAllowed(username, password));
			int result2 = 0;
			int.TryParse(num.ToString(), out result2);
			if (result2 == 0)
			{
				return new ServiceResult<string>
				{
					Message = resourceManager.Get("ErrorUsernamePasswordIncorrect", rsCollation, resourceManager.TypeMsg) + "\r\n" + resourceManager.Get("ErrorTryAgain", rsCollation, resourceManager.TypeMsg),
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			string urlWithoutEndSlash = Public.GetUrlWithoutEndSlash(Setting.GetSysSetting().ApiDomain);
			HttpClient httpClient = new HttpClient();
			HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, urlWithoutEndSlash + "/Api/AutomaticEvents/SendAutoSMSFromTankByWeb");
			(await httpClient.SendAsync(request)).EnsureSuccessStatusCode();
			status = ServiceResultStatus.Success;
		}
		catch (Exception ex)
		{
			string text = ((!string.IsNullOrEmpty(ex.Message)) ? ex.Message : "");
			if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
			{
				text = text + " - " + ex.InnerException.Message;
			}
			message = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text)) ? (" (" + text + ")") : "");
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(ex);
		}
		finally
		{
			db?.Dispose();
		}
		return new ServiceResult<string>
		{
			Message = message,
			Data = null,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<string> GetSMSWebServerCredit(string username, string password, int smsProviderId, int userId, int languageId)
	{
		CRMEntities cRMEntities = new CRMEntities();
		ResourceManager resourceManager = new ResourceManager();
		CommonClass commonClass = new CommonClass();
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		string text = DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
		decimal result = default(decimal);
		decimal result2 = default(decimal);
		try
		{
			cRMEntities = new CRMEntities();
			ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
			if (apispSelectCrmsysSetting_Result == null)
			{
				return new ServiceResult<string>
				{
					Message = Messages.ErrorInReadingSysSetting,
					Data = "0",
					Status = ServiceResultStatus.Error
				};
			}
			int.TryParse(apispSelectCrmsysSetting_Result.DefaultLanguageID.ToString(), out var result3);
			if (result3 <= 0)
			{
				result3 = 1065;
			}
			int.TryParse(languageId.ToString(), out var currLangId);
			if (currLangId <= 0)
			{
				currLangId = result3;
			}
			List<ApispSelectLanguages_Result> list = Enumerable.ToList<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)cRMEntities.ApispSelectLanguages());
			string rsCollation = "fa-IR";
			ApispSelectLanguages_Result apispSelectLanguages_Result = Enumerable.FirstOrDefault<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result m) => m.LanguageID == currLangId));
			if (apispSelectLanguages_Result != null)
			{
				rsCollation = apispSelectLanguages_Result.LanguageCollation;
			}
			int? num = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.ApispCheckUserAllowed(username, password));
			int result4 = 0;
			int.TryParse(num.ToString(), out result4);
			if (result4 == 0)
			{
				return new ServiceResult<string>
				{
					Message = resourceManager.Get("ErrorUsernamePasswordIncorrect", rsCollation, resourceManager.TypeMsg) + "\r\n" + resourceManager.Get("ErrorTryAgain", rsCollation, resourceManager.TypeMsg),
					Data = "",
					Status = ServiceResultStatus.Error
				};
			}
			string urlWithoutEndSlash = Public.GetUrlWithoutEndSlash(Setting.GetSysSetting().ApiDomain);
			HttpClient httpClient = new HttpClient();
			HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, urlWithoutEndSlash + "/Api/AutomaticEvents/GetSMSWebServerCredit?smsProviderId=" + smsProviderId);
			HttpResponseMessage result5 = httpClient.SendAsync(request).Result;
			if (result5 != null)
			{
				string text2 = result5.Content.ReadAsStringAsync().Result;
				if (!string.IsNullOrWhiteSpace(text2))
				{
					if (text2.StartsWith("\""))
					{
						text2 = text2.Substring(1, text2.Length - 1);
					}
					if (text2.EndsWith("\""))
					{
						text2 = text2.Substring(0, text2.Length - 1);
					}
					string[] array = text2.Split(new char[1] { '|' });
					if (array != null)
					{
						if (array.Length >= 3)
						{
							decimal.TryParse(array[0], out result);
							decimal.TryParse(array[1], out result2);
							if (string.IsNullOrWhiteSpace(array[2]))
							{
								status = ServiceResultStatus.Success;
							}
							else
							{
								status = ServiceResultStatus.Error;
								message = array[1];
							}
						}
						else
						{
							status = ServiceResultStatus.Error;
							message = resourceManager.Get("frmErrorMessage", rsCollation, resourceManager.TypeMsg);
						}
					}
					else
					{
						status = ServiceResultStatus.Error;
						message = resourceManager.Get("frmErrorMessage", rsCollation, resourceManager.TypeMsg);
					}
				}
				else
				{
					status = ServiceResultStatus.Error;
					message = resourceManager.Get("frmErrorMessage", rsCollation, resourceManager.TypeMsg);
				}
			}
			else
			{
				status = ServiceResultStatus.Error;
				message = resourceManager.Get("frmErrorMessage", rsCollation, resourceManager.TypeMsg);
			}
		}
		catch (Exception ex)
		{
			string text3 = ((!string.IsNullOrEmpty(ex.Message)) ? ex.Message : "");
			if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
			{
				text3 = text3 + " - " + ex.InnerException.Message;
			}
			message = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text3)) ? (" (" + text3 + ")") : "");
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(ex);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		string data = result + "|" + result2;
		return new ServiceResult<string>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	public async Task<ServiceResult<string>> ReceivedEmail(string username, string password, int userId, int languageId, DateTime? fromDateTime = null, DateTime? toDateTime = null)
	{
		CRMEntities db = new CRMEntities();
		ResourceManager resourceManager = new ResourceManager();
		new CommonClass();
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
		try
		{
			db = new CRMEntities();
			ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)db.ApispSelectCrmsysSetting());
			if (apispSelectCrmsysSetting_Result == null)
			{
				return new ServiceResult<string>
				{
					Message = Messages.ErrorInReadingSysSetting,
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			int.TryParse(apispSelectCrmsysSetting_Result.DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int.TryParse(languageId.ToString(), out var currLangId);
			if (currLangId <= 0)
			{
				currLangId = result;
			}
			List<ApispSelectLanguages_Result> list = Enumerable.ToList<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)db.ApispSelectLanguages());
			string rsCollation = "fa-IR";
			ApispSelectLanguages_Result apispSelectLanguages_Result = Enumerable.FirstOrDefault<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result m) => m.LanguageID == currLangId));
			if (apispSelectLanguages_Result != null)
			{
				rsCollation = apispSelectLanguages_Result.LanguageCollation;
			}
			int? num = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)db.ApispCheckUserAllowed(username, password));
			int result2 = 0;
			int.TryParse(num.ToString(), out result2);
			if (result2 == 0)
			{
				return new ServiceResult<string>
				{
					Message = resourceManager.Get("ErrorUsernamePasswordIncorrect", rsCollation, resourceManager.TypeMsg) + "\r\n" + resourceManager.Get("ErrorTryAgain", rsCollation, resourceManager.TypeMsg),
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			string urlWithoutEndSlash = Public.GetUrlWithoutEndSlash(Setting.GetSysSetting().ApiDomain);
			HttpClient httpClient = new HttpClient();
			HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, urlWithoutEndSlash + "/Api/AutomaticEvents/ReceivedEmail?fromDateTime=" + fromDateTime?.ToString() + "&toDateTime=" + toDateTime);
			(await httpClient.SendAsync(request)).EnsureSuccessStatusCode();
			status = ServiceResultStatus.Success;
		}
		catch (Exception ex)
		{
			string text = ((!string.IsNullOrEmpty(ex.Message)) ? ex.Message : "");
			if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
			{
				text = text + " - " + ex.InnerException.Message;
			}
			message = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text)) ? (" (" + text + ")") : "");
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(ex);
		}
		finally
		{
			db?.Dispose();
		}
		return new ServiceResult<string>
		{
			Message = message,
			Data = null,
			Status = status
		};
	}

	[HttpPost]
	public async Task<ServiceResult<string>> SendEmailsFromTank(string username, string password, int userId, int languageId)
	{
		CRMEntities db = new CRMEntities();
		ResourceManager resourceManager = new ResourceManager();
		new CommonClass();
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
		try
		{
			db = new CRMEntities();
			ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)db.ApispSelectCrmsysSetting());
			if (apispSelectCrmsysSetting_Result == null)
			{
				return new ServiceResult<string>
				{
					Message = Messages.ErrorInReadingSysSetting,
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			int.TryParse(apispSelectCrmsysSetting_Result.DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int.TryParse(languageId.ToString(), out var currLangId);
			if (currLangId <= 0)
			{
				currLangId = result;
			}
			List<ApispSelectLanguages_Result> list = Enumerable.ToList<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)db.ApispSelectLanguages());
			string rsCollation = "fa-IR";
			ApispSelectLanguages_Result apispSelectLanguages_Result = Enumerable.FirstOrDefault<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result m) => m.LanguageID == currLangId));
			if (apispSelectLanguages_Result != null)
			{
				rsCollation = apispSelectLanguages_Result.LanguageCollation;
			}
			int? num = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)db.ApispCheckUserAllowed(username, password));
			int result2 = 0;
			int.TryParse(num.ToString(), out result2);
			if (result2 == 0)
			{
				return new ServiceResult<string>
				{
					Message = resourceManager.Get("ErrorUsernamePasswordIncorrect", rsCollation, resourceManager.TypeMsg) + "\r\n" + resourceManager.Get("ErrorTryAgain", rsCollation, resourceManager.TypeMsg),
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			string urlWithoutEndSlash = Public.GetUrlWithoutEndSlash(Setting.GetSysSetting().ApiDomain);
			HttpClient httpClient = new HttpClient();
			HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, urlWithoutEndSlash + "/Api/AutomaticEvents/SendEmailsFromTank");
			(await httpClient.SendAsync(request)).EnsureSuccessStatusCode();
			status = ServiceResultStatus.Success;
		}
		catch (Exception ex)
		{
			string text = ((!string.IsNullOrEmpty(ex.Message)) ? ex.Message : "");
			if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
			{
				text = text + " - " + ex.InnerException.Message;
			}
			message = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text)) ? (" (" + text + ")") : "");
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(ex);
		}
		finally
		{
			db?.Dispose();
		}
		return new ServiceResult<string>
		{
			Message = message,
			Data = null,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<string> AutoCloseTicketAfterDay(string username, string password, int userId, int languageId)
	{
		CRMEntities cRMEntities = new CRMEntities();
		ResourceManager resourceManager = new ResourceManager();
		CommonClass commonClass = new CommonClass();
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		string text = DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
		try
		{
			cRMEntities = new CRMEntities();
			ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
			if (apispSelectCrmsysSetting_Result == null)
			{
				return new ServiceResult<string>
				{
					Message = Messages.ErrorInReadingSysSetting,
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			int.TryParse(apispSelectCrmsysSetting_Result.DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int.TryParse(languageId.ToString(), out var currLangId);
			if (currLangId <= 0)
			{
				currLangId = result;
			}
			List<ApispSelectLanguages_Result> list = Enumerable.ToList<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)cRMEntities.ApispSelectLanguages());
			string rsCollation = "fa-IR";
			ApispSelectLanguages_Result apispSelectLanguages_Result = Enumerable.FirstOrDefault<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result m) => m.LanguageID == currLangId));
			if (apispSelectLanguages_Result != null)
			{
				rsCollation = apispSelectLanguages_Result.LanguageCollation;
			}
			int? num = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.ApispCheckUserAllowed(username, password));
			int result2 = 0;
			int.TryParse(num.ToString(), out result2);
			if (result2 == 0)
			{
				return new ServiceResult<string>
				{
					Message = resourceManager.Get("ErrorUsernamePasswordIncorrect", rsCollation, resourceManager.TypeMsg) + "\r\n" + resourceManager.Get("ErrorTryAgain", rsCollation, resourceManager.TypeMsg),
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			int num2 = cRMEntities.ApispAutoCloseTicketAfterDay(CRMIdealApi.Classes.Configuration.AppType);
			status = ServiceResultStatus.Success;
		}
		catch (Exception ex)
		{
			string text2 = ((!string.IsNullOrEmpty(ex.Message)) ? ex.Message : "");
			if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
			{
				text2 = text2 + " - " + ex.InnerException.Message;
			}
			message = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text2)) ? (" (" + text2 + ")") : "");
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(ex);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<string>
		{
			Message = message,
			Data = null,
			Status = status
		};
	}

	[HttpPost]
	public async Task<ServiceResult<string>> SendSingleSms(SmsSendViewModel model)
	{
		CRMEntities db = new CRMEntities();
		ResourceManager RS = new ResourceManager();
		new CommonClass();
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				return new ServiceResult<string>
				{
					Message = Messages.ErrorAccessAPILimited,
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			db = new CRMEntities();
			ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)db.ApispSelectCrmsysSetting());
			if (apispSelectCrmsysSetting_Result == null)
			{
				return new ServiceResult<string>
				{
					Message = Messages.ErrorInReadingSysSetting,
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			int.TryParse(apispSelectCrmsysSetting_Result.DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int.TryParse(model.ApiLanguageId.ToString(), out var currLangId);
			if (currLangId <= 0)
			{
				currLangId = result;
			}
			List<ApispSelectLanguages_Result> list = Enumerable.ToList<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)db.ApispSelectLanguages());
			string _Collation = "fa-IR";
			ApispSelectLanguages_Result apispSelectLanguages_Result = Enumerable.FirstOrDefault<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result m) => m.LanguageID == currLangId));
			if (apispSelectLanguages_Result != null)
			{
				_Collation = apispSelectLanguages_Result.LanguageCollation;
			}
			if (!string.IsNullOrEmpty(model.ApiPassword))
			{
				model.ApiPassword = CodeDecode.DeCodding(model.ApiPassword);
			}
			if (!string.IsNullOrEmpty(model.ApiUsername))
			{
				model.ApiUsername = CodeDecode.DeCodding(model.ApiUsername);
			}
			int? num = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)db.ApispCheckUserAllowed(model.ApiUsername, model.ApiPassword));
			int result2 = 0;
			int.TryParse(num.ToString(), out result2);
			if (result2 == 0)
			{
				return new ServiceResult<string>
				{
					Message = RS.Get("ErrorUsernamePasswordIncorrect", _Collation, RS.TypeMsg) + "\r\n" + RS.Get("ErrorTryAgain", _Collation, RS.TypeMsg),
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			if (!string.IsNullOrWhiteSpace(model.SmsSendTopic) && model.SmsSendTopic.Length > 50)
			{
				return new ServiceResult<string>
				{
					Message = "SmsSendTopic: " + string.Format(RS.Get("LimitExceededNumber", _Collation, RS.TypeMsg), "50"),
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			if (string.IsNullOrWhiteSpace(model.SmsSendBody))
			{
				return new ServiceResult<string>
				{
					Message = string.Format(RS.Get("ErrorEmpty", _Collation, RS.TypeMsg), "SmsSendBody"),
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			if (model.SmsSendBody.Length > 2000)
			{
				return new ServiceResult<string>
				{
					Message = "SmsSendBody: " + string.Format(RS.Get("LimitExceededNumber", _Collation, RS.TypeMsg), "2000"),
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			if (string.IsNullOrWhiteSpace(model.SmsToNumber))
			{
				return new ServiceResult<string>
				{
					Message = string.Format(RS.Get("ErrorEmpty", _Collation, RS.TypeMsg), "SmsToNumber"),
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			string text = "09([0-9])\\d{8}";
			Match val = Regex.Match(model.SmsToNumber, text, (RegexOptions)1);
			if (!((Group)val).Success)
			{
				return new ServiceResult<string>
				{
					Message = "SmsToNumber: " + RS.Get("ErrorNotCorrent", _Collation, RS.TypeMsg),
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			string urlWithoutEndSlash = Public.GetUrlWithoutEndSlash(Setting.GetSysSetting().ApiDomain);
			HttpClient httpClient = new HttpClient();
			HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, urlWithoutEndSlash + "/Api/AutomaticEvents/SendSingleSms?model=" + JsonConvert.SerializeObject(model));
			HttpResponseMessage httpResponseMessage = await httpClient.SendAsync(request);
			httpResponseMessage.EnsureSuccessStatusCode();
			string text2 = await httpResponseMessage.Content.ReadAsStringAsync();
			if (!string.IsNullOrWhiteSpace(text2))
			{
				if (text2.StartsWith("\""))
				{
					text2 = text2.Substring(1, text2.Length - 1);
				}
				if (text2.EndsWith("\""))
				{
					text2 = text2.Substring(0, text2.Length - 1);
				}
				string[] array = text2.Split(new char[1] { '|' });
				if (array[0] == "1")
				{
					status = ServiceResultStatus.Success;
				}
				else if (array[0] == "-1")
				{
					status = ServiceResultStatus.Error;
					message = RS.Get("frmErrorMessage", _Collation, RS.TypeMsg);
				}
				else
				{
					message = text2;
				}
			}
		}
		catch (Exception ex)
		{
			string text3 = ((!string.IsNullOrEmpty(ex.Message)) ? ex.Message : "");
			if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
			{
				text3 = text3 + " - " + ex.InnerException.Message;
			}
			message = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text3)) ? (" (" + text3 + ")") : "");
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(ex);
		}
		finally
		{
			db?.Dispose();
		}
		return new ServiceResult<string>
		{
			Message = message,
			Data = null,
			Status = status
		};
	}

	[HttpPost]
	public async Task<ServiceResult<string>> SendGroupSms(SmsSendViewModel model)
	{
		CRMEntities db = new CRMEntities();
		ResourceManager RS = new ResourceManager();
		new CommonClass();
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				return new ServiceResult<string>
				{
					Message = Messages.ErrorAccessAPILimited,
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			db = new CRMEntities();
			ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)db.ApispSelectCrmsysSetting());
			if (apispSelectCrmsysSetting_Result == null)
			{
				return new ServiceResult<string>
				{
					Message = Messages.ErrorInReadingSysSetting,
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			int.TryParse(apispSelectCrmsysSetting_Result.DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int.TryParse(model.ApiLanguageId.ToString(), out var currLangId);
			if (currLangId <= 0)
			{
				currLangId = result;
			}
			List<ApispSelectLanguages_Result> list = Enumerable.ToList<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)db.ApispSelectLanguages());
			string _Collation = "fa-IR";
			ApispSelectLanguages_Result apispSelectLanguages_Result = Enumerable.FirstOrDefault<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result m) => m.LanguageID == currLangId));
			if (apispSelectLanguages_Result != null)
			{
				_Collation = apispSelectLanguages_Result.LanguageCollation;
			}
			if (!string.IsNullOrEmpty(model.ApiPassword))
			{
				model.ApiPassword = CodeDecode.DeCodding(model.ApiPassword);
			}
			if (!string.IsNullOrEmpty(model.ApiUsername))
			{
				model.ApiUsername = CodeDecode.DeCodding(model.ApiUsername);
			}
			int? num = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)db.ApispCheckUserAllowed(model.ApiUsername, model.ApiPassword));
			int result2 = 0;
			int.TryParse(num.ToString(), out result2);
			if (result2 == 0)
			{
				return new ServiceResult<string>
				{
					Message = RS.Get("ErrorUsernamePasswordIncorrect", _Collation, RS.TypeMsg) + "\r\n" + RS.Get("ErrorTryAgain", _Collation, RS.TypeMsg),
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			if (!string.IsNullOrWhiteSpace(model.SmsSendTopic) && model.SmsSendTopic.Length > 50)
			{
				return new ServiceResult<string>
				{
					Message = "SmsSendTopic: " + string.Format(RS.Get("LimitExceededNumber", _Collation, RS.TypeMsg), "50"),
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			if (string.IsNullOrWhiteSpace(model.SmsSendBody))
			{
				return new ServiceResult<string>
				{
					Message = string.Format(RS.Get("ErrorEmpty", _Collation, RS.TypeMsg), "SmsSendBody"),
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			if (model.SmsSendBody.Length > 2000)
			{
				return new ServiceResult<string>
				{
					Message = "SmsSendBody: " + string.Format(RS.Get("LimitExceededNumber", _Collation, RS.TypeMsg), "2000"),
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			if (string.IsNullOrWhiteSpace(model.Numbers))
			{
				return new ServiceResult<string>
				{
					Message = string.Format(RS.Get("ErrorEmpty", _Collation, RS.TypeMsg), "Numbers"),
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			string urlWithoutEndSlash = Public.GetUrlWithoutEndSlash(Setting.GetSysSetting().ApiDomain);
			HttpClient httpClient = new HttpClient();
			HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, urlWithoutEndSlash + "/Api/AutomaticEvents/SendGroupSms?userId=" + model.ApiUserId + "&model=" + JsonConvert.SerializeObject(model));
			HttpResponseMessage httpResponseMessage = await httpClient.SendAsync(request);
			httpResponseMessage.EnsureSuccessStatusCode();
			string text = await httpResponseMessage.Content.ReadAsStringAsync();
			if (!string.IsNullOrWhiteSpace(text))
			{
				if (text.StartsWith("\""))
				{
					text = text.Substring(1, text.Length - 1);
				}
				if (text.EndsWith("\""))
				{
					text = text.Substring(0, text.Length - 1);
				}
				string[] array = text.Split(new char[1] { '|' });
				if (array[0] == "1")
				{
					status = ServiceResultStatus.Success;
				}
				else if (array[0] == "-1")
				{
					status = ServiceResultStatus.Error;
					message = RS.Get("frmErrorMessage", _Collation, RS.TypeMsg);
				}
				else
				{
					message = text;
				}
			}
		}
		catch (Exception ex)
		{
			string text2 = ((!string.IsNullOrEmpty(ex.Message)) ? ex.Message : "");
			if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
			{
				text2 = text2 + " - " + ex.InnerException.Message;
			}
			message = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text2)) ? (" (" + text2 + ")") : "");
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(ex);
		}
		finally
		{
			db?.Dispose();
		}
		return new ServiceResult<string>
		{
			Message = message,
			Data = null,
			Status = status
		};
	}

	[HttpPost]
	public async Task<ServiceResult<string>> SendGroupSmsOneToOne(SmsSendViewModel model)
	{
		CRMEntities db = new CRMEntities();
		ResourceManager RS = new ResourceManager();
		new CommonClass();
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				return new ServiceResult<string>
				{
					Message = Messages.ErrorAccessAPILimited,
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			db = new CRMEntities();
			ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)db.ApispSelectCrmsysSetting());
			if (apispSelectCrmsysSetting_Result == null)
			{
				return new ServiceResult<string>
				{
					Message = Messages.ErrorInReadingSysSetting,
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			int.TryParse(apispSelectCrmsysSetting_Result.DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int.TryParse(model.ApiLanguageId.ToString(), out var currLangId);
			if (currLangId <= 0)
			{
				currLangId = result;
			}
			List<ApispSelectLanguages_Result> list = Enumerable.ToList<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)db.ApispSelectLanguages());
			string _Collation = "fa-IR";
			ApispSelectLanguages_Result apispSelectLanguages_Result = Enumerable.FirstOrDefault<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result m) => m.LanguageID == currLangId));
			if (apispSelectLanguages_Result != null)
			{
				_Collation = apispSelectLanguages_Result.LanguageCollation;
			}
			if (!string.IsNullOrEmpty(model.ApiPassword))
			{
				model.ApiPassword = CodeDecode.DeCodding(model.ApiPassword);
			}
			if (!string.IsNullOrEmpty(model.ApiUsername))
			{
				model.ApiUsername = CodeDecode.DeCodding(model.ApiUsername);
			}
			int? num = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)db.ApispCheckUserAllowed(model.ApiUsername, model.ApiPassword));
			int result2 = 0;
			int.TryParse(num.ToString(), out result2);
			if (result2 == 0)
			{
				return new ServiceResult<string>
				{
					Message = RS.Get("ErrorUsernamePasswordIncorrect", _Collation, RS.TypeMsg) + "\r\n" + RS.Get("ErrorTryAgain", _Collation, RS.TypeMsg),
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			if (!string.IsNullOrWhiteSpace(model.SmsSendTopic) && model.SmsSendTopic.Length > 50)
			{
				return new ServiceResult<string>
				{
					Message = "SmsSendTopic: " + string.Format(RS.Get("LimitExceededNumber", _Collation, RS.TypeMsg), "50"),
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			if (string.IsNullOrWhiteSpace(model.SmsSendBody))
			{
				return new ServiceResult<string>
				{
					Message = string.Format(RS.Get("ErrorEmpty", _Collation, RS.TypeMsg), "SmsSendBody"),
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			if (model.SmsSendBody.Length > 2000)
			{
				return new ServiceResult<string>
				{
					Message = "SmsSendBody: " + string.Format(RS.Get("LimitExceededNumber", _Collation, RS.TypeMsg), "2000"),
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			if (string.IsNullOrWhiteSpace(model.Numbers))
			{
				return new ServiceResult<string>
				{
					Message = string.Format(RS.Get("ErrorEmpty", _Collation, RS.TypeMsg), "Numbers"),
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			string urlWithoutEndSlash = Public.GetUrlWithoutEndSlash(Setting.GetSysSetting().ApiDomain);
			HttpClient httpClient = new HttpClient();
			HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, urlWithoutEndSlash + "/Api/AutomaticEvents/SendGroupSmsOneToOne?userId=" + model.ApiUserId + "&model=" + JsonConvert.SerializeObject(model));
			HttpResponseMessage httpResponseMessage = await httpClient.SendAsync(request);
			httpResponseMessage.EnsureSuccessStatusCode();
			string text = await httpResponseMessage.Content.ReadAsStringAsync();
			if (!string.IsNullOrWhiteSpace(text))
			{
				if (text.StartsWith("\""))
				{
					text = text.Substring(1, text.Length - 1);
				}
				if (text.EndsWith("\""))
				{
					text = text.Substring(0, text.Length - 1);
				}
				string[] array = text.Split(new char[1] { '|' });
				if (array[0] == "1")
				{
					status = ServiceResultStatus.Success;
				}
				else if (array[0] == "-1")
				{
					status = ServiceResultStatus.Error;
					message = RS.Get("frmErrorMessage", _Collation, RS.TypeMsg);
				}
				else
				{
					message = text;
				}
			}
		}
		catch (Exception ex)
		{
			string text2 = ((!string.IsNullOrEmpty(ex.Message)) ? ex.Message : "");
			if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
			{
				text2 = text2 + " - " + ex.InnerException.Message;
			}
			message = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text2)) ? (" (" + text2 + ")") : "");
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(ex);
		}
		finally
		{
			db?.Dispose();
		}
		return new ServiceResult<string>
		{
			Message = message,
			Data = null,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<string> RunDeadlineCnvsEventPolicy(string username, string password, DateTime currentDateTime, int userId, int languageId)
	{
		CRMEntities cRMEntities = new CRMEntities();
		ResourceManager resourceManager = new ResourceManager();
		CommonClass commonClass = new CommonClass();
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		DateTime now = DateTime.Now;
		string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
		try
		{
			cRMEntities = new CRMEntities();
			ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
			if (apispSelectCrmsysSetting_Result == null)
			{
				return new ServiceResult<string>
				{
					Message = Messages.ErrorInReadingSysSetting,
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			int.TryParse(apispSelectCrmsysSetting_Result.DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int.TryParse(languageId.ToString(), out var currLangId);
			if (currLangId <= 0)
			{
				currLangId = result;
			}
			List<ApispSelectLanguages_Result> list = Enumerable.ToList<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)cRMEntities.ApispSelectLanguages());
			string rsCollation = "fa-IR";
			ApispSelectLanguages_Result apispSelectLanguages_Result = Enumerable.FirstOrDefault<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result m) => m.LanguageID == currLangId));
			if (apispSelectLanguages_Result != null)
			{
				rsCollation = apispSelectLanguages_Result.LanguageCollation;
			}
			int? num = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.ApispCheckUserAllowed(username, password));
			int result2 = 0;
			int.TryParse(num.ToString(), out result2);
			if (result2 == 0)
			{
				return new ServiceResult<string>
				{
					Message = resourceManager.Get("ErrorUsernamePasswordIncorrect", rsCollation, resourceManager.TypeMsg) + "\r\n" + resourceManager.Get("ErrorTryAgain", rsCollation, resourceManager.TypeMsg),
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			string dubClickDisplayCmpInfo = Messages.DubClickDisplayCmpInfo;
			string text = "";
			string surveyMainExtrenalLink = "";
			string surveyMainExtrenalLinkLogin = "";
			string leftPart = base.Request.RequestUri.GetLeftPart(UriPartial.Authority);
			string leftPart2 = base.Request.RequestUri.GetLeftPart(UriPartial.Scheme);
			string text2 = leftPart;
			if (text2.EndsWith("/"))
			{
				text2 = text2.TrimEnd(new char[1] { '/' });
			}
			text2 += "/Survey/Home/SurveyAnswerValues";
			text = text2;
			ApispRunDeadlineCnvsEventPolicy_Result apispRunDeadlineCnvsEventPolicy_Result = Enumerable.FirstOrDefault<ApispRunDeadlineCnvsEventPolicy_Result>((IEnumerable<ApispRunDeadlineCnvsEventPolicy_Result>)cRMEntities.ApispRunDeadlineCnvsEventPolicy(text, surveyMainExtrenalLink, surveyMainExtrenalLinkLogin, dubClickDisplayCmpInfo, currentDateTime, userId, 0, short.Parse(now.ToString("yyyy", new PersianCulture())), short.Parse(DateTime.Now.ToString("MM", new PersianCulture())), now, registerDatePersian, CRMIdealApi.Classes.Configuration.AppType, currLangId, result));
			status = ServiceResultStatus.Success;
		}
		catch (Exception ex)
		{
			string text3 = ((!string.IsNullOrEmpty(ex.Message)) ? ex.Message : "");
			if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
			{
				text3 = text3 + " - " + ex.InnerException.Message;
			}
			message = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text3)) ? (" (" + text3 + ")") : "");
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(ex);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<string>
		{
			Message = message,
			Data = null,
			Status = status
		};
	}
}
