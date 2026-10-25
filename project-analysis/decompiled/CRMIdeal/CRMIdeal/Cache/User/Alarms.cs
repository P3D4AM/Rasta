using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using CRM.General.Cache;
using CRM.General.Calendar;
using CRM.Models;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes.Common;
using CRMIdeal.Classes.Helper;
using CRMIdeal.GSD.Globalization;
using Elmah;

namespace CRMIdeal.Cache.User;

public static class Alarms
{
	private static readonly object obj = new object();

	private static readonly string MainCacheName = Configuration.CacheDefaultName + Configuration.CacheUniqueName + "-User-Alarms-";

	private static readonly int DefaultTimeInMinutes = Configuration.CacheDefaultTimeInMinutes;

	public static List<CRMspLoadRemindingTask_Result> Get(int? userId = null, int? centerId = null)
	{
		IIdentity identity = Thread.CurrentPrincipal.Identity;
		List<CRMspLoadRemindingTask_Result> value = null;
		lock (obj)
		{
			try
			{
				int result = 0;
				if (!userId.HasValue)
				{
					if (identity.Name != null)
					{
						int.TryParse(identity.Name, out result);
					}
				}
				else
				{
					int.TryParse(userId.ToString(), out result);
				}
				int result2 = 0;
				if (!centerId.HasValue)
				{
					result2 = CRMIdeal.Classes.Helper.User.GetUserLastCId(result, 1065, 1065);
				}
				else
				{
					int.TryParse(centerId.ToString(), out result2);
				}
				if (result != 0)
				{
					int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result3);
					if (result3 <= 0)
					{
						result3 = 1065;
					}
					int lCID = Thread.CurrentThread.CurrentCulture.LCID;
					DateTime now = DateTime.Now;
					string text = now.ToString("yyyyMMdd");
					string key = MainCacheName + text + "-" + result;
					if (!CacheManager.Get<List<CRMspLoadRemindingTask_Result>>(key, out value))
					{
						DateTime value2 = DateTime.Parse(now.ToString("yyyy/MM/dd") + " 23:59:59");
						CRMSpEntities cRMSpEntities = new CRMSpEntities();
						value = Enumerable.ToList<CRMspLoadRemindingTask_Result>((IEnumerable<CRMspLoadRemindingTask_Result>)cRMSpEntities.CRMspLoadRemindingTask(text, result, value2, lCID, result3, result2));
						foreach (CRMspLoadRemindingTask_Result item in value)
						{
							if (item.UserTaskDate.HasValue)
							{
								DateTime.TryParse(item.UserTaskDate.ToString(), out var result4);
								item.UserTaskDatePersian = result4.ToString("yyyyMMdd");
							}
							else if (!string.IsNullOrEmpty(item.UserTaskDatePersian))
							{
								if (lCID != 1065)
								{
									item.UserTaskDatePersian = DateTime.ParseExact(PersianDate.GetFormatetdDate(item.UserTaskDatePersian.Replace("/", "")), "yyyy/MM/dd", new PersianCulture()).ToString("yyyyMMdd");
								}
								else
								{
									item.UserTaskDatePersian = item.UserTaskDatePersian.Replace("/", "");
								}
							}
							if (item.UserTaskRemindDateTime.HasValue)
							{
								DateTime.TryParse(item.UserTaskRemindDateTime.ToString(), out var result5);
								item.UserTaskRemindDate = result5.ToString("yyyyMMdd");
							}
							else if (!string.IsNullOrEmpty(item.UserTaskRemindDate))
							{
								if (lCID != 1065)
								{
									item.UserTaskRemindDate = DateTime.ParseExact(PersianDate.GetFormatetdDate(item.UserTaskRemindDate.Replace("/", "")), "yyyy/MM/dd", new PersianCulture()).ToString("yyyyMMdd");
								}
								else
								{
									item.UserTaskRemindDate = item.UserTaskRemindDate.Replace("/", "");
								}
							}
						}
						cRMSpEntities.Dispose();
						string text2 = now.AddDays(-1.0).ToString("yyyyMMdd");
						CacheManager.Clear(MainCacheName + text2 + "-" + result);
						CacheManager.Add(value, key, DefaultTimeInMinutes);
					}
				}
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
			}
		}
		return value;
	}

	public static bool Clear(int? userId = null)
	{
		try
		{
			IIdentity identity = Thread.CurrentPrincipal.Identity;
			int result = 0;
			if (!userId.HasValue)
			{
				if (identity.Name != null)
				{
					int.TryParse(identity.Name, out result);
				}
			}
			else
			{
				int.TryParse(userId.ToString(), out result);
			}
			if (result != 0)
			{
				string text = DateTime.Now.ToString("yyyyMMdd");
				CacheManager.Clear(MainCacheName + text + "-" + result);
				return true;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return false;
	}

	public static bool Update(int? userId = null, int? centerId = null)
	{
		lock (obj)
		{
			try
			{
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
				if (result <= 0)
				{
					result = 1065;
				}
				int lCID = Thread.CurrentThread.CurrentCulture.LCID;
				IIdentity identity = Thread.CurrentPrincipal.Identity;
				int result2 = 0;
				if (!userId.HasValue)
				{
					if (identity.Name != null)
					{
						int.TryParse(identity.Name, out result2);
					}
				}
				else
				{
					int.TryParse(userId.ToString(), out result2);
				}
				int result3 = 0;
				if (!centerId.HasValue)
				{
					result3 = CRMIdeal.Classes.Helper.User.GetUserLastCId(result2, 1065, 1065);
				}
				else
				{
					int.TryParse(centerId.ToString(), out result3);
				}
				if (result2 != 0)
				{
					DateTime now = DateTime.Now;
					string text = now.ToString("yyyyMMdd");
					string key = MainCacheName + text + "-" + result2;
					DateTime value = DateTime.Parse(now.ToString("yyyy/MM/dd") + " 23:59:59");
					CRMSpEntities cRMSpEntities = new CRMSpEntities();
					List<CRMspLoadRemindingTask_Result> list = Enumerable.ToList<CRMspLoadRemindingTask_Result>((IEnumerable<CRMspLoadRemindingTask_Result>)cRMSpEntities.CRMspLoadRemindingTask(text, result2, value, lCID, result, result3));
					foreach (CRMspLoadRemindingTask_Result item in list)
					{
						if (item.UserTaskDate.HasValue)
						{
							DateTime.TryParse(item.UserTaskDate.ToString(), out var result4);
							item.UserTaskDatePersian = result4.ToString("yyyyMMdd");
						}
						else if (!string.IsNullOrEmpty(item.UserTaskDatePersian))
						{
							if (lCID != 1065)
							{
								item.UserTaskDatePersian = DateTime.ParseExact(PersianDate.GetFormatetdDate(item.UserTaskDatePersian.Replace("/", "")), "yyyy/MM/dd", new PersianCulture()).ToString("yyyyMMdd");
							}
							else
							{
								item.UserTaskDatePersian = item.UserTaskDatePersian.Replace("/", "");
							}
						}
						if (item.UserTaskRemindDateTime.HasValue)
						{
							DateTime.TryParse(item.UserTaskRemindDateTime.ToString(), out var result5);
							item.UserTaskRemindDate = result5.ToString("yyyyMMdd");
						}
						else if (!string.IsNullOrEmpty(item.UserTaskRemindDate))
						{
							if (lCID != 1065)
							{
								item.UserTaskRemindDate = DateTime.ParseExact(PersianDate.GetFormatetdDate(item.UserTaskRemindDate.Replace("/", "")), "yyyy/MM/dd", new PersianCulture()).ToString("yyyyMMdd");
							}
							else
							{
								item.UserTaskRemindDate = item.UserTaskRemindDate.Replace("/", "");
							}
						}
					}
					cRMSpEntities.Dispose();
					string text2 = now.AddDays(-1.0).ToString("yyyyMMdd");
					CacheManager.Clear(MainCacheName + text2 + "-" + result2);
					CacheManager.Clear(key);
					CacheManager.Add(list, key, DefaultTimeInMinutes);
					return true;
				}
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
			}
		}
		return false;
	}
}
