using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Http;
using CRM.General.Security;
using CRM.General.Utilities;
using CRM.Resources;
using Elmah;
using GSD.Globalization;
using Mobile.Cache.Setting;
using Mobile.Classes;
using Mobile.Classes.Helper;
using Mobile.DataType;
using Mobile.Models;

namespace Mobile.Controllers;

public class FOAccountController : ApiController
{
	[HttpPost]
	public ServiceResult<FoLoginResult> Login(FoLoginModel login, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		CRMSpEntities cRMSpEntities = null;
		FoLoginResult foLoginResult = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int num = ((result > 0) ? result : result2);
		baseInfo.SetCulture(num);
		try
		{
			string text = "";
			if (base.Request.Headers.Contains("extra"))
			{
				text = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("extra"));
			}
			if (new FoCommon().CheckExtra(text))
			{
				FoCheckVersionResult foCheckVersionResult = new FoCommon().CheckVersion(login.apiVersion, login.appName);
				if (!foCheckVersionResult.Status && !string.IsNullOrEmpty(foCheckVersionResult.Message))
				{
					return new ServiceResult<FoLoginResult>
					{
						Message = foCheckVersionResult.Message,
						Data = null,
						Status = ServiceResultStatus.Fail
					};
				}
				FoSettingShareInfoViewModel foSettingShareInfo = FoCenter.GetFoSettingShareInfo();
				int? foSettingId = foSettingShareInfo.FoSettingShareId;
				int? centerId = foSettingShareInfo.FoSettingShareCId;
				if (login.FoSettingId != 0)
				{
					foSettingId = login.FoSettingId;
				}
				if (login.CenterId != 0)
				{
					centerId = login.CenterId;
				}
				cRMEntities = new CRMEntities();
				cRMSpEntities = new CRMSpEntities();
				string text2 = string.Empty;
				if (!string.IsNullOrEmpty(login.password))
				{
					text2 = XorCipher.EncryptByPublicKey(login.password);
				}
				FOMobspLoadCompanyLoginInfo_Result fOMobspLoadCompanyLoginInfo_Result = Enumerable.FirstOrDefault<FOMobspLoadCompanyLoginInfo_Result>((IEnumerable<FOMobspLoadCompanyLoginInfo_Result>)cRMSpEntities.FOMobspLoadCompanyLoginInfo(login.CmpId, cmpUserName: login.CmpUserName, password: text2, userName: login.username, loginType: login.LoginType, companyPersonId: login.PrsId, languageID: num, defaultLanguageID: result2, centerId: centerId, foSettingId: foSettingId));
				if (fOMobspLoadCompanyLoginInfo_Result != null)
				{
					foLoginResult = new FoLoginResult();
					long num2 = long.Parse(DateTime.Now.ToString("yyyyMMdd", new PersianCulture()));
					string text3 = fOMobspLoadCompanyLoginInfo_Result.cmpMobile ?? "";
					int result3 = 0;
					int.TryParse(fOMobspLoadCompanyLoginInfo_Result.LoginType.ToString(), out result3);
					if (result3 == 0)
					{
						result3 = 1;
					}
					FOMobspSelectCrmFoSetting_Result fOMobspSelectCrmFoSetting_Result = Enumerable.FirstOrDefault<FOMobspSelectCrmFoSetting_Result>((IEnumerable<FOMobspSelectCrmFoSetting_Result>)cRMSpEntities.FOMobspSelectCrmFoSetting(result, result2, centerId, foSettingId));
					bool result4 = false;
					bool.TryParse(fOMobspSelectCrmFoSetting_Result.LoginAndFoActive.ToString(), out result4);
					if (result4)
					{
						if (!fOMobspLoadCompanyLoginInfo_Result.cmpFOIsActive.GetValueOrDefault())
						{
							if (!Company.SetCmpFOIsActive(num))
							{
								ServiceResult<FoLoginResult> serviceResult = new ServiceResult<FoLoginResult>();
								message = (serviceResult.Message = Messages.msgErrorHaveNotAccessUseFoShp);
								serviceResult.Data = null;
								serviceResult.Status = ServiceResultStatus.Error;
								return serviceResult;
							}
							Company.UpdateCompanyFOInfoAndCIds(centerId.GetValueOrDefault(), fOMobspLoadCompanyLoginInfo_Result.CompanyID, "1", "", num);
						}
						if (result3 == 2 && !fOMobspLoadCompanyLoginInfo_Result.prsFOIsActive.GetValueOrDefault())
						{
							Company.UpdateCompanyPersonFOInfoAndCIds(centerId.GetValueOrDefault(), fOMobspLoadCompanyLoginInfo_Result.CompanyPersonID.GetValueOrDefault(), "1", "", num);
						}
						FOMobspLoadCompanyLoginInfo_Result fOMobspLoadCompanyLoginInfo_Result2 = Enumerable.FirstOrDefault<FOMobspLoadCompanyLoginInfo_Result>((IEnumerable<FOMobspLoadCompanyLoginInfo_Result>)cRMSpEntities.FOMobspLoadCompanyLoginInfo(login.CmpId, cmpUserName: login.CmpUserName, password: text2, userName: login.username, loginType: login.LoginType, companyPersonId: login.PrsId, languageID: num, defaultLanguageID: result2, centerId: centerId, foSettingId: foSettingId));
						if (fOMobspLoadCompanyLoginInfo_Result2 != null)
						{
							fOMobspLoadCompanyLoginInfo_Result.cmpFOIsActive = fOMobspLoadCompanyLoginInfo_Result2.cmpFOIsActive;
						}
					}
					if (fOMobspLoadCompanyLoginInfo_Result.CompanyPersonID.GetValueOrDefault() != 0)
					{
						foLoginResult.cmpMobile = fOMobspLoadCompanyLoginInfo_Result.PersonMobile ?? text3;
					}
					if (fOMobspLoadCompanyLoginInfo_Result.cmpFOLoginExpireDate.HasValue)
					{
						string s = (fOMobspLoadCompanyLoginInfo_Result.cmpFOLoginExpireDate.HasValue ? fOMobspLoadCompanyLoginInfo_Result.cmpFOLoginExpireDate.Value.ToString("yyyyMMdd", new PersianCulture()) : "");
						long result5 = 0L;
						long.TryParse(s, out result5);
						if (num2 > result5 && result5 > 0)
						{
							return new ServiceResult<FoLoginResult>
							{
								Message = Messages.FOMsgErrorUsernameExpired,
								Data = null,
								Status = ServiceResultStatus.Error
							};
						}
					}
					if (result3 == 2)
					{
						if (!fOMobspLoadCompanyLoginInfo_Result.prsFOIsActive.GetValueOrDefault())
						{
							ServiceResult<FoLoginResult> serviceResult2 = new ServiceResult<FoLoginResult>();
							message = (serviceResult2.Message = Messages.msgErrorHaveNotAccessUseFoShp);
							serviceResult2.Data = null;
							serviceResult2.Status = ServiceResultStatus.Error;
							return serviceResult2;
						}
						if (fOMobspLoadCompanyLoginInfo_Result.prsFOLoginExpireDate.HasValue)
						{
							string s2 = (fOMobspLoadCompanyLoginInfo_Result.prsFOLoginExpireDate.HasValue ? fOMobspLoadCompanyLoginInfo_Result.prsFOLoginExpireDate.Value.ToString("yyyyMMdd", new PersianCulture()) : "");
							long result6 = 0L;
							long.TryParse(s2, out result6);
							if (num2 > result6 && result6 > 0)
							{
								return new ServiceResult<FoLoginResult>
								{
									Message = Messages.FOMsgErrorUsernameExpired,
									Data = null,
									Status = ServiceResultStatus.Error
								};
							}
						}
					}
					foLoginResult.LoginType = result3;
					RandomText randomText = new RandomText();
					string getString = randomText.CreateRandomCode(5, WithNumber: true).Replace(" ", "").Trim() + "|" + fOMobspLoadCompanyLoginInfo_Result.CompanyID + "|" + randomText.CreateRandomCode(5, WithNumber: true).Replace(" ", "").Trim() + "|" + text + "|" + randomText.CreateRandomCode(5, WithNumber: true).Replace(" ", "").Trim() + "|" + DateTime.Now.ToString("yyyyMMdd-HHmmss", new PersianCulture()) + "|" + randomText.CreateRandomCode(5, WithNumber: true).Replace(" ", "").Trim();
					foLoginResult.Token = CodeDecode.Codding(getString);
					foLoginResult.CompanyID = fOMobspLoadCompanyLoginInfo_Result.CompanyID;
					foLoginResult.cmpNumber = fOMobspLoadCompanyLoginInfo_Result.cmpNumber;
					foLoginResult.CompanyName = fOMobspLoadCompanyLoginInfo_Result.CompanyName;
					if (result3 == 2)
					{
						foLoginResult.cmpMainPersonId = fOMobspLoadCompanyLoginInfo_Result.CompanyPersonID.GetValueOrDefault();
					}
					else
					{
						foLoginResult.cmpMainPersonId = fOMobspLoadCompanyLoginInfo_Result.cmpMainPersonId.GetValueOrDefault();
					}
					foLoginResult.cmpPersonName = fOMobspLoadCompanyLoginInfo_Result.PersonName;
					if (login.username == login.password)
					{
						foLoginResult.cmpMobile = text3;
					}
					foLoginResult.cmpPrsMobile = fOMobspLoadCompanyLoginInfo_Result.PrsMobile ?? "";
					foLoginResult.cmpFOIsActive = fOMobspLoadCompanyLoginInfo_Result.cmpFOIsActive.GetValueOrDefault();
					foLoginResult.MaxFileSizeForUploadMb = Mobile.Classes.Configuration.MaxFileSizeForUploadMb;
					foLoginResult.MaliciousFileExtensions = Mobile.Classes.Configuration.MaliciousFileExtensions;
					foLoginResult.FileDirectoryTitleLength = Mobile.Classes.Configuration.FileDirectoryTitleLength;
					foLoginResult.VBTicketPlus = VersionBuyer.TicketPlus;
					foLoginResult.VBSimpleTicket = VersionBuyer.SimpleTicket;
					foLoginResult.VBCallerId = VersionBuyer.CallerId;
					foLoginResult.VBRecorder = VersionBuyer.Recorder;
					foLoginResult.VBOnlinePay = VersionBuyer.OnlinePay;
					foLoginResult.VBAttachFiles = VersionBuyer.AttachFiles;
					foLoginResult.LastCId = fOMobspLoadCompanyLoginInfo_Result.LastCId;
					foLoginResult.FoActiveCIds = fOMobspLoadCompanyLoginInfo_Result.FoActiveCIds;
					foLoginResult.VBCenter = VersionBuyer.Center;
					FOMobspReturnSumCompanyScores_Result fOMobspReturnSumCompanyScores_Result = Enumerable.FirstOrDefault<FOMobspReturnSumCompanyScores_Result>((IEnumerable<FOMobspReturnSumCompanyScores_Result>)cRMSpEntities.FOMobspReturnSumCompanyScores(fOMobspLoadCompanyLoginInfo_Result.CompanyID, centerId));
					foLoginResult.CompanyScore = fOMobspReturnSumCompanyScores_Result.SumUsableScores;
					foLoginResult.CompanyProjectValidityPrd = Enumerable.ToList<FOMobspSelectCompanyProjectValidityPrd_Result>((IEnumerable<FOMobspSelectCompanyProjectValidityPrd_Result>)cRMSpEntities.FOMobspSelectCompanyProjectValidityPrd(fOMobspLoadCompanyLoginInfo_Result.CompanyID, DateTime.Now, result, result2));
					message = Messages.MobMsgSuccessAction;
					status = ServiceResultStatus.Success;
				}
				else
				{
					message = Messages.MobMsgErrorUsernamePasswordIncorrect;
					foLoginResult = null;
					status = ServiceResultStatus.Fail;
				}
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			foLoginResult = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<FoLoginResult>
		{
			Message = message,
			Data = foLoginResult,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<FoLoginResult> LoginFromUrl(string apiVersion, string appName, int mode, string mobile, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		CRMSpEntities cRMSpEntities = null;
		FoLoginResult foLoginResult = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int num = ((result > 0) ? result : result2);
		baseInfo.SetCulture(num);
		try
		{
			string text = "";
			if (base.Request.Headers.Contains("extra"))
			{
				text = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("extra"));
			}
			if (new FoCommon().CheckExtra(text))
			{
				FoCheckVersionResult foCheckVersionResult = new FoCommon().CheckVersion(apiVersion, appName);
				if (!foCheckVersionResult.Status && !string.IsNullOrEmpty(foCheckVersionResult.Message))
				{
					return new ServiceResult<FoLoginResult>
					{
						Message = foCheckVersionResult.Message,
						Data = null,
						Status = ServiceResultStatus.Fail
					};
				}
				FoSettingShareInfoViewModel foSettingShareInfo = FoCenter.GetFoSettingShareInfo();
				int? foSettingShareId = foSettingShareInfo.FoSettingShareId;
				int? foSettingShareCId = foSettingShareInfo.FoSettingShareCId;
				cRMEntities = new CRMEntities();
				cRMSpEntities = new CRMSpEntities();
				FOMobspSelectCompanyOrPersonByMobile_Result fOMobspSelectCompanyOrPersonByMobile_Result = Enumerable.FirstOrDefault<FOMobspSelectCompanyOrPersonByMobile_Result>((IEnumerable<FOMobspSelectCompanyOrPersonByMobile_Result>)cRMSpEntities.FOMobspSelectCompanyOrPersonByMobile(mode, mobile, num, result2));
				if (fOMobspSelectCompanyOrPersonByMobile_Result != null)
				{
					foLoginResult = new FoLoginResult();
					long num2 = long.Parse(DateTime.Now.ToString("yyyyMMdd", new PersianCulture()));
					string text2 = fOMobspSelectCompanyOrPersonByMobile_Result.cmpMobile ?? "";
					int result3 = 0;
					int.TryParse(fOMobspSelectCompanyOrPersonByMobile_Result.LoginType.ToString(), out result3);
					if (result3 == 0)
					{
						result3 = 1;
					}
					FOMobspSelectCrmFoSetting_Result fOMobspSelectCrmFoSetting_Result = Enumerable.FirstOrDefault<FOMobspSelectCrmFoSetting_Result>((IEnumerable<FOMobspSelectCrmFoSetting_Result>)cRMSpEntities.FOMobspSelectCrmFoSetting(result, result2, foSettingShareCId, foSettingShareId));
					bool result4 = false;
					bool.TryParse(fOMobspSelectCrmFoSetting_Result.LoginAndFoActive.ToString(), out result4);
					if (result4)
					{
						if (!fOMobspSelectCompanyOrPersonByMobile_Result.cmpFOIsActive.GetValueOrDefault())
						{
							if (!Company.SetCmpFOIsActive(num))
							{
								ServiceResult<FoLoginResult> serviceResult = new ServiceResult<FoLoginResult>();
								message = (serviceResult.Message = Messages.msgErrorHaveNotAccessUseFoShp);
								serviceResult.Data = null;
								serviceResult.Status = ServiceResultStatus.Error;
								return serviceResult;
							}
							Company.UpdateCompanyFOInfoAndCIds(foSettingShareCId.GetValueOrDefault(), fOMobspSelectCompanyOrPersonByMobile_Result.CompanyID, "1", "", num);
						}
						if (result3 == 2 && !fOMobspSelectCompanyOrPersonByMobile_Result.prsFOIsActive.GetValueOrDefault())
						{
							Company.UpdateCompanyPersonFOInfoAndCIds(foSettingShareCId.GetValueOrDefault(), fOMobspSelectCompanyOrPersonByMobile_Result.CompanyPersonID.GetValueOrDefault(), "1", "", num);
						}
						FOMobspSelectCompanyOrPersonByMobile_Result fOMobspSelectCompanyOrPersonByMobile_Result2 = Enumerable.FirstOrDefault<FOMobspSelectCompanyOrPersonByMobile_Result>((IEnumerable<FOMobspSelectCompanyOrPersonByMobile_Result>)cRMSpEntities.FOMobspSelectCompanyOrPersonByMobile(mode, mobile, num, result2));
						if (fOMobspSelectCompanyOrPersonByMobile_Result2 != null)
						{
							fOMobspSelectCompanyOrPersonByMobile_Result.cmpFOIsActive = fOMobspSelectCompanyOrPersonByMobile_Result2.cmpFOIsActive;
						}
					}
					if (fOMobspSelectCompanyOrPersonByMobile_Result.CompanyPersonID.GetValueOrDefault() != 0)
					{
						foLoginResult.cmpMobile = fOMobspSelectCompanyOrPersonByMobile_Result.PersonMobile ?? text2;
					}
					if (fOMobspSelectCompanyOrPersonByMobile_Result.cmpFOLoginExpireDate.HasValue)
					{
						string s = (fOMobspSelectCompanyOrPersonByMobile_Result.cmpFOLoginExpireDate.HasValue ? fOMobspSelectCompanyOrPersonByMobile_Result.cmpFOLoginExpireDate.Value.ToString("yyyyMMdd", new PersianCulture()) : "");
						long result5 = 0L;
						long.TryParse(s, out result5);
						if (num2 > result5 && result5 > 0)
						{
							return new ServiceResult<FoLoginResult>
							{
								Message = Messages.FOMsgErrorUsernameExpired,
								Data = null,
								Status = ServiceResultStatus.Error
							};
						}
					}
					if (result3 == 2)
					{
						if (!fOMobspSelectCompanyOrPersonByMobile_Result.prsFOIsActive.GetValueOrDefault())
						{
							ServiceResult<FoLoginResult> serviceResult2 = new ServiceResult<FoLoginResult>();
							message = (serviceResult2.Message = Messages.msgErrorHaveNotAccessUseFoShp);
							serviceResult2.Data = null;
							serviceResult2.Status = ServiceResultStatus.Error;
							return serviceResult2;
						}
						if (fOMobspSelectCompanyOrPersonByMobile_Result.prsFOLoginExpireDate.HasValue)
						{
							string s2 = (fOMobspSelectCompanyOrPersonByMobile_Result.prsFOLoginExpireDate.HasValue ? fOMobspSelectCompanyOrPersonByMobile_Result.prsFOLoginExpireDate.Value.ToString("yyyyMMdd", new PersianCulture()) : "");
							long result6 = 0L;
							long.TryParse(s2, out result6);
							if (num2 > result6 && result6 > 0)
							{
								return new ServiceResult<FoLoginResult>
								{
									Message = Messages.FOMsgErrorUsernameExpired,
									Data = null,
									Status = ServiceResultStatus.Error
								};
							}
						}
					}
					foLoginResult.LoginType = result3;
					RandomText randomText = new RandomText();
					string getString = randomText.CreateRandomCode(5, WithNumber: true).Replace(" ", "").Trim() + "|" + fOMobspSelectCompanyOrPersonByMobile_Result.CompanyID + "|" + randomText.CreateRandomCode(5, WithNumber: true).Replace(" ", "").Trim() + "|" + text + "|" + randomText.CreateRandomCode(5, WithNumber: true).Replace(" ", "").Trim() + "|" + DateTime.Now.ToString("yyyyMMdd-HHmmss", new PersianCulture()) + "|" + randomText.CreateRandomCode(5, WithNumber: true).Replace(" ", "").Trim();
					foLoginResult.Token = CodeDecode.Codding(getString);
					foLoginResult.CompanyID = fOMobspSelectCompanyOrPersonByMobile_Result.CompanyID;
					foLoginResult.cmpNumber = fOMobspSelectCompanyOrPersonByMobile_Result.cmpNumber;
					foLoginResult.CompanyName = fOMobspSelectCompanyOrPersonByMobile_Result.CompanyName;
					foLoginResult.cmpMainPersonId = fOMobspSelectCompanyOrPersonByMobile_Result.CompanyPersonID.GetValueOrDefault();
					foLoginResult.cmpPrsMobile = fOMobspSelectCompanyOrPersonByMobile_Result.PersonMobile ?? "";
					foLoginResult.cmpFOIsActive = fOMobspSelectCompanyOrPersonByMobile_Result.cmpFOIsActive.GetValueOrDefault();
					foLoginResult.cmpPersonName = fOMobspSelectCompanyOrPersonByMobile_Result.PersonName;
					if (fOMobspSelectCompanyOrPersonByMobile_Result.cmpUserName == fOMobspSelectCompanyOrPersonByMobile_Result.cmpPassword)
					{
						foLoginResult.cmpMobile = text2;
					}
					foLoginResult.MaxFileSizeForUploadMb = Mobile.Classes.Configuration.MaxFileSizeForUploadMb;
					foLoginResult.MaliciousFileExtensions = Mobile.Classes.Configuration.MaliciousFileExtensions;
					foLoginResult.FileDirectoryTitleLength = Mobile.Classes.Configuration.FileDirectoryTitleLength;
					foLoginResult.VBTicketPlus = VersionBuyer.TicketPlus;
					foLoginResult.VBSimpleTicket = VersionBuyer.SimpleTicket;
					foLoginResult.VBCallerId = VersionBuyer.CallerId;
					foLoginResult.VBRecorder = VersionBuyer.Recorder;
					foLoginResult.VBOnlinePay = VersionBuyer.OnlinePay;
					foLoginResult.VBAttachFiles = VersionBuyer.AttachFiles;
					foLoginResult.LastCId = fOMobspSelectCompanyOrPersonByMobile_Result.LastCId;
					foLoginResult.FoActiveCIds = fOMobspSelectCompanyOrPersonByMobile_Result.CIds;
					foLoginResult.VBCenter = VersionBuyer.Center;
					FOMobspReturnSumCompanyScores_Result fOMobspReturnSumCompanyScores_Result = Enumerable.FirstOrDefault<FOMobspReturnSumCompanyScores_Result>((IEnumerable<FOMobspReturnSumCompanyScores_Result>)cRMSpEntities.FOMobspReturnSumCompanyScores(fOMobspSelectCompanyOrPersonByMobile_Result.CompanyID, null));
					foLoginResult.CompanyScore = fOMobspReturnSumCompanyScores_Result.SumUsableScores;
					foLoginResult.CompanyProjectValidityPrd = Enumerable.ToList<FOMobspSelectCompanyProjectValidityPrd_Result>((IEnumerable<FOMobspSelectCompanyProjectValidityPrd_Result>)cRMSpEntities.FOMobspSelectCompanyProjectValidityPrd(fOMobspSelectCompanyOrPersonByMobile_Result.CompanyID, DateTime.Now, result, result2));
					message = Messages.MobMsgSuccessAction;
					status = ServiceResultStatus.Success;
				}
				else
				{
					message = Messages.MobMsgErrorUsernamePasswordIncorrect;
					foLoginResult = null;
					status = ServiceResultStatus.Fail;
				}
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			foLoginResult = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<FoLoginResult>
		{
			Message = message,
			Data = foLoginResult,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<string> ForgotPassword(string emailMobile, int? ln = null, int? cId = null, int? foSettingId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		CRMSpEntities cRMSpEntities = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int num = ((result > 0) ? result : result2);
		baseInfo.SetCulture(num);
		string data;
		try
		{
			cRMEntities = new CRMEntities();
			cRMSpEntities = new CRMSpEntities();
			if (!cId.HasValue || cId == 0)
			{
				cId = FoCenter.GetCurrentCId();
			}
			if (!foSettingId.HasValue)
			{
				foSettingId = FoCenter.GetFoSettingShareInfo().FoSettingShareId;
			}
			FOMobspSelectCrmFoSetting_Result fOMobspSelectCrmFoSetting_Result = Enumerable.FirstOrDefault<FOMobspSelectCrmFoSetting_Result>((IEnumerable<FOMobspSelectCrmFoSetting_Result>)cRMSpEntities.FOMobspSelectCrmFoSetting(num, result2, cId, foSettingId));
			int result3 = 0;
			int.TryParse(fOMobspSelectCrmFoSetting_Result.EmailUserInfoId.ToString(), out result3);
			int result4 = 0;
			int.TryParse(fOMobspSelectCrmFoSetting_Result.EmailSettingId.ToString(), out result4);
			FoEmail foEmail = new FoEmail(cId, foSettingId);
			_ = "<br>" + Labels.FOForgotPasswordEmailORMobile + "= " + emailMobile + "<br>";
			string arg = "";
			MobspSelectCrmsysSetting_Result mobspSelectCrmsysSetting_Result = SysSeting.Get();
			if (mobspSelectCrmsysSetting_Result != null)
			{
				arg = mobspSelectCrmsysSetting_Result.CoName ?? "";
			}
			FOMobspSelectCompanyByEmailOrMobile_Result fOMobspSelectCompanyByEmailOrMobile_Result = Enumerable.FirstOrDefault<FOMobspSelectCompanyByEmailOrMobile_Result>((IEnumerable<FOMobspSelectCompanyByEmailOrMobile_Result>)cRMEntities.FOMobspSelectCompanyByEmailOrMobile(emailMobile, num, result2, cId));
			if (fOMobspSelectCompanyByEmailOrMobile_Result != null)
			{
				if (fOMobspSelectCrmFoSetting_Result != null && fOMobspSelectCrmFoSetting_Result.EmailSendingIsActive.GetValueOrDefault() && !string.IsNullOrEmpty(fOMobspSelectCompanyByEmailOrMobile_Result.cmpEmail))
				{
					DateTime now = DateTime.Now;
					StreamReader streamReader = new StreamReader(HttpContext.Current.Server.MapPath("~/EmailTemplate/ForgotPassword.html"));
					if (!Thread.CurrentThread.CurrentCulture.TextInfo.IsRightToLeft)
					{
						streamReader = new StreamReader(HttpContext.Current.Server.MapPath("~/EmailTemplate/ForgotPassword-LTR.html"));
					}
					string text = streamReader.ReadToEnd();
					streamReader.Close();
					text = text.Replace("#ForgettingPassword#", Labels.FOForgettingPassword);
					text = text.Replace("#FODearUser#", Labels.FODearUser);
					text = text.Replace("#Email#", fOMobspSelectCompanyByEmailOrMobile_Result.cmpEmail);
					text = text.Replace("#Hi#", Labels.FOHi);
					text = text.Replace("#EmailTempTextI#", string.Format(Labels.FOForgotPasswordEmailTempTextI, arg));
					text = text.Replace("#EmailTempTextIII#", string.Format(Labels.FOForgotPasswordEmailTempTextIII, now.ToString("yyyy/MM/dd")));
					text = text.Replace("#EmailTempTextII#", Labels.FOForgotPasswordEmailTempTextII);
					string text2 = CodeDecode.Codding(now.AddHours(24.0).ToString("yyyy/MM/dd HH:mm:ss"), Mobile.Classes.Configuration.ForgotPassword);
					string text3 = CodeDecode.Codding(fOMobspSelectCompanyByEmailOrMobile_Result.CompanyID.ToString(), Mobile.Classes.Configuration.ForgotPassword);
					string text4 = CodeDecode.Codding(fOMobspSelectCompanyByEmailOrMobile_Result.cmpEmail.ToString(), Mobile.Classes.Configuration.ForgotPassword);
					string getString = "dt=[" + text2 + "]id=[" + text3 + "]email=[" + text4 + "]";
					getString = CodeDecode.Codding(getString, Mobile.Classes.Configuration.ForgotPassword);
					string absoluteUri = HttpContext.Current.Request.Url.AbsoluteUri;
					absoluteUri = absoluteUri.Replace("/Account/ForgotPassword", "/Users/Home/ResetPassword");
					text = text.Replace("#url#", absoluteUri + "?qs=" + getString);
					text = text.Replace("#link#", absoluteUri);
					text = text.Replace("#BtnCreatePassword#", Buttons.FOBtnResetPassword);
					EmailSendViewModel item = new EmailSendViewModel
					{
						EmailSubject = Labels.FOForgettingPassword,
						EmailBody = text,
						PriorityId = 0,
						EmailUsersInfoId = result3,
						EmailSettingId = result4,
						EmailAddress = fOMobspSelectCompanyByEmailOrMobile_Result.cmpEmail,
						EmailCmpId = fOMobspSelectCompanyByEmailOrMobile_Result.CompanyID,
						EmailCmpPrsId = null,
						EmailCmpPrjId = null,
						EmailCmpPrsName = null,
						EmailCmpName = fOMobspSelectCompanyByEmailOrMobile_Result.cmpName,
						EmailPrsJob = null,
						StatusId = 1,
						IsLogEmailAdmin = false,
						CmpPassword = null,
						CId = cId
					};
					foEmail.SendGeneralEmail(item);
				}
				if (fOMobspSelectCrmFoSetting_Result != null && fOMobspSelectCrmFoSetting_Result.SmsSendingIsActive.GetValueOrDefault() && !string.IsNullOrEmpty(fOMobspSelectCompanyByEmailOrMobile_Result.cmpMobile) && emailMobile.IndexOf("@", StringComparison.Ordinal) < 0)
				{
					string cmpPassword = "";
					if (!string.IsNullOrEmpty(fOMobspSelectCompanyByEmailOrMobile_Result.cmpPassword))
					{
						cmpPassword = XorCipher.DecryptByPrivateKey(fOMobspSelectCompanyByEmailOrMobile_Result.cmpPassword);
					}
					FoSms foSms = new FoSms();
					FoSmsSendViewModel foSmsSendViewModel = new FoSmsSendViewModel
					{
						CompanyId = fOMobspSelectCompanyByEmailOrMobile_Result.CompanyID,
						CompanyPersonId = null,
						PrsMobile = fOMobspSelectCompanyByEmailOrMobile_Result.cmpMobile,
						CmpPassword = cmpPassword
					};
					bool result5 = false;
					if (fOMobspSelectCrmFoSetting_Result != null)
					{
						bool.TryParse(fOMobspSelectCrmFoSetting_Result.SmsIsSendedVerification.ToString(), out result5);
					}
					foSms.SendSms(foSmsSendViewModel, result5, cId: cId, foSettingId: foSettingId, isManualSmsBody: false);
				}
				if (emailMobile.IndexOf("@", StringComparison.Ordinal) >= 0)
				{
					message = Labels.FOSendRecoveryEmailDesc;
					data = null;
					status = ServiceResultStatus.Success;
				}
				else
				{
					message = Labels.FOSendRecoverysmsTitle + "<br>" + Messages.FOMsgSendPasswordIn30Sec;
					data = null;
					status = ServiceResultStatus.Success;
				}
			}
			else
			{
				message = Messages.FOMsgErrorEmailOrMobNotInSite;
				data = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<string>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<string> CheckApiAndDbVersion(string apiVersion, string appName, int? ln = 1065)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		string data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		try
		{
			string extra = "";
			if (base.Request.Headers.Contains("extra"))
			{
				extra = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("extra"));
			}
			if (new FoCommon().CheckExtra(extra))
			{
				FoCheckVersionResult foCheckVersionResult = new FoCommon().CheckVersion(apiVersion, appName);
				if (!foCheckVersionResult.Status && !string.IsNullOrEmpty(foCheckVersionResult.Message))
				{
					status = ServiceResultStatus.Fail;
					message = foCheckVersionResult.Message;
					data = null;
				}
				else
				{
					status = ServiceResultStatus.Success;
					message = Messages.MobMsgSuccessAction;
					data = null;
				}
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<string>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[FoMobileAuthorize]
	public ServiceResult<string> ResetPassword(string newPassword, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		string data;
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				FoToken token2 = new FoCommon().GetToken(token);
				if (token2 != null)
				{
					cRMEntities = new CRMEntities();
					string text = null;
					if (string.IsNullOrEmpty(newPassword))
					{
						ServiceResult<string> result3 = new ServiceResult<string>
						{
							Message = Messages.MobMsgSendParameterNotEntered,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
						cRMEntities?.Dispose();
						return result3;
					}
					text = XorCipher.EncryptByPrivateKey(newPassword);
					DateTime now = DateTime.Now;
					DateTime value = now;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					short value2 = short.Parse(Financial.Get().Id.ToString());
					short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
					string appType = Mobile.Classes.Configuration.AppType;
					ObjectParameter objectParameter = new ObjectParameter("ErrorMessage", "");
					int? num = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.FOMobspResetCompanyPassword(token2.CompanyId, text, -20, value2, value3, value, registerDatePersian, appType, objectParameter));
					int result4 = 0;
					int.TryParse(num.ToString(), out result4);
					if (result4 > 0)
					{
						if (objectParameter.Value != null && objectParameter.Value.ToString() != "")
						{
							data = null;
							message = Messages.MobMsgErrorDoneOperation;
							status = ServiceResultStatus.Fail;
						}
						else
						{
							data = null;
							message = Messages.MobMsgSuccessAction;
							status = ServiceResultStatus.Success;
						}
					}
					else
					{
						data = null;
						message = Messages.MobMsgErrorDoneOperation;
						status = ServiceResultStatus.Fail;
					}
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					data = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				data = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<string>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[FoMobileAuthorize]
	public ServiceResult<string> ResetPasswordSendCodeBySMS(string mobile, int? ln = null, int? cId = null, int? foSettingId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		CRMSpEntities cRMSpEntities = null;
		string data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int num = ((result > 0) ? result : result2);
		baseInfo.SetCulture(num);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				FoToken token2 = new FoCommon().GetToken(token);
				if (token2 != null)
				{
					cRMEntities = new CRMEntities();
					cRMSpEntities = new CRMSpEntities();
					FOMobspSelectCrmFoSetting_Result fOMobspSelectCrmFoSetting_Result = Enumerable.FirstOrDefault<FOMobspSelectCrmFoSetting_Result>((IEnumerable<FOMobspSelectCrmFoSetting_Result>)cRMSpEntities.FOMobspSelectCrmFoSetting(num, result2, cId, foSettingId));
					string text = new Random().Next(10000, 99999).ToString();
					if (!string.IsNullOrEmpty(text))
					{
						if (fOMobspSelectCrmFoSetting_Result != null && fOMobspSelectCrmFoSetting_Result.SmsSendingIsActive.GetValueOrDefault() && !string.IsNullOrEmpty(mobile))
						{
							FoSms foSms = new FoSms();
							FoSmsSendViewModel foSmsSendViewModel = new FoSmsSendViewModel();
							foSmsSendViewModel.CompanyId = token2.CompanyId;
							foSmsSendViewModel.CompanyPersonId = null;
							foSmsSendViewModel.PrsMobile = mobile;
							foSmsSendViewModel.CmpPassword = text;
							foSmsSendViewModel.SmsText = Labels.FOResetPasswordVerifyCode + " : " + text + "\n" + Labels.FOResetPasswordCalcel11;
							FoSmsSendViewModel item = foSmsSendViewModel;
							bool result3 = false;
							if (fOMobspSelectCrmFoSetting_Result != null)
							{
								bool.TryParse(fOMobspSelectCrmFoSetting_Result.SmsIsSendedVerification.ToString(), out result3);
							}
							foSms.SendSms(item, result3, true, cId, foSettingId);
							message = Labels.FOMsgSuccessTitle;
							data = text;
							status = ServiceResultStatus.Success;
						}
						else
						{
							message = Messages.MobFoMsgSmsSendingIsInactive;
							data = null;
							status = ServiceResultStatus.Error;
						}
					}
					else
					{
						message = Messages.FOMsgErrorEmailOrMobNotInSite;
						data = null;
						status = ServiceResultStatus.Error;
					}
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					data = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				data = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<string>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[FoMobileAuthorize]
	public ServiceResult<string> InsertCompanyAppDeviceInfo(FoInsertCompanyAppDeviceInfoViewModel model)
	{
		int result = 1065;
		if (model.LanguageId.HasValue)
		{
			int.TryParse(model.LanguageId.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		CRMSpEntities cRMSpEntities = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		string data;
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				FoToken token2 = new FoCommon().GetToken(token);
				if (token2 != null)
				{
					DateTime now = DateTime.Now;
					DateTime value = now;
					string firstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					cRMSpEntities = new CRMSpEntities();
					cRMSpEntities.FOMobspDeleteCompanyAppDeviceInfo(model.DeviceId, model.DeviceType);
					cRMSpEntities.FOMobspInsertCompanyAppDeviceInfo(token2.CompanyId, model.DeviceId, model.DeviceType, value, firstRegisterDatePersian, null, null, null);
					data = null;
					message = Messages.MobMsgSuccessAction;
					status = ServiceResultStatus.Success;
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					data = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				data = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<string>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[FoMobileAuthorize]
	public ServiceResult<string> DeleteCompanyAppDeviceInfo(FoDeleteCompanyAppDeviceInfo model)
	{
		int result = 1065;
		if (model.LanguageId.HasValue)
		{
			int.TryParse(model.LanguageId.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		CRMSpEntities cRMSpEntities = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		string data;
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new FoCommon().GetToken(token) != null)
				{
					DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
					cRMSpEntities = new CRMSpEntities();
					cRMSpEntities.FOMobspDeleteCompanyAppDeviceInfo(model.DeviceId, model.DeviceType);
					data = null;
					message = Messages.MobMsgSuccessAction;
					status = ServiceResultStatus.Success;
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					data = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				data = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<string>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<string> SendLoginOTPCode(int loginType, string userName = "", string password = "", string cmpUserName = "", int? ln = null, int? cId = null, int? foSettingId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		BaseInfo baseInfo = new BaseInfo();
		int num = ((result > 0) ? result : result2);
		baseInfo.SetCulture(num);
		CRMEntities cRMEntities = null;
		CRMSpEntities cRMSpEntities = null;
		string data = "";
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			cRMEntities = new CRMEntities();
			cRMSpEntities = new CRMSpEntities();
			int? num2 = FoCenter.GetCurrentCId();
			if (cId.GetValueOrDefault() != 0)
			{
				num2 = cId;
			}
			int? num3 = FoCenter.GetCurrentFoSettingId(num2.GetValueOrDefault());
			if (foSettingId.GetValueOrDefault() != 0)
			{
				num3 = foSettingId;
			}
			if (loginType == 0)
			{
				loginType = 1;
			}
			if (!string.IsNullOrWhiteSpace(userName) && !string.IsNullOrWhiteSpace(password))
			{
				FOMobspLoadCompanyLoginInfo_Result fOMobspLoadCompanyLoginInfo_Result = Enumerable.FirstOrDefault<FOMobspLoadCompanyLoginInfo_Result>((IEnumerable<FOMobspLoadCompanyLoginInfo_Result>)cRMSpEntities.FOMobspLoadCompanyLoginInfo(0, num, result2, cmpUserName, userName, password, loginType, 0, num2, num3));
				if (fOMobspLoadCompanyLoginInfo_Result != null)
				{
					int num4 = 0;
					long num5 = long.Parse(DateTime.Now.ToString("yyyyMMdd", new PersianCulture()));
					string text = fOMobspLoadCompanyLoginInfo_Result.cmpMobile ?? "";
					int.TryParse(fOMobspLoadCompanyLoginInfo_Result.LoginType.ToString(), out loginType);
					if (loginType == 0)
					{
						loginType = 1;
					}
					if (fOMobspLoadCompanyLoginInfo_Result.CompanyPersonID.GetValueOrDefault() != 0)
					{
						text = fOMobspLoadCompanyLoginInfo_Result.PersonMobile;
					}
					if (fOMobspLoadCompanyLoginInfo_Result.cmpFOLoginExpireDate.HasValue)
					{
						string s = (fOMobspLoadCompanyLoginInfo_Result.cmpFOLoginExpireDate.HasValue ? fOMobspLoadCompanyLoginInfo_Result.cmpFOLoginExpireDate.Value.ToString("yyyyMMdd", new PersianCulture()) : "");
						long result3 = 0L;
						long.TryParse(s, out result3);
						if (num5 > result3 && result3 > 0)
						{
							ServiceResult<string> result4 = new ServiceResult<string>
							{
								Data = null,
								Message = Messages.FOMsgErrorUsernameExpired,
								Status = ServiceResultStatus.Error
							};
							num4++;
							return result4;
						}
					}
					if (loginType == 2 && fOMobspLoadCompanyLoginInfo_Result.prsFOLoginExpireDate.HasValue)
					{
						string s2 = (fOMobspLoadCompanyLoginInfo_Result.prsFOLoginExpireDate.HasValue ? fOMobspLoadCompanyLoginInfo_Result.prsFOLoginExpireDate.Value.ToString("yyyyMMdd", new PersianCulture()) : "");
						long result5 = 0L;
						long.TryParse(s2, out result5);
						if (num5 > result5 && result5 > 0)
						{
							ServiceResult<string> result6 = new ServiceResult<string>
							{
								Data = null,
								Message = Messages.FOMsgErrorUsernameExpired,
								Status = ServiceResultStatus.Error
							};
							num4++;
							return result6;
						}
					}
					if (string.IsNullOrWhiteSpace(text))
					{
						ServiceResult<string> result7 = new ServiceResult<string>
						{
							Data = null,
							Message = string.Format(Messages.FOMsgErrorIsNotEnteredItem, Labels.FOLoginMobile),
							Status = ServiceResultStatus.Error
						};
						num4++;
						return result7;
					}
					if (num4 == 0)
					{
						FOMobspSelectCrmFoSetting_Result fOMobspSelectCrmFoSetting_Result = Enumerable.FirstOrDefault<FOMobspSelectCrmFoSetting_Result>((IEnumerable<FOMobspSelectCrmFoSetting_Result>)cRMSpEntities.FOMobspSelectCrmFoSetting(result, result2, num2, num3));
						if (fOMobspSelectCrmFoSetting_Result != null)
						{
							string text2 = new Random().Next(1000, 9999).ToString();
							string text3 = fOMobspSelectCrmFoSetting_Result.LoginSendOTPSmsBodyPatternFormula ?? "";
							if (string.IsNullOrWhiteSpace(text3))
							{
								text3 = Labels.FOResetPasswordVerifyCode + " : " + text2;
							}
							if (fOMobspSelectCrmFoSetting_Result.SmsSendingIsActive.GetValueOrDefault())
							{
								FoSms foSms = new FoSms();
								FoSmsSendViewModel item = new FoSmsSendViewModel
								{
									CompanyId = fOMobspLoadCompanyLoginInfo_Result.CompanyID,
									CompanyPersonId = ((fOMobspLoadCompanyLoginInfo_Result.CompanyPersonID != 0) ? fOMobspLoadCompanyLoginInfo_Result.CompanyPersonID : null),
									PrsMobile = text,
									SmsText = text3,
									OTPCode = text2,
									sendSmsMode = 2
								};
								bool? isSendVerification = false;
								int? cId2 = num2;
								int? foSettingId2 = num3;
								foSms.SendSms(item, isSendVerification, false, cId2, foSettingId2);
								data = XorCipher.EncryptByPublicKey(text2) + "|#*#|" + text;
								message = "";
								status = ServiceResultStatus.Success;
							}
						}
					}
				}
				else
				{
					data = null;
					message = Messages.CompanyNotFound;
					status = ServiceResultStatus.Error;
				}
			}
			else if (string.IsNullOrWhiteSpace(userName))
			{
				data = "0|" + string.Format(Messages.msgErrorIsNotEnteredItem, Labels.FOLoginUsernameI);
				message = string.Format(Messages.msgErrorIsNotEnteredItem, Labels.FOLoginUsernameI);
				status = ServiceResultStatus.Error;
			}
			else if (string.IsNullOrWhiteSpace(password))
			{
				data = "0|" + string.Format(Messages.msgErrorIsNotEnteredItem, Labels.FOLoginPassword);
				message = string.Format(Messages.msgErrorIsNotEnteredItem, Labels.FOLoginPassword);
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpEntities?.Dispose();
			cRMEntities?.Dispose();
		}
		return new ServiceResult<string>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<string> SendSmsLoginByOTPCode(int loginType, string userName = "", string password = "", string cmpUserName = "", int? ln = null, int? cId = null, int? foSettingId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		BaseInfo baseInfo = new BaseInfo();
		int num = ((result > 0) ? result : result2);
		baseInfo.SetCulture(num);
		CRMEntities cRMEntities = null;
		CRMSpEntities cRMSpEntities = null;
		string data = "";
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			cRMEntities = new CRMEntities();
			cRMSpEntities = new CRMSpEntities();
			int? num2 = FoCenter.GetCurrentCId();
			if (cId.GetValueOrDefault() != 0)
			{
				num2 = cId;
			}
			int? num3 = FoCenter.GetCurrentFoSettingId(num2.GetValueOrDefault());
			if (foSettingId.GetValueOrDefault() != 0)
			{
				num3 = foSettingId;
			}
			if (loginType == 0)
			{
				loginType = 1;
			}
			if (!string.IsNullOrWhiteSpace(userName))
			{
				FOMobspLoadCompanyLoginInfo_Result fOMobspLoadCompanyLoginInfo_Result = Enumerable.FirstOrDefault<FOMobspLoadCompanyLoginInfo_Result>((IEnumerable<FOMobspLoadCompanyLoginInfo_Result>)cRMSpEntities.FOMobspLoadCompanyLoginInfo(0, num, result2, cmpUserName, userName, password, loginType, 0, num2, num3));
				if (fOMobspLoadCompanyLoginInfo_Result != null)
				{
					int num4 = 0;
					long num5 = long.Parse(DateTime.Now.ToString("yyyyMMdd", new PersianCulture()));
					string text = fOMobspLoadCompanyLoginInfo_Result.cmpMobile ?? "";
					int.TryParse(fOMobspLoadCompanyLoginInfo_Result.LoginType.ToString(), out loginType);
					if (loginType == 0)
					{
						loginType = 1;
					}
					if (fOMobspLoadCompanyLoginInfo_Result.CompanyPersonID.GetValueOrDefault() != 0)
					{
						text = fOMobspLoadCompanyLoginInfo_Result.PersonMobile;
					}
					if (fOMobspLoadCompanyLoginInfo_Result.cmpFOLoginExpireDate.HasValue)
					{
						string s = (fOMobspLoadCompanyLoginInfo_Result.cmpFOLoginExpireDate.HasValue ? fOMobspLoadCompanyLoginInfo_Result.cmpFOLoginExpireDate.Value.ToString("yyyyMMdd", new PersianCulture()) : "");
						long result3 = 0L;
						long.TryParse(s, out result3);
						if (num5 > result3 && result3 > 0)
						{
							ServiceResult<string> result4 = new ServiceResult<string>
							{
								Data = null,
								Message = Messages.FOMsgErrorUsernameExpired,
								Status = ServiceResultStatus.Error
							};
							num4++;
							return result4;
						}
					}
					if (loginType == 2 && fOMobspLoadCompanyLoginInfo_Result.prsFOLoginExpireDate.HasValue)
					{
						string s2 = (fOMobspLoadCompanyLoginInfo_Result.prsFOLoginExpireDate.HasValue ? fOMobspLoadCompanyLoginInfo_Result.prsFOLoginExpireDate.Value.ToString("yyyyMMdd", new PersianCulture()) : "");
						long result5 = 0L;
						long.TryParse(s2, out result5);
						if (num5 > result5 && result5 > 0)
						{
							ServiceResult<string> result6 = new ServiceResult<string>
							{
								Data = null,
								Message = Messages.FOMsgErrorUsernameExpired,
								Status = ServiceResultStatus.Error
							};
							num4++;
							return result6;
						}
					}
					if (string.IsNullOrWhiteSpace(text))
					{
						ServiceResult<string> result7 = new ServiceResult<string>
						{
							Data = null,
							Message = string.Format(Messages.FOMsgErrorIsNotEnteredItem, Labels.FOLoginMobile),
							Status = ServiceResultStatus.Error
						};
						num4++;
						return result7;
					}
					if (num4 == 0)
					{
						FOMobspSelectCrmFoSetting_Result fOMobspSelectCrmFoSetting_Result = Enumerable.FirstOrDefault<FOMobspSelectCrmFoSetting_Result>((IEnumerable<FOMobspSelectCrmFoSetting_Result>)cRMSpEntities.FOMobspSelectCrmFoSetting(result, result2, num2, num3));
						if (fOMobspSelectCrmFoSetting_Result != null)
						{
							string text2 = new Random().Next(1000, 9999).ToString();
							string text3 = fOMobspSelectCrmFoSetting_Result.LoginSendOTPSmsBodyPatternFormula ?? "";
							if (string.IsNullOrWhiteSpace(text3))
							{
								text3 = Labels.FOResetPasswordVerifyCode + " : " + text2;
							}
							if (fOMobspSelectCrmFoSetting_Result.SmsSendingIsActive.GetValueOrDefault())
							{
								FoSms foSms = new FoSms();
								FoSmsSendViewModel item = new FoSmsSendViewModel
								{
									CompanyId = fOMobspLoadCompanyLoginInfo_Result.CompanyID,
									CompanyPersonId = ((fOMobspLoadCompanyLoginInfo_Result.CompanyPersonID != 0) ? fOMobspLoadCompanyLoginInfo_Result.CompanyPersonID : null),
									PrsMobile = text,
									SmsText = text3,
									OTPCode = text2,
									sendSmsMode = 2
								};
								bool? isSendVerification = false;
								int? cId2 = num2;
								int? foSettingId2 = num3;
								foSms.SendSms(item, isSendVerification, false, cId2, foSettingId2);
								data = XorCipher.EncryptByPublicKey(text2) + "|#*#|" + text;
								message = "";
								status = ServiceResultStatus.Success;
							}
						}
					}
				}
				else
				{
					data = "0|" + Messages.CompanyNotFound;
					message = Messages.CompanyNotFound;
					status = ServiceResultStatus.Error;
				}
			}
			else if (string.IsNullOrWhiteSpace(userName))
			{
				data = "";
				message = string.Format(Messages.msgErrorIsNotEnteredItem, Labels.FOLoginUsernameI);
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpEntities?.Dispose();
			cRMEntities?.Dispose();
		}
		return new ServiceResult<string>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<FOMobspSelectCompanyOrPersonByMobile_Result> FoLoginByMob(int loginType, string mobile, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		int num = ((result > 0) ? result : result2);
		CRMSpEntities cRMSpEntities = null;
		FOMobspSelectCompanyOrPersonByMobile_Result fOMobspSelectCompanyOrPersonByMobile_Result = new FOMobspSelectCompanyOrPersonByMobile_Result();
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		new BaseInfo().SetCulture(num);
		try
		{
			if (loginType == 0)
			{
				message = string.Format(Messages.ResourceManager.GetString("msgErrorIsNotSpecified", new CultureInfo(num)), Labels.ResourceManager.GetString("FOLoginType", new CultureInfo(num)));
				fOMobspSelectCompanyOrPersonByMobile_Result = null;
				status = ServiceResultStatus.Error;
			}
			else if (string.IsNullOrWhiteSpace(mobile))
			{
				message = string.Format(Messages.ResourceManager.GetString("msgErrorIsNotSpecified", new CultureInfo(num)), Labels.ResourceManager.GetString("FOLoginMobile", new CultureInfo(num)));
				fOMobspSelectCompanyOrPersonByMobile_Result = null;
				status = ServiceResultStatus.Error;
			}
			else
			{
				cRMSpEntities = new CRMSpEntities();
				fOMobspSelectCompanyOrPersonByMobile_Result = Enumerable.FirstOrDefault<FOMobspSelectCompanyOrPersonByMobile_Result>((IEnumerable<FOMobspSelectCompanyOrPersonByMobile_Result>)cRMSpEntities.FOMobspSelectCompanyOrPersonByMobile(loginType, mobile, num, result2));
				if (fOMobspSelectCompanyOrPersonByMobile_Result != null)
				{
					message = Messages.MobMsgSuccessAction;
					status = ServiceResultStatus.Success;
				}
				else
				{
					message = Messages.ResourceManager.GetString("FOMsgErrorNotFound", new CultureInfo(num));
					fOMobspSelectCompanyOrPersonByMobile_Result = null;
					status = ServiceResultStatus.Error;
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<FOMobspSelectCompanyOrPersonByMobile_Result>
		{
			Message = message,
			Data = fOMobspSelectCompanyOrPersonByMobile_Result,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<List<FOMobspSelectCentersWithIds_Result>> GetActiveCenter(string CIds, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		List<FOMobspSelectCentersWithIds_Result> data = null;
		BaseInfo baseInfo = new BaseInfo();
		int num = ((result > 0) ? result : result2);
		baseInfo.SetCulture(num);
		string message;
		ServiceResultStatus status;
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new FoCommon().GetToken(token) != null)
				{
					cRMSpEntities = new CRMSpEntities();
					data = Enumerable.ToList<FOMobspSelectCentersWithIds_Result>((IEnumerable<FOMobspSelectCentersWithIds_Result>)cRMSpEntities.FOMobspSelectCentersWithIds(CIds, ",", num, result2));
					message = Messages.MobMsgSuccessAction;
					status = ServiceResultStatus.Success;
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					data = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				data = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<List<FOMobspSelectCentersWithIds_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}
}
