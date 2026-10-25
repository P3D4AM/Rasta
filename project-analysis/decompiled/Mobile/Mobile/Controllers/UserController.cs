using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Http;
using CRM.Resources;
using Elmah;
using GSD.Globalization;
using Mobile.Cache.Setting;
using Mobile.Classes;
using Mobile.Classes.Helper;
using Mobile.DataType;
using Mobile.Models;

namespace Mobile.Controllers;

public class UserController : ApiController
{
	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<UserLocationViewModel>> SelectUsersCoordinate(int lastHours, int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<UserLocationViewModel> data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		try
		{
			if (!UserLogin.IsUserAccess("frmMain", "actcUserLocation", UserLogin.CurrentUser, cId))
			{
				return new ServiceResult<List<UserLocationViewModel>>
				{
					Message = Messages.MobMsgErrorAccessLimited,
					Data = null,
					Status = ServiceResultStatus.Fail
				};
			}
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new Common().GetToken(token) != null)
				{
					cRMEntities = new CRMEntities();
					List<MobspSelectUsersCoordinate_Result> list = Enumerable.ToList<MobspSelectUsersCoordinate_Result>((IEnumerable<MobspSelectUsersCoordinate_Result>)cRMEntities.MobspSelectUsersCoordinate(result, result2, lastHours));
					List<UserLocationViewModel> list2 = new List<UserLocationViewModel>();
					if (Enumerable.Any<MobspSelectUsersCoordinate_Result>((IEnumerable<MobspSelectUsersCoordinate_Result>)list))
					{
						foreach (MobspSelectUsersCoordinate_Result item2 in list)
						{
							UserLocationViewModel item = new UserLocationViewModel
							{
								UserId = item2.UserId,
								FullName = item2.FullName,
								UserRollId = item2.UserRollId,
								RollName = (item2.RollName ?? ""),
								CoordinateLatitude = ((!string.IsNullOrEmpty(item2.CoordinateLatitude)) ? item2.CoordinateLatitude : ""),
								CoordinateLongitude = ((!string.IsNullOrEmpty(item2.CoordinateLongitude)) ? item2.CoordinateLongitude : ""),
								CoordinateLastDate = (item2.CoordinateLastDate.HasValue ? (item2.CoordinateLastDate ?? DateTime.Now).ToString("yyyy/MM/dd", new CultureInfo("en-US")) : ""),
								CoordinateLastTime = (item2.CoordinateLastDate.HasValue ? (item2.CoordinateLastDate ?? DateTime.Now).ToString("HH:mm:ss") : ""),
								CoordinateLastDatePersian = ((!string.IsNullOrEmpty(item2.CoordinateLastDatePersian)) ? DateTimeClass.ConvertDateWoSlashToSlash(item2.CoordinateLastDatePersian) : ""),
								CmpAccess = ""
							};
							list2.Add(item);
						}
					}
					data = list2;
					message = "";
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
		return new ServiceResult<List<UserLocationViewModel>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<string> UpdateUserCoordinate(int userId, string latitude, string longitude)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		CRMEntities cRMEntities = null;
		string data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int num = 1065;
		int culture = ((result > 0) ? result : num);
		baseInfo.SetCulture(culture);
		try
		{
			if (userId == 0)
			{
				ServiceResult<string> result2 = new ServiceResult<string>
				{
					Message = Messages.MobMsgErrorUserNotSelected,
					Data = null,
					Status = ServiceResultStatus.Fail
				};
				cRMEntities?.Dispose();
				return result2;
			}
			if (string.IsNullOrEmpty(latitude))
			{
				ServiceResult<string> result3 = new ServiceResult<string>
				{
					Message = Messages.MobMsgErrorLatitudeNotEntered,
					Data = null,
					Status = ServiceResultStatus.Fail
				};
				cRMEntities?.Dispose();
				return result3;
			}
			if (string.IsNullOrEmpty(longitude))
			{
				ServiceResult<string> result4 = new ServiceResult<string>
				{
					Message = Messages.MobMsgErrorLongitudeNotEntered,
					Data = null,
					Status = ServiceResultStatus.Fail
				};
				cRMEntities?.Dispose();
				return result4;
			}
			cRMEntities = new CRMEntities();
			string text = DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
			short value = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Mobile.Classes.Configuration.AppType;
			CRMEntities cRMEntities2 = cRMEntities;
			int? userId2 = userId;
			int? registerUserId = userId;
			string registerDatePersian = text;
			if (cRMEntities2.MobspUpdateUserCoordinate(userId2, registerUserId, appType, registerDatePersian, value, latitude, longitude) >= 1)
			{
				data = "Ok";
				message = Messages.MobMsgUpdateSuccess;
				status = ServiceResultStatus.Success;
			}
			else
			{
				data = "NO";
				message = Messages.MobMsgErorrUpdate;
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
		return new ServiceResult<string>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<MobspSelectUser_Result> SelectUser(int userId, int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		MobspSelectUser_Result data = null;
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
				if (new Common().GetToken(token) != null)
				{
					cRMEntities = new CRMEntities();
					data = Enumerable.FirstOrDefault<MobspSelectUser_Result>((IEnumerable<MobspSelectUser_Result>)cRMEntities.MobspSelectUser(userId, result, result2, cId));
					message = "";
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
		return new ServiceResult<MobspSelectUser_Result>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<string> UpdateUserMobAppDevSetting(string settingJson, int? ln = null)
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
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					cRMEntities = new CRMEntities();
					DateTime now = DateTime.Now;
					DateTime value = now;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
					string appType = Mobile.Classes.Configuration.AppType;
					_ = token2.userId;
					data = Enumerable.FirstOrDefault<MobspUpdateUserMobAppDevSetting_Result>((IEnumerable<MobspUpdateUserMobAppDevSetting_Result>)cRMEntities.MobspUpdateUserMobAppDevSetting(settingJson, token2.userId, value2, token2.userId, value, registerDatePersian, appType)).MobAppDevSetting;
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
		return new ServiceResult<string>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}
}
