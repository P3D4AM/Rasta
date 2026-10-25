using System;
using System.Collections.Generic;
using System.Linq;

namespace CRMIdealApi.Classes.Common;

public static class ConvertCharacter
{
	public static string ClearHiddenCharacters(this string value)
	{
		if (string.IsNullOrWhiteSpace(value))
		{
			return value;
		}
		value = value.TrimEnd(Array.Empty<char>()).TrimStart(Array.Empty<char>());
		Dictionary<string, string> dictionary = new Dictionary<string, string> { ["\ufeff"] = "" };
		return Enumerable.Aggregate<KeyValuePair<string, string>, string>((IEnumerable<KeyValuePair<string, string>>)dictionary, value, (Func<string, KeyValuePair<string, string>, string>)((string current, KeyValuePair<string, string> item) => current.Replace(item.Key, item.Value)));
	}
}
