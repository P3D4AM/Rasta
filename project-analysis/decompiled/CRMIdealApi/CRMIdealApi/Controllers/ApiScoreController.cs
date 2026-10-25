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
using CRMIdealApi.ApiModels.ViewModel.Scores;
using CRMIdealApi.Classes;
using CRMIdealApi.Classes.Common;
using CRMIdealApi.DataType;
using CRMIdealApi.Resources;
using Elmah;
using GSD.Globalization;
using Newtonsoft.Json;

namespace CRMIdealApi.Controllers;

public class ApiScoreController : ApiController
{
	[HttpPost]
	public ServiceResult<ApispReturnSumCompanyScores_Result> GetSumCompanyScore(SumCompanyScoreViewModel model)
	{
		CRMEntities cRMEntities = null;
		string text = "";
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				return new ServiceResult<ApispReturnSumCompanyScores_Result>
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
				return new ServiceResult<ApispReturnSumCompanyScores_Result>
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
			ServiceResult<ApispReturnSumCompanyScores_Result> serviceResult;
			if (result2 == 0)
			{
				serviceResult = new ServiceResult<ApispReturnSumCompanyScores_Result>();
				serviceResult.Message = MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			ApispReturnSumCompanyScores_Result data = Enumerable.FirstOrDefault<ApispReturnSumCompanyScores_Result>((IEnumerable<ApispReturnSumCompanyScores_Result>)cRMEntities.ApispReturnSumCompanyScores(model.ApiCompanyId, model.CenterId, model.CenterCode));
			serviceResult = new ServiceResult<ApispReturnSumCompanyScores_Result>();
			serviceResult.Message = MyResource.GetResourceString("SuccessDoneRegister", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
			serviceResult.Data = data;
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
			return new ServiceResult<ApispReturnSumCompanyScores_Result>
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
	public ServiceResult<int> Insert(InsertScoreViewModel model)
	{
		CRMEntities cRMEntities = null;
		ApispInsertDiscountCodeFromDisCodeRule_Result apispInsertDiscountCodeFromDisCodeRule_Result = null;
		string text = "";
		ServiceResultStatus serviceResultStatus = ServiceResultStatus.Error;
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
			int.TryParse(apispSelectCrmsysSetting_Result.DefaultLanguageID.ToString(), out var defLangId);
			if (defLangId <= 0)
			{
				defLangId = 1065;
			}
			int.TryParse(model.LanguageId.ToString(), out var currLangId);
			if (currLangId <= 0)
			{
				currLangId = defLangId;
			}
			List<ApispSelectLanguages_Result> list = Enumerable.ToList<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)cRMEntities.ApispSelectLanguages());
			string culture = "fa-IR";
			ApispSelectLanguages_Result apispSelectLanguages_Result = Enumerable.FirstOrDefault<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result m) => m.LanguageID == currLangId));
			if (apispSelectLanguages_Result != null)
			{
				culture = apispSelectLanguages_Result.LanguageCollation;
			}
			if (!VersionBuyer.Score)
			{
				return new ServiceResult<int>
				{
					Message = string.Format(Messages.ResourceManager.GetString("ErrorMsgBuyModule", new CultureInfo(currLangId)), Labels.ResourceManager.GetString("lblScore", new CultureInfo(currLangId))),
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
			int result = 0;
			int.TryParse(num.ToString(), out result);
			if (result == 0)
			{
				ServiceResult<int> serviceResult = new ServiceResult<int>();
				serviceResult.Message = MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = 0;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			DateTime? scoreDate = DateTimeClass.ParseGregorianDate(model.ApiScoreDate);
			DateTime? scoreExpireDate = DateTimeClass.ParseGregorianDate(model.ApiScoreExpireDate);
			string text2 = "";
			List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(model.ApiScoreDescription))
			{
				foreach (ApispSelectLanguages_Result item in list)
				{
					list2.Add(new CommonMultiLanguageViewModel
					{
						LanguageId = item.LanguageID,
						Value = model.ApiScoreDescription
					});
				}
				text2 = JsonConvert.SerializeObject(list2);
			}
			if (model.ApiScoreExpireDate == null && model.ApiScoreExpireDay.GetValueOrDefault() != 0)
			{
				try
				{
					scoreExpireDate = DateTime.Now.AddDays(model.ApiScoreExpireDay.GetValueOrDefault());
				}
				catch (Exception)
				{
					scoreExpireDate = null;
				}
			}
			if (!model.ApiScoreOprType.HasValue)
			{
				if (model.ApiScore > 0.0)
				{
					model.ApiScoreOprType = 1;
				}
				else if (model.ApiScore <= 0.0)
				{
					model.ApiScoreOprType = 2;
				}
			}
			if (model.ApiScoreSysPartId.GetValueOrDefault() == 90)
			{
				model.ApiScoreDescription = string.Format(Messages.ResourceManager.GetString("msgAutoInsertToMoneyBag", new CultureInfo(defLangId)), model.ApiPrice.ToString("#,#"), Labels.ResourceManager.GetString("LanguageMainCurrency", new CultureInfo(defLangId)), model.ApiScoreRuleRate.ToString());
				List<CommonMultiLanguageViewModel> list3 = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrWhiteSpace(text2))
				{
					list3 = JsonConvert.DeserializeObject<List<CommonMultiLanguageViewModel>>(text2);
				}
				else
				{
					foreach (ApispSelectLanguages_Result item2 in Enumerable.Where<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result x) => x.LanguageID != defLangId)))
					{
						list3.Add(new CommonMultiLanguageViewModel
						{
							LanguageId = item2.LanguageID
						});
					}
				}
				foreach (CommonMultiLanguageViewModel item3 in list3)
				{
					item3.Value = item3.Value + ((item3.Value != null) ? " " : "") + string.Format(Messages.ResourceManager.GetString("msgAutoInsertToMoneyBag", new CultureInfo(item3.LanguageId)), model.ApiPrice.ToString("#,#"), Labels.ResourceManager.GetString("LanguageMainCurrency", new CultureInfo(item3.LanguageId)), model.ApiScoreRuleRate.ToString());
				}
				text2 = JsonConvert.SerializeObject(list3);
			}
			DateTime now = DateTime.Now;
			DateTime value = now;
			string text3 = now.ToString("yyyyMMdd", new PersianCulture());
			short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			short value3 = short.Parse(now.ToString("yyyy", new PersianCulture()));
			string dubClickDisplayCmpInfo = Messages.DubClickDisplayCmpInfo;
			string appType = CRMIdealApi.Classes.Configuration.AppType;
			ObjectParameter result2 = new ObjectParameter("Result", 0);
			int num2 = cRMEntities.ApispInsertScore(scoreDate, model.ApiScore, model.ApiScoreOrderId, model.ApiScoreCmpId, model.ApiScoreRuleId, model.ApiOrderView, 0, model.UserId, value3, value2, value, appType, currLangId, defLangId, model.ApiScoreSysPartId, model.ApiScoreObjectId, model.ApiScoreOprType, scoreExpireDate, model.ApiScoreIsExpired, model.ApiScoreDescription, text2, "", model.ApiCompanyId, model.ApiPrice, result2, model.ApiScoreKind, model.CenterId, model.CenterCode);
			if (num2 > 0)
			{
				return new ServiceResult<int>
				{
					Data = num2,
					Message = Messages.msgSuccessAction,
					Status = ServiceResultStatus.Success
				};
			}
			return new ServiceResult<int>
			{
				Data = 0,
				Message = Messages.ErrorDoneOperation,
				Status = ServiceResultStatus.Error
			};
		}
		catch (Exception ex2)
		{
			ErrorSignal.FromCurrentContext().Raise(ex2);
			string text4 = ex2.Message;
			if (ex2.InnerException != null)
			{
				text4 = text4 + " - " + ex2.InnerException.Message;
			}
			text = Messages.ErrorDoneOperation + " (" + text4 + ")";
			return new ServiceResult<int>
			{
				Message = text,
				Data = 0,
				Status = ServiceResultStatus.Fail
			};
		}
		finally
		{
			cRMEntities?.Dispose();
		}
	}

	[HttpPost]
	public ServiceResult<int> Update(UpdateScoreViewModel model)
	{
		CRMEntities cRMEntities = null;
		ApispInsertDiscountCodeFromDisCodeRule_Result apispInsertDiscountCodeFromDisCodeRule_Result = null;
		string text = "";
		ServiceResultStatus serviceResultStatus = ServiceResultStatus.Error;
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
			string text2 = null;
			string text3 = null;
			ServiceResult<int> serviceResult;
			if (!string.IsNullOrEmpty(model.ApiScoreDate) && model.ApiScoreDate.ToLower() == "null")
			{
				text2 = model.ApiScoreDate;
				model.ApiScoreDateTime = null;
			}
			else
			{
				try
				{
					if (model.ApiScoreDateTime.HasValue)
					{
						text2 = (model.ApiScoreDateTime ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
					}
				}
				catch (Exception)
				{
					serviceResult = new ServiceResult<int>();
					serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CnvsDate", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
					serviceResult.Data = 0;
					serviceResult.Status = ServiceResultStatus.Error;
					return serviceResult;
				}
			}
			if (!string.IsNullOrEmpty(model.ApiScoreExpireDate) && model.ApiScoreExpireDate.ToLower() == "null")
			{
				text3 = model.ApiScoreExpireDate;
				model.ApiScoreExpireDateTime = null;
			}
			else
			{
				try
				{
					if (model.ApiScoreExpireDateTime.HasValue)
					{
						text3 = (model.ApiScoreExpireDateTime ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
					}
				}
				catch (Exception)
				{
					serviceResult = new ServiceResult<int>();
					serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CnvsDate", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
					serviceResult.Data = 0;
					serviceResult.Status = ServiceResultStatus.Error;
					return serviceResult;
				}
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
				serviceResult = new ServiceResult<int>();
				serviceResult.Message = MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = 0;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			if (model.ApiScoreId <= 0)
			{
				serviceResult = new ServiceResult<int>();
				serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorItemIdIsNotEntered", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("Score", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
				serviceResult.Data = 0;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			if (!model.ApiScoreOprType.HasValue)
			{
				if (model.ApiScore > 0.0)
				{
					model.ApiScoreOprType = 1;
				}
				else if (model.ApiScore <= 0.0)
				{
					model.ApiScoreOprType = 2;
				}
			}
			if (model.ApiScoreSysPartId.GetValueOrDefault() == 90)
			{
				model.ApiScoreDescription = string.Format(Messages.ResourceManager.GetString("msgAutoInsertToMoneyBag", new CultureInfo(result)), model.ApiPrice.ToString("#,#"), Labels.ResourceManager.GetString("LanguageMainCurrency", new CultureInfo(result)), model.ApiScoreRuleRate.ToString());
			}
			DateTime now = DateTime.Now;
			DateTime value = now;
			string text4 = now.ToString("yyyyMMdd", new PersianCulture());
			short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			short value3 = short.Parse(now.ToString("yyyy", new PersianCulture()));
			string dubClickDisplayCmpInfo = Messages.DubClickDisplayCmpInfo;
			string appType = CRMIdealApi.Classes.Configuration.AppType;
			ObjectParameter errorMessage = new ObjectParameter("ErrorMessage", "");
			int num2 = cRMEntities.ApispUpdateScore(model.ApiScoreId, model.ApiScoreDateTime, text2, model.ApiScore, model.ApiScoreRuleId, orderView: model.ApiOrderView, userId: model.UserId, year1: value3, month1: value2, registerDate: value, registerDatePersian: text4, appType: appType, languageID: currLangId, defaultLanguageID: result, scoreSysPartId: model.ApiScoreSysPartId, scoreObjectId: model.ApiScoreObjectId, scoreOprType: model.ApiScoreOprType, scoreExpireDate: model.ApiScoreExpireDateTime, scoreExpireDatePersian: text3, scoreIsExpired: model.ApiScoreIsExpired, scoreDescription: model.ApiScoreDescription, companyId: model.ApiCompanyId, price: model.ApiPrice, scoreKind: model.ApiScoreKind, centerId: model.CenterId, centerCode: model.CenterCode, errorMessage: errorMessage);
			if (num2 > 0)
			{
				serviceResult = new ServiceResult<int>();
				serviceResult.Data = 1;
				serviceResult.Message = MyResource.GetResourceString("SuccessDoneRegister", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Status = ServiceResultStatus.Success;
				return serviceResult;
			}
			serviceResult = new ServiceResult<int>();
			serviceResult.Data = 0;
			serviceResult.Message = MyResource.GetResourceString("ErrorDoneOperation", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
			serviceResult.Status = ServiceResultStatus.Error;
			return serviceResult;
		}
		catch (Exception ex3)
		{
			ErrorSignal.FromCurrentContext().Raise(ex3);
			string text5 = ex3.Message;
			if (ex3.InnerException != null)
			{
				text5 = text5 + " - " + ex3.InnerException.Message;
			}
			text = Messages.ErrorDoneOperation + " (" + text5 + ")";
			return new ServiceResult<int>
			{
				Message = text,
				Data = 0,
				Status = ServiceResultStatus.Fail
			};
		}
		finally
		{
			cRMEntities?.Dispose();
		}
	}

	[HttpPost]
	public ServiceResult<bool> Delete(DeleteScoreViewModel model)
	{
		CRMEntities cRMEntities = null;
		ApispInsertDiscountCodeFromDisCodeRule_Result apispInsertDiscountCodeFromDisCodeRule_Result = null;
		string text = "";
		ServiceResultStatus serviceResultStatus = ServiceResultStatus.Error;
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
			if (model.ApiScoreId <= 0)
			{
				serviceResult = new ServiceResult<bool>();
				serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorItemIdIsNotEntered", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("Score", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
				serviceResult.Data = false;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			short num2 = short.Parse(now.ToString("MM", new PersianCulture()));
			short value2 = short.Parse(now.ToString("yyyy", new PersianCulture()));
			string appType = CRMIdealApi.Classes.Configuration.AppType;
			int? num3 = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.ApispDeleteScore(model.ApiScoreId, model.UserId, value2, value2, value, registerDatePersian, appType, result, model.CenterId, model.CenterCode));
			if (num3.HasValue && num3 > 0)
			{
				serviceResult = new ServiceResult<bool>();
				serviceResult.Data = true;
				serviceResult.Message = MyResource.GetResourceString("SuccessDoneRegister", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Status = ServiceResultStatus.Success;
				return serviceResult;
			}
			serviceResult = new ServiceResult<bool>();
			serviceResult.Data = false;
			serviceResult.Message = MyResource.GetResourceString("ErrorDoneOperation", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
			serviceResult.Status = ServiceResultStatus.Error;
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
	public ServiceResult<List<ScorespSelectOrderScores_Result>> SelectOrderScores(SelectOrderScoresViewModel model)
	{
		CRMEntities cRMEntities = null;
		ScorespSelectOrderScores_Result scorespSelectOrderScores_Result = null;
		string text = "";
		ServiceResultStatus serviceResultStatus = ServiceResultStatus.Error;
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				return new ServiceResult<List<ScorespSelectOrderScores_Result>>
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
				return new ServiceResult<List<ScorespSelectOrderScores_Result>>
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
				ServiceResult<List<ScorespSelectOrderScores_Result>> serviceResult = new ServiceResult<List<ScorespSelectOrderScores_Result>>();
				serviceResult.Message = MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			List<ScorespSelectOrderScores_Result> list2 = Enumerable.ToList<ScorespSelectOrderScores_Result>((IEnumerable<ScorespSelectOrderScores_Result>)cRMEntities.ScorespSelectOrderScores(model.ApiOrderId, currLangId, result, model.CenterId));
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
			return new ServiceResult<List<ScorespSelectOrderScores_Result>>
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
			return new ServiceResult<List<ScorespSelectOrderScores_Result>>
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
}
