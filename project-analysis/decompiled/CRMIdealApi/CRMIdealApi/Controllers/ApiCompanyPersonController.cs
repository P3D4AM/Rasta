using System;
using System.Collections.Generic;
using System.Data.Objects;
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

public class ApiCompanyPersonController : ApiController
{
	[HttpPost]
	public ServiceResult<ApispReturnCompanyPersonId_Result> ReturnCompanyPersonId(ReturnCompanyPersonIdViewModel model)
	{
		CRMEntities cRMEntities = null;
		ApispReturnCompanyPersonId_Result data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				return new ServiceResult<ApispReturnCompanyPersonId_Result>
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
				return new ServiceResult<ApispReturnCompanyPersonId_Result>
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
				ServiceResult<ApispReturnCompanyPersonId_Result> serviceResult = new ServiceResult<ApispReturnCompanyPersonId_Result>();
				serviceResult.Message = MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			ApispReturnCompanyPersonId_Result apispReturnCompanyPersonId_Result = Enumerable.FirstOrDefault<ApispReturnCompanyPersonId_Result>((IEnumerable<ApispReturnCompanyPersonId_Result>)cRMEntities.ApispReturnCompanyPersonId(model.ApiCmpNumber, model.ApiCmpCode, model.ApiPrsMobile, model.ApiPrsEmail, model.ApiPrsNationalCode));
			if (apispReturnCompanyPersonId_Result != null)
			{
				message = MyResource.GetResourceString("SuccessDoneRegister", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				status = ServiceResultStatus.Success;
			}
			else
			{
				message = MyResource.GetResourceString("ErrorNotFound", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				status = ServiceResultStatus.Fail;
			}
			data = apispReturnCompanyPersonId_Result;
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
		return new ServiceResult<ApispReturnCompanyPersonId_Result>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<int> Insert(InsertCompanyPersonViewModel model)
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
			if (model.ApiCompanyId <= 0)
			{
				model.ApiCompanyId = null;
			}
			if (model.ApiPrsTitleId <= 0)
			{
				model.ApiPrsTitleId = null;
			}
			if (model.ApiPrsJobId <= 0)
			{
				model.ApiPrsJobId = null;
			}
			if (model.ApiPrsTypeId <= 0)
			{
				model.ApiPrsTypeId = null;
			}
			if (model.ApiPrsGroupId <= 0)
			{
				model.ApiPrsGroupId = null;
			}
			if (model.ApiPrsSexId <= 0)
			{
				model.ApiPrsSexId = null;
			}
			if (model.ApiPrsEducationId <= 0)
			{
				model.ApiPrsEducationId = null;
			}
			if (model.ApiPrsCountryId <= 0)
			{
				model.ApiPrsCountryId = null;
			}
			if (model.ApiPrsProvinceId <= 0)
			{
				model.ApiPrsProvinceId = null;
			}
			if (model.ApiPrsCityId <= 0)
			{
				model.ApiPrsCityId = null;
			}
			if (model.ApiPrsDepartmentId <= 0)
			{
				model.ApiPrsDepartmentId = null;
			}
			if (model.ApiPrsTelegramId <= 0)
			{
				model.ApiPrsTelegramId = null;
			}
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
			int mobNumLen = Setting.GetMobNumLen();
			bool mobNumLenNoCheck = Setting.GetMobNumLenNoCheck();
			int.TryParse(model.LanguageId.ToString(), out var currLangId);
			if (currLangId <= 0)
			{
				currLangId = result;
			}
			List<ApispSelectLanguages_Result> list = Enumerable.ToList<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)cRMEntities.ApispSelectLanguages());
			string text = "fa-IR";
			ApispSelectLanguages_Result apispSelectLanguages_Result = Enumerable.FirstOrDefault<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result m) => m.LanguageID == currLangId));
			if (apispSelectLanguages_Result != null)
			{
				text = apispSelectLanguages_Result.LanguageCollation;
			}
			string prsBirthDate = null;
			string prsMarriageDate = null;
			try
			{
				if (model.ApiPrsBirthDateTime.HasValue)
				{
					prsBirthDate = (model.ApiPrsBirthDateTime ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
				}
			}
			catch (Exception)
			{
				ServiceResult<int> serviceResult = new ServiceResult<int>();
				serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PrsBirthDate", text, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
				serviceResult.Data = 0;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			try
			{
				if (model.ApiPrsMarriageDateTime.HasValue)
				{
					prsMarriageDate = (model.ApiPrsMarriageDateTime ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
				}
			}
			catch (Exception)
			{
				ServiceResult<int> serviceResult = new ServiceResult<int>();
				serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PrsMarriageDate", text, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
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
				serviceResult.Message = MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = 0;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			if (string.IsNullOrEmpty(model.ApiPrsLName))
			{
				ServiceResult<int> serviceResult = new ServiceResult<int>();
				serviceResult.Message = MyResource.GetResourceString("ErrorPrsLNameNotEntered", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = 0;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			if (model.ApiPrsMobile != null)
			{
				if (model.ApiPrsMobile.Length != mobNumLen && !mobNumLenNoCheck)
				{
					ServiceResult<int> serviceResult = new ServiceResult<int>();
					serviceResult.Message = MyResource.GetResourceString("CheckLenMob", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
					serviceResult.Data = 0;
					serviceResult.Status = ServiceResultStatus.Error;
					return serviceResult;
				}
				if (model.ApiPrsMobile.Length >= 2)
				{
					string text2 = model.ApiPrsMobile.Substring(0, 2);
					if (text2 != "09" && !mobNumLenNoCheck)
					{
						ServiceResult<int> serviceResult = new ServiceResult<int>();
						serviceResult.Message = MyResource.GetResourceString("CheckMobileFormat", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
						serviceResult.Data = 0;
						serviceResult.Status = ServiceResultStatus.Error;
						return serviceResult;
					}
				}
			}
			if (!string.IsNullOrEmpty(model.ApiPrsMobile))
			{
				try
				{
					long.Parse(model.ApiPrsMobile);
				}
				catch
				{
					ServiceResult<int> serviceResult = new ServiceResult<int>();
					serviceResult.Message = string.Format(MyResource.GetResourceString("CheckDigit", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PrsMobile", text, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly));
					serviceResult.Data = 0;
					serviceResult.Status = ServiceResultStatus.Error;
					return serviceResult;
				}
			}
			if (model.ApiPrsPreTel != null && model.ApiPrsPreTel.Length > 1 && model.ApiPrsPreTel.Substring(0, 2) == "09")
			{
				ServiceResult<int> serviceResult = new ServiceResult<int>();
				serviceResult.Message = MyResource.GetResourceString("CheckPreTelForNotMobile", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = 0;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			if (model.ApiPrsTel != null && model.ApiPrsTel.Length > 1 && model.ApiPrsTel.Substring(0, 2) == "09")
			{
				ServiceResult<int> serviceResult = new ServiceResult<int>();
				serviceResult.Message = MyResource.GetResourceString("CheckPreTelForNotMobile", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = 0;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			if (model.ApiPrsTelII != null && model.ApiPrsTelII.Length > 1 && model.ApiPrsTelII.Substring(0, 2) == "09")
			{
				ServiceResult<int> serviceResult = new ServiceResult<int>();
				serviceResult.Message = MyResource.GetResourceString("CheckPreTelForNotMobile", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = 0;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			if (model.ApiPrsMobile != null)
			{
				if (model.ApiPrsMobile.Length != mobNumLen && !mobNumLenNoCheck)
				{
					ServiceResult<int> serviceResult = new ServiceResult<int>();
					serviceResult.Message = MyResource.GetResourceString("CheckLenMob", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
					serviceResult.Data = 0;
					serviceResult.Status = ServiceResultStatus.Error;
					return serviceResult;
				}
				if (model.ApiPrsMobile.Length >= 2)
				{
					string text3 = model.ApiPrsMobile.Substring(0, 2);
					if (text3 != "09" && !mobNumLenNoCheck)
					{
						ServiceResult<int> serviceResult = new ServiceResult<int>();
						serviceResult.Message = MyResource.GetResourceString("CheckMobileFormat", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
						serviceResult.Data = 0;
						serviceResult.Status = ServiceResultStatus.Error;
						return serviceResult;
					}
				}
			}
			if (!string.IsNullOrEmpty(model.ApiPrsMobile))
			{
				try
				{
					long.Parse(model.ApiPrsMobile);
				}
				catch
				{
					ServiceResult<int> serviceResult = new ServiceResult<int>();
					serviceResult.Message = string.Format(MyResource.GetResourceString("CheckDigit", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PrsMobile", text, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly));
					serviceResult.Data = 0;
					serviceResult.Status = ServiceResultStatus.Error;
					return serviceResult;
				}
			}
			if (!string.IsNullOrEmpty(model.ApiPrsTel))
			{
				try
				{
					long.Parse(model.ApiPrsTel);
				}
				catch
				{
					ServiceResult<int> serviceResult = new ServiceResult<int>();
					serviceResult.Message = string.Format(MyResource.GetResourceString("CheckDigit", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PrsTel", text, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly));
					serviceResult.Data = 0;
					serviceResult.Status = ServiceResultStatus.Error;
					return serviceResult;
				}
			}
			if (!string.IsNullOrEmpty(model.ApiPrsPreTel))
			{
				try
				{
					long.Parse(model.ApiPrsPreTel);
				}
				catch
				{
					ServiceResult<int> serviceResult = new ServiceResult<int>();
					serviceResult.Message = string.Format(MyResource.GetResourceString("CheckDigit", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PrsPreTel", text, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly));
					serviceResult.Data = 0;
					serviceResult.Status = ServiceResultStatus.Error;
					return serviceResult;
				}
			}
			if (!string.IsNullOrEmpty(model.ApiPrsTelUpTo))
			{
				try
				{
					long.Parse(model.ApiPrsTelUpTo);
				}
				catch
				{
					ServiceResult<int> serviceResult = new ServiceResult<int>();
					serviceResult.Message = string.Format(MyResource.GetResourceString("CheckDigit", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PrsTelUpTo", text, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly));
					serviceResult.Data = 0;
					serviceResult.Status = ServiceResultStatus.Error;
					return serviceResult;
				}
			}
			if (!string.IsNullOrEmpty(model.ApiPrsTelII))
			{
				try
				{
					long.Parse(model.ApiPrsTelII);
				}
				catch
				{
					ServiceResult<int> serviceResult = new ServiceResult<int>();
					serviceResult.Message = string.Format(MyResource.GetResourceString("CheckDigit", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PrsTelII", text, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly));
					serviceResult.Data = 0;
					serviceResult.Status = ServiceResultStatus.Error;
					return serviceResult;
				}
			}
			if (!string.IsNullOrEmpty(model.ApiPrsFax))
			{
				try
				{
					long.Parse(model.ApiPrsFax);
				}
				catch
				{
					ServiceResult<int> serviceResult = new ServiceResult<int>();
					serviceResult.Message = string.Format(MyResource.GetResourceString("CheckDigit", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PrsFax", text, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly));
					serviceResult.Data = 0;
					serviceResult.Status = ServiceResultStatus.Error;
					return serviceResult;
				}
			}
			if (model.ApiPrsPreTel != null && model.ApiPrsPreTel.Length > 1 && model.ApiPrsPreTel.Substring(0, 2) == "09")
			{
				ServiceResult<int> serviceResult = new ServiceResult<int>();
				serviceResult.Message = MyResource.GetResourceString("CheckPreTelForNotMobile", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = 0;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			if (model.ApiPrsTel != null && model.ApiPrsTel.Length > 1 && model.ApiPrsTel.Substring(0, 2) == "09")
			{
				ServiceResult<int> serviceResult = new ServiceResult<int>();
				serviceResult.Message = MyResource.GetResourceString("CheckPreTelForNotMobile", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = 0;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			if (model.ApiPrsTelII != null && model.ApiPrsTelII.Length > 1 && model.ApiPrsTelII.Substring(0, 2) == "09")
			{
				ServiceResult<int> serviceResult = new ServiceResult<int>();
				serviceResult.Message = MyResource.GetResourceString("CheckPreTelForNotMobile", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = 0;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			bool flag4 = false;
			bool flag5 = false;
			ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result2 = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
			if (apispSelectCrmsysSetting_Result2 != null)
			{
				flag = ((apispSelectCrmsysSetting_Result2.CantSaveDupTel.HasValue && apispSelectCrmsysSetting_Result2.CantSaveDupTel != false) ? true : false);
				flag2 = ((apispSelectCrmsysSetting_Result2.CantSaveDupFax.HasValue && apispSelectCrmsysSetting_Result2.CantSaveDupFax != false) ? true : false);
				flag3 = ((apispSelectCrmsysSetting_Result2.CantSaveDupZipCode.HasValue && apispSelectCrmsysSetting_Result2.CantSaveDupZipCode != false) ? true : false);
				flag4 = ((apispSelectCrmsysSetting_Result2.CantSaveDupPrsNationalCode.HasValue && apispSelectCrmsysSetting_Result2.CantSaveDupPrsNationalCode != false) ? true : false);
				flag5 = ((apispSelectCrmsysSetting_Result2.MustFullPrsNationalCode.HasValue && apispSelectCrmsysSetting_Result2.MustFullPrsNationalCode != false) ? true : false);
			}
			if (!string.IsNullOrEmpty(model.ApiPrsTel) && flag && model.PrsTelNotDup.HasValue && model.PrsTelNotDup.GetValueOrDefault())
			{
				string text4 = Company.CantSaveDupTel(model.ApiPrsTel, 2, 0, result, currLangId, text);
				if (!string.IsNullOrEmpty(text4))
				{
					return new ServiceResult<int>
					{
						Message = text4,
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
			}
			if (!string.IsNullOrEmpty(model.ApiPrsTelII) && flag && model.PrsTelNotDup.HasValue && model.PrsTelNotDup.GetValueOrDefault())
			{
				string text5 = Company.CantSaveDupTel(model.ApiPrsTelII, 2, 0, result, currLangId, text);
				if (!string.IsNullOrEmpty(text5))
				{
					return new ServiceResult<int>
					{
						Message = text5,
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
			}
			if (!string.IsNullOrEmpty(model.ApiPrsFax) && flag2 && model.PrsFaxNotDup.HasValue && model.PrsFaxNotDup.GetValueOrDefault())
			{
				string text6 = Company.CantSaveDupFax(model.ApiPrsFax, 2, 0, result, currLangId, text);
				if (!string.IsNullOrEmpty(text6))
				{
					return new ServiceResult<int>
					{
						Message = text6,
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
			}
			if (!string.IsNullOrEmpty(model.ApiPrsZipCode) && flag3)
			{
				string text7 = Company.CantSaveDupZipCode(model.ApiPrsZipCode, 2, 0, result, currLangId, text);
				if (!string.IsNullOrEmpty(text7))
				{
					return new ServiceResult<int>
					{
						Message = text7,
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
			}
			if (!string.IsNullOrEmpty(model.ApiPrsNationalCode) && flag4)
			{
				string text8 = Company.CantSaveDupPrsNationalCode(model.ApiPrsNationalCode, 0, result, currLangId, text);
				if (!string.IsNullOrEmpty(text8))
				{
					return new ServiceResult<int>
					{
						Message = text8,
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
			}
			if (string.IsNullOrEmpty(model.ApiPrsNationalCode) && flag5)
			{
				ServiceResult<int> serviceResult = new ServiceResult<int>();
				serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorIsNotEntered", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PrsNationalCode", text, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly));
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
			CommonClass commonClass = new CommonClass();
			string text9 = commonClass.ConvertNameToDayNum(now.DayOfWeek.ToString());
			string text10 = now.ToString("HH:mm:ss");
			string person = Labels.Person;
			ObjectParameter objectParameter = new ObjectParameter("InsertedPersonId", 0);
			ObjectParameter objectParameter2 = new ObjectParameter("ErrorMessage", "");
			int? num3 = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.ApispInsertCompanyPersons(model.ApiCompanyId, model.ApiCmpNumber, model.ApiCmpCode, model.ApiPrsLName, model.ApiPrsFName, model.ApiPrsTitleId, model.ApiPrsJobId, model.ApiPrsTypeId, model.ApiPrsGroupId, model.ApiPrsSexId, model.ApiPrsEducationId, model.ApiPrsPreTel, model.ApiPrsTel, model.ApiPrsTelUpTo, model.ApiPrsTelDesc, model.ApiPrsTelII, model.ApiPrsFax, model.ApiPrsFaxDesc, model.ApiPrsMobile, model.ApiPrsWebSite, model.ApiPrsEmail, model.ApiPrsEmailII, model.ApiPrsCountryId, model.ApiPrsProvinceId, model.ApiPrsCityId, model.ApiPrsAddress, model.ApiPrsAddressDesc, model.ApiPrsZipCode, model.ApiPrsPostBox, model.ApiPrsNationalCode, model.ApiPrsIdentityNumber, model.ApiPrsFatherName, prsBirthDate, model.ApiPrsBirthDateTime, model.ApiPrsBirthPlace, model.ApiPrsIsMarried, prsMarriageDate, model.ApiPrsMarriageDateTime, model.ApiPrsEducationField, model.ApiPrsSkill, model.ApiPrsStudyField, model.ApiPrsInteresting, model.ApiPrsSpecialPoint, model.ApiPrsDescription, model.ApiPrsDepartmentId, model.ApiPrsStopSendSms, model.ApiPrsOrderView, model.ApiPrsWorkingOut, model.ApiPrsTelegramId, userId, value2, value, registerDatePersian, appType, objectParameter, objectParameter2));
			string resourceString = MyResource.GetResourceString("ErrorDoneOperationTryAgain", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
			string resourceString2 = MyResource.GetResourceString("ErrorTryAgain", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
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
			if (objectParameter2.Value != null && objectParameter2.Value.ToString() != "")
			{
				string text11 = "";
				string text12 = objectParameter2.Value.ToString();
				if (text12.IndexOf("IsUser=0", StringComparison.Ordinal) >= 0)
				{
					text11 = text11 + MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "<br>";
					resourceString2 = "<br>" + MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + resourceString2;
					return new ServiceResult<int>
					{
						Message = resourceString2.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text12.IndexOf("DupMob=", StringComparison.Ordinal) >= 0)
				{
					string[] array = text12.Split(new char[1] { '|' });
					string arg = "";
					if (array != null)
					{
						string[] array2 = array;
						foreach (string text13 in array2)
						{
							if (!string.IsNullOrEmpty(text13) && text13.IndexOf("DupMob=", StringComparison.Ordinal) >= 0)
							{
								string[] array3 = text13.Split(new char[1] { '=' });
								if (array3 != null && array3.Length == 2)
								{
									arg = ((array3[1] != null && array3[1] != "") ? array3[1] : "");
								}
							}
						}
					}
					text11 = text11 + string.Format(MyResource.GetResourceString("ErrorCheckPrsMobileDuplicate", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), model.ApiPrsMobile, arg) + "<br>";
					resourceString2 = "<br>" + MyResource.GetResourceString("ErrorMobileAlreadyRegistered", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + resourceString2;
					return new ServiceResult<int>
					{
						Message = resourceString2.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text12.IndexOf("DupEmailI=", StringComparison.Ordinal) >= 0)
				{
					string[] array4 = text12.Split(new char[1] { '|' });
					string arg2 = "";
					if (array4 != null)
					{
						string[] array5 = array4;
						foreach (string text14 in array5)
						{
							if (!string.IsNullOrEmpty(text14) && text14.IndexOf("DupEmailI=", StringComparison.Ordinal) >= 0)
							{
								string[] array6 = text14.Split(new char[1] { '=' });
								if (array6 != null && array6.Length == 2)
								{
									arg2 = ((array6[1] != null && array6[1] != "") ? array6[1] : "");
								}
							}
						}
					}
					text11 = text11 + string.Format(MyResource.GetResourceString("ErrorCheckPrsEmailDuplicate", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), model.ApiPrsEmail, arg2) + "<br>";
					resourceString2 = "<br>" + MyResource.GetResourceString("ErrorEmailAlreadyRegistered", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + resourceString2;
					return new ServiceResult<int>
					{
						Message = resourceString2.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text12.IndexOf("DupEmailII=", StringComparison.Ordinal) >= 0)
				{
					string[] array7 = text12.Split(new char[1] { '|' });
					string arg3 = "";
					if (array7 != null)
					{
						string[] array8 = array7;
						foreach (string text15 in array8)
						{
							if (!string.IsNullOrEmpty(text15) && text15.IndexOf("DupEmailII=", StringComparison.Ordinal) >= 0)
							{
								string[] array9 = text15.Split(new char[1] { '=' });
								if (array9 != null && array9.Length == 2)
								{
									arg3 = ((array9[1] != null && array9[1] != "") ? array9[1] : "");
								}
							}
						}
					}
					text11 = text11 + string.Format(MyResource.GetResourceString("ErrorCheckPrsEmailDuplicate", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), model.ApiPrsEmail, arg3) + "<br>";
					resourceString2 = "<br>" + MyResource.GetResourceString("ErrorEmailIIAlreadyRegistered", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + resourceString2;
					return new ServiceResult<int>
					{
						Message = resourceString2.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text12.IndexOf("No CmpId|", StringComparison.Ordinal) >= 0)
				{
					text11 = text11 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("Company", text, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text11.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text12.IndexOf("No PrsTitleId|", StringComparison.Ordinal) >= 0)
				{
					text11 = text11 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PrsTitle", text, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text11.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text12.IndexOf("No PrsJobId|", StringComparison.Ordinal) >= 0)
				{
					text11 = text11 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PrsJob", text, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text11.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text12.IndexOf("No PrsTypeId|", StringComparison.Ordinal) >= 0)
				{
					text11 = text11 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PrsType", text, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text11.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text12.IndexOf("No PrsGroupId|", StringComparison.Ordinal) >= 0)
				{
					text11 = text11 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PrsGroup", text, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text11.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text12.IndexOf("No PrsSexId|", StringComparison.Ordinal) >= 0)
				{
					text11 = text11 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PrsSex", text, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text11.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text12.IndexOf("No PrsEducationId|", StringComparison.Ordinal) >= 0)
				{
					text11 = text11 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PrsEducation", text, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text11.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text12.IndexOf("No PrsCountryId|", StringComparison.Ordinal) >= 0)
				{
					text11 = text11 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PrsCountry", text, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text11.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text12.IndexOf("No PrsProvinceId|", StringComparison.Ordinal) >= 0)
				{
					text11 = text11 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PrsProvince", text, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text11.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text12.IndexOf("No PrsCityId|", StringComparison.Ordinal) >= 0)
				{
					text11 = text11 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PrsCity", text, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text11.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text12.IndexOf("No PrsDepartmentId|", StringComparison.Ordinal) >= 0)
				{
					text11 = text11 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PrsDepartment", text, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text11.Replace("<br>", "\r\n"),
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
					serviceResult.Message = (MyResource.GetResourceString("ErrorDoneOperation", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "<br>" + resourceString).Replace("<br>", "\r\n");
					serviceResult.Data = 0;
					serviceResult.Status = ServiceResultStatus.Fail;
					return serviceResult;
				}
				FullRegisterResultViewModel fullRegisterResultViewModel = new FullRegisterResultViewModel();
				data = ((objectParameter.Value != null) ? int.Parse(objectParameter.Value.ToString() ?? "0") : 0);
				message = MyResource.GetResourceString("SuccessDoneRegister", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				status = ServiceResultStatus.Success;
			}
		}
		catch (Exception ex3)
		{
			string text16 = ((!string.IsNullOrEmpty(ex3.Message)) ? ex3.Message : "");
			if (ex3.InnerException != null && !string.IsNullOrEmpty(ex3.InnerException.Message))
			{
				text16 = text16 + " - " + ex3.InnerException.Message;
			}
			message = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text16)) ? (" (" + text16 + ")") : "");
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
	public ServiceResult<int> Update(UpdateCompanyPersonViewModel model)
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
			int mobNumLen = Setting.GetMobNumLen();
			bool mobNumLenNoCheck = Setting.GetMobNumLenNoCheck();
			int.TryParse(model.LanguageId.ToString(), out var currLangId);
			if (currLangId <= 0)
			{
				currLangId = result;
			}
			List<ApispSelectLanguages_Result> list = Enumerable.ToList<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)cRMEntities.ApispSelectLanguages());
			string text = "fa-IR";
			ApispSelectLanguages_Result apispSelectLanguages_Result = Enumerable.FirstOrDefault<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result m) => m.LanguageID == currLangId));
			if (apispSelectLanguages_Result != null)
			{
				text = apispSelectLanguages_Result.LanguageCollation;
			}
			string text2 = null;
			string text3 = null;
			if (!string.IsNullOrEmpty(model.ApiPrsBirthDate) && model.ApiPrsBirthDate.ToLower() == "null")
			{
				text2 = model.ApiPrsBirthDate;
				model.ApiPrsBirthDateTime = null;
			}
			else
			{
				try
				{
					if (model.ApiPrsBirthDateTime.HasValue)
					{
						text2 = (model.ApiPrsBirthDateTime ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
					}
				}
				catch (Exception)
				{
					ServiceResult<int> serviceResult = new ServiceResult<int>();
					serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PrsBirthDate", text, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
					serviceResult.Data = 0;
					serviceResult.Status = ServiceResultStatus.Error;
					return serviceResult;
				}
			}
			if (!string.IsNullOrEmpty(model.ApiPrsMarriageDate) && model.ApiPrsMarriageDate.ToLower() == "null")
			{
				text3 = model.ApiPrsMarriageDate;
				model.ApiPrsMarriageDateTime = null;
			}
			else
			{
				try
				{
					if (model.ApiPrsMarriageDateTime.HasValue)
					{
						text3 = (model.ApiPrsMarriageDateTime ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
					}
				}
				catch (Exception)
				{
					ServiceResult<int> serviceResult = new ServiceResult<int>();
					serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PrsMarriageDate", text, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
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
				ServiceResult<int> serviceResult = new ServiceResult<int>();
				serviceResult.Message = MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = 0;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			if (model.ApiCompanyPersonId <= 0 || model.ApiCompanyId <= 0)
			{
				ServiceResult<int> serviceResult = new ServiceResult<int>();
				serviceResult.Message = MyResource.GetResourceString("ErrorNotFound", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = 0;
				serviceResult.Status = ServiceResultStatus.Fail;
				return serviceResult;
			}
			if (model.ApiPrsMobile != null)
			{
				if (model.ApiPrsMobile.Length != mobNumLen && !mobNumLenNoCheck)
				{
					ServiceResult<int> serviceResult = new ServiceResult<int>();
					serviceResult.Message = MyResource.GetResourceString("CheckLenMob", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
					serviceResult.Data = 0;
					serviceResult.Status = ServiceResultStatus.Error;
					return serviceResult;
				}
				if (model.ApiPrsMobile.Length >= 2)
				{
					string text4 = model.ApiPrsMobile.Substring(0, 2);
					if (text4 != "09" && !mobNumLenNoCheck)
					{
						ServiceResult<int> serviceResult = new ServiceResult<int>();
						serviceResult.Message = MyResource.GetResourceString("CheckMobileFormat", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
						serviceResult.Data = 0;
						serviceResult.Status = ServiceResultStatus.Error;
						return serviceResult;
					}
				}
			}
			if (!string.IsNullOrEmpty(model.ApiPrsMobile))
			{
				try
				{
					long.Parse(model.ApiPrsMobile);
				}
				catch
				{
					ServiceResult<int> serviceResult = new ServiceResult<int>();
					serviceResult.Message = string.Format(MyResource.GetResourceString("CheckDigit", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PrsMobile", text, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly));
					serviceResult.Data = 0;
					serviceResult.Status = ServiceResultStatus.Error;
					return serviceResult;
				}
			}
			if (!string.IsNullOrEmpty(model.ApiPrsTel))
			{
				try
				{
					long.Parse(model.ApiPrsTel);
				}
				catch
				{
					ServiceResult<int> serviceResult = new ServiceResult<int>();
					serviceResult.Message = string.Format(MyResource.GetResourceString("CheckDigit", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PrsTel", text, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly));
					serviceResult.Data = 0;
					serviceResult.Status = ServiceResultStatus.Error;
					return serviceResult;
				}
			}
			if (!string.IsNullOrEmpty(model.ApiPrsPreTel))
			{
				try
				{
					long.Parse(model.ApiPrsPreTel);
				}
				catch
				{
					ServiceResult<int> serviceResult = new ServiceResult<int>();
					serviceResult.Message = string.Format(MyResource.GetResourceString("CheckDigit", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PrsPreTel", text, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly));
					serviceResult.Data = 0;
					serviceResult.Status = ServiceResultStatus.Error;
					return serviceResult;
				}
			}
			if (!string.IsNullOrEmpty(model.ApiPrsTelUpTo))
			{
				try
				{
					long.Parse(model.ApiPrsTelUpTo);
				}
				catch
				{
					ServiceResult<int> serviceResult = new ServiceResult<int>();
					serviceResult.Message = string.Format(MyResource.GetResourceString("CheckDigit", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PrsTelUpTo", text, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly));
					serviceResult.Data = 0;
					serviceResult.Status = ServiceResultStatus.Error;
					return serviceResult;
				}
			}
			if (!string.IsNullOrEmpty(model.ApiPrsTelII))
			{
				try
				{
					long.Parse(model.ApiPrsTelII);
				}
				catch
				{
					ServiceResult<int> serviceResult = new ServiceResult<int>();
					serviceResult.Message = string.Format(MyResource.GetResourceString("CheckDigit", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PrsTelII", text, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly));
					serviceResult.Data = 0;
					serviceResult.Status = ServiceResultStatus.Error;
					return serviceResult;
				}
			}
			if (!string.IsNullOrEmpty(model.ApiPrsFax))
			{
				try
				{
					long.Parse(model.ApiPrsFax);
				}
				catch
				{
					ServiceResult<int> serviceResult = new ServiceResult<int>();
					serviceResult.Message = string.Format(MyResource.GetResourceString("CheckDigit", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PrsFax", text, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly));
					serviceResult.Data = 0;
					serviceResult.Status = ServiceResultStatus.Error;
					return serviceResult;
				}
			}
			if (model.ApiPrsPreTel != null && model.ApiPrsPreTel.Length > 1 && model.ApiPrsPreTel.Substring(0, 2) == "09")
			{
				ServiceResult<int> serviceResult = new ServiceResult<int>();
				serviceResult.Message = MyResource.GetResourceString("CheckPreTelForNotMobile", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = 0;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			if (model.ApiPrsTel != null && model.ApiPrsTel.Length > 1 && model.ApiPrsTel.Substring(0, 2) == "09")
			{
				ServiceResult<int> serviceResult = new ServiceResult<int>();
				serviceResult.Message = MyResource.GetResourceString("CheckPreTelForNotMobile", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = 0;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			if (model.ApiPrsTelII != null && model.ApiPrsTelII.Length > 1 && model.ApiPrsTelII.Substring(0, 2) == "09")
			{
				ServiceResult<int> serviceResult = new ServiceResult<int>();
				serviceResult.Message = MyResource.GetResourceString("CheckPreTelForNotMobile", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = 0;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			bool flag4 = false;
			bool flag5 = false;
			ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result2 = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
			if (apispSelectCrmsysSetting_Result2 != null)
			{
				flag = ((apispSelectCrmsysSetting_Result2.CantSaveDupTel.HasValue && apispSelectCrmsysSetting_Result2.CantSaveDupTel != false) ? true : false);
				flag2 = ((apispSelectCrmsysSetting_Result2.CantSaveDupFax.HasValue && apispSelectCrmsysSetting_Result2.CantSaveDupFax != false) ? true : false);
				flag3 = ((apispSelectCrmsysSetting_Result2.CantSaveDupZipCode.HasValue && apispSelectCrmsysSetting_Result2.CantSaveDupZipCode != false) ? true : false);
				flag4 = ((apispSelectCrmsysSetting_Result2.CantSaveDupPrsNationalCode.HasValue && apispSelectCrmsysSetting_Result2.CantSaveDupPrsNationalCode != false) ? true : false);
				flag5 = ((apispSelectCrmsysSetting_Result2.MustFullPrsNationalCode.HasValue && apispSelectCrmsysSetting_Result2.MustFullPrsNationalCode != false) ? true : false);
			}
			if (!string.IsNullOrEmpty(model.ApiPrsTel) && flag && model.PrsTelNotDup.HasValue && model.PrsTelNotDup.GetValueOrDefault())
			{
				string text5 = Company.CantSaveDupTel(model.ApiPrsTel, 2, model.ApiCompanyPersonId, result, currLangId, text);
				if (!string.IsNullOrEmpty(text5))
				{
					return new ServiceResult<int>
					{
						Message = text5,
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
			}
			if (!string.IsNullOrEmpty(model.ApiPrsTelII) && flag && model.PrsTelNotDup.HasValue && model.PrsTelNotDup.GetValueOrDefault())
			{
				string text6 = Company.CantSaveDupTel(model.ApiPrsTelII, 2, model.ApiCompanyPersonId, result, currLangId, text);
				if (!string.IsNullOrEmpty(text6))
				{
					return new ServiceResult<int>
					{
						Message = text6,
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
			}
			if (!string.IsNullOrEmpty(model.ApiPrsFax) && flag2 && model.PrsFaxNotDup.HasValue && model.PrsFaxNotDup.GetValueOrDefault())
			{
				string text7 = Company.CantSaveDupFax(model.ApiPrsFax, 2, model.ApiCompanyPersonId, result, currLangId, text);
				if (!string.IsNullOrEmpty(text7))
				{
					return new ServiceResult<int>
					{
						Message = text7,
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
			}
			if (!string.IsNullOrEmpty(model.ApiPrsZipCode) && flag3)
			{
				string text8 = Company.CantSaveDupZipCode(model.ApiPrsZipCode, 2, model.ApiCompanyPersonId, result, currLangId, text);
				if (!string.IsNullOrEmpty(text8))
				{
					return new ServiceResult<int>
					{
						Message = text8,
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
			}
			if (!string.IsNullOrEmpty(model.ApiPrsNationalCode) && flag4)
			{
				string text9 = Company.CantSaveDupPrsNationalCode(model.ApiPrsNationalCode, model.ApiCompanyPersonId, result, currLangId, text);
				if (!string.IsNullOrEmpty(text9))
				{
					return new ServiceResult<int>
					{
						Message = text9,
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
			}
			if (string.IsNullOrEmpty(model.ApiPrsNationalCode) && flag5)
			{
				ServiceResult<int> serviceResult = new ServiceResult<int>();
				serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorIsNotEntered", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PrsNationalCode", text, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly));
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
			CommonClass commonClass = new CommonClass();
			string text10 = commonClass.ConvertNameToDayNum(now.DayOfWeek.ToString());
			string text11 = now.ToString("HH:mm:ss");
			string resourceString = MyResource.GetResourceString("Person", text, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
			ObjectParameter objectParameter = new ObjectParameter("ErrorMessage", "");
			int num3 = cRMEntities.ApispUpdateCompanyPerson(model.ApiCompanyPersonId, model.ApiCompanyId, model.ApiPrsLName, model.ApiPrsFName, model.ApiPrsTitleId, model.ApiPrsJobId, model.ApiPrsTypeId, model.ApiPrsGroupId, model.ApiPrsSexId, model.ApiPrsEducationId, model.ApiPrsPreTel, model.ApiPrsTel, model.ApiPrsTelUpTo, model.ApiPrsTelDesc, model.ApiPrsTelII, model.ApiPrsFax, model.ApiPrsFaxDesc, model.ApiPrsMobile, model.ApiPrsWebSite, model.ApiPrsEmail, model.ApiPrsEmailII, model.ApiPrsCountryId, model.ApiPrsProvinceId, model.ApiPrsCityId, model.ApiPrsAddress, model.ApiPrsAddressDesc, model.ApiPrsZipCode, model.ApiPrsPostBox, model.ApiPrsNationalCode, model.ApiPrsIdentityNumber, model.ApiPrsFatherName, text2, prsBirthDateTime: model.ApiPrsBirthDateTime, prsBirthPlace: model.ApiPrsBirthPlace, prsIsMarried: model.ApiPrsIsMarried, prsMarriageDate: text3, prsMarriageDateTime: model.ApiPrsMarriageDateTime, prsEducationField: model.ApiPrsEducationField, prsSkill: model.ApiPrsSkill, prsStudyField: model.ApiPrsStudyField, prsInteresting: model.ApiPrsInteresting, prsSpecialPoint: model.ApiPrsSpecialPoint, prsDescription: model.ApiPrsDescription, addType: null, prsDepartmentId: model.ApiPrsDepartmentId, prsStopSendSms: model.ApiPrsStopSendSms, prsOrderView: model.ApiPrsOrderView, prsWorkingOut: model.ApiPrsWorkingOut, companyPersonTemplateID: null, prsTelegramId: model.ApiPrsTelegramId, userId: userId, year1: (short)1, month1: value2, registerDate: value, registerDatePersian: registerDatePersian, appType: appType, languageID: currLangId, defaultLanguageID: result, errorMessage: objectParameter);
			string resourceString2 = MyResource.GetResourceString("ErrorDoneOperationTryAgain", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
			string resourceString3 = MyResource.GetResourceString("ErrorTryAgain", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
			int result3 = 0;
			int.TryParse(num3.ToString(), out result3);
			if (result3 < 0 && objectParameter.Value == null)
			{
				return new ServiceResult<int>
				{
					Message = resourceString2.Replace("<br>", "\r\n"),
					Data = 0,
					Status = ServiceResultStatus.Error
				};
			}
			if (objectParameter.Value != null && objectParameter.Value.ToString() != "")
			{
				string text12 = "";
				string text13 = objectParameter.Value.ToString();
				if (text13.IndexOf("IsUser=0", StringComparison.Ordinal) >= 0)
				{
					text12 = text12 + MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "<br>";
					resourceString3 = "<br>" + MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + resourceString3;
					return new ServiceResult<int>
					{
						Message = resourceString3.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text13.IndexOf("DupMob=", StringComparison.Ordinal) >= 0)
				{
					string[] array = text13.Split(new char[1] { '|' });
					string arg = "";
					if (array != null)
					{
						string[] array2 = array;
						foreach (string text14 in array2)
						{
							if (!string.IsNullOrEmpty(text14) && text14.IndexOf("DupMob=", StringComparison.Ordinal) >= 0)
							{
								string[] array3 = text14.Split(new char[1] { '=' });
								if (array3 != null && array3.Length == 2)
								{
									arg = ((array3[1] != null && array3[1] != "") ? array3[1] : "");
								}
							}
						}
					}
					text12 = text12 + string.Format(MyResource.GetResourceString("ErrorCheckPrsMobileDuplicate", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), model.ApiPrsMobile, arg) + "<br>";
					resourceString3 = "<br>" + MyResource.GetResourceString("ErrorMobileAlreadyRegistered", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + resourceString3;
					return new ServiceResult<int>
					{
						Message = resourceString3.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text13.IndexOf("DupEmailI=", StringComparison.Ordinal) >= 0)
				{
					string[] array4 = text13.Split(new char[1] { '|' });
					string arg2 = "";
					if (array4 != null)
					{
						string[] array5 = array4;
						foreach (string text15 in array5)
						{
							if (!string.IsNullOrEmpty(text15) && text15.IndexOf("DupEmailI=", StringComparison.Ordinal) >= 0)
							{
								string[] array6 = text15.Split(new char[1] { '=' });
								if (array6 != null && array6.Length == 2)
								{
									arg2 = ((array6[1] != null && array6[1] != "") ? array6[1] : "");
								}
							}
						}
					}
					text12 = text12 + string.Format(MyResource.GetResourceString("ErrorCheckPrsEmailDuplicate", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), model.ApiPrsEmail, arg2) + "<br>";
					resourceString3 = "<br>" + MyResource.GetResourceString("ErrorEmailAlreadyRegistered", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + resourceString3;
					return new ServiceResult<int>
					{
						Message = resourceString3.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text13.IndexOf("DupEmailII=", StringComparison.Ordinal) >= 0)
				{
					string[] array7 = text13.Split(new char[1] { '|' });
					string arg3 = "";
					if (array7 != null)
					{
						string[] array8 = array7;
						foreach (string text16 in array8)
						{
							if (!string.IsNullOrEmpty(text16) && text16.IndexOf("DupEmailII=", StringComparison.Ordinal) >= 0)
							{
								string[] array9 = text16.Split(new char[1] { '=' });
								if (array9 != null && array9.Length == 2)
								{
									arg3 = ((array9[1] != null && array9[1] != "") ? array9[1] : "");
								}
							}
						}
					}
					text12 = text12 + string.Format(MyResource.GetResourceString("ErrorCheckPrsEmailDuplicate", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), model.ApiPrsEmail, arg3) + "<br>";
					resourceString3 = "<br>" + MyResource.GetResourceString("ErrorEmailIIAlreadyRegistered", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + resourceString3;
					return new ServiceResult<int>
					{
						Message = resourceString3.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text13.IndexOf("No CmpId|", StringComparison.Ordinal) >= 0)
				{
					text12 = text12 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("Company", text, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString3;
					return new ServiceResult<int>
					{
						Message = text12.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text13.IndexOf("No PrsTitleId|", StringComparison.Ordinal) >= 0)
				{
					text12 = text12 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PrsTitle", text, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString3;
					return new ServiceResult<int>
					{
						Message = text12.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text13.IndexOf("No PrsJobId|", StringComparison.Ordinal) >= 0)
				{
					text12 = text12 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PrsJob", text, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString3;
					return new ServiceResult<int>
					{
						Message = text12.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text13.IndexOf("No PrsTypeId|", StringComparison.Ordinal) >= 0)
				{
					text12 = text12 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PrsType", text, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString3;
					return new ServiceResult<int>
					{
						Message = text12.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text13.IndexOf("No PrsGroupId|", StringComparison.Ordinal) >= 0)
				{
					text12 = text12 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PrsGroup", text, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString3;
					return new ServiceResult<int>
					{
						Message = text12.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text13.IndexOf("No PrsSexId|", StringComparison.Ordinal) >= 0)
				{
					text12 = text12 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PrsSex", text, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString3;
					return new ServiceResult<int>
					{
						Message = text12.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text13.IndexOf("No PrsEducationId|", StringComparison.Ordinal) >= 0)
				{
					text12 = text12 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PrsEducation", text, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString3;
					return new ServiceResult<int>
					{
						Message = text12.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text13.IndexOf("No PrsCountryId|", StringComparison.Ordinal) >= 0)
				{
					text12 = text12 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PrsCountry", text, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString3;
					return new ServiceResult<int>
					{
						Message = text12.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text13.IndexOf("No PrsProvinceId|", StringComparison.Ordinal) >= 0)
				{
					text12 = text12 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PrsProvince", text, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString3;
					return new ServiceResult<int>
					{
						Message = text12.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text13.IndexOf("No PrsCityId|", StringComparison.Ordinal) >= 0)
				{
					text12 = text12 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PrsCity", text, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString3;
					return new ServiceResult<int>
					{
						Message = text12.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text13.IndexOf("No PrsDepartmentId|", StringComparison.Ordinal) >= 0)
				{
					text12 = text12 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PrsDepartment", text, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString3;
					return new ServiceResult<int>
					{
						Message = text12.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
			}
			else
			{
				FullRegisterResultViewModel fullRegisterResultViewModel = new FullRegisterResultViewModel();
				data = 1;
				message = MyResource.GetResourceString("SuccessDoneRegister", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				status = ServiceResultStatus.Success;
			}
		}
		catch (Exception ex3)
		{
			string text17 = ((!string.IsNullOrEmpty(ex3.Message)) ? ex3.Message : "");
			if (ex3.InnerException != null && !string.IsNullOrEmpty(ex3.InnerException.Message))
			{
				text17 = text17 + " - " + ex3.InnerException.Message;
			}
			message = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text17)) ? (" (" + text17 + ")") : "");
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
	public ServiceResult<List<ApispSelectCompanyPersons_Result>> Select(SelectCompanyPersonViewModel model)
	{
		CRMEntities cRMEntities = null;
		List<ApispSelectCompanyPersons_Result> data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				return new ServiceResult<List<ApispSelectCompanyPersons_Result>>
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
				return new ServiceResult<List<ApispSelectCompanyPersons_Result>>
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
				ServiceResult<List<ApispSelectCompanyPersons_Result>> serviceResult = new ServiceResult<List<ApispSelectCompanyPersons_Result>>();
				serviceResult.Message = MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			model.PageSize = ((model.PageNumber.HasValue && model.PageNumber > 0 && (!model.PageSize.HasValue || model.PageSize == 0)) ? new int?(20) : model.PageSize);
			List<ApispSelectCompanyPersons_Result> list2 = Enumerable.ToList<ApispSelectCompanyPersons_Result>((IEnumerable<ApispSelectCompanyPersons_Result>)cRMEntities.ApispSelectCompanyPersons(companyId: model.ApiCompanyId, companyPersonID: model.ApiCompanyPersonId, languageID: currLangId, defaultLanguageID: result, pageNumber: model.PageNumber, pageSize: model.PageSize));
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
		return new ServiceResult<List<ApispSelectCompanyPersons_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<bool> Delete(DeleteCompanyPersonViewModel model)
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
			if (model.ApiCompanyPersonId > 0)
			{
				mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)cRMEntities.ApispDeleteCompanyPerson(model.ApiCompanyPersonId));
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
