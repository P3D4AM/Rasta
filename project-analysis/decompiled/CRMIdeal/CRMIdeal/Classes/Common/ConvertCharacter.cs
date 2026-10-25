using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CRMIdeal.Classes.Common;

public static class ConvertCharacter
{
	public static string ArabicToPersian(this string arabicValue)
	{
		if (string.IsNullOrWhiteSpace(arabicValue))
		{
			return arabicValue;
		}
		arabicValue = arabicValue.TrimEnd(Array.Empty<char>()).TrimStart(Array.Empty<char>());
		return Enumerable.Aggregate<KeyValuePair<string, string>, string>((IEnumerable<KeyValuePair<string, string>>)new Dictionary<string, string>
		{
			["ى"] = "ی",
			["ي"] = "ی",
			["ك"] = "ک"
		}, arabicValue, (Func<string, KeyValuePair<string, string>, string>)((string current, KeyValuePair<string, string> item) => current.Replace(item.Key, item.Value)));
	}

	public static string ClearHiddenCharacters(this string value)
	{
		if (string.IsNullOrWhiteSpace(value))
		{
			return value;
		}
		value = value.TrimEnd(Array.Empty<char>()).TrimStart(Array.Empty<char>());
		return Enumerable.Aggregate<KeyValuePair<string, string>, string>((IEnumerable<KeyValuePair<string, string>>)new Dictionary<string, string>
		{
			["\ufeff"] = "",
			["U+200E"] = "",
			["U+200F"] = ""
		}, value, (Func<string, KeyValuePair<string, string>, string>)((string current, KeyValuePair<string, string> item) => current.Replace(item.Key, item.Value)));
	}

	public static string RemoveSpecialCharacters(string str)
	{
		string result = "";
		if (!string.IsNullOrWhiteSpace(str))
		{
			result = Regex.Replace(str, "[^\\p{L}0-9_.]", "", (RegexOptions)8);
		}
		return result;
	}

	public static string RemoveSpecialCharactersWithoutDot(string str)
	{
		string result = "";
		if (!string.IsNullOrWhiteSpace(str))
		{
			result = Regex.Replace(str, "[^\\p{L}0-9_]", "", (RegexOptions)8);
		}
		return result;
	}

	public static string EncodeTracing(string tracing = "")
	{
		if (string.IsNullOrWhiteSpace(tracing))
		{
			return tracing;
		}
		return tracing.Replace("/", "$*");
	}

	public static string DecodeTracing(string tracing = "")
	{
		if (string.IsNullOrWhiteSpace(tracing))
		{
			return tracing;
		}
		return tracing.Replace("$*", "/");
	}
}
