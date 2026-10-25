using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Web.Http;
using CRM.General.Security;
using CRM.General.Utilities;
using CRM.Resources;
using Elmah;
using GSD.Globalization;
using Microsoft.Ajax.Utilities;
using Mobile.Cache;
using Mobile.Cache.Setting;
using Mobile.Cache.User;
using Mobile.Classes;
using Mobile.Classes.Helper;
using Mobile.DataType;
using Mobile.Models;
using Mobile.Models.ViewModel.Common;
using Newtonsoft.Json;

namespace Mobile.Controllers;

public class AccountController : ApiController
{
	[HttpPost]
	public async Task<ServiceResult<byte[]>> Login()
	{
		string encryptedData = Convert.ToBase64String(await base.Request.Content.ReadAsByteArrayAsync());
		LoginResult loginResult = new LoginResult();
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		CRMEntities cRMEntities = null;
		CRMSpEntities cRMSpEntities = null;
		MyLogin login = null;
		Security security = new Security();
		byte[] data = null;
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			int result2 = 1065;
			if (base.Request.Headers.Contains("LangId"))
			{
				int.TryParse(Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("LangId")), out result2);
			}
			if (result2 == 0)
			{
				result2 = 1065;
			}
			BaseInfo baseInfo = new BaseInfo();
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
				login = JsonConvert.DeserializeObject<MyLogin>(decodedDataModel.Body);
			}
			string text3 = "";
			if (!decodedDataModel.Extra.IsNullOrWhiteSpace())
			{
				text3 = decodedDataModel.Extra;
			}
			if (new Common().CheckExtra(text3))
			{
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
							return new ServiceResult<byte[]>
							{
								Message = Messages.MobMsgErrorExpDate,
								Data = null,
								Status = ServiceResultStatus.Fail
							};
						}
					}
					catch (Exception e2)
					{
						ErrorSignal.FromCurrentContext().Raise(e2);
					}
				}
				CheckVersionViewModel checkVersionViewModel = new Common().CheckVersion(login.apiVersion, login.appName);
				if (checkVersionViewModel != null)
				{
					if (!checkVersionViewModel.Status && !string.IsNullOrEmpty(checkVersionViewModel.Message))
					{
						return new ServiceResult<byte[]>
						{
							Message = checkVersionViewModel.Message,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
					}
					string userPassword = baseInfo.ConvertMd5(login.password).ToLower();
					MobspLoadUserLoginInfo_Result mobspLoadUserLoginInfo_Result = Enumerable.FirstOrDefault<MobspLoadUserLoginInfo_Result>((IEnumerable<MobspLoadUserLoginInfo_Result>)cRMEntities.MobspLoadUserLoginInfo(0, login.username, userPassword, result2, result));
					if (mobspLoadUserLoginInfo_Result != null)
					{
						if (!mobspLoadUserLoginInfo_Result.UserIsActiveInMobApp.GetValueOrDefault())
						{
							message = Messages.MobMsgErrorHaveNotAccessUseMobApp;
							status = ServiceResultStatus.Fail;
						}
						else
						{
							if (mobspLoadUserLoginInfo_Result.ExpireDate.HasValue)
							{
								long num4 = long.Parse(mobspLoadUserLoginInfo_Result.ExpireDate.HasValue ? mobspLoadUserLoginInfo_Result.ExpireDate.Value.ToString("yyyyMMdd", new PersianCulture()) : "");
								if (long.Parse(DateTime.Now.ToString("yyyyMMdd", new PersianCulture())) > num4)
								{
									return new ServiceResult<byte[]>
									{
										Message = Messages.MobMsgErrorUsernameExpired,
										Data = null,
										Status = ServiceResultStatus.Fail
									};
								}
							}
							if (!string.IsNullOrEmpty(login.imeiCode))
							{
								DateTime now = DateTime.Now;
								DateTime value2 = now;
								string text4 = now.ToString("yyyyMMdd", new PersianCulture());
								string appType = Mobile.Classes.Configuration.AppType;
								List<MobspSelectUserAppDeviceInfoByUserId_Result> list2 = Enumerable.ToList<MobspSelectUserAppDeviceInfoByUserId_Result>((IEnumerable<MobspSelectUserAppDeviceInfoByUserId_Result>)cRMSpEntities.MobspSelectUserAppDeviceInfoByUserId(mobspLoadUserLoginInfo_Result.UserId, login.projectAppName));
								int num5 = Enumerable.Count<MobspSelectUserAppDeviceInfoByUserId_Result>(Enumerable.Where<MobspSelectUserAppDeviceInfoByUserId_Result>((IEnumerable<MobspSelectUserAppDeviceInfoByUserId_Result>)list2, (Func<MobspSelectUserAppDeviceInfoByUserId_Result, bool>)((MobspSelectUserAppDeviceInfoByUserId_Result e) => !e.DeviceDeactive.GetValueOrDefault())));
								MobspSelectUserAppDeviceInfoByUserId_Result mobspSelectUserAppDeviceInfoByUserId_Result = Enumerable.FirstOrDefault<MobspSelectUserAppDeviceInfoByUserId_Result>(Enumerable.Where<MobspSelectUserAppDeviceInfoByUserId_Result>((IEnumerable<MobspSelectUserAppDeviceInfoByUserId_Result>)list2, (Func<MobspSelectUserAppDeviceInfoByUserId_Result, bool>)((MobspSelectUserAppDeviceInfoByUserId_Result e) => e.ImeiCode == login.imeiCode)));
								if (mobspSelectUserAppDeviceInfoByUserId_Result != null)
								{
									if (mobspSelectUserAppDeviceInfoByUserId_Result.DeviceDeactive.GetValueOrDefault())
									{
										if (num5 >= mobspLoadUserLoginInfo_Result.MobUserAppUseCnt.GetValueOrDefault())
										{
											return new ServiceResult<byte[]>
											{
												Message = string.Format(Messages.MobMsgMaxMobDeviceUseReached, mobspLoadUserLoginInfo_Result.MobUserAppUseCnt.GetValueOrDefault()),
												Data = null,
												Status = ServiceResultStatus.Fail
											};
										}
										List<MobspSelectActiveUserAppDeviceInfoByImeiCode_Result> list3 = Enumerable.ToList<MobspSelectActiveUserAppDeviceInfoByImeiCode_Result>((IEnumerable<MobspSelectActiveUserAppDeviceInfoByImeiCode_Result>)cRMSpEntities.MobspSelectActiveUserAppDeviceInfoByImeiCode(login.imeiCode, login.projectAppName));
										if (Enumerable.Any<MobspSelectActiveUserAppDeviceInfoByImeiCode_Result>((IEnumerable<MobspSelectActiveUserAppDeviceInfoByImeiCode_Result>)list3))
										{
											if (!Common.IsKara())
											{
												string userName = Mobile.Classes.Helper.User.GetUserName(Enumerable.First<MobspSelectActiveUserAppDeviceInfoByImeiCode_Result>((IEnumerable<MobspSelectActiveUserAppDeviceInfoByImeiCode_Result>)list3).UserId, num, result);
												return new ServiceResult<byte[]>
												{
													Message = string.Format(Messages.MobMsgThisDeviceIsTakenForUser, userName),
													Data = null,
													Status = ServiceResultStatus.Fail
												};
											}
											foreach (MobspSelectActiveUserAppDeviceInfoByImeiCode_Result item in list3)
											{
												cRMSpEntities.MobspDeactiveUserAppDeviceInfo(item.UserAppDeviceInfoId, value2, text4, appType);
											}
										}
									}
									cRMSpEntities.MobspUpdateUserAppDeviceInfoById(mobspSelectUserAppDeviceInfoByUserId_Result.UserAppDeviceInfoId, login.deviceId ?? mobspSelectUserAppDeviceInfoByUserId_Result.DeviceId, login.deviceProperty ?? mobspSelectUserAppDeviceInfoByUserId_Result.DeviceProperty, value2, text4, appType, aESKey);
									loginResult.MobImeiCode = mobspSelectUserAppDeviceInfoByUserId_Result.ImeiCode;
								}
								else
								{
									if (num5 >= mobspLoadUserLoginInfo_Result.MobUserAppUseCnt.GetValueOrDefault())
									{
										return new ServiceResult<byte[]>
										{
											Message = string.Format(Messages.MobMsgMaxMobDeviceUseReached, mobspLoadUserLoginInfo_Result.MobUserAppUseCnt.GetValueOrDefault()),
											Data = null,
											Status = ServiceResultStatus.Fail
										};
									}
									List<MobspSelectActiveUserAppDeviceInfoByImeiCode_Result> list4 = Enumerable.ToList<MobspSelectActiveUserAppDeviceInfoByImeiCode_Result>((IEnumerable<MobspSelectActiveUserAppDeviceInfoByImeiCode_Result>)cRMSpEntities.MobspSelectActiveUserAppDeviceInfoByImeiCode(login.imeiCode, login.projectAppName));
									if (Enumerable.Any<MobspSelectActiveUserAppDeviceInfoByImeiCode_Result>((IEnumerable<MobspSelectActiveUserAppDeviceInfoByImeiCode_Result>)list4))
									{
										if (!Common.IsKara())
										{
											string userName2 = Mobile.Classes.Helper.User.GetUserName(Enumerable.First<MobspSelectActiveUserAppDeviceInfoByImeiCode_Result>((IEnumerable<MobspSelectActiveUserAppDeviceInfoByImeiCode_Result>)list4).UserId, num, result);
											return new ServiceResult<byte[]>
											{
												Message = string.Format(Messages.MobMsgThisDeviceIsTakenForUser, userName2),
												Data = null,
												Status = ServiceResultStatus.Fail
											};
										}
										foreach (MobspSelectActiveUserAppDeviceInfoByImeiCode_Result item2 in list4)
										{
											cRMSpEntities.MobspDeactiveUserAppDeviceInfo(item2.UserAppDeviceInfoId, value2, text4, appType);
										}
									}
									cRMEntities.MobspInsertUserAppDeviceInfo(mobspLoadUserLoginInfo_Result.UserId, login.deviceId, login.deviceType, login.projectAppName, value2, text4, appType, login.imeiCode, login.deviceProperty, aESKey);
									loginResult.MobImeiCode = login.imeiCode;
								}
							}
							RandomText randomText = new RandomText();
							string getString = randomText.CreateRandomCode(5, WithNumber: true).Replace(" ", "").Trim() + "|" + mobspLoadUserLoginInfo_Result.UserId + "|" + randomText.CreateRandomCode(5, WithNumber: true).Replace(" ", "").Trim() + "|" + mobspLoadUserLoginInfo_Result.UserRollId + "|" + randomText.CreateRandomCode(5, WithNumber: true).Replace(" ", "").Trim() + "|" + text3 + "|" + randomText.CreateRandomCode(5, WithNumber: true).Replace(" ", "").Trim() + "|" + DateTime.Now.ToString("yyyyMMdd-HHmmss", new PersianCulture()) + "|" + randomText.CreateRandomCode(5, WithNumber: true).Replace(" ", "").Trim();
							loginResult.token = CodeDecode.Codding(getString);
							loginResult.FullName = mobspLoadUserLoginInfo_Result.FullName;
							loginResult.RollId = mobspLoadUserLoginInfo_Result.UserRollId;
							loginResult.UserId = mobspLoadUserLoginInfo_Result.UserId;
							loginResult.RollName = mobspLoadUserLoginInfo_Result.RollName;
							loginResult.CoordinateLatitude = ((!string.IsNullOrEmpty(mobspLoadUserLoginInfo_Result.CoordinateLatitude)) ? mobspLoadUserLoginInfo_Result.CoordinateLatitude : "");
							loginResult.CoordinateLongitude = ((!string.IsNullOrEmpty(mobspLoadUserLoginInfo_Result.CoordinateLongitude)) ? mobspLoadUserLoginInfo_Result.CoordinateLongitude : "");
							loginResult.LimitPreOrderDiscountActive = mobspLoadUserLoginInfo_Result.LimitPreOrderDiscountActive;
							loginResult.LimitPreOrderDiscountPercent = mobspLoadUserLoginInfo_Result.LimitPreOrderDiscountPercent;
							loginResult.LimitOrderDiscountActive = mobspLoadUserLoginInfo_Result.LimitOrderDiscountActive;
							loginResult.LimitOrderDiscountPercent = mobspLoadUserLoginInfo_Result.LimitOrderDiscountPercent;
							loginResult.CoordinateLastDatePersian = ((!string.IsNullOrEmpty(mobspLoadUserLoginInfo_Result.CoordinateLastDatePersian)) ? DateTimeClass.ConvertDateWoSlashToSlash(mobspLoadUserLoginInfo_Result.CoordinateLastDatePersian) : "");
							loginResult.CoordinateLastDate = (mobspLoadUserLoginInfo_Result.CoordinateLastDate.HasValue ? (mobspLoadUserLoginInfo_Result.CoordinateLastDate ?? DateTime.Now).ToString("yyyy/MM/dd", new CultureInfo("en-US")) : "");
							loginResult.CoordinateLastTime = (mobspLoadUserLoginInfo_Result.CoordinateLastDate.HasValue ? (mobspLoadUserLoginInfo_Result.CoordinateLastDate ?? DateTime.Now).ToString("HH:mm:ss") : "");
							loginResult.MaxNumberCmpDraft = mobspLoadUserLoginInfo_Result.MaxNumberCmpDraft.GetValueOrDefault();
							loginResult.MobDeActiveAccessToLocation = mobspLoadUserLoginInfo_Result.MobDeActiveAccessToLocation;
							loginResult.UserAccessDailyChrtAllUsers = mobspLoadUserLoginInfo_Result.UserAccessDailyChrtAllUsers;
							loginResult.UserAccessSaleChrtAllUsers = mobspLoadUserLoginInfo_Result.UserAccessSaleChrtAllUsers;
							loginResult.DeActiveSmartTimeAttendance = mobspLoadUserLoginInfo_Result.DeActiveSmartTimeAttendance;
							loginResult.ActiveMobMovementTracking = mobspLoadUserLoginInfo_Result.ActiveMobMovementTracking;
							loginResult.MobMovementTrackingDistanceInterval = mobspLoadUserLoginInfo_Result.MobMovementTrackingDistanceInterval;
							loginResult.MobMovementTrackingTimeInterval = mobspLoadUserLoginInfo_Result.MobMovementTrackingTimeInterval;
							loginResult.DepartmentInfo = mobspLoadUserLoginInfo_Result.DepartmentInfo;
							loginResult.ResponsibleUserId = mobspLoadUserLoginInfo_Result.ResponsibleUserId;
							loginResult.ResponsibleUser = mobspLoadUserLoginInfo_Result.ResponsibleUser;
							loginResult.MobDeActiveScreenshot = mobspLoadUserLoginInfo_Result.MobDeActiveScreenshot;
							loginResult.DefCmpPrjTitle = mobspLoadUserLoginInfo_Result.DefCmpPrjTitle;
							loginResult.MobCallerIdDeActive = mobspLoadUserLoginInfo_Result.MobCallerIdDeActive;
							loginResult.MobAppDevSetting = mobspLoadUserLoginInfo_Result.MobAppDevSetting;
							loginResult.AppLocationRequired = mobspLoadUserLoginInfo_Result.AppLocationRequired;
							loginResult.MaliciousFileExtensions = Mobile.Classes.Configuration.MaliciousFileExtensions;
							loginResult.MaxFileSizeForUploadMb = Mobile.Classes.Configuration.MaxFileSizeForUploadMb;
							loginResult.MaxFileCountForUpload = Mobile.Classes.Configuration.MaxFileCount;
							loginResult.FileDirectoryTitleLength = Mobile.Classes.Configuration.FileDirectoryTitleLength;
							loginResult.MaxFileCountToDwonload = Mobile.Classes.Configuration.MaxFileCountToDwonload;
							loginResult.MobFinancial = VersionBuyer.MobFinancial;
							loginResult.VBTicketPlus = VersionBuyer.TicketPlus;
							loginResult.VBPreOrder = VersionBuyer.PreOrders;
							loginResult.VBOrder = VersionBuyer.Order;
							loginResult.VBPordPlus = VersionBuyer.PordPlus;
							loginResult.VBMobDyForm = VersionBuyer.MobDyForm;
							loginResult.VBDyForm = VersionBuyer.DyForm;
							loginResult.VBLeave = VersionBuyer.Leave;
							loginResult.VBWareHouse = VersionBuyer.WareHouse;
							loginResult.VBWareHouseUserPermission = VersionBuyer.WareHouseUserPermission;
							loginResult.VBProjectProductHistory = VersionBuyer.ProjectProductHistory;
							loginResult.VBSmartTimeAttendance = VersionBuyer.SmartTimeAttendance;
							loginResult.VBIssueMultiDraftFromOrd = VersionBuyer.IssueMultiDraftFromOrd;
							loginResult.VBLetters = VersionBuyer.Letters;
							loginResult.VBLetterNumberCounter = VersionBuyer.LetterNumberCounter;
							loginResult.VBEmails = VersionBuyer.Emails;
							loginResult.VBSms = VersionBuyer.SMS;
							loginResult.VBFund = VersionBuyer.Fund;
							loginResult.VBCenter = VersionBuyer.Center;
							loginResult.VBLinkAcc = VersionBuyer.LinkAcc;
							loginResult.MobHRMLoginMode = mobspLoadUserLoginInfo_Result.MobHRMLoginMode.GetValueOrDefault();
							loginResult.UserCIds = mobspLoadUserLoginInfo_Result.UserCIds;
							loginResult.UserLastCId = mobspLoadUserLoginInfo_Result.UserLastCId;
							loginResult.ShiftWorkingId = mobspLoadUserLoginInfo_Result.ShiftWorkingId;
							loginResult.UserExtensions = mobspLoadUserLoginInfo_Result.UserExtensions;
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
							if (mobspLoadUserLoginInfo_Result.UserLoginCheckLocationType.GetValueOrDefault() == 2 && (mobspLoadUserLoginInfo_Result.UserLoginCheckLocations ?? "") != "")
							{
								loginResult.TimeAttendanceLocation = mobspLoadUserLoginInfo_Result.UserLoginCheckLocations;
							}
							else if (mobspLoadUserLoginInfo_Result.UserLoginCheckLocationType.GetValueOrDefault() != 2 && (mobspSelectCrmsysSetting_Result.CoLocations ?? "") != "")
							{
								loginResult.TimeAttendanceLocation = mobspSelectCrmsysSetting_Result.CoLocations;
							}
							loginResult.Permissions = new Dictionary<string, bool>();
							UserLoginInfo user = new UserLoginInfo
							{
								UserId = mobspLoadUserLoginInfo_Result.UserId,
								IsActive = mobspLoadUserLoginInfo_Result.IsActive,
								FullName = mobspLoadUserLoginInfo_Result.FullName,
								RollName = mobspLoadUserLoginInfo_Result.RollName
							};
							loginResult.Permissions.Add("actcUserLocation", UserLogin.IsUserAccess("frmMain", "actcUserLocation", user, login.CenterId));
							if (string.IsNullOrEmpty(loginResult.MobAppDevSetting))
							{
								loginResult.MobAppDevSetting = InsertDefaultUserMobAppDevSetting(mobspLoadUserLoginInfo_Result.UserId);
							}
							loginResult.DefMapType = Common.GetDefMapName();
							loginResult.ServerCurrentDateTime = DateTime.Now;
							data = security.EncryptJson(loginResult, aESKey);
							Info.Update(mobspLoadUserLoginInfo_Result.UserId, true);
							Permissions.Update(mobspLoadUserLoginInfo_Result.UserId);
							Manager.UpdateAllSettingCach();
							message = Messages.MobMsgSuccessAction;
							status = ServiceResultStatus.Success;
						}
					}
					else
					{
						message = Messages.MobMsgErrorUsernamePasswordIncorrect;
						status = ServiceResultStatus.Fail;
					}
				}
			}
			else
			{
				message = Messages.MobMsgErrorLackAccessDevice;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e3)
		{
			message = Messages.MobMsgErrorDoneOperation;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e3);
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
	public ServiceResult<List<MobspSelectCentersWithIds_Result>> GetUserCenters(string cIds, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		List<MobspSelectCentersWithIds_Result> data = null;
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
					data = Enumerable.ToList<MobspSelectCentersWithIds_Result>((IEnumerable<MobspSelectCentersWithIds_Result>)cRMSpEntities.MobspSelectCentersWithIds(cIds, ",", num, result2));
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
		return new ServiceResult<List<MobspSelectCentersWithIds_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<LoginByMobileResult> LoginByMobileNumber(LoginByMobileViewModel model)
	{
		LoginByMobileResult loginByMobileResult = new LoginByMobileResult();
		string text = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		CRMEntities cRMEntities = null;
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			int num = 1065;
			BaseInfo baseInfo = new BaseInfo();
			num = ((model.LangId > 0) ? model.LangId : 1065);
			int culture = ((num > 0) ? num : result);
			baseInfo.SetCulture(culture);
			DateTime now = DateTime.Now;
			string mobPersonLabel = Labels.MobPersonLabel;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			short value2 = short.Parse(Financial.Get().Id.ToString());
			short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string mobConversationErjaShow = Messages.MobConversationErjaShow;
			string appType = Mobile.Classes.Configuration.AppType;
			string text2 = "\r\n" + Messages.MobConversationErjaMultiUser + "{MultiUser}";
			string text3 = "\r\n" + Messages.MobConversationErjaReferDescription + ":\r\n{CNVSREFERDESC}";
			string mobLackOfShowText = Labels.MobLackOfShowText;
			string conversationErjaShow = Messages.ConversationErjaShow;
			string eventErjaRefmsg = "";
			int num2 = -10;
			int num3 = 0;
			int num4 = 0;
			if (base.Request.Headers.Contains("extra"))
			{
				Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("extra"));
			}
			new Common();
			cRMEntities = new CRMEntities();
			List<MobspSelectLanguages_Result> list = Enumerable.ToList<MobspSelectLanguages_Result>((IEnumerable<MobspSelectLanguages_Result>)cRMEntities.MobspSelectLanguages());
			MobspCheckDuplicateCmpMobile_Result mobspCheckDuplicateCmpMobile_Result = Enumerable.FirstOrDefault<MobspCheckDuplicateCmpMobile_Result>((IEnumerable<MobspCheckDuplicateCmpMobile_Result>)cRMEntities.MobspCheckDuplicateCmpMobile(model.mobileNumber, 0, num, result));
			if (mobspCheckDuplicateCmpMobile_Result != null)
			{
				MobspCheckDuplicatePrsMobileByCmpId_Result mobspCheckDuplicatePrsMobileByCmpId_Result = Enumerable.FirstOrDefault<MobspCheckDuplicatePrsMobileByCmpId_Result>((IEnumerable<MobspCheckDuplicatePrsMobileByCmpId_Result>)cRMEntities.MobspCheckDuplicatePrsMobileByCmpId(model.mobileNumber, mobspCheckDuplicateCmpMobile_Result.CompanyId, 0, num, result));
				num3 = mobspCheckDuplicateCmpMobile_Result.CompanyId;
				loginByMobileResult.Company = mobspCheckDuplicateCmpMobile_Result.CompanyId.ToString();
				if (mobspCheckDuplicatePrsMobileByCmpId_Result == null)
				{
					ObjectParameter objectParameter = new ObjectParameter("insertedPersonIds", "");
					ObjectParameter objectParameter2 = new ObjectParameter("errorMessage", "");
					model.Persons = model.Persons.Replace("prsCompanyId=", "prsCompanyId=" + mobspCheckDuplicateCmpMobile_Result.CompanyId);
					CRMEntities cRMEntities2 = cRMEntities;
					string persons = model.Persons;
					int? userId = num2;
					short? year = value2;
					short? month = value3;
					DateTime? registerDate = value;
					int? languageID = num;
					int? defaultLanguageID = result;
					ObjectParameter insertedPersonIds = objectParameter;
					ObjectParameter errorMessage = objectParameter2;
					int? num5 = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities2.MobspInsertQuickPerson(persons, userId, year, month, registerDate, registerDatePersian, appType, languageID, defaultLanguageID, model.Type, insertedPersonIds, errorMessage, model.CenterId));
					string text4 = "";
					if (objectParameter2.Value != null)
					{
						if (objectParameter2.Value.ToString() != "")
						{
							string text5 = objectParameter2.Value.ToString();
							text5 = text5.Replace("|Msg=0", "<CMP>" + Messages.MobMsgErrorInsertCompany + "<\\CMP>");
							text5 = text5.Replace("Msg=1", "<CMP>" + Messages.MobMsgErrorInconsistencyInCompanySelection + "<\\CMP>");
							text5 = text5.Replace("Msg=2", "<PRS>" + Messages.MobMsgErrorInsertPersons + "<\\PRS>");
							text5 = text5.Replace("Msg=3", "<PRS>" + Messages.MobMsgErrorInsertPerson + "<\\PRS>");
							text5 = text5.Replace("Msg=4", "<PRj>" + Messages.MobMsgErrorInsertProjects + "<\\PRj>");
							text5 = text5.Replace("Msg=5", "<PRj>" + Messages.MobMsgErrorInsertProject + "<\\PRj>");
							text5 = text5.Replace("Msg=6", "<CNVS>" + Messages.MobMsgErrorInsertSms + "<\\CNVS>");
							text5 = text5.Replace("Msg=7", "<CNVS>" + Messages.MobMsgErrorInsertConversation + "<\\CNVS>");
							loginByMobileResult.ErrorMessage = text5;
							text4 = objectParameter2.Value.ToString();
							if (text4.IndexOf("|Msg=CompanyAccess|", StringComparison.Ordinal) >= 0)
							{
								text4 = text4.Replace("|Msg=0", "").Replace("Msg=1", "").Replace("Msg=2", "")
									.Replace("Msg=3", "")
									.Replace("Msg=4", "")
									.Replace("Msg=5", "")
									.Replace("Msg=6", "")
									.Replace("Msg=7", "")
									.Replace("Dup=1Msg=0", "");
								if (text4.IndexOf("|Msg=CompanyAccess|", StringComparison.Ordinal) >= 0)
								{
									string[] array = text4.Split(new string[1] { "|Msg=CompanyAccess|" }, StringSplitOptions.None);
									if (array != null && Enumerable.Count<string>((IEnumerable<string>)array) == 3)
									{
										if (!string.IsNullOrEmpty(array[1]))
										{
											string[] array2 = array[1].Split(new string[1] { "|PRSID|" }, StringSplitOptions.None);
											if (array2 != null && Enumerable.Count<string>((IEnumerable<string>)array2) == 2)
											{
												string text6 = string.Format(Messages.MobMsgErrorrNotAccessToCompany, array2[1]);
												string newValue = "<PRS><PRSID>" + array2[0] + "<\\PRSID><PRSCOMPANY>" + text6 + "<\\PRSCOMPANY><\\PRS>";
												text4 = text4.Replace("|Msg=CompanyAccess|" + array[1] + "|Msg=CompanyAccess|", newValue);
											}
										}
									}
									else if (array != null && Enumerable.Count<string>((IEnumerable<string>)array) > 3)
									{
										for (int i = 1; i < Enumerable.Count<string>((IEnumerable<string>)array); i++)
										{
											if (!string.IsNullOrEmpty(array[i]))
											{
												string[] array3 = array[i].Split(new string[1] { "|PRSID|" }, StringSplitOptions.None);
												if (array3 != null && Enumerable.Count<string>((IEnumerable<string>)array3) == 2)
												{
													string text7 = string.Format(Messages.MobMsgErrorrNotAccessToCompany, array3[1]);
													string newValue2 = "<PRS><PRSID>" + array3[0] + "<\\PRSID><PRSCOMPANY>" + text7 + "<\\PRSCOMPANY><\\PRS>";
													text4 = text4.Replace("|Msg=CompanyAccess|" + array[i] + "|Msg=CompanyAccess|", newValue2);
												}
											}
										}
									}
								}
								loginByMobileResult.ErrorMessage = text4;
							}
							else
							{
								text4 = "";
							}
						}
						else
						{
							loginByMobileResult.ErrorMessage = "";
						}
					}
					if (objectParameter.Value != null)
					{
						string text8 = objectParameter.Value.ToString();
						loginByMobileResult.Persons = text8.Substring(text8.IndexOf(",") + 1, text8.IndexOf("|") - 2) ?? "0";
						num4 = int.Parse(loginByMobileResult.Persons);
					}
					else
					{
						loginByMobileResult.Persons = "0";
					}
					if (num5.HasValue && !(num5 >= 1))
					{
						text = Messages.MobMsgErrorDoneOperation;
						status = ServiceResultStatus.Fail;
						return new ServiceResult<LoginByMobileResult>
						{
							Message = text,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
					}
					if (loginByMobileResult.ErrorMessage.IndexOf("Dup=1", StringComparison.Ordinal) >= 0)
					{
						loginByMobileResult.Type = "Dup";
					}
					if (loginByMobileResult.Type == "Dup")
					{
						ObjectParameter objectParameter3 = new ObjectParameter("errorMessage", "");
						CRMEntities cRMEntities3 = cRMEntities;
						string company = model.Company;
						string persons2 = model.Persons;
						string personLabel = mobPersonLabel;
						int? id = 0;
						int? userId2 = num2;
						int? languageID2 = num;
						int? defaultLanguageID2 = result;
						errorMessage = objectParameter3;
						int? mode = 0;
						cRMEntities3.MobspCheckDuplicateCompanyWithReason(company, persons2, null, id, userId2, languageID2, defaultLanguageID2, mobLackOfShowText, personLabel, mode, errorMessage, model.CenterId);
						if (objectParameter3.Value != null && objectParameter3.Value.ToString() != "")
						{
							string text9 = objectParameter3.Value.ToString();
							string text10 = "";
							if (text9 != "")
							{
								string[] array4 = text9.Split(new string[1] { "|^|" }, StringSplitOptions.None);
								foreach (string text11 in array4)
								{
									if (!string.IsNullOrEmpty(text11))
									{
										string[] array5 = text11.Split(new char[1] { ',' });
										string text12 = "";
										string text13 = "";
										string text14 = "";
										string text15 = "";
										string text16 = "";
										string text17 = "";
										string text18 = "";
										if (array5[0] == "@cmpName=Dup")
										{
											text12 = array5[3].Replace("@DupCmpName=", "") ?? "";
											text13 = array5[2].Replace("@DupCmpTitle=", "") ?? "";
											text14 = array5[4].Replace("@DupCmpCity=", "") ?? "";
											text15 = array5[5].Replace("@DupCmpNumber=", "") ?? "";
											text10 = text10 + "<CMP>" + string.Format(Messages.MobMsgErrorCheckCmpNameDuplicate, text12, text13, text14, text15) + "<\\CMP>";
										}
										else if (array5[0] == "@cmpName=IsNull")
										{
											text10 = text10 + "<CMP>" + Messages.MobMsgErrorCmpNameNotEntered + "<\\CMP>";
										}
										else if (array5[0] == "@cmpTel=Dup")
										{
											text12 = array5[3].Replace("@DupCmpName=", "") ?? "";
											text13 = array5[2].Replace("@DupCmpTitle=", "") ?? "";
											text14 = array5[4].Replace("@DupCmpCity=", "") ?? "";
											text15 = array5[5].Replace("@DupCmpNumber=", "") ?? "";
											text10 = text10 + "<CMP>" + string.Format(Messages.MobMsgErrorCheckCmpTelDuplicate, text12, text13, text14, text15) + "<\\CMP>";
										}
										else if (array5[0] == "@cmpTelII=Dup")
										{
											text12 = array5[3].Replace("@DupCmpName=", "") ?? "";
											text13 = array5[2].Replace("@DupCmpTitle=", "") ?? "";
											text14 = array5[4].Replace("@DupCmpCity=", "") ?? "";
											text15 = array5[5].Replace("@DupCmpNumber=", "") ?? "";
											text10 = text10 + "<CMP>" + string.Format(Messages.MobMsgErrorCheckCmpTelIIDuplicate, text12, text13, text14, text15) + "<\\CMP>";
										}
										else if (array5[0] == "@cmpFax=Dup")
										{
											text12 = array5[3].Replace("@DupCmpName=", "") ?? "";
											text13 = array5[2].Replace("@DupCmpTitle=", "") ?? "";
											text14 = array5[4].Replace("@DupCmpCity=", "") ?? "";
											text15 = array5[5].Replace("@DupCmpNumber=", "") ?? "";
											text10 = text10 + "<CMP>" + string.Format(Messages.MobMsgErrorCheckCmpFaxDuplicate, text12, text13, text14, text15) + "<\\CMP>";
										}
										else if (array5[0] == "@prsLName=Dup")
										{
											text18 = array5[2].Replace("@CompanyPersonID=", "") ?? "";
											text16 = array5[1].Replace("@prsLName=", "") ?? "";
											text17 = array5[4].Replace("@prsFName=", "") ?? "";
											text12 = array5[7].Replace("@DupCmpName=", "") ?? "";
											text13 = array5[6].Replace("@DupCmpTitle=", "") ?? "";
											text14 = array5[8].Replace("@DupCmpCity=", "") ?? "";
											text15 = array5[9].Replace("@DupCmpNumber=", "") ?? "";
											text10 = text10 + "<PRS><PRSID>" + text18 + "<\\PRSID>" + string.Format(Messages.MobMsgErrorCheckPrsLNameDuplicate, text17 + " " + text16, text12, text13, text14, text15) + "<\\PRS>";
										}
										if (array5[0] == "@prsLName=IsNull")
										{
											text10 = text10 + "<PRS>" + Messages.MobMsgErrorPrsLNameNotEntered + "<\\PRS>";
										}
										else if (array5[0] == "@prsTel=Dup")
										{
											text18 = array5[2].Replace("@CompanyPersonID=", "") ?? "";
											text16 = array5[1].Replace("@prsLName=", "") ?? "";
											text17 = array5[4].Replace("@prsFName=", "") ?? "";
											text12 = array5[7].Replace("@DupCmpName=", "") ?? "";
											text13 = array5[6].Replace("@DupCmpTitle=", "") ?? "";
											text14 = array5[8].Replace("@DupCmpCity=", "") ?? "";
											text15 = array5[9].Replace("@DupCmpNumber=", "") ?? "";
											text10 = text10 + "<PRS><PRSID>" + text18 + "<\\PRSID>" + string.Format(Messages.MobMsgErrorCheckPrsTelDuplicate, text17 + " " + text16, text12, text13, text14, text15) + "<\\PRS>";
										}
										else if (array5[0] == "@prsTelII=Dup")
										{
											text18 = array5[2].Replace("@CompanyPersonID=", "") ?? "";
											text16 = array5[1].Replace("@prsLName=", "") ?? "";
											text17 = array5[4].Replace("@prsFName=", "") ?? "";
											text12 = array5[7].Replace("@DupCmpName=", "") ?? "";
											text13 = array5[6].Replace("@DupCmpTitle=", "") ?? "";
											text14 = array5[8].Replace("@DupCmpCity=", "") ?? "";
											text15 = array5[9].Replace("@DupCmpNumber=", "") ?? "";
											text10 = text10 + "<PRS><PRSID>" + text18 + "<\\PRSID>" + string.Format(Messages.MobMsgErrorCheckPrsTelIIDuplicate, text17 + " " + text16, text12, text13, text14, text15) + "<\\PRS>";
										}
										else if (array5[0] == "@prsFax=Dup")
										{
											text18 = array5[2].Replace("@CompanyPersonID=", "") ?? "";
											text16 = array5[1].Replace("@prsLName=", "") ?? "";
											text17 = array5[4].Replace("@prsFName=", "") ?? "";
											text12 = array5[7].Replace("@DupCmpName=", "") ?? "";
											text13 = array5[6].Replace("@DupCmpTitle=", "") ?? "";
											text14 = array5[8].Replace("@DupCmpCity=", "") ?? "";
											text15 = array5[9].Replace("@DupCmpNumber=", "") ?? "";
											text10 = text10 + "<PRS><PRSID>" + text18 + "<\\PRSID>" + string.Format(Messages.MobMsgErrorCheckPrsFaxDuplicate, text17 + " " + text16, text12, text13, text14, text15) + "<\\PRS>";
										}
										else if (array5[0] == "@prsMobile=Dup")
										{
											text18 = array5[3].Replace("@CompanyPersonID=", "") ?? "";
											text16 = array5[1].Replace("@prsLName=", "") ?? "";
											text17 = array5[2].Replace("@prsFName=", "") ?? "";
											text15 = array5[5].Replace("@DupCmpNumber=", "") ?? "";
											text10 = text10 + "<PRS><PRSID>" + text18 + "<\\PRSID>" + string.Format(Messages.MobMsgErrorCheckPrsMobileDuplicate, text17 + " " + text16, text15) + "<\\PRS>";
										}
										else if (array5[0] == "@prsEmail=Dup")
										{
											text18 = array5[3].Replace("@CompanyPersonID=", "") ?? "";
											text16 = array5[1].Replace("@prsLName=", "") ?? "";
											text17 = array5[2].Replace("@prsFName=", "") ?? "";
											text15 = array5[5].Replace("@DupCmpNumber=", "") ?? "";
											text10 = text10 + "<PRS><PRSID>" + text18 + "<\\PRSID>" + string.Format(Messages.MobMsgErrorCheckPrsEmailDuplicate, text17 + " " + text16, text15) + "<\\PRS>";
										}
										else if (array5[0] == "@prsEmailII=Dup")
										{
											text18 = array5[3].Replace("@CompanyPersonID=", "") ?? "";
											text16 = array5[1].Replace("@prsLName=", "") ?? "";
											text17 = array5[2].Replace("@prsFName=", "") ?? "";
											text15 = array5[5].Replace("@DupCmpNumber=", "") ?? "";
											text10 = text10 + "<PRS><PRSID>" + text18 + "<\\PRSID>" + string.Format(Messages.MobMsgErrorCheckPrsEmailIIDuplicate, text17 + " " + text16, text15) + "<\\PRS>";
										}
									}
								}
							}
							loginByMobileResult.ErrorMessage = text4 + " " + text10;
						}
					}
					if (!string.IsNullOrEmpty(loginByMobileResult.ErrorMessage))
					{
						text = loginByMobileResult.ErrorMessage;
						status = ServiceResultStatus.Fail;
						return new ServiceResult<LoginByMobileResult>
						{
							Message = text,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
					}
				}
				else
				{
					loginByMobileResult.Persons = mobspCheckDuplicatePrsMobileByCmpId_Result.CompanyPersonID.ToString();
					num4 = mobspCheckDuplicatePrsMobileByCmpId_Result.CompanyPersonID;
				}
				if (num3 > 0 && num4 > 0 && string.IsNullOrEmpty(text))
				{
					string projectTitle = model.Projects.Substring(model.Projects.IndexOf("prjTitle=") + 9, model.Projects.IndexOf("|#|prjStartDate=") - (model.Projects.IndexOf("prjTitle=") + 9));
					MobspSelectCrmProjectByProjectTitle_Result mobspSelectCrmProjectByProjectTitle_Result = Enumerable.FirstOrDefault<MobspSelectCrmProjectByProjectTitle_Result>((IEnumerable<MobspSelectCrmProjectByProjectTitle_Result>)cRMEntities.MobspSelectCrmProjectByProjectTitle(projectTitle, num3, num, result));
					if (mobspSelectCrmProjectByProjectTitle_Result == null)
					{
						ObjectParameter objectParameter4 = new ObjectParameter("insertedProjectIds", "");
						ObjectParameter objectParameter5 = new ObjectParameter("errorMessage", "");
						model.Projects = model.Projects.Replace("prjCompanyId=", "prjCompanyId=" + mobspCheckDuplicateCmpMobile_Result.CompanyId);
						int? num6 = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.MobspInsertQuickProject(model.Projects, num2, value2, value3, value, registerDatePersian, appType, num, result, model.Type, objectParameter4, objectParameter5, null));
						string text19 = "";
						if (objectParameter5.Value != null)
						{
							if (objectParameter5.Value.ToString() != "")
							{
								string text20 = objectParameter5.Value.ToString();
								text20 = text20.Replace("|Msg=0", "<CMP>" + Messages.MobMsgErrorInsertCompany + "<\\CMP>");
								text20 = text20.Replace("Msg=1", "<CMP>" + Messages.MobMsgErrorInconsistencyInCompanySelection + "<\\CMP>");
								text20 = text20.Replace("Msg=2", "<PRS>" + Messages.MobMsgErrorInsertPersons + "<\\PRS>");
								text20 = text20.Replace("Msg=3", "<PRS>" + Messages.MobMsgErrorInsertPerson + "<\\PRS>");
								text20 = text20.Replace("Msg=4", "<PRj>" + Messages.MobMsgErrorInsertProjects + "<\\PRj>");
								text20 = text20.Replace("Msg=5", "<PRj>" + Messages.MobMsgErrorInsertProject + "<\\PRj>");
								text20 = text20.Replace("Msg=6", "<CNVS>" + Messages.MobMsgErrorInsertSms + "<\\CNVS>");
								text20 = text20.Replace("Msg=7", "<CNVS>" + Messages.MobMsgErrorInsertConversation + "<\\CNVS>");
								text20 = text20.Replace("Dup=1Msg=0", "<CMP>" + Messages.MobMsgErrorNotInsertDuplicateCompany + "<\\CMP>");
								loginByMobileResult.ErrorMessage = text20;
								text19 = objectParameter5.Value.ToString();
								if (text19.IndexOf("|Msg=CompanyAccess|", StringComparison.Ordinal) >= 0 || text19.IndexOf("|Msg=PrjAccess|", StringComparison.Ordinal) >= 0)
								{
									text19 = text19.Replace("|Msg=0", "").Replace("Msg=1", "").Replace("Msg=2", "")
										.Replace("Msg=3", "")
										.Replace("Msg=4", "")
										.Replace("Msg=5", "")
										.Replace("Msg=6", "")
										.Replace("Msg=7", "")
										.Replace("Dup=1Msg=0", "");
									if (text19.IndexOf("|Msg=CompanyAccess|", StringComparison.Ordinal) >= 0)
									{
										string[] array6 = text19.Split(new string[1] { "|Msg=CompanyAccess|" }, StringSplitOptions.None);
										if (array6 != null && Enumerable.Count<string>((IEnumerable<string>)array6) == 3)
										{
											if (!string.IsNullOrEmpty(array6[1]))
											{
												string[] array7 = array6[1].Split(new string[1] { "|PRJID|" }, StringSplitOptions.None);
												if (array7 != null && Enumerable.Count<string>((IEnumerable<string>)array7) == 2)
												{
													string text21 = string.Format(Messages.MobMsgErrorrNotAccessToCompany, array7[1]);
													string newValue3 = "<PRJ><PRJID>" + array7[0] + "<\\PRJID><PRJCOMPANY>" + text21 + "<\\PRJCOMPANY><\\PRJ>";
													text19 = text19.Replace("|Msg=CompanyAccess|" + array6[1] + "|Msg=CompanyAccess|", newValue3);
												}
											}
										}
										else if (array6 != null && Enumerable.Count<string>((IEnumerable<string>)array6) > 3)
										{
											for (int k = 1; k < Enumerable.Count<string>((IEnumerable<string>)array6); k++)
											{
												if (!string.IsNullOrEmpty(array6[k]))
												{
													string[] array8 = array6[k].Split(new string[1] { "|PRJID|" }, StringSplitOptions.None);
													if (array8 != null && Enumerable.Count<string>((IEnumerable<string>)array8) == 2)
													{
														string text22 = string.Format(Messages.MobMsgErrorrNotAccessToCompany, array8[1]);
														string newValue4 = "<PRJ><PRJID>" + array8[0] + "<\\PRJID><PRJCOMPANY>" + text22 + "<\\PRJCOMPANY><\\PRJ>";
														text19 = text19.Replace("|Msg=CompanyAccess|" + array6[k] + "|Msg=CompanyAccess|", newValue4);
													}
												}
											}
										}
									}
									if (text19.IndexOf("|Msg=PrjAccess|", StringComparison.Ordinal) >= 0)
									{
										string[] array9 = text19.Split(new string[1] { "|Msg=PrjAccess|" }, StringSplitOptions.None);
										if (array9 != null && Enumerable.Count<string>((IEnumerable<string>)array9) == 3)
										{
											if (!string.IsNullOrEmpty(array9[1]))
											{
												string[] array10 = array9[1].Split(new string[1] { "|PRJID|" }, StringSplitOptions.None);
												if (array10 != null && Enumerable.Count<string>((IEnumerable<string>)array10) == 2)
												{
													string text23 = string.Format(Messages.MobMsgErrorrNotAccessToProject, array10[1]);
													string newValue5 = "<PRJ><PRJID>" + array10[0] + "<\\PRJID><PRJTITLE>" + text23 + "<\\PRJTITLE><\\PRJ>";
													text19 = text19.Replace("|Msg=PrjAccess|" + array9[1] + "|Msg=PrjAccess|", newValue5);
												}
											}
										}
										else if (array9 != null && Enumerable.Count<string>((IEnumerable<string>)array9) > 3)
										{
											for (int l = 1; l < Enumerable.Count<string>((IEnumerable<string>)array9); l++)
											{
												if (!string.IsNullOrEmpty(array9[l]))
												{
													string[] array11 = array9[l].Split(new string[1] { "|PRJID|" }, StringSplitOptions.None);
													if (array11 != null && Enumerable.Count<string>((IEnumerable<string>)array11) == 2)
													{
														string text24 = string.Format(Messages.MobMsgErrorrNotAccessToProject, array11[1]);
														string newValue6 = "<PRJ><PRJID>" + array11[0] + "<\\PRJID><PRJTITLE>" + text24 + "<\\PRJTITLE><\\PRJ>";
														text19 = text19.Replace("|Msg=PrjAccess|" + array9[l] + "|Msg=PrjAccess|", newValue6);
													}
												}
											}
										}
									}
									loginByMobileResult.ErrorMessage = text19;
								}
								else
								{
									text19 = "";
								}
							}
							else
							{
								loginByMobileResult.ErrorMessage = "";
							}
						}
						if (objectParameter4.Value != null)
						{
							string text25 = objectParameter4.Value.ToString();
							loginByMobileResult.Projects = text25.Substring(text25.IndexOf(",") + 1, text25.IndexOf("|") - 2) ?? "0";
							int.Parse(loginByMobileResult.Projects);
						}
						else
						{
							loginByMobileResult.Projects = "0";
						}
						if (num6.HasValue && !(num6 >= 1))
						{
							text = Messages.MobMsgErrorDoneOperation;
							status = ServiceResultStatus.Fail;
							return new ServiceResult<LoginByMobileResult>
							{
								Message = text,
								Data = null,
								Status = ServiceResultStatus.Fail
							};
						}
						if (!string.IsNullOrEmpty(loginByMobileResult.ErrorMessage))
						{
							text = loginByMobileResult.ErrorMessage;
							status = ServiceResultStatus.Fail;
							return new ServiceResult<LoginByMobileResult>
							{
								Message = text,
								Data = null,
								Status = ServiceResultStatus.Fail
							};
						}
					}
					else
					{
						_ = mobspSelectCrmProjectByProjectTitle_Result.ProjectID;
						loginByMobileResult.Projects = mobspSelectCrmProjectByProjectTitle_Result.ProjectID.ToString();
					}
					string mobCnvsReferUserCmpNotAccess = Messages.MobCnvsReferUserCmpNotAccess;
					string text26 = "";
					string text27 = "";
					string text28 = "";
					foreach (MobspSelectLanguages_Result item in list)
					{
						text2 = "";
						text2 = "\r\n" + MyResource.GetResourceString("MobConversationErjaMultiUser", item.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + " : {MultiUser}";
						text3 = "";
						text3 = "\r\n" + MyResource.GetResourceString("MobConversationErjaReferDescription", item.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ":\r\n{CNVSREFERDESC}";
						mobCnvsReferUserCmpNotAccess = "";
						mobCnvsReferUserCmpNotAccess = MyResource.GetResourceString("MobCnvsReferUserCmpNotAccess", item.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
						text26 = text26 + "MsgErjaMultiUser=" + text2 + "|@#@|LangId=" + item.LanguageID + "|@#@||^#^|";
						text27 = text27 + "MsgReferDesc=" + text3 + "|@#@|LangId=" + item.LanguageID + "|@#@||^#^|";
						text28 = text28 + "CmpNotAccess=" + mobCnvsReferUserCmpNotAccess + "|@#@|LangId=" + item.LanguageID + "|@#@||^#^|";
					}
					text2 = text26;
					text3 = text27;
					mobCnvsReferUserCmpNotAccess = text28;
					string text29 = "";
					string text30 = "";
					string text31 = "";
					text29 = "";
					foreach (MobspSelectLanguages_Result item2 in list)
					{
						text30 = "";
						text31 = "";
						text30 = MyResource.GetResourceString("MobConversationErjaFrom", item2.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + " " + Common.GetUserName(num2, result, item2.LanguageID, model.CenterId);
						text31 = MyResource.GetResourceString("MobConversationErjaInConnection", item2.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": {CMP}\r\n" + MyResource.GetResourceString("MobConversationErjaPerson", item2.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": {PRS}\r\n" + MyResource.GetResourceString("MobConversationErjaProject", item2.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": {PRJ}{MultiUser}";
						text31 = text31 + "\r\n\r\n" + MyResource.GetResourceString("MobConversationErjaConversationDescription", item2.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ":\r\n{CNVSDESC}{CNVSREFERDESC}";
						text31 = text31 + "\r\n\r\n" + MyResource.GetResourceString("MobConversationErjaDetails", item2.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
						text29 = text29 + "MsgSubj=" + text30 + "|@#@|MsgBody=" + text31 + "|@#@|LangId=" + item2.LanguageID + "|@#@||^#^|";
					}
					text30 = "";
					text31 = text29;
					string text32 = "";
					string text33 = "";
					text29 = "";
					foreach (MobspSelectLanguages_Result item3 in list)
					{
						text32 = "";
						text33 = "";
						text32 = MyResource.GetResourceString("MobConversationErjaNotice", item3.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": " + Common.GetUserName(num2, result, item3.LanguageID, model.CenterId);
						text33 = "**" + MyResource.GetResourceString("MobConversationErjaAutomatically", item3.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n\r\n" + MyResource.GetResourceString("MobConversationErjaAttention", item3.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + MyResource.GetResourceString("MobConversationErjaInConnection", item3.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": {CMP}\r\n" + MyResource.GetResourceString("MobConversationErjaPerson", item3.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": {PRS}\r\n" + MyResource.GetResourceString("MobConversationErjaProject", item3.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": {PRJ}\r\n\r\n" + MyResource.GetResourceString("MobConversationErjaLastNegotiator", item3.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ", " + MyResource.GetResourceString("MobConversationErjaTransmitter", item3.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + MyResource.GetResourceString("MobConversationErjaMultiUser", item3.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "{MultiUser}\r\n\r\n" + MyResource.GetResourceString("MobConversationErjaConversationDescription", item3.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": \r\n{CNVSDESC}{CNVSREFERDESC}";
						text33 = text33 + "\r\n\r\n" + MyResource.GetResourceString("MobConversationErjaDetails", item3.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
						text29 = text29 + "MsgSubj=" + text32 + "|@#@|MsgBody=" + text33 + "|@#@|LangId=" + item3.LanguageID + "|@#@||^#^|";
					}
					text32 = "";
					text33 = text29;
					string text34 = "";
					string text35 = "";
					text29 = "";
					foreach (MobspSelectLanguages_Result item4 in list)
					{
						text34 = "";
						text35 = "";
						text34 = MyResource.GetResourceString("MobConversationErjaRonevesht", item4.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": " + Common.GetUserName(num2, result, item4.LanguageID, model.CenterId);
						text35 = MyResource.GetResourceString("MobConversationErjaInConnection", item4.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": {CMP} \r\n" + MyResource.GetResourceString("MobConversationErjaPerson", item4.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": {PRS} \r\n" + MyResource.GetResourceString("MobConversationErjaProject", item4.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": {PRJ}\r\n" + MyResource.GetResourceString("MobConversationErjaMultiUser", item4.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + " : {MultiUser}\r\n\r\n" + MyResource.GetResourceString("MobConversationErjaConversationDescription", item4.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": \r\n{CNVSDESC}{CNVSREFERDESC}";
						text35 = text35 + "\r\n\r\n" + MyResource.GetResourceString("MobConversationErjaDetails", item4.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
						text29 = text29 + "MsgSubj=" + text34 + "|@#@|MsgBody=" + text35 + "|@#@|LangId=" + item4.LanguageID + "|@#@||^#^|";
					}
					text34 = "";
					text35 = text29;
					int value4 = 7;
					string text36 = "";
					string surveyMainExtrenalLinkLogin = "";
					string surveyMainExtrenalLink = "";
					string text37 = base.Request.RequestUri.GetLeftPart(UriPartial.Authority);
					string leftPart = base.Request.RequestUri.GetLeftPart(UriPartial.Scheme);
					if (text37.EndsWith("/"))
					{
						text37 = text37.TrimEnd(new char[1] { '/' });
					}
					text37 += "/Survey/Home/SurveyAnswerValues";
					text36 = text37;
					string text38 = "";
					MobspSelectCrmsysSetting_Result mobspSelectCrmsysSetting_Result = SysSeting.Get();
					string text39 = "";
					string text40 = "";
					if (mobspSelectCrmsysSetting_Result != null)
					{
						text39 = mobspSelectCrmsysSetting_Result.FOUrl ?? "";
						text40 = mobspSelectCrmsysSetting_Result.CrmIPStatic ?? "";
					}
					if (!string.IsNullOrWhiteSpace(text39))
					{
						text38 = text39.Trim();
						if (!text38.Contains("http"))
						{
							text38 = leftPart + text38;
						}
						if (text38.EndsWith("/"))
						{
							text38 = text38.TrimEnd(new char[1] { '/' });
						}
						text38 += "/Survey/Home";
						surveyMainExtrenalLinkLogin = text38;
					}
					if (!string.IsNullOrWhiteSpace(text40))
					{
						text38 = text40.Trim();
						if (!text38.Contains("http"))
						{
							text38 = leftPart + text38;
						}
						if (text38.EndsWith("/"))
						{
							text38 = text38.TrimEnd(new char[1] { '/' });
						}
						text38 += "/Survey/Register/Index";
					}
					model.Conversations = model.Conversations.Replace("cnvsProjectId=", "cnvsProjectId=" + loginByMobileResult.Projects);
					model.Conversations = model.Conversations.Replace("cnvsCompanyId=", "cnvsCompanyId=" + num3);
					model.Conversations = model.Conversations.Replace("cnvsPersonId=", "cnvsPersonId=" + num4);
					int maxFOCount = Mobile.Classes.Configuration.MaxFOCount;
					ObjectParameter objectParameter6 = new ObjectParameter("insertedConversationIds", "");
					ObjectParameter objectParameter7 = new ObjectParameter("errorMessage", "");
					ObjectParameter objectParameter8 = new ObjectParameter("result", 0);
					CRMEntities cRMEntities4 = cRMEntities;
					string conversations = model.Conversations;
					int? userId3 = num2;
					short? year2 = value2;
					short? month2 = value3;
					DateTime? registerDate2 = value;
					int? languageID3 = num;
					int? defaultLanguageID3 = result;
					string needErjaRefmsgSubj = text30;
					string needErjaRefmsgBody = text31;
					string needErjaMultiIntmsgSubject = text34;
					string needErjaMultiIntmsgBody = text35;
					string needSendErjaAllarmRefmsgSubj = text32;
					string needSendErjaAllarmRefmsgBody = text33;
					string msgConversationErjaMultiUser = text2;
					string msgConversationErjaReferDescription = text3;
					ObjectParameter errorMessage = objectParameter6;
					ObjectParameter insertedPersonIds = objectParameter7;
					string type = model.Type;
					ObjectParameter insertedConversationIds = errorMessage;
					ObjectParameter errorMessage2 = insertedPersonIds;
					string personLabel = mobCnvsReferUserCmpNotAccess;
					Enumerable.FirstOrDefault<MobspInsertQuickConversation_Result>((IEnumerable<MobspInsertQuickConversation_Result>)cRMEntities4.MobspInsertQuickConversation(conversations, userId3, year2, month2, registerDate2, registerDatePersian, appType, languageID3, defaultLanguageID3, needErjaRefmsgSubj, needErjaRefmsgBody, needErjaMultiIntmsgSubject, needErjaMultiIntmsgBody, needSendErjaAllarmRefmsgSubj, needSendErjaAllarmRefmsgBody, mobConversationErjaShow, msgConversationErjaMultiUser, msgConversationErjaReferDescription, type, insertedConversationIds, errorMessage2, objectParameter8, value4, personLabel, text36, surveyMainExtrenalLink, surveyMainExtrenalLinkLogin, conversationErjaShow, eventErjaRefmsg, null, maxFOCount));
					string text41 = "";
					if (objectParameter7.Value != null)
					{
						if (objectParameter7.Value.ToString() != "")
						{
							string text42 = objectParameter7.Value.ToString();
							text42 = text42.Replace("|Msg=0", "<CMP>" + Messages.MobMsgErrorInsertCompany + "<\\CMP>");
							text42 = text42.Replace("Msg=1", "<CMP>" + Messages.MobMsgErrorInconsistencyInCompanySelection + "<\\CMP>");
							text42 = text42.Replace("Msg=2", "<PRS>" + Messages.MobMsgErrorInsertPersons + "<\\PRS>");
							text42 = text42.Replace("Msg=3", "<PRS>" + Messages.MobMsgErrorInsertPerson + "<\\PRS>");
							text42 = text42.Replace("Msg=4", "<PRj>" + Messages.MobMsgErrorInsertProjects + "<\\PRj>");
							text42 = text42.Replace("Msg=5", "<PRj>" + Messages.MobMsgErrorInsertProject + "<\\PRj>");
							text42 = text42.Replace("Msg=6", "<CNVS>" + Messages.MobMsgErrorInsertSms + "<\\CNVS>");
							text42 = text42.Replace("Msg=7", "<CNVS>" + Messages.MobMsgErrorInsertConversation + "<\\CNVS>");
							text42 = text42.Replace("Dup=1Msg=0", "<CMP>" + Messages.MobMsgErrorNotInsertDuplicateCompany + "<\\CMP>");
							loginByMobileResult.ErrorMessage = text42;
							text41 = objectParameter7.Value.ToString();
							if (text41.IndexOf("|Msg=CompanyAccess|", StringComparison.Ordinal) >= 0 || text41.IndexOf("|Msg=PrjAccess|", StringComparison.Ordinal) >= 0)
							{
								text41 = text41.Replace("|Msg=0", "").Replace("Msg=1", "").Replace("Msg=2", "")
									.Replace("Msg=3", "")
									.Replace("Msg=4", "")
									.Replace("Msg=5", "")
									.Replace("Msg=6", "")
									.Replace("Msg=7", "")
									.Replace("Dup=1Msg=0", "");
								if (text41.IndexOf("|Msg=CompanyAccess|", StringComparison.Ordinal) >= 0)
								{
									string[] array12 = text41.Split(new string[1] { "|Msg=CompanyAccess|" }, StringSplitOptions.None);
									if (array12 != null && Enumerable.Count<string>((IEnumerable<string>)array12) == 3)
									{
										if (!string.IsNullOrEmpty(array12[1]))
										{
											string[] array13 = array12[1].Split(new string[1] { "|CNVSID|" }, StringSplitOptions.None);
											if (array13 != null && Enumerable.Count<string>((IEnumerable<string>)array13) == 2)
											{
												string text43 = string.Format(Messages.MobMsgErrorrNotAccessToCompany, array13[1]);
												string newValue7 = "<CNVS><CNVSID>" + array13[0] + "<\\CNVSID><CNVSCOMPANY>" + text43 + "<\\CNVSCOMPANY><\\CNVS>";
												text41 = text41.Replace("|Msg=CompanyAccess|" + array12[1] + "|Msg=CompanyAccess|", newValue7);
											}
										}
									}
									else if (array12 != null && Enumerable.Count<string>((IEnumerable<string>)array12) > 3)
									{
										for (int m = 1; m < Enumerable.Count<string>((IEnumerable<string>)array12); m++)
										{
											if (!string.IsNullOrEmpty(array12[m]))
											{
												string[] array14 = array12[m].Split(new string[1] { "|CNVSID|" }, StringSplitOptions.None);
												if (array14 != null && Enumerable.Count<string>((IEnumerable<string>)array14) == 2)
												{
													string text44 = string.Format(Messages.MobMsgErrorrNotAccessToCompany, array14[1]);
													string newValue8 = "<CNVS><CNVSID>" + array14[0] + "<\\CNVSID><CNVSCOMPANY>" + text44 + "<\\CNVSCOMPANY><\\CNVS>";
													text41 = text41.Replace("|Msg=CompanyAccess|" + array12[m] + "|Msg=CompanyAccess|", newValue8);
												}
											}
										}
									}
								}
								if (text41.IndexOf("|Msg=PrjAccess|", StringComparison.Ordinal) >= 0)
								{
									string[] array15 = text41.Split(new string[1] { "|Msg=PrjAccess|" }, StringSplitOptions.None);
									if (array15 != null && Enumerable.Count<string>((IEnumerable<string>)array15) == 3)
									{
										if (!string.IsNullOrEmpty(array15[1]))
										{
											string[] array16 = array15[1].Split(new string[1] { "|CNVSID|" }, StringSplitOptions.None);
											if (array16 != null && Enumerable.Count<string>((IEnumerable<string>)array16) == 2)
											{
												string text45 = string.Format(Messages.MobMsgErrorrNotAccessToProject, array16[1]);
												string newValue9 = "<CNVS><CNVSID>" + array16[0] + "<\\CNVSID><CNVSPROJECT>" + text45 + "<\\CNVSPROJECT><\\CNVS>";
												text41 = text41.Replace("|Msg=PrjAccess|" + array15[1] + "|Msg=PrjAccess|", newValue9);
											}
										}
									}
									else if (array15 != null && Enumerable.Count<string>((IEnumerable<string>)array15) > 3)
									{
										for (int n = 1; n < Enumerable.Count<string>((IEnumerable<string>)array15); n++)
										{
											if (!string.IsNullOrEmpty(array15[n]))
											{
												string[] array17 = array15[n].Split(new string[1] { "|CNVSID|" }, StringSplitOptions.None);
												if (array17 != null && Enumerable.Count<string>((IEnumerable<string>)array17) == 2)
												{
													string text46 = string.Format(Messages.MobMsgErrorrNotAccessToProject, array17[1]);
													string newValue10 = "<CNVS><CNVSID>" + array17[0] + "<\\CNVSID><CNVSPROJECT>" + text46 + "<\\CNVSPROJECT><\\CNVS>";
													text41 = text41.Replace("|Msg=PrjAccess|" + array15[n] + "|Msg=PrjAccess|", newValue10);
												}
											}
										}
									}
								}
								loginByMobileResult.ErrorMessage = text41;
							}
							else
							{
								text41 = "";
							}
						}
						else
						{
							loginByMobileResult.ErrorMessage = "";
						}
					}
					if (objectParameter6.Value != null)
					{
						string text47 = objectParameter6.Value.ToString();
						loginByMobileResult.Conversations = text47.Substring(text47.IndexOf(",") + 1, text47.IndexOf("|") - 2) ?? "0";
					}
					else
					{
						loginByMobileResult.Conversations = "0";
					}
					if (objectParameter8.Value == null)
					{
						text = Messages.MobMsgErrorDoneOperation;
						status = ServiceResultStatus.Fail;
						return new ServiceResult<LoginByMobileResult>
						{
							Message = text,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
					}
					if (!(objectParameter8.Value.ToString() == "1"))
					{
						text = Messages.MobMsgErrorDoneOperation;
						status = ServiceResultStatus.Fail;
						return new ServiceResult<LoginByMobileResult>
						{
							Message = text,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
					}
					if (!string.IsNullOrEmpty(loginByMobileResult.ErrorMessage))
					{
						text = loginByMobileResult.ErrorMessage;
						status = ServiceResultStatus.Fail;
						return new ServiceResult<LoginByMobileResult>
						{
							Message = text,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
					}
				}
			}
			else
			{
				model.Company = model.Company.Replace("CompanyID=", "CompanyID=1");
				model.Persons = model.Persons.Replace("CompanyPersonID=", "CompanyPersonID=2");
				model.Persons = model.Persons.Replace("prsCompanyId=", "prsCompanyId=1");
				model.Projects = model.Projects.Replace("ProjectID=", "ProjectID=3");
				model.Projects = model.Projects.Replace("prjCompanyId=", "prjCompanyId=1");
				model.Conversations = model.Conversations.Replace("ConversationID=", "ConversationID=4");
				model.Conversations = model.Conversations.Replace("cnvsProjectId=", "cnvsProjectId=3");
				model.Conversations = model.Conversations.Replace("cnvsCompanyId=", "cnvsCompanyId=1");
				model.Conversations = model.Conversations.Replace("cnvsPersonId=", "cnvsPersonId=2");
				ObjectParameter objectParameter9 = new ObjectParameter("insertedCompanyId", 0);
				ObjectParameter objectParameter10 = new ObjectParameter("insertedPersonIds", "");
				ObjectParameter objectParameter11 = new ObjectParameter("insertedProjectIds", "");
				ObjectParameter objectParameter12 = new ObjectParameter("insertedConversationIds", "");
				ObjectParameter objectParameter13 = new ObjectParameter("errorMessage", "");
				ObjectParameter objectParameter14 = new ObjectParameter("typeTable", "");
				string text48 = "";
				string mobCnvsReferUserCmpNotAccess2 = Messages.MobCnvsReferUserCmpNotAccess;
				int value5 = 7;
				string text49 = "";
				string text50 = "";
				string text51 = "";
				foreach (MobspSelectLanguages_Result item5 in list)
				{
					text2 = "";
					text2 = "\r\n" + MyResource.GetResourceString("MobConversationErjaMultiUser", item5.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + " : {MultiUser}";
					text3 = "";
					text3 = "\r\n" + MyResource.GetResourceString("MobConversationErjaReferDescription", item5.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ":\r\n{CNVSREFERDESC}";
					mobCnvsReferUserCmpNotAccess2 = "";
					mobCnvsReferUserCmpNotAccess2 = MyResource.GetResourceString("MobCnvsReferUserCmpNotAccess", item5.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
					text49 = text49 + "MsgErjaMultiUser=" + text2 + "|@#@|LangId=" + item5.LanguageID + "|@#@||^#^|";
					text50 = text50 + "MsgReferDesc=" + text3 + "|@#@|LangId=" + item5.LanguageID + "|@#@||^#^|";
					text51 = text51 + "CmpNotAccess=" + mobCnvsReferUserCmpNotAccess2 + "|@#@|LangId=" + item5.LanguageID + "|@#@||^#^|";
				}
				text2 = text49;
				text3 = text50;
				mobCnvsReferUserCmpNotAccess2 = text51;
				string text52 = "";
				string text53 = "";
				text48 = "";
				foreach (MobspSelectLanguages_Result item6 in list)
				{
					text52 = "";
					text53 = "";
					text52 = MyResource.GetResourceString("MobConversationErjaFrom", item6.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + " " + Common.GetUserName(num2, result, item6.LanguageID, model.CenterId);
					text53 = MyResource.GetResourceString("MobConversationErjaInConnection", item6.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": {CMP}\r\n" + MyResource.GetResourceString("MobConversationErjaPerson", item6.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": {PRS}\r\n" + MyResource.GetResourceString("MobConversationErjaProject", item6.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": {PRJ}{MultiUser}";
					text53 = text53 + "\r\n\r\n" + MyResource.GetResourceString("MobConversationErjaConversationDescription", item6.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ":\r\n{CNVSDESC}{CNVSREFERDESC}";
					text53 = text53 + "\r\n\r\n" + MyResource.GetResourceString("MobConversationErjaDetails", item6.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
					text48 = text48 + "MsgSubj=" + text52 + "|@#@|MsgBody=" + text53 + "|@#@|LangId=" + item6.LanguageID + "|@#@||^#^|";
				}
				text52 = "";
				text53 = text48;
				string text54 = "";
				string text55 = "";
				text48 = "";
				foreach (MobspSelectLanguages_Result item7 in list)
				{
					text54 = "";
					text55 = "";
					text54 = MyResource.GetResourceString("MobConversationErjaNotice", item7.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": " + Common.GetUserName(num2, result, item7.LanguageID, model.CenterId);
					text55 = "**" + MyResource.GetResourceString("MobConversationErjaAutomatically", item7.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n\r\n" + MyResource.GetResourceString("MobConversationErjaAttention", item7.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + MyResource.GetResourceString("MobConversationErjaInConnection", item7.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": {CMP}\r\n" + MyResource.GetResourceString("MobConversationErjaPerson", item7.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": {PRS}\r\n" + MyResource.GetResourceString("MobConversationErjaProject", item7.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": {PRJ}\r\n\r\n" + MyResource.GetResourceString("MobConversationErjaLastNegotiator", item7.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ", " + MyResource.GetResourceString("MobConversationErjaTransmitter", item7.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "\r\n" + MyResource.GetResourceString("MobConversationErjaMultiUser", item7.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + "{MultiUser}\r\n\r\n" + MyResource.GetResourceString("MobConversationErjaConversationDescription", item7.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": \r\n{CNVSDESC}{CNVSREFERDESC}";
					text55 = text55 + "\r\n\r\n" + MyResource.GetResourceString("MobConversationErjaDetails", item7.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
					text48 = text48 + "MsgSubj=" + text54 + "|@#@|MsgBody=" + text55 + "|@#@|LangId=" + item7.LanguageID + "|@#@||^#^|";
				}
				text54 = "";
				text55 = text48;
				string text56 = "";
				string text57 = "";
				text48 = "";
				foreach (MobspSelectLanguages_Result item8 in list)
				{
					text56 = "";
					text57 = "";
					text56 = MyResource.GetResourceString("MobConversationErjaRonevesht", item8.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": " + Common.GetUserName(num2, result, item8.LanguageID, model.CenterId);
					text57 = MyResource.GetResourceString("MobConversationErjaInConnection", item8.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": {CMP} \r\n" + MyResource.GetResourceString("MobConversationErjaPerson", item8.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": {PRS} \r\n" + MyResource.GetResourceString("MobConversationErjaProject", item8.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": {PRJ}\r\n" + MyResource.GetResourceString("MobConversationErjaMultiUser", item8.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + " : {MultiUser}\r\n\r\n" + MyResource.GetResourceString("MobConversationErjaConversationDescription", item8.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly) + ": \r\n{CNVSDESC}{CNVSREFERDESC}";
					text57 = text57 + "\r\n\r\n" + MyResource.GetResourceString("MobConversationErjaDetails", item8.LanguageCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
					text48 = text48 + "MsgSubj=" + text56 + "|@#@|MsgBody=" + text57 + "|@#@|LangId=" + item8.LanguageID + "|@#@||^#^|";
				}
				text56 = "";
				text57 = text48;
				string text58 = "";
				string surveyMainExtrenalLinkLogin2 = "";
				string surveyMainExtrenalLink2 = "";
				string text59 = base.Request.RequestUri.GetLeftPart(UriPartial.Authority);
				string leftPart2 = base.Request.RequestUri.GetLeftPart(UriPartial.Scheme);
				if (text59.EndsWith("/"))
				{
					text59 = text59.TrimEnd(new char[1] { '/' });
				}
				text59 += "/Survey/Home/SurveyAnswerValues";
				text58 = text59;
				string text60 = "";
				MobspSelectCrmsysSetting_Result mobspSelectCrmsysSetting_Result2 = SysSeting.Get();
				string text61 = "";
				string text62 = "";
				if (mobspSelectCrmsysSetting_Result2 != null)
				{
					text61 = mobspSelectCrmsysSetting_Result2.FOUrl ?? "";
					text62 = mobspSelectCrmsysSetting_Result2.CrmIPStatic ?? "";
				}
				if (!string.IsNullOrWhiteSpace(text61))
				{
					text60 = text61.Trim();
					if (!text60.Contains("http"))
					{
						text60 = leftPart2 + text60;
					}
					if (text60.EndsWith("/"))
					{
						text60 = text60.TrimEnd(new char[1] { '/' });
					}
					text60 += "/Survey/Home";
					surveyMainExtrenalLinkLogin2 = text60;
				}
				if (!string.IsNullOrWhiteSpace(text62))
				{
					text60 = text62.Trim();
					if (!text60.Contains("http"))
					{
						text60 = leftPart2 + text60;
					}
					if (text60.EndsWith("/"))
					{
						text60 = text60.TrimEnd(new char[1] { '/' });
					}
					text60 += "/Survey/Register/Index";
				}
				int maxFOCount2 = Mobile.Classes.Configuration.MaxFOCount;
				string encryptionKey = XorCipher.PreparePublicKeyForSql();
				CRMEntities cRMEntities5 = cRMEntities;
				string company2 = model.Company;
				string persons3 = model.Persons;
				string projects = model.Projects;
				string conversations2 = model.Conversations;
				int? userId4 = num2;
				short? year3 = value2;
				short? month3 = value3;
				DateTime? registerDate3 = value;
				int? languageID4 = num;
				int? defaultLanguageID4 = result;
				string needErjaRefmsgSubj2 = text52;
				string needErjaRefmsgBody2 = text53;
				string needErjaMultiIntmsgSubject2 = text56;
				string needErjaMultiIntmsgBody2 = text57;
				string needSendErjaAllarmRefmsgSubj2 = text54;
				string needSendErjaAllarmRefmsgBody2 = text55;
				string msgConversationErjaMultiUser2 = text2;
				string msgConversationErjaReferDescription2 = text3;
				string personLabel = mobCnvsReferUserCmpNotAccess2;
				int? num7 = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities5.MobspInsertQuickCmpPrsPrjCnvs(company2, persons3, projects, conversations2, null, userId4, year3, month3, registerDate3, registerDatePersian, appType, languageID4, defaultLanguageID4, mobPersonLabel, needErjaRefmsgSubj2, needErjaRefmsgBody2, needErjaMultiIntmsgSubject2, needErjaMultiIntmsgBody2, needSendErjaAllarmRefmsgSubj2, needSendErjaAllarmRefmsgBody2, mobConversationErjaShow, msgConversationErjaMultiUser2, msgConversationErjaReferDescription2, objectParameter9, objectParameter10, objectParameter11, objectParameter12, null, objectParameter13, objectParameter14, value5, personLabel, text58, surveyMainExtrenalLink2, surveyMainExtrenalLinkLogin2, conversationErjaShow, eventErjaRefmsg, model.CenterId, encryptionKey, maxFOCount2));
				string text63 = "";
				if (objectParameter13.Value != null)
				{
					if (objectParameter13.Value.ToString() != "")
					{
						string text64 = objectParameter13.Value.ToString();
						text64 = text64.Replace("|Msg=0", "<CMP>" + Messages.MobMsgErrorInsertCompany + "<\\CMP>");
						text64 = text64.Replace("Msg=1", "<CMP>" + Messages.MobMsgErrorInconsistencyInCompanySelection + "<\\CMP>");
						text64 = text64.Replace("Msg=2", "<PRS>" + Messages.MobMsgErrorInsertPersons + "<\\PRS>");
						text64 = text64.Replace("Msg=3", "<PRS>" + Messages.MobMsgErrorInsertPerson + "<\\PRS>");
						text64 = text64.Replace("Msg=4", "<PRj>" + Messages.MobMsgErrorInsertProjects + "<\\PRj>");
						text64 = text64.Replace("Msg=5", "<PRj>" + Messages.MobMsgErrorInsertProject + "<\\PRj>");
						text64 = text64.Replace("Msg=6", "<CNVS>" + Messages.MobMsgErrorInsertSms + "<\\CNVS>");
						text64 = text64.Replace("Msg=7", "<CNVS>" + Messages.MobMsgErrorInsertConversation + "<\\CNVS>");
						text64 = text64.Replace("Dup=1Msg=0", "<CMP>" + Messages.MobMsgErrorNotInsertDuplicateCompany + "<\\CMP>");
						loginByMobileResult.ErrorMessage = text64;
						text63 = objectParameter13.Value.ToString();
						if (text63.IndexOf("|Msg=CmpGroupIdAccess|", StringComparison.Ordinal) >= 0 || text63.IndexOf("|Msg=CmpSubGroupIdAccess|", StringComparison.Ordinal) >= 0 || text63.IndexOf("|Msg=CmpGroupIdIVAccess|", StringComparison.Ordinal) >= 0 || text63.IndexOf("|Msg=CmpProvinceIdAccess|", StringComparison.Ordinal) >= 0 || text63.IndexOf("|Msg=CmpCityIdAccess|", StringComparison.Ordinal) >= 0 || text63.IndexOf("|Msg=PrjAccess|", StringComparison.Ordinal) >= 0)
						{
							text63 = text63.Replace("|Msg=0", "").Replace("Msg=1", "").Replace("Msg=2", "")
								.Replace("Msg=3", "")
								.Replace("Msg=4", "")
								.Replace("Msg=5", "")
								.Replace("Msg=6", "")
								.Replace("Msg=7", "")
								.Replace("Dup=1Msg=0", "");
							if (text63.IndexOf("|Msg=CmpGroupIdAccess|", StringComparison.Ordinal) >= 0)
							{
								string[] array18 = text63.Split(new string[1] { "|Msg=CmpGroupIdAccess|" }, StringSplitOptions.None);
								if (array18 != null && Enumerable.Count<string>((IEnumerable<string>)array18) == 3 && !string.IsNullOrEmpty(array18[1]))
								{
									string newValue11 = "<CMP>" + string.Format(Messages.MobMsgErrorrNotAccessToCmpGroup, array18[1]) + "<\\CMP>";
									text63 = text63.Replace("|Msg=CmpGroupIdAccess|" + array18[1] + "|Msg=CmpGroupIdAccess|", newValue11);
								}
							}
							if (text63.IndexOf("|Msg=CmpSubGroupIdAccess|", StringComparison.Ordinal) >= 0)
							{
								string[] array19 = text63.Split(new string[1] { "|Msg=CmpSubGroupIdAccess|" }, StringSplitOptions.None);
								if (array19 != null && Enumerable.Count<string>((IEnumerable<string>)array19) == 3 && !string.IsNullOrEmpty(array19[1]))
								{
									string newValue12 = "<CMP>" + string.Format(Messages.MobMsgErrorrNotAccessToCmpSubGroup, array19[1]) + "<\\CMP>";
									text63 = text63.Replace("|Msg=CmpSubGroupIdAccess|" + array19[1] + "|Msg=CmpSubGroupIdAccess|", newValue12);
								}
							}
							if (text63.IndexOf("|Msg=CmpGroupIdIVAccess|", StringComparison.Ordinal) >= 0)
							{
								string[] array20 = text63.Split(new string[1] { "|Msg=CmpGroupIdIVAccess|" }, StringSplitOptions.None);
								if (array20 != null && Enumerable.Count<string>((IEnumerable<string>)array20) == 3 && !string.IsNullOrEmpty(array20[1]))
								{
									string newValue13 = "<CMP>" + string.Format(Messages.MobMsgErrorrNotAccessToCmpGroupIV, array20[1]) + "<\\CMP>";
									text63 = text63.Replace("|Msg=CmpGroupIdIVAccess|" + array20[1] + "|Msg=CmpGroupIdIVAccess|", newValue13);
								}
							}
							if (text63.IndexOf("|Msg=CmpProvinceIdAccess|", StringComparison.Ordinal) >= 0)
							{
								string[] array21 = text63.Split(new string[1] { "|Msg=CmpProvinceIdAccess|" }, StringSplitOptions.None);
								if (array21 != null && Enumerable.Count<string>((IEnumerable<string>)array21) == 3 && !string.IsNullOrEmpty(array21[1]))
								{
									string newValue14 = "<CMP>" + string.Format(Messages.MobMsgErrorrNotAccessToProvince, array21[1]) + "<\\CMP>";
									text63 = text63.Replace("|Msg=CmpProvinceIdAccess|" + array21[1] + "|Msg=CmpProvinceIdAccess|", newValue14);
								}
							}
							if (text63.IndexOf("|Msg=CmpCityIdAccess|", StringComparison.Ordinal) >= 0)
							{
								string[] array22 = text63.Split(new string[1] { "|Msg=CmpCityIdAccess|" }, StringSplitOptions.None);
								if (array22 != null && Enumerable.Count<string>((IEnumerable<string>)array22) == 3 && !string.IsNullOrEmpty(array22[1]))
								{
									string newValue15 = "<CMP>" + string.Format(Messages.MobMsgErrorrNotAccessToCity, array22[1]) + "<\\CMP>";
									text63 = text63.Replace("|Msg=CmpCityIdAccess|" + array22[1] + "|Msg=CmpCityIdAccess|", newValue15);
								}
							}
							if (text63.IndexOf("|Msg=PrjAccess|", StringComparison.Ordinal) >= 0)
							{
								string[] array23 = text63.Split(new string[1] { "|Msg=PrjAccess|" }, StringSplitOptions.None);
								if (array23 != null && Enumerable.Count<string>((IEnumerable<string>)array23) == 3)
								{
									if (!string.IsNullOrEmpty(array23[1]))
									{
										string[] array24 = array23[1].Split(new string[1] { "|PRJID|" }, StringSplitOptions.None);
										if (array24 != null && Enumerable.Count<string>((IEnumerable<string>)array24) == 2)
										{
											string text65 = string.Format(Messages.MobMsgErrorrNotAccessToProject, array24[1]);
											string newValue16 = "<PRJ><PRJID>" + array24[0] + "<\\PRJID><PRJTITLE>" + text65 + "<\\PRJTITLE><\\PRJ>";
											text63 = text63.Replace("|Msg=PrjAccess|" + array23[1] + "|Msg=PrjAccess|", newValue16);
										}
									}
								}
								else if (array23 != null && Enumerable.Count<string>((IEnumerable<string>)array23) > 3)
								{
									for (int num8 = 1; num8 < Enumerable.Count<string>((IEnumerable<string>)array23); num8++)
									{
										if (!string.IsNullOrEmpty(array23[num8]))
										{
											string[] array25 = array23[num8].Split(new string[1] { "|PRJID|" }, StringSplitOptions.None);
											if (array25 != null && Enumerable.Count<string>((IEnumerable<string>)array25) == 2)
											{
												string text66 = string.Format(Messages.MobMsgErrorrNotAccessToProject, array25[1]);
												string newValue17 = "<PRJ><PRJID>" + array25[0] + "<\\PRJID><PRJTITLE>" + text66 + "<\\PRJTITLE><\\PRJ>";
												text63 = text63.Replace("|Msg=PrjAccess|" + array23[num8] + "|Msg=PrjAccess|", newValue17);
											}
										}
									}
								}
							}
							loginByMobileResult.ErrorMessage = text63;
						}
						else
						{
							text63 = "";
						}
					}
					else
					{
						loginByMobileResult.ErrorMessage = "";
					}
				}
				if (objectParameter9.Value != null)
				{
					loginByMobileResult.Company = objectParameter9.Value.ToString() ?? "0";
				}
				else
				{
					loginByMobileResult.Company = "0";
				}
				if (objectParameter10.Value != null)
				{
					string text67 = objectParameter10.Value.ToString();
					loginByMobileResult.Persons = text67.Substring(text67.IndexOf(",") + 1, text67.IndexOf("|") - 2) ?? "0";
				}
				else
				{
					loginByMobileResult.Persons = "0";
				}
				if (objectParameter11.Value != null)
				{
					string text68 = objectParameter11.Value.ToString();
					loginByMobileResult.Projects = text68.Substring(text68.IndexOf(",") + 1, text68.IndexOf("|") - 2) ?? "0";
				}
				else
				{
					loginByMobileResult.Projects = "0";
				}
				if (objectParameter12.Value != null)
				{
					string text69 = objectParameter12.Value.ToString();
					loginByMobileResult.Conversations = text69.Substring(text69.IndexOf(",") + 1, text69.IndexOf("|") - 2) ?? "0";
				}
				else
				{
					loginByMobileResult.Conversations = "0";
				}
				if (objectParameter14.Value != null)
				{
					loginByMobileResult.Type = objectParameter14.Value.ToString() ?? "";
				}
				else
				{
					loginByMobileResult.Type = "";
				}
				if (num7.HasValue && !(num7 >= 1))
				{
					text = Messages.MobMsgErrorDoneOperation;
					status = ServiceResultStatus.Fail;
					return new ServiceResult<LoginByMobileResult>
					{
						Message = text,
						Data = null,
						Status = ServiceResultStatus.Fail
					};
				}
				if (loginByMobileResult.Type == "Dup")
				{
					ObjectParameter objectParameter15 = new ObjectParameter("errorMessage", "");
					CRMEntities cRMEntities6 = cRMEntities;
					string company3 = model.Company;
					string persons4 = model.Persons;
					personLabel = mobPersonLabel;
					string projects2 = model.Projects;
					int? id2 = 0;
					int? userId5 = num2;
					int? languageID5 = num;
					int? defaultLanguageID5 = result;
					ObjectParameter insertedPersonIds = objectParameter15;
					int? mode = 0;
					cRMEntities6.MobspCheckDuplicateCompanyWithReason(company3, persons4, projects2, id2, userId5, languageID5, defaultLanguageID5, mobLackOfShowText, personLabel, mode, insertedPersonIds, model.CenterId);
					if (objectParameter15.Value != null && objectParameter15.Value.ToString() != "")
					{
						string text70 = objectParameter15.Value.ToString();
						string text71 = "";
						if (text70 != "")
						{
							string[] array4 = text70.Split(new string[1] { "|^|" }, StringSplitOptions.None);
							foreach (string text72 in array4)
							{
								if (!string.IsNullOrEmpty(text72))
								{
									string[] array26 = text72.Split(new char[1] { ',' });
									string text73 = "";
									string text74 = "";
									string text75 = "";
									string text76 = "";
									string text77 = "";
									string text78 = "";
									string text79 = "";
									if (array26[0] == "@cmpName=Dup")
									{
										text73 = array26[3].Replace("@DupCmpName=", "") ?? "";
										text74 = array26[2].Replace("@DupCmpTitle=", "") ?? "";
										text75 = array26[4].Replace("@DupCmpCity=", "") ?? "";
										text76 = array26[5].Replace("@DupCmpNumber=", "") ?? "";
										text71 = text71 + "<CMP>" + string.Format(Messages.MobMsgErrorCheckCmpNameDuplicate, text73, text74, text75, text76) + "<\\CMP>";
									}
									else if (array26[0] == "@cmpName=IsNull")
									{
										text71 = text71 + "<CMP>" + Messages.MobMsgErrorCmpNameNotEntered + "<\\CMP>";
									}
									else if (array26[0] == "@cmpTel=Dup")
									{
										text73 = array26[3].Replace("@DupCmpName=", "") ?? "";
										text74 = array26[2].Replace("@DupCmpTitle=", "") ?? "";
										text75 = array26[4].Replace("@DupCmpCity=", "") ?? "";
										text76 = array26[5].Replace("@DupCmpNumber=", "") ?? "";
										text71 = text71 + "<CMP>" + string.Format(Messages.MobMsgErrorCheckCmpTelDuplicate, text73, text74, text75, text76) + "<\\CMP>";
									}
									else if (array26[0] == "@cmpTelII=Dup")
									{
										text73 = array26[3].Replace("@DupCmpName=", "") ?? "";
										text74 = array26[2].Replace("@DupCmpTitle=", "") ?? "";
										text75 = array26[4].Replace("@DupCmpCity=", "") ?? "";
										text76 = array26[5].Replace("@DupCmpNumber=", "") ?? "";
										text71 = text71 + "<CMP>" + string.Format(Messages.MobMsgErrorCheckCmpTelIIDuplicate, text73, text74, text75, text76) + "<\\CMP>";
									}
									else if (array26[0] == "@cmpFax=Dup")
									{
										text73 = array26[3].Replace("@DupCmpName=", "") ?? "";
										text74 = array26[2].Replace("@DupCmpTitle=", "") ?? "";
										text75 = array26[4].Replace("@DupCmpCity=", "") ?? "";
										text76 = array26[5].Replace("@DupCmpNumber=", "") ?? "";
										text71 = text71 + "<CMP>" + string.Format(Messages.MobMsgErrorCheckCmpFaxDuplicate, text73, text74, text75, text76) + "<\\CMP>";
									}
									else if (array26[0] == "@prsLName=Dup")
									{
										text79 = array26[2].Replace("@CompanyPersonID=", "") ?? "";
										text77 = array26[1].Replace("@prsLName=", "") ?? "";
										text78 = array26[4].Replace("@prsFName=", "") ?? "";
										text73 = array26[7].Replace("@DupCmpName=", "") ?? "";
										text74 = array26[6].Replace("@DupCmpTitle=", "") ?? "";
										text75 = array26[8].Replace("@DupCmpCity=", "") ?? "";
										text76 = array26[9].Replace("@DupCmpNumber=", "") ?? "";
										text71 = text71 + "<PRS><PRSID>" + text79 + "<\\PRSID>" + string.Format(Messages.MobMsgErrorCheckPrsLNameDuplicate, text78 + " " + text77, text73, text74, text75, text76) + "<\\PRS>";
									}
									if (array26[0] == "@prsLName=IsNull")
									{
										text71 = text71 + "<PRS>" + Messages.MobMsgErrorPrsLNameNotEntered + "<\\PRS>";
									}
									else if (array26[0] == "@prsTel=Dup")
									{
										text79 = array26[2].Replace("@CompanyPersonID=", "") ?? "";
										text77 = array26[1].Replace("@prsLName=", "") ?? "";
										text78 = array26[4].Replace("@prsFName=", "") ?? "";
										text73 = array26[7].Replace("@DupCmpName=", "") ?? "";
										text74 = array26[6].Replace("@DupCmpTitle=", "") ?? "";
										text75 = array26[8].Replace("@DupCmpCity=", "") ?? "";
										text76 = array26[9].Replace("@DupCmpNumber=", "") ?? "";
										text71 = text71 + "<PRS><PRSID>" + text79 + "<\\PRSID>" + string.Format(Messages.MobMsgErrorCheckPrsTelDuplicate, text78 + " " + text77, text73, text74, text75, text76) + "<\\PRS>";
									}
									else if (array26[0] == "@prsTelII=Dup")
									{
										text79 = array26[2].Replace("@CompanyPersonID=", "") ?? "";
										text77 = array26[1].Replace("@prsLName=", "") ?? "";
										text78 = array26[4].Replace("@prsFName=", "") ?? "";
										text73 = array26[7].Replace("@DupCmpName=", "") ?? "";
										text74 = array26[6].Replace("@DupCmpTitle=", "") ?? "";
										text75 = array26[8].Replace("@DupCmpCity=", "") ?? "";
										text76 = array26[9].Replace("@DupCmpNumber=", "") ?? "";
										text71 = text71 + "<PRS><PRSID>" + text79 + "<\\PRSID>" + string.Format(Messages.MobMsgErrorCheckPrsTelIIDuplicate, text78 + " " + text77, text73, text74, text75, text76) + "<\\PRS>";
									}
									else if (array26[0] == "@prsFax=Dup")
									{
										text79 = array26[2].Replace("@CompanyPersonID=", "") ?? "";
										text77 = array26[1].Replace("@prsLName=", "") ?? "";
										text78 = array26[4].Replace("@prsFName=", "") ?? "";
										text73 = array26[7].Replace("@DupCmpName=", "") ?? "";
										text74 = array26[6].Replace("@DupCmpTitle=", "") ?? "";
										text75 = array26[8].Replace("@DupCmpCity=", "") ?? "";
										text76 = array26[9].Replace("@DupCmpNumber=", "") ?? "";
										text71 = text71 + "<PRS><PRSID>" + text79 + "<\\PRSID>" + string.Format(Messages.MobMsgErrorCheckPrsFaxDuplicate, text78 + " " + text77, text73, text74, text75, text76) + "<\\PRS>";
									}
									else if (array26[0] == "@prsMobile=Dup")
									{
										text79 = array26[3].Replace("@CompanyPersonID=", "") ?? "";
										text77 = array26[1].Replace("@prsLName=", "") ?? "";
										text78 = array26[2].Replace("@prsFName=", "") ?? "";
										text76 = array26[5].Replace("@DupCmpNumber=", "") ?? "";
										text71 = text71 + "<PRS><PRSID>" + text79 + "<\\PRSID>" + string.Format(Messages.MobMsgErrorCheckPrsMobileDuplicate, text78 + " " + text77, text76) + "<\\PRS>";
									}
									else if (array26[0] == "@prsEmail=Dup")
									{
										text79 = array26[3].Replace("@CompanyPersonID=", "") ?? "";
										text77 = array26[1].Replace("@prsLName=", "") ?? "";
										text78 = array26[2].Replace("@prsFName=", "") ?? "";
										text76 = array26[5].Replace("@DupCmpNumber=", "") ?? "";
										text71 = text71 + "<PRS><PRSID>" + text79 + "<\\PRSID>" + string.Format(Messages.MobMsgErrorCheckPrsEmailDuplicate, text78 + " " + text77, text76) + "<\\PRS>";
									}
									else if (array26[0] == "@prsEmailII=Dup")
									{
										text79 = array26[3].Replace("@CompanyPersonID=", "") ?? "";
										text77 = array26[1].Replace("@prsLName=", "") ?? "";
										text78 = array26[2].Replace("@prsFName=", "") ?? "";
										text76 = array26[5].Replace("@DupCmpNumber=", "") ?? "";
										text71 = text71 + "<PRS><PRSID>" + text79 + "<\\PRSID>" + string.Format(Messages.MobMsgErrorCheckPrsEmailIIDuplicate, text78 + " " + text77, text76) + "<\\PRS>";
									}
									else if (array26[0] == "@prjPostFix=Dup")
									{
										text73 = array26[1].Replace("@DupCmpName=", "") ?? "";
										text76 = array26[2].Replace("@DupCmpNumber=", "") ?? "";
										text71 = text71 + "<PRJ>" + string.Format(Messages.CheckDuplicatePrjPostFix, text76, text73) + "<\\PRJ>";
									}
									else if (array26[0] == "@prjDesc=Dup")
									{
										text73 = array26[1].Replace("@DupCmpName=", "") ?? "";
										text76 = array26[2].Replace("@DupCmpNumber=", "") ?? "";
										text71 = text71 + "<PRJ>" + string.Format(Messages.CheckDuplicatePrjDesc, text76, text73) + "<\\PRJ>";
									}
									else if (array26[0] == "@prjNumRef=Dup")
									{
										text73 = array26[1].Replace("@DupCmpName=", "") ?? "";
										text76 = array26[2].Replace("@DupCmpNumber=", "") ?? "";
										text71 = text71 + "<PRJ>" + string.Format(Messages.CheckDuplicatePrjNumRef, text76, text73) + "<\\PRJ>";
									}
									else if (array26[0] == "@prjInquiryNum=Dup")
									{
										text73 = array26[1].Replace("@DupCmpName=", "") ?? "";
										text76 = array26[2].Replace("@DupCmpNumber=", "") ?? "";
										text71 = text71 + "<PRJ>" + string.Format(Messages.CheckDuplicatePrjInquiryNum, text76, text73) + "<\\PRJ>";
									}
									else if (array26[0] == "@prjNumR=Dup")
									{
										text73 = array26[1].Replace("@DupCmpName=", "") ?? "";
										text76 = array26[2].Replace("@DupCmpNumber=", "") ?? "";
										text71 = text71 + "<PRJ>" + string.Format(Messages.CheckDuplicatePrjNumR, text76, text73) + "<\\PRJ>";
									}
								}
							}
						}
						loginByMobileResult.ErrorMessage = text63 + " " + text71;
					}
				}
				if (!string.IsNullOrEmpty(loginByMobileResult.ErrorMessage))
				{
					text = loginByMobileResult.ErrorMessage;
					status = ServiceResultStatus.Fail;
					return new ServiceResult<LoginByMobileResult>
					{
						Message = text,
						Data = null,
						Status = ServiceResultStatus.Fail
					};
				}
			}
			if (string.IsNullOrEmpty(text) && loginByMobileResult != null)
			{
				Random random = new Random();
				loginByMobileResult.AuthenticationCode = random.Next(10000, 99999).ToString();
				RandomText randomText = new RandomText();
				string getString = randomText.CreateRandomCode(5, WithNumber: true).Replace(" ", "").Trim() + "|" + loginByMobileResult.Company + "|" + randomText.CreateRandomCode(5, WithNumber: true).Replace(" ", "").Trim() + "|" + loginByMobileResult.Persons + "|" + randomText.CreateRandomCode(5, WithNumber: true).Replace(" ", "").Trim() + "|" + loginByMobileResult.AuthenticationCode + "|" + randomText.CreateRandomCode(5, WithNumber: true).Replace(" ", "").Trim() + "|" + DateTime.Now.ToString("yyyyMMdd-HHmmss", new PersianCulture()) + "|" + randomText.CreateRandomCode(5, WithNumber: true).Replace(" ", "").Trim();
				loginByMobileResult.Token = CodeDecode.Codding(getString);
				Sms sms = new Sms();
				SmsSendViewModel newSms = new SmsSendViewModel
				{
					SendType = 1,
					Sid = -1,
					SmsNumberCount = 1,
					LangId = model.LangId,
					CompaniesId = loginByMobileResult.Company,
					CompanyPersonsId = loginByMobileResult.Persons,
					UserId = num2,
					SmsToNumber = model.mobileNumber,
					Cmessage = 1,
					SmsSendBody = "کد احراز هویت: " + loginByMobileResult.AuthenticationCode + "\n*تعمیرکار هوم*\nwww.tamirkar.app"
				};
				text = sms.SendSmsSingle(newSms, isCodeVerification: true, int.Parse(loginByMobileResult.AuthenticationCode));
				if (string.IsNullOrEmpty(text))
				{
					status = ServiceResultStatus.Success;
				}
				else
				{
					loginByMobileResult = null;
					status = ServiceResultStatus.Error;
				}
			}
			PushNotif.NewIntMsgNotify();
		}
		catch (Exception e)
		{
			text = Messages.MobMsgErrorDoneOperation;
			loginByMobileResult = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<LoginByMobileResult>
		{
			Message = text,
			Data = loginByMobileResult,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<CmpAuthenticationByMobileModel> CmpAuthenticationByMobNum(CmpAuthenticationByMobileModel model)
	{
		CmpAuthenticationByMobileModel cmpAuthenticationByMobileModel = new CmpAuthenticationByMobileModel();
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		CRMEntities cRMEntities = null;
		try
		{
			int result = 1065;
			if (model.LangId.HasValue)
			{
				int.TryParse(model.LangId.ToString(), out result);
			}
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			cRMEntities = new CRMEntities();
			MobspCheckDuplicateCmpMobile_Result company = Enumerable.FirstOrDefault<MobspCheckDuplicateCmpMobile_Result>((IEnumerable<MobspCheckDuplicateCmpMobile_Result>)cRMEntities.MobspCheckDuplicateCmpMobile(model.MobileNumber, 0, result, result2));
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
			message = Messages.MobMsgSuccessAction;
			cmpAuthenticationByMobileModel.Company = company;
			status = ServiceResultStatus.Success;
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
			cRMEntities?.Dispose();
		}
		return new ServiceResult<CmpAuthenticationByMobileModel>
		{
			Message = message,
			Data = cmpAuthenticationByMobileModel,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<PrsAuthenticationByMobileNumberModel> PrsAuthenticationByMobNum(PrsAuthenticationByMobileNumberModel model)
	{
		PrsAuthenticationByMobileNumberModel prsAuthenticationByMobileNumberModel = new PrsAuthenticationByMobileNumberModel();
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		CRMEntities cRMEntities = null;
		try
		{
			int result = 1065;
			if (model.LangId.HasValue)
			{
				int.TryParse(model.LangId.ToString(), out result);
			}
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			cRMEntities = new CRMEntities();
			MobspCheckDuplicatePrsMobileByCmpId_Result person = Enumerable.FirstOrDefault<MobspCheckDuplicatePrsMobileByCmpId_Result>((IEnumerable<MobspCheckDuplicatePrsMobileByCmpId_Result>)cRMEntities.MobspCheckDuplicatePrsMobileByCmpId(model.MobileNumber, model.CompanyId, 0, result, result2));
			message = Messages.MobMsgSuccessAction;
			prsAuthenticationByMobileNumberModel.Person = person;
			status = ServiceResultStatus.Success;
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			prsAuthenticationByMobileNumberModel = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<PrsAuthenticationByMobileNumberModel>
		{
			Message = message,
			Data = prsAuthenticationByMobileNumberModel,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<string> SendAuthenticationCodeBySMS(SendSMSModel model)
	{
		string text = "";
		ServiceResultStatus serviceResultStatus = ServiceResultStatus.Fail;
		string text2;
		try
		{
			text2 = new Random().Next(10000, 99999).ToString();
			if (text2 != null || text2 != null)
			{
				Sms sms = new Sms();
				SmsSendViewModel newSms = new SmsSendViewModel
				{
					SendType = 1,
					Sid = -1,
					SmsNumberCount = 1,
					LangId = model.LangId,
					CompaniesId = (model.CompanyId ?? ""),
					CompanyPersonsId = (model.PersonId ?? ""),
					UserId = model.UserId,
					SmsToNumber = model.MobileNumber,
					Cmessage = 1,
					SmsSendBody = "کد احراز هویت: " + text2 + "\n" + model.SMSBody
				};
				text = sms.SendSmsSingle(newSms, isCodeVerification: true, int.Parse(text2));
				if (string.IsNullOrEmpty(text))
				{
					serviceResultStatus = ServiceResultStatus.Success;
				}
				else
				{
					text2 = null;
					serviceResultStatus = ServiceResultStatus.Error;
				}
			}
			else
			{
				text2 = null;
				serviceResultStatus = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			text = Messages.MobMsgErrorDoneOperation;
			text2 = null;
			serviceResultStatus = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return new ServiceResult<string>
		{
			Message = text,
			Data = text2,
			Status = serviceResultStatus
		};
	}

	[HttpPost]
	public async Task<ServiceResult<byte[]>> ScanQRLogin()
	{
		string encryptedData = Convert.ToBase64String(await base.Request.Content.ReadAsByteArrayAsync());
		ScanQRLoginResultViewModel scanQRLoginResultViewModel = new ScanQRLoginResultViewModel();
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		CRMEntities cRMEntities = null;
		CRMSpEntities cRMSpEntities = null;
		ScanQRLoginViewModel login = null;
		Security security = new Security();
		byte[] data = null;
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			int result2 = 1065;
			if (base.Request.Headers.Contains("LangId"))
			{
				int.TryParse(Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("LangId")), out result2);
			}
			if (result2 == 0)
			{
				result2 = 1065;
			}
			BaseInfo baseInfo = new BaseInfo();
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
				login = JsonConvert.DeserializeObject<ScanQRLoginViewModel>(decodedDataModel.Body);
			}
			string text3 = "";
			if (!decodedDataModel.Extra.IsNullOrWhiteSpace())
			{
				text3 = decodedDataModel.Extra;
			}
			if (new Common().CheckExtra(text3))
			{
				string userPassword = baseInfo.ConvertMd5(login.password).ToLower();
				MobspLoadUserLoginInfo_Result mobspLoadUserLoginInfo_Result = Enumerable.FirstOrDefault<MobspLoadUserLoginInfo_Result>((IEnumerable<MobspLoadUserLoginInfo_Result>)cRMEntities.MobspLoadUserLoginInfo(0, login.username, userPassword, result2, result));
				if (mobspLoadUserLoginInfo_Result != null)
				{
					if (!mobspLoadUserLoginInfo_Result.UserIsActiveInMobApp.GetValueOrDefault())
					{
						return new ServiceResult<byte[]>
						{
							Message = Messages.MobMsgErrorHaveNotAccessUseMobApp,
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
						List<MobspSelectUserAppDeviceInfoByUserId_Result> list2 = Enumerable.ToList<MobspSelectUserAppDeviceInfoByUserId_Result>((IEnumerable<MobspSelectUserAppDeviceInfoByUserId_Result>)cRMSpEntities.MobspSelectUserAppDeviceInfoByUserId(mobspLoadUserLoginInfo_Result.UserId, login.projectAppName));
						int num2 = Enumerable.Count<MobspSelectUserAppDeviceInfoByUserId_Result>(Enumerable.Where<MobspSelectUserAppDeviceInfoByUserId_Result>((IEnumerable<MobspSelectUserAppDeviceInfoByUserId_Result>)list2, (Func<MobspSelectUserAppDeviceInfoByUserId_Result, bool>)((MobspSelectUserAppDeviceInfoByUserId_Result e) => !e.DeviceDeactive.GetValueOrDefault())));
						MobspSelectUserAppDeviceInfoByUserId_Result mobspSelectUserAppDeviceInfoByUserId_Result = Enumerable.FirstOrDefault<MobspSelectUserAppDeviceInfoByUserId_Result>(Enumerable.Where<MobspSelectUserAppDeviceInfoByUserId_Result>((IEnumerable<MobspSelectUserAppDeviceInfoByUserId_Result>)list2, (Func<MobspSelectUserAppDeviceInfoByUserId_Result, bool>)((MobspSelectUserAppDeviceInfoByUserId_Result e) => e.ImeiCode == login.imeiCode)));
						if (mobspSelectUserAppDeviceInfoByUserId_Result != null)
						{
							if (mobspSelectUserAppDeviceInfoByUserId_Result.DeviceDeactive.GetValueOrDefault())
							{
								if (num2 >= mobspLoadUserLoginInfo_Result.MobUserAppUseCnt.GetValueOrDefault())
								{
									return new ServiceResult<byte[]>
									{
										Message = string.Format(Messages.MobMsgMaxMobDeviceUseReached, mobspLoadUserLoginInfo_Result.MobUserAppUseCnt.GetValueOrDefault()),
										Data = null,
										Status = ServiceResultStatus.Fail
									};
								}
								List<MobspSelectActiveUserAppDeviceInfoByImeiCode_Result> list3 = Enumerable.ToList<MobspSelectActiveUserAppDeviceInfoByImeiCode_Result>((IEnumerable<MobspSelectActiveUserAppDeviceInfoByImeiCode_Result>)cRMSpEntities.MobspSelectActiveUserAppDeviceInfoByImeiCode(login.imeiCode, login.projectAppName));
								if (Enumerable.Any<MobspSelectActiveUserAppDeviceInfoByImeiCode_Result>((IEnumerable<MobspSelectActiveUserAppDeviceInfoByImeiCode_Result>)list3))
								{
									if (!Common.IsKara())
									{
										string userName = Mobile.Classes.Helper.User.GetUserName(Enumerable.First<MobspSelectActiveUserAppDeviceInfoByImeiCode_Result>((IEnumerable<MobspSelectActiveUserAppDeviceInfoByImeiCode_Result>)list3).UserId, num, result);
										return new ServiceResult<byte[]>
										{
											Message = string.Format(Messages.MobMsgThisDeviceIsTakenForUser, userName),
											Data = null,
											Status = ServiceResultStatus.Fail
										};
									}
									foreach (MobspSelectActiveUserAppDeviceInfoByImeiCode_Result item in list3)
									{
										cRMSpEntities.MobspDeactiveUserAppDeviceInfo(item.UserAppDeviceInfoId, value, text4, appType);
									}
								}
							}
							cRMSpEntities.MobspUpdateUserAppDeviceInfoById(mobspSelectUserAppDeviceInfoByUserId_Result.UserAppDeviceInfoId, login.deviceId ?? mobspSelectUserAppDeviceInfoByUserId_Result.DeviceId, login.deviceProperty ?? mobspSelectUserAppDeviceInfoByUserId_Result.DeviceProperty, value, text4, appType, aESKey);
						}
						else
						{
							if (num2 >= mobspLoadUserLoginInfo_Result.MobUserAppUseCnt.GetValueOrDefault())
							{
								return new ServiceResult<byte[]>
								{
									Message = string.Format(Messages.MobMsgMaxMobDeviceUseReached, mobspLoadUserLoginInfo_Result.MobUserAppUseCnt.GetValueOrDefault()),
									Data = null,
									Status = ServiceResultStatus.Fail
								};
							}
							List<MobspSelectActiveUserAppDeviceInfoByImeiCode_Result> list4 = Enumerable.ToList<MobspSelectActiveUserAppDeviceInfoByImeiCode_Result>((IEnumerable<MobspSelectActiveUserAppDeviceInfoByImeiCode_Result>)cRMSpEntities.MobspSelectActiveUserAppDeviceInfoByImeiCode(login.imeiCode, login.projectAppName));
							if (Enumerable.Any<MobspSelectActiveUserAppDeviceInfoByImeiCode_Result>((IEnumerable<MobspSelectActiveUserAppDeviceInfoByImeiCode_Result>)list4))
							{
								if (!Common.IsKara())
								{
									string userName2 = Mobile.Classes.Helper.User.GetUserName(Enumerable.First<MobspSelectActiveUserAppDeviceInfoByImeiCode_Result>((IEnumerable<MobspSelectActiveUserAppDeviceInfoByImeiCode_Result>)list4).UserId, num, result);
									return new ServiceResult<byte[]>
									{
										Message = string.Format(Messages.MobMsgThisDeviceIsTakenForUser, userName2),
										Data = null,
										Status = ServiceResultStatus.Fail
									};
								}
								foreach (MobspSelectActiveUserAppDeviceInfoByImeiCode_Result item2 in list4)
								{
									cRMSpEntities.MobspDeactiveUserAppDeviceInfo(item2.UserAppDeviceInfoId, value, text4, appType);
								}
							}
							cRMEntities.MobspInsertUserAppDeviceInfo(mobspLoadUserLoginInfo_Result.UserId, login.deviceId, login.deviceType, login.projectAppName, value, text4, appType, login.imeiCode, login.deviceProperty, aESKey);
						}
					}
					RandomText randomText = new RandomText();
					string getString = randomText.CreateRandomCode(5, WithNumber: true).Replace(" ", "").Trim() + "|" + mobspLoadUserLoginInfo_Result.UserId + "|" + randomText.CreateRandomCode(5, WithNumber: true).Replace(" ", "").Trim() + "|" + mobspLoadUserLoginInfo_Result.UserRollId + "|" + randomText.CreateRandomCode(5, WithNumber: true).Replace(" ", "").Trim() + "|" + text3 + "|" + randomText.CreateRandomCode(5, WithNumber: true).Replace(" ", "").Trim() + "|" + DateTime.Now.ToString("yyyyMMdd-HHmmss", new PersianCulture()) + "|" + randomText.CreateRandomCode(5, WithNumber: true).Replace(" ", "").Trim();
					scanQRLoginResultViewModel.Token = CodeDecode.Codding(getString);
					if (mobspLoadUserLoginInfo_Result.MobHRMLoginMode.GetValueOrDefault() == 2)
					{
						scanQRLoginResultViewModel.LoginWithScan = false;
					}
					else
					{
						scanQRLoginResultViewModel.LoginWithScan = true;
					}
					scanQRLoginResultViewModel.ShiftWorkingId = mobspLoadUserLoginInfo_Result.ShiftWorkingId;
					scanQRLoginResultViewModel.UserId = mobspLoadUserLoginInfo_Result.UserId;
					data = security.EncryptJson(scanQRLoginResultViewModel, aESKey);
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
	private string InsertDefaultUserMobAppDevSetting(int userId)
	{
		CRMEntities cRMEntities = null;
		string result = null;
		try
		{
			cRMEntities = new CRMEntities();
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Mobile.Classes.Configuration.AppType;
			string text = JsonConvert.SerializeObject(new List<MobAppDevSettingViewModel>
			{
				new MobAppDevSettingViewModel
				{
					dType = 1,
					cIdOnOpenActive = true,
					cIdOnCloseActive = true,
					cIdOnBgActive = true,
					intMsgNotifOnOpenActive = true,
					intMsgNotifOnCloseActive = true,
					intMsgNotifOnBgActive = true
				},
				new MobAppDevSettingViewModel
				{
					dType = 2,
					cIdOnOpenActive = true,
					cIdOnCloseActive = true,
					cIdOnBgActive = true,
					intMsgNotifOnOpenActive = true,
					intMsgNotifOnCloseActive = true,
					intMsgNotifOnBgActive = true
				},
				new MobAppDevSettingViewModel
				{
					dType = 3,
					cIdOnOpenActive = true,
					cIdOnCloseActive = true,
					cIdOnBgActive = true,
					intMsgNotifOnOpenActive = true,
					intMsgNotifOnCloseActive = true,
					intMsgNotifOnBgActive = true
				}
			});
			cRMEntities.MobspUpdateUserMobAppDevSetting(text, userId, value2, userId, value, registerDatePersian, appType);
			result = text;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return result;
	}
}
