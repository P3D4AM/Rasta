using System;
using System.Collections.Generic;
using System.Linq;
using CRM.General.Cache;
using CRM.Models;
using CRMIdeal.Classes.Common;
using Elmah;

namespace CRMIdeal.Cache.User;

public static class UserLoginSmartTimeAttendance
{
	private static readonly string MainCacheName = Configuration.CacheDefaultName + Configuration.CacheUniqueName + "-User-Login-SmartTimeAttendance";

	private static readonly int DefaultTimeInMinutes = Configuration.CacheDefaultTimeInMinutes;

	public static List<LoginUserSmartTimeAttendanceViewModel> GetList()
	{
		List<LoginUserSmartTimeAttendanceViewModel> value = new List<LoginUserSmartTimeAttendanceViewModel>();
		try
		{
			if (!CacheManager.Get<List<LoginUserSmartTimeAttendanceViewModel>>(MainCacheName, out value))
			{
				value = new List<LoginUserSmartTimeAttendanceViewModel>();
				CacheManager.Add(value, MainCacheName, DefaultTimeInMinutes);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return value;
	}

	public static LoginUserSmartTimeAttendanceViewModel Get(int userId)
	{
		LoginUserSmartTimeAttendanceViewModel result = null;
		try
		{
			if (userId != 0)
			{
				List<LoginUserSmartTimeAttendanceViewModel> value = new List<LoginUserSmartTimeAttendanceViewModel>();
				CacheManager.Get<List<LoginUserSmartTimeAttendanceViewModel>>(MainCacheName, out value);
				if (value != null && Enumerable.Any<LoginUserSmartTimeAttendanceViewModel>((IEnumerable<LoginUserSmartTimeAttendanceViewModel>)value))
				{
					result = Enumerable.FirstOrDefault<LoginUserSmartTimeAttendanceViewModel>((IEnumerable<LoginUserSmartTimeAttendanceViewModel>)value, (Func<LoginUserSmartTimeAttendanceViewModel, bool>)((LoginUserSmartTimeAttendanceViewModel m) => m.UserId == userId));
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public static bool Clear(int userId)
	{
		try
		{
			if (userId != 0)
			{
				List<LoginUserSmartTimeAttendanceViewModel> value = new List<LoginUserSmartTimeAttendanceViewModel>();
				CacheManager.Get<List<LoginUserSmartTimeAttendanceViewModel>>(MainCacheName, out value);
				if (value != null && Enumerable.Any<LoginUserSmartTimeAttendanceViewModel>((IEnumerable<LoginUserSmartTimeAttendanceViewModel>)value))
				{
					int num = value.FindIndex((LoginUserSmartTimeAttendanceViewModel m) => m.UserId == userId);
					if (num >= 0)
					{
						if (num >= 0)
						{
							value.RemoveAt(num);
							CacheManager.Clear(MainCacheName);
							CacheManager.Add(value, MainCacheName, DefaultTimeInMinutes);
							return true;
						}
						num = -1;
						return false;
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return false;
	}

	public static bool Update(int userId, string qrCode, string mainQrCode, string tmPatamJson)
	{
		try
		{
			if (userId != 0)
			{
				List<LoginUserSmartTimeAttendanceViewModel> value = new List<LoginUserSmartTimeAttendanceViewModel>();
				CacheManager.Get<List<LoginUserSmartTimeAttendanceViewModel>>(MainCacheName, out value);
				if (value != null && Enumerable.Any<LoginUserSmartTimeAttendanceViewModel>((IEnumerable<LoginUserSmartTimeAttendanceViewModel>)value) && !string.IsNullOrWhiteSpace(qrCode))
				{
					if (Enumerable.FirstOrDefault<LoginUserSmartTimeAttendanceViewModel>((IEnumerable<LoginUserSmartTimeAttendanceViewModel>)value, (Func<LoginUserSmartTimeAttendanceViewModel, bool>)((LoginUserSmartTimeAttendanceViewModel m) => m.UserId == userId)) == null)
					{
						return false;
					}
					if (Enumerable.FirstOrDefault<LoginUserSmartTimeAttendanceViewModel>((IEnumerable<LoginUserSmartTimeAttendanceViewModel>)value, (Func<LoginUserSmartTimeAttendanceViewModel, bool>)((LoginUserSmartTimeAttendanceViewModel m) => m.UserId == userId)) != null)
					{
						Enumerable.FirstOrDefault<LoginUserSmartTimeAttendanceViewModel>((IEnumerable<LoginUserSmartTimeAttendanceViewModel>)value, (Func<LoginUserSmartTimeAttendanceViewModel, bool>)((LoginUserSmartTimeAttendanceViewModel m) => m.UserId == userId)).SmartTimeAttendanceQRCode = qrCode;
						Enumerable.FirstOrDefault<LoginUserSmartTimeAttendanceViewModel>((IEnumerable<LoginUserSmartTimeAttendanceViewModel>)value, (Func<LoginUserSmartTimeAttendanceViewModel, bool>)((LoginUserSmartTimeAttendanceViewModel m) => m.UserId == userId)).SmartTimeAttendanceRegisterDate = DateTime.Now;
						Enumerable.FirstOrDefault<LoginUserSmartTimeAttendanceViewModel>((IEnumerable<LoginUserSmartTimeAttendanceViewModel>)value, (Func<LoginUserSmartTimeAttendanceViewModel, bool>)((LoginUserSmartTimeAttendanceViewModel m) => m.UserId == userId)).SmartTimeAttendanceParamJson = tmPatamJson;
					}
				}
				else if (value == null)
				{
					value = new List<LoginUserSmartTimeAttendanceViewModel>();
					LoginUserSmartTimeAttendanceViewModel item = new LoginUserSmartTimeAttendanceViewModel
					{
						UserId = userId,
						SmartTimeAttendanceQRCode = "",
						SmartTimeAttendanceMainQRCode = mainQrCode,
						SmartTimeAttendanceFirstRegisterDate = DateTime.Now,
						SmartTimeAttendanceParamJson = tmPatamJson
					};
					value.Add(item);
				}
				else if (Enumerable.FirstOrDefault<LoginUserSmartTimeAttendanceViewModel>((IEnumerable<LoginUserSmartTimeAttendanceViewModel>)value, (Func<LoginUserSmartTimeAttendanceViewModel, bool>)((LoginUserSmartTimeAttendanceViewModel m) => m.UserId == userId)) != null)
				{
					Enumerable.FirstOrDefault<LoginUserSmartTimeAttendanceViewModel>((IEnumerable<LoginUserSmartTimeAttendanceViewModel>)value, (Func<LoginUserSmartTimeAttendanceViewModel, bool>)((LoginUserSmartTimeAttendanceViewModel m) => m.UserId == userId)).SmartTimeAttendanceQRCode = "";
					Enumerable.FirstOrDefault<LoginUserSmartTimeAttendanceViewModel>((IEnumerable<LoginUserSmartTimeAttendanceViewModel>)value, (Func<LoginUserSmartTimeAttendanceViewModel, bool>)((LoginUserSmartTimeAttendanceViewModel m) => m.UserId == userId)).SmartTimeAttendanceMainQRCode = mainQrCode;
					Enumerable.FirstOrDefault<LoginUserSmartTimeAttendanceViewModel>((IEnumerable<LoginUserSmartTimeAttendanceViewModel>)value, (Func<LoginUserSmartTimeAttendanceViewModel, bool>)((LoginUserSmartTimeAttendanceViewModel m) => m.UserId == userId)).SmartTimeAttendanceFirstRegisterDate = DateTime.Now;
					Enumerable.FirstOrDefault<LoginUserSmartTimeAttendanceViewModel>((IEnumerable<LoginUserSmartTimeAttendanceViewModel>)value, (Func<LoginUserSmartTimeAttendanceViewModel, bool>)((LoginUserSmartTimeAttendanceViewModel m) => m.UserId == userId)).SmartTimeAttendanceRegisterDate = null;
					Enumerable.FirstOrDefault<LoginUserSmartTimeAttendanceViewModel>((IEnumerable<LoginUserSmartTimeAttendanceViewModel>)value, (Func<LoginUserSmartTimeAttendanceViewModel, bool>)((LoginUserSmartTimeAttendanceViewModel m) => m.UserId == userId)).SmartTimeAttendanceParamJson = tmPatamJson;
				}
				else
				{
					LoginUserSmartTimeAttendanceViewModel item2 = new LoginUserSmartTimeAttendanceViewModel
					{
						UserId = userId,
						SmartTimeAttendanceQRCode = "",
						SmartTimeAttendanceMainQRCode = mainQrCode,
						SmartTimeAttendanceFirstRegisterDate = DateTime.Now,
						SmartTimeAttendanceParamJson = tmPatamJson
					};
					value.Add(item2);
				}
				CacheManager.Clear(MainCacheName);
				CacheManager.Add(value, MainCacheName, DefaultTimeInMinutes);
				return true;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return false;
	}
}
