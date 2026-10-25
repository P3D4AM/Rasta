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

public static class TelegramMsg
{
	private static readonly object obj = new object();

	private static readonly string MainCacheName = Configuration.CacheDefaultName + Configuration.CacheUniqueName + "-User-TelegMsg-";

	private static readonly int DefaultTimeInMinutes = Configuration.CacheDefaultTimeInMinutes;

	public static List<CRMspSelectTelegChatMessage_Result> Get(int chatId, int mainPageIndex, int settingId, int? userId = null)
	{
		IIdentity identity = Thread.CurrentPrincipal.Identity;
		List<CRMspSelectTelegChatMessage_Result> result = null;
		lock (obj)
		{
			try
			{
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
				if (result2 != 0)
				{
					int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result3);
					if (result3 <= 0)
					{
						result3 = 1065;
					}
					int lCID = Thread.CurrentThread.CurrentCulture.LCID;
					result = Enumerable.ToList<CRMspSelectTelegChatMessage_Result>((IEnumerable<CRMspSelectTelegChatMessage_Result>)new CRMSpEntities().CRMspSelectTelegChatMessage(chatId, 0L, 0, 0, languageID: lCID, defaultLanguageID: result3, pageNumber: mainPageIndex, pageSize: 100, settingId: settingId));
				}
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
			}
		}
		return result;
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
