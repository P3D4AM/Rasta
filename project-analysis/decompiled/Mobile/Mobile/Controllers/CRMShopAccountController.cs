using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using CRM.General.Security;
using CRM.General.Utilities;
using CRM.Resources;
using Elmah;
using GSD.Globalization;
using Mobile.Cache;
using Mobile.Cache.Setting;
using Mobile.Cache.User;
using Mobile.Classes;
using Mobile.Classes.Helper;
using Mobile.DataType;
using Mobile.Models;
using Mobile.ShopAccount;

namespace Mobile.Controllers;

public class CRMShopAccountController : ApiController
{
	[HttpPost]
	public ServiceResult<CmpAuthenticationByMobileModel> CmpAuthenticationByMobNum(CmpAuthenticationByMobileModel model)
	{
		CmpAuthenticationByMobileModel cmpAuthenticationByMobileModel = new CmpAuthenticationByMobileModel();
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		CRMSpEntities cRMSpEntities = null;
		try
		{
			int result = 1065;
			if (model.LangId.HasValue)
			{
				int.TryParse(model.LangId.ToString(), out result);
			}
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			cRMSpEntities = new CRMSpEntities();
			BaseInfo baseInfo = new BaseInfo();
			int culture = ((result > 0) ? result : result2);
			baseInfo.SetCulture(culture);
			MobspSelectCompanyByCmpMobile_Result mobspSelectCompanyByCmpMobile_Result = Enumerable.FirstOrDefault<MobspSelectCompanyByCmpMobile_Result>((IEnumerable<MobspSelectCompanyByCmpMobile_Result>)cRMSpEntities.MobspSelectCompanyByCmpMobile(model.MobileNumber, result, result2));
			if (mobspSelectCompanyByCmpMobile_Result != null)
			{
				bool flag = false;
				bool result3 = false;
				bool.TryParse(mobspSelectCompanyByCmpMobile_Result.cmpCRMShopIsActive.ToString(), out result3);
				if (result3)
				{
					flag = true;
				}
				else
				{
					int maxCountCrmShop = Mobile.Classes.Configuration.MaxCountCrmShop;
					if (Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMSpEntities.MobspReturnCmpCRMShopIsActiveCnt()).GetValueOrDefault() + 1 > maxCountCrmShop)
					{
						flag = false;
						message = Messages.MobMsgNotLoginToCRMShopMoreThanMaxCount;
						cmpAuthenticationByMobileModel = null;
						status = ServiceResultStatus.Fail;
					}
					else
					{
						flag = true;
					}
				}
				if (flag)
				{
					if (!result3)
					{
						DateTime now = DateTime.Now;
						DateTime value = now;
						string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
						short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
						string appType = Mobile.Classes.Configuration.AppType;
						short value3 = short.Parse(Financial.Get().Id.ToString());
						int userId = model.UserId;
						cRMSpEntities.MobspUpdateCompanyCRMShopActive(mobspSelectCompanyByCmpMobile_Result.CompanyId, true, value, userId, value, registerDatePersian, value3, value2, appType);
					}
					string text = "";
					if (base.Request.Headers.Contains("extra"))
					{
						text = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("extra"));
					}
					RandomText randomText = new RandomText();
					string getString = randomText.CreateRandomCode(5, WithNumber: true).Replace(" ", "").Trim() + "|" + model.UserId + "|" + randomText.CreateRandomCode(5, WithNumber: true).Replace(" ", "").Trim() + "|" + model.UserRollId + "|" + randomText.CreateRandomCode(5, WithNumber: true).Replace(" ", "").Trim() + "|" + text + "|" + randomText.CreateRandomCode(5, WithNumber: true).Replace(" ", "").Trim() + "|" + DateTime.Now.ToString("yyyyMMdd-HHmmss", new PersianCulture()) + "|" + randomText.CreateRandomCode(5, WithNumber: true).Replace(" ", "").Trim();
					cmpAuthenticationByMobileModel.Token = CodeDecode.Codding(getString);
					Info.Update(model.UserId, false);
					Permissions.Update(model.UserId);
					Manager.UpdateAllSettingCach();
					MobspCheckDuplicateCmpMobile_Result company = new MobspCheckDuplicateCmpMobile_Result
					{
						CompanyId = mobspSelectCompanyByCmpMobile_Result.CompanyId,
						cmpNumber = mobspSelectCompanyByCmpMobile_Result.cmpNumber,
						CompanyName = mobspSelectCompanyByCmpMobile_Result.CompanyName,
						cmpMainPersonId = mobspSelectCompanyByCmpMobile_Result.cmpMainPersonId,
						cmpCIds = mobspSelectCompanyByCmpMobile_Result.cmpCIds,
						cmpLastCId = mobspSelectCompanyByCmpMobile_Result.cmpLastCId
					};
					cmpAuthenticationByMobileModel.VBCenter = VersionBuyer.Center;
					message = Messages.MobMsgSuccessAction;
					cmpAuthenticationByMobileModel.Company = company;
					status = ServiceResultStatus.Success;
				}
			}
			else
			{
				message = Messages.MobMsgNotFountCmpMobile;
				cmpAuthenticationByMobileModel = null;
				status = ServiceResultStatus.Fail;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			cmpAuthenticationByMobileModel = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<CmpAuthenticationByMobileModel>
		{
			Message = message,
			Data = cmpAuthenticationByMobileModel,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<ShpLoginResult> ShopLogin(ShpLoginViewModel login)
	{
		ShpLoginResult shpLoginResult = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		CRMEntities cRMEntities = null;
		CRMSpEntities cRMSpEntities = null;
		int result = 1065;
		if (login.LangId.HasValue)
		{
			int.TryParse(login.LangId.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		BaseInfo baseInfo = new BaseInfo();
		result = ((login.LangId.GetValueOrDefault() > 0) ? login.LangId.GetValueOrDefault() : 1065);
		int num = ((result > 0) ? result : result2);
		baseInfo.SetCulture(num);
		try
		{
			string extra = "";
			if (base.Request.Headers.Contains("extra"))
			{
				extra = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("extra"));
			}
			if (new FoCommon().CheckExtra(extra))
			{
				cRMEntities = new CRMEntities();
				cRMSpEntities = new CRMSpEntities();
				int? currentCId = FoCenter.GetCurrentCId();
				_ = login.CenterId;
				currentCId = login.CenterId;
				int? currentFoSettingId = FoCenter.GetCurrentFoSettingId(currentCId.GetValueOrDefault());
				if (currentFoSettingId.GetValueOrDefault() != 0)
				{
					Enumerable.FirstOrDefault<MobspSelectCrmFoSetting_Result>((IEnumerable<MobspSelectCrmFoSetting_Result>)cRMEntities.MobspSelectCrmFoSetting(num, result2, currentCId.GetValueOrDefault(), currentFoSettingId.GetValueOrDefault()));
				}
				int num2 = int.Parse(DateTime.Now.ToString("yyyyMMdd", new PersianCulture()));
				string value = ApplicationSettings.GetValue("yevNGNeetPc=");
				if (!string.IsNullOrEmpty(value))
				{
					try
					{
						value = CodeDecode.DeCodding(value);
						value = value.Trim().Replace("/", "").Replace("-", "")
							.Replace("\\", "")
							.Replace(" ", "")
							.Replace("_", "");
						int num3 = int.Parse(value);
						if (num2 > num3)
						{
							return new ServiceResult<ShpLoginResult>
							{
								Data = null,
								Message = Messages.FOMsgErrorExpDate,
								Status = ServiceResultStatus.Error
							};
						}
					}
					catch (Exception e)
					{
						ErrorSignal.FromCurrentContext().Raise(e);
					}
				}
				ShpMobspLoadCompanyLoginInfo_Result shpMobspLoadCompanyLoginInfo_Result = Enumerable.FirstOrDefault<ShpMobspLoadCompanyLoginInfo_Result>((IEnumerable<ShpMobspLoadCompanyLoginInfo_Result>)cRMSpEntities.ShpMobspLoadCompanyLoginInfo(login.CmpId, cmpUserName: login.CmpUserName, password: login.password, userName: login.username, loginType: login.LoginType, companyPersonId: login.PrsId, languageID: num, defaultLanguageID: result2, centerId: login.CenterId, foSettingId: login.FoSettingId));
				if (shpMobspLoadCompanyLoginInfo_Result != null)
				{
					shpLoginResult = new ShpLoginResult();
					long num4 = long.Parse(DateTime.Now.ToString("yyyyMMdd", new PersianCulture()));
					string text = shpMobspLoadCompanyLoginInfo_Result.cmpMobile ?? "";
					int result3 = 0;
					int.TryParse(shpMobspLoadCompanyLoginInfo_Result.LoginType.ToString(), out result3);
					if (result3 == 0)
					{
						result3 = 1;
					}
					if (shpMobspLoadCompanyLoginInfo_Result.CompanyPersonID.GetValueOrDefault() != 0)
					{
						shpLoginResult.cmpMobile = shpMobspLoadCompanyLoginInfo_Result.PersonMobile ?? text;
					}
					if (shpMobspLoadCompanyLoginInfo_Result.cmpFOLoginExpireDate.HasValue)
					{
						string s = (shpMobspLoadCompanyLoginInfo_Result.cmpFOLoginExpireDate.HasValue ? shpMobspLoadCompanyLoginInfo_Result.cmpFOLoginExpireDate.Value.ToString("yyyyMMdd", new PersianCulture()) : "");
						long result4 = 0L;
						long.TryParse(s, out result4);
						if (num4 > result4 && result4 > 0)
						{
							return new ServiceResult<ShpLoginResult>
							{
								Message = Messages.FOMsgErrorUsernameExpired,
								Data = null,
								Status = ServiceResultStatus.Error
							};
						}
					}
					if (result3 == 2)
					{
						if (!shpMobspLoadCompanyLoginInfo_Result.prsFOIsActive.GetValueOrDefault())
						{
							ServiceResult<ShpLoginResult> serviceResult = new ServiceResult<ShpLoginResult>();
							message = (serviceResult.Message = Messages.msgErrorHaveNotAccessUseFoShp);
							serviceResult.Data = null;
							serviceResult.Status = ServiceResultStatus.Error;
							return serviceResult;
						}
						if (shpMobspLoadCompanyLoginInfo_Result.prsFOLoginExpireDate.HasValue)
						{
							string s2 = (shpMobspLoadCompanyLoginInfo_Result.prsFOLoginExpireDate.HasValue ? shpMobspLoadCompanyLoginInfo_Result.prsFOLoginExpireDate.Value.ToString("yyyyMMdd", new PersianCulture()) : "");
							long result5 = 0L;
							long.TryParse(s2, out result5);
							if (num4 > result5 && result5 > 0)
							{
								return new ServiceResult<ShpLoginResult>
								{
									Message = Messages.FOMsgErrorUsernameExpired,
									Data = null,
									Status = ServiceResultStatus.Error
								};
							}
						}
					}
					shpLoginResult.LoginType = result3;
					string text2 = "";
					if (base.Request.Headers.Contains("extra"))
					{
						text2 = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("extra"));
					}
					RandomText randomText = new RandomText();
					string getString = randomText.CreateRandomCode(5, WithNumber: true).Replace(" ", "").Trim() + "|" + login.UserId + "|" + randomText.CreateRandomCode(5, WithNumber: true).Replace(" ", "").Trim() + "|" + login.UserRollId + "|" + randomText.CreateRandomCode(5, WithNumber: true).Replace(" ", "").Trim() + "|" + text2 + "|" + randomText.CreateRandomCode(5, WithNumber: true).Replace(" ", "").Trim() + "|" + DateTime.Now.ToString("yyyyMMdd-HHmmss", new PersianCulture()) + "|" + randomText.CreateRandomCode(5, WithNumber: true).Replace(" ", "").Trim();
					shpLoginResult.Token = CodeDecode.Codding(getString);
					shpLoginResult.CompanyID = shpMobspLoadCompanyLoginInfo_Result.CompanyID;
					shpLoginResult.cmpNumber = shpMobspLoadCompanyLoginInfo_Result.cmpNumber;
					shpLoginResult.CompanyName = shpMobspLoadCompanyLoginInfo_Result.CompanyName;
					if (result3 == 2)
					{
						shpLoginResult.cmpMainPersonId = shpMobspLoadCompanyLoginInfo_Result.CompanyPersonID.GetValueOrDefault();
					}
					else
					{
						shpLoginResult.cmpMainPersonId = shpMobspLoadCompanyLoginInfo_Result.cmpMainPersonId.GetValueOrDefault();
					}
					shpLoginResult.cmpPersonName = shpMobspLoadCompanyLoginInfo_Result.PersonName;
					shpLoginResult.cmpPrsMobile = shpMobspLoadCompanyLoginInfo_Result.PrsMobile ?? "";
					shpLoginResult.cmpFOIsActive = shpMobspLoadCompanyLoginInfo_Result.cmpFOIsActive.GetValueOrDefault();
					shpLoginResult.LastCId = shpMobspLoadCompanyLoginInfo_Result.LastCId;
					shpLoginResult.FoActiveCIds = shpMobspLoadCompanyLoginInfo_Result.FoActiveCIds;
					shpLoginResult.VBCenter = VersionBuyer.Center;
					shpLoginResult.cmpCIds = shpMobspLoadCompanyLoginInfo_Result.cmpCIds;
					shpLoginResult.prsCIds = shpMobspLoadCompanyLoginInfo_Result.prsCIds;
					shpLoginResult.prsFoInfo = shpMobspLoadCompanyLoginInfo_Result.prsFOInfo;
					shpLoginResult.foShpInfo = shpMobspLoadCompanyLoginInfo_Result.FoShpInfo;
					shpLoginResult.prsShpIsActive = shpMobspLoadCompanyLoginInfo_Result.prsShpIsActive;
					shpLoginResult.cmpShpIsActive = shpMobspLoadCompanyLoginInfo_Result.cmpShpIsActive;
					shpLoginResult.cmpShpLoginExpireDate = shpMobspLoadCompanyLoginInfo_Result.cmpShpLoginExpireDate;
					shpLoginResult.prsShpLoginExpireDate = shpMobspLoadCompanyLoginInfo_Result.prsShpLoginExpireDate;
					message = Messages.MobMsgSuccessAction;
					status = ServiceResultStatus.Success;
				}
			}
		}
		catch (Exception e2)
		{
			message = Messages.MobMsgErrorDoneOperation;
			shpLoginResult = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		finally
		{
			cRMEntities?.Dispose();
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<ShpLoginResult>
		{
			Data = shpLoginResult,
			Message = message,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<string> SenLoginByOTPCode(int loginType, string userName = "", string password = "", string cmpUserName = "", int cId = 0, int? ln = null)
	{
		string data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		CRMEntities cRMEntities = null;
		CRMSpEntities cRMSpEntities = null;
		try
		{
			cRMEntities = new CRMEntities();
			cRMSpEntities = new CRMSpEntities();
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			int num = 1065;
			BaseInfo baseInfo = new BaseInfo();
			num = ((ln.GetValueOrDefault() > 0) ? ln.GetValueOrDefault() : 1065);
			int num2 = ((num > 0) ? num : result);
			baseInfo.SetCulture(num2);
			int? num3 = FoCenter.GetCurrentCId();
			if (cId != 0)
			{
				num3 = cId;
			}
			int? currentFoSettingId = FoCenter.GetCurrentFoSettingId(num3.GetValueOrDefault());
			if (loginType == 0)
			{
				loginType = 1;
			}
			if (!string.IsNullOrWhiteSpace(userName))
			{
				ShpMobspLoadCompanyLoginInfo_Result shpMobspLoadCompanyLoginInfo_Result = Enumerable.FirstOrDefault<ShpMobspLoadCompanyLoginInfo_Result>((IEnumerable<ShpMobspLoadCompanyLoginInfo_Result>)cRMSpEntities.ShpMobspLoadCompanyLoginInfo(0, num2, result, cmpUserName, userName, password, loginType, 0, num3, currentFoSettingId));
				if (shpMobspLoadCompanyLoginInfo_Result != null)
				{
					int num4 = 0;
					long num5 = long.Parse(DateTime.Now.ToString("yyyyMMdd", new PersianCulture()));
					string text = shpMobspLoadCompanyLoginInfo_Result.cmpMobile ?? "";
					int.TryParse(shpMobspLoadCompanyLoginInfo_Result.LoginType.ToString(), out loginType);
					if (loginType == 0)
					{
						loginType = 1;
					}
					if (shpMobspLoadCompanyLoginInfo_Result.CompanyPersonID.GetValueOrDefault() != 0)
					{
						text = shpMobspLoadCompanyLoginInfo_Result.PersonMobile;
					}
					if (shpMobspLoadCompanyLoginInfo_Result.cmpFOLoginExpireDate.HasValue)
					{
						string s = (shpMobspLoadCompanyLoginInfo_Result.cmpFOLoginExpireDate.HasValue ? shpMobspLoadCompanyLoginInfo_Result.cmpFOLoginExpireDate.Value.ToString("yyyyMMdd", new PersianCulture()) : "");
						long result2 = 0L;
						long.TryParse(s, out result2);
						if (num5 > result2 && result2 > 0)
						{
							ServiceResult<string> result3 = new ServiceResult<string>
							{
								Data = null,
								Message = Messages.FOMsgErrorUsernameExpired,
								Status = ServiceResultStatus.Error
							};
							num4++;
							return result3;
						}
					}
					if (loginType == 2 && shpMobspLoadCompanyLoginInfo_Result.prsFOLoginExpireDate.HasValue)
					{
						string s2 = (shpMobspLoadCompanyLoginInfo_Result.prsFOLoginExpireDate.HasValue ? shpMobspLoadCompanyLoginInfo_Result.prsFOLoginExpireDate.Value.ToString("yyyyMMdd", new PersianCulture()) : "");
						long result4 = 0L;
						long.TryParse(s2, out result4);
						if (num5 > result4 && result4 > 0)
						{
							ServiceResult<string> result5 = new ServiceResult<string>
							{
								Data = null,
								Message = Messages.FOMsgErrorUsernameExpired,
								Status = ServiceResultStatus.Error
							};
							num4++;
							return result5;
						}
					}
					if (string.IsNullOrWhiteSpace(text))
					{
						ServiceResult<string> result6 = new ServiceResult<string>
						{
							Data = null,
							Message = string.Format(Messages.FOMsgErrorIsNotEnteredItem, Labels.FOLoginMobile),
							Status = ServiceResultStatus.Error
						};
						num4++;
						return result6;
					}
					if (num4 == 0)
					{
						MobspSelectCrmFoSetting_Result mobspSelectCrmFoSetting_Result = null;
						if (currentFoSettingId.GetValueOrDefault() != 0)
						{
							mobspSelectCrmFoSetting_Result = Enumerable.FirstOrDefault<MobspSelectCrmFoSetting_Result>((IEnumerable<MobspSelectCrmFoSetting_Result>)cRMEntities.MobspSelectCrmFoSetting(num2, result, num3.GetValueOrDefault(), currentFoSettingId.GetValueOrDefault()));
						}
						if (mobspSelectCrmFoSetting_Result != null)
						{
							string text2 = new Random().Next(10000, 99999).ToString();
							string text3 = mobspSelectCrmFoSetting_Result.LoginByOtpSmsBodyPatternFormula ?? "";
							if (string.IsNullOrWhiteSpace(text3))
							{
								text3 = Labels.FOOneTimePassword + " : " + text2;
							}
							if (mobspSelectCrmFoSetting_Result.SmsSendingIsActive.GetValueOrDefault())
							{
								FoSms foSms = new FoSms();
								FoSmsSendViewModel item = new FoSmsSendViewModel
								{
									CompanyId = shpMobspLoadCompanyLoginInfo_Result.CompanyID,
									CompanyPersonId = ((shpMobspLoadCompanyLoginInfo_Result.CompanyPersonID != 0) ? shpMobspLoadCompanyLoginInfo_Result.CompanyPersonID : null),
									PrsMobile = text,
									SmsText = text3,
									OTPCode = text2,
									sendSmsMode = 2,
									CId = num3
								};
								foSms.SendSms(item, false, false);
								data = XorCipher.EncryptByPublicKey(text2);
								message = null;
								status = ServiceResultStatus.Success;
							}
						}
					}
				}
				else
				{
					data = "";
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
			cRMEntities?.Dispose();
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<string>
		{
			Data = data,
			Message = message,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<string> SendLoginOTPCode(int loginType, string userName = "", string password = "", string cmpUserName = "", int cId = 0, int? ln = null)
	{
		string data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		CRMEntities cRMEntities = null;
		CRMSpEntities cRMSpEntities = null;
		try
		{
			cRMEntities = new CRMEntities();
			cRMSpEntities = new CRMSpEntities();
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			int num = 1065;
			BaseInfo baseInfo = new BaseInfo();
			num = ((ln.GetValueOrDefault() > 0) ? ln.GetValueOrDefault() : 1065);
			int num2 = ((num > 0) ? num : result);
			baseInfo.SetCulture(num2);
			int? num3 = FoCenter.GetCurrentCId();
			if (cId != 0)
			{
				num3 = cId;
			}
			int? currentFoSettingId = FoCenter.GetCurrentFoSettingId(num3.GetValueOrDefault());
			if (loginType == 0)
			{
				loginType = 1;
			}
			if (!string.IsNullOrWhiteSpace(userName) && !string.IsNullOrWhiteSpace(password))
			{
				ShpMobspLoadCompanyLoginInfo_Result shpMobspLoadCompanyLoginInfo_Result = Enumerable.FirstOrDefault<ShpMobspLoadCompanyLoginInfo_Result>((IEnumerable<ShpMobspLoadCompanyLoginInfo_Result>)cRMSpEntities.ShpMobspLoadCompanyLoginInfo(0, num2, result, cmpUserName, userName, password, loginType, 0, num3, currentFoSettingId));
				if (shpMobspLoadCompanyLoginInfo_Result != null)
				{
					int num4 = 0;
					long num5 = long.Parse(DateTime.Now.ToString("yyyyMMdd", new PersianCulture()));
					string text = shpMobspLoadCompanyLoginInfo_Result.cmpMobile ?? "";
					int.TryParse(shpMobspLoadCompanyLoginInfo_Result.LoginType.ToString(), out loginType);
					if (loginType == 0)
					{
						loginType = 1;
					}
					if (shpMobspLoadCompanyLoginInfo_Result.CompanyPersonID.GetValueOrDefault() != 0)
					{
						text = shpMobspLoadCompanyLoginInfo_Result.PersonMobile;
					}
					if (shpMobspLoadCompanyLoginInfo_Result.cmpFOLoginExpireDate.HasValue)
					{
						string s = (shpMobspLoadCompanyLoginInfo_Result.cmpFOLoginExpireDate.HasValue ? shpMobspLoadCompanyLoginInfo_Result.cmpFOLoginExpireDate.Value.ToString("yyyyMMdd", new PersianCulture()) : "");
						long result2 = 0L;
						long.TryParse(s, out result2);
						if (num5 > result2 && result2 > 0)
						{
							ServiceResult<string> result3 = new ServiceResult<string>
							{
								Data = null,
								Message = Messages.FOMsgErrorUsernameExpired,
								Status = ServiceResultStatus.Error
							};
							num4++;
							return result3;
						}
					}
					if (loginType == 2 && shpMobspLoadCompanyLoginInfo_Result.prsFOLoginExpireDate.HasValue)
					{
						string s2 = (shpMobspLoadCompanyLoginInfo_Result.prsFOLoginExpireDate.HasValue ? shpMobspLoadCompanyLoginInfo_Result.prsFOLoginExpireDate.Value.ToString("yyyyMMdd", new PersianCulture()) : "");
						long result4 = 0L;
						long.TryParse(s2, out result4);
						if (num5 > result4 && result4 > 0)
						{
							ServiceResult<string> result5 = new ServiceResult<string>
							{
								Data = null,
								Message = Messages.FOMsgErrorUsernameExpired,
								Status = ServiceResultStatus.Error
							};
							num4++;
							return result5;
						}
					}
					if (string.IsNullOrWhiteSpace(text))
					{
						ServiceResult<string> result6 = new ServiceResult<string>
						{
							Data = null,
							Message = string.Format(Messages.FOMsgErrorIsNotEnteredItem, Labels.FOLoginMobile),
							Status = ServiceResultStatus.Error
						};
						num4++;
						return result6;
					}
					if (num4 == 0)
					{
						MobspSelectCrmFoSetting_Result mobspSelectCrmFoSetting_Result = null;
						if (currentFoSettingId.GetValueOrDefault() != 0)
						{
							mobspSelectCrmFoSetting_Result = Enumerable.FirstOrDefault<MobspSelectCrmFoSetting_Result>((IEnumerable<MobspSelectCrmFoSetting_Result>)cRMEntities.MobspSelectCrmFoSetting(num2, result, num3.GetValueOrDefault(), currentFoSettingId.GetValueOrDefault()));
						}
						if (mobspSelectCrmFoSetting_Result != null)
						{
							string text2 = new Random().Next(10000, 99999).ToString();
							string text3 = mobspSelectCrmFoSetting_Result.LoginSendOTPSmsBodyPatternFormula ?? "";
							if (string.IsNullOrWhiteSpace(text3))
							{
								text3 = Labels.FOOneTimePassword + " : " + text2;
							}
							if (mobspSelectCrmFoSetting_Result.SmsSendingIsActive.GetValueOrDefault())
							{
								FoSms foSms = new FoSms();
								FoSmsSendViewModel item = new FoSmsSendViewModel
								{
									CompanyId = shpMobspLoadCompanyLoginInfo_Result.CompanyID,
									CompanyPersonId = ((shpMobspLoadCompanyLoginInfo_Result.CompanyPersonID != 0) ? shpMobspLoadCompanyLoginInfo_Result.CompanyPersonID : null),
									PrsMobile = text,
									SmsText = text3,
									OTPCode = text2,
									sendSmsMode = 2,
									CId = num3
								};
								foSms.SendSms(item, false, false);
								data = XorCipher.EncryptByPublicKey(text2);
								message = null;
								status = ServiceResultStatus.Success;
							}
						}
					}
				}
				else
				{
					data = "";
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
			else if (string.IsNullOrWhiteSpace(password))
			{
				data = "";
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
			cRMEntities?.Dispose();
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<string>
		{
			Data = data,
			Message = message,
			Status = status
		};
	}
}
