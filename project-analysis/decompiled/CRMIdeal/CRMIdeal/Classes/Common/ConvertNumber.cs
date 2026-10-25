using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using CRMIdeal.Cache.Setting;

namespace CRMIdeal.Classes.Common;

public static class ConvertNumber
{
	public static string PersianToEnglish(this string persianStr)
	{
		if (string.IsNullOrEmpty(persianStr))
		{
			return persianStr;
		}
		return Enumerable.Aggregate<KeyValuePair<string, string>, string>((IEnumerable<KeyValuePair<string, string>>)new Dictionary<string, string>
		{
			["۰"] = "0",
			["۱"] = "1",
			["۲"] = "2",
			["۳"] = "3",
			["۴"] = "4",
			["۵"] = "5",
			["۶"] = "6",
			["۷"] = "7",
			["۸"] = "8",
			["۹"] = "9"
		}, persianStr, (Func<string, KeyValuePair<string, string>, string>)((string current, KeyValuePair<string, string> item) => current.Replace(item.Key, item.Value)));
	}

	public static string EnglishToPersian(this string englishStr)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		if (Thread.CurrentThread.CurrentCulture.LCID != 1065)
		{
			return englishStr;
		}
		if (string.IsNullOrEmpty(englishStr))
		{
			return englishStr;
		}
		return Enumerable.Aggregate<KeyValuePair<string, string>, string>((IEnumerable<KeyValuePair<string, string>>)new Dictionary<string, string>
		{
			["0"] = "۰",
			["1"] = "۱",
			["2"] = "۲",
			["3"] = "۳",
			["4"] = "۴",
			["5"] = "۵",
			["6"] = "۶",
			["7"] = "۷",
			["8"] = "۸",
			["9"] = "۹"
		}, englishStr, (Func<string, KeyValuePair<string, string>, string>)((string current, KeyValuePair<string, string> item) => current.Replace(item.Key, item.Value)));
	}
}
