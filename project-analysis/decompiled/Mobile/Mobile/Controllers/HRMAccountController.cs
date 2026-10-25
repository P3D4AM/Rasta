using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
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

public class HRMAccountController : ApiController
{
	[HttpPost]
	public async Task<ServiceResult<byte[]>> HrmLogin()
	{
		string encryptedData = Convert.ToBase64String(await base.Request.Content.ReadAsByteArrayAsync());
		HrmLoginResultViewModel hrmLoginResultViewModel = new HrmLoginResultViewModel();
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		CRMEntities cRMEntities = null;
		CRMSpEntities cRMSpEntities = null;
		HrmLoginViewModel login = null;
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
			cRMSpEntities = new CRMSpEntities();
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
				login = JsonConvert.DeserializeObject<HrmLoginViewModel>(decodedDataModel.Body);
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
				HRMMobspLoadUserLoginInfo_Result hRMMobspLoadUserLoginInfo_Result = Enumerable.FirstOrDefault<HRMMobspLoadUserLoginInfo_Result>((IEnumerable<HRMMobspLoadUserLoginInfo_Result>)cRMEntities.HRMMobspLoadUserLoginInfo(0, login.username, userPassword, result2, result));
				if (hRMMobspLoadUserLoginInfo_Result != null)
				{
					if (!hRMMobspLoadUserLoginInfo_Result.UserIsActiveInHRM.GetValueOrDefault())
					{
						return new ServiceResult<byte[]>
						{
							Message = Messages.MobMsgErrorHaveNotAccessUseHRM,
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
						List<HRMMobspSelectUserAppDeviceInfoByUserId_Result> list2 = Enumerable.ToList<HRMMobspSelectUserAppDeviceInfoByUserId_Result>((IEnumerable<HRMMobspSelectUserAppDeviceInfoByUserId_Result>)cRMSpEntities.HRMMobspSelectUserAppDeviceInfoByUserId(hRMMobspLoadUserLoginInfo_Result.UserId, login.projectAppName));
						int num2 = Enumerable.Count<HRMMobspSelectUserAppDeviceInfoByUserId_Result>(Enumerable.Where<HRMMobspSelectUserAppDeviceInfoByUserId_Result>((IEnumerable<HRMMobspSelectUserAppDeviceInfoByUserId_Result>)list2, (Func<HRMMobspSelectUserAppDeviceInfoByUserId_Result, bool>)((HRMMobspSelectUserAppDeviceInfoByUserId_Result e) => !e.DeviceDeactive.GetValueOrDefault())));
						HRMMobspSelectUserAppDeviceInfoByUserId_Result hRMMobspSelectUserAppDeviceInfoByUserId_Result = Enumerable.FirstOrDefault<HRMMobspSelectUserAppDeviceInfoByUserId_Result>(Enumerable.Where<HRMMobspSelectUserAppDeviceInfoByUserId_Result>((IEnumerable<HRMMobspSelectUserAppDeviceInfoByUserId_Result>)list2, (Func<HRMMobspSelectUserAppDeviceInfoByUserId_Result, bool>)((HRMMobspSelectUserAppDeviceInfoByUserId_Result e) => e.ImeiCode == login.imeiCode)));
						if (hRMMobspSelectUserAppDeviceInfoByUserId_Result != null)
						{
							if (hRMMobspSelectUserAppDeviceInfoByUserId_Result.DeviceDeactive.GetValueOrDefault())
							{
								if (num2 >= hRMMobspLoadUserLoginInfo_Result.MobHRMUserAppUseCnt.GetValueOrDefault())
								{
									return new ServiceResult<byte[]>
									{
										Message = string.Format(Messages.MobMsgMaxMobDeviceUseReached, hRMMobspLoadUserLoginInfo_Result.MobHRMUserAppUseCnt.GetValueOrDefault()),
										Data = null,
										Status = ServiceResultStatus.Fail
									};
								}
								List<HRMMobspSelectActiveUserAppDeviceInfoByImeiCode_Result> list3 = Enumerable.ToList<HRMMobspSelectActiveUserAppDeviceInfoByImeiCode_Result>((IEnumerable<HRMMobspSelectActiveUserAppDeviceInfoByImeiCode_Result>)cRMSpEntities.HRMMobspSelectActiveUserAppDeviceInfoByImeiCode(login.imeiCode, login.projectAppName));
								if (Enumerable.Any<HRMMobspSelectActiveUserAppDeviceInfoByImeiCode_Result>((IEnumerable<HRMMobspSelectActiveUserAppDeviceInfoByImeiCode_Result>)list3))
								{
									if (!Common.IsKara())
									{
										string userName = Mobile.Classes.Helper.User.GetUserName(Enumerable.First<HRMMobspSelectActiveUserAppDeviceInfoByImeiCode_Result>((IEnumerable<HRMMobspSelectActiveUserAppDeviceInfoByImeiCode_Result>)list3).UserId, num, result);
										return new ServiceResult<byte[]>
										{
											Message = string.Format(Messages.MobMsgThisDeviceIsTakenForUser, userName),
											Data = null,
											Status = ServiceResultStatus.Fail
										};
									}
									foreach (HRMMobspSelectActiveUserAppDeviceInfoByImeiCode_Result item in list3)
									{
										cRMSpEntities.HRMMobspDeactiveUserAppDeviceInfo(item.UserAppDeviceInfoId, value, text4, appType);
									}
								}
							}
							cRMSpEntities.HRMMobspUpdateUserAppDeviceInfoById(hRMMobspSelectUserAppDeviceInfoByUserId_Result.UserAppDeviceInfoId, login.deviceId ?? hRMMobspSelectUserAppDeviceInfoByUserId_Result.DeviceId, login.deviceProperty ?? hRMMobspSelectUserAppDeviceInfoByUserId_Result.DeviceProperty, value, text4, appType, aESKey);
							hrmLoginResultViewModel.MobImeiCode = hRMMobspSelectUserAppDeviceInfoByUserId_Result.ImeiCode;
						}
						else
						{
							if (num2 >= hRMMobspLoadUserLoginInfo_Result.MobHRMUserAppUseCnt.GetValueOrDefault())
							{
								return new ServiceResult<byte[]>
								{
									Message = string.Format(Messages.MobMsgMaxMobDeviceUseReached, hRMMobspLoadUserLoginInfo_Result.MobHRMUserAppUseCnt.GetValueOrDefault()),
									Data = null,
									Status = ServiceResultStatus.Fail
								};
							}
							List<HRMMobspSelectActiveUserAppDeviceInfoByImeiCode_Result> list4 = Enumerable.ToList<HRMMobspSelectActiveUserAppDeviceInfoByImeiCode_Result>((IEnumerable<HRMMobspSelectActiveUserAppDeviceInfoByImeiCode_Result>)cRMSpEntities.HRMMobspSelectActiveUserAppDeviceInfoByImeiCode(login.imeiCode, login.projectAppName));
							if (Enumerable.Any<HRMMobspSelectActiveUserAppDeviceInfoByImeiCode_Result>((IEnumerable<HRMMobspSelectActiveUserAppDeviceInfoByImeiCode_Result>)list4))
							{
								if (!Common.IsKara())
								{
									string userName2 = Mobile.Classes.Helper.User.GetUserName(Enumerable.First<HRMMobspSelectActiveUserAppDeviceInfoByImeiCode_Result>((IEnumerable<HRMMobspSelectActiveUserAppDeviceInfoByImeiCode_Result>)list4).UserId, num, result);
									return new ServiceResult<byte[]>
									{
										Message = string.Format(Messages.MobMsgThisDeviceIsTakenForUser, userName2),
										Data = null,
										Status = ServiceResultStatus.Fail
									};
								}
								foreach (HRMMobspSelectActiveUserAppDeviceInfoByImeiCode_Result item2 in list4)
								{
									cRMSpEntities.HRMMobspDeactiveUserAppDeviceInfo(item2.UserAppDeviceInfoId, value, text4, appType);
								}
							}
							cRMSpEntities.HRMMobspInsertUserAppDeviceInfo(hRMMobspLoadUserLoginInfo_Result.UserId, login.deviceId, login.deviceType, login.projectAppName, value, text4, appType, login.imeiCode, login.deviceProperty, aESKey);
							hrmLoginResultViewModel.MobImeiCode = login.imeiCode;
						}
					}
					RandomText randomText = new RandomText();
					string getString = randomText.CreateRandomCode(5, WithNumber: true).Replace(" ", "").Trim() + "|" + hRMMobspLoadUserLoginInfo_Result.UserId + "|" + randomText.CreateRandomCode(5, WithNumber: true).Replace(" ", "").Trim() + "|" + hRMMobspLoadUserLoginInfo_Result.UserRollId + "|" + randomText.CreateRandomCode(5, WithNumber: true).Replace(" ", "").Trim() + "|" + text3 + "|" + randomText.CreateRandomCode(5, WithNumber: true).Replace(" ", "").Trim() + "|" + DateTime.Now.ToString("yyyyMMdd-HHmmss", new PersianCulture()) + "|" + randomText.CreateRandomCode(5, WithNumber: true).Replace(" ", "").Trim();
					hrmLoginResultViewModel.Token = CodeDecode.Codding(getString);
					hrmLoginResultViewModel.FullName = hRMMobspLoadUserLoginInfo_Result.FullName;
					hrmLoginResultViewModel.RollId = hRMMobspLoadUserLoginInfo_Result.UserRollId;
					hrmLoginResultViewModel.UserId = hRMMobspLoadUserLoginInfo_Result.UserId;
					hrmLoginResultViewModel.RollName = hRMMobspLoadUserLoginInfo_Result.RollName;
					hrmLoginResultViewModel.DeActiveSmartTimeAttendance = hRMMobspLoadUserLoginInfo_Result.DeActiveSmartTimeAttendance;
					hrmLoginResultViewModel.ResponsibleUserId = hRMMobspLoadUserLoginInfo_Result.ResponsibleUserId;
					hrmLoginResultViewModel.ResponsibleUser = hRMMobspLoadUserLoginInfo_Result.ResponsibleUser;
					hrmLoginResultViewModel.DepartmentId = hRMMobspLoadUserLoginInfo_Result.DepartmentId;
					hrmLoginResultViewModel.Department = hRMMobspLoadUserLoginInfo_Result.Department;
					hrmLoginResultViewModel.DepartmentInfo = hRMMobspLoadUserLoginInfo_Result.DepartmentInfo;
					hrmLoginResultViewModel.MaliciousFileExtensions = Mobile.Classes.Configuration.MaliciousFileExtensions;
					hrmLoginResultViewModel.MaxFileSizeForUploadMb = Mobile.Classes.Configuration.MaxFileSizeForUploadMb;
					hrmLoginResultViewModel.MaxFileCountForUpload = Mobile.Classes.Configuration.MaxFileCount;
					hrmLoginResultViewModel.FileDirectoryTitleLength = Mobile.Classes.Configuration.FileDirectoryTitleLength;
					hrmLoginResultViewModel.VBLeave = VersionBuyer.Leave;
					hrmLoginResultViewModel.VBSmartTimeAttendance = VersionBuyer.SmartTimeAttendance;
					hrmLoginResultViewModel.DefMapType = Common.GetDefMapName();
					hrmLoginResultViewModel.MobHRMLoginMode = hRMMobspLoadUserLoginInfo_Result.MobHRMLoginMode.GetValueOrDefault(1);
					hrmLoginResultViewModel.VBCenter = VersionBuyer.Center;
					hrmLoginResultViewModel.UserCIds = hRMMobspLoadUserLoginInfo_Result.UserCIds;
					hrmLoginResultViewModel.UserLastCId = hRMMobspLoadUserLoginInfo_Result.UserLastCId;
					hrmLoginResultViewModel.ShiftWorkingId = hRMMobspLoadUserLoginInfo_Result.ShiftWorkingId;
					MobspSelectCrmsysSetting_Result mobspSelectCrmsysSetting_Result = SysSeting.Get();
					if (mobspSelectCrmsysSetting_Result == null)
					{
						return new ServiceResult<byte[]>
						{
							Message = Messages.ErrorNotFoundSetting,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
					}
					if (hRMMobspLoadUserLoginInfo_Result.UserLoginCheckLocationType.GetValueOrDefault() == 2 && (hRMMobspLoadUserLoginInfo_Result.UserLoginCheckLocations ?? "") != "")
					{
						hrmLoginResultViewModel.TimeAttendanceLocation = hRMMobspLoadUserLoginInfo_Result.UserLoginCheckLocations;
					}
					else if (hRMMobspLoadUserLoginInfo_Result.UserLoginCheckLocationType.GetValueOrDefault() != 2 && (mobspSelectCrmsysSetting_Result.CoLocations ?? "") != "")
					{
						hrmLoginResultViewModel.TimeAttendanceLocation = mobspSelectCrmsysSetting_Result.CoLocations;
					}
					data = security.EncryptJson(hrmLoginResultViewModel, aESKey);
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
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<byte[]>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<int> SubmitMissionAttendance(int leaveId, double usLat = 0.0, double usLng = 0.0, int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		CRMSpEntities cRMSpEntities = null;
		int data = 0;
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
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					cRMEntities = new CRMEntities();
					cRMSpEntities = new CRMSpEntities();
					HRMMobspSelectLeave_Result hRMMobspSelectLeave_Result = Enumerable.FirstOrDefault<HRMMobspSelectLeave_Result>((IEnumerable<HRMMobspSelectLeave_Result>)cRMEntities.HRMMobspSelectLeave(null, leaveId, null, null, null, null, null, null, num, result2, cId));
					if (hRMMobspSelectLeave_Result != null)
					{
						if (base.Request.Headers.TryGetValues("imeiCode", out var _) && !Common.CheckUserImeiCode(token2.userId, Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("imeiCode")), Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("appName"))))
						{
							return new ServiceResult<int>
							{
								Message = Messages.MobMsgUserImeiNotPreDefined,
								Data = 0,
								Status = ServiceResultStatus.Fail
							};
						}
						MobspSelectCrmsysSetting_Result mobspSelectCrmsysSetting_Result = SysSeting.Get();
						if (mobspSelectCrmsysSetting_Result == null)
						{
							return new ServiceResult<int>
							{
								Message = Messages.ErrorNotFoundSetting,
								Data = 0,
								Status = ServiceResultStatus.Fail
							};
						}
						if (mobspSelectCrmsysSetting_Result.CheckLocForScanQRInMission.GetValueOrDefault())
						{
							if (usLat == 0.0 && usLng == 0.0)
							{
								return new ServiceResult<int>
								{
									Message = Messages.msgErrorGettingCurrentLocation,
									Data = 0,
									Status = ServiceResultStatus.Fail
								};
							}
							double result3 = 0.0;
							double result4 = 0.0;
							double.TryParse(hRMMobspSelectLeave_Result.PlaceCoordinateLatitude, out result3);
							double.TryParse(hRMMobspSelectLeave_Result.PlaceCoordinateLongitude, out result4);
							if (result3 != 0.0 && result4 != 0.0)
							{
								double distance = Common.GetDistance(result4, result3, usLng, usLat);
								double valueOrDefault = mobspSelectCrmsysSetting_Result.UserLoginAccessDistance.GetValueOrDefault();
								if (distance > valueOrDefault)
								{
									return new ServiceResult<int>
									{
										Message = string.Format(Messages.MobMsgSubmitAttendanceMustBeInMissionArea, valueOrDefault.ToString()),
										Data = 0,
										Status = ServiceResultStatus.Fail
									};
								}
								int valueOrDefault2 = mobspSelectCrmsysSetting_Result.UserLoginAccessTimeDiffInMission.GetValueOrDefault();
								DateTime now = DateTime.Now;
								DateTime dateTime = hRMMobspSelectLeave_Result.FromDateTime.GetValueOrDefault(now).AddMinutes(-valueOrDefault2);
								DateTime dateTime2 = hRMMobspSelectLeave_Result.ToDateTime.GetValueOrDefault(now).AddMinutes(valueOrDefault2);
								if (now >= dateTime && now <= dateTime2)
								{
									string appType = Mobile.Classes.Configuration.AppType;
									string userHostAddress = HttpContext.Current.Request.UserHostAddress;
									string tmDatePersian = DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
									mct_I_Result mct_I_Result = Enumerable.FirstOrDefault<mct_I_Result>((IEnumerable<mct_I_Result>)cRMSpEntities.HRMMobspRegisterDailyTimeAttendance(tmDatePersian, token2.userId, userHostAddress, appType, result2));
									int num2 = 0;
									if (mct_I_Result != null)
									{
										num2 = mct_I_Result.Result;
									}
									switch (num2)
									{
									case 1:
										message = Messages.MobMsgLogInSuccessfullyRegistered;
										status = ServiceResultStatus.Success;
										break;
									case 2:
										message = Messages.MobMsgLogoutSuccessfullyRegistered;
										status = ServiceResultStatus.Success;
										break;
									default:
										message = Messages.MobMsgSubmitTimeAttendanceFailed;
										status = ServiceResultStatus.Fail;
										break;
									}
									data = num2;
								}
								else
								{
									message = string.Format(Messages.MobMsgSubmitAttendanceMustBeInMissionTimeZone, valueOrDefault2.ToString());
									data = 0;
									status = ServiceResultStatus.Fail;
								}
							}
							else
							{
								message = Messages.MobMsgMissionLocationNotDefined;
								data = 0;
								status = ServiceResultStatus.Fail;
							}
						}
						else
						{
							message = Messages.MobMsgCheckLocForScanQRInMissionIsDeactive;
							data = 0;
							status = ServiceResultStatus.Fail;
						}
					}
					else
					{
						message = Messages.MobMsgErorrNotFound;
						data = 0;
						status = ServiceResultStatus.Fail;
					}
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					data = 0;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				data = 0;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = 0;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<int>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<HRMMobspSelectTimeAttendanceByDate_Result> GetTimeAttendanceByCurrentDate(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		HRMMobspSelectTimeAttendanceByDate_Result data = null;
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
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					cRMEntities = new CRMEntities();
					data = Enumerable.FirstOrDefault<HRMMobspSelectTimeAttendanceByDate_Result>((IEnumerable<HRMMobspSelectTimeAttendanceByDate_Result>)cRMEntities.HRMMobspSelectTimeAttendanceByDate(DateTime.Now, token2.userId, num, result2));
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
			cRMEntities?.Dispose();
		}
		return new ServiceResult<HRMMobspSelectTimeAttendanceByDate_Result>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	public ServiceResult<bool> SubmitAttendanceWithoutScan(double usLat = 0.0, double usLng = 0.0, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		CRMSpEntities cRMSpEntities = null;
		bool data = false;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					cRMEntities = new CRMEntities();
					cRMSpEntities = new CRMSpEntities();
					if (base.Request.Headers.TryGetValues("imeiCode", out var _) && !Common.CheckUserImeiCode(token2.userId, Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("imeiCode")), Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("appName"))))
					{
						return new ServiceResult<bool>
						{
							Message = Messages.MobMsgUserImeiNotPreDefined,
							Data = false,
							Status = ServiceResultStatus.Fail
						};
					}
					MobspSelectCrmsysSetting_Result mobspSelectCrmsysSetting_Result = SysSeting.Get();
					if (mobspSelectCrmsysSetting_Result == null)
					{
						return new ServiceResult<bool>
						{
							Message = Messages.ErrorNotFoundSetting,
							Data = false,
							Status = ServiceResultStatus.Fail
						};
					}
					bool flag = false;
					double result3 = mobspSelectCrmsysSetting_Result.UserLoginAccessDistance.GetValueOrDefault();
					bool valueOrDefault = mobspSelectCrmsysSetting_Result.CheckLocForScanQR.GetValueOrDefault();
					bool valueOrDefault2 = mobspSelectCrmsysSetting_Result.CheckLocForScanQRInMission.GetValueOrDefault();
					if (valueOrDefault || valueOrDefault2)
					{
						if (usLat == 0.0 && usLng == 0.0)
						{
							return new ServiceResult<bool>
							{
								Message = Messages.msgErrorGettingCurrentLocation,
								Data = false,
								Status = ServiceResultStatus.Fail
							};
						}
						if (valueOrDefault)
						{
							message = Messages.MsgCoLocationNotDefined;
							data = false;
							status = ServiceResultStatus.Fail;
							double result4 = 0.0;
							double result5 = 0.0;
							HRMMobspLoadUserLoginInfo_Result hRMMobspLoadUserLoginInfo_Result = Enumerable.FirstOrDefault<HRMMobspLoadUserLoginInfo_Result>((IEnumerable<HRMMobspLoadUserLoginInfo_Result>)cRMEntities.HRMMobspLoadUserLoginInfo(token2.userId, "", "", result, result2));
							string coLocations = mobspSelectCrmsysSetting_Result.CoLocations;
							if (hRMMobspLoadUserLoginInfo_Result != null)
							{
								List<Dictionary<string, string>> list = new List<Dictionary<string, string>>();
								if (hRMMobspLoadUserLoginInfo_Result.UserLoginCheckLocationType.GetValueOrDefault() == 2 && (hRMMobspLoadUserLoginInfo_Result.UserLoginCheckLocations ?? "") != "")
								{
									list = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(hRMMobspLoadUserLoginInfo_Result.UserLoginCheckLocations);
								}
								else if (hRMMobspLoadUserLoginInfo_Result.UserLoginCheckLocationType.GetValueOrDefault() != 2 && (coLocations ?? "") != "")
								{
									list = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(coLocations);
								}
								foreach (Dictionary<string, string> item in list)
								{
									double.TryParse(item["lat"], out result4);
									double.TryParse(item["lng"], out result5);
									double.TryParse(item["AccessDistance"], out result3);
									if (result4 != 0.0 && result5 != 0.0)
									{
										if (!(Common.GetDistance(result5, result4, usLng, usLat) > result3))
										{
											flag = true;
											break;
										}
										message = string.Format(Messages.MobMsgSubmitAttendanceMustBeInArea, result3.ToString());
										data = false;
										status = ServiceResultStatus.Fail;
									}
								}
							}
							if (flag)
							{
								string appType = Mobile.Classes.Configuration.AppType;
								string userHostAddress = HttpContext.Current.Request.UserHostAddress;
								string tmDatePersian = DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
								mct_I_Result mct_I_Result = Enumerable.FirstOrDefault<mct_I_Result>((IEnumerable<mct_I_Result>)cRMSpEntities.HRMMobspRegisterDailyTimeAttendance(tmDatePersian, token2.userId, userHostAddress, appType, result2));
								int num = 0;
								if (mct_I_Result != null)
								{
									num = mct_I_Result.Result;
								}
								switch (num)
								{
								case 1:
									message = Messages.MobMsgLogInSuccessfullyRegistered;
									status = ServiceResultStatus.Success;
									data = true;
									break;
								case 2:
									message = Messages.MobMsgLogoutSuccessfullyRegistered;
									status = ServiceResultStatus.Success;
									data = true;
									break;
								default:
									message = Messages.MobMsgSubmitTimeAttendanceFailed;
									status = ServiceResultStatus.Fail;
									data = false;
									break;
								}
							}
						}
						if (!flag && valueOrDefault2)
						{
							foreach (MobspSelectSmartTimeAttendanceMission_Result item2 in Enumerable.ToList<MobspSelectSmartTimeAttendanceMission_Result>((IEnumerable<MobspSelectSmartTimeAttendanceMission_Result>)cRMSpEntities.MobspSelectSmartTimeAttendanceMission(token2.userId)))
							{
								double result6 = 0.0;
								double result7 = 0.0;
								double.TryParse(item2.PlaceCoordinateLatitude, out result6);
								double.TryParse(item2.PlaceCoordinateLongitude, out result7);
								if (result6 == 0.0 || result7 == 0.0 || !(Common.GetDistance(result7, result6, usLng, usLat) <= result3))
								{
									continue;
								}
								int valueOrDefault3 = mobspSelectCrmsysSetting_Result.UserLoginAccessTimeDiffInMission.GetValueOrDefault();
								DateTime now = DateTime.Now;
								DateTime dateTime = item2.FromDateTime.GetValueOrDefault(now).AddMinutes(-valueOrDefault3);
								DateTime dateTime2 = item2.ToDateTime.GetValueOrDefault(now).AddMinutes(valueOrDefault3);
								if (now >= dateTime && now <= dateTime2)
								{
									string appType2 = Mobile.Classes.Configuration.AppType;
									string userHostAddress2 = HttpContext.Current.Request.UserHostAddress;
									string tmDatePersian2 = DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
									mct_I_Result mct_I_Result2 = Enumerable.FirstOrDefault<mct_I_Result>((IEnumerable<mct_I_Result>)cRMSpEntities.HRMMobspRegisterDailyTimeAttendance(tmDatePersian2, token2.userId, userHostAddress2, appType2, result2));
									int num2 = 0;
									if (mct_I_Result2 != null)
									{
										num2 = mct_I_Result2.Result;
									}
									switch (num2)
									{
									case 1:
										message = Messages.MobMsgLogInSuccessfullyRegistered;
										status = ServiceResultStatus.Success;
										data = true;
										break;
									case 2:
										message = Messages.MobMsgLogoutSuccessfullyRegistered;
										status = ServiceResultStatus.Success;
										data = true;
										break;
									default:
										message = Messages.MobMsgSubmitTimeAttendanceFailed;
										status = ServiceResultStatus.Fail;
										data = false;
										break;
									}
								}
								else
								{
									message = string.Format(Messages.MobMsgSubmitAttendanceMustBeInMissionTimeZone, valueOrDefault3.ToString());
									data = false;
									status = ServiceResultStatus.Fail;
								}
								break;
							}
						}
					}
					else
					{
						message = Messages.MobMsgCheckLocForScanQRInMissionIsDeactive;
						data = false;
						status = ServiceResultStatus.Fail;
					}
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
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<bool>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> GetUserShiftWorkingTimeByDate(int? userShiftWorkingId = null, int timeAttendanceMode = 1, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		List<DropDownItemWithParentId> data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					cRMSpEntities = new CRMSpEntities();
					List<MobspSelectShiftWorkingTimeByDate_Result> list = Enumerable.ToList<MobspSelectShiftWorkingTimeByDate_Result>((IEnumerable<MobspSelectShiftWorkingTimeByDate_Result>)cRMSpEntities.MobspSelectShiftWorkingTimeByDate(token2.userId, DateTime.Now, userShiftWorkingId, timeAttendanceMode, Thread.CurrentThread.CurrentCulture.LCID, result2));
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					if (list != null)
					{
						_ = DateTime.Now;
						string text = DateTime.Now.ToString("HH:mm");
						int.Parse(text.Split(new char[1] { ':' })[0]);
						int.Parse(text.Split(new char[1] { ':' })[1]);
						for (int i = 0; i < list.Count; i++)
						{
							DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
							dropDownItemWithParentId.ParentId = 0;
							dropDownItemWithParentId.Id = list[i].ShiftWorkingTimeId;
							dropDownItemWithParentId.Title = list[i].swtTitle + " - " + list[i].EntryTime + " - " + list[i].ExitTime;
							Dictionary<string, string> dictionary = new Dictionary<string, string>();
							dictionary.Add("ShiftWorkingTimeId", list[i].ShiftWorkingTimeId.ToString());
							dictionary.Add("swtShiftWorkingId", list[i].swtShiftWorkingId.ToString());
							dictionary.Add("swtShiftWorking ", (list[i].swtShiftWorking ?? "").ToString());
							dictionary.Add("swtTitle", (list[i].swtTitle ?? "").ToString());
							dictionary.Add("DayNum", list[i].DayNum.GetValueOrDefault().ToString());
							dictionary.Add("EntryTime", (list[i].EntryTime ?? "").ToString());
							dictionary.Add("EntryTimeMin ", list[i].EntryTimeMin.GetValueOrDefault().ToString());
							dictionary.Add("EntryTimeSoon", (list[i].EntryTimeSoon ?? "").ToString());
							dictionary.Add("EntryTimeSoonMin", list[i].EntryTimeSoonMin.GetValueOrDefault().ToString());
							dictionary.Add("EntryTimeLate", (list[i].EntryTimeLate ?? "").ToString());
							dictionary.Add("EntryTimeLateMin", list[i].EntryTimeLateMin.GetValueOrDefault().ToString());
							dictionary.Add("ExitTime", (list[i].ExitTime ?? "").ToString());
							dictionary.Add("ExitTimeMin", list[i].ExitTimeMin.GetValueOrDefault().ToString());
							dictionary.Add("ExitTimeSoon", (list[i].ExitTimeSoon ?? "").ToString());
							dictionary.Add("ExitTimeSoonMin", list[i].ExitTimeSoonMin.GetValueOrDefault().ToString());
							dictionary.Add("ExitTimeLate", (list[i].ExitTimeLate ?? "").ToString());
							dictionary.Add("ExitTimeLateMin", list[i].ExitTimeLateMin.GetValueOrDefault().ToString());
							dictionary.Add("IsCloseDurationTime", (list[i].IsCloseDurationTime ?? "").ToString());
							dictionary.Add("IsClose", list[i].IsClose.GetValueOrDefault().ToString());
							dictionary.Add("IsCloseDurationTimeMin", list[i].IsCloseDurationTimeMin.GetValueOrDefault().ToString());
							dropDownItemWithParentId.ExtraField = dictionary;
							list2.Add(dropDownItemWithParentId);
						}
					}
					data = list2;
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
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}
}
