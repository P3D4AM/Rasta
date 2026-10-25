using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using CRM.General.Security;
using CRM.General.Utilities;
using CRM.Resources;
using Elmah;
using GSD.Globalization;
using Microsoft.Ajax.Utilities;
using Mobile.Cache.Setting;
using Mobile.Classes;
using Mobile.Classes.Helper;
using Mobile.DataType;
using Mobile.Models;
using Mobile.Models.ViewModel.Common;
using Newtonsoft.Json;

namespace Mobile.Controllers;

public class CICAccountController : ApiController
{
	[HttpPost]
	public async Task<ServiceResult<byte[]>> CicLogin()
	{
		string encryptedData = Convert.ToBase64String(await base.Request.Content.ReadAsByteArrayAsync());
		CicLoginResultViewModel cicLoginResultViewModel = new CicLoginResultViewModel();
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		CRMEntities cRMEntities = null;
		CicLoginViewModel login = null;
		Security security = new Security();
		byte[] data = null;
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			int result2 = 1065;
			BaseInfo baseInfo = new BaseInfo();
			if (base.Request.Headers.Contains("LangId"))
			{
				int.TryParse(Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("LangId")), out result2);
			}
			if (result2 == 0)
			{
				result2 = 1065;
			}
			int num = ((result2 > 0) ? result2 : result);
			baseInfo.SetCulture(num);
			cRMEntities = new CRMEntities();
			CRMSpEntities cRMSpEntities = new CRMSpEntities();
			string text = "";
			string appName = "";
			int deviceTypeId = 0;
			DecodedDataModel decodedDataModel = new DecodedDataModel();
			if (base.Request.Headers.Contains("imeiCode"))
			{
				text = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("imeiCode"));
			}
			if (base.Request.Headers.Contains("appName"))
			{
				appName = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("appName"));
			}
			if (base.Request.Headers.Contains("deviceType"))
			{
				int.TryParse(Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("deviceType")), out deviceTypeId);
			}
			if (text.IsNullOrWhiteSpace())
			{
				return new ServiceResult<byte[]>
				{
					Message = Messages.MobImeicodeNotFound,
					Data = null,
					Status = ServiceResultStatus.Fail
				};
			}
			List<MobspSelectActiveUserAppDeviceInfoByImeiCode_Result> list = Enumerable.ToList<MobspSelectActiveUserAppDeviceInfoByImeiCode_Result>((IEnumerable<MobspSelectActiveUserAppDeviceInfoByImeiCode_Result>)cRMSpEntities.MobspSelectActiveUserAppDeviceInfoByImeiCode(text, appName));
			MobspSelectActiveUserAppDeviceInfoByImeiCode_Result mobspSelectActiveUserAppDeviceInfoByImeiCode_Result = ((deviceTypeId != 0) ? Enumerable.FirstOrDefault<MobspSelectActiveUserAppDeviceInfoByImeiCode_Result>(Enumerable.Where<MobspSelectActiveUserAppDeviceInfoByImeiCode_Result>((IEnumerable<MobspSelectActiveUserAppDeviceInfoByImeiCode_Result>)list, (Func<MobspSelectActiveUserAppDeviceInfoByImeiCode_Result, bool>)((MobspSelectActiveUserAppDeviceInfoByImeiCode_Result e) => e.UserId == -3 && e.DeviceType == deviceTypeId))) : Enumerable.FirstOrDefault<MobspSelectActiveUserAppDeviceInfoByImeiCode_Result>(Enumerable.Where<MobspSelectActiveUserAppDeviceInfoByImeiCode_Result>((IEnumerable<MobspSelectActiveUserAppDeviceInfoByImeiCode_Result>)list, (Func<MobspSelectActiveUserAppDeviceInfoByImeiCode_Result, bool>)((MobspSelectActiveUserAppDeviceInfoByImeiCode_Result e) => e.UserId == -3))));
			if (mobspSelectActiveUserAppDeviceInfoByImeiCode_Result == null || mobspSelectActiveUserAppDeviceInfoByImeiCode_Result.AESKey.IsNullOrWhiteSpace())
			{
				return new ServiceResult<byte[]>
				{
					Message = Messages.MobSecutiryCodeNotFound,
					Data = null,
					Status = ServiceResultStatus.Fail
				};
			}
			string aESKey = mobspSelectActiveUserAppDeviceInfoByImeiCode_Result.AESKey;
			cRMSpEntities.MobspRemoveTmpUserAppDeviceInfo(mobspSelectActiveUserAppDeviceInfoByImeiCode_Result.UserAppDeviceInfoId);
			string text2 = security.DecryptJson(encryptedData, aESKey);
			if (!text2.IsNullOrWhiteSpace())
			{
				decodedDataModel = JsonConvert.DeserializeObject<DecodedDataModel>(text2);
				login = JsonConvert.DeserializeObject<CicLoginViewModel>(decodedDataModel.Body);
			}
			string text3 = "";
			if (!decodedDataModel.Extra.IsNullOrWhiteSpace())
			{
				text3 = decodedDataModel.Extra;
			}
			if (new Common().CheckExtra(text3))
			{
				CheckVersionViewModel checkVersionViewModel = new Common().CheckVersion(login.apiVersion, login.appName);
				if (checkVersionViewModel == null || (!checkVersionViewModel.Status && !string.IsNullOrEmpty(checkVersionViewModel.Message)))
				{
					return new ServiceResult<byte[]>
					{
						Message = checkVersionViewModel.Message,
						Data = null,
						Status = ServiceResultStatus.Fail
					};
				}
				string userPassword = baseInfo.ConvertMd5(login.password).ToLower();
				CICMobspLoadUserLoginInfo_Result cICMobspLoadUserLoginInfo_Result = Enumerable.FirstOrDefault<CICMobspLoadUserLoginInfo_Result>((IEnumerable<CICMobspLoadUserLoginInfo_Result>)cRMSpEntities.CICMobspLoadUserLoginInfo(0, login.username, userPassword, result2, result));
				if (cICMobspLoadUserLoginInfo_Result != null)
				{
					if (!cICMobspLoadUserLoginInfo_Result.UserIsActiveInCIC.GetValueOrDefault())
					{
						return new ServiceResult<byte[]>
						{
							Message = Messages.MobMsgErrorHaveNotAccessUseCIC,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
					}
					if (!string.IsNullOrEmpty(login.imeiCode))
					{
						DateTime now = DateTime.Now;
						DateTime value = now;
						string text4 = now.ToString("yyyyMMdd", new PersianCulture());
						string appType = Mobile.Classes.Configuration.AppType;
						List<CICMobspSelectUserAppDeviceInfoByUserId_Result> list2 = Enumerable.ToList<CICMobspSelectUserAppDeviceInfoByUserId_Result>((IEnumerable<CICMobspSelectUserAppDeviceInfoByUserId_Result>)cRMSpEntities.CICMobspSelectUserAppDeviceInfoByUserId(cICMobspLoadUserLoginInfo_Result.UserId, login.projectAppName));
						int num2 = Enumerable.Count<CICMobspSelectUserAppDeviceInfoByUserId_Result>(Enumerable.Where<CICMobspSelectUserAppDeviceInfoByUserId_Result>((IEnumerable<CICMobspSelectUserAppDeviceInfoByUserId_Result>)list2, (Func<CICMobspSelectUserAppDeviceInfoByUserId_Result, bool>)((CICMobspSelectUserAppDeviceInfoByUserId_Result e) => !e.DeviceDeactive.GetValueOrDefault())));
						CICMobspSelectUserAppDeviceInfoByUserId_Result cICMobspSelectUserAppDeviceInfoByUserId_Result = Enumerable.FirstOrDefault<CICMobspSelectUserAppDeviceInfoByUserId_Result>(Enumerable.Where<CICMobspSelectUserAppDeviceInfoByUserId_Result>((IEnumerable<CICMobspSelectUserAppDeviceInfoByUserId_Result>)list2, (Func<CICMobspSelectUserAppDeviceInfoByUserId_Result, bool>)((CICMobspSelectUserAppDeviceInfoByUserId_Result e) => e.ImeiCode == login.imeiCode)));
						if (cICMobspSelectUserAppDeviceInfoByUserId_Result != null)
						{
							if (cICMobspSelectUserAppDeviceInfoByUserId_Result.DeviceDeactive.GetValueOrDefault())
							{
								if (num2 >= cICMobspLoadUserLoginInfo_Result.MobCICUserAppUseCnt.GetValueOrDefault())
								{
									return new ServiceResult<byte[]>
									{
										Message = string.Format(Messages.MobMsgMaxMobDeviceUseReached, cICMobspLoadUserLoginInfo_Result.MobCICUserAppUseCnt.GetValueOrDefault()),
										Data = null,
										Status = ServiceResultStatus.Fail
									};
								}
								List<CICMobspSelectActiveUserAppDeviceInfoByImeiCode_Result> list3 = Enumerable.ToList<CICMobspSelectActiveUserAppDeviceInfoByImeiCode_Result>((IEnumerable<CICMobspSelectActiveUserAppDeviceInfoByImeiCode_Result>)cRMSpEntities.CICMobspSelectActiveUserAppDeviceInfoByImeiCode(login.imeiCode, login.projectAppName));
								if (Enumerable.Any<CICMobspSelectActiveUserAppDeviceInfoByImeiCode_Result>((IEnumerable<CICMobspSelectActiveUserAppDeviceInfoByImeiCode_Result>)list3))
								{
									if (!Common.IsKara())
									{
										string userName = Mobile.Classes.Helper.User.GetUserName(Enumerable.First<CICMobspSelectActiveUserAppDeviceInfoByImeiCode_Result>((IEnumerable<CICMobspSelectActiveUserAppDeviceInfoByImeiCode_Result>)list3).UserId, num, result);
										return new ServiceResult<byte[]>
										{
											Message = string.Format(Messages.MobMsgThisDeviceIsTakenForUser, userName),
											Data = null,
											Status = ServiceResultStatus.Fail
										};
									}
									foreach (CICMobspSelectActiveUserAppDeviceInfoByImeiCode_Result item in list3)
									{
										cRMSpEntities.CICMobspDeactiveUserAppDeviceInfo(item.UserAppDeviceInfoId, value, text4, appType);
									}
								}
							}
							cRMSpEntities.CICMobspUpdateUserAppDeviceInfoById(cICMobspSelectUserAppDeviceInfoByUserId_Result.UserAppDeviceInfoId, login.deviceId ?? cICMobspSelectUserAppDeviceInfoByUserId_Result.DeviceId, login.deviceProperty ?? cICMobspSelectUserAppDeviceInfoByUserId_Result.DeviceProperty, value, text4, appType, aESKey);
							cicLoginResultViewModel.MobImeiCode = cICMobspSelectUserAppDeviceInfoByUserId_Result.ImeiCode;
						}
						else
						{
							if (num2 >= cICMobspLoadUserLoginInfo_Result.MobCICUserAppUseCnt.GetValueOrDefault())
							{
								return new ServiceResult<byte[]>
								{
									Message = string.Format(Messages.MobMsgMaxMobDeviceUseReached, cICMobspLoadUserLoginInfo_Result.MobCICUserAppUseCnt.GetValueOrDefault()),
									Data = null,
									Status = ServiceResultStatus.Fail
								};
							}
							List<CICMobspSelectActiveUserAppDeviceInfoByImeiCode_Result> list4 = Enumerable.ToList<CICMobspSelectActiveUserAppDeviceInfoByImeiCode_Result>((IEnumerable<CICMobspSelectActiveUserAppDeviceInfoByImeiCode_Result>)cRMSpEntities.CICMobspSelectActiveUserAppDeviceInfoByImeiCode(login.imeiCode, login.projectAppName));
							if (Enumerable.Any<CICMobspSelectActiveUserAppDeviceInfoByImeiCode_Result>((IEnumerable<CICMobspSelectActiveUserAppDeviceInfoByImeiCode_Result>)list4))
							{
								if (!Common.IsKara())
								{
									string userName2 = Mobile.Classes.Helper.User.GetUserName(Enumerable.First<CICMobspSelectActiveUserAppDeviceInfoByImeiCode_Result>((IEnumerable<CICMobspSelectActiveUserAppDeviceInfoByImeiCode_Result>)list4).UserId, num, result);
									return new ServiceResult<byte[]>
									{
										Message = string.Format(Messages.MobMsgThisDeviceIsTakenForUser, userName2),
										Data = null,
										Status = ServiceResultStatus.Fail
									};
								}
								foreach (CICMobspSelectActiveUserAppDeviceInfoByImeiCode_Result item2 in list4)
								{
									cRMSpEntities.CICMobspDeactiveUserAppDeviceInfo(item2.UserAppDeviceInfoId, value, text4, appType);
								}
							}
							cRMSpEntities.CICMobspInsertUserAppDeviceInfo(cICMobspLoadUserLoginInfo_Result.UserId, login.deviceId, login.deviceType, login.projectAppName, value, text4, appType, login.imeiCode, login.deviceProperty, aESKey);
							cicLoginResultViewModel.MobImeiCode = login.imeiCode;
						}
					}
					RandomText randomText = new RandomText();
					string getString = randomText.CreateRandomCode(5, WithNumber: true).Replace(" ", "").Trim() + "|" + cICMobspLoadUserLoginInfo_Result.UserId + "|" + randomText.CreateRandomCode(5, WithNumber: true).Replace(" ", "").Trim() + "|" + cICMobspLoadUserLoginInfo_Result.UserRollId + "|" + randomText.CreateRandomCode(5, WithNumber: true).Replace(" ", "").Trim() + "|" + text3 + "|" + randomText.CreateRandomCode(5, WithNumber: true).Replace(" ", "").Trim() + "|" + DateTime.Now.ToString("yyyyMMdd-HHmmss", new PersianCulture()) + "|" + randomText.CreateRandomCode(5, WithNumber: true).Replace(" ", "").Trim();
					cicLoginResultViewModel.token = CodeDecode.Codding(getString);
					cicLoginResultViewModel.FullName = cICMobspLoadUserLoginInfo_Result.FullName;
					cicLoginResultViewModel.RollId = cICMobspLoadUserLoginInfo_Result.UserRollId;
					cicLoginResultViewModel.UserId = cICMobspLoadUserLoginInfo_Result.UserId;
					cicLoginResultViewModel.RollName = cICMobspLoadUserLoginInfo_Result.RollName;
					cicLoginResultViewModel.CallerIdDeActiveFromMobile = cICMobspLoadUserLoginInfo_Result.CallerIdDeActiveFromMobile;
					data = security.EncryptJson(cicLoginResultViewModel, aESKey);
					message = Messages.MobMsgSuccessAction;
					status = ServiceResultStatus.Success;
				}
				else
				{
					message = Messages.MobMsgErrorUsernamePasswordIncorrect;
					status = ServiceResultStatus.Fail;
				}
			}
			else
			{
				message = Messages.MobMsgErrorLackAccessDevice;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e2)
		{
			message = Messages.MobMsgErrorDoneOperation;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<byte[]>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}
}
