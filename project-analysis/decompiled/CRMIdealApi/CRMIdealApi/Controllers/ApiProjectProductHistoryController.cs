using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using CRM.General.Security;
using CRM.General.Utilities;
using CRMIdealApi.ApiModels;
using CRMIdealApi.Classes;
using CRMIdealApi.Classes.Helper;
using CRMIdealApi.DataType;
using CRMIdealApi.Resources;
using Elmah;
using GSD.Globalization;

namespace CRMIdealApi.Controllers;

public class ApiProjectProductHistoryController : ApiController
{
	[HttpPost]
	public ServiceResult<int> Insert(InsertProjectProductHistoryViewModel model)
	{
		CRMEntities cRMEntities = null;
		if (model.ApiCompanyId <= 0)
		{
			model.ApiCompanyId = null;
		}
		if (model.ApiCmpNumber <= 0)
		{
			model.ApiCmpNumber = null;
		}
		if (model.ApiProjectId <= 0)
		{
			model.ApiProjectId = null;
		}
		if (model.ApiProductId <= 0)
		{
			model.ApiProductId = null;
		}
		if (model.ApiPrjPrdHOrderId <= 0)
		{
			model.ApiPrjPrdHOrderId = null;
		}
		if (model.ApiPrjPrdHOrderItemId <= 0)
		{
			model.ApiPrjPrdHOrderItemId = null;
		}
		if (model.ApiPrjPrdHDoneStatusUserId <= 0)
		{
			model.ApiPrjPrdHDoneStatusUserId = null;
		}
		if (model.ApiPrjPrdHCount < 0)
		{
			model.ApiPrjPrdHCount = null;
		}
		if (model.ApiPrjPrdHDurationMin < 0)
		{
			model.ApiPrjPrdHDurationMin = null;
		}
		int data = 0;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				return new ServiceResult<int>
				{
					Message = Messages.ErrorAccessAPILimited,
					Data = 0,
					Status = ServiceResultStatus.Error
				};
			}
			cRMEntities = new CRMEntities();
			CommonClass commonClass = new CommonClass();
			ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
			if (apispSelectCrmsysSetting_Result == null)
			{
				return new ServiceResult<int>
				{
					Message = Messages.ErrorInReadingSysSetting,
					Data = 0,
					Status = ServiceResultStatus.Error
				};
			}
			int.TryParse(apispSelectCrmsysSetting_Result.DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int.TryParse(model.LanguageId.ToString(), out var currLangId);
			if (currLangId <= 0)
			{
				currLangId = result;
			}
			List<ApispSelectLanguages_Result> list = Enumerable.ToList<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)cRMEntities.ApispSelectLanguages());
			string culture = "fa-IR";
			ApispSelectLanguages_Result apispSelectLanguages_Result = Enumerable.FirstOrDefault<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result m) => m.LanguageID == currLangId));
			if (apispSelectLanguages_Result != null)
			{
				culture = apispSelectLanguages_Result.LanguageCollation;
			}
			if (!VersionBuyer.ProjectProductHistory)
			{
				return new ServiceResult<int>
				{
					Message = string.Format(Messages.ResourceManager.GetString("ErrorMsgBuyModule", new CultureInfo(currLangId)), Labels.ResourceManager.GetString("lblProjectProductHistory", new CultureInfo(currLangId))),
					Data = 0,
					Status = ServiceResultStatus.Error
				};
			}
			string prjPrdHSetDatePersian = null;
			string prjPrdHDoneStatusDatePersian = null;
			try
			{
				if (model.ApiPrjPrdHSetDate.HasValue)
				{
					prjPrdHSetDatePersian = (model.ApiPrjPrdHSetDate ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
				}
			}
			catch (Exception)
			{
				ServiceResult<int> serviceResult = new ServiceResult<int>();
				serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PrjPrdHSetDate", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
				serviceResult.Data = 0;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			try
			{
				if (model.ApiPrjPrdHDoneStatusDate.HasValue)
				{
					prjPrdHDoneStatusDatePersian = (model.ApiPrjPrdHDoneStatusDate ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
				}
			}
			catch (Exception)
			{
				ServiceResult<int> serviceResult = new ServiceResult<int>();
				serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PrjPrdHDoneStatusDate", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
				serviceResult.Data = 0;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			if (!string.IsNullOrEmpty(model.Password))
			{
				model.Password = CodeDecode.DeCodding(model.Password);
			}
			if (!string.IsNullOrEmpty(model.UserName))
			{
				model.UserName = CodeDecode.DeCodding(model.UserName);
			}
			int? num = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.ApispCheckUserAllowed(model.UserName, model.Password));
			int result2 = 0;
			int.TryParse(num.ToString(), out result2);
			if (result2 == 0)
			{
				ServiceResult<int> serviceResult = new ServiceResult<int>();
				serviceResult.Message = MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = 0;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			int userId = model.UserId;
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string dubClickDisplayCmpInfo = Messages.DubClickDisplayCmpInfo;
			string appType = CRMIdealApi.Classes.Configuration.AppType;
			short num2 = short.Parse(now.ToString("yyyy", new PersianCulture()));
			string text = commonClass.ConvertNameToDayNum(now.DayOfWeek.ToString());
			string text2 = now.ToString("HH:mm:ss");
			string person = Labels.Person;
			ObjectParameter objectParameter = new ObjectParameter("InsertedPrjPrdHistoryId", 0);
			ObjectParameter objectParameter2 = new ObjectParameter("PrjPrdHRemainCount", 0.0);
			ObjectParameter objectParameter3 = new ObjectParameter("PrjPrdHRemainDurationMin", 0.0);
			ObjectParameter objectParameter4 = new ObjectParameter("ErrorMessage", "");
			int? num3 = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.ApispInsertProjectProductHistory(model.ApiCompanyId, model.ApiCmpNumber, model.ApiCmpCode, model.ApiProjectId, model.ApiPrjTitle, model.ApiProductId, model.ApiPrdCode, model.ApiPrjPrdHOrderId, model.ApiPrjPrdHOrderItemId, model.ApiPrjPrdHSetDate, prjPrdHSetDatePersian, model.ApiPrjPrdHDoneStatus, model.ApiPrjPrdHDoneStatusUserId, model.ApiPrjPrdHDoneStatusDate, prjPrdHDoneStatusDatePersian, model.ApiPrjPrdHDesc, model.ApiPrjPrdHScore, model.ApiPrjPrdHCount, model.ApiPrjPrdHDurationMin, model.PrjPrdHNoCalc, userId, value2, value, registerDatePersian, appType, objectParameter, objectParameter2, objectParameter3, objectParameter4));
			string resourceString = MyResource.GetResourceString("ErrorDoneOperationTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
			string resourceString2 = MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
			int result3 = 0;
			int.TryParse(num3.ToString(), out result3);
			if (result3 <= 0)
			{
				return new ServiceResult<int>
				{
					Message = resourceString.Replace("<br>", "\r\n"),
					Data = 0,
					Status = ServiceResultStatus.Error
				};
			}
			if (objectParameter4.Value != null && objectParameter4.Value.ToString() != "")
			{
				string text3 = "";
				string text4 = "";
				string text5 = objectParameter4.Value.ToString();
				if (text5.IndexOf("IsUser=0", StringComparison.Ordinal) >= 0)
				{
					text3 = text3 + MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "<br>";
					resourceString2 = "<br>" + MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + resourceString2;
					return new ServiceResult<int>
					{
						Message = resourceString2.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text5.IndexOf("No CmpId|", StringComparison.Ordinal) >= 0)
				{
					text4 = text4 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("Company", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text4.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text5.IndexOf("No PrjId|", StringComparison.Ordinal) >= 0)
				{
					text4 = text4 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("Project", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text4.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text5.IndexOf("No PrdId|", StringComparison.Ordinal) >= 0)
				{
					text4 = text4 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("Product", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text4.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text5.IndexOf("No PrdValidity|", StringComparison.Ordinal) >= 0)
				{
					text4 = text4 + MyResource.GetResourceString("ErrorNoPrdValidityCounting", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text4.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text5.IndexOf("No PrdValidityCountingNumNeedOrder|", StringComparison.Ordinal) >= 0)
				{
					text4 = text4 + MyResource.GetResourceString("ErrorNoPrdValidityCountingNumNeedOrder", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text4.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text5.IndexOf("No PrdValidityCountingMinNeedOrder|", StringComparison.Ordinal) >= 0)
				{
					text4 = text4 + MyResource.GetResourceString("ErrorNoPrdValidityCountingMinNeedOrder", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text4.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text5.IndexOf("No PrjPrdHOrderId|", StringComparison.Ordinal) >= 0)
				{
					text4 = text4 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("Order", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text4.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text5.IndexOf("No PrjPrdHOrderItemId|", StringComparison.Ordinal) >= 0)
				{
					text4 = text4 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("OrderItem", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text4.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text5.IndexOf("No PrjPrdHDoneStatusUserId|", StringComparison.Ordinal) >= 0)
				{
					text4 = text4 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PrjPrdHDoneStatusUser", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text4.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text5.IndexOf("No PrjPrdHRemainCount|", StringComparison.Ordinal) >= 0)
				{
					double result4 = 0.0;
					if (objectParameter2 != null && objectParameter2.Value != null)
					{
						double.TryParse(objectParameter2.Value.ToString(), out result4);
					}
					text4 = text4 + string.Format(MyResource.GetResourceString("ErrorNoPrjPrdHRemainCount", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), result4.ToString()) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text4.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text5.IndexOf("No PrjPrdHRemainDurationMin|", StringComparison.Ordinal) >= 0)
				{
					double result5 = 0.0;
					if (objectParameter3 != null && objectParameter3.Value != null)
					{
						double.TryParse(objectParameter3.Value.ToString(), out result5);
					}
					text4 = text4 + string.Format(MyResource.GetResourceString("ErrorNoPrjPrdHRemainDurationMin", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), result5.ToString()) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text4.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
			}
			else
			{
				if (objectParameter == null || objectParameter.Value.ToString() == "0")
				{
					ServiceResult<int> serviceResult = new ServiceResult<int>();
					serviceResult.Message = (MyResource.GetResourceString("ErrorDoneOperation", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "<br>" + resourceString).Replace("<br>", "\r\n");
					serviceResult.Data = 0;
					serviceResult.Status = ServiceResultStatus.Fail;
					return serviceResult;
				}
				FullRegisterResultViewModel fullRegisterResultViewModel = new FullRegisterResultViewModel();
				data = ((objectParameter.Value != null) ? int.Parse(objectParameter.Value.ToString() ?? "0") : 0);
				message = MyResource.GetResourceString("SuccessDoneRegister", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				status = ServiceResultStatus.Success;
			}
		}
		catch (Exception ex3)
		{
			string text6 = ((!string.IsNullOrEmpty(ex3.Message)) ? ex3.Message : "");
			if (ex3.InnerException != null && !string.IsNullOrEmpty(ex3.InnerException.Message))
			{
				text6 = text6 + " - " + ex3.InnerException.Message;
			}
			message = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text6)) ? (" (" + text6 + ")") : "");
			data = 0;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(ex3);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<int>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<int> Update(UpdateProjectProductHistoryViewModel model)
	{
		CRMEntities cRMEntities = null;
		int data = 0;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				return new ServiceResult<int>
				{
					Message = Messages.ErrorAccessAPILimited,
					Data = 0,
					Status = ServiceResultStatus.Error
				};
			}
			cRMEntities = new CRMEntities();
			CommonClass commonClass = new CommonClass();
			ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
			if (apispSelectCrmsysSetting_Result == null)
			{
				return new ServiceResult<int>
				{
					Message = Messages.ErrorInReadingSysSetting,
					Data = 0,
					Status = ServiceResultStatus.Error
				};
			}
			int.TryParse(apispSelectCrmsysSetting_Result.DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int.TryParse(model.LanguageId.ToString(), out var currLangId);
			if (currLangId <= 0)
			{
				currLangId = result;
			}
			List<ApispSelectLanguages_Result> list = Enumerable.ToList<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)cRMEntities.ApispSelectLanguages());
			string culture = "fa-IR";
			ApispSelectLanguages_Result apispSelectLanguages_Result = Enumerable.FirstOrDefault<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result m) => m.LanguageID == currLangId));
			if (apispSelectLanguages_Result != null)
			{
				culture = apispSelectLanguages_Result.LanguageCollation;
			}
			if (model.ApiPrjPrdHDoneStatusUserId <= 0)
			{
				model.ApiPrjPrdHDoneStatusUserId = null;
			}
			if (model.ApiPrjPrdHCount < 0)
			{
				model.ApiPrjPrdHCount = null;
			}
			if (model.ApiPrjPrdHDurationMin < 0)
			{
				model.ApiPrjPrdHDurationMin = null;
			}
			string prjPrdHSetDatePersian = null;
			string prjPrdHDoneStatusDatePersian = null;
			try
			{
				if (model.ApiPrjPrdHSetDate.HasValue)
				{
					prjPrdHSetDatePersian = (model.ApiPrjPrdHSetDate ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
				}
			}
			catch (Exception)
			{
				ServiceResult<int> serviceResult = new ServiceResult<int>();
				serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PrjPrdHSetDate", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
				serviceResult.Data = 0;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			try
			{
				if (model.ApiPrjPrdHDoneStatusDate.HasValue)
				{
					prjPrdHDoneStatusDatePersian = (model.ApiPrjPrdHDoneStatusDate ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
				}
			}
			catch (Exception)
			{
				ServiceResult<int> serviceResult = new ServiceResult<int>();
				serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PrjPrdHDoneStatusDate", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
				serviceResult.Data = 0;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			if (!string.IsNullOrEmpty(model.Password))
			{
				model.Password = CodeDecode.DeCodding(model.Password);
			}
			if (!string.IsNullOrEmpty(model.UserName))
			{
				model.UserName = CodeDecode.DeCodding(model.UserName);
			}
			int? num = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.ApispCheckUserAllowed(model.UserName, model.Password));
			int result2 = 0;
			int.TryParse(num.ToString(), out result2);
			if (result2 == 0)
			{
				ServiceResult<int> serviceResult = new ServiceResult<int>();
				serviceResult.Message = MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = 0;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			if (model.ApiProjectProductHistoryId <= 0)
			{
				ServiceResult<int> serviceResult = new ServiceResult<int>();
				serviceResult.Message = MyResource.GetResourceString("ErrorNotFound", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = 0;
				serviceResult.Status = ServiceResultStatus.Fail;
				return serviceResult;
			}
			int userId = model.UserId;
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string dubClickDisplayCmpInfo = Messages.DubClickDisplayCmpInfo;
			string appType = CRMIdealApi.Classes.Configuration.AppType;
			short num2 = short.Parse(now.ToString("yyyy", new PersianCulture()));
			string text = commonClass.ConvertNameToDayNum(now.DayOfWeek.ToString());
			string text2 = now.ToString("HH:mm:ss");
			string person = Labels.Person;
			ObjectParameter objectParameter = new ObjectParameter("PrjPrdHRemainCount", 0.0);
			ObjectParameter objectParameter2 = new ObjectParameter("PrjPrdHRemainDurationMin", 0.0);
			ObjectParameter objectParameter3 = new ObjectParameter("ErrorMessage", "");
			int num3 = cRMEntities.ApispUpdateProjectProductHistory(model.ApiProjectProductHistoryId, model.ApiPrjPrdHSetDate, prjPrdHSetDatePersian, model.ApiPrjPrdHDoneStatus, model.ApiPrjPrdHDoneStatusUserId, model.ApiPrjPrdHDoneStatusDate, prjPrdHDoneStatusDatePersian, model.ApiPrjPrdHDesc, model.ApiPrjPrdHScore, model.ApiPrjPrdHCount, model.ApiPrjPrdHDurationMin, model.PrjPrdHNoCalc, userId, value, registerDatePersian, value2, appType, currLangId, result, objectParameter, objectParameter2, objectParameter3);
			string resourceString = MyResource.GetResourceString("ErrorDoneOperationTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
			string resourceString2 = MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
			int result3 = 0;
			int.TryParse(num3.ToString(), out result3);
			if (result3 < 0 && objectParameter3.Value == null)
			{
				return new ServiceResult<int>
				{
					Message = resourceString.Replace("<br>", "\r\n"),
					Data = 0,
					Status = ServiceResultStatus.Error
				};
			}
			if (objectParameter3.Value != null && objectParameter3.Value.ToString() != "")
			{
				string text3 = "";
				string text4 = "";
				string text5 = objectParameter3.Value.ToString();
				if (text5.IndexOf("IsUser=0", StringComparison.Ordinal) >= 0)
				{
					text3 = text3 + MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "<br>";
					resourceString2 = "<br>" + MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + resourceString2;
					return new ServiceResult<int>
					{
						Message = resourceString2.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text5.IndexOf("No CmpId|", StringComparison.Ordinal) >= 0)
				{
					text4 = text4 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("Company", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text4.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text5.IndexOf("No PrjId|", StringComparison.Ordinal) >= 0)
				{
					text4 = text4 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("Project", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text4.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text5.IndexOf("No PrdId|", StringComparison.Ordinal) >= 0)
				{
					text4 = text4 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("Product", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text4.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text5.IndexOf("No PrdValidity|", StringComparison.Ordinal) >= 0)
				{
					text4 = text4 + MyResource.GetResourceString("ErrorNoPrdValidityCounting", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text4.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text5.IndexOf("No PrdValidityCountingNumNeedOrder|", StringComparison.Ordinal) >= 0)
				{
					text4 = text4 + MyResource.GetResourceString("ErrorNoPrdValidityCountingNumNeedOrder", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text4.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text5.IndexOf("No PrdValidityCountingMinNeedOrder|", StringComparison.Ordinal) >= 0)
				{
					text4 = text4 + MyResource.GetResourceString("ErrorNoPrdValidityCountingMinNeedOrder", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text4.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text5.IndexOf("No PrjPrdHOrderId|", StringComparison.Ordinal) >= 0)
				{
					text4 = text4 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("Order", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text4.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text5.IndexOf("No PrjPrdHOrderItemId|", StringComparison.Ordinal) >= 0)
				{
					text4 = text4 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("OrderItem", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text4.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text5.IndexOf("No PrjPrdHDoneStatusUserId|", StringComparison.Ordinal) >= 0)
				{
					text4 = text4 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PrjPrdHDoneStatusUser", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text4.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text5.IndexOf("No PrjPrdHRemainCount|", StringComparison.Ordinal) >= 0)
				{
					double result4 = 0.0;
					if (objectParameter != null && objectParameter.Value != null)
					{
						double.TryParse(objectParameter.Value.ToString(), out result4);
					}
					text4 = text4 + string.Format(MyResource.GetResourceString("ErrorNoPrjPrdHRemainCount", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), result4.ToString()) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text4.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text5.IndexOf("No PrjPrdHRemainDurationMin|", StringComparison.Ordinal) >= 0)
				{
					double result5 = 0.0;
					if (objectParameter2 != null && objectParameter2.Value != null)
					{
						double.TryParse(objectParameter2.Value.ToString(), out result5);
					}
					text4 = text4 + string.Format(MyResource.GetResourceString("ErrorNoPrjPrdHRemainDurationMin", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), result5.ToString()) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text4.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
			}
			else
			{
				FullRegisterResultViewModel fullRegisterResultViewModel = new FullRegisterResultViewModel();
				data = 1;
				message = MyResource.GetResourceString("SuccessDoneRegister", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				status = ServiceResultStatus.Success;
			}
		}
		catch (Exception ex3)
		{
			string text6 = ((!string.IsNullOrEmpty(ex3.Message)) ? ex3.Message : "");
			if (ex3.InnerException != null && !string.IsNullOrEmpty(ex3.InnerException.Message))
			{
				text6 = text6 + " - " + ex3.InnerException.Message;
			}
			message = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text6)) ? (" (" + text6 + ")") : "");
			data = 0;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(ex3);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<int>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<List<ApispSelectProjectProductHistory_Result>> Select(SelectProjectProductHistoryViewModel model)
	{
		CRMEntities cRMEntities = null;
		List<ApispSelectProjectProductHistory_Result> data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				return new ServiceResult<List<ApispSelectProjectProductHistory_Result>>
				{
					Message = Messages.ErrorAccessAPILimited,
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			cRMEntities = new CRMEntities();
			CommonClass commonClass = new CommonClass();
			ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
			if (apispSelectCrmsysSetting_Result == null)
			{
				return new ServiceResult<List<ApispSelectProjectProductHistory_Result>>
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
			int.TryParse(model.LanguageId.ToString(), out var currLangId);
			if (currLangId <= 0)
			{
				currLangId = result;
			}
			List<ApispSelectLanguages_Result> list = Enumerable.ToList<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)cRMEntities.ApispSelectLanguages());
			string culture = "fa-IR";
			ApispSelectLanguages_Result apispSelectLanguages_Result = Enumerable.FirstOrDefault<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result m) => m.LanguageID == currLangId));
			if (apispSelectLanguages_Result != null)
			{
				culture = apispSelectLanguages_Result.LanguageCollation;
			}
			if (!string.IsNullOrEmpty(model.Password))
			{
				model.Password = CodeDecode.DeCodding(model.Password);
			}
			if (!string.IsNullOrEmpty(model.UserName))
			{
				model.UserName = CodeDecode.DeCodding(model.UserName);
			}
			int? num = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.ApispCheckUserAllowed(model.UserName, model.Password));
			int result2 = 0;
			int.TryParse(num.ToString(), out result2);
			if (result2 == 0)
			{
				ServiceResult<List<ApispSelectProjectProductHistory_Result>> serviceResult = new ServiceResult<List<ApispSelectProjectProductHistory_Result>>();
				serviceResult.Message = MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			string txtIsDone = Labels.TxtIsDone;
			string txtIsNotDone = Labels.TxtIsNotDone;
			List<ApispSelectProjectProductHistory_Result> list2 = Enumerable.ToList<ApispSelectProjectProductHistory_Result>((IEnumerable<ApispSelectProjectProductHistory_Result>)cRMEntities.ApispSelectProjectProductHistory(model.ApiCompanyId, model.ApiProjectId, txtIsDone, txtIsNotDone, currLangId, result));
			if (list2 != null)
			{
				message = MyResource.GetResourceString("SuccessDoneRegister", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				status = ServiceResultStatus.Success;
			}
			else
			{
				message = MyResource.GetResourceString("ErrorNotFound", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				status = ServiceResultStatus.Fail;
			}
			data = list2;
		}
		catch (Exception ex)
		{
			string text = ((!string.IsNullOrEmpty(ex.Message)) ? ex.Message : "");
			if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
			{
				text = text + " - " + ex.InnerException.Message;
			}
			message = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text)) ? (" (" + text + ")") : "");
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(ex);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<List<ApispSelectProjectProductHistory_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<bool> Delete(DeleteProjectProductHistoryViewModel model)
	{
		CRMEntities cRMEntities = null;
		bool data = false;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				return new ServiceResult<bool>
				{
					Message = Messages.ErrorAccessAPILimited,
					Data = false,
					Status = ServiceResultStatus.Error
				};
			}
			cRMEntities = new CRMEntities();
			CommonClass commonClass = new CommonClass();
			ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
			if (apispSelectCrmsysSetting_Result == null)
			{
				return new ServiceResult<bool>
				{
					Message = Messages.ErrorInReadingSysSetting,
					Data = false,
					Status = ServiceResultStatus.Error
				};
			}
			int.TryParse(apispSelectCrmsysSetting_Result.DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int.TryParse(model.LanguageId.ToString(), out var currLangId);
			if (currLangId <= 0)
			{
				currLangId = result;
			}
			List<ApispSelectLanguages_Result> list = Enumerable.ToList<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)cRMEntities.ApispSelectLanguages());
			string culture = "fa-IR";
			ApispSelectLanguages_Result apispSelectLanguages_Result = Enumerable.FirstOrDefault<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result m) => m.LanguageID == currLangId));
			if (apispSelectLanguages_Result != null)
			{
				culture = apispSelectLanguages_Result.LanguageCollation;
			}
			if (!string.IsNullOrEmpty(model.Password))
			{
				model.Password = CodeDecode.DeCodding(model.Password);
			}
			if (!string.IsNullOrEmpty(model.UserName))
			{
				model.UserName = CodeDecode.DeCodding(model.UserName);
			}
			int? num = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.ApispCheckUserAllowed(model.UserName, model.Password));
			int result2 = 0;
			int.TryParse(num.ToString(), out result2);
			if (result2 == 0)
			{
				ServiceResult<bool> serviceResult = new ServiceResult<bool>();
				serviceResult.Message = MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = false;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			if (model.ApiProjectProductHistoryId > 0)
			{
				mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)cRMEntities.ApispDeleteProjectProductHistory(model.ApiProjectProductHistoryId));
				if (mct_Result != null)
				{
					if (mct_Result.Result > 0)
					{
						data = true;
						message = MyResource.GetResourceString("SuccessDoneRegister", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
						status = ServiceResultStatus.Success;
					}
					else
					{
						data = false;
						message = MyResource.GetResourceString("RedundancyMessage", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
						status = ServiceResultStatus.Fail;
					}
				}
				else
				{
					data = false;
					message = MyResource.GetResourceString("RedundancyMessage", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
					status = ServiceResultStatus.Fail;
				}
			}
			else
			{
				data = false;
				message = MyResource.GetResourceString("ErrorNotFound", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				status = ServiceResultStatus.Fail;
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
			data = false;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(ex);
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
}
