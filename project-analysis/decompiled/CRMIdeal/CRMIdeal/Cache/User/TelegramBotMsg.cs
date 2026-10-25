using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using CRM.General.Cache;
using CRM.Models;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes.Common;
using Elmah;

namespace CRMIdeal.Cache.User;

public static class TelegramBotMsg
{
	private static readonly object obj = new object();

	private static readonly string MainCacheName = Configuration.CacheDefaultName + Configuration.CacheUniqueName + "-User-TelegBotMsg-";

	private static readonly int DefaultTimeInMinutes = Configuration.CacheDefaultTimeInMinutes;

	public static List<CRMspSelectTelegBotChatMessage_Result> Get(int chatId, int mainPageIndex, int? userId = null)
	{
		IIdentity identity = Thread.CurrentPrincipal.Identity;
		List<CRMspSelectTelegBotChatMessage_Result> value = null;
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
				if (result != 0)
				{
					string key = MainCacheName + result;
					if (!CacheManager.Get<List<CRMspSelectTelegBotChatMessage_Result>>(key, out value))
					{
						int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
						if (result2 <= 0)
						{
							result2 = 1065;
						}
						int lCID = Thread.CurrentThread.CurrentCulture.LCID;
						CRMSpEntities cRMSpEntities = new CRMSpEntities();
						value = Enumerable.ToList<CRMspSelectTelegBotChatMessage_Result>((IEnumerable<CRMspSelectTelegBotChatMessage_Result>)cRMSpEntities.CRMspSelectTelegBotChatMessage(chatId, 0L, 0, 0, languageID: lCID, defaultLanguageID: result2, pageNumber: mainPageIndex, pageSize: 100));
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
}
