using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using CRM.General.Cache;
using CRM.Models;
using CRMIdeal.Classes.Common;
using Elmah;

namespace CRMIdeal.Cache.Setting;

public static class LoginActivity
{
	private static readonly string MainCacheName = Configuration.CacheDefaultName + Configuration.CacheUniqueName + "-Setting-LoginActivity";

	private static readonly int DefaultTimeInMinutes = Configuration.CacheDefaultTimeInMinutes;

	public static List<LoginActivityViewModel> Get()
	{
		List<LoginActivityViewModel> value = new List<LoginActivityViewModel>();
		try
		{
			if (!CacheManager.Get<List<LoginActivityViewModel>>(MainCacheName, out value))
			{
				value = new List<LoginActivityViewModel>();
				CacheManager.Add(value, MainCacheName, DefaultTimeInMinutes);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return value;
	}

	public static LoginActivityViewModel GetCurrentUserActivity(int userId = 0)
	{
		LoginActivityViewModel result = new LoginActivityViewModel();
		try
		{
			IIdentity identity = Thread.CurrentPrincipal.Identity;
			int usId = 0;
			if (userId == 0)
			{
				if (identity.Name != null)
				{
					int.TryParse(identity.Name, out usId);
				}
			}
			else
			{
				int.TryParse(userId.ToString(), out usId);
			}
			List<LoginActivityViewModel> value = new List<LoginActivityViewModel>();
			CacheManager.Get<List<LoginActivityViewModel>>(MainCacheName, out value);
			if (value.Count > 0)
			{
				result = Enumerable.FirstOrDefault<LoginActivityViewModel>((IEnumerable<LoginActivityViewModel>)value, (Func<LoginActivityViewModel, bool>)((LoginActivityViewModel x) => x.Id == usId));
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public static bool Update(int? userId, bool autoAdd, out Guid? currGuid, bool generateNewGuid = false)
	{
		currGuid = null;
		try
		{
			IIdentity identity = Thread.CurrentPrincipal.Identity;
			int usId = 0;
			if (!userId.HasValue)
			{
				if (identity.Name != null)
				{
					int.TryParse(identity.Name, out usId);
				}
			}
			else
			{
				int.TryParse(userId.ToString(), out usId);
			}
			if (usId > 0)
			{
				List<LoginActivityViewModel> list = Get();
				if (Enumerable.FirstOrDefault<LoginActivityViewModel>(Enumerable.Where<LoginActivityViewModel>((IEnumerable<LoginActivityViewModel>)list, (Func<LoginActivityViewModel, bool>)((LoginActivityViewModel x) => x.Id == usId))) == null)
				{
					if (autoAdd)
					{
						Guid guid = Guid.NewGuid();
						currGuid = guid;
						CRMspLoadUserLoginInfo_Result cRMspLoadUserLoginInfo_Result = Enumerable.FirstOrDefault<CRMspLoadUserLoginInfo_Result>((IEnumerable<CRMspLoadUserLoginInfo_Result>)new CRMSpEntities().CRMspLoadUserLoginInfo(usId, "", "", Thread.CurrentThread.CurrentCulture.LCID, SysSeting.Get().DefaultLanguageID, null));
						list.Add(new LoginActivityViewModel
						{
							Id = cRMspLoadUserLoginInfo_Result.UserId,
							FullName = cRMspLoadUserLoginInfo_Result.FullName,
							LastActivityDateTime = DateTime.Now,
							LastActivityDateTimePersian = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
							CurrGuid = guid
						});
					}
				}
				else
				{
					Enumerable.FirstOrDefault<LoginActivityViewModel>((IEnumerable<LoginActivityViewModel>)list, (Func<LoginActivityViewModel, bool>)((LoginActivityViewModel x) => x.Id == usId)).LastActivityDateTime = DateTime.Now;
					Enumerable.FirstOrDefault<LoginActivityViewModel>((IEnumerable<LoginActivityViewModel>)list, (Func<LoginActivityViewModel, bool>)((LoginActivityViewModel x) => x.Id == usId)).LastActivityDateTimePersian = DateTime.Now.ToString("yyyy/MM/dd");
					if (generateNewGuid)
					{
						Guid guid2 = Guid.NewGuid();
						currGuid = guid2;
						Enumerable.FirstOrDefault<LoginActivityViewModel>((IEnumerable<LoginActivityViewModel>)list, (Func<LoginActivityViewModel, bool>)((LoginActivityViewModel x) => x.Id == usId)).CurrGuid = guid2;
					}
				}
				CacheManager.Clear(MainCacheName);
				CacheManager.Add(list, MainCacheName, DefaultTimeInMinutes);
				return true;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		currGuid = null;
		return false;
	}

	public static bool Remove(int userId = 0)
	{
		try
		{
			IIdentity identity = Thread.CurrentPrincipal.Identity;
			int usId = userId;
			if (usId == 0 && identity.Name != null)
			{
				int.TryParse(identity.Name, out usId);
			}
			if (usId > 0)
			{
				List<LoginActivityViewModel> list = Get();
				int num = list.FindIndex((LoginActivityViewModel x) => x.Id == usId);
				while (num >= 0)
				{
					if (num >= 0)
					{
						list.RemoveAt(num);
						CacheManager.Clear(MainCacheName);
						CacheManager.Add(list, MainCacheName, DefaultTimeInMinutes);
						LoginCount.Update(LoginCountType.Minus, usId);
						num = list.FindIndex((LoginActivityViewModel x) => x.Id == usId);
						continue;
					}
					num = -1;
					return false;
				}
				return true;
			}
			return false;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return false;
	}

	public static int RemoveExpiredLogins()
	{
		try
		{
			int minimumTimeoutLoginInMin = Configuration.MinimumTimeoutLoginInMin;
			DateTime t = DateTime.Now.AddMinutes(minimumTimeoutLoginInMin);
			List<int> list = new List<int>();
			List<LoginActivityViewModel> list2 = Get();
			foreach (LoginActivityViewModel item in list2)
			{
				if (DateTime.Compare(item.LastActivityDateTime, t) > 0)
				{
					list.Add(item.Id);
				}
			}
			if (list.Count > 0)
			{
				foreach (int i in list)
				{
					list2.RemoveAt(list2.FindIndex((LoginActivityViewModel x) => x.Id == i));
					LoginCount.Update(LoginCountType.Minus, i);
				}
				CacheManager.Clear(MainCacheName);
				CacheManager.Add(list2, MainCacheName, DefaultTimeInMinutes);
			}
			return list2.Count;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return 0;
	}
}
