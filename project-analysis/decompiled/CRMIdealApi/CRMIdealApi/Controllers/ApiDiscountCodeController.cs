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
using CRMIdealApi.ApiModels.ViewModel.DiscountCodes;
using CRMIdealApi.Classes;
using CRMIdealApi.Classes.Common;
using CRMIdealApi.Classes.Helper;
using CRMIdealApi.DataType;
using CRMIdealApi.Resources;
using Elmah;
using GSD.Globalization;
using Newtonsoft.Json;

namespace CRMIdealApi.Controllers;

public class ApiDiscountCodeController : ApiController
{
	[HttpPost]
	public ServiceResult<bool> CheckDiscountCodeBeforeUse(CheckDiscountCodeBeforeUseViewModel model)
	{
		CRMEntities cRMEntities = null;
		string text = "";
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
			ServiceResult<bool> serviceResult;
			if (result2 == 0)
			{
				serviceResult = new ServiceResult<bool>();
				serviceResult.Message = MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = false;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			ApispCheckDiscountCodeToUse_Result apispCheckDiscountCodeToUse_Result = Enumerable.FirstOrDefault<ApispCheckDiscountCodeToUse_Result>((IEnumerable<ApispCheckDiscountCodeToUse_Result>)cRMEntities.ApispCheckDiscountCodeToUse(model.ApiDisCode, model.ApiCompanyId, model.ApiOrderId, model.ApiPreOrderId, model.CenterId, model.CenterCode, DateTime.Now));
			string errorMessage = apispCheckDiscountCodeToUse_Result.ErrorMessage;
			if (!string.IsNullOrWhiteSpace(errorMessage))
			{
				string[] array = errorMessage.Trim(new char[1] { '|' }).Split(new char[1] { '|' });
				string[] array2 = array;
				int num2 = 0;
				if (num2 < array2.Length)
				{
					switch (array2[num2])
					{
					default:
						serviceResult = new ServiceResult<bool>();
						serviceResult.Message = MyResource.GetResourceString("DiscountNotFound", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
						serviceResult.Data = false;
						serviceResult.Status = ServiceResultStatus.Error;
						return serviceResult;
					case "DiscountExpired":
						serviceResult = new ServiceResult<bool>();
						serviceResult.Message = MyResource.GetResourceString("DiscountExpired", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
						serviceResult.Data = false;
						serviceResult.Status = ServiceResultStatus.Error;
						return serviceResult;
					case "DiscountUsageLimit":
						serviceResult = new ServiceResult<bool>();
						serviceResult.Message = MyResource.GetResourceString("DiscountUsageLimit", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
						serviceResult.Data = false;
						serviceResult.Status = ServiceResultStatus.Error;
						return serviceResult;
					case "DiscountUsageLimitUser":
						serviceResult = new ServiceResult<bool>();
						serviceResult.Message = MyResource.GetResourceString("DiscountUsageLimitUser", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
						serviceResult.Data = false;
						serviceResult.Status = ServiceResultStatus.Error;
						return serviceResult;
					case "DiscountNoScoreMin":
						serviceResult = new ServiceResult<bool>();
						serviceResult.Message = MyResource.GetResourceString("DiscountNoScoreMin", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
						serviceResult.Data = false;
						serviceResult.Status = ServiceResultStatus.Error;
						return serviceResult;
					case "DiscountNotApplicable":
						serviceResult = new ServiceResult<bool>();
						serviceResult.Message = MyResource.GetResourceString("DiscountNotApplicable", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
						serviceResult.Data = false;
						serviceResult.Status = ServiceResultStatus.Error;
						return serviceResult;
					}
				}
			}
			serviceResult = new ServiceResult<bool>();
			serviceResult.Message = MyResource.GetResourceString("SuccessDoneRegister", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
			serviceResult.Data = apispCheckDiscountCodeToUse_Result.IsUsable.GetValueOrDefault();
			serviceResult.Status = ServiceResultStatus.Success;
			return serviceResult;
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			string text2 = ex.Message;
			if (ex.InnerException != null)
			{
				text2 = text2 + " - " + ex.InnerException.Message;
			}
			text = Messages.ErrorDoneOperation + " (" + text2 + ")";
			return new ServiceResult<bool>
			{
				Message = text,
				Data = false,
				Status = ServiceResultStatus.Fail
			};
		}
		finally
		{
			cRMEntities?.Dispose();
		}
	}

	[HttpPost]
	public ServiceResult<ApispInsertDiscountCodeFromDisCodeRule_Result> InsertDiscountCodeFromRule(InsertDiscountCodeFromRuleViewModel model)
	{
		CRMEntities cRMEntities = null;
		ApispInsertDiscountCodeFromDisCodeRule_Result apispInsertDiscountCodeFromDisCodeRule_Result = null;
		string text = "";
		ServiceResultStatus serviceResultStatus = ServiceResultStatus.Error;
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				return new ServiceResult<ApispInsertDiscountCodeFromDisCodeRule_Result>
				{
					Message = Messages.ErrorAccessAPILimited,
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			cRMEntities = new CRMEntities();
			ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
			if (apispSelectCrmsysSetting_Result == null)
			{
				return new ServiceResult<ApispInsertDiscountCodeFromDisCodeRule_Result>
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
			if (!VersionBuyer.DiscountCode)
			{
				return new ServiceResult<ApispInsertDiscountCodeFromDisCodeRule_Result>
				{
					Message = string.Format(Messages.ResourceManager.GetString("ErrorMsgBuyModule", new CultureInfo(currLangId)), Labels.ResourceManager.GetString("lblDiscountCode", new CultureInfo(currLangId))),
					Data = null,
					Status = ServiceResultStatus.Error
				};
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
			ServiceResult<ApispInsertDiscountCodeFromDisCodeRule_Result> serviceResult;
			if (result2 == 0)
			{
				serviceResult = new ServiceResult<ApispInsertDiscountCodeFromDisCodeRule_Result>();
				serviceResult.Message = MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			double num2 = 0.0;
			ApispReturnSumCompanyScores_Result apispReturnSumCompanyScores_Result = Enumerable.FirstOrDefault<ApispReturnSumCompanyScores_Result>((IEnumerable<ApispReturnSumCompanyScores_Result>)cRMEntities.ApispReturnSumCompanyScores(model.ApiCompanyId, model.CenterId, model.CenterCode));
			if (apispReturnSumCompanyScores_Result != null)
			{
				num2 = apispReturnSumCompanyScores_Result.ApiSumUsableScores;
			}
			ApispSelectDiscountCodeRuleWithId_Result apispSelectDiscountCodeRuleWithId_Result = Enumerable.FirstOrDefault<ApispSelectDiscountCodeRuleWithId_Result>((IEnumerable<ApispSelectDiscountCodeRuleWithId_Result>)cRMEntities.ApispSelectDiscountCodeRuleWithId(model.ApiRuleId, currLangId, result));
			if (apispSelectDiscountCodeRuleWithId_Result != null)
			{
				if (apispSelectDiscountCodeRuleWithId_Result.DisRScoreRate.GetValueOrDefault() != 0.0 && apispSelectDiscountCodeRuleWithId_Result.DisRScoreRate > num2)
				{
					apispInsertDiscountCodeFromDisCodeRule_Result = null;
					text = MyResource.GetResourceString("ErrorDisCodeRuleYourScoreIsNotEnough", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
					serviceResultStatus = ServiceResultStatus.Error;
					return new ServiceResult<ApispInsertDiscountCodeFromDisCodeRule_Result>
					{
						Data = apispInsertDiscountCodeFromDisCodeRule_Result,
						Message = text,
						Status = serviceResultStatus
					};
				}
				DateTime? dateTime = null;
				if (apispSelectDiscountCodeRuleWithId_Result.DisRExpDay.GetValueOrDefault() != 0)
				{
					dateTime = DateTime.Now.AddDays(apispSelectDiscountCodeRuleWithId_Result.DisRExpDay.GetValueOrDefault());
				}
				else if (apispSelectDiscountCodeRuleWithId_Result.DisRExpDate.HasValue)
				{
					dateTime = apispSelectDiscountCodeRuleWithId_Result.DisRExpDate;
				}
				List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
				foreach (ApispSelectLanguages_Result item in list)
				{
					list2.Add(new CommonMultiLanguageViewModel
					{
						LanguageId = item.LanguageID,
						Value = Labels.ResourceManager.GetString("GenerateDiscountCodeFromDisCodeRuleTitle", new CultureInfo(item.LanguageID))
					});
				}
				double? num3 = apispSelectDiscountCodeRuleWithId_Result.DisRScoreRate;
				if (num3 == 0.0)
				{
					num3 = null;
				}
				else if (num3 > 0.0)
				{
					num3 = -1.0 * num3;
				}
				DateTime now = DateTime.Now;
				DateTime value = now;
				string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
				short value3 = short.Parse(now.ToString("yyyy", new PersianCulture()));
				string dubClickDisplayCmpInfo = Messages.DubClickDisplayCmpInfo;
				string appType = CRMIdealApi.Classes.Configuration.AppType;
				CRMEntities cRMEntities2 = cRMEntities;
				int? ruleId = model.ApiRuleId;
				string titleJs = JsonConvert.SerializeObject(list2);
				decimal? disRAmount = apispSelectDiscountCodeRuleWithId_Result.DisRAmount;
				decimal? disRAmountPercent = apispSelectDiscountCodeRuleWithId_Result.DisRAmountPercent;
				DateTime? disExpDate = dateTime;
				string disExpDatePersian = dateTime?.ToString("yyyyMMdd", new PersianCulture());
				int? disCmpId = model.ApiCompanyId;
				int? disRUseCnt = apispSelectDiscountCodeRuleWithId_Result.DisRUseCnt;
				int? languageID = currLangId;
				int? defaultLanguageID = result;
				double? scoreRate = num3;
				bool? disRCanChangeToScore = apispSelectDiscountCodeRuleWithId_Result.DisRCanChangeToScore;
				string disRPreCode = apispSelectDiscountCodeRuleWithId_Result.DisRPreCode;
				int? userId = model.UserId;
				short? year = value3;
				short? month = value2;
				DateTime? registerDate = value;
				int? centerId = model.CenterId;
				string centerCode = model.CenterCode;
				ApispInsertDiscountCodeFromDisCodeRule_Result apispInsertDiscountCodeFromDisCodeRule_Result2 = Enumerable.FirstOrDefault<ApispInsertDiscountCodeFromDisCodeRule_Result>((IEnumerable<ApispInsertDiscountCodeFromDisCodeRule_Result>)cRMEntities2.ApispInsertDiscountCodeFromDisCodeRule(ruleId, titleJs, disRAmount, disRAmountPercent, disExpDate, disExpDatePersian, disCmpId, disRUseCnt, languageID, defaultLanguageID, scoreRate, disRCanChangeToScore, disRPreCode, userId, year, month, registerDate, registerDatePersian, appType, centerId, centerCode));
				if (apispInsertDiscountCodeFromDisCodeRule_Result2 != null)
				{
					serviceResult = new ServiceResult<ApispInsertDiscountCodeFromDisCodeRule_Result>();
					serviceResult.Data = apispInsertDiscountCodeFromDisCodeRule_Result2;
					serviceResult.Message = MyResource.GetResourceString("SuccessDoneRegister", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
					serviceResult.Status = ServiceResultStatus.Success;
					return serviceResult;
				}
				serviceResult = new ServiceResult<ApispInsertDiscountCodeFromDisCodeRule_Result>();
				serviceResult.Data = null;
				serviceResult.Message = MyResource.GetResourceString("ErrorDoneOperation", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			serviceResult = new ServiceResult<ApispInsertDiscountCodeFromDisCodeRule_Result>();
			serviceResult.Data = null;
			serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorRecordNotFound", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("DiscountCodeRule", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
			serviceResult.Status = ServiceResultStatus.Error;
			return serviceResult;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			return new ServiceResult<ApispInsertDiscountCodeFromDisCodeRule_Result>
			{
				Message = Messages.ErrorDoneOperation,
				Data = null,
				Status = ServiceResultStatus.Fail
			};
		}
		finally
		{
			cRMEntities?.Dispose();
		}
	}

	[HttpPost]
	public ServiceResult<List<ApispSelectDiscountCodeRules_Result>> SelectDiscountCodeRules(PublicParameters model)
	{
		CRMEntities cRMEntities = null;
		ApispSelectDiscountCodeRules_Result apispSelectDiscountCodeRules_Result = null;
		string text = "";
		ServiceResultStatus serviceResultStatus = ServiceResultStatus.Error;
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				return new ServiceResult<List<ApispSelectDiscountCodeRules_Result>>
				{
					Message = Messages.ErrorAccessAPILimited,
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			cRMEntities = new CRMEntities();
			ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
			if (apispSelectCrmsysSetting_Result == null)
			{
				return new ServiceResult<List<ApispSelectDiscountCodeRules_Result>>
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
				ServiceResult<List<ApispSelectDiscountCodeRules_Result>> serviceResult = new ServiceResult<List<ApispSelectDiscountCodeRules_Result>>();
				serviceResult.Message = MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			List<ApispSelectDiscountCodeRules_Result> list2 = Enumerable.ToList<ApispSelectDiscountCodeRules_Result>((IEnumerable<ApispSelectDiscountCodeRules_Result>)cRMEntities.ApispSelectDiscountCodeRules(DateTime.Now, currLangId, result));
			if (list2 != null)
			{
				text = MyResource.GetResourceString("SuccessDoneRegister", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResultStatus = ServiceResultStatus.Success;
			}
			else
			{
				text = MyResource.GetResourceString("ErrorNotFound", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResultStatus = ServiceResultStatus.Fail;
			}
			return new ServiceResult<List<ApispSelectDiscountCodeRules_Result>>
			{
				Data = list2,
				Message = text,
				Status = serviceResultStatus
			};
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			string text2 = ex.Message;
			if (ex.InnerException != null)
			{
				text2 = text2 + " - " + ex.InnerException.Message;
			}
			text = Messages.ErrorDoneOperation + " (" + text2 + ")";
			return new ServiceResult<List<ApispSelectDiscountCodeRules_Result>>
			{
				Message = text,
				Data = null,
				Status = ServiceResultStatus.Fail
			};
		}
		finally
		{
			cRMEntities?.Dispose();
		}
	}

	[HttpPost]
	public ServiceResult<int> InsertDiscountCodeRule(InsertDiscountCodeRuleViewModel model)
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
			int result = 1065;
			int.TryParse(apispSelectCrmsysSetting_Result.DefaultLanguageID.ToString(), out result);
			if (result <= 0)
			{
				result = 1065;
			}
			int currLangId = result;
			int.TryParse(model.LanguageId.ToString(), out currLangId);
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
			if (!VersionBuyer.DiscountCode)
			{
				return new ServiceResult<int>
				{
					Message = string.Format(Messages.ResourceManager.GetString("ErrorMsgBuyModule", new CultureInfo(currLangId)), Labels.ResourceManager.GetString("lblDiscountCode", new CultureInfo(currLangId))),
					Data = 0,
					Status = ServiceResultStatus.Error
				};
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
			if (string.IsNullOrEmpty(model.ApiDisRTitle))
			{
				ServiceResult<int> serviceResult = new ServiceResult<int>();
				serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorItemIsNotEntered", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("Title", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
				serviceResult.Data = 0;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
			short num2 = short.Parse(now.ToString("yyyy", new PersianCulture()));
			string appType = CRMIdealApi.Classes.Configuration.AppType;
			DateTime? dateTime = DateTimeClass.ParseGregorianDate(model.ApiDisRExpDate);
			string disRExpDatePersian = DateTimeClass.ToPersianDateString(dateTime);
			ObjectParameter objectParameter = new ObjectParameter("InsertedId", 0);
			ObjectParameter objectParameter2 = new ObjectParameter("ErrorMessage", "");
			int? num3 = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.ApispInsertDiscountCodeRule(model.ApiDisRTitle, model.ApiDisRTitle, model.ApiDisRAmount, model.ApiDisRAmountPercent, model.ApiDisRExpDay, dateTime, disRExpDatePersian, model.ApiDisRUseCnt, model.ApiDisRScoreRate, model.ApiDisRCanChangeToScore, model.ApiDisRInActive, model.UserId, value2, value, registerDatePersian, appType, currLangId, result, objectParameter, objectParameter2));
			string resourceString = MyResource.GetResourceString("ErrorDoneOperationTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
			if (!string.IsNullOrWhiteSpace(objectParameter2.Value?.ToString()))
			{
				string[] array = objectParameter2.Value.ToString().Trim(new char[1] { '|' }).Split(new char[1] { '|' });
				string[] array2 = array;
				int num4 = 0;
				if (num4 < array2.Length)
				{
					string text = array2[num4];
					_ = text == "ErrorInInsertDiscountCodeRule";
					ServiceResult<int> serviceResult = new ServiceResult<int>();
					serviceResult.Message = MyResource.GetResourceString("ErrorDoneOperation", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + resourceString;
					serviceResult.Data = 0;
					serviceResult.Status = ServiceResultStatus.Fail;
					return serviceResult;
				}
			}
			data = ((objectParameter.Value != null) ? Convert.ToInt32(objectParameter.Value) : 0);
			message = MyResource.GetResourceString("SuccessDoneRegister", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
			status = ServiceResultStatus.Success;
		}
		catch (Exception ex)
		{
			string text2 = ex.Message;
			if (ex.InnerException != null)
			{
				text2 = text2 + " - " + ex.InnerException.Message;
			}
			message = Messages.ErrorDoneOperation + " (" + text2 + ")";
			data = 0;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(ex);
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
	public ServiceResult<int> UpdateDiscountCodeRule(UpdateDiscountCodeRuleViewModel model)
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
			if (model.ApiDiscountCodeRuleId <= 0)
			{
				ServiceResult<int> serviceResult = new ServiceResult<int>();
				serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorItemIdIsNotEntered", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("DiscountCodeRule", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
				serviceResult.Data = 0;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			int userId = model.UserId;
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
			short num2 = short.Parse(now.ToString("yyyy", new PersianCulture()));
			string dubClickDisplayCmpInfo = Messages.DubClickDisplayCmpInfo;
			string appType = CRMIdealApi.Classes.Configuration.AppType;
			string text = commonClass.ConvertNameToDayNum(now.DayOfWeek.ToString());
			string text2 = now.ToString("HH:mm:ss");
			DateTime? dateTime = DateTimeClass.ParseGregorianDate(model.ApiDisRExpDate);
			string disRExpDatePersian = DateTimeClass.ToPersianDateString(dateTime);
			ObjectParameter objectParameter = new ObjectParameter("ErrorMessage", "");
			int num3 = cRMEntities.ApispUpdateDiscountCodeRule(model.ApiDiscountCodeRuleId, model.ApiDisRTitle, model.ApiDisRPreCode, model.ApiDisRAmount, model.ApiDisRAmountPercent, model.ApiDisRExpDay, dateTime, disRExpDatePersian, model.ApiDisRUseCnt, model.ApiDisRScoreRate, model.ApiDisRCanChangeToScore, model.ApiDisRInActive, model.UserId, value2, value, registerDatePersian, appType, currLangId, result, objectParameter);
			string resourceString = MyResource.GetResourceString("ErrorDoneOperationTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
			if (!string.IsNullOrWhiteSpace(objectParameter.Value?.ToString()))
			{
				string[] array = objectParameter.Value.ToString().Trim(new char[1] { '|' }).Split(new char[1] { '|' });
				string[] array2 = array;
				int num4 = 0;
				if (num4 < array2.Length)
				{
					switch (array2[num4])
					{
					case "MissingDiscountCodeRuleId":
					{
						ServiceResult<int> serviceResult = new ServiceResult<int>();
						serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorItemIdIsNotEntered", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("DiscountCodeRule", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
						serviceResult.Data = 0;
						serviceResult.Status = ServiceResultStatus.Error;
						return serviceResult;
					}
					case "DiscountCodeRuleNotFound":
					{
						ServiceResult<int> serviceResult = new ServiceResult<int>();
						serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorRecordNotFound", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("DiscountCodeRule", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
						serviceResult.Data = 0;
						serviceResult.Status = ServiceResultStatus.Error;
						return serviceResult;
					}
					default:
					{
						ServiceResult<int> serviceResult = new ServiceResult<int>();
						serviceResult.Message = MyResource.GetResourceString("ErrorDoneOperation", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + resourceString;
						serviceResult.Data = 0;
						serviceResult.Status = ServiceResultStatus.Fail;
						return serviceResult;
					}
					}
				}
			}
			data = 1;
			message = MyResource.GetResourceString("SuccessDoneRegister", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
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
			data = 0;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(ex);
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
	public ServiceResult<bool> DeleteDiscountCodeRule(DeleteDiscountCodeRuleViewModel model)
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
			int result = 1065;
			int.TryParse(apispSelectCrmsysSetting_Result.DefaultLanguageID.ToString(), out result);
			if (result <= 0)
			{
				result = 1065;
			}
			int currLangId = result;
			int.TryParse(model.LanguageId.ToString(), out currLangId);
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
			string resourceString = MyResource.GetResourceString("ErrorDoneOperationTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
			if (model.ApiDiscountCodeRuleId <= 0)
			{
				ServiceResult<bool> serviceResult = new ServiceResult<bool>();
				serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorItemIdIsNotEntered", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("DiscountCodeRule", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
				serviceResult.Data = false;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			ObjectParameter objectParameter = new ObjectParameter("ErrorMessage", "");
			int? num2 = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.ApispDeleteDiscountCodeRule(model.ApiDiscountCodeRuleId, objectParameter));
			if (!string.IsNullOrWhiteSpace(objectParameter.Value?.ToString()))
			{
				string[] array = objectParameter.Value.ToString().Trim(new char[1] { '|' }).Split(new char[1] { '|' });
				string[] array2 = array;
				int num3 = 0;
				if (num3 < array2.Length)
				{
					string text = array2[num3];
					_ = text == "ErrorInDeleteDiscountCodeRule";
					ServiceResult<bool> serviceResult = new ServiceResult<bool>();
					serviceResult.Message = MyResource.GetResourceString("ErrorDoneOperation", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + resourceString;
					serviceResult.Data = false;
					serviceResult.Status = ServiceResultStatus.Fail;
					return serviceResult;
				}
			}
			data = true;
			message = MyResource.GetResourceString("SuccessDoneRegister", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
			status = ServiceResultStatus.Success;
		}
		catch (Exception ex)
		{
			string text2 = ex.Message;
			if (ex.InnerException != null)
			{
				text2 = text2 + " - " + ex.InnerException.Message;
			}
			message = Messages.ErrorDoneOperation + " (" + text2 + ")";
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
