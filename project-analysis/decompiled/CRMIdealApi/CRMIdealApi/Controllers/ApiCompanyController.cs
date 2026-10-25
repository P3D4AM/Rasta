using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Data.Objects;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Script.Serialization;
using CRM.General.Calendar;
using CRM.General.Security;
using CRM.General.Utilities;
using CRMIdealApi.ApiModels;
using CRMIdealApi.Classes;
using CRMIdealApi.Classes.Helper;
using CRMIdealApi.DataType;
using CRMIdealApi.Resources;
using Elmah;
using GSD.Globalization;
using Newtonsoft.Json;

namespace CRMIdealApi.Controllers;

public class ApiCompanyController : ApiController
{
	[HttpPost]
	public ServiceResult<FullRegisterResultViewModel> FullRegister(FullRegisterViewModel model)
	{
		CRMEntities cRMEntities = null;
		FullRegisterResultViewModel data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			cRMEntities = new CRMEntities();
			if (!VersionBuyer.CRMApi && !VersionBuyer.CrmApiFRL)
			{
				return new ServiceResult<FullRegisterResultViewModel>
				{
					Message = Messages.ErrorAccessAPILimited,
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
			if (apispSelectCrmsysSetting_Result == null)
			{
				return new ServiceResult<FullRegisterResultViewModel>
				{
					Message = Messages.ErrorInReadingSysSetting,
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			int.TryParse(apispSelectCrmsysSetting_Result.DefaultLanguageID.ToString(), out var defLangId);
			if (defLangId <= 0)
			{
				defLangId = 1065;
			}
			List<ApispSelectLanguages_Result> list = Enumerable.ToList<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)cRMEntities.ApispSelectLanguages());
			int.TryParse(model.LanguageId.ToString(), out var currLangId);
			if (currLangId <= 0)
			{
				currLangId = defLangId;
			}
			string text = "fa-IR";
			ApispSelectLanguages_Result apispSelectLanguages_Result = Enumerable.FirstOrDefault<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result m) => m.LanguageID == currLangId));
			if (apispSelectLanguages_Result != null)
			{
				text = apispSelectLanguages_Result.LanguageCollation;
			}
			string text2 = null;
			CommonClass commonClass = new CommonClass();
			string cmpEffectiveDatePersian = null;
			string cmpCoordinateLastDatePersian = null;
			string prsBirthDate = null;
			string prsMarriageDate = null;
			string prjRemindDate = null;
			string cnvsRemindDate = null;
			string cnvsCoordinateLastDatePersian = null;
			string cnvsRemindDateForAllarm = null;
			string prjStartDate = null;
			string prjStartDay = null;
			string prjStartTime = null;
			string prjFinishedDate = null;
			string prjFinishedDay = null;
			string prjFinishedTime = null;
			TimeSpan? cnvsDoingTimeFrom = null;
			TimeSpan? cnvsDoingTime = null;
			TimeSpan? cnvsDoingTimeTo = null;
			if (model.ApiCmpEffectiveDateTime.HasValue)
			{
				cmpEffectiveDatePersian = (model.ApiCmpEffectiveDateTime ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
			}
			if (model.ApiCmpCoordinateLastDate.HasValue)
			{
				cmpCoordinateLastDatePersian = (model.ApiCmpCoordinateLastDate ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
			}
			if (model.ApiPrsBirthDateTime.HasValue)
			{
				prsBirthDate = (model.ApiPrsBirthDateTime ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
			}
			if (model.ApiPrsMarriageDateTime.HasValue)
			{
				prsMarriageDate = (model.ApiPrsMarriageDateTime ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
			}
			if (model.ApiPrjRemindDateTime.HasValue)
			{
				prjRemindDate = (model.ApiPrjRemindDateTime ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
			}
			if (model.ApiCnvsRemindDateTime.HasValue)
			{
				cnvsRemindDate = (model.ApiCnvsRemindDateTime ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
			}
			if (model.ApiCnvsCoordinateLastDateTime.HasValue)
			{
				cnvsCoordinateLastDatePersian = (model.ApiCnvsCoordinateLastDateTime ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
			}
			if (model.ApiCnvsRemindDateTimeForAllarm.HasValue)
			{
				cnvsRemindDateForAllarm = (model.ApiCnvsRemindDateTimeForAllarm ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
			}
			try
			{
				if (model.ApiPrjStartDateTime.HasValue)
				{
					prjStartDate = (model.ApiPrjStartDateTime ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
					prjStartDay = commonClass.ConvertNameToDayNum((model.ApiPrjStartDateTime ?? DateTime.Now).DayOfWeek.ToString());
					prjStartTime = (model.ApiPrjStartDateTime ?? DateTime.Now).ToString("HH:mm:ss");
				}
			}
			catch (Exception)
			{
				ServiceResult<FullRegisterResultViewModel> serviceResult = new ServiceResult<FullRegisterResultViewModel>();
				serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PrjStartDate", text, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			try
			{
				if (model.ApiPrjFinishedDateTime.HasValue)
				{
					prjFinishedDate = (model.ApiPrjFinishedDateTime ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
					prjFinishedDay = commonClass.ConvertNameToDayNum((model.ApiPrjFinishedDateTime ?? DateTime.Now).DayOfWeek.ToString());
					prjFinishedTime = (model.ApiPrjFinishedDateTime ?? DateTime.Now).ToString("HH:mm:ss");
				}
			}
			catch (Exception)
			{
				ServiceResult<FullRegisterResultViewModel> serviceResult = new ServiceResult<FullRegisterResultViewModel>();
				serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PrjFinishedDate", text, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			try
			{
				if (model.ApiPrjRemindDateTime.HasValue)
				{
					prjRemindDate = (model.ApiPrjRemindDateTime ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
				}
			}
			catch (Exception)
			{
				ServiceResult<FullRegisterResultViewModel> serviceResult = new ServiceResult<FullRegisterResultViewModel>();
				serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PrjRemindDate", text, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			if (!string.IsNullOrEmpty(model.ApiCnvsDoingTimeFrom) && TimeSpan.TryParseExact(model.ApiCnvsDoingTimeFrom, new string[3] { "hh\\:mm\\:ss", "hh\\:mm\\:ss\\.fffffff", "c" }, CultureInfo.InvariantCulture, out var result))
			{
				cnvsDoingTimeFrom = result;
			}
			if (!string.IsNullOrEmpty(model.ApiCnvsDoingTimeTo) && TimeSpan.TryParseExact(model.ApiCnvsDoingTimeTo, new string[3] { "hh\\:mm\\:ss", "hh\\:mm\\:ss\\.fffffff", "c" }, CultureInfo.InvariantCulture, out var result2))
			{
				cnvsDoingTimeTo = result2;
			}
			if (!string.IsNullOrEmpty(model.ApiCnvsDoingTime) && TimeSpan.TryParseExact(model.ApiCnvsDoingTime, new string[3] { "hh\\:mm\\:ss", "hh\\:mm\\:ss\\.fffffff", "c" }, CultureInfo.InvariantCulture, out var result3))
			{
				cnvsDoingTime = result3;
			}
			int mobNumLen = Setting.GetMobNumLen();
			bool mobNumLenNoCheck = Setting.GetMobNumLenNoCheck();
			if (!string.IsNullOrEmpty(model.Password))
			{
				model.Password = CodeDecode.DeCodding(model.Password);
			}
			if (!string.IsNullOrEmpty(model.UserName))
			{
				model.UserName = CodeDecode.DeCodding(model.UserName);
			}
			List<ApispSelectCrmFoSetting_Result> list2 = Enumerable.ToList<ApispSelectCrmFoSetting_Result>((IEnumerable<ApispSelectCrmFoSetting_Result>)cRMEntities.ApispSelectCrmFoSetting());
			if (!Enumerable.Any<ApispSelectCrmFoSetting_Result>((IEnumerable<ApispSelectCrmFoSetting_Result>)list2))
			{
				ServiceResult<FullRegisterResultViewModel> serviceResult = new ServiceResult<FullRegisterResultViewModel>();
				serviceResult.Message = MyResource.GetResourceString("ErrorInReadingFoSetting", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			if (Enumerable.FirstOrDefault<ApispSelectCrmFoSetting_Result>((IEnumerable<ApispSelectCrmFoSetting_Result>)list2, (Func<ApispSelectCrmFoSetting_Result, bool>)((ApispSelectCrmFoSetting_Result m) => m.LanguageID == defLangId)) == null)
			{
				ServiceResult<FullRegisterResultViewModel> serviceResult = new ServiceResult<FullRegisterResultViewModel>();
				serviceResult.Message = MyResource.GetResourceString("ErrorInReadingFoSetting", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			if (string.IsNullOrEmpty(model.ApiPrsMobile) && string.IsNullOrEmpty(model.ApiPrsEmail) && string.IsNullOrEmpty(model.ApiPrsEmailII))
			{
				ServiceResult<FullRegisterResultViewModel> serviceResult = new ServiceResult<FullRegisterResultViewModel>();
				serviceResult.Message = MyResource.GetResourceString("ErrorPrsMobEmailNotEntered", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			if (model.ApiPrsMobile != null)
			{
				if (model.ApiPrsMobile.Length != mobNumLen && !mobNumLenNoCheck)
				{
					ServiceResult<FullRegisterResultViewModel> serviceResult = new ServiceResult<FullRegisterResultViewModel>();
					serviceResult.Message = MyResource.GetResourceString("CheckLenMob", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
					serviceResult.Data = null;
					serviceResult.Status = ServiceResultStatus.Error;
					return serviceResult;
				}
				if (model.ApiPrsMobile.Length >= 2)
				{
					string text3 = model.ApiPrsMobile.Substring(0, 2);
					if (text3 != "09" && !mobNumLenNoCheck)
					{
						ServiceResult<FullRegisterResultViewModel> serviceResult = new ServiceResult<FullRegisterResultViewModel>();
						serviceResult.Message = MyResource.GetResourceString("CheckMobileFormat", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
						serviceResult.Data = null;
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
					ServiceResult<FullRegisterResultViewModel> serviceResult = new ServiceResult<FullRegisterResultViewModel>();
					serviceResult.Message = string.Format(MyResource.GetResourceString("CheckDigit", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PrsMobile", text, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly));
					serviceResult.Data = null;
					serviceResult.Status = ServiceResultStatus.Error;
					return serviceResult;
				}
			}
			if (model.ApiCmpPreTel != null && model.ApiCmpPreTel.Length > 1 && model.ApiCmpPreTel.Substring(0, 2) == "09")
			{
				ServiceResult<FullRegisterResultViewModel> serviceResult = new ServiceResult<FullRegisterResultViewModel>();
				serviceResult.Message = MyResource.GetResourceString("CheckPreTelForNotMobile", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			if (model.ApiCmpPreTelII != null && model.ApiCmpPreTelII.Length > 1 && model.ApiCmpPreTelII.Substring(0, 2) == "09")
			{
				ServiceResult<FullRegisterResultViewModel> serviceResult = new ServiceResult<FullRegisterResultViewModel>();
				serviceResult.Message = MyResource.GetResourceString("CheckPreTelForNotMobile", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			if (model.ApiCmpTel != null && model.ApiCmpTel.Length > 1 && model.ApiCmpTel.Substring(0, 2) == "09")
			{
				ServiceResult<FullRegisterResultViewModel> serviceResult = new ServiceResult<FullRegisterResultViewModel>();
				serviceResult.Message = MyResource.GetResourceString("CheckPreTelForNotMobile", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			if (model.ApiCmpTelII != null && model.ApiCmpTelII.Length > 1 && model.ApiCmpTelII.Substring(0, 2) == "09")
			{
				ServiceResult<FullRegisterResultViewModel> serviceResult = new ServiceResult<FullRegisterResultViewModel>();
				serviceResult.Message = MyResource.GetResourceString("CheckPreTelForNotMobile", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			if (model.ApiPrsPreTel != null && model.ApiPrsPreTel.Length > 1 && model.ApiPrsPreTel.Substring(0, 2) == "09")
			{
				ServiceResult<FullRegisterResultViewModel> serviceResult = new ServiceResult<FullRegisterResultViewModel>();
				serviceResult.Message = MyResource.GetResourceString("CheckPreTelForNotMobile", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			if (model.ApiPrsTel != null && model.ApiPrsTel.Length > 1 && model.ApiPrsTel.Substring(0, 2) == "09")
			{
				ServiceResult<FullRegisterResultViewModel> serviceResult = new ServiceResult<FullRegisterResultViewModel>();
				serviceResult.Message = MyResource.GetResourceString("CheckPreTelForNotMobile", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			if (model.ApiPrsTelII != null && model.ApiPrsTelII.Length > 1 && model.ApiPrsTelII.Substring(0, 2) == "09")
			{
				ServiceResult<FullRegisterResultViewModel> serviceResult = new ServiceResult<FullRegisterResultViewModel>();
				serviceResult.Message = MyResource.GetResourceString("CheckPreTelForNotMobile", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			if (!string.IsNullOrEmpty(model.ApiCmpMobile))
			{
				try
				{
					long.Parse(model.ApiCmpMobile);
				}
				catch
				{
					ServiceResult<FullRegisterResultViewModel> serviceResult = new ServiceResult<FullRegisterResultViewModel>();
					serviceResult.Message = string.Format(MyResource.GetResourceString("CheckDigit", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CmpMobile", text, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly));
					serviceResult.Data = null;
					serviceResult.Status = ServiceResultStatus.Error;
					return serviceResult;
				}
			}
			if (!string.IsNullOrEmpty(model.ApiCmpTel))
			{
				try
				{
					long.Parse(model.ApiCmpTel);
				}
				catch
				{
					ServiceResult<FullRegisterResultViewModel> serviceResult = new ServiceResult<FullRegisterResultViewModel>();
					serviceResult.Message = string.Format(MyResource.GetResourceString("CheckDigit", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CmpTel", text, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly));
					serviceResult.Data = null;
					serviceResult.Status = ServiceResultStatus.Error;
					return serviceResult;
				}
			}
			if (!string.IsNullOrEmpty(model.ApiCmpPreTel))
			{
				try
				{
					long.Parse(model.ApiCmpPreTel);
				}
				catch
				{
					ServiceResult<FullRegisterResultViewModel> serviceResult = new ServiceResult<FullRegisterResultViewModel>();
					serviceResult.Message = string.Format(MyResource.GetResourceString("CheckDigit", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CmpPreTel", text, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly));
					serviceResult.Data = null;
					serviceResult.Status = ServiceResultStatus.Error;
					return serviceResult;
				}
			}
			if (!string.IsNullOrEmpty(model.ApiCmpTelUpTo))
			{
				try
				{
					long.Parse(model.ApiCmpTelUpTo);
				}
				catch
				{
					ServiceResult<FullRegisterResultViewModel> serviceResult = new ServiceResult<FullRegisterResultViewModel>();
					serviceResult.Message = string.Format(MyResource.GetResourceString("CheckDigit", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CmpTelUpTo", text, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly));
					serviceResult.Data = null;
					serviceResult.Status = ServiceResultStatus.Error;
					return serviceResult;
				}
			}
			if (!string.IsNullOrEmpty(model.ApiCmpTelII))
			{
				try
				{
					long.Parse(model.ApiCmpTelII);
				}
				catch
				{
					ServiceResult<FullRegisterResultViewModel> serviceResult = new ServiceResult<FullRegisterResultViewModel>();
					serviceResult.Message = string.Format(MyResource.GetResourceString("CheckDigit", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CmpTelII", text, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly));
					serviceResult.Data = null;
					serviceResult.Status = ServiceResultStatus.Error;
					return serviceResult;
				}
			}
			if (!string.IsNullOrEmpty(model.ApiCmpPreTelII))
			{
				try
				{
					long.Parse(model.ApiCmpPreTelII);
				}
				catch
				{
					ServiceResult<FullRegisterResultViewModel> serviceResult = new ServiceResult<FullRegisterResultViewModel>();
					serviceResult.Message = string.Format(MyResource.GetResourceString("CheckDigit", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CmpPreTel", text, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly));
					serviceResult.Data = null;
					serviceResult.Status = ServiceResultStatus.Error;
					return serviceResult;
				}
			}
			if (!string.IsNullOrEmpty(model.ApiCmpTelUpToII))
			{
				try
				{
					long.Parse(model.ApiCmpTelUpToII);
				}
				catch
				{
					ServiceResult<FullRegisterResultViewModel> serviceResult = new ServiceResult<FullRegisterResultViewModel>();
					serviceResult.Message = string.Format(MyResource.GetResourceString("CheckDigit", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CmpTelUpTo", text, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly));
					serviceResult.Data = null;
					serviceResult.Status = ServiceResultStatus.Error;
					return serviceResult;
				}
			}
			if (!string.IsNullOrEmpty(model.ApiCmpFax))
			{
				try
				{
					long.Parse(model.ApiCmpFax);
				}
				catch
				{
					ServiceResult<FullRegisterResultViewModel> serviceResult = new ServiceResult<FullRegisterResultViewModel>();
					serviceResult.Message = string.Format(MyResource.GetResourceString("CheckDigit", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CmpFax", text, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly));
					serviceResult.Data = null;
					serviceResult.Status = ServiceResultStatus.Error;
					return serviceResult;
				}
			}
			if (model.ApiCmpPreTel != null && model.ApiCmpPreTel.Length > 1 && model.ApiCmpPreTel.Substring(0, 2) == "09")
			{
				ServiceResult<FullRegisterResultViewModel> serviceResult = new ServiceResult<FullRegisterResultViewModel>();
				serviceResult.Message = MyResource.GetResourceString("CheckPreTelForNotMobile", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			if (model.ApiCmpPreTelII != null && model.ApiCmpPreTelII.Length > 1 && model.ApiCmpPreTelII.Substring(0, 2) == "09")
			{
				ServiceResult<FullRegisterResultViewModel> serviceResult = new ServiceResult<FullRegisterResultViewModel>();
				serviceResult.Message = MyResource.GetResourceString("CheckPreTelForNotMobile", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			if (model.ApiCmpTel != null && model.ApiCmpTel.Length > 1 && model.ApiCmpTel.Substring(0, 2) == "09")
			{
				ServiceResult<FullRegisterResultViewModel> serviceResult = new ServiceResult<FullRegisterResultViewModel>();
				serviceResult.Message = MyResource.GetResourceString("CheckPreTelForNotMobile", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			if (model.ApiCmpTelII != null && model.ApiCmpTelII.Length > 1 && model.ApiCmpTelII.Substring(0, 2) == "09")
			{
				ServiceResult<FullRegisterResultViewModel> serviceResult = new ServiceResult<FullRegisterResultViewModel>();
				serviceResult.Message = MyResource.GetResourceString("CheckPreTelForNotMobile", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			if (model.ApiCmpNumber.HasValue)
			{
				ApispCheckDuplicateCompanyNumber_Result apispCheckDuplicateCompanyNumber_Result = Enumerable.FirstOrDefault<ApispCheckDuplicateCompanyNumber_Result>((IEnumerable<ApispCheckDuplicateCompanyNumber_Result>)cRMEntities.ApispCheckDuplicateCompanyNumber(model.ApiCmpNumber, 0, currLangId, defLangId));
				if (apispCheckDuplicateCompanyNumber_Result != null)
				{
					ServiceResult<FullRegisterResultViewModel> serviceResult = new ServiceResult<FullRegisterResultViewModel>();
					serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorCmpNumberDuplicate", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), apispCheckDuplicateCompanyNumber_Result.CompanyName ?? "");
					serviceResult.Data = null;
					serviceResult.Status = ServiceResultStatus.Error;
					return serviceResult;
				}
			}
			if (!string.IsNullOrEmpty(model.ApiCmpCode) && model.CmpCodeNotDup.HasValue && model.CmpCodeNotDup.GetValueOrDefault())
			{
				string text4 = Company.CheckDuplicateCompanyCode(0, model.ApiCmpCode, defLangId, currLangId, text);
				if (!string.IsNullOrEmpty(text4))
				{
					return new ServiceResult<FullRegisterResultViewModel>
					{
						Message = text4,
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
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
				flag4 = ((apispSelectCrmsysSetting_Result2.CantSaveDupCmpNationalCode.HasValue && apispSelectCrmsysSetting_Result2.CantSaveDupCmpNationalCode != false) ? true : false);
				flag5 = ((apispSelectCrmsysSetting_Result2.CantSaveDupCmpEconomicCode.HasValue && apispSelectCrmsysSetting_Result2.CantSaveDupCmpEconomicCode != false) ? true : false);
			}
			if (!string.IsNullOrEmpty(model.ApiCmpTel) && flag && model.CmpTelNotDup.HasValue && model.CmpTelNotDup.GetValueOrDefault())
			{
				string text5 = Company.CantSaveDupTel(model.ApiCmpTel, 1, 0, defLangId, currLangId, text);
				if (!string.IsNullOrEmpty(text5))
				{
					return new ServiceResult<FullRegisterResultViewModel>
					{
						Message = text5,
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
			}
			if (!string.IsNullOrEmpty(model.ApiCmpTelII) && flag && model.CmpTelNotDup.HasValue && model.CmpTelNotDup.GetValueOrDefault())
			{
				string text6 = Company.CantSaveDupTel(model.ApiCmpTelII, 1, 0, defLangId, currLangId, text);
				if (!string.IsNullOrEmpty(text6))
				{
					return new ServiceResult<FullRegisterResultViewModel>
					{
						Message = text6,
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
			}
			if (!string.IsNullOrEmpty(model.ApiCmpFax) && flag2 && model.CmpFaxNotDup.HasValue && model.CmpFaxNotDup.GetValueOrDefault())
			{
				string text7 = Company.CantSaveDupFax(model.ApiCmpFax, 1, 0, defLangId, currLangId, text);
				if (!string.IsNullOrEmpty(text7))
				{
					return new ServiceResult<FullRegisterResultViewModel>
					{
						Message = text7,
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
			}
			if (!string.IsNullOrEmpty(model.ApiCmpZipCode) && flag3)
			{
				string text8 = Company.CantSaveDupZipCode(model.ApiCmpZipCode, 1, 0, defLangId, currLangId, text);
				if (!string.IsNullOrEmpty(text8))
				{
					return new ServiceResult<FullRegisterResultViewModel>
					{
						Message = text8,
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
			}
			if (!string.IsNullOrEmpty(model.ApiCmpNationalCode) && flag4)
			{
				string text9 = Company.CantSaveDupCmpNationalCode(model.ApiCmpNationalCode, 0, defLangId, currLangId, text);
				if (!string.IsNullOrEmpty(text9))
				{
					return new ServiceResult<FullRegisterResultViewModel>
					{
						Message = text9,
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
			}
			if (!string.IsNullOrEmpty(model.ApiCmpEconomicCode) && flag5)
			{
				string text10 = Company.CantSaveDupCmpEconomicCode(model.ApiCmpEconomicCode, 0, defLangId, currLangId, text);
				if (!string.IsNullOrEmpty(text10))
				{
					return new ServiceResult<FullRegisterResultViewModel>
					{
						Message = text10,
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
			}
			if (!string.IsNullOrEmpty(model.ApiCmpEmail))
			{
				string text11 = Company.CantSaveDupCmpEmail(model.ApiCmpEmail, 0, defLangId, currLangId, text);
				if (!string.IsNullOrEmpty(text11))
				{
					return new ServiceResult<FullRegisterResultViewModel>
					{
						Message = text11,
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
			}
			if (!string.IsNullOrEmpty(model.ApiCmpMobile))
			{
				if (model.ApiCmpMobile != null)
				{
					if (model.ApiCmpMobile.Length != mobNumLen && !mobNumLenNoCheck)
					{
						ServiceResult<FullRegisterResultViewModel> serviceResult = new ServiceResult<FullRegisterResultViewModel>();
						serviceResult.Message = MyResource.GetResourceString("CheckLenMob", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
						serviceResult.Data = null;
						serviceResult.Status = ServiceResultStatus.Error;
						return serviceResult;
					}
					if (model.ApiCmpMobile.Length >= 2)
					{
						string text12 = model.ApiCmpMobile.Substring(0, 2);
						if (text12 != "09" && !mobNumLenNoCheck)
						{
							ServiceResult<FullRegisterResultViewModel> serviceResult = new ServiceResult<FullRegisterResultViewModel>();
							serviceResult.Message = MyResource.GetResourceString("CheckMobileFormat", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
							serviceResult.Data = null;
							serviceResult.Status = ServiceResultStatus.Error;
							return serviceResult;
						}
					}
				}
				string text13 = Company.CantSaveDupCmpMobile(model.ApiCmpMobile, 0, defLangId, currLangId, text);
				if (!string.IsNullOrEmpty(text13))
				{
					return new ServiceResult<FullRegisterResultViewModel>
					{
						Message = text13,
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
			}
			if (model.ApiPrsMobile != null)
			{
				if (model.ApiPrsMobile.Length != mobNumLen && !mobNumLenNoCheck)
				{
					ServiceResult<FullRegisterResultViewModel> serviceResult = new ServiceResult<FullRegisterResultViewModel>();
					serviceResult.Message = MyResource.GetResourceString("CheckLenMob", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
					serviceResult.Data = null;
					serviceResult.Status = ServiceResultStatus.Error;
					return serviceResult;
				}
				if (model.ApiPrsMobile.Length >= 2)
				{
					string text14 = model.ApiPrsMobile.Substring(0, 2);
					if (text14 != "09" && !mobNumLenNoCheck)
					{
						ServiceResult<FullRegisterResultViewModel> serviceResult = new ServiceResult<FullRegisterResultViewModel>();
						serviceResult.Message = MyResource.GetResourceString("CheckMobileFormat", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
						serviceResult.Data = null;
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
					ServiceResult<FullRegisterResultViewModel> serviceResult = new ServiceResult<FullRegisterResultViewModel>();
					serviceResult.Message = string.Format(MyResource.GetResourceString("CheckDigit", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PrsMobile", text, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly));
					serviceResult.Data = null;
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
					ServiceResult<FullRegisterResultViewModel> serviceResult = new ServiceResult<FullRegisterResultViewModel>();
					serviceResult.Message = string.Format(MyResource.GetResourceString("CheckDigit", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PrsTel", text, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly));
					serviceResult.Data = null;
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
					ServiceResult<FullRegisterResultViewModel> serviceResult = new ServiceResult<FullRegisterResultViewModel>();
					serviceResult.Message = string.Format(MyResource.GetResourceString("CheckDigit", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PrsPreTel", text, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly));
					serviceResult.Data = null;
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
					ServiceResult<FullRegisterResultViewModel> serviceResult = new ServiceResult<FullRegisterResultViewModel>();
					serviceResult.Message = string.Format(MyResource.GetResourceString("CheckDigit", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PrsTelUpTo", text, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly));
					serviceResult.Data = null;
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
					ServiceResult<FullRegisterResultViewModel> serviceResult = new ServiceResult<FullRegisterResultViewModel>();
					serviceResult.Message = string.Format(MyResource.GetResourceString("CheckDigit", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PrsTelII", text, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly));
					serviceResult.Data = null;
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
					ServiceResult<FullRegisterResultViewModel> serviceResult = new ServiceResult<FullRegisterResultViewModel>();
					serviceResult.Message = string.Format(MyResource.GetResourceString("CheckDigit", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PrsFax", text, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly));
					serviceResult.Data = null;
					serviceResult.Status = ServiceResultStatus.Error;
					return serviceResult;
				}
			}
			if (model.ApiPrsPreTel != null && model.ApiPrsPreTel.Length > 1 && model.ApiPrsPreTel.Substring(0, 2) == "09")
			{
				ServiceResult<FullRegisterResultViewModel> serviceResult = new ServiceResult<FullRegisterResultViewModel>();
				serviceResult.Message = MyResource.GetResourceString("CheckPreTelForNotMobile", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			if (model.ApiPrsTel != null && model.ApiPrsTel.Length > 1 && model.ApiPrsTel.Substring(0, 2) == "09")
			{
				ServiceResult<FullRegisterResultViewModel> serviceResult = new ServiceResult<FullRegisterResultViewModel>();
				serviceResult.Message = MyResource.GetResourceString("CheckPreTelForNotMobile", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			if (model.ApiPrsTelII != null && model.ApiPrsTelII.Length > 1 && model.ApiPrsTelII.Substring(0, 2) == "09")
			{
				ServiceResult<FullRegisterResultViewModel> serviceResult = new ServiceResult<FullRegisterResultViewModel>();
				serviceResult.Message = MyResource.GetResourceString("CheckPreTelForNotMobile", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			bool flag6 = false;
			bool flag7 = false;
			if (apispSelectCrmsysSetting_Result2 != null)
			{
				flag6 = ((apispSelectCrmsysSetting_Result2.CantSaveDupPrsNationalCode.HasValue && apispSelectCrmsysSetting_Result2.CantSaveDupPrsNationalCode != false) ? true : false);
				flag7 = ((apispSelectCrmsysSetting_Result2.MustFullPrsNationalCode.HasValue && apispSelectCrmsysSetting_Result2.MustFullPrsNationalCode != false) ? true : false);
			}
			if (!string.IsNullOrEmpty(model.ApiPrsTel) && flag && model.CmpTelNotDup.HasValue && model.CmpTelNotDup.GetValueOrDefault())
			{
				string text15 = Company.CantSaveDupTel(model.ApiPrsTel, 2, 0, defLangId, currLangId, text);
				if (!string.IsNullOrEmpty(text15))
				{
					return new ServiceResult<FullRegisterResultViewModel>
					{
						Message = text15,
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
			}
			if (!string.IsNullOrEmpty(model.ApiPrsTelII) && flag && model.CmpTelNotDup.HasValue && model.CmpTelNotDup.GetValueOrDefault())
			{
				string text16 = Company.CantSaveDupTel(model.ApiPrsTelII, 2, 0, defLangId, currLangId, text);
				if (!string.IsNullOrEmpty(text16))
				{
					return new ServiceResult<FullRegisterResultViewModel>
					{
						Message = text16,
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
			}
			if (!string.IsNullOrEmpty(model.ApiPrsFax) && flag2 && model.CmpFaxNotDup.HasValue && model.CmpFaxNotDup.GetValueOrDefault())
			{
				string text17 = Company.CantSaveDupFax(model.ApiPrsFax, 2, 0, defLangId, currLangId, text);
				if (!string.IsNullOrEmpty(text17))
				{
					return new ServiceResult<FullRegisterResultViewModel>
					{
						Message = text17,
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
			}
			if (!string.IsNullOrEmpty(model.ApiPrsNationalCode) && flag6)
			{
				string text18 = Company.CantSaveDupPrsNationalCode(model.ApiPrsNationalCode, 0, defLangId, currLangId, text);
				if (!string.IsNullOrEmpty(text18))
				{
					return new ServiceResult<FullRegisterResultViewModel>
					{
						Message = text18,
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
			}
			if (string.IsNullOrEmpty(model.ApiPrsNationalCode) && flag7)
			{
				ServiceResult<FullRegisterResultViewModel> serviceResult = new ServiceResult<FullRegisterResultViewModel>();
				serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorIsNotEntered", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PrsNationalCode", text, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly));
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			if (!string.IsNullOrEmpty(model.ApiPrjPostFix) && model.PrjPostFixNotDup.HasValue && model.PrjPostFixNotDup.GetValueOrDefault())
			{
				string text19 = Company.CantSaveDupPrjPostFix(model.ApiPrjPostFix, 0, defLangId, currLangId, text);
				if (!string.IsNullOrEmpty(text19))
				{
					return new ServiceResult<FullRegisterResultViewModel>
					{
						Message = text19,
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
			}
			if (!string.IsNullOrEmpty(model.ApiPrjDesc) && model.PrjDescNotDup.HasValue && model.PrjDescNotDup.GetValueOrDefault())
			{
				string text20 = Company.CantSaveDupPrjDesc(model.ApiPrjDesc, 0, defLangId, currLangId, text);
				if (!string.IsNullOrEmpty(text20))
				{
					return new ServiceResult<FullRegisterResultViewModel>
					{
						Message = text20,
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
			}
			if (model.ApiPrjNumR.HasValue && model.PrjNumRNotDup.HasValue && model.PrjNumRNotDup.GetValueOrDefault())
			{
				string text21 = Company.CantSaveDupPrjNumR(0, model.ApiPrjNumR, model.ApiPrjTitle, 0, defLangId, currLangId, text);
				if (!string.IsNullOrEmpty(text21))
				{
					return new ServiceResult<FullRegisterResultViewModel>
					{
						Message = text21,
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
			}
			if (!string.IsNullOrEmpty(model.ApiPrjNumRef) && model.PrjNumRefNotDup.HasValue && model.PrjNumRefNotDup.GetValueOrDefault())
			{
				string text22 = Company.CantSaveDupPrjNumRef(model.ApiPrjNumRef, 0, defLangId, currLangId, text);
				if (!string.IsNullOrEmpty(text22))
				{
					return new ServiceResult<FullRegisterResultViewModel>
					{
						Message = text22,
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
			}
			if (string.IsNullOrEmpty(model.ApiCmpName))
			{
				model.ApiCmpName = MyResource.GetResourceString("Person", text, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
			}
			string text23 = "";
			string text24 = "";
			string text25 = "";
			string text26 = "";
			if (!string.IsNullOrEmpty(model.Value))
			{
				model.Value = "<BR>" + model.Value.Replace("\r\n", "<BR>");
			}
			string text27 = "";
			if (!string.IsNullOrEmpty(model.ApiPrjTitle))
			{
				text27 = model.ApiPrjTitle + ((!string.IsNullOrEmpty(model.ApiPrjPostFix)) ? (" " + model.ApiPrjPostFix) : "");
			}
			else
			{
				text27 = text23 + ((text24 != "") ? (" " + text24) : "");
			}
			List<ApispSelectPersonTitleWithId_Result> list3 = new List<ApispSelectPersonTitleWithId_Result>();
			if (model.ApiPrsTitleId.HasValue)
			{
				list3 = Enumerable.ToList<ApispSelectPersonTitleWithId_Result>((IEnumerable<ApispSelectPersonTitleWithId_Result>)cRMEntities.ApispSelectPersonTitleWithId(model.ApiPrsTitleId));
			}
			string text28 = "";
			if (Enumerable.Any<ApispSelectPersonTitleWithId_Result>((IEnumerable<ApispSelectPersonTitleWithId_Result>)list3))
			{
				ApispSelectPersonTitleWithId_Result apispSelectPersonTitleWithId_Result = Enumerable.FirstOrDefault<ApispSelectPersonTitleWithId_Result>((IEnumerable<ApispSelectPersonTitleWithId_Result>)list3, (Func<ApispSelectPersonTitleWithId_Result, bool>)((ApispSelectPersonTitleWithId_Result m) => m.LanguageID == defLangId));
				text28 = ((apispSelectPersonTitleWithId_Result != null && !string.IsNullOrEmpty(apispSelectPersonTitleWithId_Result.PersonTitle)) ? apispSelectPersonTitleWithId_Result.PersonTitle : "");
			}
			string text29 = text28 + ((!string.IsNullOrEmpty(model.ApiPrsFName)) ? (" " + model.ApiPrsFName) : "") + ((!string.IsNullOrEmpty(model.ApiPrsLName)) ? (" " + model.ApiPrsLName) : "");
			List<ApispSelectCompanyTitleWithId_Result> list4 = new List<ApispSelectCompanyTitleWithId_Result>();
			if (model.ApiCmpTitleId.HasValue)
			{
				list4 = Enumerable.ToList<ApispSelectCompanyTitleWithId_Result>((IEnumerable<ApispSelectCompanyTitleWithId_Result>)cRMEntities.ApispSelectCompanyTitleWithId(model.ApiCmpTitleId));
			}
			string text30 = "";
			if (Enumerable.Any<ApispSelectCompanyTitleWithId_Result>((IEnumerable<ApispSelectCompanyTitleWithId_Result>)list4))
			{
				ApispSelectCompanyTitleWithId_Result apispSelectCompanyTitleWithId_Result = Enumerable.FirstOrDefault<ApispSelectCompanyTitleWithId_Result>((IEnumerable<ApispSelectCompanyTitleWithId_Result>)list4, (Func<ApispSelectCompanyTitleWithId_Result, bool>)((ApispSelectCompanyTitleWithId_Result m) => m.LanguageID == defLangId));
				text30 = ((apispSelectCompanyTitleWithId_Result != null && !string.IsNullOrEmpty(apispSelectCompanyTitleWithId_Result.CompanyTitle)) ? apispSelectCompanyTitleWithId_Result.CompanyTitle : "");
			}
			string text31 = text30 + ((!string.IsNullOrEmpty(model.ApiCmpName)) ? (" " + model.ApiCmpName) : "");
			string cnvsDesc = ((!string.IsNullOrEmpty(model.ApiCnvsDesc)) ? model.ApiCnvsDesc.Replace("\r\n", "<BR>") : text25);
			string cnvsReferDesc = ((!string.IsNullOrEmpty(model.ApiCnvsReferDesc)) ? model.ApiCnvsReferDesc.Replace("\r\n", "<BR>") : text26);
			string userName = CommonClass.GetUserName(model.UserId, defLangId, defLangId);
			int userId = model.UserId;
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string dubClickDisplayCmpInfo = Messages.DubClickDisplayCmpInfo;
			string appType = CRMIdealApi.Classes.Configuration.AppType;
			short num = short.Parse(now.ToString("yyyy", new PersianCulture()));
			string registerDay = commonClass.ConvertNameToDayNum(now.DayOfWeek.ToString());
			string registerTime = now.ToString("HH:mm:ss");
			string person = Labels.Person;
			if (!string.IsNullOrEmpty(model.ApiCmpPassword))
			{
				model.ApiCmpPassword = ((!string.IsNullOrEmpty(model.ApiCmpPassword)) ? XorCipher.EncryptByPublicKey(model.ApiCmpPassword) : null);
			}
			string text32 = "";
			string text33 = "";
			string text34 = "";
			foreach (ApispSelectLanguages_Result lang2 in list)
			{
				string text35 = "";
				string text36 = "";
				string text37 = "";
				string text38 = "";
				ApispSelectCrmFoSetting_Result apispSelectCrmFoSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmFoSetting_Result>((IEnumerable<ApispSelectCrmFoSetting_Result>)list2, (Func<ApispSelectCrmFoSetting_Result, bool>)((ApispSelectCrmFoSetting_Result m) => m.LanguageID == lang2.LanguageID));
				if (apispSelectCrmFoSetting_Result != null)
				{
					text35 = ((!string.IsNullOrEmpty(apispSelectCrmFoSetting_Result.PrjDefaultTitle)) ? apispSelectCrmFoSetting_Result.PrjDefaultTitle : "");
					text36 = ((!string.IsNullOrEmpty(apispSelectCrmFoSetting_Result.PrjDefaultPostFix)) ? apispSelectCrmFoSetting_Result.PrjDefaultPostFix : "");
					text37 = ((!string.IsNullOrEmpty(apispSelectCrmFoSetting_Result.CnvsDefaultDesc)) ? apispSelectCrmFoSetting_Result.CnvsDefaultDesc.Replace("\r\n", "<BR>") : "");
					text38 = ((!string.IsNullOrEmpty(apispSelectCrmFoSetting_Result.CnvsDefaultReferDesc)) ? apispSelectCrmFoSetting_Result.CnvsDefaultReferDesc.Replace("\r\n", "<BR>") : null);
				}
				text35 = ((!string.IsNullOrEmpty(model.ApiPrjTitle)) ? model.ApiPrjTitle : text35);
				text36 = ((!string.IsNullOrEmpty(model.ApiPrjPostFix)) ? model.ApiPrjPostFix : text36);
				text37 = ((!string.IsNullOrEmpty(model.ApiCnvsDesc)) ? model.ApiCnvsDesc.Replace("\r\n", "<BR>") : text37);
				text38 = ((!string.IsNullOrEmpty(model.ApiCnvsReferDesc)) ? model.ApiCnvsReferDesc.Replace("\r\n", "<BR>") : text38);
				text32 = "";
				text33 = "";
				text32 = MyResource.GetResourceString("ErjaFrom", lang2.LanguageCollation, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + " " + CommonClass.GetUserName(model.UserId, defLangId, lang2.LanguageID);
				text33 = MyResource.GetResourceString("ErjaInConnection", lang2.LanguageCollation, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": " + text31 + "<BR>" + MyResource.GetResourceString("ErjaPerson", lang2.LanguageCollation, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": " + text29 + "<BR>" + MyResource.GetResourceString("ErjaProject", lang2.LanguageCollation, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": " + ((!string.IsNullOrEmpty(text35)) ? text35 : "") + ((!string.IsNullOrEmpty(text36)) ? (" " + text36) : "");
				if (!string.IsNullOrEmpty(model.ApiCnvsReferToMultilUser))
				{
					string[] array = model.ApiCnvsReferToMultilUser.Split(new char[1] { ',' });
					if (Enumerable.Any<string>((IEnumerable<string>)array))
					{
						string text39 = "";
						string[] array2 = array;
						foreach (string text40 in array2)
						{
							int num2 = ((!string.IsNullOrEmpty(text40)) ? int.Parse(text40) : 0);
							if (num2 > 0)
							{
								string text41 = ((num2 > 0) ? CommonClass.GetUserName(num2, defLangId, lang2.LanguageID) : "");
								text39 = text39 + text41 + ",";
							}
						}
						text39 = ((!string.IsNullOrEmpty(text39)) ? text39.TrimEnd(new char[1] { ',' }) : "");
						if (text39 != "")
						{
							text33 = text33 + "<BR>" + MyResource.GetResourceString("ErjaMultiUser", lang2.LanguageCollation, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": " + text39;
						}
					}
				}
				text33 = text33 + "<BR><BR>" + MyResource.GetResourceString("ErjaConversationDescription", lang2.LanguageCollation, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ":<BR>" + text37.Replace("\r\n", "<BR>") + ((!string.IsNullOrEmpty(model.Value)) ? model.Value : "");
				string text42 = text38;
				if (!string.IsNullOrEmpty(text42))
				{
					text33 = text33 + "<BR>" + MyResource.GetResourceString("ErjaReferDescription", lang2.LanguageCollation, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ":<BR>" + text42.Replace("\r\n", "<BR>");
				}
				text33 = text33 + "<BR><BR>" + MyResource.GetResourceString("ErjaDetails", lang2.LanguageCollation, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				text34 = text34 + "MsgSubj=" + text32 + "|@#@|MsgBody=" + text33 + "|@#@|LangId=" + lang2.LanguageID + "|@#@||^#^|";
			}
			string text43 = "";
			string text44 = "";
			string text45 = "";
			if (!string.IsNullOrEmpty(model.ApiCnvsReferToMultilUser))
			{
				string[] array3 = model.ApiCnvsReferToMultilUser.Split(new char[1] { ',' });
				if (Enumerable.Any<string>((IEnumerable<string>)array3))
				{
					foreach (ApispSelectLanguages_Result lang in list)
					{
						string text46 = "";
						string[] array4 = array3;
						foreach (string text47 in array4)
						{
							int num3 = ((!string.IsNullOrEmpty(text47)) ? int.Parse(text47) : 0);
							if (num3 > 0)
							{
								string text48 = ((num3 > 0) ? CommonClass.GetUserName(num3, defLangId, lang.LanguageID) : "");
								text46 = text46 + text48 + ",";
							}
						}
						text46 = ((!string.IsNullOrEmpty(text46)) ? text46.TrimEnd(new char[1] { ',' }) : "");
						string text49 = "";
						string text50 = "";
						string text51 = "";
						string text52 = "";
						ApispSelectCrmFoSetting_Result apispSelectCrmFoSetting_Result2 = Enumerable.FirstOrDefault<ApispSelectCrmFoSetting_Result>((IEnumerable<ApispSelectCrmFoSetting_Result>)list2, (Func<ApispSelectCrmFoSetting_Result, bool>)((ApispSelectCrmFoSetting_Result m) => m.LanguageID == lang.LanguageID));
						if (apispSelectCrmFoSetting_Result2 != null)
						{
							text49 = ((!string.IsNullOrEmpty(apispSelectCrmFoSetting_Result2.PrjDefaultTitle)) ? apispSelectCrmFoSetting_Result2.PrjDefaultTitle : "");
							text50 = ((!string.IsNullOrEmpty(apispSelectCrmFoSetting_Result2.PrjDefaultPostFix)) ? apispSelectCrmFoSetting_Result2.PrjDefaultPostFix : "");
							text51 = ((!string.IsNullOrEmpty(apispSelectCrmFoSetting_Result2.CnvsDefaultDesc)) ? apispSelectCrmFoSetting_Result2.CnvsDefaultDesc.Replace("\r\n", "<BR>") : "");
							text52 = ((!string.IsNullOrEmpty(apispSelectCrmFoSetting_Result2.CnvsDefaultReferDesc)) ? apispSelectCrmFoSetting_Result2.CnvsDefaultReferDesc.Replace("\r\n", "<BR>") : null);
						}
						text49 = ((!string.IsNullOrEmpty(model.ApiPrjTitle)) ? model.ApiPrjTitle : text49);
						text50 = ((!string.IsNullOrEmpty(model.ApiPrjPostFix)) ? model.ApiPrjPostFix : text50);
						text51 = ((!string.IsNullOrEmpty(model.ApiCnvsDesc)) ? model.ApiCnvsDesc.Replace("\r\n", "<BR>") : text51);
						text52 = ((!string.IsNullOrEmpty(model.ApiCnvsReferDesc)) ? model.ApiCnvsReferDesc.Replace("\r\n", "<BR>") : text52);
						text43 = "";
						text44 = "";
						text43 = MyResource.GetResourceString("ErjaRonevesht", lang.LanguageCollation, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + " " + CommonClass.GetUserName(model.UserId, defLangId, lang.LanguageID);
						text44 = MyResource.GetResourceString("ErjaInConnection", lang.LanguageCollation, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": " + text31 + "<BR>" + MyResource.GetResourceString("ErjaPerson", lang.LanguageCollation, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": " + text29 + "<BR>" + MyResource.GetResourceString("ErjaProject", lang.LanguageCollation, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": " + ((!string.IsNullOrEmpty(text49)) ? text49 : "") + ((!string.IsNullOrEmpty(text50)) ? (" " + text50) : "");
						if (text46 != "")
						{
							text44 = text44 + "<BR>" + MyResource.GetResourceString("ErjaMultiUser", lang.LanguageCollation, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": " + text46;
						}
						text44 = text44 + "<BR><BR>" + MyResource.GetResourceString("ErjaConversationDescription", lang.LanguageCollation, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ":<BR>" + text51.Replace("\r\n", "<BR>") + ((!string.IsNullOrEmpty(model.Value)) ? model.Value : "");
						text44 = text44 + "<BR><BR>" + MyResource.GetResourceString("ErjaDetails", lang.LanguageCollation, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
						text45 = text45 + "MsgSubj=" + text43 + "|@#@|MsgBody=" + text44 + "|@#@|LangId=" + lang.LanguageID + "|@#@||^#^|";
					}
				}
			}
			ObjectParameter objectParameter = new ObjectParameter("InsertedCompanyId", 0);
			ObjectParameter objectParameter2 = new ObjectParameter("InsertedPersonId", 0);
			ObjectParameter objectParameter3 = new ObjectParameter("InsertedProjectId", 0);
			ObjectParameter objectParameter4 = new ObjectParameter("InsertedConversationId", 0);
			ObjectParameter objectParameter5 = new ObjectParameter("ErrorMessage", "");
			string text53 = "";
			string surveyMainExtrenalLink = "";
			string surveyMainExtrenalLinkLogin = "";
			string leftPart = base.Request.RequestUri.GetLeftPart(UriPartial.Authority);
			string leftPart2 = base.Request.RequestUri.GetLeftPart(UriPartial.Scheme);
			string text54 = leftPart;
			if (text54.EndsWith("/"))
			{
				text54 = text54.TrimEnd(new char[1] { '/' });
			}
			text54 += "/Survey/Home/SurveyAnswerValues";
			text53 = text54;
			int? num4 = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.ApispRegisterCompanyWithCnvs(model.UserName, model.Password, cmpName: model.ApiCmpName, cmpNumber: model.ApiCmpNumber, cmpNameEng: model.ApiCmpNameEng, cmpTitleId: model.ApiCmpTitleId, cmpFame: model.ApiCmpFame, cmpActivityType: model.ApiCmpActivityType, cmpGroupId: model.ApiCmpGroupId, cmpSubGroupId: model.ApiCmpSubGroupId, cmpGroupIdII: model.ApiCmpGroupIdII, cmpGroupIdIII: model.ApiCmpGroupIdIII, cmpGroupIdIV: model.ApiCmpGroupIdIV, cmpTypeId: model.ApiCmpTypeId, cmpPresentationId: model.ApiCmpPresentationId, cmpPreTel: model.ApiCmpPreTel, cmpTel: model.ApiCmpTel, cmpTelUpTo: model.ApiCmpTelUpTo, cmpTelDesc: model.ApiCmpTelDesc, cmpPreTelII: model.ApiCmpPreTelII, cmpTelII: model.ApiCmpTelII, cmpTelUpToII: model.ApiCmpTelUpToII, cmpTelIIDesc: model.ApiCmpTelIIDesc, cmpMobile: null, cmpFax: model.ApiCmpFax, cmpFaxDesc: model.ApiCmpFaxDesc, cmpCountryId: model.ApiCmpCountryId, cmpProvinceId: model.ApiCmpProvinceId, cmpCityId: model.ApiCmpCityId, cmpAddress: model.ApiCmpAddress, cmpAddressDesc: model.ApiCmpAddressDesc, cmpZipCode: model.ApiCmpZipCode, cmpPostBox: model.ApiCmpPostBox, cmpWebSite: model.ApiCmpWebSite, cmpEmail: model.ApiCmpEmail, cmpInteresting: model.ApiCmpInteresting, cmpSpecialPoint: model.ApiCmpSpecialPoint, cmpDescription: model.ApiCmpDescription, cmpUserName: model.ApiCmpUserName, cmpPassword: model.ApiCmpPassword, cmpRegistrationNumber: model.ApiCmpRegistrationNumber, cmpEconomicCode: model.ApiCmpEconomicCode, cmpNationalCode: model.ApiCmpNationalCode, cmpBuyLimit: model.ApiCmpBuyLimit, cmpAccountNumber: model.ApiCmpAccountNumber, cmpAccInquiry: model.ApiCmpAccInquiry, cmpFreight: model.ApiCmpFreight, cmpInquiry: model.ApiCmpInquiry, cmpReferUserId: model.ApiCmpReferUserId, cmpSpecialWordForCI: model.ApiCmpSpecialWordForCI, cmpCode: model.ApiCmpCode, cmpEffectiveDatePersian: cmpEffectiveDatePersian, cmpEffectiveDateTime: model.ApiCmpEffectiveDateTime, cmpCoordinateLatitude: model.ApiCmpCoordinateLatitude, cmpCoordinateLongitude: model.ApiCmpCoordinateLongitude, cmpCoordinateLastDate: model.ApiCmpCoordinateLastDate, cmpCoordinateLastDatePersian: cmpCoordinateLastDatePersian, cmpCoordinateZoomLevel: model.ApiCmpCoordinateZoomLevel, cmpCoordinateLastUserId: model.ApiCmpCoordinateLastUserId, tspCmpBbc: model.ApiTspCmpBbc, tspCmpBpn: model.ApiTspCmpBpn, tspCmpTob: model.ApiTspCmpTob, cmpOfficialTel: model.ApiCmpOfficialTel, cmpOfficialCityId: model.ApiCmpOfficialCityId, cmpOfficialAddress: model.ApiCmpOfficialAddress, cmpOfficialZipCode: model.ApiCmpOfficialZipCode, cmpOfficialDesc: model.ApiCmpOfficialDesc, cmpSuppUserId: model.ApiCmpSuppUserId, prsLName: model.ApiPrsLName, prsFName: model.ApiPrsFName, prsTitleId: model.ApiPrsTitleId, prsJobId: model.ApiPrsJobId, prsTypeId: model.ApiPrsTypeId, prsGroupId: model.ApiPrsGroupId, prsSexId: model.ApiPrsSexId, prsPreTel: model.ApiPrsPreTel, prsTel: model.ApiPrsTel, prsTelUpTo: model.ApiPrsTelUpTo, prsTelDesc: model.ApiPrsTelDesc, prsTelII: model.ApiPrsTelII, prsFax: model.ApiPrsFax, prsFaxDesc: model.ApiPrsFaxDesc, prsMobile: model.ApiPrsMobile, prsEmail: model.ApiPrsEmail, prsEmailII: model.ApiPrsEmailII, prsAddress: model.ApiPrsAddress, prsAddressDesc: model.ApiPrsAddressDesc, prsNationalCode: model.ApiPrsNationalCode, prsBirthDate: prsBirthDate, prsBirthDateTime: model.ApiPrsBirthDateTime, prsMarriageDate: prsMarriageDate, prsMarriageDateTime: model.ApiPrsMarriageDateTime, prsDescription: model.ApiPrsDescription, prsDepartmentId: model.ApiPrsDepartmentId, prsEducationId: model.ApiPrsEducationId, prsWebSite: model.ApiPrsWebSite, prsCountryId: model.ApiPrsCountryId, prsProvinceId: model.ApiPrsProvinceId, prsCityId: model.ApiPrsCityId, prsZipCode: model.ApiPrsZipCode, prsPostBox: model.ApiPrsPostBox, prsIdentityNumber: model.ApiPrsIdentityNumber, prsFatherName: model.ApiPrsFatherName, prsBirthPlace: model.ApiPrsBirthPlace, prsIsMarried: model.ApiPrsIsMarried, prsEducationField: model.ApiPrsEducationField, prsSkill: model.ApiPrsSkill, prsStudyField: model.ApiPrsStudyField, prsInteresting: model.ApiPrsInteresting, prsSpecialPoint: model.ApiPrsSpecialPoint, prsStopSendSms: model.ApiPrsStopSendSms, prsWorkingOut: model.ApiPrsWorkingOut, prsTelegramId: model.ApiPrsTelegramId, prjTitle: model.ApiPrjTitle, prjDesc: model.ApiPrjDesc, prjStarterUserId: model.ApiPrjStarterUserId, prjGradeId: model.ApiPrjGradeId, prjPriorityId: model.ApiPrjPriorityId, prjGroupId: model.ApiPrjGroupId, prjcnvsStatusGroupId: model.ApiPrjCnvsStatusGroupId, prjPostFix: model.ApiPrjPostFix, prjRemindDate: prjRemindDate, prjRemindDateTime: model.ApiPrjRemindDateTime, prjInsertCrmProjectForbiddenFUFDPActive: model.ApiPrjInsertCrmProjectForbiddenFUFDPActive, prjStartDate: prjStartDate, prjStartDay: prjStartDay, prjStartTime: prjStartTime, prjStartDateTime: model.ApiPrjStartDateTime, prjFinishedStatusId: model.ApiPrjFinishedStatusId, prjIsFinished: model.ApiPrjIsFinished, prjFinishedDate: prjFinishedDate, prjFinishedDay: prjFinishedDay, prjFinishedTime: prjFinishedTime, prjFinishedDateTime: model.ApiPrjFinishedDateTime, prjFinishedUserId: model.ApiPrjFinishedUserId, prjFOCmpCanSee: model.ApiPrjFOCmpCanSee, prjIsTicket: model.ApiPrjIsTicket, prjUserDepartmentId: model.ApiPrjUserDepartmentId, prjTitleGroup: model.ApiPrjTitleGroup, prjCategoryId: model.ApiPrjCategoryId, prjSubject: model.ApiPrjSubject, prjDescI: model.ApiPrjDescI, prjNumR: model.ApiPrjNumR, prjNumRef: model.ApiPrjNumRef, cnvsTopicId: model.ApiCnvsTopicId, cnvsDesc: cnvsDesc, cnvsUserId: model.ApiCnvsUserId, cnvsReferUserId: model.ApiCnvsReferUserId, cnvsReferDesc: cnvsReferDesc, cnvsStatusId: model.ApiCnvsStatusId, cnvsPriorityId: model.ApiCnvsPriorityId, cnvsRemindDate: cnvsRemindDate, cnvsRemindDateTime: model.ApiCnvsRemindDateTime, cnvsReferToMultilUser: model.ApiCnvsReferToMultilUser, cnvsSubject: model.ApiCnvsSubject, cnvsRemindTime: model.ApiCnvsRemindTime, cnvsRemindOk: model.ApiCnvsRemindOk, cnvsIsBookMark: model.ApiCnvsIsBookMark, cnvsRemindDateForAllarm: cnvsRemindDateForAllarm, cnvsRemindDateTimeForAllarm: model.ApiCnvsRemindDateTimeForAllarm, cnvsFOCmpCanSee: model.ApiCnvsFOCmpCanSee, cnvsIsTicket: model.ApiCnvsIsTicket, cnvsCoordinateLatitude: model.ApiCnvsCoordinateLatitude, cnvsCoordinateLongitude: model.ApiCnvsCoordinateLongitude, cnvsCoordinateLastDate: model.ApiCnvsCoordinateLastDateTime, cnvsCoordinateLastDatePersian: cnvsCoordinateLastDatePersian, cnvsTicketIsRead: model.ApiCnvsTicketIsRead, cnvsDoingTime: cnvsDoingTime, cnvsDoingTimeFrom: cnvsDoingTimeFrom, cnvsDoingTimeTo: cnvsDoingTimeTo, cnvsIsCopy: model.ApiCnvsIsCopy, userId: userId, month1: value2, registerDate: value, registerDatePersian: registerDatePersian, registerTime: registerTime, registerDay: registerDay, appType: appType, needErjaRefMsgSubject: "", needErjaRefMsgBody: text34, needErjaMultiIntmsgSubject: "", needErjaMultiIntmsgBody: text45, conversationErjaShowText: dubClickDisplayCmpInfo, value: model.Value, insertedCompanyId: objectParameter, insertedPersonId: objectParameter2, insertedProjectId: objectParameter3, insertedConversationId: objectParameter4, errorMessage: objectParameter5, cmpCodeNotDup: model.CmpCodeNotDup, cmpCampaignIds: model.ApiCmpCampaignIds, prjCmpPresentationId: model.ApiPrjCmpPresentationId, prjCmpCampaignIds: model.ApiPrjCmpCampaignIds, cmpCampaignName: model.ApiCmpCampaignName, prjCampaignName: model.ApiPrjCmpCampaignName, cnvsStatusResultId: model.ApiCnvsStatusResultId, surveyMainInternalLink: text53, surveyMainExtrenalLink: surveyMainExtrenalLink, surveyMainExtrenalLinkLogin: surveyMainExtrenalLinkLogin, cmpKind: model.ApiCmpKind, centerId: model.CenterId, centerCode: model.CenterCode, cmpNameOfficial: model.ApiCmpNameOfficial));
			string resourceString = MyResource.GetResourceString("ErrorDoneOperationTryAgain", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
			string resourceString2 = MyResource.GetResourceString("ErrorTryAgain", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
			int result4 = 0;
			int.TryParse(num4.ToString(), out result4);
			if (result4 <= 0)
			{
				return new ServiceResult<FullRegisterResultViewModel>
				{
					Message = resourceString.Replace("<br>", "\r\n"),
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			if (objectParameter5.Value != null && objectParameter5.Value.ToString() != "")
			{
				string text55 = "";
				string text56 = objectParameter5.Value.ToString();
				if (text56.IndexOf("IsUser=0", StringComparison.Ordinal) >= 0)
				{
					text55 = text55 + MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "<br>";
					resourceString2 = "<br>" + MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + resourceString2;
					return new ServiceResult<FullRegisterResultViewModel>
					{
						Message = resourceString2.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text56.IndexOf("DupUName=1", StringComparison.Ordinal) >= 0)
				{
					text55 = text55 + MyResource.GetResourceString("ErrorUsernameIsRepeat", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "<br>";
					resourceString2 = "<br>" + MyResource.GetResourceString("ErrorUsernameIsRepeat", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + resourceString2;
					return new ServiceResult<FullRegisterResultViewModel>
					{
						Message = resourceString2.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text56.IndexOf("DupCmpCode=", StringComparison.Ordinal) >= 0)
				{
					string[] array5 = text56.Split(new char[1] { '|' });
					string arg = "";
					if (array5 != null)
					{
						string[] array6 = array5;
						foreach (string text57 in array6)
						{
							if (!string.IsNullOrEmpty(text57) && text57.IndexOf("DupCmpCode=", StringComparison.Ordinal) >= 0)
							{
								string[] array7 = text57.Split(new char[1] { '=' });
								if (array7 != null && array7.Length == 2)
								{
									arg = ((array7[1] != null && array7[1] != "") ? array7[1] : "");
								}
							}
						}
					}
					text55 = text55 + string.Format(MyResource.GetResourceString("ErrorCheckCmpCodeDuplicate", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), model.ApiCmpCode, arg) + "<br>";
					return new ServiceResult<FullRegisterResultViewModel>
					{
						Message = text55.Replace("<br>", "\r\n") + resourceString2.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text56.IndexOf("DupMob=", StringComparison.Ordinal) >= 0)
				{
					string[] array8 = text56.Split(new char[1] { '|' });
					string arg2 = "";
					if (array8 != null)
					{
						string[] array9 = array8;
						foreach (string text58 in array9)
						{
							if (!string.IsNullOrEmpty(text58) && text58.IndexOf("DupMob=", StringComparison.Ordinal) >= 0)
							{
								string[] array10 = text58.Split(new char[1] { '=' });
								if (array10 != null && array10.Length == 2)
								{
									arg2 = ((array10[1] != null && array10[1] != "") ? array10[1] : "");
								}
							}
						}
					}
					text55 = text55 + string.Format(MyResource.GetResourceString("ErrorCheckPrsMobileDuplicate", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), model.ApiPrsMobile, arg2) + "<br>";
					resourceString2 = "<br>" + MyResource.GetResourceString("ErrorMobileAlreadyRegistered", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + resourceString2;
					return new ServiceResult<FullRegisterResultViewModel>
					{
						Message = resourceString2.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text56.IndexOf("DupEmailI=", StringComparison.Ordinal) >= 0)
				{
					string[] array11 = text56.Split(new char[1] { '|' });
					string arg3 = "";
					if (array11 != null)
					{
						string[] array12 = array11;
						foreach (string text59 in array12)
						{
							if (!string.IsNullOrEmpty(text59) && text59.IndexOf("DupEmailI=", StringComparison.Ordinal) >= 0)
							{
								string[] array13 = text59.Split(new char[1] { '=' });
								if (array13 != null && array13.Length == 2)
								{
									arg3 = ((array13[1] != null && array13[1] != "") ? array13[1] : "");
								}
							}
						}
					}
					text55 = text55 + string.Format(MyResource.GetResourceString("ErrorCheckPrsEmailDuplicate", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), model.ApiPrsEmail, arg3) + "<br>";
					resourceString2 = "<br>" + MyResource.GetResourceString("ErrorEmailAlreadyRegistered", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + resourceString2;
					return new ServiceResult<FullRegisterResultViewModel>
					{
						Message = resourceString2.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text56.IndexOf("DupEmailII=", StringComparison.Ordinal) >= 0)
				{
					string[] array14 = text56.Split(new char[1] { '|' });
					string arg4 = "";
					if (array14 != null)
					{
						string[] array15 = array14;
						foreach (string text60 in array15)
						{
							if (!string.IsNullOrEmpty(text60) && text60.IndexOf("DupEmailII=", StringComparison.Ordinal) >= 0)
							{
								string[] array16 = text60.Split(new char[1] { '=' });
								if (array16 != null && array16.Length == 2)
								{
									arg4 = ((array16[1] != null && array16[1] != "") ? array16[1] : "");
								}
							}
						}
					}
					text55 = text55 + string.Format(MyResource.GetResourceString("ErrorCheckPrsEmailDuplicate", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), model.ApiPrsEmail, arg4) + "<br>";
					resourceString2 = "<br>" + MyResource.GetResourceString("ErrorEmailIIAlreadyRegistered", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + resourceString2;
					return new ServiceResult<FullRegisterResultViewModel>
					{
						Message = resourceString2.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text56.IndexOf("No Center|", StringComparison.Ordinal) >= 0)
				{
					text55 = text55 + MyResource.GetResourceString("msgErrorCenterNotFound", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "<br>";
					return new ServiceResult<FullRegisterResultViewModel>
					{
						Message = resourceString.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text56.IndexOf("ErrorInInsertCompany|", StringComparison.Ordinal) >= 0)
				{
					text55 = text55 + MyResource.GetResourceString("ErrorInInsertCompany", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "<br>";
					return new ServiceResult<FullRegisterResultViewModel>
					{
						Message = resourceString.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text56.IndexOf("ErrorInInsertPerson|", StringComparison.Ordinal) >= 0)
				{
					text55 = text55 + MyResource.GetResourceString("ErrorInInsertPerson", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "<br>";
					return new ServiceResult<FullRegisterResultViewModel>
					{
						Message = resourceString.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text56.IndexOf("ErrorInInsertProject|", StringComparison.Ordinal) >= 0)
				{
					text55 = text55 + MyResource.GetResourceString("ErrorInInsertProject", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "<br>";
					return new ServiceResult<FullRegisterResultViewModel>
					{
						Message = resourceString.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text56.IndexOf("ErrorInInsertConversation|", StringComparison.Ordinal) >= 0)
				{
					text55 = text55 + MyResource.GetResourceString("ErrorInInsertConversation", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "<br>";
					return new ServiceResult<FullRegisterResultViewModel>
					{
						Message = resourceString.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
			}
			else
			{
				if (objectParameter == null || objectParameter.Value.ToString() == "0")
				{
					return new ServiceResult<FullRegisterResultViewModel>
					{
						Message = resourceString.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if ((objectParameter2 == null || objectParameter2.Value.ToString() == "0") && !string.IsNullOrWhiteSpace(model.ApiPrsLName))
				{
					return new ServiceResult<FullRegisterResultViewModel>
					{
						Message = resourceString.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if ((objectParameter3 == null || objectParameter3.Value.ToString() == "0") && !string.IsNullOrWhiteSpace(model.ApiPrjTitle))
				{
					return new ServiceResult<FullRegisterResultViewModel>
					{
						Message = resourceString.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if ((objectParameter4 == null || objectParameter4.Value.ToString() == "0") && !string.IsNullOrWhiteSpace(model.ApiCnvsDesc))
				{
					return new ServiceResult<FullRegisterResultViewModel>
					{
						Message = resourceString.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				PushNotif.NewIntMsgNotify(currLangId, defLangId);
				FullRegisterResultViewModel fullRegisterResultViewModel = new FullRegisterResultViewModel();
				fullRegisterResultViewModel.CompanyId = ((objectParameter.Value != null) ? int.Parse(objectParameter.Value.ToString() ?? "0") : 0);
				fullRegisterResultViewModel.PersonId = ((objectParameter2.Value != null) ? int.Parse(objectParameter2.Value.ToString() ?? "0") : 0);
				fullRegisterResultViewModel.ProjectId = ((objectParameter3.Value != null) ? int.Parse(objectParameter3.Value.ToString() ?? "0") : 0);
				fullRegisterResultViewModel.ConversationId = ((objectParameter4.Value != null) ? int.Parse(objectParameter4.Value.ToString() ?? "0") : 0);
				data = fullRegisterResultViewModel;
				int companyId = fullRegisterResultViewModel.CompanyId;
				if (companyId != 0)
				{
					string errorMsg = "";
					bool flag8 = OtherSystems.SendCmpToLinkAccByShpIsActive(companyId, model.CenterId.GetValueOrDefault(), model.CenterCode ?? "", ref errorMsg);
				}
				message = MyResource.GetResourceString("SuccessDoneRegister", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				status = ServiceResultStatus.Success;
			}
		}
		catch (Exception ex4)
		{
			string text61 = ((!string.IsNullOrEmpty(ex4.Message)) ? ex4.Message : "");
			if (ex4.InnerException != null && !string.IsNullOrEmpty(ex4.InnerException.Message))
			{
				text61 = text61 + " - " + ex4.InnerException.Message;
			}
			message = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text61)) ? (" (" + text61 + ")") : "");
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(ex4);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<FullRegisterResultViewModel>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<int> ReturnCompanyId(ReturnCompanyIdViewModel model)
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
			int? num2 = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.ApispReturnCompanyId(model.ApiCmpNumber, model.ApiCmpCode));
			int result3 = 0;
			int.TryParse(num2.ToString(), out result3);
			if (result3 > 0)
			{
				message = MyResource.GetResourceString("SuccessDoneRegister", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				status = ServiceResultStatus.Success;
			}
			else
			{
				message = MyResource.GetResourceString("ErrorNotFound", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				status = ServiceResultStatus.Fail;
			}
			data = result3;
		}
		catch (Exception ex)
		{
			string text = ((!string.IsNullOrEmpty(ex.Message)) ? ex.Message : "");
			if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
			{
				text = text + " - " + ex.InnerException.Message;
			}
			message = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text)) ? (" (" + text + ")") : "");
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
	public ServiceResult<int> Insert(InsertCompanyViewModel model)
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
			string text = null;
			if (model.ApiCmpTitleId <= 0)
			{
				model.ApiCmpTitleId = null;
			}
			if (model.ApiCmpGroupId <= 0)
			{
				model.ApiCmpGroupId = null;
			}
			if (model.ApiCmpSubGroupId <= 0)
			{
				model.ApiCmpSubGroupId = null;
			}
			if (model.ApiCmpGroupIdII <= 0)
			{
				model.ApiCmpGroupIdII = null;
			}
			if (model.ApiCmpGroupIdIII <= 0)
			{
				model.ApiCmpGroupIdIII = null;
			}
			if (model.ApiCmpGroupIdIV <= 0)
			{
				model.ApiCmpGroupIdIV = null;
			}
			if (model.ApiCmpTypeId <= 0)
			{
				model.ApiCmpTypeId = null;
			}
			if (model.ApiCmpPresentationId <= 0)
			{
				model.ApiCmpPresentationId = null;
			}
			if (model.ApiCmpCountryId <= 0)
			{
				model.ApiCmpCountryId = null;
			}
			if (model.ApiCmpProvinceId <= 0)
			{
				model.ApiCmpProvinceId = null;
			}
			if (model.ApiCmpCityId <= 0)
			{
				model.ApiCmpCityId = null;
			}
			if (model.ApiCmpReferUserId <= 0)
			{
				model.ApiCmpReferUserId = null;
			}
			if (model.ApiCmpCoordinateLastUserId <= 0)
			{
				model.ApiCmpCoordinateLastUserId = null;
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
			string text2 = "fa-IR";
			ApispSelectLanguages_Result apispSelectLanguages_Result = Enumerable.FirstOrDefault<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result m) => m.LanguageID == currLangId));
			if (apispSelectLanguages_Result != null)
			{
				text2 = apispSelectLanguages_Result.LanguageCollation;
			}
			string text3 = null;
			string text4 = null;
			try
			{
				if (model.ApiCmpEffectiveDateTime.HasValue)
				{
					text3 = (model.ApiCmpEffectiveDateTime ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
				}
			}
			catch (Exception)
			{
				ServiceResult<int> serviceResult = new ServiceResult<int>();
				serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", text2, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CmpEffectiveDate", text2, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
				serviceResult.Data = 0;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			try
			{
				if (model.ApiCmpCoordinateLastDate.HasValue)
				{
					text4 = (model.ApiCmpCoordinateLastDate ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
				}
			}
			catch (Exception)
			{
				ServiceResult<int> serviceResult = new ServiceResult<int>();
				serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", text2, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CmpCoordinateLastDate", text2, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
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
				serviceResult.Message = MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", text2, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", text2, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = 0;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			if (!string.IsNullOrEmpty(model.ApiCmpMobile))
			{
				try
				{
					long.Parse(model.ApiCmpMobile);
				}
				catch
				{
					ServiceResult<int> serviceResult = new ServiceResult<int>();
					serviceResult.Message = string.Format(MyResource.GetResourceString("CheckDigit", text2, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CmpMobile", text2, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly));
					serviceResult.Data = 0;
					serviceResult.Status = ServiceResultStatus.Error;
					return serviceResult;
				}
			}
			if (!string.IsNullOrEmpty(model.ApiCmpTel))
			{
				try
				{
					long.Parse(model.ApiCmpTel);
				}
				catch
				{
					ServiceResult<int> serviceResult = new ServiceResult<int>();
					serviceResult.Message = string.Format(MyResource.GetResourceString("CheckDigit", text2, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CmpTel", text2, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly));
					serviceResult.Data = 0;
					serviceResult.Status = ServiceResultStatus.Error;
					return serviceResult;
				}
			}
			if (!string.IsNullOrEmpty(model.ApiCmpPreTel))
			{
				try
				{
					long.Parse(model.ApiCmpPreTel);
				}
				catch
				{
					ServiceResult<int> serviceResult = new ServiceResult<int>();
					serviceResult.Message = string.Format(MyResource.GetResourceString("CheckDigit", text2, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CmpPreTel", text2, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly));
					serviceResult.Data = 0;
					serviceResult.Status = ServiceResultStatus.Error;
					return serviceResult;
				}
			}
			if (!string.IsNullOrEmpty(model.ApiCmpTelUpTo))
			{
				try
				{
					long.Parse(model.ApiCmpTelUpTo);
				}
				catch
				{
					ServiceResult<int> serviceResult = new ServiceResult<int>();
					serviceResult.Message = string.Format(MyResource.GetResourceString("CheckDigit", text2, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CmpTelUpTo", text2, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly));
					serviceResult.Data = 0;
					serviceResult.Status = ServiceResultStatus.Error;
					return serviceResult;
				}
			}
			if (!string.IsNullOrEmpty(model.ApiCmpTelII))
			{
				try
				{
					long.Parse(model.ApiCmpTelII);
				}
				catch
				{
					ServiceResult<int> serviceResult = new ServiceResult<int>();
					serviceResult.Message = string.Format(MyResource.GetResourceString("CheckDigit", text2, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CmpTelII", text2, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly));
					serviceResult.Data = 0;
					serviceResult.Status = ServiceResultStatus.Error;
					return serviceResult;
				}
			}
			if (!string.IsNullOrEmpty(model.ApiCmpPreTelII))
			{
				try
				{
					long.Parse(model.ApiCmpPreTelII);
				}
				catch
				{
					ServiceResult<int> serviceResult = new ServiceResult<int>();
					serviceResult.Message = string.Format(MyResource.GetResourceString("CheckDigit", text2, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CmpPreTel", text2, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly));
					serviceResult.Data = 0;
					serviceResult.Status = ServiceResultStatus.Error;
					return serviceResult;
				}
			}
			if (!string.IsNullOrEmpty(model.ApiCmpTelUpToII))
			{
				try
				{
					long.Parse(model.ApiCmpTelUpToII);
				}
				catch
				{
					ServiceResult<int> serviceResult = new ServiceResult<int>();
					serviceResult.Message = string.Format(MyResource.GetResourceString("CheckDigit", text2, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CmpTelUpTo", text2, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly));
					serviceResult.Data = 0;
					serviceResult.Status = ServiceResultStatus.Error;
					return serviceResult;
				}
			}
			if (!string.IsNullOrEmpty(model.ApiCmpFax))
			{
				try
				{
					long.Parse(model.ApiCmpFax);
				}
				catch
				{
					ServiceResult<int> serviceResult = new ServiceResult<int>();
					serviceResult.Message = string.Format(MyResource.GetResourceString("CheckDigit", text2, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CmpFax", text2, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly));
					serviceResult.Data = 0;
					serviceResult.Status = ServiceResultStatus.Error;
					return serviceResult;
				}
			}
			if (model.ApiCmpPreTel != null && model.ApiCmpPreTel.Length > 1 && model.ApiCmpPreTel.Substring(0, 2) == "09")
			{
				ServiceResult<int> serviceResult = new ServiceResult<int>();
				serviceResult.Message = MyResource.GetResourceString("CheckPreTelForNotMobile", text2, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = 0;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			if (model.ApiCmpPreTelII != null && model.ApiCmpPreTelII.Length > 1 && model.ApiCmpPreTelII.Substring(0, 2) == "09")
			{
				ServiceResult<int> serviceResult = new ServiceResult<int>();
				serviceResult.Message = MyResource.GetResourceString("CheckPreTelForNotMobile", text2, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = 0;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			if (model.ApiCmpTel != null && model.ApiCmpTel.Length > 1 && model.ApiCmpTel.Substring(0, 2) == "09")
			{
				ServiceResult<int> serviceResult = new ServiceResult<int>();
				serviceResult.Message = MyResource.GetResourceString("CheckPreTelForNotMobile", text2, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = 0;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			if (model.ApiCmpTelII != null && model.ApiCmpTelII.Length > 1 && model.ApiCmpTelII.Substring(0, 2) == "09")
			{
				ServiceResult<int> serviceResult = new ServiceResult<int>();
				serviceResult.Message = MyResource.GetResourceString("CheckPreTelForNotMobile", text2, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = 0;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			if (model.ApiCmpNumber.HasValue)
			{
				ApispCheckDuplicateCompanyNumber_Result apispCheckDuplicateCompanyNumber_Result = Enumerable.FirstOrDefault<ApispCheckDuplicateCompanyNumber_Result>((IEnumerable<ApispCheckDuplicateCompanyNumber_Result>)cRMEntities.ApispCheckDuplicateCompanyNumber(model.ApiCmpNumber, 0, currLangId, result));
				if (apispCheckDuplicateCompanyNumber_Result != null)
				{
					ServiceResult<int> serviceResult = new ServiceResult<int>();
					serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorCmpNumberDuplicate", text2, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), apispCheckDuplicateCompanyNumber_Result.CompanyName ?? "");
					serviceResult.Data = 0;
					serviceResult.Status = ServiceResultStatus.Error;
					return serviceResult;
				}
			}
			if (!string.IsNullOrEmpty(model.ApiCmpCode) && model.CmpCodeNotDup.HasValue && model.CmpCodeNotDup.GetValueOrDefault())
			{
				string text5 = Company.CheckDuplicateCompanyCode(0, model.ApiCmpCode, result, currLangId, text2);
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
				flag4 = ((apispSelectCrmsysSetting_Result2.CantSaveDupCmpNationalCode.HasValue && apispSelectCrmsysSetting_Result2.CantSaveDupCmpNationalCode != false) ? true : false);
				flag5 = ((apispSelectCrmsysSetting_Result2.CantSaveDupCmpEconomicCode.HasValue && apispSelectCrmsysSetting_Result2.CantSaveDupCmpEconomicCode != false) ? true : false);
			}
			if (!string.IsNullOrEmpty(model.ApiCmpTel) && flag && model.CmpTelNotDup.HasValue && model.CmpTelNotDup.GetValueOrDefault())
			{
				string text6 = Company.CantSaveDupTel(model.ApiCmpTel, 1, 0, result, currLangId, text2);
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
			if (!string.IsNullOrEmpty(model.ApiCmpTelII) && flag && model.CmpTelNotDup.HasValue && model.CmpTelNotDup.GetValueOrDefault())
			{
				string text7 = Company.CantSaveDupTel(model.ApiCmpTelII, 1, 0, result, currLangId, text2);
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
			if (!string.IsNullOrEmpty(model.ApiCmpFax) && flag2 && model.CmpFaxNotDup.HasValue && model.CmpFaxNotDup.GetValueOrDefault())
			{
				string text8 = Company.CantSaveDupFax(model.ApiCmpFax, 1, 0, result, currLangId, text2);
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
			if (!string.IsNullOrEmpty(model.ApiCmpZipCode) && flag3)
			{
				string text9 = Company.CantSaveDupZipCode(model.ApiCmpZipCode, 1, 0, result, currLangId, text2);
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
			if (!string.IsNullOrEmpty(model.ApiCmpNationalCode) && flag4)
			{
				string text10 = Company.CantSaveDupCmpNationalCode(model.ApiCmpNationalCode, 0, result, currLangId, text2);
				if (!string.IsNullOrEmpty(text10))
				{
					return new ServiceResult<int>
					{
						Message = text10,
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
			}
			if (!string.IsNullOrEmpty(model.ApiCmpEconomicCode) && flag5)
			{
				string text11 = Company.CantSaveDupCmpEconomicCode(model.ApiCmpEconomicCode, 0, result, currLangId, text2);
				if (!string.IsNullOrEmpty(text11))
				{
					return new ServiceResult<int>
					{
						Message = text11,
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
			}
			if (!string.IsNullOrEmpty(model.ApiCmpEmail))
			{
				string text12 = Company.CantSaveDupCmpEmail(model.ApiCmpEmail, 0, result, currLangId, text2);
				if (!string.IsNullOrEmpty(text12))
				{
					return new ServiceResult<int>
					{
						Message = text12,
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
			}
			if (!string.IsNullOrEmpty(model.ApiCmpMobile))
			{
				if (model.ApiCmpMobile != null)
				{
					if (model.ApiCmpMobile.Length != mobNumLen && !mobNumLenNoCheck)
					{
						ServiceResult<int> serviceResult = new ServiceResult<int>();
						serviceResult.Message = MyResource.GetResourceString("CheckLenMob", text2, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
						serviceResult.Data = 0;
						serviceResult.Status = ServiceResultStatus.Error;
						return serviceResult;
					}
					if (!Regex.IsMatch(model.ApiCmpMobile, "09([0-9])\\d{8}"))
					{
						ServiceResult<int> serviceResult = new ServiceResult<int>();
						serviceResult.Message = MyResource.GetResourceString("CheckMobileFormat", text2, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
						serviceResult.Data = 0;
						serviceResult.Status = ServiceResultStatus.Error;
						return serviceResult;
					}
					if (model.ApiCmpMobile.Length >= 2)
					{
						string text13 = model.ApiCmpMobile.Substring(0, 2);
						if (text13 != "09" && !mobNumLenNoCheck)
						{
							ServiceResult<int> serviceResult = new ServiceResult<int>();
							serviceResult.Message = MyResource.GetResourceString("CheckMobileFormat", text2, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
							serviceResult.Data = 0;
							serviceResult.Status = ServiceResultStatus.Error;
							return serviceResult;
						}
					}
				}
				string text14 = Company.CantSaveDupCmpMobile(model.ApiCmpMobile, 0, result, currLangId, text2);
				if (!string.IsNullOrEmpty(text14))
				{
					return new ServiceResult<int>
					{
						Message = text14,
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
			}
			if (model.ApiCmpPreTel != null && model.ApiCmpPreTel.Length > 1 && model.ApiCmpPreTel.Substring(0, 2) == "09")
			{
				ServiceResult<int> serviceResult = new ServiceResult<int>();
				serviceResult.Message = MyResource.GetResourceString("CheckPreTelForNotMobile", text2, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = 0;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			if (model.ApiCmpPreTelII != null && model.ApiCmpPreTelII.Length > 1 && model.ApiCmpPreTelII.Substring(0, 2) == "09")
			{
				ServiceResult<int> serviceResult = new ServiceResult<int>();
				serviceResult.Message = MyResource.GetResourceString("CheckPreTelForNotMobile", text2, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = 0;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			if (model.ApiCmpTel != null && model.ApiCmpTel.Length > 1 && model.ApiCmpTel.Substring(0, 2) == "09")
			{
				ServiceResult<int> serviceResult = new ServiceResult<int>();
				serviceResult.Message = MyResource.GetResourceString("CheckPreTelForNotMobile", text2, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = 0;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			if (model.ApiCmpTelII != null && model.ApiCmpTelII.Length > 1 && model.ApiCmpTelII.Substring(0, 2) == "09")
			{
				ServiceResult<int> serviceResult = new ServiceResult<int>();
				serviceResult.Message = MyResource.GetResourceString("CheckPreTelForNotMobile", text2, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = 0;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			if (string.IsNullOrEmpty(model.ApiCmpName))
			{
				model.ApiCmpName = MyResource.GetResourceString("Person", text2, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
			}
			int userId = model.UserId;
			DateTime now = DateTime.Now;
			DateTime value = now;
			string text15 = now.ToString("yyyyMMdd", new PersianCulture());
			short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string dubClickDisplayCmpInfo = Messages.DubClickDisplayCmpInfo;
			string appType = CRMIdealApi.Classes.Configuration.AppType;
			short num2 = short.Parse(now.ToString("yyyy", new PersianCulture()));
			CommonClass commonClass = new CommonClass();
			string text16 = commonClass.ConvertNameToDayNum(now.DayOfWeek.ToString());
			string text17 = now.ToString("HH:mm:ss");
			string resourceString = MyResource.GetResourceString("Person", text2, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
			if (!string.IsNullOrEmpty(model.ApiCmpPassword))
			{
				model.ApiCmpPassword = ((!string.IsNullOrEmpty(model.ApiCmpPassword)) ? XorCipher.EncryptByPublicKey(model.ApiCmpPassword) : null);
			}
			ObjectParameter objectParameter = new ObjectParameter("InsertedCompanyId", 0);
			ObjectParameter objectParameter2 = new ObjectParameter("ErrorMessage", "");
			CRMEntities cRMEntities2 = cRMEntities;
			int? apiCmpNumber = model.ApiCmpNumber;
			string apiCmpName = model.ApiCmpName;
			string apiCmpNameEng = model.ApiCmpNameEng;
			int? apiCmpTitleId = model.ApiCmpTitleId;
			string apiCmpFame = model.ApiCmpFame;
			string apiCmpActivityType = model.ApiCmpActivityType;
			int? apiCmpGroupId = model.ApiCmpGroupId;
			int? apiCmpSubGroupId = model.ApiCmpSubGroupId;
			int? apiCmpGroupIdII = model.ApiCmpGroupIdII;
			int? apiCmpGroupIdIII = model.ApiCmpGroupIdIII;
			int? apiCmpGroupIdIV = model.ApiCmpGroupIdIV;
			int? apiCmpTypeId = model.ApiCmpTypeId;
			int? apiCmpPresentationId = model.ApiCmpPresentationId;
			string apiCmpPreTel = model.ApiCmpPreTel;
			string apiCmpTel = model.ApiCmpTel;
			string apiCmpTelUpTo = model.ApiCmpTelUpTo;
			string apiCmpTelDesc = model.ApiCmpTelDesc;
			string apiCmpPreTelII = model.ApiCmpPreTelII;
			string apiCmpTelII = model.ApiCmpTelII;
			string apiCmpTelUpToII = model.ApiCmpTelUpToII;
			string apiCmpTelIIDesc = model.ApiCmpTelIIDesc;
			string apiCmpMobile = model.ApiCmpMobile;
			string apiCmpFax = model.ApiCmpFax;
			string apiCmpFaxDesc = model.ApiCmpFaxDesc;
			int? apiCmpCountryId = model.ApiCmpCountryId;
			int? apiCmpProvinceId = model.ApiCmpProvinceId;
			int? apiCmpCityId = model.ApiCmpCityId;
			string apiCmpAddress = model.ApiCmpAddress;
			string apiCmpAddressDesc = model.ApiCmpAddressDesc;
			string apiCmpZipCode = model.ApiCmpZipCode;
			string apiCmpPostBox = model.ApiCmpPostBox;
			string apiCmpWebSite = model.ApiCmpWebSite;
			string apiCmpEmail = model.ApiCmpEmail;
			string apiCmpInteresting = model.ApiCmpInteresting;
			string apiCmpSpecialPoint = model.ApiCmpSpecialPoint;
			string apiCmpDescription = model.ApiCmpDescription;
			string apiCmpUserName = model.ApiCmpUserName;
			string apiCmpPassword = model.ApiCmpPassword;
			string apiCmpRegistrationNumber = model.ApiCmpRegistrationNumber;
			string apiCmpEconomicCode = model.ApiCmpEconomicCode;
			string apiCmpNationalCode = model.ApiCmpNationalCode;
			string apiCmpBuyLimit = model.ApiCmpBuyLimit;
			string apiCmpAccountNumber = model.ApiCmpAccountNumber;
			string apiCmpAccInquiry = model.ApiCmpAccInquiry;
			string apiCmpFreight = model.ApiCmpFreight;
			string apiCmpInquiry = model.ApiCmpInquiry;
			int? apiCmpReferUserId = model.ApiCmpReferUserId;
			string apiCmpSpecialWordForCI = model.ApiCmpSpecialWordForCI;
			string apiCmpCode = model.ApiCmpCode;
			string cmpEffectiveDatePersian = text3;
			DateTime? apiCmpEffectiveDateTime = model.ApiCmpEffectiveDateTime;
			string apiCmpCoordinateLatitude = model.ApiCmpCoordinateLatitude;
			string apiCmpCoordinateLongitude = model.ApiCmpCoordinateLongitude;
			string text18 = text4;
			int? num3 = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities2.ApispInsertCompany(cmpCoordinateLastDate: model.ApiCmpCoordinateLastDate, cmpCoordinateLastDatePersian: text18, cmpCoordinateZoomLevel: model.ApiCmpCoordinateZoomLevel, cmpCoordinateLastUserId: model.ApiCmpCoordinateLastUserId, cmpFOAccessLinkedCompany: model.ApiCmpFOAccessLinkedCompany, userId: userId, month1: value2, registerDate: value, registerDatePersian: text15, appType: appType, insertedCompanyId: objectParameter, errorMessage: objectParameter2, personLabel: resourceString, cmpCodeNotDup: model.CmpCodeNotDup, cmpCampaignIds: model.ApiCmpCampaignIds, cmpCampaignName: model.ApiCmpCampaignName, cmpNameOfficial: model.ApiCmpNameOfficial, cmpKind: model.ApiCmpKind, centerId: model.CenterId, centerCode: model.CenterCode, cmpLinkAccCodeId: model.ApiCmpLinkAccCodeId, cmpLinkAccCode: model.ApiCmpLinkAccCode, cmpLinkAccCustomerId: model.ApiCmpLinkAccCustomerId, cmpLinkAccCustomerIdStr: model.ApiCmpLinkAccCustomerIdStr, cmpLinkAccFirstTransferDate: model.ApiCmpLinkAccFirstTransferDate, cmpLinkAccLastTransferDate: model.ApiCmpLinkAccLastTransferDate, cmpLinkAccData: model.ApiCmpLinkAccData, cmpSuppUserId: model.ApiCmpSuppUserId, tspCmpBpn: model.ApiTspCmpBpn, cmpNumber: apiCmpNumber, cmpName: apiCmpName, cmpNameEng: apiCmpNameEng, cmpTitleId: apiCmpTitleId, cmpFame: apiCmpFame, cmpActivityType: apiCmpActivityType, cmpGroupId: apiCmpGroupId, cmpSubGroupId: apiCmpSubGroupId, cmpGroupIdII: apiCmpGroupIdII, cmpGroupIdIII: apiCmpGroupIdIII, cmpGroupIdIV: apiCmpGroupIdIV, cmpTypeId: apiCmpTypeId, cmpPresentationId: apiCmpPresentationId, cmpPreTel: apiCmpPreTel, cmpTel: apiCmpTel, cmpTelUpTo: apiCmpTelUpTo, cmpTelDesc: apiCmpTelDesc, cmpPreTelII: apiCmpPreTelII, cmpTelII: apiCmpTelII, cmpTelUpToII: apiCmpTelUpToII, cmpTelIIDesc: apiCmpTelIIDesc, cmpMobile: apiCmpMobile, cmpFax: apiCmpFax, cmpFaxDesc: apiCmpFaxDesc, cmpCountryId: apiCmpCountryId, cmpProvinceId: apiCmpProvinceId, cmpCityId: apiCmpCityId, cmpAddress: apiCmpAddress, cmpAddressDesc: apiCmpAddressDesc, cmpZipCode: apiCmpZipCode, cmpPostBox: apiCmpPostBox, cmpWebSite: apiCmpWebSite, cmpEmail: apiCmpEmail, cmpInteresting: apiCmpInteresting, cmpSpecialPoint: apiCmpSpecialPoint, cmpDescription: apiCmpDescription, cmpUserName: apiCmpUserName, cmpPassword: apiCmpPassword, cmpRegistrationNumber: apiCmpRegistrationNumber, cmpEconomicCode: apiCmpEconomicCode, cmpNationalCode: apiCmpNationalCode, cmpBuyLimit: apiCmpBuyLimit, cmpAccountNumber: apiCmpAccountNumber, cmpAccInquiry: apiCmpAccInquiry, cmpFreight: apiCmpFreight, cmpInquiry: apiCmpInquiry, cmpReferUserId: apiCmpReferUserId, cmpSpecialWordForCI: apiCmpSpecialWordForCI, cmpCode: apiCmpCode, cmpEffectiveDatePersian: cmpEffectiveDatePersian, cmpEffectiveDateTime: apiCmpEffectiveDateTime, cmpCoordinateLatitude: apiCmpCoordinateLatitude, cmpCoordinateLongitude: apiCmpCoordinateLongitude, tspCmpBbc: model.ApiTspCmpBbc, tspCmpTob: model.ApiTspCmpTob, cmpOfficialTel: model.ApiCmpOfficialTel, cmpOfficialCityId: model.ApiCmpOfficialCityId, cmpOfficialAddress: model.ApiCmpOfficialAddress, cmpOfficialZipCode: model.ApiCmpOfficialZipCode, cmpOfficialDesc: model.ApiCmpOfficialDesc));
			string resourceString2 = MyResource.GetResourceString("ErrorDoneOperationTryAgain", text2, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
			string resourceString3 = MyResource.GetResourceString("ErrorTryAgain", text2, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
			int result3 = 0;
			int.TryParse(num3.ToString(), out result3);
			if (result3 <= 0)
			{
				return new ServiceResult<int>
				{
					Message = resourceString2.Replace("<br>", "\r\n"),
					Data = 0,
					Status = ServiceResultStatus.Error
				};
			}
			if (objectParameter2.Value != null && objectParameter2.Value.ToString() != "")
			{
				string text19 = "";
				string text20 = "";
				string text21 = objectParameter2.Value.ToString();
				if (text21.IndexOf("IsUser=0", StringComparison.Ordinal) >= 0)
				{
					text19 = text19 + MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", text2, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "<br>";
					resourceString3 = "<br>" + MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", text2, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + resourceString3;
					return new ServiceResult<int>
					{
						Message = resourceString3.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text21.IndexOf("DupUName=1", StringComparison.Ordinal) >= 0)
				{
					text19 = text19 + MyResource.GetResourceString("ErrorUsernameIsRepeat", text2, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "<br>";
					resourceString3 = "<br>" + MyResource.GetResourceString("ErrorUsernameIsRepeat", text2, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + resourceString3;
					return new ServiceResult<int>
					{
						Message = resourceString3.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text21.IndexOf("DupCmpCode=", StringComparison.Ordinal) >= 0)
				{
					string[] array = text21.Split(new char[1] { '|' });
					string arg = "";
					if (array != null)
					{
						string[] array2 = array;
						foreach (string text22 in array2)
						{
							if (!string.IsNullOrEmpty(text22) && text22.IndexOf("DupCmpCode=", StringComparison.Ordinal) >= 0)
							{
								string[] array3 = text22.Split(new char[1] { '=' });
								if (array3 != null && array3.Length == 2)
								{
									arg = ((array3[1] != null && array3[1] != "") ? array3[1] : "");
								}
							}
						}
					}
					text19 = text19 + string.Format(MyResource.GetResourceString("ErrorCheckCmpCodeDuplicate", text2, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), model.ApiCmpCode, arg) + "<br>";
					return new ServiceResult<int>
					{
						Message = text19.Replace("<br>", "\r\n") + "\r\n" + resourceString3.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text21.IndexOf("DupCmp=", StringComparison.Ordinal) >= 0)
				{
					string[] array4 = text21.Split(new char[1] { '|' });
					string arg2 = "";
					if (array4 != null)
					{
						string[] array5 = array4;
						foreach (string text23 in array5)
						{
							if (!string.IsNullOrEmpty(text23) && text23.IndexOf("DupCmp=", StringComparison.Ordinal) >= 0)
							{
								string[] array6 = text23.Split(new char[1] { '=' });
								if (array6 != null && array6.Length == 2)
								{
									arg2 = ((array6[1] != null && array6[1] != "") ? array6[1] : "");
								}
							}
						}
					}
					text19 = text19 + string.Format(MyResource.GetResourceString("ErrorCheckCmpNameDuplicate", text2, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), arg2) + "<br>";
					return new ServiceResult<int>
					{
						Message = text19.Replace("<br>", "\r\n") + "\r\n" + resourceString3.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text21.IndexOf("No Center|", StringComparison.Ordinal) >= 0)
				{
					text20 = text20 + MyResource.GetResourceString("msgErrorCenterNotFound", text2, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + resourceString3;
					return new ServiceResult<int>
					{
						Message = text20.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text21.IndexOf("No CmpTitleId|", StringComparison.Ordinal) >= 0)
				{
					text20 = text20 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", text2, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CmpTitle", text2, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString3;
					return new ServiceResult<int>
					{
						Message = text20.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text21.IndexOf("No CmpGroupId|", StringComparison.Ordinal) >= 0)
				{
					text20 = text20 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", text2, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CmpGroup", text2, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString3;
					return new ServiceResult<int>
					{
						Message = text20.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text21.IndexOf("No CmpSubGroupId|", StringComparison.Ordinal) >= 0)
				{
					text20 = text20 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", text2, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CmpSubGroup", text2, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString3;
					return new ServiceResult<int>
					{
						Message = text20.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text21.IndexOf("No CmpGroupIdII|", StringComparison.Ordinal) >= 0)
				{
					text20 = text20 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", text2, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CmpGroupII", text2, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString3;
					return new ServiceResult<int>
					{
						Message = text20.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text21.IndexOf("No CmpGroupIdIII|", StringComparison.Ordinal) >= 0)
				{
					text20 = text20 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", text2, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CmpGroupIII", text2, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString3;
					return new ServiceResult<int>
					{
						Message = text20.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text21.IndexOf("No CmpGroupIdIV|", StringComparison.Ordinal) >= 0)
				{
					text20 = text20 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", text2, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CmpGroupIV", text2, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString3;
					return new ServiceResult<int>
					{
						Message = text20.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text21.IndexOf("No CmpTypeId|", StringComparison.Ordinal) >= 0)
				{
					text20 = text20 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", text2, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CmpType", text2, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString3;
					return new ServiceResult<int>
					{
						Message = text20.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text21.IndexOf("No CmpPresentationId|", StringComparison.Ordinal) >= 0)
				{
					text20 = text20 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", text2, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CmpPresentation", text2, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString3;
					return new ServiceResult<int>
					{
						Message = text20.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text21.IndexOf("No CmpCountryId|", StringComparison.Ordinal) >= 0)
				{
					text20 = text20 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", text2, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CmpCountry", text2, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString3;
					return new ServiceResult<int>
					{
						Message = text20.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text21.IndexOf("No CmpProvinceId|", StringComparison.Ordinal) >= 0)
				{
					text20 = text20 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", text2, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CmpProvince", text2, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString3;
					return new ServiceResult<int>
					{
						Message = text20.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text21.IndexOf("No CmpCityId|", StringComparison.Ordinal) >= 0)
				{
					text20 = text20 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", text2, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CmpCity", text2, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString3;
					return new ServiceResult<int>
					{
						Message = text20.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text21.IndexOf("No CmpCoordinateLastUserId|", StringComparison.Ordinal) >= 0)
				{
					text20 = text20 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", text2, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CmpCoordinateLastUser", text2, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString3;
					return new ServiceResult<int>
					{
						Message = text20.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text21.IndexOf("No CmpReferUserId|", StringComparison.Ordinal) >= 0)
				{
					text20 = text20 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", text2, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CmpReferUser", text2, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString3;
					return new ServiceResult<int>
					{
						Message = text20.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text21.IndexOf("No CmpOfficialCityId|", StringComparison.Ordinal) >= 0)
				{
					text20 = text20 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", text2, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CmpOfficialCity", text2, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString3;
					return new ServiceResult<int>
					{
						Message = text20.Replace("<br>", "\r\n"),
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
					serviceResult.Message = (MyResource.GetResourceString("ErrorDoneOperation", text2, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "<br>" + resourceString2).Replace("<br>", "\r\n");
					serviceResult.Data = 0;
					serviceResult.Status = ServiceResultStatus.Fail;
					return serviceResult;
				}
				data = ((objectParameter.Value != null) ? int.Parse(objectParameter.Value.ToString() ?? "0") : 0);
				message = MyResource.GetResourceString("SuccessDoneRegister", text2, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				status = ServiceResultStatus.Success;
			}
		}
		catch (Exception ex3)
		{
			string text24 = ((!string.IsNullOrEmpty(ex3.Message)) ? ex3.Message : "");
			if (ex3.InnerException != null && !string.IsNullOrEmpty(ex3.InnerException.Message))
			{
				text24 = text24 + " - " + ex3.InnerException.Message;
			}
			message = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text24)) ? (" (" + text24 + ")") : "");
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
	public ServiceResult<int> Update(UpdateCompanyViewModel model)
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
			string text = null;
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
			int mobNumLen = Setting.GetMobNumLen();
			bool mobNumLenNoCheck = Setting.GetMobNumLenNoCheck();
			List<ApispSelectLanguages_Result> list = Enumerable.ToList<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)cRMEntities.ApispSelectLanguages());
			string text2 = "fa-IR";
			ApispSelectLanguages_Result apispSelectLanguages_Result = Enumerable.FirstOrDefault<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result m) => m.LanguageID == currLangId));
			if (apispSelectLanguages_Result != null)
			{
				text2 = apispSelectLanguages_Result.LanguageCollation;
			}
			string text3 = null;
			string text4 = null;
			if (!string.IsNullOrEmpty(model.ApiCmpEffectiveDatePersian) && model.ApiCmpEffectiveDatePersian.ToLower() == "null")
			{
				text3 = model.ApiCmpEffectiveDatePersian;
				model.ApiCmpEffectiveDateTime = null;
			}
			else
			{
				try
				{
					if (model.ApiCmpEffectiveDateTime.HasValue)
					{
						text3 = (model.ApiCmpEffectiveDateTime ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
					}
				}
				catch (Exception)
				{
					ServiceResult<int> serviceResult = new ServiceResult<int>();
					serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", text2, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CmpEffectiveDate", text2, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
					serviceResult.Data = 0;
					serviceResult.Status = ServiceResultStatus.Error;
					return serviceResult;
				}
			}
			if (!string.IsNullOrEmpty(model.ApiCmpCoordinateLastDatePersian) && model.ApiCmpCoordinateLastDatePersian.ToLower() == "null")
			{
				text4 = model.ApiCmpCoordinateLastDatePersian;
			}
			else
			{
				try
				{
					if (model.ApiCmpCoordinateLastDate.HasValue)
					{
						text4 = (model.ApiCmpCoordinateLastDate ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
					}
				}
				catch (Exception)
				{
					ServiceResult<int> serviceResult = new ServiceResult<int>();
					serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", text2, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CmpCoordinateLastDate", text2, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
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
				serviceResult.Message = MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", text2, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", text2, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = 0;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			if (model.ApiCompanyId <= 0)
			{
				ServiceResult<int> serviceResult = new ServiceResult<int>();
				serviceResult.Message = MyResource.GetResourceString("ErrorNotFound", text2, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = 0;
				serviceResult.Status = ServiceResultStatus.Fail;
				return serviceResult;
			}
			if (!string.IsNullOrEmpty(model.ApiCmpMobile))
			{
				try
				{
					long.Parse(model.ApiCmpMobile);
				}
				catch
				{
					ServiceResult<int> serviceResult = new ServiceResult<int>();
					serviceResult.Message = string.Format(MyResource.GetResourceString("CheckDigit", text2, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CmpMobile", text2, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly));
					serviceResult.Data = 0;
					serviceResult.Status = ServiceResultStatus.Error;
					return serviceResult;
				}
			}
			if (!string.IsNullOrEmpty(model.ApiCmpTel))
			{
				try
				{
					long.Parse(model.ApiCmpTel);
				}
				catch
				{
					ServiceResult<int> serviceResult = new ServiceResult<int>();
					serviceResult.Message = string.Format(MyResource.GetResourceString("CheckDigit", text2, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CmpTel", text2, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly));
					serviceResult.Data = 0;
					serviceResult.Status = ServiceResultStatus.Error;
					return serviceResult;
				}
			}
			if (!string.IsNullOrEmpty(model.ApiCmpPreTel))
			{
				try
				{
					long.Parse(model.ApiCmpPreTel);
				}
				catch
				{
					ServiceResult<int> serviceResult = new ServiceResult<int>();
					serviceResult.Message = string.Format(MyResource.GetResourceString("CheckDigit", text2, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CmpPreTel", text2, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly));
					serviceResult.Data = 0;
					serviceResult.Status = ServiceResultStatus.Error;
					return serviceResult;
				}
			}
			if (!string.IsNullOrEmpty(model.ApiCmpTelUpTo))
			{
				try
				{
					long.Parse(model.ApiCmpTelUpTo);
				}
				catch
				{
					ServiceResult<int> serviceResult = new ServiceResult<int>();
					serviceResult.Message = string.Format(MyResource.GetResourceString("CheckDigit", text2, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CmpTelUpTo", text2, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly));
					serviceResult.Data = 0;
					serviceResult.Status = ServiceResultStatus.Error;
					return serviceResult;
				}
			}
			if (!string.IsNullOrEmpty(model.ApiCmpTelII))
			{
				try
				{
					long.Parse(model.ApiCmpTelII);
				}
				catch
				{
					ServiceResult<int> serviceResult = new ServiceResult<int>();
					serviceResult.Message = string.Format(MyResource.GetResourceString("CheckDigit", text2, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CmpTelII", text2, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly));
					serviceResult.Data = 0;
					serviceResult.Status = ServiceResultStatus.Error;
					return serviceResult;
				}
			}
			if (!string.IsNullOrEmpty(model.ApiCmpPreTelII))
			{
				try
				{
					long.Parse(model.ApiCmpPreTelII);
				}
				catch
				{
					ServiceResult<int> serviceResult = new ServiceResult<int>();
					serviceResult.Message = string.Format(MyResource.GetResourceString("CheckDigit", text2, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CmpPreTel", text2, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly));
					serviceResult.Data = 0;
					serviceResult.Status = ServiceResultStatus.Error;
					return serviceResult;
				}
			}
			if (!string.IsNullOrEmpty(model.ApiCmpTelUpToII))
			{
				try
				{
					long.Parse(model.ApiCmpTelUpToII);
				}
				catch
				{
					ServiceResult<int> serviceResult = new ServiceResult<int>();
					serviceResult.Message = string.Format(MyResource.GetResourceString("CheckDigit", text2, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CmpTelUpTo", text2, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly));
					serviceResult.Data = 0;
					serviceResult.Status = ServiceResultStatus.Error;
					return serviceResult;
				}
			}
			if (!string.IsNullOrEmpty(model.ApiCmpFax))
			{
				try
				{
					long.Parse(model.ApiCmpFax);
				}
				catch
				{
					ServiceResult<int> serviceResult = new ServiceResult<int>();
					serviceResult.Message = string.Format(MyResource.GetResourceString("CheckDigit", text2, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CmpFax", text2, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly));
					serviceResult.Data = 0;
					serviceResult.Status = ServiceResultStatus.Error;
					return serviceResult;
				}
			}
			if (model.ApiCmpPreTel != null && model.ApiCmpPreTel.Length > 1 && model.ApiCmpPreTel.Substring(0, 2) == "09")
			{
				ServiceResult<int> serviceResult = new ServiceResult<int>();
				serviceResult.Message = MyResource.GetResourceString("CheckPreTelForNotMobile", text2, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = 0;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			if (model.ApiCmpPreTelII != null && model.ApiCmpPreTelII.Length > 1 && model.ApiCmpPreTelII.Substring(0, 2) == "09")
			{
				ServiceResult<int> serviceResult = new ServiceResult<int>();
				serviceResult.Message = MyResource.GetResourceString("CheckPreTelForNotMobile", text2, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = 0;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			if (model.ApiCmpTel != null && model.ApiCmpTel.Length > 1 && model.ApiCmpTel.Substring(0, 2) == "09")
			{
				ServiceResult<int> serviceResult = new ServiceResult<int>();
				serviceResult.Message = MyResource.GetResourceString("CheckPreTelForNotMobile", text2, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = 0;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			if (model.ApiCmpTelII != null && model.ApiCmpTelII.Length > 1 && model.ApiCmpTelII.Substring(0, 2) == "09")
			{
				ServiceResult<int> serviceResult = new ServiceResult<int>();
				serviceResult.Message = MyResource.GetResourceString("CheckPreTelForNotMobile", text2, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = 0;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			if (model.ApiCmpNumber.HasValue)
			{
				ApispCheckDuplicateCompanyNumber_Result apispCheckDuplicateCompanyNumber_Result = Enumerable.FirstOrDefault<ApispCheckDuplicateCompanyNumber_Result>((IEnumerable<ApispCheckDuplicateCompanyNumber_Result>)cRMEntities.ApispCheckDuplicateCompanyNumber(model.ApiCmpNumber, model.ApiCompanyId, currLangId, result));
				if (apispCheckDuplicateCompanyNumber_Result != null)
				{
					ServiceResult<int> serviceResult = new ServiceResult<int>();
					serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorCmpNumberDuplicate", text2, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), apispCheckDuplicateCompanyNumber_Result.CompanyName ?? "");
					serviceResult.Data = 0;
					serviceResult.Status = ServiceResultStatus.Error;
					return serviceResult;
				}
			}
			if (!string.IsNullOrEmpty(model.ApiCmpCode) && model.CmpCodeNotDup.HasValue && model.CmpCodeNotDup.GetValueOrDefault())
			{
				string text5 = Company.CheckDuplicateCompanyCode(model.ApiCompanyId, model.ApiCmpCode, result, currLangId, text2);
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
				flag4 = ((apispSelectCrmsysSetting_Result2.CantSaveDupCmpNationalCode.HasValue && apispSelectCrmsysSetting_Result2.CantSaveDupCmpNationalCode != false) ? true : false);
				flag5 = ((apispSelectCrmsysSetting_Result2.CantSaveDupCmpEconomicCode.HasValue && apispSelectCrmsysSetting_Result2.CantSaveDupCmpEconomicCode != false) ? true : false);
			}
			if (!string.IsNullOrEmpty(model.ApiCmpTel) && flag && model.CmpTelNotDup.HasValue && model.CmpTelNotDup.GetValueOrDefault())
			{
				string text6 = Company.CantSaveDupTel(model.ApiCmpTel, 1, model.ApiCompanyId, result, currLangId, text2);
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
			if (!string.IsNullOrEmpty(model.ApiCmpTelII) && flag && model.CmpTelNotDup.HasValue && model.CmpTelNotDup.GetValueOrDefault())
			{
				string text7 = Company.CantSaveDupTel(model.ApiCmpTelII, 1, model.ApiCompanyId, result, currLangId, text2);
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
			if (!string.IsNullOrEmpty(model.ApiCmpFax) && flag2 && model.CmpFaxNotDup.HasValue && model.CmpFaxNotDup.GetValueOrDefault())
			{
				string text8 = Company.CantSaveDupFax(model.ApiCmpFax, 1, model.ApiCompanyId, result, currLangId, text2);
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
			if (!string.IsNullOrEmpty(model.ApiCmpZipCode) && flag3)
			{
				string text9 = Company.CantSaveDupZipCode(model.ApiCmpZipCode, 1, model.ApiCompanyId, result, currLangId, text2);
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
			if (!string.IsNullOrEmpty(model.ApiCmpNationalCode) && flag4)
			{
				string text10 = Company.CantSaveDupCmpNationalCode(model.ApiCmpNationalCode, model.ApiCompanyId, result, currLangId, text2);
				if (!string.IsNullOrEmpty(text10))
				{
					return new ServiceResult<int>
					{
						Message = text10,
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
			}
			if (!string.IsNullOrEmpty(model.ApiCmpEconomicCode) && flag5)
			{
				string text11 = Company.CantSaveDupCmpEconomicCode(model.ApiCmpEconomicCode, model.ApiCompanyId, result, currLangId, text2);
				if (!string.IsNullOrEmpty(text11))
				{
					return new ServiceResult<int>
					{
						Message = text11,
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
			}
			if (!string.IsNullOrEmpty(model.ApiCmpEmail))
			{
				string text12 = Company.CantSaveDupCmpEmail(model.ApiCmpEmail, model.ApiCompanyId, result, currLangId, text2);
				if (!string.IsNullOrEmpty(text12))
				{
					return new ServiceResult<int>
					{
						Message = text12,
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
			}
			if (!string.IsNullOrEmpty(model.ApiCmpMobile))
			{
				if (model.ApiCmpMobile != null)
				{
					if (model.ApiCmpMobile.Length != mobNumLen && !mobNumLenNoCheck)
					{
						ServiceResult<int> serviceResult = new ServiceResult<int>();
						serviceResult.Message = MyResource.GetResourceString("CheckLenMob", text2, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
						serviceResult.Data = 0;
						serviceResult.Status = ServiceResultStatus.Error;
						return serviceResult;
					}
					if (model.ApiCmpMobile.Length >= 2)
					{
						string text13 = model.ApiCmpMobile.Substring(0, 2);
						if (text13 != "09" && !mobNumLenNoCheck)
						{
							ServiceResult<int> serviceResult = new ServiceResult<int>();
							serviceResult.Message = MyResource.GetResourceString("CheckMobileFormat", text2, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
							serviceResult.Data = 0;
							serviceResult.Status = ServiceResultStatus.Error;
							return serviceResult;
						}
					}
				}
				string text14 = Company.CantSaveDupCmpMobile(model.ApiCmpMobile, model.ApiCompanyId, result, currLangId, text2);
				if (!string.IsNullOrEmpty(text14))
				{
					return new ServiceResult<int>
					{
						Message = text14,
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
			}
			int userId = model.UserId;
			DateTime now = DateTime.Now;
			DateTime value = now;
			string text15 = now.ToString("yyyyMMdd", new PersianCulture());
			short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string dubClickDisplayCmpInfo = Messages.DubClickDisplayCmpInfo;
			string appType = CRMIdealApi.Classes.Configuration.AppType;
			short num2 = short.Parse(now.ToString("yyyy", new PersianCulture()));
			CommonClass commonClass = new CommonClass();
			string text16 = commonClass.ConvertNameToDayNum(now.DayOfWeek.ToString());
			string text17 = now.ToString("HH:mm:ss");
			string resourceString = MyResource.GetResourceString("Person", text2, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
			if (!string.IsNullOrEmpty(model.ApiCmpPassword))
			{
				ApispSelectCompany_Result apispSelectCompany_Result = Enumerable.FirstOrDefault<ApispSelectCompany_Result>((IEnumerable<ApispSelectCompany_Result>)cRMEntities.ApispSelectCompany(model.ApiCompanyId, null, null, null, null, null, null, currLangId, result, null, null, 0, 0));
				if (apispSelectCompany_Result != null)
				{
					model.ApiCmpPassword = ((!string.IsNullOrEmpty(model.ApiCmpPassword)) ? model.ApiCmpPassword : null);
					string text18 = ((!string.IsNullOrEmpty(model.ApiCmpPassword)) ? XorCipher.EncryptByPublicKey(model.ApiCmpPassword) : null);
					string text19 = ((!string.IsNullOrEmpty(apispSelectCompany_Result.ApiCmpPassword)) ? XorCipher.DecryptByPublicKey(apispSelectCompany_Result.ApiCmpPassword) : null);
					bool flag6 = text18 == apispSelectCompany_Result.ApiCmpPassword;
					bool flag7 = model.ApiCmpPassword == apispSelectCompany_Result.ApiCmpPassword;
					if (!flag6 && !flag7)
					{
						model.ApiCmpPassword = text18;
					}
					else
					{
						model.ApiCmpPassword = null;
					}
				}
			}
			ObjectParameter objectParameter = new ObjectParameter("ErrorMessage", "");
			CRMEntities cRMEntities2 = cRMEntities;
			int? companyID = model.ApiCompanyId;
			int? apiCmpNumber = model.ApiCmpNumber;
			string apiCmpName = model.ApiCmpName;
			string apiCmpNameEng = model.ApiCmpNameEng;
			int? apiCmpTitleId = model.ApiCmpTitleId;
			string apiCmpFame = model.ApiCmpFame;
			string apiCmpActivityType = model.ApiCmpActivityType;
			int? apiCmpGroupId = model.ApiCmpGroupId;
			int? apiCmpSubGroupId = model.ApiCmpSubGroupId;
			int? apiCmpGroupIdII = model.ApiCmpGroupIdII;
			int? apiCmpGroupIdIII = model.ApiCmpGroupIdIII;
			int? apiCmpGroupIdIV = model.ApiCmpGroupIdIV;
			int? apiCmpTypeId = model.ApiCmpTypeId;
			int? apiCmpPresentationId = model.ApiCmpPresentationId;
			string apiCmpPreTel = model.ApiCmpPreTel;
			string apiCmpTel = model.ApiCmpTel;
			string apiCmpTelUpTo = model.ApiCmpTelUpTo;
			string apiCmpTelDesc = model.ApiCmpTelDesc;
			string apiCmpPreTelII = model.ApiCmpPreTelII;
			string apiCmpTelII = model.ApiCmpTelII;
			string apiCmpTelUpToII = model.ApiCmpTelUpToII;
			string apiCmpTelIIDesc = model.ApiCmpTelIIDesc;
			string apiCmpMobile = model.ApiCmpMobile;
			string apiCmpFax = model.ApiCmpFax;
			string apiCmpFaxDesc = model.ApiCmpFaxDesc;
			int? apiCmpCountryId = model.ApiCmpCountryId;
			int? apiCmpProvinceId = model.ApiCmpProvinceId;
			int? apiCmpCityId = model.ApiCmpCityId;
			string apiCmpAddress = model.ApiCmpAddress;
			string apiCmpAddressDesc = model.ApiCmpAddressDesc;
			string apiCmpZipCode = model.ApiCmpZipCode;
			string apiCmpPostBox = model.ApiCmpPostBox;
			string apiCmpWebSite = model.ApiCmpWebSite;
			string apiCmpEmail = model.ApiCmpEmail;
			string apiCmpInteresting = model.ApiCmpInteresting;
			string apiCmpSpecialPoint = model.ApiCmpSpecialPoint;
			string apiCmpDescription = model.ApiCmpDescription;
			string apiCmpUserName = model.ApiCmpUserName;
			string apiCmpPassword = model.ApiCmpPassword;
			string apiCmpRegistrationNumber = model.ApiCmpRegistrationNumber;
			string apiCmpEconomicCode = model.ApiCmpEconomicCode;
			string apiCmpNationalCode = model.ApiCmpNationalCode;
			string apiCmpBuyLimit = model.ApiCmpBuyLimit;
			string apiCmpAccountNumber = model.ApiCmpAccountNumber;
			string apiCmpAccInquiry = model.ApiCmpAccInquiry;
			string apiCmpFreight = model.ApiCmpFreight;
			string apiCmpInquiry = model.ApiCmpInquiry;
			int? apiCmpReferUserId = model.ApiCmpReferUserId;
			string apiCmpSpecialWordForCI = model.ApiCmpSpecialWordForCI;
			string apiCmpCode = model.ApiCmpCode;
			string cmpEffectiveDatePersian = text3;
			DateTime? apiCmpEffectiveDateTime = model.ApiCmpEffectiveDateTime;
			string apiCmpCoordinateLatitude = model.ApiCmpCoordinateLatitude;
			string apiCmpCoordinateLongitude = model.ApiCmpCoordinateLongitude;
			string text20 = text4;
			int num3 = cRMEntities2.ApispUpdateCompany(cmpCoordinateLastDate: model.ApiCmpCoordinateLastDate, cmpCoordinateLastDatePersian: text20, cmpCoordinateZoomLevel: model.ApiCmpCoordinateZoomLevel, cmpCoordinateLastUserId: model.ApiCmpCoordinateLastUserId, cmpIsDraft: model.ApiCmpIsDraft, cmpKind: model.ApiCmpKind, cmpMainPersonId: model.ApiCmpMainPersonId, addType: null, cmpFOAccessLinkedCompany: model.ApiCmpFOAccessLinkedCompany, userId: userId, year1: (short)1, month1: value2, registerDate: value, registerDatePersian: text15, appType: appType, errorMessage: objectParameter, personLabel: resourceString, cmpCodeNotDup: model.CmpCodeNotDup, languageID: currLangId, defaultLanguageID: result, cmpCampaignIds: model.ApiCmpCampaignIds, cmpCampaignName: model.ApiCmpCampaignName, cmpNameOfficial: model.ApiCmpNameOfficial, cmpSuppUserId: model.ApiCmpSuppUserId, centerId: model.CenterId, centerCode: model.CenterCode, tspCmpBpn: model.ApiTspCmpBpn, companyID: companyID, cmpNumber: apiCmpNumber, cmpName: apiCmpName, cmpNameEng: apiCmpNameEng, cmpTitleId: apiCmpTitleId, cmpFame: apiCmpFame, cmpActivityType: apiCmpActivityType, cmpGroupId: apiCmpGroupId, cmpSubGroupId: apiCmpSubGroupId, cmpGroupIdII: apiCmpGroupIdII, cmpGroupIdIII: apiCmpGroupIdIII, cmpGroupIdIV: apiCmpGroupIdIV, cmpTypeId: apiCmpTypeId, cmpPresentationId: apiCmpPresentationId, cmpPreTel: apiCmpPreTel, cmpTel: apiCmpTel, cmpTelUpTo: apiCmpTelUpTo, cmpTelDesc: apiCmpTelDesc, cmpPreTelII: apiCmpPreTelII, cmpTelII: apiCmpTelII, cmpTelUpToII: apiCmpTelUpToII, cmpTelIIDesc: apiCmpTelIIDesc, cmpMobile: apiCmpMobile, cmpFax: apiCmpFax, cmpFaxDesc: apiCmpFaxDesc, cmpCountryId: apiCmpCountryId, cmpProvinceId: apiCmpProvinceId, cmpCityId: apiCmpCityId, cmpAddress: apiCmpAddress, cmpAddressDesc: apiCmpAddressDesc, cmpZipCode: apiCmpZipCode, cmpPostBox: apiCmpPostBox, cmpWebSite: apiCmpWebSite, cmpEmail: apiCmpEmail, cmpInteresting: apiCmpInteresting, cmpSpecialPoint: apiCmpSpecialPoint, cmpDescription: apiCmpDescription, cmpUserName: apiCmpUserName, cmpPassword: apiCmpPassword, cmpRegistrationNumber: apiCmpRegistrationNumber, cmpEconomicCode: apiCmpEconomicCode, cmpNationalCode: apiCmpNationalCode, cmpBuyLimit: apiCmpBuyLimit, cmpAccountNumber: apiCmpAccountNumber, cmpAccInquiry: apiCmpAccInquiry, cmpFreight: apiCmpFreight, cmpInquiry: apiCmpInquiry, cmpReferUserId: apiCmpReferUserId, cmpSpecialWordForCI: apiCmpSpecialWordForCI, cmpCode: apiCmpCode, cmpEffectiveDateTime: apiCmpEffectiveDateTime, cmpEffectiveDatePersian: cmpEffectiveDatePersian, cmpCoordinateLatitude: apiCmpCoordinateLatitude, cmpCoordinateLongitude: apiCmpCoordinateLongitude, tspCmpBbc: model.ApiTspCmpBbc, tspCmpTob: model.ApiTspCmpTob, cmpOfficialTel: model.ApiCmpOfficialTel, cmpOfficialCityId: model.ApiCmpOfficialCityId, cmpOfficialAddress: model.ApiCmpOfficialAddress, cmpOfficialZipCode: model.ApiCmpOfficialZipCode, cmpOfficialDesc: model.ApiCmpOfficialDesc);
			string resourceString2 = MyResource.GetResourceString("ErrorDoneOperationTryAgain", text2, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
			string resourceString3 = MyResource.GetResourceString("ErrorTryAgain", text2, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
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
				string text21 = "";
				string text22 = "";
				string text23 = objectParameter.Value.ToString();
				if (text23.IndexOf("IsUser=0", StringComparison.Ordinal) >= 0)
				{
					text21 = text21 + MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", text2, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "<br>";
					resourceString3 = "<br>" + MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", text2, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + resourceString3;
					return new ServiceResult<int>
					{
						Message = resourceString3.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text23.IndexOf("DupUName=1", StringComparison.Ordinal) >= 0)
				{
					text21 = text21 + MyResource.GetResourceString("ErrorUsernameIsRepeat", text2, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "<br>";
					resourceString3 = "<br>" + MyResource.GetResourceString("ErrorUsernameIsRepeat", text2, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + resourceString3;
					return new ServiceResult<int>
					{
						Message = resourceString3.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text23.IndexOf("DupCmpCode=", StringComparison.Ordinal) >= 0)
				{
					string[] array = text23.Split(new char[1] { '|' });
					string arg = "";
					if (array != null)
					{
						string[] array2 = array;
						foreach (string text24 in array2)
						{
							if (!string.IsNullOrEmpty(text24) && text24.IndexOf("DupCmpCode=", StringComparison.Ordinal) >= 0)
							{
								string[] array3 = text24.Split(new char[1] { '=' });
								if (array3 != null && array3.Length == 2)
								{
									arg = ((array3[1] != null && array3[1] != "") ? array3[1] : "");
								}
							}
						}
					}
					text21 = text21 + string.Format(MyResource.GetResourceString("ErrorCheckCmpCodeDuplicate", text2, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), model.ApiCmpCode, arg) + "<br>";
					return new ServiceResult<int>
					{
						Message = text21.Replace("<br>", "\r\n") + "\r\n" + resourceString3.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text23.IndexOf("DupCmp=", StringComparison.Ordinal) >= 0)
				{
					string[] array4 = text23.Split(new char[1] { '|' });
					string arg2 = "";
					if (array4 != null)
					{
						string[] array5 = array4;
						foreach (string text25 in array5)
						{
							if (!string.IsNullOrEmpty(text25) && text25.IndexOf("DupCmp=", StringComparison.Ordinal) >= 0)
							{
								string[] array6 = text25.Split(new char[1] { '=' });
								if (array6 != null && array6.Length == 2)
								{
									arg2 = ((array6[1] != null && array6[1] != "") ? array6[1] : "");
								}
							}
						}
					}
					text21 = text21 + string.Format(MyResource.GetResourceString("ErrorCheckCmpNameDuplicate", text2, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), arg2) + "<br>";
					return new ServiceResult<int>
					{
						Message = text21.Replace("<br>", "\r\n") + "\r\n" + resourceString3.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text23.IndexOf("No Center|", StringComparison.Ordinal) >= 0)
				{
					text22 = text22 + MyResource.GetResourceString("msgErrorCenterNotFound", text2, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + resourceString3;
					return new ServiceResult<int>
					{
						Message = text22.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text23.IndexOf("No CmpTitleId|", StringComparison.Ordinal) >= 0)
				{
					text22 = text22 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", text2, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CmpTitle", text2, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString3;
					return new ServiceResult<int>
					{
						Message = text22.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text23.IndexOf("No CmpGroupId|", StringComparison.Ordinal) >= 0)
				{
					text22 = text22 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", text2, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CmpGroup", text2, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString3;
					return new ServiceResult<int>
					{
						Message = text22.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text23.IndexOf("No CmpSubGroupId|", StringComparison.Ordinal) >= 0)
				{
					text22 = text22 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", text2, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CmpSubGroup", text2, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString3;
					return new ServiceResult<int>
					{
						Message = text22.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text23.IndexOf("No CmpGroupIdII|", StringComparison.Ordinal) >= 0)
				{
					text22 = text22 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", text2, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CmpGroupII", text2, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString3;
					return new ServiceResult<int>
					{
						Message = text22.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text23.IndexOf("No CmpGroupIdIII|", StringComparison.Ordinal) >= 0)
				{
					text22 = text22 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", text2, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CmpGroupIII", text2, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString3;
					return new ServiceResult<int>
					{
						Message = text22.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text23.IndexOf("No CmpGroupIdIV|", StringComparison.Ordinal) >= 0)
				{
					text22 = text22 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", text2, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CmpGroupIV", text2, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString3;
					return new ServiceResult<int>
					{
						Message = text22.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text23.IndexOf("No CmpTypeId|", StringComparison.Ordinal) >= 0)
				{
					text22 = text22 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", text2, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CmpType", text2, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString3;
					return new ServiceResult<int>
					{
						Message = text22.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text23.IndexOf("No CmpPresentationId|", StringComparison.Ordinal) >= 0)
				{
					text22 = text22 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", text2, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CmpPresentation", text2, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString3;
					return new ServiceResult<int>
					{
						Message = text22.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text23.IndexOf("No CmpCountryId|", StringComparison.Ordinal) >= 0)
				{
					text22 = text22 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", text2, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CmpCountry", text2, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString3;
					return new ServiceResult<int>
					{
						Message = text22.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text23.IndexOf("No CmpProvinceId|", StringComparison.Ordinal) >= 0)
				{
					text22 = text22 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", text2, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CmpProvince", text2, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString3;
					return new ServiceResult<int>
					{
						Message = text22.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text23.IndexOf("No CmpCityId|", StringComparison.Ordinal) >= 0)
				{
					text22 = text22 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", text2, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CmpCity", text2, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString3;
					return new ServiceResult<int>
					{
						Message = text22.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text23.IndexOf("No CmpCoordinateLastUserId|", StringComparison.Ordinal) >= 0)
				{
					text22 = text22 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", text2, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CmpCoordinateLastUser", text2, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString3;
					return new ServiceResult<int>
					{
						Message = text22.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text23.IndexOf("No CmpReferUserId|", StringComparison.Ordinal) >= 0)
				{
					text22 = text22 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", text2, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CmpReferUser", text2, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString3;
					return new ServiceResult<int>
					{
						Message = text22.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text23.IndexOf("No CmpMainPersonId|", StringComparison.Ordinal) >= 0)
				{
					text22 = text22 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", text2, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CmpMainPerson", text2, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString3;
					return new ServiceResult<int>
					{
						Message = text22.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text23.IndexOf("No CmpOfficialCityId|", StringComparison.Ordinal) >= 0)
				{
					text22 = text22 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", text2, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CmpOfficialCity", text2, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString3;
					return new ServiceResult<int>
					{
						Message = text22.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
			}
			else
			{
				data = 1;
				message = MyResource.GetResourceString("SuccessDoneRegister", text2, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				status = ServiceResultStatus.Success;
			}
		}
		catch (Exception ex3)
		{
			string text26 = ((!string.IsNullOrEmpty(ex3.Message)) ? ex3.Message : "");
			if (ex3.InnerException != null && !string.IsNullOrEmpty(ex3.InnerException.Message))
			{
				text26 = text26 + " - " + ex3.InnerException.Message;
			}
			message = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text26)) ? (" (" + text26 + ")") : "");
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
	public ServiceResult<List<ApispSelectCompany_Result>> Select(SelectCompanyViewModel model)
	{
		CRMEntities cRMEntities = null;
		List<ApispSelectCompany_Result> data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				return new ServiceResult<List<ApispSelectCompany_Result>>
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
				return new ServiceResult<List<ApispSelectCompany_Result>>
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
				ServiceResult<List<ApispSelectCompany_Result>> serviceResult = new ServiceResult<List<ApispSelectCompany_Result>>();
				serviceResult.Message = MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			DateTime value = DateTime.Now;
			DateTime value2 = DateTime.Now;
			DateTime value3 = DateTime.Now;
			DateTime value4 = DateTime.Now;
			try
			{
				if (!string.IsNullOrEmpty(model.FromRegisterDate))
				{
					model.FromRegisterDate = model.FromRegisterDate.Replace("/", "").Replace("-", "").Replace("\\", "")
						.Replace(" ", "")
						.Replace("_", "");
					if (currLangId != 1065)
					{
						value = ((currLangId != 1025) ? DateTime.Parse(PersianDate.GetFormatetdDate(model.FromRegisterDate) + " 00:00:00", new CultureInfo("en-US"), DateTimeStyles.None) : DateTime.Parse(PersianDate.GetFormatetdDate(model.FromRegisterDate) + " 00:00:00", new CultureInfo("ar-SA"), DateTimeStyles.None));
					}
					else
					{
						string shamsi2Miladi = PersianDate.GetShamsi2Miladi(model.FromRegisterDate);
						value = DateTime.Parse(PersianDate.GetFormatetdDate(shamsi2Miladi) + " 00:00:00", new CultureInfo("en-US"), DateTimeStyles.None);
					}
				}
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
				ServiceResult<List<ApispSelectCompany_Result>> serviceResult = new ServiceResult<List<ApispSelectCompany_Result>>();
				serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("FromRegisterDate", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly)) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				ServiceResult<List<ApispSelectCompany_Result>> result3 = serviceResult;
				cRMEntities?.Dispose();
				return result3;
			}
			try
			{
				if (!string.IsNullOrEmpty(model.ToRegisterDate))
				{
					model.ToRegisterDate = model.ToRegisterDate.Replace("/", "").Replace("-", "").Replace("\\", "")
						.Replace(" ", "")
						.Replace("_", "");
					if (currLangId != 1065)
					{
						value2 = ((currLangId != 1025) ? DateTime.Parse(PersianDate.GetFormatetdDate(model.ToRegisterDate) + " 23:59:59", new CultureInfo("en-US"), DateTimeStyles.None) : DateTime.Parse(PersianDate.GetFormatetdDate(model.ToRegisterDate) + " 23:59:59", new CultureInfo("ar-SA"), DateTimeStyles.None));
					}
					else
					{
						string shamsi2Miladi2 = PersianDate.GetShamsi2Miladi(model.ToRegisterDate);
						value2 = DateTime.Parse(PersianDate.GetFormatetdDate(shamsi2Miladi2) + " 23:59:59", new CultureInfo("en-US"), DateTimeStyles.None);
					}
				}
			}
			catch (Exception e2)
			{
				ErrorSignal.FromCurrentContext().Raise(e2);
				ServiceResult<List<ApispSelectCompany_Result>> serviceResult = new ServiceResult<List<ApispSelectCompany_Result>>();
				serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("ToRegisterDate", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly)) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				ServiceResult<List<ApispSelectCompany_Result>> result4 = serviceResult;
				cRMEntities?.Dispose();
				return result4;
			}
			try
			{
				if (!string.IsNullOrEmpty(model.FromFirstRegisterDate))
				{
					model.FromFirstRegisterDate = model.FromFirstRegisterDate.Replace("/", "").Replace("-", "").Replace("\\", "")
						.Replace(" ", "")
						.Replace("_", "");
					if (currLangId != 1065)
					{
						value3 = ((currLangId != 1025) ? DateTime.Parse(PersianDate.GetFormatetdDate(model.FromFirstRegisterDate) + " 00:00:00", new CultureInfo("en-US"), DateTimeStyles.None) : DateTime.Parse(PersianDate.GetFormatetdDate(model.FromFirstRegisterDate) + " 00:00:00", new CultureInfo("ar-SA"), DateTimeStyles.None));
					}
					else
					{
						string shamsi2Miladi3 = PersianDate.GetShamsi2Miladi(model.FromFirstRegisterDate);
						value3 = DateTime.Parse(PersianDate.GetFormatetdDate(shamsi2Miladi3) + " 00:00:00", new CultureInfo("en-US"), DateTimeStyles.None);
					}
				}
			}
			catch (Exception e3)
			{
				ErrorSignal.FromCurrentContext().Raise(e3);
				ServiceResult<List<ApispSelectCompany_Result>> serviceResult = new ServiceResult<List<ApispSelectCompany_Result>>();
				serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("FromFirstRegisterDate", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly)) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				ServiceResult<List<ApispSelectCompany_Result>> result5 = serviceResult;
				cRMEntities?.Dispose();
				return result5;
			}
			try
			{
				if (!string.IsNullOrEmpty(model.ToFirstRegisterDate))
				{
					model.ToFirstRegisterDate = model.ToFirstRegisterDate.Replace("/", "").Replace("-", "").Replace("\\", "")
						.Replace(" ", "")
						.Replace("_", "");
					if (currLangId != 1065)
					{
						value4 = ((currLangId != 1025) ? DateTime.Parse(PersianDate.GetFormatetdDate(model.ToFirstRegisterDate) + " 23:59:59", new CultureInfo("en-US"), DateTimeStyles.None) : DateTime.Parse(PersianDate.GetFormatetdDate(model.ToFirstRegisterDate) + " 23:59:59", new CultureInfo("ar-SA"), DateTimeStyles.None));
					}
					else
					{
						string shamsi2Miladi4 = PersianDate.GetShamsi2Miladi(model.ToFirstRegisterDate);
						value4 = DateTime.Parse(PersianDate.GetFormatetdDate(shamsi2Miladi4) + " 23:59:59", new CultureInfo("en-US"), DateTimeStyles.None);
					}
				}
			}
			catch (Exception e4)
			{
				ErrorSignal.FromCurrentContext().Raise(e4);
				ServiceResult<List<ApispSelectCompany_Result>> serviceResult = new ServiceResult<List<ApispSelectCompany_Result>>();
				serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorFormat", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("ToFirstRegisterDate", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly)) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				ServiceResult<List<ApispSelectCompany_Result>> result6 = serviceResult;
				cRMEntities?.Dispose();
				return result6;
			}
			model.PageSize = ((model.PageNumber.HasValue && model.PageNumber > 0 && (!model.PageSize.HasValue || model.PageSize == 0)) ? new int?(20) : model.PageSize);
			List<ApispSelectCompany_Result> list2 = Enumerable.ToList<ApispSelectCompany_Result>((IEnumerable<ApispSelectCompany_Result>)cRMEntities.ApispSelectCompany(model.ApiCompanyId, model.ApiCmpCode, model.ApiCmpNumber, (!string.IsNullOrEmpty(model.FromRegisterDate)) ? new DateTime?(value) : null, (!string.IsNullOrEmpty(model.ToRegisterDate)) ? new DateTime?(value2) : null, (!string.IsNullOrEmpty(model.FromFirstRegisterDate)) ? new DateTime?(value3) : null, (!string.IsNullOrEmpty(model.ToFirstRegisterDate)) ? new DateTime?(value4) : null, currLangId, result, model.CenterId, model.CenterCode, model.PageNumber, model.PageSize));
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
		return new ServiceResult<List<ApispSelectCompany_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<bool> Delete(DeleteCompanyViewModel model)
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
			if (model.ApiCompanyId > 0)
			{
				mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)cRMEntities.ApispDeleteCompany(model.ApiCompanyId));
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

	[HttpPost]
	public ServiceResult<List<ApispMainSearchWebSmart_Result>> MainSearchSmart(SearchCompanySmartViewModel model)
	{
		CRMEntities cRMEntities = null;
		List<ApispMainSearchWebSmart_Result> data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				return new ServiceResult<List<ApispMainSearchWebSmart_Result>>
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
				return new ServiceResult<List<ApispMainSearchWebSmart_Result>>
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
				ServiceResult<List<ApispMainSearchWebSmart_Result>> serviceResult = new ServiceResult<List<ApispMainSearchWebSmart_Result>>();
				serviceResult.Message = MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			if (!model.ApiSearchType.HasValue)
			{
				model.ApiSearchType = 1;
			}
			List<ApispMainSearchWebSmart_Result> list2 = Enumerable.ToList<ApispMainSearchWebSmart_Result>((IEnumerable<ApispMainSearchWebSmart_Result>)cRMEntities.ApispMainSearchWebSmart(model.ApiVal, model.UserId, model.ApiSearchType, currLangId, result, model.ApiSearchConditionMode, model.CenterId, model.CenterCode));
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
		return new ServiceResult<List<ApispMainSearchWebSmart_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<List<ApispMainSearch_Result>> MainSearch(SearchCompanyViewModel model)
	{
		CRMEntities cRMEntities = null;
		List<ApispMainSearch_Result> data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				return new ServiceResult<List<ApispMainSearch_Result>>
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
				return new ServiceResult<List<ApispMainSearch_Result>>
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
				ServiceResult<List<ApispMainSearch_Result>> serviceResult = new ServiceResult<List<ApispMainSearch_Result>>();
				serviceResult.Message = MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			if (!model.ApiSearchType.HasValue)
			{
				model.ApiSearchType = 1;
			}
			List<ApispMainSearch_Result> list2 = Enumerable.ToList<ApispMainSearch_Result>((IEnumerable<ApispMainSearch_Result>)cRMEntities.ApispMainSearch(model.ApiVal, model.UserId, model.ApiSearchType, currLangId, result, model.CenterId, model.CenterCode));
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
		return new ServiceResult<List<ApispMainSearch_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<int> InsertCompanyMultiGroups(InsertCompanyMultiGroupsViewModel model)
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
			string text = null;
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
			if (model.ApiCompanyId <= 0)
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
			CommonClass commonClass = new CommonClass();
			ObjectParameter objectParameter = new ObjectParameter("InsertedCompanyMultiGroups", 0);
			ObjectParameter objectParameter2 = new ObjectParameter("ErrorMessage", "");
			int num3 = cRMEntities.ApispInsertCompanyMultiGroups(model.ApiCompanyId, model.ApiCompanyGroupsMultiId, userId, value2, value, registerDatePersian, appType, currLangId, result, objectParameter, objectParameter2);
			string resourceString = MyResource.GetResourceString("ErrorDoneOperationTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
			string resourceString2 = MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
			int result3 = 0;
			int.TryParse(num3.ToString(), out result3);
			if (result3 < 0 && objectParameter2.Value == null)
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
				string text2 = "";
				string text3 = "";
				string text4 = objectParameter2.Value.ToString();
				if (text4.IndexOf("IsUser=0", StringComparison.Ordinal) >= 0)
				{
					text2 = text2 + MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "<br>";
					resourceString2 = "<br>" + MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + resourceString2;
					return new ServiceResult<int>
					{
						Message = resourceString2.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text4.IndexOf("No Center|", StringComparison.Ordinal) >= 0)
				{
					text3 = text3 + MyResource.GetResourceString("msgErrorCenterNotFound", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text3.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text4.IndexOf("No CmpId|", StringComparison.Ordinal) >= 0)
				{
					text3 = text3 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CompanyI", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text3.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text4.IndexOf("NO CrmCompanyGroupsMulti|", StringComparison.Ordinal) >= 0)
				{
					text3 = text3 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("Group", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text3.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text4.IndexOf("Already Registered|", StringComparison.Ordinal) >= 0)
				{
					text3 = text3 + MyResource.GetResourceString("ErrorAlreadyRegisteredCmpMultiGroups", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + resourceString2;
					return new ServiceResult<int>
					{
						Message = text3.Replace("<br>", "\r\n"),
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
				data = 1;
				message = MyResource.GetResourceString("SuccessDoneRegister", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				status = ServiceResultStatus.Success;
			}
		}
		catch (Exception ex)
		{
			string text5 = ((!string.IsNullOrEmpty(ex.Message)) ? ex.Message : "");
			if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
			{
				text5 = text5 + " - " + ex.InnerException.Message;
			}
			message = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text5)) ? (" (" + text5 + ")") : "");
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
	public ServiceResult<List<ApispSelectCompanyMultiGroups_Result>> SelectCompanyMultiGroups(SelectCompanyMultiGroupsViewModel model)
	{
		CRMEntities cRMEntities = null;
		List<ApispSelectCompanyMultiGroups_Result> data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				return new ServiceResult<List<ApispSelectCompanyMultiGroups_Result>>
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
				return new ServiceResult<List<ApispSelectCompanyMultiGroups_Result>>
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
				ServiceResult<List<ApispSelectCompanyMultiGroups_Result>> serviceResult = new ServiceResult<List<ApispSelectCompanyMultiGroups_Result>>();
				serviceResult.Message = MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			List<ApispSelectCompanyMultiGroups_Result> list2 = Enumerable.ToList<ApispSelectCompanyMultiGroups_Result>((IEnumerable<ApispSelectCompanyMultiGroups_Result>)cRMEntities.ApispSelectCompanyMultiGroups(model.ApiCompanyId, currLangId, result));
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
		return new ServiceResult<List<ApispSelectCompanyMultiGroups_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<bool> DeleteCompanyMultiGroups(DeleteCompanyMultiGroupsViewModel model)
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
			if (model.ApiCompanyId > 0 && model.ApiCompanyGroupsMultiId > 0)
			{
				int num2 = cRMEntities.ApispDeleteCompanyMultiGroups(model.ApiCompanyId, model.ApiCompanyGroupsMultiId);
				data = true;
				message = MyResource.GetResourceString("SuccessDoneRegister", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				status = ServiceResultStatus.Success;
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

	[HttpPost]
	public ServiceResult<List<ApispCompanyMultiSelect_Result>> CompanyMultiSelect(CompanyMultiSelectViewModel model)
	{
		CRMEntities cRMEntities = null;
		List<ApispCompanyMultiSelect_Result> data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				return new ServiceResult<List<ApispCompanyMultiSelect_Result>>
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
				return new ServiceResult<List<ApispCompanyMultiSelect_Result>>
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
				ServiceResult<List<ApispCompanyMultiSelect_Result>> serviceResult = new ServiceResult<List<ApispCompanyMultiSelect_Result>>();
				serviceResult.Message = MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			if (string.IsNullOrWhiteSpace(model.ApiFieldName))
			{
				ServiceResult<List<ApispCompanyMultiSelect_Result>> serviceResult = new ServiceResult<List<ApispCompanyMultiSelect_Result>>();
				serviceResult.Message = MyResource.GetResourceString("ErrorNotEnteredFieldName", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			if (string.IsNullOrWhiteSpace(model.ApiFieldValue))
			{
				ServiceResult<List<ApispCompanyMultiSelect_Result>> serviceResult = new ServiceResult<List<ApispCompanyMultiSelect_Result>>();
				serviceResult.Message = MyResource.GetResourceString("ErrorNotEnteredFieldValue", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			List<ApispCompanyMultiSelect_Result> list2 = Enumerable.ToList<ApispCompanyMultiSelect_Result>((IEnumerable<ApispCompanyMultiSelect_Result>)cRMEntities.ApispCompanyMultiSelect(model.ApiFieldName, model.ApiFieldValue, model.ApiUserId, currLangId, result, model.CenterId, model.CenterCode));
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
		return new ServiceResult<List<ApispCompanyMultiSelect_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<FullRegisterResultViewModel> FullRegisterKaraAfzar(FullRegisterViewModel model)
	{
		CRMEntities cRMEntities = null;
		FullRegisterResultViewModel data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			cRMEntities = new CRMEntities();
			string text = null;
			string text2 = null;
			string text3 = null;
			string text4 = null;
			string text5 = null;
			string text6 = null;
			string text7 = null;
			if (model.ApiCmpEffectiveDateTime.HasValue)
			{
				text2 = (model.ApiCmpEffectiveDateTime ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
			}
			if (model.ApiCmpCoordinateLastDate.HasValue)
			{
				text3 = (model.ApiCmpCoordinateLastDate ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
			}
			if (model.ApiPrsBirthDateTime.HasValue)
			{
				text4 = (model.ApiPrsBirthDateTime ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
			}
			if (model.ApiPrsMarriageDateTime.HasValue)
			{
				text5 = (model.ApiPrsMarriageDateTime ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
			}
			if (model.ApiPrjRemindDateTime.HasValue)
			{
				text6 = (model.ApiPrjRemindDateTime ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
			}
			if (model.ApiCnvsRemindDateTime.HasValue)
			{
				text7 = (model.ApiCnvsRemindDateTime ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
			}
			ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
			if (apispSelectCrmsysSetting_Result == null)
			{
				return new ServiceResult<FullRegisterResultViewModel>
				{
					Message = Messages.ErrorInReadingSysSetting,
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			int.TryParse(apispSelectCrmsysSetting_Result.DefaultLanguageID.ToString(), out var defLangId);
			if (defLangId <= 0)
			{
				defLangId = 1065;
			}
			int mobNumLen = Setting.GetMobNumLen();
			bool mobNumLenNoCheck = Setting.GetMobNumLenNoCheck();
			string key = "KaRaAfzarCRM!deal1384";
			if (!string.IsNullOrEmpty(model.Password))
			{
				model.Password = CodeDecode.DeCodding(model.Password, key);
			}
			if (!string.IsNullOrEmpty(model.UserName))
			{
				model.UserName = CodeDecode.DeCodding(model.UserName, key);
			}
			List<ApispSelectLanguages_Result> list = Enumerable.ToList<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)cRMEntities.ApispSelectLanguages());
			int.TryParse(model.LanguageId.ToString(), out var currLangId);
			if (currLangId <= 0)
			{
				currLangId = defLangId;
			}
			string text8 = "fa-IR";
			ApispSelectLanguages_Result apispSelectLanguages_Result = Enumerable.FirstOrDefault<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result m) => m.LanguageID == currLangId));
			if (apispSelectLanguages_Result != null)
			{
				text8 = apispSelectLanguages_Result.LanguageCollation;
			}
			List<ApispSelectCrmFoSetting_Result> list2 = Enumerable.ToList<ApispSelectCrmFoSetting_Result>((IEnumerable<ApispSelectCrmFoSetting_Result>)cRMEntities.ApispSelectCrmFoSetting());
			if (!Enumerable.Any<ApispSelectCrmFoSetting_Result>((IEnumerable<ApispSelectCrmFoSetting_Result>)list2))
			{
				ServiceResult<FullRegisterResultViewModel> serviceResult = new ServiceResult<FullRegisterResultViewModel>();
				serviceResult.Message = MyResource.GetResourceString("ErrorInReadingFoSetting", text8, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			if (Enumerable.FirstOrDefault<ApispSelectCrmFoSetting_Result>((IEnumerable<ApispSelectCrmFoSetting_Result>)list2, (Func<ApispSelectCrmFoSetting_Result, bool>)((ApispSelectCrmFoSetting_Result m) => m.LanguageID == defLangId)) == null)
			{
				ServiceResult<FullRegisterResultViewModel> serviceResult = new ServiceResult<FullRegisterResultViewModel>();
				serviceResult.Message = MyResource.GetResourceString("ErrorInReadingFoSetting", text8, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			if (string.IsNullOrEmpty(model.ApiPrsLName))
			{
				ServiceResult<FullRegisterResultViewModel> serviceResult = new ServiceResult<FullRegisterResultViewModel>();
				serviceResult.Message = MyResource.GetResourceString("ErrorPrsLNameNotEntered", text8, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			if (string.IsNullOrEmpty(model.ApiPrsMobile) && string.IsNullOrEmpty(model.ApiPrsEmail) && string.IsNullOrEmpty(model.ApiPrsEmailII))
			{
				ServiceResult<FullRegisterResultViewModel> serviceResult = new ServiceResult<FullRegisterResultViewModel>();
				serviceResult.Message = MyResource.GetResourceString("ErrorPrsMobEmailNotEntered", text8, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			if (model.ApiPrsMobile != null)
			{
				if (model.ApiPrsMobile.Length != mobNumLen && !mobNumLenNoCheck)
				{
					ServiceResult<FullRegisterResultViewModel> serviceResult = new ServiceResult<FullRegisterResultViewModel>();
					serviceResult.Message = MyResource.GetResourceString("CheckLenMob", text8, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
					serviceResult.Data = null;
					serviceResult.Status = ServiceResultStatus.Error;
					return serviceResult;
				}
				if (model.ApiPrsMobile.Length >= 2)
				{
					string text9 = model.ApiPrsMobile.Substring(0, 2);
					if (text9 != "09" && !mobNumLenNoCheck)
					{
						ServiceResult<FullRegisterResultViewModel> serviceResult = new ServiceResult<FullRegisterResultViewModel>();
						serviceResult.Message = MyResource.GetResourceString("CheckMobileFormat", text8, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
						serviceResult.Data = null;
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
					ServiceResult<FullRegisterResultViewModel> serviceResult = new ServiceResult<FullRegisterResultViewModel>();
					serviceResult.Message = string.Format(MyResource.GetResourceString("CheckDigit", text8, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PrsMobile", text8, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly));
					serviceResult.Data = null;
					serviceResult.Status = ServiceResultStatus.Error;
					return serviceResult;
				}
			}
			if (model.ApiCmpPreTel != null && model.ApiCmpPreTel.Length > 1 && model.ApiCmpPreTel.Substring(0, 2) == "09")
			{
				ServiceResult<FullRegisterResultViewModel> serviceResult = new ServiceResult<FullRegisterResultViewModel>();
				serviceResult.Message = MyResource.GetResourceString("CheckPreTelForNotMobile", text8, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			if (model.ApiCmpPreTelII != null && model.ApiCmpPreTelII.Length > 1 && model.ApiCmpPreTelII.Substring(0, 2) == "09")
			{
				ServiceResult<FullRegisterResultViewModel> serviceResult = new ServiceResult<FullRegisterResultViewModel>();
				serviceResult.Message = MyResource.GetResourceString("CheckPreTelForNotMobile", text8, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			if (model.ApiCmpTel != null && model.ApiCmpTel.Length > 1 && model.ApiCmpTel.Substring(0, 2) == "09")
			{
				ServiceResult<FullRegisterResultViewModel> serviceResult = new ServiceResult<FullRegisterResultViewModel>();
				serviceResult.Message = MyResource.GetResourceString("CheckPreTelForNotMobile", text8, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			if (model.ApiCmpTelII != null && model.ApiCmpTelII.Length > 1 && model.ApiCmpTelII.Substring(0, 2) == "09")
			{
				ServiceResult<FullRegisterResultViewModel> serviceResult = new ServiceResult<FullRegisterResultViewModel>();
				serviceResult.Message = MyResource.GetResourceString("CheckPreTelForNotMobile", text8, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			if (model.ApiPrsPreTel != null && model.ApiPrsPreTel.Length > 1 && model.ApiPrsPreTel.Substring(0, 2) == "09")
			{
				ServiceResult<FullRegisterResultViewModel> serviceResult = new ServiceResult<FullRegisterResultViewModel>();
				serviceResult.Message = MyResource.GetResourceString("CheckPreTelForNotMobile", text8, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			if (model.ApiPrsTel != null && model.ApiPrsTel.Length > 1 && model.ApiPrsTel.Substring(0, 2) == "09")
			{
				ServiceResult<FullRegisterResultViewModel> serviceResult = new ServiceResult<FullRegisterResultViewModel>();
				serviceResult.Message = MyResource.GetResourceString("CheckPreTelForNotMobile", text8, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			if (model.ApiPrsTelII != null && model.ApiPrsTelII.Length > 1 && model.ApiPrsTelII.Substring(0, 2) == "09")
			{
				ServiceResult<FullRegisterResultViewModel> serviceResult = new ServiceResult<FullRegisterResultViewModel>();
				serviceResult.Message = MyResource.GetResourceString("CheckPreTelForNotMobile", text8, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			if (!string.IsNullOrEmpty(model.ApiCmpMobile))
			{
				try
				{
					long.Parse(model.ApiCmpMobile);
				}
				catch
				{
					ServiceResult<FullRegisterResultViewModel> serviceResult = new ServiceResult<FullRegisterResultViewModel>();
					serviceResult.Message = string.Format(MyResource.GetResourceString("CheckDigit", text8, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CmpMobile", text8, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly));
					serviceResult.Data = null;
					serviceResult.Status = ServiceResultStatus.Error;
					return serviceResult;
				}
			}
			if (!string.IsNullOrEmpty(model.ApiCmpTel))
			{
				try
				{
					long.Parse(model.ApiCmpTel);
				}
				catch
				{
					ServiceResult<FullRegisterResultViewModel> serviceResult = new ServiceResult<FullRegisterResultViewModel>();
					serviceResult.Message = string.Format(MyResource.GetResourceString("CheckDigit", text8, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CmpTel", text8, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly));
					serviceResult.Data = null;
					serviceResult.Status = ServiceResultStatus.Error;
					return serviceResult;
				}
			}
			if (!string.IsNullOrEmpty(model.ApiCmpPreTel))
			{
				try
				{
					long.Parse(model.ApiCmpPreTel);
				}
				catch
				{
					ServiceResult<FullRegisterResultViewModel> serviceResult = new ServiceResult<FullRegisterResultViewModel>();
					serviceResult.Message = string.Format(MyResource.GetResourceString("CheckDigit", text8, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CmpPreTel", text8, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly));
					serviceResult.Data = null;
					serviceResult.Status = ServiceResultStatus.Error;
					return serviceResult;
				}
			}
			if (!string.IsNullOrEmpty(model.ApiCmpTelUpTo))
			{
				try
				{
					long.Parse(model.ApiCmpTelUpTo);
				}
				catch
				{
					ServiceResult<FullRegisterResultViewModel> serviceResult = new ServiceResult<FullRegisterResultViewModel>();
					serviceResult.Message = string.Format(MyResource.GetResourceString("CheckDigit", text8, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CmpTelUpTo", text8, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly));
					serviceResult.Data = null;
					serviceResult.Status = ServiceResultStatus.Error;
					return serviceResult;
				}
			}
			if (!string.IsNullOrEmpty(model.ApiCmpTelII))
			{
				try
				{
					long.Parse(model.ApiCmpTelII);
				}
				catch
				{
					ServiceResult<FullRegisterResultViewModel> serviceResult = new ServiceResult<FullRegisterResultViewModel>();
					serviceResult.Message = string.Format(MyResource.GetResourceString("CheckDigit", text8, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CmpTelII", text8, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly));
					serviceResult.Data = null;
					serviceResult.Status = ServiceResultStatus.Error;
					return serviceResult;
				}
			}
			if (!string.IsNullOrEmpty(model.ApiCmpPreTelII))
			{
				try
				{
					long.Parse(model.ApiCmpPreTelII);
				}
				catch
				{
					ServiceResult<FullRegisterResultViewModel> serviceResult = new ServiceResult<FullRegisterResultViewModel>();
					serviceResult.Message = string.Format(MyResource.GetResourceString("CheckDigit", text8, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CmpPreTel", text8, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly));
					serviceResult.Data = null;
					serviceResult.Status = ServiceResultStatus.Error;
					return serviceResult;
				}
			}
			if (!string.IsNullOrEmpty(model.ApiCmpTelUpToII))
			{
				try
				{
					long.Parse(model.ApiCmpTelUpToII);
				}
				catch
				{
					ServiceResult<FullRegisterResultViewModel> serviceResult = new ServiceResult<FullRegisterResultViewModel>();
					serviceResult.Message = string.Format(MyResource.GetResourceString("CheckDigit", text8, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CmpTelUpTo", text8, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly));
					serviceResult.Data = null;
					serviceResult.Status = ServiceResultStatus.Error;
					return serviceResult;
				}
			}
			if (!string.IsNullOrEmpty(model.ApiCmpFax))
			{
				try
				{
					long.Parse(model.ApiCmpFax);
				}
				catch
				{
					ServiceResult<FullRegisterResultViewModel> serviceResult = new ServiceResult<FullRegisterResultViewModel>();
					serviceResult.Message = string.Format(MyResource.GetResourceString("CheckDigit", text8, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CmpFax", text8, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly));
					serviceResult.Data = null;
					serviceResult.Status = ServiceResultStatus.Error;
					return serviceResult;
				}
			}
			if (model.ApiCmpPreTel != null && model.ApiCmpPreTel.Length > 1 && model.ApiCmpPreTel.Substring(0, 2) == "09")
			{
				ServiceResult<FullRegisterResultViewModel> serviceResult = new ServiceResult<FullRegisterResultViewModel>();
				serviceResult.Message = MyResource.GetResourceString("CheckPreTelForNotMobile", text8, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			if (model.ApiCmpPreTelII != null && model.ApiCmpPreTelII.Length > 1 && model.ApiCmpPreTelII.Substring(0, 2) == "09")
			{
				ServiceResult<FullRegisterResultViewModel> serviceResult = new ServiceResult<FullRegisterResultViewModel>();
				serviceResult.Message = MyResource.GetResourceString("CheckPreTelForNotMobile", text8, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			if (model.ApiCmpTel != null && model.ApiCmpTel.Length > 1 && model.ApiCmpTel.Substring(0, 2) == "09")
			{
				ServiceResult<FullRegisterResultViewModel> serviceResult = new ServiceResult<FullRegisterResultViewModel>();
				serviceResult.Message = MyResource.GetResourceString("CheckPreTelForNotMobile", text8, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			if (model.ApiCmpTelII != null && model.ApiCmpTelII.Length > 1 && model.ApiCmpTelII.Substring(0, 2) == "09")
			{
				ServiceResult<FullRegisterResultViewModel> serviceResult = new ServiceResult<FullRegisterResultViewModel>();
				serviceResult.Message = MyResource.GetResourceString("CheckPreTelForNotMobile", text8, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			if (model.ApiCmpNumber.HasValue)
			{
				ApispCheckDuplicateCompanyNumber_Result apispCheckDuplicateCompanyNumber_Result = Enumerable.FirstOrDefault<ApispCheckDuplicateCompanyNumber_Result>((IEnumerable<ApispCheckDuplicateCompanyNumber_Result>)cRMEntities.ApispCheckDuplicateCompanyNumber(model.ApiCmpNumber, 0, currLangId, defLangId));
				if (apispCheckDuplicateCompanyNumber_Result != null)
				{
					ServiceResult<FullRegisterResultViewModel> serviceResult = new ServiceResult<FullRegisterResultViewModel>();
					serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorCmpNumberDuplicate", text8, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), apispCheckDuplicateCompanyNumber_Result.CompanyName ?? "");
					serviceResult.Data = null;
					serviceResult.Status = ServiceResultStatus.Error;
					return serviceResult;
				}
			}
			if (!string.IsNullOrEmpty(model.ApiCmpCode) && model.CmpCodeNotDup.HasValue && model.CmpCodeNotDup.GetValueOrDefault())
			{
				string text10 = Company.CheckDuplicateCompanyCode(0, model.ApiCmpCode, defLangId, currLangId, text8);
				if (!string.IsNullOrEmpty(text10))
				{
					return new ServiceResult<FullRegisterResultViewModel>
					{
						Message = text10,
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
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
				flag4 = ((apispSelectCrmsysSetting_Result2.CantSaveDupCmpNationalCode.HasValue && apispSelectCrmsysSetting_Result2.CantSaveDupCmpNationalCode != false) ? true : false);
				flag5 = ((apispSelectCrmsysSetting_Result2.CantSaveDupCmpEconomicCode.HasValue && apispSelectCrmsysSetting_Result2.CantSaveDupCmpEconomicCode != false) ? true : false);
			}
			if (!string.IsNullOrEmpty(model.ApiCmpTel) && flag && model.CmpTelNotDup.HasValue && model.CmpTelNotDup.GetValueOrDefault())
			{
				string text11 = Company.CantSaveDupTel(model.ApiCmpTel, 1, 0, defLangId, currLangId, text8);
				if (!string.IsNullOrEmpty(text11))
				{
					return new ServiceResult<FullRegisterResultViewModel>
					{
						Message = text11,
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
			}
			if (!string.IsNullOrEmpty(model.ApiCmpTelII) && flag && model.CmpTelNotDup.HasValue && model.CmpTelNotDup.GetValueOrDefault())
			{
				string text12 = Company.CantSaveDupTel(model.ApiCmpTelII, 1, 0, defLangId, currLangId, text8);
				if (!string.IsNullOrEmpty(text12))
				{
					return new ServiceResult<FullRegisterResultViewModel>
					{
						Message = text12,
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
			}
			if (!string.IsNullOrEmpty(model.ApiCmpFax) && flag2 && model.CmpFaxNotDup.HasValue && model.CmpFaxNotDup.GetValueOrDefault())
			{
				string text13 = Company.CantSaveDupFax(model.ApiCmpFax, 1, 0, defLangId, currLangId, text8);
				if (!string.IsNullOrEmpty(text13))
				{
					return new ServiceResult<FullRegisterResultViewModel>
					{
						Message = text13,
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
			}
			if (!string.IsNullOrEmpty(model.ApiCmpZipCode) && flag3)
			{
				string text14 = Company.CantSaveDupZipCode(model.ApiCmpZipCode, 1, 0, defLangId, currLangId, text8);
				if (!string.IsNullOrEmpty(text14))
				{
					return new ServiceResult<FullRegisterResultViewModel>
					{
						Message = text14,
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
			}
			if (!string.IsNullOrEmpty(model.ApiCmpNationalCode) && flag4)
			{
				string text15 = Company.CantSaveDupCmpNationalCode(model.ApiCmpNationalCode, 0, defLangId, currLangId, text8);
				if (!string.IsNullOrEmpty(text15))
				{
					return new ServiceResult<FullRegisterResultViewModel>
					{
						Message = text15,
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
			}
			if (!string.IsNullOrEmpty(model.ApiCmpEconomicCode) && flag5)
			{
				string text16 = Company.CantSaveDupCmpEconomicCode(model.ApiCmpEconomicCode, 0, defLangId, currLangId, text8);
				if (!string.IsNullOrEmpty(text16))
				{
					return new ServiceResult<FullRegisterResultViewModel>
					{
						Message = text16,
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
			}
			if (!string.IsNullOrEmpty(model.ApiCmpEmail))
			{
				string text17 = Company.CantSaveDupCmpEmail(model.ApiCmpEmail, 0, defLangId, currLangId, text8);
				if (!string.IsNullOrEmpty(text17))
				{
					return new ServiceResult<FullRegisterResultViewModel>
					{
						Message = text17,
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
			}
			if (!string.IsNullOrEmpty(model.ApiCmpMobile))
			{
				if (model.ApiCmpMobile != null)
				{
					if (model.ApiCmpMobile.Length != mobNumLen && !mobNumLenNoCheck)
					{
						ServiceResult<FullRegisterResultViewModel> serviceResult = new ServiceResult<FullRegisterResultViewModel>();
						serviceResult.Message = MyResource.GetResourceString("CheckLenMob", text8, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
						serviceResult.Data = null;
						serviceResult.Status = ServiceResultStatus.Error;
						return serviceResult;
					}
					if (model.ApiCmpMobile.Length >= 2)
					{
						string text18 = model.ApiCmpMobile.Substring(0, 2);
						if (text18 != "09" && !mobNumLenNoCheck)
						{
							ServiceResult<FullRegisterResultViewModel> serviceResult = new ServiceResult<FullRegisterResultViewModel>();
							serviceResult.Message = MyResource.GetResourceString("CheckMobileFormat", text8, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
							serviceResult.Data = null;
							serviceResult.Status = ServiceResultStatus.Error;
							return serviceResult;
						}
					}
				}
				string text19 = Company.CantSaveDupCmpMobile(model.ApiCmpMobile, 0, defLangId, currLangId, text8);
				if (!string.IsNullOrEmpty(text19))
				{
					return new ServiceResult<FullRegisterResultViewModel>
					{
						Message = text19,
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
			}
			if (model.ApiPrsMobile != null)
			{
				if (model.ApiPrsMobile.Length != mobNumLen && !mobNumLenNoCheck)
				{
					ServiceResult<FullRegisterResultViewModel> serviceResult = new ServiceResult<FullRegisterResultViewModel>();
					serviceResult.Message = MyResource.GetResourceString("CheckLenMob", text8, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
					serviceResult.Data = null;
					serviceResult.Status = ServiceResultStatus.Error;
					return serviceResult;
				}
				if (model.ApiPrsMobile.Length >= 2)
				{
					string text20 = model.ApiPrsMobile.Substring(0, 2);
					if (text20 != "09" && !mobNumLenNoCheck)
					{
						ServiceResult<FullRegisterResultViewModel> serviceResult = new ServiceResult<FullRegisterResultViewModel>();
						serviceResult.Message = MyResource.GetResourceString("CheckMobileFormat", text8, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
						serviceResult.Data = null;
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
					ServiceResult<FullRegisterResultViewModel> serviceResult = new ServiceResult<FullRegisterResultViewModel>();
					serviceResult.Message = string.Format(MyResource.GetResourceString("CheckDigit", text8, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PrsMobile", text8, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly));
					serviceResult.Data = null;
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
					ServiceResult<FullRegisterResultViewModel> serviceResult = new ServiceResult<FullRegisterResultViewModel>();
					serviceResult.Message = string.Format(MyResource.GetResourceString("CheckDigit", text8, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PrsTel", text8, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly));
					serviceResult.Data = null;
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
					ServiceResult<FullRegisterResultViewModel> serviceResult = new ServiceResult<FullRegisterResultViewModel>();
					serviceResult.Message = string.Format(MyResource.GetResourceString("CheckDigit", text8, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PrsPreTel", text8, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly));
					serviceResult.Data = null;
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
					ServiceResult<FullRegisterResultViewModel> serviceResult = new ServiceResult<FullRegisterResultViewModel>();
					serviceResult.Message = string.Format(MyResource.GetResourceString("CheckDigit", text8, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PrsTelUpTo", text8, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly));
					serviceResult.Data = null;
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
					ServiceResult<FullRegisterResultViewModel> serviceResult = new ServiceResult<FullRegisterResultViewModel>();
					serviceResult.Message = string.Format(MyResource.GetResourceString("CheckDigit", text8, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PrsTelII", text8, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly));
					serviceResult.Data = null;
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
					ServiceResult<FullRegisterResultViewModel> serviceResult = new ServiceResult<FullRegisterResultViewModel>();
					serviceResult.Message = string.Format(MyResource.GetResourceString("CheckDigit", text8, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PrsFax", text8, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly));
					serviceResult.Data = null;
					serviceResult.Status = ServiceResultStatus.Error;
					return serviceResult;
				}
			}
			if (model.ApiPrsPreTel != null && model.ApiPrsPreTel.Length > 1 && model.ApiPrsPreTel.Substring(0, 2) == "09")
			{
				ServiceResult<FullRegisterResultViewModel> serviceResult = new ServiceResult<FullRegisterResultViewModel>();
				serviceResult.Message = MyResource.GetResourceString("CheckPreTelForNotMobile", text8, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			if (model.ApiPrsTel != null && model.ApiPrsTel.Length > 1 && model.ApiPrsTel.Substring(0, 2) == "09")
			{
				ServiceResult<FullRegisterResultViewModel> serviceResult = new ServiceResult<FullRegisterResultViewModel>();
				serviceResult.Message = MyResource.GetResourceString("CheckPreTelForNotMobile", text8, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			if (model.ApiPrsTelII != null && model.ApiPrsTelII.Length > 1 && model.ApiPrsTelII.Substring(0, 2) == "09")
			{
				ServiceResult<FullRegisterResultViewModel> serviceResult = new ServiceResult<FullRegisterResultViewModel>();
				serviceResult.Message = MyResource.GetResourceString("CheckPreTelForNotMobile", text8, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			bool flag6 = false;
			bool flag7 = false;
			if (apispSelectCrmsysSetting_Result2 != null)
			{
				flag6 = ((apispSelectCrmsysSetting_Result2.CantSaveDupPrsNationalCode.HasValue && apispSelectCrmsysSetting_Result2.CantSaveDupPrsNationalCode != false) ? true : false);
				flag7 = ((apispSelectCrmsysSetting_Result2.MustFullPrsNationalCode.HasValue && apispSelectCrmsysSetting_Result2.MustFullPrsNationalCode != false) ? true : false);
			}
			if (!string.IsNullOrEmpty(model.ApiPrsTel) && flag && model.CmpTelNotDup.HasValue && model.CmpTelNotDup.GetValueOrDefault())
			{
				string text21 = Company.CantSaveDupTel(model.ApiPrsTel, 2, 0, defLangId, currLangId, text8);
				if (!string.IsNullOrEmpty(text21))
				{
					return new ServiceResult<FullRegisterResultViewModel>
					{
						Message = text21,
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
			}
			if (!string.IsNullOrEmpty(model.ApiPrsTelII) && flag && model.CmpTelNotDup.HasValue && model.CmpTelNotDup.GetValueOrDefault())
			{
				string text22 = Company.CantSaveDupTel(model.ApiPrsTelII, 2, 0, defLangId, currLangId, text8);
				if (!string.IsNullOrEmpty(text22))
				{
					return new ServiceResult<FullRegisterResultViewModel>
					{
						Message = text22,
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
			}
			if (!string.IsNullOrEmpty(model.ApiPrsFax) && flag2 && model.CmpFaxNotDup.HasValue && model.CmpFaxNotDup.GetValueOrDefault())
			{
				string text23 = Company.CantSaveDupFax(model.ApiPrsFax, 2, 0, defLangId, currLangId, text8);
				if (!string.IsNullOrEmpty(text23))
				{
					return new ServiceResult<FullRegisterResultViewModel>
					{
						Message = text23,
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
			}
			if (!string.IsNullOrEmpty(model.ApiPrsNationalCode) && flag6)
			{
				string text24 = Company.CantSaveDupPrsNationalCode(model.ApiPrsNationalCode, 0, defLangId, currLangId, text8);
				if (!string.IsNullOrEmpty(text24))
				{
					return new ServiceResult<FullRegisterResultViewModel>
					{
						Message = text24,
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
			}
			if (!string.IsNullOrEmpty(model.ApiPrsZipCode) && flag3)
			{
				string text25 = Company.CantSaveDupZipCode(model.ApiPrsZipCode, 2, 0, defLangId, currLangId, text8);
				if (!string.IsNullOrEmpty(text25))
				{
					return new ServiceResult<FullRegisterResultViewModel>
					{
						Message = text25,
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
			}
			if (string.IsNullOrEmpty(model.ApiCmpName))
			{
				model.ApiCmpName = MyResource.GetResourceString("Person", text8, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
			}
			string text26 = "";
			string text27 = "";
			string text28 = "";
			string text29 = "";
			ApispSelectCrmFoSetting_Result apispSelectCrmFoSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmFoSetting_Result>((IEnumerable<ApispSelectCrmFoSetting_Result>)list2, (Func<ApispSelectCrmFoSetting_Result, bool>)((ApispSelectCrmFoSetting_Result m) => m.LanguageID == defLangId));
			if (apispSelectCrmFoSetting_Result != null)
			{
				text26 = ((!string.IsNullOrEmpty(apispSelectCrmFoSetting_Result.PrjDefaultTitle)) ? apispSelectCrmFoSetting_Result.PrjDefaultTitle : "");
				text27 = ((!string.IsNullOrEmpty(apispSelectCrmFoSetting_Result.PrjDefaultPostFix)) ? apispSelectCrmFoSetting_Result.PrjDefaultPostFix : "");
				text28 = ((!string.IsNullOrEmpty(apispSelectCrmFoSetting_Result.CnvsDefaultDesc)) ? apispSelectCrmFoSetting_Result.CnvsDefaultDesc.Replace("\r\n", "<BR>") : "");
				text29 = ((!string.IsNullOrEmpty(apispSelectCrmFoSetting_Result.CnvsDefaultReferDesc)) ? apispSelectCrmFoSetting_Result.CnvsDefaultReferDesc.Replace("\r\n", "<BR>") : null);
			}
			if (!string.IsNullOrEmpty(model.Value))
			{
				model.Value = "<BR>" + model.Value.Replace("\r\n", "<BR>");
			}
			string text30 = "";
			if (!string.IsNullOrEmpty(model.ApiPrjTitle))
			{
				text30 = model.ApiPrjTitle + ((!string.IsNullOrEmpty(model.ApiPrjPostFix)) ? (" " + model.ApiPrjPostFix) : "");
			}
			else
			{
				text30 = text26 + ((text27 != "") ? (" " + text27) : "");
			}
			List<ApispSelectPersonTitleWithId_Result> list3 = new List<ApispSelectPersonTitleWithId_Result>();
			if (model.ApiPrsTitleId.HasValue)
			{
				list3 = Enumerable.ToList<ApispSelectPersonTitleWithId_Result>((IEnumerable<ApispSelectPersonTitleWithId_Result>)cRMEntities.ApispSelectPersonTitleWithId(model.ApiPrsTitleId));
			}
			string text31 = "";
			if (Enumerable.Any<ApispSelectPersonTitleWithId_Result>((IEnumerable<ApispSelectPersonTitleWithId_Result>)list3))
			{
				ApispSelectPersonTitleWithId_Result apispSelectPersonTitleWithId_Result = Enumerable.FirstOrDefault<ApispSelectPersonTitleWithId_Result>((IEnumerable<ApispSelectPersonTitleWithId_Result>)list3, (Func<ApispSelectPersonTitleWithId_Result, bool>)((ApispSelectPersonTitleWithId_Result m) => m.LanguageID == defLangId));
				text31 = ((apispSelectPersonTitleWithId_Result != null && !string.IsNullOrEmpty(apispSelectPersonTitleWithId_Result.PersonTitle)) ? apispSelectPersonTitleWithId_Result.PersonTitle : "");
			}
			string text32 = text31 + ((!string.IsNullOrEmpty(model.ApiPrsFName)) ? (" " + model.ApiPrsFName) : "") + ((!string.IsNullOrEmpty(model.ApiPrsLName)) ? (" " + model.ApiPrsLName) : "");
			List<ApispSelectCompanyTitleWithId_Result> list4 = new List<ApispSelectCompanyTitleWithId_Result>();
			if (model.ApiCmpTitleId.HasValue)
			{
				list4 = Enumerable.ToList<ApispSelectCompanyTitleWithId_Result>((IEnumerable<ApispSelectCompanyTitleWithId_Result>)cRMEntities.ApispSelectCompanyTitleWithId(model.ApiCmpTitleId));
			}
			string text33 = "";
			if (Enumerable.Any<ApispSelectCompanyTitleWithId_Result>((IEnumerable<ApispSelectCompanyTitleWithId_Result>)list4))
			{
				ApispSelectCompanyTitleWithId_Result apispSelectCompanyTitleWithId_Result = Enumerable.FirstOrDefault<ApispSelectCompanyTitleWithId_Result>((IEnumerable<ApispSelectCompanyTitleWithId_Result>)list4, (Func<ApispSelectCompanyTitleWithId_Result, bool>)((ApispSelectCompanyTitleWithId_Result m) => m.LanguageID == defLangId));
				text33 = ((apispSelectCompanyTitleWithId_Result != null && !string.IsNullOrEmpty(apispSelectCompanyTitleWithId_Result.CompanyTitle)) ? apispSelectCompanyTitleWithId_Result.CompanyTitle : "");
			}
			string text34 = text33 + ((!string.IsNullOrEmpty(model.ApiCmpName)) ? (" " + model.ApiCmpName) : "");
			string text35 = ((!string.IsNullOrEmpty(model.ApiCnvsDesc)) ? model.ApiCnvsDesc.Replace("\r\n", "<BR>") : text28);
			string text36 = ((!string.IsNullOrEmpty(model.ApiCnvsReferDesc)) ? model.ApiCnvsReferDesc.Replace("\r\n", "<BR>") : text29);
			string userName = CommonClass.GetUserName(model.UserId, defLangId, defLangId);
			int userId = model.UserId;
			DateTime now = DateTime.Now;
			DateTime value = now;
			string text37 = now.ToString("yyyyMMdd", new PersianCulture());
			short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string dubClickDisplayCmpInfo = Messages.DubClickDisplayCmpInfo;
			string appType = CRMIdealApi.Classes.Configuration.AppType;
			short num = short.Parse(now.ToString("yyyy", new PersianCulture()));
			CommonClass commonClass = new CommonClass();
			string text38 = commonClass.ConvertNameToDayNum(now.DayOfWeek.ToString());
			string text39 = now.ToString("HH:mm:ss");
			string person = Labels.Person;
			if (!string.IsNullOrEmpty(model.ApiCmpPassword))
			{
				model.ApiCmpPassword = ((!string.IsNullOrEmpty(model.ApiCmpPassword)) ? XorCipher.EncryptByPublicKey(model.ApiCmpPassword) : null);
			}
			string text40 = "";
			string text41 = "";
			string text42 = "";
			foreach (ApispSelectLanguages_Result lang2 in list)
			{
				string text43 = "";
				string text44 = "";
				string text45 = "";
				string text46 = "";
				ApispSelectCrmFoSetting_Result apispSelectCrmFoSetting_Result2 = Enumerable.FirstOrDefault<ApispSelectCrmFoSetting_Result>((IEnumerable<ApispSelectCrmFoSetting_Result>)list2, (Func<ApispSelectCrmFoSetting_Result, bool>)((ApispSelectCrmFoSetting_Result m) => m.LanguageID == lang2.LanguageID));
				if (apispSelectCrmFoSetting_Result2 != null)
				{
					text43 = ((!string.IsNullOrEmpty(apispSelectCrmFoSetting_Result2.PrjDefaultTitle)) ? apispSelectCrmFoSetting_Result2.PrjDefaultTitle : "");
					text44 = ((!string.IsNullOrEmpty(apispSelectCrmFoSetting_Result2.PrjDefaultPostFix)) ? apispSelectCrmFoSetting_Result2.PrjDefaultPostFix : "");
					text45 = ((!string.IsNullOrEmpty(apispSelectCrmFoSetting_Result2.CnvsDefaultDesc)) ? apispSelectCrmFoSetting_Result2.CnvsDefaultDesc.Replace("\r\n", "<BR>") : "");
					text46 = ((!string.IsNullOrEmpty(apispSelectCrmFoSetting_Result2.CnvsDefaultReferDesc)) ? apispSelectCrmFoSetting_Result2.CnvsDefaultReferDesc.Replace("\r\n", "<BR>") : null);
				}
				text43 = ((!string.IsNullOrEmpty(model.ApiPrjTitle)) ? model.ApiPrjTitle : text43);
				text44 = ((!string.IsNullOrEmpty(model.ApiPrjPostFix)) ? model.ApiPrjPostFix : text44);
				text45 = ((!string.IsNullOrEmpty(model.ApiCnvsDesc)) ? model.ApiCnvsDesc.Replace("\r\n", "<BR>") : text45);
				text46 = ((!string.IsNullOrEmpty(model.ApiCnvsReferDesc)) ? model.ApiCnvsReferDesc.Replace("\r\n", "<BR>") : text46);
				text40 = "";
				text41 = "";
				text40 = MyResource.GetResourceString("ErjaFrom", lang2.LanguageCollation, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + " " + CommonClass.GetUserName(model.UserId, defLangId, lang2.LanguageID);
				text41 = MyResource.GetResourceString("ErjaInConnection", lang2.LanguageCollation, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": " + text34 + "<BR>" + MyResource.GetResourceString("ErjaPerson", lang2.LanguageCollation, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": " + text32 + "<BR>" + MyResource.GetResourceString("ErjaProject", lang2.LanguageCollation, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": " + ((!string.IsNullOrEmpty(text43)) ? text43 : "") + ((!string.IsNullOrEmpty(text44)) ? (" " + text44) : "");
				if (!string.IsNullOrEmpty(model.ApiCnvsReferToMultilUser))
				{
					string[] array = model.ApiCnvsReferToMultilUser.Split(new char[1] { ',' });
					if (Enumerable.Any<string>((IEnumerable<string>)array))
					{
						string text47 = "";
						string[] array2 = array;
						foreach (string text48 in array2)
						{
							int num2 = ((!string.IsNullOrEmpty(text48)) ? int.Parse(text48) : 0);
							if (num2 > 0)
							{
								string text49 = ((num2 > 0) ? CommonClass.GetUserName(num2, defLangId, lang2.LanguageID) : "");
								text47 = text47 + text49 + ",";
							}
						}
						text47 = ((!string.IsNullOrEmpty(text47)) ? text47.TrimEnd(new char[1] { ',' }) : "");
						if (text47 != "")
						{
							text41 = text41 + "<BR>" + MyResource.GetResourceString("ErjaMultiUser", lang2.LanguageCollation, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": " + text47;
						}
					}
				}
				text41 = text41 + "<BR><BR>" + MyResource.GetResourceString("ErjaConversationDescription", lang2.LanguageCollation, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ":<BR>" + text45.Replace("\r\n", "<BR>") + ((!string.IsNullOrEmpty(model.Value)) ? model.Value : "");
				string text50 = text46;
				if (!string.IsNullOrEmpty(text50))
				{
					text41 = text41 + "<BR>" + MyResource.GetResourceString("ErjaReferDescription", lang2.LanguageCollation, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ":<BR>" + text50.Replace("\r\n", "<BR>");
				}
				text41 = text41 + "<BR><BR>" + MyResource.GetResourceString("ErjaDetails", lang2.LanguageCollation, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				text42 = text42 + "MsgSubj=" + text40 + "|@#@|MsgBody=" + text41 + "|@#@|LangId=" + lang2.LanguageID + "|@#@||^#^|";
			}
			string text51 = "";
			string text52 = "";
			string text53 = "";
			if (!string.IsNullOrEmpty(model.ApiCnvsReferToMultilUser))
			{
				string[] array3 = model.ApiCnvsReferToMultilUser.Split(new char[1] { ',' });
				if (Enumerable.Any<string>((IEnumerable<string>)array3))
				{
					foreach (ApispSelectLanguages_Result lang in list)
					{
						string text54 = "";
						string[] array4 = array3;
						foreach (string text55 in array4)
						{
							int num3 = ((!string.IsNullOrEmpty(text55)) ? int.Parse(text55) : 0);
							if (num3 > 0)
							{
								string text56 = ((num3 > 0) ? CommonClass.GetUserName(num3, defLangId, lang.LanguageID) : "");
								text54 = text54 + text56 + ",";
							}
						}
						text54 = ((!string.IsNullOrEmpty(text54)) ? text54.TrimEnd(new char[1] { ',' }) : "");
						string text57 = "";
						string text58 = "";
						string text59 = "";
						string text60 = "";
						ApispSelectCrmFoSetting_Result apispSelectCrmFoSetting_Result3 = Enumerable.FirstOrDefault<ApispSelectCrmFoSetting_Result>((IEnumerable<ApispSelectCrmFoSetting_Result>)list2, (Func<ApispSelectCrmFoSetting_Result, bool>)((ApispSelectCrmFoSetting_Result m) => m.LanguageID == lang.LanguageID));
						if (apispSelectCrmFoSetting_Result3 != null)
						{
							text57 = ((!string.IsNullOrEmpty(apispSelectCrmFoSetting_Result3.PrjDefaultTitle)) ? apispSelectCrmFoSetting_Result3.PrjDefaultTitle : "");
							text58 = ((!string.IsNullOrEmpty(apispSelectCrmFoSetting_Result3.PrjDefaultPostFix)) ? apispSelectCrmFoSetting_Result3.PrjDefaultPostFix : "");
							text59 = ((!string.IsNullOrEmpty(apispSelectCrmFoSetting_Result3.CnvsDefaultDesc)) ? apispSelectCrmFoSetting_Result3.CnvsDefaultDesc.Replace("\r\n", "<BR>") : "");
							text60 = ((!string.IsNullOrEmpty(apispSelectCrmFoSetting_Result3.CnvsDefaultReferDesc)) ? apispSelectCrmFoSetting_Result3.CnvsDefaultReferDesc.Replace("\r\n", "<BR>") : null);
						}
						text57 = ((!string.IsNullOrEmpty(model.ApiPrjTitle)) ? model.ApiPrjTitle : text57);
						text58 = ((!string.IsNullOrEmpty(model.ApiPrjPostFix)) ? model.ApiPrjPostFix : text58);
						text59 = ((!string.IsNullOrEmpty(model.ApiCnvsDesc)) ? model.ApiCnvsDesc.Replace("\r\n", "<BR>") : text59);
						text60 = ((!string.IsNullOrEmpty(model.ApiCnvsReferDesc)) ? model.ApiCnvsReferDesc.Replace("\r\n", "<BR>") : text60);
						text51 = "";
						text52 = "";
						text51 = MyResource.GetResourceString("ErjaRonevesht", lang.LanguageCollation, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + " " + CommonClass.GetUserName(model.UserId, defLangId, lang.LanguageID);
						text52 = MyResource.GetResourceString("ErjaInConnection", lang.LanguageCollation, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": " + text34 + "<BR>" + MyResource.GetResourceString("ErjaPerson", lang.LanguageCollation, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": " + text32 + "<BR>" + MyResource.GetResourceString("ErjaProject", lang.LanguageCollation, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": " + ((!string.IsNullOrEmpty(text57)) ? text57 : "") + ((!string.IsNullOrEmpty(text58)) ? (" " + text58) : "");
						if (text54 != "")
						{
							text52 = text52 + "<BR>" + MyResource.GetResourceString("ErjaMultiUser", lang.LanguageCollation, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": " + text54;
						}
						text52 = text52 + "<BR><BR>" + MyResource.GetResourceString("ErjaConversationDescription", lang.LanguageCollation, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ":<BR>" + text59.Replace("\r\n", "<BR>") + ((!string.IsNullOrEmpty(model.Value)) ? model.Value : "");
						text52 = text52 + "<BR><BR>" + MyResource.GetResourceString("ErjaDetails", lang.LanguageCollation, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
						text53 = text53 + "MsgSubj=" + text51 + "|@#@|MsgBody=" + text52 + "|@#@|LangId=" + lang.LanguageID + "|@#@||^#^|";
					}
				}
			}
			ObjectParameter objectParameter = new ObjectParameter("InsertedCompanyId", 0);
			ObjectParameter objectParameter2 = new ObjectParameter("InsertedPersonId", 0);
			ObjectParameter objectParameter3 = new ObjectParameter("InsertedProjectId", 0);
			ObjectParameter objectParameter4 = new ObjectParameter("InsertedConversationId", 0);
			ObjectParameter objectParameter5 = new ObjectParameter("ErrorMessage", "");
			string text61 = "";
			string text62 = "";
			string text63 = "";
			string leftPart = base.Request.RequestUri.GetLeftPart(UriPartial.Authority);
			string leftPart2 = base.Request.RequestUri.GetLeftPart(UriPartial.Scheme);
			string text64 = leftPart;
			if (text64.EndsWith("/"))
			{
				text64 = text64.TrimEnd(new char[1] { '/' });
			}
			text64 += "/Survey/Home/SurveyAnswerValues";
			text61 = text64;
			CRMEntities cRMEntities2 = cRMEntities;
			string userName2 = model.UserName;
			string password = model.Password;
			string apiCmpName = model.ApiCmpName;
			int? num4 = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities2.ApispRegisterCompanyWithCnvsKaraAfzar(cmpNumber: model.ApiCmpNumber, cmpName: apiCmpName, cmpNameEng: model.ApiCmpNameEng, cmpTitleId: model.ApiCmpTitleId, cmpFame: model.ApiCmpFame, cmpActivityType: model.ApiCmpActivityType, cmpGroupId: model.ApiCmpGroupId, cmpSubGroupId: model.ApiCmpSubGroupId, cmpGroupIdII: model.ApiCmpGroupIdII, cmpGroupIdIII: model.ApiCmpGroupIdIII, cmpGroupIdIV: model.ApiCmpGroupIdIV, cmpTypeId: model.ApiCmpTypeId, cmpPresentationId: model.ApiCmpPresentationId, cmpPreTel: model.ApiCmpPreTel, cmpTel: model.ApiCmpTel, cmpTelUpTo: model.ApiCmpTelUpTo, cmpTelDesc: model.ApiCmpTelDesc, cmpPreTelII: model.ApiCmpPreTelII, cmpTelII: model.ApiCmpTelII, cmpTelUpToII: model.ApiCmpTelUpToII, cmpTelIIDesc: model.ApiCmpTelIIDesc, cmpMobile: null, cmpFax: model.ApiCmpFax, cmpFaxDesc: model.ApiCmpFaxDesc, cmpCountryId: model.ApiCmpCountryId, cmpProvinceId: model.ApiCmpProvinceId, cmpCityId: model.ApiCmpCityId, cmpAddress: model.ApiCmpAddress, cmpAddressDesc: model.ApiCmpAddressDesc, cmpZipCode: model.ApiCmpZipCode, cmpPostBox: model.ApiCmpPostBox, cmpWebSite: model.ApiCmpWebSite, cmpEmail: model.ApiCmpEmail, cmpInteresting: model.ApiCmpInteresting, cmpSpecialPoint: model.ApiCmpSpecialPoint, cmpDescription: model.ApiCmpDescription, cmpUserName: model.ApiCmpUserName, cmpPassword: model.ApiCmpPassword, cmpRegistrationNumber: model.ApiCmpRegistrationNumber, cmpEconomicCode: model.ApiCmpEconomicCode, cmpNationalCode: model.ApiCmpNationalCode, cmpBuyLimit: model.ApiCmpBuyLimit, cmpAccountNumber: model.ApiCmpAccountNumber, cmpAccInquiry: model.ApiCmpAccInquiry, cmpFreight: model.ApiCmpFreight, cmpInquiry: model.ApiCmpInquiry, cmpReferUserId: model.ApiCmpReferUserId, cmpSpecialWordForCI: model.ApiCmpSpecialWordForCI, cmpCode: model.ApiCmpCode, cmpEffectiveDatePersian: text2, cmpEffectiveDateTime: model.ApiCmpEffectiveDateTime, cmpCoordinateLatitude: model.ApiCmpCoordinateLatitude, cmpCoordinateLongitude: model.ApiCmpCoordinateLongitude, cmpCoordinateLastDate: model.ApiCmpCoordinateLastDate, cmpCoordinateLastDatePersian: text3, cmpCoordinateZoomLevel: model.ApiCmpCoordinateZoomLevel, cmpCoordinateLastUserId: model.ApiCmpCoordinateLastUserId, prsLName: model.ApiPrsLName, prsFName: model.ApiPrsFName, prsTitleId: model.ApiPrsTitleId, prsJobId: model.ApiPrsJobId, prsTypeId: model.ApiPrsTypeId, prsGroupId: model.ApiPrsGroupId, prsSexId: model.ApiPrsSexId, prsPreTel: model.ApiPrsPreTel, prsTel: model.ApiPrsTel, prsTelUpTo: model.ApiPrsTelUpTo, prsTelDesc: model.ApiPrsTelDesc, prsTelII: model.ApiPrsTelII, prsFax: model.ApiPrsFax, prsFaxDesc: model.ApiPrsFaxDesc, prsMobile: model.ApiPrsMobile, prsEmail: model.ApiPrsEmail, prsEmailII: model.ApiPrsEmailII, prsAddress: model.ApiPrsAddress, prsAddressDesc: model.ApiPrsAddressDesc, prsNationalCode: model.ApiPrsNationalCode, prsBirthDate: text4, prsBirthDateTime: model.ApiPrsBirthDateTime, prsMarriageDate: text5, prsMarriageDateTime: model.ApiPrsMarriageDateTime, prsDescription: model.ApiPrsDescription, prsDepartmentId: model.ApiPrsDepartmentId, prjTitle: model.ApiPrjTitle, prjDesc: model.ApiPrjDesc, prjStarterUserId: model.ApiPrjStarterUserId, prjGradeId: model.ApiPrjGradeId, prjPriorityId: model.ApiPrjPriorityId, prjGroupId: model.ApiPrjGroupId, prjcnvsStatusGroupId: model.ApiPrjCnvsStatusGroupId, prjPostFix: model.ApiPrjPostFix, prjRemindDate: text6, prjRemindDateTime: model.ApiPrjRemindDateTime, prjInsertCrmProjectForbiddenFUFDPActive: model.ApiPrjInsertCrmProjectForbiddenFUFDPActive, cnvsTopicId: model.ApiCnvsTopicId, cnvsDesc: text35, cnvsUserId: model.ApiCnvsUserId, cnvsReferUserId: model.ApiCnvsReferUserId, cnvsReferDesc: text36, cnvsStatusId: model.ApiCnvsStatusId, cnvsPriorityId: model.ApiCnvsPriorityId, cnvsRemindDate: text7, cnvsRemindDateTime: model.ApiCnvsRemindDateTime, cnvsReferToMultilUser: model.ApiCnvsReferToMultilUser, userId: userId, month1: value2, registerDate: value, registerDatePersian: text37, registerTime: text39, registerDay: text38, appType: appType, needErjaRefMsgSubject: "", needErjaRefMsgBody: text42, needErjaMultiIntmsgSubject: "", needErjaMultiIntmsgBody: text53, conversationErjaShowText: dubClickDisplayCmpInfo, value: model.Value, insertedCompanyId: objectParameter, insertedPersonId: objectParameter2, insertedProjectId: objectParameter3, insertedConversationId: objectParameter4, errorMessage: objectParameter5, cmpCodeNotDup: model.CmpCodeNotDup, cmpCampaignIds: model.ApiCmpCampaignIds, prjCmpPresentationId: model.ApiPrjCmpPresentationId, prjCmpCampaignIds: model.ApiPrjCmpCampaignIds, cmpCampaignName: model.ApiCmpCampaignName, prjCampaignName: model.ApiPrjCmpCampaignName, cnvsStatusResultId: model.ApiCnvsStatusResultId, surveyMainInternalLink: text61, surveyMainExtrenalLink: text62, surveyMainExtrenalLinkLogin: text63, centerId: model.CenterId, centerCode: model.CenterCode, userName: userName2, password: password, cmpKind: model.ApiCmpKind));
			string resourceString = MyResource.GetResourceString("ErrorDoneOperationTryAgain", text8, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
			string resourceString2 = MyResource.GetResourceString("ErrorTryAgain", text8, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
			int result = 0;
			int.TryParse(num4.ToString(), out result);
			if (result <= 0)
			{
				return new ServiceResult<FullRegisterResultViewModel>
				{
					Message = resourceString.Replace("<br>", "\r\n"),
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			if (objectParameter5.Value != null && objectParameter5.Value.ToString() != "")
			{
				string text65 = "";
				string text66 = objectParameter5.Value.ToString();
				if (text66.IndexOf("IsUser=0", StringComparison.Ordinal) >= 0)
				{
					text65 = text65 + MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", text8, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "<br>";
					resourceString2 = "<br>" + MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", text8, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + resourceString2;
					return new ServiceResult<FullRegisterResultViewModel>
					{
						Message = resourceString2.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text66.IndexOf("DupUName=1", StringComparison.Ordinal) >= 0)
				{
					text65 = text65 + MyResource.GetResourceString("ErrorUsernameIsRepeat", text8, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "<br>";
					resourceString2 = "<br>" + MyResource.GetResourceString("ErrorUsernameIsRepeat", text8, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + resourceString2;
					return new ServiceResult<FullRegisterResultViewModel>
					{
						Message = resourceString2.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text66.IndexOf("DupCmpCode=", StringComparison.Ordinal) >= 0)
				{
					string[] array5 = text66.Split(new char[1] { '|' });
					string arg = "";
					if (array5 != null)
					{
						string[] array6 = array5;
						foreach (string text67 in array6)
						{
							if (!string.IsNullOrEmpty(text67) && text67.IndexOf("DupCmpCode=", StringComparison.Ordinal) >= 0)
							{
								string[] array7 = text67.Split(new char[1] { '=' });
								if (array7 != null && array7.Length == 2)
								{
									arg = ((array7[1] != null && array7[1] != "") ? array7[1] : "");
								}
							}
						}
					}
					text65 = text65 + string.Format(MyResource.GetResourceString("ErrorCheckCmpCodeDuplicate", text8, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), model.ApiCmpCode, arg) + "<br>";
					return new ServiceResult<FullRegisterResultViewModel>
					{
						Message = text65.Replace("<br>", "\r\n") + resourceString2.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text66.IndexOf("DupMob=", StringComparison.Ordinal) >= 0)
				{
					string[] array8 = text66.Split(new char[1] { '|' });
					string arg2 = "";
					if (array8 != null)
					{
						string[] array9 = array8;
						foreach (string text68 in array9)
						{
							if (!string.IsNullOrEmpty(text68) && text68.IndexOf("DupMob=", StringComparison.Ordinal) >= 0)
							{
								string[] array10 = text68.Split(new char[1] { '=' });
								if (array10 != null && array10.Length == 2)
								{
									arg2 = ((array10[1] != null && array10[1] != "") ? array10[1] : "");
								}
							}
						}
					}
					text65 = text65 + string.Format(MyResource.GetResourceString("ErrorCheckPrsMobileDuplicate", text8, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), model.ApiPrsMobile, arg2) + "<br>";
					resourceString2 = "<br>" + MyResource.GetResourceString("ErrorMobileAlreadyRegistered", text8, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + resourceString2;
					return new ServiceResult<FullRegisterResultViewModel>
					{
						Message = resourceString2.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text66.IndexOf("DupEmailI=", StringComparison.Ordinal) >= 0)
				{
					string[] array11 = text66.Split(new char[1] { '|' });
					string arg3 = "";
					if (array11 != null)
					{
						string[] array12 = array11;
						foreach (string text69 in array12)
						{
							if (!string.IsNullOrEmpty(text69) && text69.IndexOf("DupEmailI=", StringComparison.Ordinal) >= 0)
							{
								string[] array13 = text69.Split(new char[1] { '=' });
								if (array13 != null && array13.Length == 2)
								{
									arg3 = ((array13[1] != null && array13[1] != "") ? array13[1] : "");
								}
							}
						}
					}
					text65 = text65 + string.Format(MyResource.GetResourceString("ErrorCheckPrsEmailDuplicate", text8, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), model.ApiPrsEmail, arg3) + "<br>";
					resourceString2 = "<br>" + MyResource.GetResourceString("ErrorEmailAlreadyRegistered", text8, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + resourceString2;
					return new ServiceResult<FullRegisterResultViewModel>
					{
						Message = resourceString2.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text66.IndexOf("DupEmailII=", StringComparison.Ordinal) >= 0)
				{
					string[] array14 = text66.Split(new char[1] { '|' });
					string arg4 = "";
					if (array14 != null)
					{
						string[] array15 = array14;
						foreach (string text70 in array15)
						{
							if (!string.IsNullOrEmpty(text70) && text70.IndexOf("DupEmailII=", StringComparison.Ordinal) >= 0)
							{
								string[] array16 = text70.Split(new char[1] { '=' });
								if (array16 != null && array16.Length == 2)
								{
									arg4 = ((array16[1] != null && array16[1] != "") ? array16[1] : "");
								}
							}
						}
					}
					text65 = text65 + string.Format(MyResource.GetResourceString("ErrorCheckPrsEmailDuplicate", text8, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), model.ApiPrsEmail, arg4) + "<br>";
					resourceString2 = "<br>" + MyResource.GetResourceString("ErrorEmailIIAlreadyRegistered", text8, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + resourceString2;
					return new ServiceResult<FullRegisterResultViewModel>
					{
						Message = resourceString2.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text66.IndexOf("No Center|", StringComparison.Ordinal) >= 0)
				{
					text65 = text65 + MyResource.GetResourceString("msgErrorCenterNotFound", text8, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "<br>";
					return new ServiceResult<FullRegisterResultViewModel>
					{
						Message = resourceString.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text66.IndexOf("ErrorInInsertCompany|", StringComparison.Ordinal) >= 0)
				{
					text65 = text65 + MyResource.GetResourceString("ErrorInInsertCompany", text8, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "<br>";
					return new ServiceResult<FullRegisterResultViewModel>
					{
						Message = resourceString.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text66.IndexOf("ErrorInInsertPerson|", StringComparison.Ordinal) >= 0)
				{
					text65 = text65 + MyResource.GetResourceString("ErrorInInsertPerson", text8, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "<br>";
					return new ServiceResult<FullRegisterResultViewModel>
					{
						Message = resourceString.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text66.IndexOf("ErrorInInsertProject|", StringComparison.Ordinal) >= 0)
				{
					text65 = text65 + MyResource.GetResourceString("ErrorInInsertProject", text8, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "<br>";
					return new ServiceResult<FullRegisterResultViewModel>
					{
						Message = resourceString.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text66.IndexOf("ErrorInInsertConversation|", StringComparison.Ordinal) >= 0)
				{
					text65 = text65 + MyResource.GetResourceString("ErrorInInsertConversation", text8, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "<br>";
					return new ServiceResult<FullRegisterResultViewModel>
					{
						Message = resourceString.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text66.IndexOf("ErrorDupReqCnvs|", StringComparison.Ordinal) >= 0)
				{
					string message2 = MyResource.GetResourceString("ErrorDupReqCnvs", text8, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "<br>";
					return new ServiceResult<FullRegisterResultViewModel>
					{
						Message = message2,
						Data = null,
						Status = ServiceResultStatus.Fail
					};
				}
			}
			else
			{
				if (objectParameter == null || objectParameter.Value.ToString() == "0")
				{
					return new ServiceResult<FullRegisterResultViewModel>
					{
						Message = resourceString.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (objectParameter2 == null || objectParameter2.Value.ToString() == "0")
				{
					return new ServiceResult<FullRegisterResultViewModel>
					{
						Message = resourceString.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (objectParameter3 == null || objectParameter3.Value.ToString() == "0")
				{
					return new ServiceResult<FullRegisterResultViewModel>
					{
						Message = resourceString.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (objectParameter4 == null || objectParameter4.Value.ToString() == "0")
				{
					return new ServiceResult<FullRegisterResultViewModel>
					{
						Message = resourceString.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				PushNotif.NewIntMsgNotify(currLangId, defLangId);
				FullRegisterResultViewModel fullRegisterResultViewModel = new FullRegisterResultViewModel();
				fullRegisterResultViewModel.CompanyId = ((objectParameter.Value != null) ? int.Parse(objectParameter.Value.ToString() ?? "0") : 0);
				fullRegisterResultViewModel.PersonId = ((objectParameter2.Value != null) ? int.Parse(objectParameter2.Value.ToString() ?? "0") : 0);
				fullRegisterResultViewModel.ProjectId = ((objectParameter3.Value != null) ? int.Parse(objectParameter3.Value.ToString() ?? "0") : 0);
				fullRegisterResultViewModel.ConversationId = ((objectParameter4.Value != null) ? int.Parse(objectParameter4.Value.ToString() ?? "0") : 0);
				data = fullRegisterResultViewModel;
				message = MyResource.GetResourceString("SuccessDoneRegister", text8, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				status = ServiceResultStatus.Success;
			}
		}
		catch (Exception ex)
		{
			string text71 = ((!string.IsNullOrEmpty(ex.Message)) ? ex.Message : "");
			if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
			{
				text71 = text71 + " - " + ex.InnerException.Message;
			}
			message = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text71)) ? (" (" + text71 + ")") : "");
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(ex);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<FullRegisterResultViewModel>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<List<ApispSelectLinkedCompany_Result>> SelectLinkedCompany(SelectLinkedCompanyViewModel model)
	{
		CRMEntities cRMEntities = null;
		List<ApispSelectLinkedCompany_Result> data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				return new ServiceResult<List<ApispSelectLinkedCompany_Result>>
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
				return new ServiceResult<List<ApispSelectLinkedCompany_Result>>
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
				ServiceResult<List<ApispSelectLinkedCompany_Result>> serviceResult = new ServiceResult<List<ApispSelectLinkedCompany_Result>>();
				serviceResult.Message = MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			List<ApispSelectLinkedCompany_Result> list2 = Enumerable.ToList<ApispSelectLinkedCompany_Result>((IEnumerable<ApispSelectLinkedCompany_Result>)cRMEntities.ApispSelectLinkedCompany(model.CompanyId, currLangId, result));
			if (list2 != null)
			{
				foreach (ApispSelectLinkedCompany_Result item in list2)
				{
					item.RegisterDatePersian = item.RegisterDate.ToString("yyyy/MM/dd HH:mm:ss", new CultureInfo(model.LanguageId.GetValueOrDefault(1065)));
				}
				data = list2;
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
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(ex);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<List<ApispSelectLinkedCompany_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<bool?> InsertLinkedCompany(InsertLinkedCompanyViewModel model)
	{
		CRMEntities cRMEntities = null;
		bool? data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			DateTime now = DateTime.Now;
			DateTime value = now;
			string persianDate = now.ToString("yyyyMMdd", new PersianCulture());
			short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = CRMIdealApi.Classes.Configuration.AppType;
			if (!VersionBuyer.CRMApi)
			{
				return new ServiceResult<bool?>
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
				return new ServiceResult<bool?>
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
				ServiceResult<bool?> serviceResult = new ServiceResult<bool?>();
				serviceResult.Message = MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			int num2 = cRMEntities.ApispInsertLinkedCompany(model.CompanyId, model.LinkedCompanyId, model.UserId, persianDate, value, 0, value2, appType, currLangId);
			status = ServiceResultStatus.Success;
			data = true;
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
		return new ServiceResult<bool?>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<bool?> DeleteAllLinkedCompany(DeleteAllLinkedCompanyViewModel model)
	{
		CRMEntities cRMEntities = null;
		bool? data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			DateTime now = DateTime.Now;
			DateTime dateTime = now;
			string text = now.ToString("yyyyMMdd", new PersianCulture());
			short num = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = CRMIdealApi.Classes.Configuration.AppType;
			if (!VersionBuyer.CRMApi)
			{
				return new ServiceResult<bool?>
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
				return new ServiceResult<bool?>
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
			int? num2 = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.ApispCheckUserAllowed(model.UserName, model.Password));
			int result2 = 0;
			int.TryParse(num2.ToString(), out result2);
			if (result2 == 0)
			{
				ServiceResult<bool?> serviceResult = new ServiceResult<bool?>();
				serviceResult.Message = MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			int num3 = cRMEntities.ApispDeleteAllLinkedCompany(model.CompanyId);
			status = ServiceResultStatus.Success;
			data = true;
		}
		catch (Exception ex)
		{
			string text2 = ((!string.IsNullOrEmpty(ex.Message)) ? ex.Message : "");
			if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
			{
				text2 = text2 + " - " + ex.InnerException.Message;
			}
			message = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text2)) ? (" (" + text2 + ")") : "");
			data = false;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(ex);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<bool?>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<bool?> DeleteLinkedCompany(DeleteLinkedCompanyViewModel model)
	{
		CRMEntities cRMEntities = null;
		bool? data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			DateTime now = DateTime.Now;
			DateTime dateTime = now;
			string text = now.ToString("yyyyMMdd", new PersianCulture());
			short num = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = CRMIdealApi.Classes.Configuration.AppType;
			if (!VersionBuyer.CRMApi)
			{
				return new ServiceResult<bool?>
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
				return new ServiceResult<bool?>
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
			int? num2 = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.ApispCheckUserAllowed(model.UserName, model.Password));
			int result2 = 0;
			int.TryParse(num2.ToString(), out result2);
			if (result2 == 0)
			{
				ServiceResult<bool?> serviceResult = new ServiceResult<bool?>();
				serviceResult.Message = MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			ObjectResult<mct_Result> objectResult = cRMEntities.ApispDeleteLinkedCompany(model.CompanyId, model.LinkedCompanyId);
			status = ServiceResultStatus.Success;
			data = true;
		}
		catch (Exception ex)
		{
			string text2 = ((!string.IsNullOrEmpty(ex.Message)) ? ex.Message : "");
			if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
			{
				text2 = text2 + " - " + ex.InnerException.Message;
			}
			message = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text2)) ? (" (" + text2 + ")") : "");
			data = false;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(ex);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<bool?>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<List<ApispSelectCompanyMoneyBag_Result>> SelectCompanyMoneyBag(SelectCompanyMoneyBagViewModel model)
	{
		CRMEntities cRMEntities = null;
		List<ApispSelectCompanyMoneyBag_Result> data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				return new ServiceResult<List<ApispSelectCompanyMoneyBag_Result>>
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
				return new ServiceResult<List<ApispSelectCompanyMoneyBag_Result>>
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
				ServiceResult<List<ApispSelectCompanyMoneyBag_Result>> serviceResult = new ServiceResult<List<ApispSelectCompanyMoneyBag_Result>>();
				serviceResult.Message = MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			List<ApispSelectCompanyMoneyBag_Result> list2 = Enumerable.ToList<ApispSelectCompanyMoneyBag_Result>((IEnumerable<ApispSelectCompanyMoneyBag_Result>)cRMEntities.ApispSelectCompanyMoneyBag(model.CompanyId, model.FDateTime, model.TDateTime, model.TextRemainderBefore, model.TextManual, model.TextSystemic, currLangId, result, model.CenterId, model.CenterCode));
			if (list2 != null)
			{
				data = list2;
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
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(ex);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<List<ApispSelectCompanyMoneyBag_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<int?> InsertCompanyMoneyBag(InsertCompanyMoneyBagViewModel model)
	{
		//IL_0399: Unknown result type (might be due to invalid IL or missing references)
		CRMEntities cRMEntities = null;
		ResourceManager resourceManager = new ResourceManager();
		int? data = null;
		string text = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = CRMIdealApi.Classes.Configuration.AppType;
			if (!VersionBuyer.CRMApi)
			{
				return new ServiceResult<int?>
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
				return new ServiceResult<int?>
				{
					Message = Messages.ErrorInReadingSysSetting,
					Data = null,
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
			string text2 = "fa-IR";
			ApispSelectLanguages_Result apispSelectLanguages_Result = Enumerable.FirstOrDefault<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result m) => m.LanguageID == currLangId));
			if (apispSelectLanguages_Result != null)
			{
				text2 = apispSelectLanguages_Result.LanguageCollation;
			}
			if (!VersionBuyer.MoneyBag)
			{
				return new ServiceResult<int?>
				{
					Message = string.Format(Messages.ResourceManager.GetString("ErrorMsgBuyModule", new CultureInfo(currLangId)), Labels.ResourceManager.GetString("lblMoneyBag", new CultureInfo(currLangId))),
					Data = data,
					Status = status
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
				return new ServiceResult<int?>
				{
					Message = resourceManager.Get("ErrorUsernamePasswordIncorrect", text2, resourceManager.TypeMsg) + "\r\n" + resourceManager.Get("ErrorTryAgain", text2, resourceManager.TypeMsg),
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			_ = model.Date;
			string cmpMnBgExpireDatePersian = null;
			try
			{
				if (model.ApiCmpMnBgExpireDate.HasValue)
				{
					cmpMnBgExpireDatePersian = (model.ApiCmpMnBgExpireDate ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
				}
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
				return new ServiceResult<int?>
				{
					Message = string.Format(Messages.ResourceManager.GetString("ErrorItemIsNotEntered", new CultureInfo(text2)), Labels.ResourceManager.GetString("ExpireDate\r\n", new CultureInfo(text2))),
					Data = data,
					Status = status
				};
			}
			if (base.ModelState.IsValid)
			{
				List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(model.Desc_Lang))
				{
					list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.Desc_Lang);
				}
				list2.Add(new CommonMultiLanguageViewModel
				{
					Value = model.Desc,
					LanguageId = currLangId
				});
				string cmpMnBgDesc = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangId)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangId)).Value : null);
				string cmpMnBgDesc_Lang = "";
				if (list2 != null && Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2))
				{
					cmpMnBgDesc_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel m) => m.LanguageId != defLangId))));
				}
				ObjectParameter objectParameter = new ObjectParameter("insertedCompanyMoneyBagId", 0);
				int? num2 = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.ApispInsertCompanyMoneyBag(model.CompanyId, null, null, model.Date, model.Date.ToString("yyyyMMdd", new CultureInfo("fa-IR")), model.Amount, cmpMnBgDesc, cmpMnBgDesc_Lang, model.BankTransactionCode, model.UserId, 0, value2, value, registerDatePersian, appType, defLangId, objectParameter, model.CenterId, model.CenterCode, model.ApiCmpMnBgLinkAccMoneyBagIdStr, model.ApiCmpMnBgLinkAccMoneyBagType, model.ApiCmpMnBgLinkAccFirstTransferDate, model.ApiCmpMnBgLinkAccLastTransferDate, model.ApiCmpMnBgLinkAccData, model.ApiCmpMnBgExpireDate, cmpMnBgExpireDatePersian));
				int result2 = 0;
				if (objectParameter.Value != null)
				{
					int.TryParse(objectParameter.Value.ToString(), out result2);
				}
				if (result2 > 0)
				{
					data = result2;
					status = ServiceResultStatus.Success;
					text = resourceManager.Get("frmFormBaseInsertSuccessFulMessage", text2, resourceManager.TypeMsg);
				}
				else
				{
					text = resourceManager.Get("msgErrorRunFunction", text2, resourceManager.TypeMsg);
				}
			}
			else
			{
				text = string.Join("<br/> ", Enumerable.Select<ModelError, string>(Enumerable.SelectMany<ModelState, ModelError>((IEnumerable<ModelState>)base.ModelState.Values, (Func<ModelState, IEnumerable<ModelError>>)((ModelState x) => x.Errors)), (Func<ModelError, string>)((ModelError x) => x.ErrorMessage)));
			}
		}
		catch (DbEntityValidationException e2)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e2);
			text = resourceManager.Get("msgErrorRunFunction", "en-US", resourceManager.TypeMsg);
		}
		catch (Exception e3)
		{
			ErrorSignal.FromCurrentContext().Raise(e3);
			text = resourceManager.Get("msgErrorRunFunction", "en-US", resourceManager.TypeMsg);
		}
		return new ServiceResult<int?>
		{
			Message = text,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<bool?> DeleteCompanyMoneyBag(DeleteCompanyMoneyBagViewModel model)
	{
		CRMEntities cRMEntities = null;
		ResourceManager resourceManager = new ResourceManager();
		bool? data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			DateTime now = DateTime.Now;
			DateTime dateTime = now;
			string text = now.ToString("yyyyMMdd", new PersianCulture());
			short num = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = CRMIdealApi.Classes.Configuration.AppType;
			if (!VersionBuyer.CRMApi)
			{
				return new ServiceResult<bool?>
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
				return new ServiceResult<bool?>
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
			string rsCollation = "fa-IR";
			ApispSelectLanguages_Result apispSelectLanguages_Result = Enumerable.FirstOrDefault<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result m) => m.LanguageID == currLangId));
			if (apispSelectLanguages_Result != null)
			{
				rsCollation = apispSelectLanguages_Result.LanguageCollation;
			}
			if (!string.IsNullOrEmpty(model.Password))
			{
				model.Password = CodeDecode.DeCodding(model.Password);
			}
			if (!string.IsNullOrEmpty(model.UserName))
			{
				model.UserName = CodeDecode.DeCodding(model.UserName);
			}
			int? num2 = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.ApispCheckUserAllowed(model.UserName, model.Password));
			int result2 = 0;
			int.TryParse(num2.ToString(), out result2);
			if (result2 == 0)
			{
				return new ServiceResult<bool?>
				{
					Message = resourceManager.Get("ErrorUsernamePasswordIncorrect", rsCollation, resourceManager.TypeMsg) + "\r\n" + resourceManager.Get("ErrorTryAgain", rsCollation, resourceManager.TypeMsg),
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			if (!CRMIdealApi.Classes.Helper.User.IsUserAccess("frmCompanyMoneyBag", "actDelete", model.UserId))
			{
				return new ServiceResult<bool?>
				{
					Message = resourceManager.Get("ErrorNotAccess", rsCollation, resourceManager.TypeMsg),
					Data = null,
					Status = ServiceResultStatus.Fail
				};
			}
			if (model.MoneyBagId > 0)
			{
				try
				{
					mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)cRMEntities.ApispDeleteCompanyMoneyBag(model.MoneyBagId));
					if (mct_Result != null && mct_Result.Result > 0)
					{
						message = "";
						data = true;
						status = ServiceResultStatus.Success;
					}
					else if (mct_Result != null && mct_Result.Result == 0)
					{
						message = resourceManager.Get("RedundancyMessage", rsCollation, resourceManager.TypeMsg);
					}
				}
				catch (DbEntityValidationException e)
				{
					ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
					message = resourceManager.Get("RedundancyMessage", rsCollation, resourceManager.TypeMsg);
				}
				catch (Exception ex)
				{
					ErrorSignal.FromCurrentContext().Raise(ex);
					message = resourceManager.Get("msgErrorCommunicateWithServer", rsCollation, resourceManager.TypeMsg) + "<br><p style=text-align:left;>" + ex.Message + "</p>";
				}
			}
			else
			{
				message = resourceManager.Get("ErrorNotFound", rsCollation, resourceManager.TypeMsg);
			}
		}
		catch (Exception ex2)
		{
			string text2 = ((!string.IsNullOrEmpty(ex2.Message)) ? ex2.Message : "");
			if (ex2.InnerException != null && !string.IsNullOrEmpty(ex2.InnerException.Message))
			{
				text2 = text2 + " - " + ex2.InnerException.Message;
			}
			message = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text2)) ? (" (" + text2 + ")") : "");
			data = false;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(ex2);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<bool?>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<int> UpdateCompanyMoneyBag(UpdateCompanyMoneyBagViewModel model)
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
			string cmpMnBgDatePersian = null;
			string cmpMnBgExpireDatePersian = "";
			if (!string.IsNullOrEmpty(model.ApiCmpMnBgDatePersian) && model.ApiCmpMnBgDatePersian.ToLower() == "null")
			{
				cmpMnBgDatePersian = model.ApiCmpMnBgDatePersian;
				model.ApiCmpMnBgDate = null;
			}
			else
			{
				try
				{
					if (model.ApiCmpMnBgDate.HasValue)
					{
						cmpMnBgDatePersian = (model.ApiCmpMnBgDate ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
					}
				}
				catch (Exception e)
				{
					ErrorSignal.FromCurrentContext().Raise(e);
					return new ServiceResult<int>
					{
						Message = string.Format(Messages.ResourceManager.GetString("ErrorEmpty", new CultureInfo("fa-IR")), Labels.ResourceManager.GetString("Date", new CultureInfo("fa-IR"))),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
			}
			if (!string.IsNullOrEmpty(model.ApiCmpMnBgExpireDatePersian) && model.ApiCmpMnBgExpireDatePersian.ToLower() == "null")
			{
				cmpMnBgExpireDatePersian = model.ApiCmpMnBgExpireDatePersian;
				model.ApiCmpMnBgExpireDate = null;
			}
			else
			{
				try
				{
					if (model.ApiCmpMnBgExpireDate.HasValue)
					{
						cmpMnBgExpireDatePersian = (model.ApiCmpMnBgExpireDate ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
					}
				}
				catch (Exception e2)
				{
					ErrorSignal.FromCurrentContext().Raise(e2);
					return new ServiceResult<int>
					{
						Message = string.Format(Messages.ResourceManager.GetString("ErrorEmpty", new CultureInfo("fa-IR")), Labels.ResourceManager.GetString("ExpireDate", new CultureInfo("fa-IR"))),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
			}
			if (!string.IsNullOrEmpty(model.ApiCmpMnBgLinkAccFirstTransferDatePersian) && model.ApiCmpMnBgLinkAccFirstTransferDatePersian.ToLower() == "null")
			{
				model.ApiCmpMnBgLinkAccFirstTransferDate = null;
			}
			if (!string.IsNullOrEmpty(model.ApiCmpMnBgLinkAccLastTransferDatePersian) && model.ApiCmpMnBgLinkAccLastTransferDatePersian.ToLower() == "null")
			{
				model.ApiCmpMnBgLinkAccLastTransferDate = null;
			}
			if (model.ApiCompanyMoneyBagId <= 0)
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
			string text = commonClass.ConvertNameToDayNum(now.DayOfWeek.ToString());
			string text2 = now.ToString("HH:mm:ss");
			short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = CRMIdealApi.Classes.Configuration.AppType;
			string resourceString = MyResource.GetResourceString("DefualtPrjTitle", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
			ObjectParameter objectParameter = new ObjectParameter("ErrorMessage", "");
			int num2 = cRMEntities.ApispUpdateCompanyMoneyBag(model.ApiCompanyMoneyBagId, model.ApiCmpMnBgCompanyId, model.ApiCmpMnBgSystemPartId, model.ApiCmpMnBgSystemPartObjectId, model.ApiCmpMnBgDate, cmpMnBgDatePersian, model.ApiCmpMnBgAmount, model.ApiCmpMnBgDesc, model.ApiCmpMnBgBankTransactionCode, model.ApiCmpMnBgLinkAccMoneyBagIdStr, model.ApiCmpMnBgLinkAccMoneyBagType, model.ApiCmpMnBgLinkAccFirstTransferDate, model.ApiCmpMnBgLinkAccFirstTransferDatePersian, model.ApiCmpMnBgLinkAccLastTransferDate, model.ApiCmpMnBgLinkAccLastTransferDatePersian, model.ApiCmpMnBgLinkAccData, model.ApiCmpMnBgExpireDate, cmpMnBgExpireDatePersian, userId, 0, value2, value, registerDatePersian, appType, currLangId, result, objectParameter);
			string resourceString2 = MyResource.GetResourceString("ErrorDoneOperationTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
			string resourceString3 = MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
			int result3 = 0;
			int.TryParse(num2.ToString(), out result3);
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
				string text3 = "";
				string text4 = objectParameter.Value.ToString();
				if (text4.IndexOf("No CmpId|", StringComparison.Ordinal) >= 0)
				{
					text3 = text3 + string.Format(MyResource.GetResourceString("ErrorItemIsWrong", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("Company", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower()) + " " + resourceString3;
					return new ServiceResult<int>
					{
						Message = text3.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
				if (text4.IndexOf("Error", StringComparison.Ordinal) >= 0)
				{
					text3 += resourceString3;
					ErrorSignal.FromCurrentContext().Raise(new Exception(text4));
					return new ServiceResult<int>
					{
						Message = resourceString3.Replace("<br>", "\r\n"),
						Data = 0,
						Status = ServiceResultStatus.Error
					};
				}
			}
			else
			{
				data = 1;
				message = MyResource.GetResourceString("SuccessDoneRegister", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				status = ServiceResultStatus.Success;
			}
		}
		catch (Exception ex)
		{
			string text5 = ((!string.IsNullOrEmpty(ex.Message)) ? ex.Message : "");
			if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
			{
				text5 = text5 + " - " + ex.InnerException.Message;
			}
			message = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text5)) ? (" (" + text5 + ")") : "");
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
	public ServiceResult<string> DecryptCompanyPassword(DecryptCompanyPasswordViewModel model)
	{
		CRMEntities cRMEntities = null;
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
			cRMEntities = new CRMEntities();
			CommonClass commonClass = new CommonClass();
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
			ServiceResult<string> serviceResult;
			if (result2 == 0)
			{
				serviceResult = new ServiceResult<string>();
				serviceResult.Message = MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			cRMEntities = new CRMEntities();
			ApispSelectCompany_Result apispSelectCompany_Result = Enumerable.FirstOrDefault<ApispSelectCompany_Result>((IEnumerable<ApispSelectCompany_Result>)cRMEntities.ApispSelectCompany(model.CompanyId, null, null, null, null, null, null, currLangId, result, null, null, 0, 0));
			if (apispSelectCompany_Result == null)
			{
				serviceResult = new ServiceResult<string>();
				serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorRecordNotFound", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("Company", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			string apiCmpPassword = apispSelectCompany_Result.ApiCmpPassword;
			string data = ((!string.IsNullOrEmpty(apiCmpPassword)) ? XorCipher.DecryptByPublicKey(apiCmpPassword) : null);
			serviceResult = new ServiceResult<string>();
			serviceResult.Message = MyResource.GetResourceString("SuccessDoneRegister", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
			serviceResult.Data = data;
			serviceResult.Status = ServiceResultStatus.Error;
			return serviceResult;
		}
		catch (Exception)
		{
			return new ServiceResult<string>
			{
				Message = Messages.ErrorInReadingSysSetting,
				Data = null,
				Status = ServiceResultStatus.Error
			};
		}
	}

	public ServiceResult<string> DecryptCompanyPersonPassword(DecryptCompanyPersonPasswordViewModel model)
	{
		CRMEntities cRMEntities = null;
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
			cRMEntities = new CRMEntities();
			CommonClass commonClass = new CommonClass();
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
			ServiceResult<string> serviceResult;
			if (result2 == 0)
			{
				serviceResult = new ServiceResult<string>();
				serviceResult.Message = MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			cRMEntities = new CRMEntities();
			ApispSelectCompanyPersonsByID_Result apispSelectCompanyPersonsByID_Result = Enumerable.FirstOrDefault<ApispSelectCompanyPersonsByID_Result>((IEnumerable<ApispSelectCompanyPersonsByID_Result>)cRMEntities.ApispSelectCompanyPersonsByID(model.CompanyPersonId, currLangId, result));
			if (apispSelectCompanyPersonsByID_Result == null)
			{
				serviceResult = new ServiceResult<string>();
				serviceResult.Message = string.Format(MyResource.GetResourceString("ErrorRecordNotFound", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("CompanyPerson", culture, "CRMIdealApi.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly).ToLower());
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			string prsPassword = apispSelectCompanyPersonsByID_Result.prsPassword;
			string data = ((!string.IsNullOrEmpty(prsPassword)) ? XorCipher.DecryptByPublicKey(prsPassword) : null);
			serviceResult = new ServiceResult<string>();
			serviceResult.Message = MyResource.GetResourceString("SuccessDoneRegister", culture, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
			serviceResult.Data = data;
			serviceResult.Status = ServiceResultStatus.Error;
			return serviceResult;
		}
		catch (Exception)
		{
			return new ServiceResult<string>
			{
				Message = Messages.ErrorInReadingSysSetting,
				Data = null,
				Status = ServiceResultStatus.Error
			};
		}
	}

	public ServiceResult<ApispAddCompanyToCenter_Result> AddToCenter(AddCompanyToCenterViewModel model)
	{
		CRMEntities cRMEntities = null;
		ApispAddCompanyToCenter_Result data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (!VersionBuyer.CRMApi)
			{
				return new ServiceResult<ApispAddCompanyToCenter_Result>
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
				return new ServiceResult<ApispAddCompanyToCenter_Result>
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
			string text = "fa-IR";
			ApispSelectLanguages_Result apispSelectLanguages_Result = Enumerable.FirstOrDefault<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result m) => m.LanguageID == currLangId));
			if (apispSelectLanguages_Result != null)
			{
				text = apispSelectLanguages_Result.LanguageCollation;
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
				ServiceResult<ApispAddCompanyToCenter_Result> serviceResult = new ServiceResult<ApispAddCompanyToCenter_Result>();
				serviceResult.Message = MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + MyResource.GetResourceString("ErrorTryAgain", text, "CRMIdealApi.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				serviceResult.Data = null;
				serviceResult.Status = ServiceResultStatus.Error;
				return serviceResult;
			}
			ObjectParameter objectParameter = new ObjectParameter("errorMessage", "");
			ApispAddCompanyToCenter_Result apispAddCompanyToCenter_Result = Enumerable.FirstOrDefault<ApispAddCompanyToCenter_Result>((IEnumerable<ApispAddCompanyToCenter_Result>)cRMEntities.ApispAddCompanyToCenter(model.CenterId, model.CenterCode, model.ApiCmpNationalCode, model.ApiPrsNationalCode, currLangId, result, objectParameter));
			string @string = Messages.ResourceManager.GetString("ErrorDoneOperationTryAgain", new CultureInfo(text));
			string string2 = Messages.ResourceManager.GetString("ErrorTryAgain", new CultureInfo(text));
			if (objectParameter.Value != null && objectParameter.Value.ToString() != "")
			{
				string text2 = "";
				string text3 = objectParameter.Value.ToString();
				if (text3.IndexOf("No Center|", StringComparison.Ordinal) >= 0)
				{
					return new ServiceResult<ApispAddCompanyToCenter_Result>
					{
						Message = Messages.ResourceManager.GetString("msgErrorCenterNotFound", new CultureInfo(text)),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text3.IndexOf("No Cmp|", StringComparison.Ordinal) >= 0)
				{
					return new ServiceResult<ApispAddCompanyToCenter_Result>
					{
						Message = Messages.ResourceManager.GetString("CompanyNotFound", new CultureInfo(text)),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
			}
			else
			{
				status = ServiceResultStatus.Success;
				data = apispAddCompanyToCenter_Result;
			}
		}
		catch (Exception ex)
		{
			string text4 = ((!string.IsNullOrEmpty(ex.Message)) ? ex.Message : "");
			if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
			{
				text4 = text4 + " - " + ex.InnerException.Message;
			}
			message = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text4)) ? (" (" + text4 + ")") : "");
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(ex);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<ApispAddCompanyToCenter_Result>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}
}
