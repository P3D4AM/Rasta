using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using CRM.General.Cache;
using CRM.Models;
using CRMIdeal.Classes.Common;
using Elmah;

namespace CRMIdeal.Cache.User;

public static class Language
{
	private static readonly object obj = new object();

	private static readonly string MainCacheName = Configuration.CacheDefaultName + Configuration.CacheUniqueName + "-User-Language-";

	private static readonly int DefaultTimeInMinutes = Configuration.CacheDefaultTimeInMinutes;

	public static List<CRMspSelectUserLanguages_Result> Get(int? userId = null)
	{
		IIdentity identity = Thread.CurrentPrincipal.Identity;
		List<CRMspSelectUserLanguages_Result> value = new List<CRMspSelectUserLanguages_Result>();
		lock (obj)
		{
			try
			{
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
				if (usId != 0)
				{
					string key = MainCacheName + usId;
					if (!CacheManager.Get<List<CRMspSelectUserLanguages_Result>>(key, out value))
					{
						CRMSpEntities cRMSpEntities = new CRMSpEntities();
						List<CRMspSelectUserLanguages_Result> list = Enumerable.ToList<CRMspSelectUserLanguages_Result>(Enumerable.Where<CRMspSelectUserLanguages_Result>((IEnumerable<CRMspSelectUserLanguages_Result>)Enumerable.ToList<CRMspSelectUserLanguages_Result>((IEnumerable<CRMspSelectUserLanguages_Result>)cRMSpEntities.CRMspSelectUserLanguages(usId)), (Func<CRMspSelectUserLanguages_Result, bool>)((CRMspSelectUserLanguages_Result c) => c.IsActive)));
						List<CRMspSelectLanguages_Result> listLn = Enumerable.ToList<CRMspSelectLanguages_Result>(Enumerable.Where<CRMspSelectLanguages_Result>((IEnumerable<CRMspSelectLanguages_Result>)Enumerable.ToList<CRMspSelectLanguages_Result>((IEnumerable<CRMspSelectLanguages_Result>)cRMSpEntities.CRMspSelectLanguages()), (Func<CRMspSelectLanguages_Result, bool>)((CRMspSelectLanguages_Result c) => c.IsActive.GetValueOrDefault())));
						value.AddRange(Enumerable.Select<CRMspSelectUserLanguages_Result, CRMspSelectUserLanguages_Result>(Enumerable.Where<CRMspSelectUserLanguages_Result>((IEnumerable<CRMspSelectUserLanguages_Result>)list, (Func<CRMspSelectUserLanguages_Result, bool>)((CRMspSelectUserLanguages_Result item) => Enumerable.Any<CRMspSelectLanguages_Result>((IEnumerable<CRMspSelectLanguages_Result>)listLn, (Func<CRMspSelectLanguages_Result, bool>)((CRMspSelectLanguages_Result c) => c.LanguageID == item.LanguageID)))), (Func<CRMspSelectUserLanguages_Result, CRMspSelectUserLanguages_Result>)((CRMspSelectUserLanguages_Result item) => new CRMspSelectUserLanguages_Result
						{
							LanguageID = item.LanguageID,
							UserId = usId,
							IsActive = true,
							LanguageCollation = item.LanguageCollation,
							LanguageDirection = item.LanguageDirection,
							LanguageName = item.LanguageName
						})));
						if (!Enumerable.Any<CRMspSelectUserLanguages_Result>((IEnumerable<CRMspSelectUserLanguages_Result>)value))
						{
							value = new List<CRMspSelectUserLanguages_Result>
							{
								new CRMspSelectUserLanguages_Result
								{
									LanguageID = 1065,
									UserId = usId,
									IsActive = true,
									LanguageCollation = "fa-IR",
									LanguageDirection = "RTL",
									LanguageName = "فارسی"
								}
							};
						}
						cRMSpEntities.Dispose();
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
				CacheManager.Clear(MainCacheName + result);
				return true;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return false;
	}

	public static bool Update(int? userId = null)
	{
		lock (obj)
		{
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
				if (usId != 0)
				{
					string key = MainCacheName + usId;
					CRMSpEntities cRMSpEntities = new CRMSpEntities();
					List<CRMspSelectUserLanguages_Result> list = new List<CRMspSelectUserLanguages_Result>();
					List<CRMspSelectUserLanguages_Result> list2 = Enumerable.ToList<CRMspSelectUserLanguages_Result>(Enumerable.Where<CRMspSelectUserLanguages_Result>((IEnumerable<CRMspSelectUserLanguages_Result>)Enumerable.ToList<CRMspSelectUserLanguages_Result>((IEnumerable<CRMspSelectUserLanguages_Result>)cRMSpEntities.CRMspSelectUserLanguages(usId)), (Func<CRMspSelectUserLanguages_Result, bool>)((CRMspSelectUserLanguages_Result c) => c.IsActive)));
					List<CRMspSelectLanguages_Result> listLn = Enumerable.ToList<CRMspSelectLanguages_Result>(Enumerable.Where<CRMspSelectLanguages_Result>((IEnumerable<CRMspSelectLanguages_Result>)Enumerable.ToList<CRMspSelectLanguages_Result>((IEnumerable<CRMspSelectLanguages_Result>)cRMSpEntities.CRMspSelectLanguages()), (Func<CRMspSelectLanguages_Result, bool>)((CRMspSelectLanguages_Result c) => c.IsActive.GetValueOrDefault())));
					list.AddRange(Enumerable.Select<CRMspSelectUserLanguages_Result, CRMspSelectUserLanguages_Result>(Enumerable.Where<CRMspSelectUserLanguages_Result>((IEnumerable<CRMspSelectUserLanguages_Result>)list2, (Func<CRMspSelectUserLanguages_Result, bool>)((CRMspSelectUserLanguages_Result item) => Enumerable.Any<CRMspSelectLanguages_Result>((IEnumerable<CRMspSelectLanguages_Result>)listLn, (Func<CRMspSelectLanguages_Result, bool>)((CRMspSelectLanguages_Result c) => c.LanguageID == item.LanguageID)))), (Func<CRMspSelectUserLanguages_Result, CRMspSelectUserLanguages_Result>)((CRMspSelectUserLanguages_Result item) => new CRMspSelectUserLanguages_Result
					{
						LanguageID = item.LanguageID,
						UserId = usId,
						IsActive = true,
						LanguageCollation = item.LanguageCollation,
						LanguageDirection = item.LanguageDirection,
						LanguageName = item.LanguageName
					})));
					if (!Enumerable.Any<CRMspSelectUserLanguages_Result>((IEnumerable<CRMspSelectUserLanguages_Result>)list))
					{
						list = new List<CRMspSelectUserLanguages_Result>
						{
							new CRMspSelectUserLanguages_Result
							{
								LanguageID = 1065,
								UserId = usId,
								IsActive = true,
								LanguageCollation = "fa-IR",
								LanguageDirection = "RTL",
								LanguageName = "فارسی"
							}
						};
					}
					cRMSpEntities.Dispose();
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
