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
using Mobile.Models.ViewModel.System;

namespace Mobile.Controllers;

public class SystemController : ApiController
{
	[HttpPost]
	public ServiceResult<InstallResult> Install(InstallParameters parameters)
	{
		InstallResult installResult = new InstallResult();
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		CRMEntities cRMEntities = null;
		BaseInfo baseInfo = new BaseInfo();
		int num = 1065;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		int culture = ((result > 0) ? result : num);
		baseInfo.SetCulture(culture);
		try
		{
			cRMEntities = new CRMEntities();
			if (((parameters.registerCode != null) & (parameters.registerCode != "")) && ((parameters.imeiCode != null) & (parameters.imeiCode != "")))
			{
				string registerCode = CodeDecode.Codding(parameters.registerCode);
				RandomText randomText = new RandomText();
				string extraCode = EncryptDecrypt.Encrypting(EncryptDecrypt.Encrypting(EncryptDecrypt.Encrypting(randomText.CreateRandomCode(5, WithNumber: true).Replace(" ", "").Trim()) + "|" + EncryptDecrypt.Encrypting(parameters.imeiCode) + "|" + EncryptDecrypt.Encrypting("ADBF") + EncryptDecrypt.Encrypting(DateTime.Now.ToString("yyyyMMdd-HHmmss", new PersianCulture()))));
				MobspCheckRegisterCode_Result mobspCheckRegisterCode_Result = Enumerable.FirstOrDefault<MobspCheckRegisterCode_Result>((IEnumerable<MobspCheckRegisterCode_Result>)cRMEntities.MobspCheckRegisterCode(registerCode, extraCode, parameters.imeiCode, parameters.devTypeId, parameters.CurrentVersion));
				if (mobspCheckRegisterCode_Result != null)
				{
					if (mobspCheckRegisterCode_Result.ImeiCode == parameters.imeiCode)
					{
						installResult.Download = mobspCheckRegisterCode_Result.DownloadURL;
						installResult.ExtraCode = mobspCheckRegisterCode_Result.ExtraCode;
						installResult.WcfUrl = mobspCheckRegisterCode_Result.WcfURL;
						installResult.CompanyName = mobspCheckRegisterCode_Result.cmp;
						installResult.CompanyId = mobspCheckRegisterCode_Result.CompanyID;
						installResult.CompanyPersonId = mobspCheckRegisterCode_Result.CompanyPersonID;
						message = "";
						status = ServiceResultStatus.Success;
					}
					else
					{
						installResult = null;
						message = Messages.MobMsgErrorCodeInvalidForMobile;
						status = ServiceResultStatus.Fail;
					}
				}
				else
				{
					installResult = null;
					message = Messages.MobMsgErrorCodeInvalid;
					status = ServiceResultStatus.Fail;
				}
			}
			else
			{
				installResult = null;
				message = Messages.MobMsgErrorParamHaveNotCorrectlyInitialized;
				status = ServiceResultStatus.Fail;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			installResult = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<InstallResult>
		{
			Message = message,
			Data = installResult,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<GetWcfResult> GetWcfUrl(GetWcfParameters parameters)
	{
		GetWcfResult getWcfResult = new GetWcfResult();
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		CRMEntities cRMEntities = null;
		BaseInfo baseInfo = new BaseInfo();
		int num = 1065;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		int culture = ((result > 0) ? result : num);
		baseInfo.SetCulture(culture);
		try
		{
			cRMEntities = new CRMEntities();
			if (((parameters.statusDownload != null) & (parameters.statusDownload != "")) && ((parameters.extraCode != null) & (parameters.extraCode != "")))
			{
				if (parameters.statusDownload == "Ok")
				{
					MobspCheckExtraCode_Result mobspCheckExtraCode_Result = Enumerable.FirstOrDefault<MobspCheckExtraCode_Result>((IEnumerable<MobspCheckExtraCode_Result>)cRMEntities.MobspCheckExtraCode(parameters.extraCode.ToLower()));
					if (mobspCheckExtraCode_Result != null)
					{
						getWcfResult.WcfUrl = mobspCheckExtraCode_Result.WcfURL;
						getWcfResult.ExtraCode = mobspCheckExtraCode_Result.ExtraCode;
						message = "";
						status = ServiceResultStatus.Success;
					}
					else
					{
						getWcfResult = null;
						message = Messages.MobMsgErrorLackAccessDevice;
						status = ServiceResultStatus.Fail;
					}
				}
				else
				{
					getWcfResult = null;
					message = Messages.MobMsgErrorDownloadAppHasNotCompleted;
					status = ServiceResultStatus.Fail;
				}
			}
			else
			{
				getWcfResult = null;
				message = Messages.MobMsgErrorParamHaveNotCorrectlyInitialized;
				status = ServiceResultStatus.Fail;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			getWcfResult = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<GetWcfResult>
		{
			Message = message,
			Data = getWcfResult,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<MobspSelectUserRollPermissionByForm_Result>> CheckPermissions(string formName, int? cId = null)
	{
		CRMEntities cRMEntities = null;
		List<MobspSelectUserRollPermissionByForm_Result> data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int num = 1065;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		int culture = ((result > 0) ? result : num);
		baseInfo.SetCulture(culture);
		try
		{
			if (!string.IsNullOrEmpty(formName))
			{
				cRMEntities = new CRMEntities();
				data = Enumerable.ToList<MobspSelectUserRollPermissionByForm_Result>((IEnumerable<MobspSelectUserRollPermissionByForm_Result>)cRMEntities.MobspSelectUserRollPermissionByForm(UserLogin.CurrentUser.UserId, formName, cId));
				message = "";
				status = ServiceResultStatus.Success;
			}
			else
			{
				data = null;
				message = Messages.MobMsgErrorParamHaveNotCorrectlyInitialized;
				status = ServiceResultStatus.Fail;
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
		return new ServiceResult<List<MobspSelectUserRollPermissionByForm_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<bool> CheckConnection()
	{
		bool flag = false;
		string text = "";
		ServiceResultStatus serviceResultStatus = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int num = 1065;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		int culture = ((result > 0) ? result : num);
		baseInfo.SetCulture(culture);
		try
		{
			flag = true;
			text = "";
			serviceResultStatus = ServiceResultStatus.Success;
		}
		catch (Exception e)
		{
			text = Messages.MobMsgErrorDoneOperation;
			flag = false;
			serviceResultStatus = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return new ServiceResult<bool>
		{
			Message = text,
			Data = flag,
			Status = serviceResultStatus
		};
	}

	[HttpPost]
	public ServiceResult<bool> CheckVersion(string apiVersion)
	{
		bool data = false;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int num = 1065;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		int culture = ((result > 0) ? result : num);
		baseInfo.SetCulture(culture);
		try
		{
			string extra = "";
			if (base.Request.Headers.Contains("extra"))
			{
				extra = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("extra"));
			}
			if (new Common().CheckExtra(extra))
			{
				CheckVersionViewModel checkVersionViewModel = new Common().CheckVersion(apiVersion, "");
				if (checkVersionViewModel != null)
				{
					if (!checkVersionViewModel.Status && !string.IsNullOrEmpty(checkVersionViewModel.Message))
					{
						return new ServiceResult<bool>
						{
							Message = checkVersionViewModel.Message,
							Data = checkVersionViewModel.Status,
							Status = ServiceResultStatus.Fail
						};
					}
					data = true;
					message = "";
					status = ServiceResultStatus.Success;
				}
			}
			else
			{
				message = Messages.MobMsgErrorLackAccessDevice;
				data = false;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = false;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return new ServiceResult<bool>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<bool> CheckVersionAppMob(string appVersion)
	{
		bool flag = false;
		string text = "";
		ServiceResultStatus serviceResultStatus = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int num = 1065;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		int culture = ((result > 0) ? result : num);
		baseInfo.SetCulture(culture);
		try
		{
			string extra = "";
			if (base.Request.Headers.Contains("extra"))
			{
				extra = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("extra"));
			}
			if (new Common().CheckExtra(extra))
			{
				if (string.IsNullOrEmpty(appVersion))
				{
					return new ServiceResult<bool>
					{
						Message = Messages.MobMsgErrorAppMobVersion,
						Data = false,
						Status = ServiceResultStatus.Fail
					};
				}
				if (VersionConfig.CurrentVerAppMob != appVersion)
				{
					return new ServiceResult<bool>
					{
						Message = Messages.MobMsgErrorConflictsAppMobVersion.Replace("{0}", VersionConfig.CurrentVerAppMob),
						Data = false,
						Status = ServiceResultStatus.Fail
					};
				}
				flag = true;
				text = "";
				serviceResultStatus = ServiceResultStatus.Success;
			}
			else
			{
				text = Messages.MobMsgErrorLackAccessDevice;
				flag = false;
				serviceResultStatus = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			text = Messages.MobMsgErrorDoneOperation;
			flag = false;
			serviceResultStatus = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return new ServiceResult<bool>
		{
			Message = text,
			Data = flag,
			Status = serviceResultStatus
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<bool> RefreshCache()
	{
		CRMEntities cRMEntities = null;
		bool data = false;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int num = 1065;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		int culture = ((result > 0) ? result : num);
		baseInfo.SetCulture(culture);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					Info.Update(token2.userId, true);
					Permissions.Update(token2.userId);
					Manager.UpdateAllSettingCach();
					data = true;
					message = "";
					status = ServiceResultStatus.Success;
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					data = false;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				data = false;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = false;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
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
	public ServiceResult<MobspSelectMobSetting_Result> SelectMobSetting(string appName)
	{
		CRMEntities cRMEntities = new CRMEntities();
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		MobspSelectMobSetting_Result data;
		try
		{
			MobspSelectMobSetting_Result mobspSelectMobSetting_Result = Enumerable.FirstOrDefault<MobspSelectMobSetting_Result>((IEnumerable<MobspSelectMobSetting_Result>)cRMEntities.MobspSelectMobSetting());
			message = Messages.msgOperationCompleted;
			data = mobspSelectMobSetting_Result;
			status = ServiceResultStatus.Success;
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
		return new ServiceResult<MobspSelectMobSetting_Result>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<MobParsServiceAppSettingViewModel> SelectParsServiceAppSetting(int? ln = null)
	{
		MobParsServiceAppSettingViewModel data = new MobParsServiceAppSettingViewModel();
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		CRMEntities cRMEntities = null;
		BaseInfo baseInfo = new BaseInfo();
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		int culture = ((result2 == result) ? result2 : result);
		baseInfo.SetCulture(culture);
		try
		{
			cRMEntities = new CRMEntities();
			MobspSelectParsServiceAppSetting_Result mobspSelectParsServiceAppSetting_Result = Enumerable.FirstOrDefault<MobspSelectParsServiceAppSetting_Result>((IEnumerable<MobspSelectParsServiceAppSetting_Result>)cRMEntities.MobspSelectParsServiceAppSetting());
			if (mobspSelectParsServiceAppSetting_Result != null)
			{
				data = new MobParsServiceAppSettingViewModel
				{
					LoginUserId = mobspSelectParsServiceAppSetting_Result.LoginUserId.GetValueOrDefault(-1),
					LoginPrjTitle = (mobspSelectParsServiceAppSetting_Result.LoginPrjTitle ?? ""),
					LoginPrjCnvsStatusGroupId = mobspSelectParsServiceAppSetting_Result.LoginPrjCnvsStatusGroupId.GetValueOrDefault(-1),
					LoginCnvsTopicId = mobspSelectParsServiceAppSetting_Result.LoginCnvsTopicId.GetValueOrDefault(-1),
					LoginCnvsReferUserId = mobspSelectParsServiceAppSetting_Result.LoginCnvsReferUserId.GetValueOrDefault(-1),
					LoginCnvsStatusId = mobspSelectParsServiceAppSetting_Result.LoginCnvsStatusId.GetValueOrDefault(-1),
					CallPrjTitle = (mobspSelectParsServiceAppSetting_Result.CallPrjTitle ?? ""),
					CallPrjCnvsStatusGroupId = mobspSelectParsServiceAppSetting_Result.CallPrjCnvsStatusGroupId.GetValueOrDefault(-1),
					CallCnvsTopicId = mobspSelectParsServiceAppSetting_Result.CallCnvsTopicId.GetValueOrDefault(-1),
					CallCnvsReferUserId = mobspSelectParsServiceAppSetting_Result.CallCnvsReferUserId.GetValueOrDefault(-1),
					CallCnvsStatusId = mobspSelectParsServiceAppSetting_Result.CallCnvsStatusId.GetValueOrDefault(-1),
					CallAfterSendMessage = (mobspSelectParsServiceAppSetting_Result.CallAfterSendMessage ?? ""),
					InstallPrjTitle = (mobspSelectParsServiceAppSetting_Result.InstallPrjTitle ?? ""),
					InstallPrjCnvsStatusGroupId = mobspSelectParsServiceAppSetting_Result.InstallPrjCnvsStatusGroupId.GetValueOrDefault(-1),
					InstallCnvsTopicId = mobspSelectParsServiceAppSetting_Result.InstallCnvsTopicId.GetValueOrDefault(-1),
					InstallCnvsReferUserId = mobspSelectParsServiceAppSetting_Result.InstallCnvsReferUserId.GetValueOrDefault(-1),
					InstallCnvsStatusId = mobspSelectParsServiceAppSetting_Result.InstallCnvsStatusId.GetValueOrDefault(-1),
					CheckPrjTitle = (mobspSelectParsServiceAppSetting_Result.CheckPrjTitle ?? ""),
					CheckPrjCnvsStatusGroupId = mobspSelectParsServiceAppSetting_Result.CheckPrjCnvsStatusGroupId.GetValueOrDefault(-1),
					CheckCnvsTopicId = mobspSelectParsServiceAppSetting_Result.CheckCnvsTopicId.GetValueOrDefault(-1),
					CheckCnvsReferUserId = mobspSelectParsServiceAppSetting_Result.CheckCnvsReferUserId.GetValueOrDefault(-1),
					CheckCnvsStatusId = mobspSelectParsServiceAppSetting_Result.CheckCnvsStatusId.GetValueOrDefault(-1),
					EdtInfPrjTitle = (mobspSelectParsServiceAppSetting_Result.EdtInfPrjTitle ?? ""),
					EdtInfPrjCnvsStatusGroupId = mobspSelectParsServiceAppSetting_Result.EdtInfPrjCnvsStatusGroupId.GetValueOrDefault(-1),
					EdtInfCnvsTopicId = mobspSelectParsServiceAppSetting_Result.EdtInfCnvsTopicId.GetValueOrDefault(-1),
					EdtInfCnvsReferUserId = mobspSelectParsServiceAppSetting_Result.EdtInfCnvsReferUserId.GetValueOrDefault(-1),
					EdtInfCnvsStatusId = mobspSelectParsServiceAppSetting_Result.EdtInfCnvsStatusId.GetValueOrDefault(-1)
				};
				message = "";
				status = ServiceResultStatus.Success;
			}
			else
			{
				data = null;
				message = Messages.MobMsgErrorReceiveInfoFromCentralServer;
				status = ServiceResultStatus.Fail;
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
		return new ServiceResult<MobParsServiceAppSettingViewModel>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}
}
