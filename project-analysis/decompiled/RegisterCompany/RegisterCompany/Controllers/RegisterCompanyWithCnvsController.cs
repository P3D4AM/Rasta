using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web.Http;
using CRM.General.Security;
using CRM.General.Utilities;
using GSD.Globalization;
using RegisterCompany.Classes;
using RegisterCompany.Classes.Helper;
using RegisterCompany.DataType;
using RegisterCompany.Models;
using RegisterCompany.Resources;

namespace RegisterCompany.Controllers;

public class RegisterCompanyWithCnvsController : ApiController
{
	[HttpPost]
	public ServiceResult<RegisterCompanyWithCnvsResultViewModel> Send(RegisterCompanyWithCnvsViewModel model)
	{
		CRMEntities cRMEntities = null;
		RegisterCompanyWithCnvsResultViewModel data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			cRMEntities = new CRMEntities();
			string cmpEffectiveDatePersian = null;
			string cmpCoordinateLastDatePersian = null;
			string prsBirthDate = null;
			string prsMarriageDate = null;
			string prjRemindDate = null;
			string cnvsRemindDate = null;
			if (model.ApiCustomerEffectiveDateTime.HasValue)
			{
				cmpEffectiveDatePersian = (model.ApiCustomerEffectiveDateTime ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
			}
			if (model.ApiCustomerCoordinateLastDate.HasValue)
			{
				cmpCoordinateLastDatePersian = (model.ApiCustomerCoordinateLastDate ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
			}
			if (model.ApiPersonBirthDateTime.HasValue)
			{
				prsBirthDate = (model.ApiPersonBirthDateTime ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
			}
			if (model.ApiPersonMarriageDateTime.HasValue)
			{
				prsMarriageDate = (model.ApiPersonMarriageDateTime ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
			}
			if (model.ApiProjectRemindDateTime.HasValue)
			{
				prjRemindDate = (model.ApiProjectRemindDateTime ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
			}
			if (model.ApiConversationRemindDateTime.HasValue)
			{
				cnvsRemindDate = (model.ApiConversationRemindDateTime ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture());
			}
			ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
			if (apispSelectCrmsysSetting_Result == null)
			{
				return new ServiceResult<RegisterCompanyWithCnvsResultViewModel>
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
			if (!string.IsNullOrEmpty(model.Password))
			{
				model.Password = CodeDecode.DeCodding(model.Password);
			}
			if (!string.IsNullOrEmpty(model.UserName))
			{
				model.UserName = CodeDecode.DeCodding(model.UserName);
			}
			List<ApispSelectLanguages_Result> list = Enumerable.ToList<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)cRMEntities.ApispSelectLanguages());
			string culture = "fa-IR";
			ApispSelectLanguages_Result apispSelectLanguages_Result = Enumerable.FirstOrDefault<ApispSelectLanguages_Result>((IEnumerable<ApispSelectLanguages_Result>)list, (Func<ApispSelectLanguages_Result, bool>)((ApispSelectLanguages_Result m) => m.LanguageID == defLangId));
			if (apispSelectLanguages_Result != null)
			{
				culture = apispSelectLanguages_Result.LanguageCollation;
			}
			List<ApispSelectCrmFoSetting_Result> list2 = Enumerable.ToList<ApispSelectCrmFoSetting_Result>((IEnumerable<ApispSelectCrmFoSetting_Result>)cRMEntities.ApispSelectCrmFoSetting());
			if (!Enumerable.Any<ApispSelectCrmFoSetting_Result>((IEnumerable<ApispSelectCrmFoSetting_Result>)list2))
			{
				return new ServiceResult<RegisterCompanyWithCnvsResultViewModel>
				{
					Message = MyResource.GetResourceString("ErrorInReadingFoSetting", culture, "RegisterCompany.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly),
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			if (Enumerable.FirstOrDefault<ApispSelectCrmFoSetting_Result>((IEnumerable<ApispSelectCrmFoSetting_Result>)list2, (Func<ApispSelectCrmFoSetting_Result, bool>)((ApispSelectCrmFoSetting_Result m) => m.LanguageID == defLangId)) == null)
			{
				return new ServiceResult<RegisterCompanyWithCnvsResultViewModel>
				{
					Message = MyResource.GetResourceString("ErrorInReadingFoSetting", culture, "RegisterCompany.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly),
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			if (string.IsNullOrEmpty(model.ApiPersonLName))
			{
				return new ServiceResult<RegisterCompanyWithCnvsResultViewModel>
				{
					Message = MyResource.GetResourceString("ErrorPrsLNameNotEntered", culture, "RegisterCompany.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly),
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			if (string.IsNullOrEmpty(model.ApiPersonMobile) && string.IsNullOrEmpty(model.ApiPersonEmail) && string.IsNullOrEmpty(model.ApiPersonEmailII))
			{
				return new ServiceResult<RegisterCompanyWithCnvsResultViewModel>
				{
					Message = MyResource.GetResourceString("ErrorPrsMobEmailNotEntered", culture, "RegisterCompany.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly),
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			if (Thread.CurrentThread.CurrentCulture.LCID == defLangId && model.ApiPersonMobile != null)
			{
				if (model.ApiPersonMobile.Length < 11)
				{
					return new ServiceResult<RegisterCompanyWithCnvsResultViewModel>
					{
						Message = MyResource.GetResourceString("CheckLenMob", culture, "RegisterCompany.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (!Regex.IsMatch(model.ApiPersonMobile, "09([0-9])\\d{8}"))
				{
					return new ServiceResult<RegisterCompanyWithCnvsResultViewModel>
					{
						Message = MyResource.GetResourceString("CheckMobileFormat", culture, "RegisterCompany.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
			}
			if (!string.IsNullOrEmpty(model.ApiPersonMobile))
			{
				try
				{
					long.Parse(model.ApiPersonMobile);
				}
				catch
				{
					return new ServiceResult<RegisterCompanyWithCnvsResultViewModel>
					{
						Message = string.Format(MyResource.GetResourceString("CheckDigit", culture, "RegisterCompany.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), MyResource.GetResourceString("PrsMobile", culture, "RegisterCompany.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly)),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
			}
			if (model.ApiCustomerPreTel != null && model.ApiCustomerPreTel.Length > 1 && model.ApiCustomerPreTel.Substring(0, 2) == "09")
			{
				return new ServiceResult<RegisterCompanyWithCnvsResultViewModel>
				{
					Message = MyResource.GetResourceString("CheckPreTelForNotMobile", culture, "RegisterCompany.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly),
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			if (model.ApiCustomerPreTelII != null && model.ApiCustomerPreTelII.Length > 1 && model.ApiCustomerPreTelII.Substring(0, 2) == "09")
			{
				return new ServiceResult<RegisterCompanyWithCnvsResultViewModel>
				{
					Message = MyResource.GetResourceString("CheckPreTelForNotMobile", culture, "RegisterCompany.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly),
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			if (model.ApiCustomerTel != null && model.ApiCustomerTel.Length > 1 && model.ApiCustomerTel.Substring(0, 2) == "09")
			{
				return new ServiceResult<RegisterCompanyWithCnvsResultViewModel>
				{
					Message = MyResource.GetResourceString("CheckPreTelForNotMobile", culture, "RegisterCompany.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly),
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			if (model.ApiCustomerTelII != null && model.ApiCustomerTelII.Length > 1 && model.ApiCustomerTelII.Substring(0, 2) == "09")
			{
				return new ServiceResult<RegisterCompanyWithCnvsResultViewModel>
				{
					Message = MyResource.GetResourceString("CheckPreTelForNotMobile", culture, "RegisterCompany.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly),
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			if (model.ApiPersonPreTel != null && model.ApiPersonPreTel.Length > 1 && model.ApiPersonPreTel.Substring(0, 2) == "09")
			{
				return new ServiceResult<RegisterCompanyWithCnvsResultViewModel>
				{
					Message = MyResource.GetResourceString("CheckPreTelForNotMobile", culture, "RegisterCompany.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly),
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			if (model.ApiPersonTel != null && model.ApiPersonTel.Length > 1 && model.ApiPersonTel.Substring(0, 2) == "09")
			{
				return new ServiceResult<RegisterCompanyWithCnvsResultViewModel>
				{
					Message = MyResource.GetResourceString("CheckPreTelForNotMobile", culture, "RegisterCompany.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly),
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			if (model.ApiPersonTelII != null && model.ApiPersonTelII.Length > 1 && model.ApiPersonTelII.Substring(0, 2) == "09")
			{
				return new ServiceResult<RegisterCompanyWithCnvsResultViewModel>
				{
					Message = MyResource.GetResourceString("CheckPreTelForNotMobile", culture, "RegisterCompany.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly),
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			if (string.IsNullOrEmpty(model.ApiCustomerName))
			{
				model.ApiCustomerName = MyResource.GetResourceString("Person", culture, "RegisterCompany.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
			}
			string text = "";
			string text2 = "";
			string text3 = "";
			string text4 = "";
			ApispSelectCrmFoSetting_Result apispSelectCrmFoSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmFoSetting_Result>((IEnumerable<ApispSelectCrmFoSetting_Result>)list2, (Func<ApispSelectCrmFoSetting_Result, bool>)((ApispSelectCrmFoSetting_Result m) => m.LanguageID == defLangId));
			if (apispSelectCrmFoSetting_Result != null)
			{
				text = ((!string.IsNullOrEmpty(apispSelectCrmFoSetting_Result.PrjDefaultTitle)) ? apispSelectCrmFoSetting_Result.PrjDefaultTitle : "");
				text2 = ((!string.IsNullOrEmpty(apispSelectCrmFoSetting_Result.PrjDefaultPostFix)) ? apispSelectCrmFoSetting_Result.PrjDefaultPostFix : "");
				text3 = ((!string.IsNullOrEmpty(apispSelectCrmFoSetting_Result.CnvsDefaultDesc)) ? apispSelectCrmFoSetting_Result.CnvsDefaultDesc.Replace("\r\n", "<BR>") : "");
				text4 = ((!string.IsNullOrEmpty(apispSelectCrmFoSetting_Result.CnvsDefaultReferDesc)) ? apispSelectCrmFoSetting_Result.CnvsDefaultReferDesc.Replace("\r\n", "<BR>") : null);
			}
			if (!string.IsNullOrEmpty(model.Value))
			{
				model.Value = "<BR>" + model.Value.Replace("\r\n", "<BR>");
			}
			if (!string.IsNullOrEmpty(model.ApiProjectTitle))
			{
				_ = model.ApiProjectTitle + ((!string.IsNullOrEmpty(model.ApiProjectPostFix)) ? (" " + model.ApiProjectPostFix) : "");
			}
			else
			{
				_ = text + ((text2 != "") ? (" " + text2) : "");
			}
			List<ApispSelectPersonTitleWithId_Result> list3 = new List<ApispSelectPersonTitleWithId_Result>();
			if (model.ApiPersonTitleId.HasValue)
			{
				list3 = Enumerable.ToList<ApispSelectPersonTitleWithId_Result>((IEnumerable<ApispSelectPersonTitleWithId_Result>)cRMEntities.ApispSelectPersonTitleWithId(model.ApiPersonTitleId));
			}
			string text5 = "";
			if (Enumerable.Any<ApispSelectPersonTitleWithId_Result>((IEnumerable<ApispSelectPersonTitleWithId_Result>)list3))
			{
				ApispSelectPersonTitleWithId_Result apispSelectPersonTitleWithId_Result = Enumerable.FirstOrDefault<ApispSelectPersonTitleWithId_Result>((IEnumerable<ApispSelectPersonTitleWithId_Result>)list3, (Func<ApispSelectPersonTitleWithId_Result, bool>)((ApispSelectPersonTitleWithId_Result m) => m.LanguageID == defLangId));
				text5 = ((apispSelectPersonTitleWithId_Result != null && !string.IsNullOrEmpty(apispSelectPersonTitleWithId_Result.PersonTitle)) ? apispSelectPersonTitleWithId_Result.PersonTitle : "");
			}
			string text6 = text5 + ((!string.IsNullOrEmpty(model.ApiPersonFName)) ? (" " + model.ApiPersonFName) : "") + ((!string.IsNullOrEmpty(model.ApiPersonLName)) ? (" " + model.ApiPersonLName) : "");
			List<ApispSelectCompanyTitleWithId_Result> list4 = new List<ApispSelectCompanyTitleWithId_Result>();
			if (model.ApiCustomerTitleId.HasValue)
			{
				list4 = Enumerable.ToList<ApispSelectCompanyTitleWithId_Result>((IEnumerable<ApispSelectCompanyTitleWithId_Result>)cRMEntities.ApispSelectCompanyTitleWithId(model.ApiCustomerTitleId));
			}
			string text7 = "";
			if (Enumerable.Any<ApispSelectCompanyTitleWithId_Result>((IEnumerable<ApispSelectCompanyTitleWithId_Result>)list4))
			{
				ApispSelectCompanyTitleWithId_Result apispSelectCompanyTitleWithId_Result = Enumerable.FirstOrDefault<ApispSelectCompanyTitleWithId_Result>((IEnumerable<ApispSelectCompanyTitleWithId_Result>)list4, (Func<ApispSelectCompanyTitleWithId_Result, bool>)((ApispSelectCompanyTitleWithId_Result m) => m.LanguageID == defLangId));
				text7 = ((apispSelectCompanyTitleWithId_Result != null && !string.IsNullOrEmpty(apispSelectCompanyTitleWithId_Result.CompanyTitle)) ? apispSelectCompanyTitleWithId_Result.CompanyTitle : "");
			}
			string text8 = text7 + ((!string.IsNullOrEmpty(model.ApiCustomerName)) ? (" " + model.ApiCustomerName) : "");
			string cnvsDesc = ((!string.IsNullOrEmpty(model.ApiConversationDesc)) ? model.ApiConversationDesc.Replace("\r\n", "<BR>") : text3);
			string cnvsReferDesc = ((!string.IsNullOrEmpty(model.ApiConversationReferDesc)) ? model.ApiConversationReferDesc.Replace("\r\n", "<BR>") : text4);
			CommonClass.GetUserName(-10, defLangId, defLangId);
			int value = -10;
			DateTime now = DateTime.Now;
			DateTime value2 = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string dubClickDisplayCmpInfo = Messages.DubClickDisplayCmpInfo;
			string appType = RegisterCompany.Classes.Configuration.AppType;
			short.Parse(now.ToString("yyyy", new PersianCulture()));
			CommonClass commonClass = new CommonClass();
			string registerDay = commonClass.ConvertNameToDayNum(now.DayOfWeek.ToString());
			string registerTime = now.ToString("HH:mm:ss");
			_ = Labels.Person;
			if (!string.IsNullOrEmpty(model.ApiCustomerPassword))
			{
				model.ApiCustomerPassword = commonClass.ConvertMd5(model.ApiCustomerPassword).ToLower();
			}
			string text9 = "";
			string text10 = "";
			string text11 = "";
			foreach (ApispSelectLanguages_Result lang2 in list)
			{
				string text12 = "";
				string text13 = "";
				string text14 = "";
				string text15 = "";
				ApispSelectCrmFoSetting_Result apispSelectCrmFoSetting_Result2 = Enumerable.FirstOrDefault<ApispSelectCrmFoSetting_Result>((IEnumerable<ApispSelectCrmFoSetting_Result>)list2, (Func<ApispSelectCrmFoSetting_Result, bool>)((ApispSelectCrmFoSetting_Result m) => m.LanguageID == lang2.LanguageID));
				if (apispSelectCrmFoSetting_Result2 != null)
				{
					text12 = ((!string.IsNullOrEmpty(apispSelectCrmFoSetting_Result2.PrjDefaultTitle)) ? apispSelectCrmFoSetting_Result2.PrjDefaultTitle : "");
					text13 = ((!string.IsNullOrEmpty(apispSelectCrmFoSetting_Result2.PrjDefaultPostFix)) ? apispSelectCrmFoSetting_Result2.PrjDefaultPostFix : "");
					text14 = ((!string.IsNullOrEmpty(apispSelectCrmFoSetting_Result2.CnvsDefaultDesc)) ? apispSelectCrmFoSetting_Result2.CnvsDefaultDesc.Replace("\r\n", "<BR>") : "");
					text15 = ((!string.IsNullOrEmpty(apispSelectCrmFoSetting_Result2.CnvsDefaultReferDesc)) ? apispSelectCrmFoSetting_Result2.CnvsDefaultReferDesc.Replace("\r\n", "<BR>") : null);
				}
				text12 = ((!string.IsNullOrEmpty(model.ApiProjectTitle)) ? model.ApiProjectTitle : text12);
				text13 = ((!string.IsNullOrEmpty(model.ApiProjectPostFix)) ? model.ApiProjectPostFix : text13);
				text14 = ((!string.IsNullOrEmpty(model.ApiConversationDesc)) ? model.ApiConversationDesc.Replace("\r\n", "<BR>") : text14);
				text15 = ((!string.IsNullOrEmpty(model.ApiConversationReferDesc)) ? model.ApiConversationReferDesc.Replace("\r\n", "<BR>") : text15);
				text9 = "";
				text10 = "";
				text9 = MyResource.GetResourceString("ErjaFrom", lang2.LanguageCollation, "RegisterCompany.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + " " + CommonClass.GetUserName(-10, defLangId, lang2.LanguageID);
				text10 = MyResource.GetResourceString("ErjaInConnection", lang2.LanguageCollation, "RegisterCompany.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": " + text8 + "<BR>" + MyResource.GetResourceString("ErjaPerson", lang2.LanguageCollation, "RegisterCompany.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": " + text6 + "<BR>" + MyResource.GetResourceString("ErjaProject", lang2.LanguageCollation, "RegisterCompany.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": " + ((!string.IsNullOrEmpty(text12)) ? text12 : "") + ((!string.IsNullOrEmpty(text13)) ? (" " + text13) : "");
				if (!string.IsNullOrEmpty(model.ApiConversationReferToMultilUser))
				{
					string[] array = model.ApiConversationReferToMultilUser.Split(new char[1] { ',' });
					if (Enumerable.Any<string>((IEnumerable<string>)array))
					{
						string text16 = "";
						string[] array2 = array;
						foreach (string text17 in array2)
						{
							int num = ((!string.IsNullOrEmpty(text17)) ? int.Parse(text17) : 0);
							if (num > 0)
							{
								string text18 = ((num > 0) ? CommonClass.GetUserName(num, defLangId, lang2.LanguageID) : "");
								text16 = text16 + text18 + ",";
							}
						}
						text16 = ((!string.IsNullOrEmpty(text16)) ? text16.TrimEnd(new char[1] { ',' }) : "");
						if (text16 != "")
						{
							text10 = text10 + "<BR>" + MyResource.GetResourceString("ErjaMultiUser", lang2.LanguageCollation, "RegisterCompany.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": " + text16;
						}
					}
				}
				text10 = text10 + "<BR><BR>" + MyResource.GetResourceString("ErjaConversationDescription", lang2.LanguageCollation, "RegisterCompany.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ":<BR>" + text14.Replace("\r\n", "<BR>") + ((!string.IsNullOrEmpty(model.Value)) ? model.Value : "");
				string text19 = text15;
				if (!string.IsNullOrEmpty(text19))
				{
					text10 = text10 + "<BR>" + MyResource.GetResourceString("ErjaReferDescription", lang2.LanguageCollation, "RegisterCompany.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ":<BR>" + text19.Replace("\r\n", "<BR>");
				}
				text10 = text10 + "<BR><BR>" + MyResource.GetResourceString("ErjaDetails", lang2.LanguageCollation, "RegisterCompany.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				text11 = text11 + "MsgSubj=" + text9 + "|@#@|MsgBody=" + text10 + "|@#@|LangId=" + lang2.LanguageID + "|@#@||^#^|";
			}
			string text20 = "";
			string text21 = "";
			string text22 = "";
			if (!string.IsNullOrEmpty(model.ApiConversationReferToMultilUser))
			{
				string[] array3 = model.ApiConversationReferToMultilUser.Split(new char[1] { ',' });
				if (Enumerable.Any<string>((IEnumerable<string>)array3))
				{
					foreach (ApispSelectLanguages_Result lang in list)
					{
						string text23 = "";
						string[] array2 = array3;
						foreach (string text24 in array2)
						{
							int num2 = ((!string.IsNullOrEmpty(text24)) ? int.Parse(text24) : 0);
							if (num2 > 0)
							{
								string text25 = ((num2 > 0) ? CommonClass.GetUserName(num2, defLangId, lang.LanguageID) : "");
								text23 = text23 + text25 + ",";
							}
						}
						text23 = ((!string.IsNullOrEmpty(text23)) ? text23.TrimEnd(new char[1] { ',' }) : "");
						string text26 = "";
						string text27 = "";
						string text28 = "";
						string text29 = "";
						ApispSelectCrmFoSetting_Result apispSelectCrmFoSetting_Result3 = Enumerable.FirstOrDefault<ApispSelectCrmFoSetting_Result>((IEnumerable<ApispSelectCrmFoSetting_Result>)list2, (Func<ApispSelectCrmFoSetting_Result, bool>)((ApispSelectCrmFoSetting_Result m) => m.LanguageID == lang.LanguageID));
						if (apispSelectCrmFoSetting_Result3 != null)
						{
							text26 = ((!string.IsNullOrEmpty(apispSelectCrmFoSetting_Result3.PrjDefaultTitle)) ? apispSelectCrmFoSetting_Result3.PrjDefaultTitle : "");
							text27 = ((!string.IsNullOrEmpty(apispSelectCrmFoSetting_Result3.PrjDefaultPostFix)) ? apispSelectCrmFoSetting_Result3.PrjDefaultPostFix : "");
							text28 = ((!string.IsNullOrEmpty(apispSelectCrmFoSetting_Result3.CnvsDefaultDesc)) ? apispSelectCrmFoSetting_Result3.CnvsDefaultDesc.Replace("\r\n", "<BR>") : "");
							text29 = ((!string.IsNullOrEmpty(apispSelectCrmFoSetting_Result3.CnvsDefaultReferDesc)) ? apispSelectCrmFoSetting_Result3.CnvsDefaultReferDesc.Replace("\r\n", "<BR>") : null);
						}
						text26 = ((!string.IsNullOrEmpty(model.ApiProjectTitle)) ? model.ApiProjectTitle : text26);
						text27 = ((!string.IsNullOrEmpty(model.ApiProjectPostFix)) ? model.ApiProjectPostFix : text27);
						text28 = ((!string.IsNullOrEmpty(model.ApiConversationDesc)) ? model.ApiConversationDesc.Replace("\r\n", "<BR>") : text28);
						text29 = ((!string.IsNullOrEmpty(model.ApiConversationReferDesc)) ? model.ApiConversationReferDesc.Replace("\r\n", "<BR>") : text29);
						text20 = "";
						text21 = "";
						text20 = MyResource.GetResourceString("ErjaRonevesht", lang.LanguageCollation, "RegisterCompany.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + " " + CommonClass.GetUserName(-10, defLangId, lang.LanguageID);
						text21 = MyResource.GetResourceString("ErjaInConnection", lang.LanguageCollation, "RegisterCompany.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": " + text8 + "<BR>" + MyResource.GetResourceString("ErjaPerson", lang.LanguageCollation, "RegisterCompany.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": " + text6 + "<BR>" + MyResource.GetResourceString("ErjaProject", lang.LanguageCollation, "RegisterCompany.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": " + ((!string.IsNullOrEmpty(text26)) ? text26 : "") + ((!string.IsNullOrEmpty(text27)) ? (" " + text27) : "");
						if (text23 != "")
						{
							text21 = text21 + "<BR>" + MyResource.GetResourceString("ErjaMultiUser", lang.LanguageCollation, "RegisterCompany.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": " + text23;
						}
						text21 = text21 + "<BR><BR>" + MyResource.GetResourceString("ErjaConversationDescription", lang.LanguageCollation, "RegisterCompany.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ":<BR>" + text28.Replace("\r\n", "<BR>") + ((!string.IsNullOrEmpty(model.Value)) ? model.Value : "");
						text21 = text21 + "<BR><BR>" + MyResource.GetResourceString("ErjaDetails", lang.LanguageCollation, "RegisterCompany.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
						text22 = text22 + "MsgSubj=" + text20 + "|@#@|MsgBody=" + text21 + "|@#@|LangId=" + lang.LanguageID + "|@#@||^#^|";
					}
				}
			}
			ObjectParameter objectParameter = new ObjectParameter("InsertedCompanyId", 0);
			ObjectParameter objectParameter2 = new ObjectParameter("InsertedPersonId", 0);
			ObjectParameter objectParameter3 = new ObjectParameter("InsertedProjectId", 0);
			ObjectParameter objectParameter4 = new ObjectParameter("InsertedConversationId", 0);
			ObjectParameter objectParameter5 = new ObjectParameter("ErrorMessage", "");
			int? num3 = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.ApispRegisterCompanyWithCnvs(model.UserName, model.Password, cmpName: model.ApiCustomerName, cmpNumber: model.ApiCustomerNumber, cmpNameEng: model.ApiCustomerNameEng, cmpTitleId: model.ApiCustomerTitleId, cmpFame: model.ApiCustomerFame, cmpActivityType: model.ApiCustomerActivityType, cmpGroupId: model.ApiCustomerGroupId, cmpSubGroupId: model.ApiCustomerSubGroupId, cmpGroupIdII: model.ApiCustomerGroupIdII, cmpGroupIdIII: model.ApiCustomerGroupIdIII, cmpGroupIdIV: model.ApiCustomerGroupIdIV, cmpTypeId: model.ApiCustomerTypeId, cmpPresentationId: model.ApiCustomerPresentationId, cmpPreTel: model.ApiCustomerPreTel, cmpTel: model.ApiCustomerTel, cmpTelUpTo: model.ApiCustomerTelUpTo, cmpTelDesc: model.ApiCustomerTelDesc, cmpPreTelII: model.ApiCustomerPreTelII, cmpTelII: model.ApiCustomerTelII, cmpTelUpToII: model.ApiCustomerTelUpToII, cmpTelIIDesc: model.ApiCustomerTelIIDesc, cmpMobile: null, cmpFax: model.ApiCustomerFax, cmpFaxDesc: model.ApiCustomerFaxDesc, cmpCountryId: model.ApiCustomerCountryId, cmpProvinceId: model.ApiCustomerProvinceId, cmpCityId: model.ApiCustomerCityId, cmpAddress: model.ApiCustomerAddress, cmpAddressDesc: model.ApiCustomerAddressDesc, cmpZipCode: model.ApiCustomerZipCode, cmpPostBox: model.ApiCustomerPostBox, cmpWebSite: model.ApiCustomerWebSite, cmpEmail: model.ApiCustomerEmail, cmpInteresting: model.ApiCustomerInteresting, cmpSpecialPoint: model.ApiCustomerSpecialPoint, cmpDescription: model.ApiCustomerDescription, cmpUserName: model.ApiCustomerUserName, cmpPassword: model.ApiCustomerPassword, cmpRegistrationNumber: model.ApiCustomerRegistrationNumber, cmpEconomicCode: model.ApiCustomerEconomicCode, cmpNationalCode: model.ApiCustomerNationalCode, cmpBuyLimit: model.ApiCustomerBuyLimit, cmpAccountNumber: model.ApiCustomerAccountNumber, cmpAccInquiry: model.ApiCustomerAccInquiry, cmpFreight: model.ApiCustomerFreight, cmpInquiry: model.ApiCustomerInquiry, cmpReferUserId: model.ApiCustomerReferUserId, cmpSpecialWordForCI: model.ApiCustomerSpecialWordForCI, cmpCode: model.ApiCustomerCode, cmpEffectiveDatePersian: cmpEffectiveDatePersian, cmpEffectiveDateTime: model.ApiCustomerEffectiveDateTime, cmpCoordinateLatitude: model.ApiCustomerCoordinateLatitude, cmpCoordinateLongitude: model.ApiCustomerCoordinateLongitude, cmpCoordinateLastDate: model.ApiCustomerCoordinateLastDate, cmpCoordinateLastDatePersian: cmpCoordinateLastDatePersian, cmpCoordinateZoomLevel: model.ApiCustomerCoordinateZoomLevel, cmpCoordinateLastUserId: model.ApiCustomerCoordinateLastUserId, prsLName: model.ApiPersonLName, prsFName: model.ApiPersonFName, prsTitleId: model.ApiPersonTitleId, prsJobId: model.ApiPersonJobId, prsTypeId: model.ApiPersonTypeId, prsGroupId: model.ApiPersonGroupId, prsSexId: model.ApiPersonSexId, prsPreTel: model.ApiPersonPreTel, prsTel: model.ApiPersonTel, prsTelUpTo: model.ApiPersonTelUpTo, prsTelDesc: model.ApiPersonTelDesc, prsTelII: model.ApiPersonTelII, prsFax: model.ApiPersonFax, prsFaxDesc: model.ApiPersonFaxDesc, prsMobile: model.ApiPersonMobile, prsEmail: model.ApiPersonEmail, prsEmailII: model.ApiPersonEmailII, prsAddress: model.ApiPersonAddress, prsAddressDesc: model.ApiPersonAddressDesc, prsNationalCode: model.ApiPersonNationalCode, prsBirthDate: prsBirthDate, prsBirthDateTime: model.ApiPersonBirthDateTime, prsMarriageDate: prsMarriageDate, prsMarriageDateTime: model.ApiPersonMarriageDateTime, prsDescription: model.ApiPersonDescription, prsDepartmentId: model.ApiPersonDepartmentId, prjTitle: model.ApiProjectTitle, prjDesc: model.ApiProjectDesc, prjStarterUserId: model.ApiProjectStarterUserId, prjGradeId: model.ApiProjectGradeId, prjPriorityId: model.ApiProjectPriorityId, prjGroupId: model.ApiProjectGroupId, prjcnvsStatusGroupId: model.ApiProjectCnvsStatusGroupId, prjPostFix: model.ApiProjectPostFix, prjRemindDate: prjRemindDate, prjRemindDateTime: model.ApiProjectRemindDateTime, prjInsertCrmProjectForbiddenFUFDPActive: model.ApiProjectInsertCrmProjectForbiddenFUFDPActive, cnvsTopicId: model.ApiConversationTopicId, cnvsDesc: cnvsDesc, cnvsUserId: model.ApiConversationUserId, cnvsReferUserId: model.ApiConversationReferUserId, cnvsReferDesc: cnvsReferDesc, cnvsStatusId: model.ApiConversationStatusId, cnvsPriorityId: model.ApiConversationPriorityId, cnvsRemindDate: cnvsRemindDate, cnvsRemindDateTime: model.ApiConversationRemindDateTime, cnvsReferToMultilUser: model.ApiConversationReferToMultilUser, userId: value, month1: value3, registerDate: value2, registerDatePersian: registerDatePersian, registerTime: registerTime, registerDay: registerDay, appType: appType, needErjaRefMsgSubject: "", needErjaRefMsgBody: text11, needErjaMultiIntmsgSubject: "", needErjaMultiIntmsgBody: text22, conversationErjaShowText: dubClickDisplayCmpInfo, value: model.Value, insertedCompanyId: objectParameter, insertedPersonId: objectParameter2, insertedProjectId: objectParameter3, insertedConversationId: objectParameter4, errorMessage: objectParameter5, cmpCodeNotDup: model.CmpCodeNotDup));
			string resourceString = MyResource.GetResourceString("ErrorDoneOperationTryAgain", culture, "RegisterCompany.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
			string resourceString2 = MyResource.GetResourceString("ErrorTryAgain", culture, "RegisterCompany.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
			int result = 0;
			int.TryParse(num3.ToString(), out result);
			if (result <= 0)
			{
				return new ServiceResult<RegisterCompanyWithCnvsResultViewModel>
				{
					Message = resourceString.Replace("<br>", "\r\n"),
					Data = null,
					Status = ServiceResultStatus.Error
				};
			}
			if (objectParameter5.Value != null && objectParameter5.Value.ToString() != "")
			{
				string text30 = "";
				string text31 = objectParameter5.Value.ToString();
				if (text31.IndexOf("IsUser=0", StringComparison.Ordinal) >= 0)
				{
					text30 = text30 + MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", culture, "RegisterCompany.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "<br>";
					resourceString2 = "<br>" + MyResource.GetResourceString("ErrorUsernamePasswordIncorrect", culture, "RegisterCompany.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + resourceString2;
					return new ServiceResult<RegisterCompanyWithCnvsResultViewModel>
					{
						Message = resourceString2.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text31.IndexOf("DupUName=1", StringComparison.Ordinal) >= 0)
				{
					text30 = text30 + MyResource.GetResourceString("ErrorUsernameIsRepeat", culture, "RegisterCompany.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "<br>";
					resourceString2 = "<br>" + MyResource.GetResourceString("ErrorUsernameIsRepeat", culture, "RegisterCompany.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + resourceString2;
					return new ServiceResult<RegisterCompanyWithCnvsResultViewModel>
					{
						Message = resourceString2.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text31.IndexOf("DupCmpCode=", StringComparison.Ordinal) >= 0)
				{
					string[] array4 = text31.Split(new char[1] { '|' });
					string arg = "";
					if (array4 != null)
					{
						string[] array2 = array4;
						foreach (string text32 in array2)
						{
							if (!string.IsNullOrEmpty(text32) && text32.IndexOf("DupCmpCode=", StringComparison.Ordinal) >= 0)
							{
								string[] array5 = text32.Split(new char[1] { '=' });
								if (array5 != null && array5.Length == 2)
								{
									arg = ((array5[1] != null && array5[1] != "") ? array5[1] : "");
								}
							}
						}
					}
					text30 = text30 + string.Format(MyResource.GetResourceString("ErrorCheckCmpCodeDuplicate", culture, "RegisterCompany.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), model.ApiCustomerCode, arg) + "<br>";
					return new ServiceResult<RegisterCompanyWithCnvsResultViewModel>
					{
						Message = text30.Replace("<br>", "\r\n") + resourceString2.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text31.IndexOf("DupMob=", StringComparison.Ordinal) >= 0)
				{
					string[] array6 = text31.Split(new char[1] { '|' });
					string arg2 = "";
					if (array6 != null)
					{
						string[] array2 = array6;
						foreach (string text33 in array2)
						{
							if (!string.IsNullOrEmpty(text33) && text33.IndexOf("DupMob=", StringComparison.Ordinal) >= 0)
							{
								string[] array7 = text33.Split(new char[1] { '=' });
								if (array7 != null && array7.Length == 2)
								{
									arg2 = ((array7[1] != null && array7[1] != "") ? array7[1] : "");
								}
							}
						}
					}
					text30 = text30 + string.Format(MyResource.GetResourceString("ErrorCheckPrsMobileDuplicate", culture, "RegisterCompany.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), model.ApiPersonMobile, arg2) + "<br>";
					resourceString2 = "<br>" + MyResource.GetResourceString("ErrorMobileAlreadyRegistered", culture, "RegisterCompany.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + resourceString2;
					return new ServiceResult<RegisterCompanyWithCnvsResultViewModel>
					{
						Message = resourceString2.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text31.IndexOf("DupEmailI=", StringComparison.Ordinal) >= 0)
				{
					string[] array8 = text31.Split(new char[1] { '|' });
					string arg3 = "";
					if (array8 != null)
					{
						string[] array2 = array8;
						foreach (string text34 in array2)
						{
							if (!string.IsNullOrEmpty(text34) && text34.IndexOf("DupEmailI=", StringComparison.Ordinal) >= 0)
							{
								string[] array9 = text34.Split(new char[1] { '=' });
								if (array9 != null && array9.Length == 2)
								{
									arg3 = ((array9[1] != null && array9[1] != "") ? array9[1] : "");
								}
							}
						}
					}
					text30 = text30 + string.Format(MyResource.GetResourceString("ErrorCheckPrsEmailDuplicate", culture, "RegisterCompany.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), model.ApiPersonEmail, arg3) + "<br>";
					resourceString2 = "<br>" + MyResource.GetResourceString("ErrorEmailAlreadyRegistered", culture, "RegisterCompany.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + resourceString2;
					return new ServiceResult<RegisterCompanyWithCnvsResultViewModel>
					{
						Message = resourceString2.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text31.IndexOf("DupEmailII=", StringComparison.Ordinal) >= 0)
				{
					string[] array10 = text31.Split(new char[1] { '|' });
					string arg4 = "";
					if (array10 != null)
					{
						string[] array2 = array10;
						foreach (string text35 in array2)
						{
							if (!string.IsNullOrEmpty(text35) && text35.IndexOf("DupEmailII=", StringComparison.Ordinal) >= 0)
							{
								string[] array11 = text35.Split(new char[1] { '=' });
								if (array11 != null && array11.Length == 2)
								{
									arg4 = ((array11[1] != null && array11[1] != "") ? array11[1] : "");
								}
							}
						}
					}
					text30 = text30 + string.Format(MyResource.GetResourceString("ErrorCheckPrsEmailDuplicate", culture, "RegisterCompany.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly), model.ApiPersonEmail, arg4) + "<br>";
					resourceString2 = "<br>" + MyResource.GetResourceString("ErrorEmailIIAlreadyRegistered", culture, "RegisterCompany.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + resourceString2;
					return new ServiceResult<RegisterCompanyWithCnvsResultViewModel>
					{
						Message = resourceString2.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text31.IndexOf("ErrorInInsertCompany|", StringComparison.Ordinal) >= 0)
				{
					text30 = text30 + MyResource.GetResourceString("ErrorInInsertCompany", culture, "RegisterCompany.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "<br>";
					return new ServiceResult<RegisterCompanyWithCnvsResultViewModel>
					{
						Message = resourceString.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text31.IndexOf("ErrorInInsertPerson|", StringComparison.Ordinal) >= 0)
				{
					text30 = text30 + MyResource.GetResourceString("ErrorInInsertPerson", culture, "RegisterCompany.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "<br>";
					return new ServiceResult<RegisterCompanyWithCnvsResultViewModel>
					{
						Message = resourceString.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text31.IndexOf("ErrorInInsertProject|", StringComparison.Ordinal) >= 0)
				{
					text30 = text30 + MyResource.GetResourceString("ErrorInInsertProject", culture, "RegisterCompany.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "<br>";
					return new ServiceResult<RegisterCompanyWithCnvsResultViewModel>
					{
						Message = resourceString.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (text31.IndexOf("ErrorInInsertConversation|", StringComparison.Ordinal) >= 0)
				{
					text30 = text30 + MyResource.GetResourceString("ErrorInInsertConversation", culture, "RegisterCompany.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "<br>";
					return new ServiceResult<RegisterCompanyWithCnvsResultViewModel>
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
					return new ServiceResult<RegisterCompanyWithCnvsResultViewModel>
					{
						Message = resourceString.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (objectParameter2 == null || objectParameter2.Value.ToString() == "0")
				{
					return new ServiceResult<RegisterCompanyWithCnvsResultViewModel>
					{
						Message = resourceString.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (objectParameter3 == null || objectParameter3.Value.ToString() == "0")
				{
					return new ServiceResult<RegisterCompanyWithCnvsResultViewModel>
					{
						Message = resourceString.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				if (objectParameter4 == null || objectParameter4.Value.ToString() == "0")
				{
					return new ServiceResult<RegisterCompanyWithCnvsResultViewModel>
					{
						Message = resourceString.Replace("<br>", "\r\n"),
						Data = null,
						Status = ServiceResultStatus.Error
					};
				}
				data = new RegisterCompanyWithCnvsResultViewModel
				{
					Company = ((objectParameter.Value != null) ? int.Parse(objectParameter.Value.ToString() ?? "0") : 0),
					Person = ((objectParameter2.Value != null) ? int.Parse(objectParameter2.Value.ToString() ?? "0") : 0),
					Project = ((objectParameter3.Value != null) ? int.Parse(objectParameter3.Value.ToString() ?? "0") : 0),
					Conversation = ((objectParameter4.Value != null) ? int.Parse(objectParameter4.Value.ToString() ?? "0") : 0)
				};
				message = MyResource.GetResourceString("SuccessDoneRegister", culture, "RegisterCompany.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
				status = ServiceResultStatus.Success;
			}
		}
		catch (Exception ex)
		{
			string text36 = ((!string.IsNullOrEmpty(ex.Message)) ? ex.Message : "");
			if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
			{
				text36 = text36 + " - " + ex.InnerException.Message;
			}
			message = Messages.ErrorDoneOperation + ((!string.IsNullOrEmpty(text36)) ? (" (" + text36 + ")") : "");
			data = null;
			status = ServiceResultStatus.Error;
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<RegisterCompanyWithCnvsResultViewModel>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}
}
