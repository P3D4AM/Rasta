using System;
using System.Collections;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;

namespace CRM.General.Utilities;

public static class MyResource
{
	public static string GetResourceString(string key, string culture, string baseName, Assembly assembly)
	{
		if (string.IsNullOrEmpty(key))
		{
			return key;
		}
		string result = key;
		CultureInfo culture2 = new CultureInfo(culture);
		DictionaryEntry dictionaryEntry = Enumerable.FirstOrDefault<DictionaryEntry>(Enumerable.OfType<DictionaryEntry>((IEnumerable)new ResourceManager(baseName, assembly).GetResourceSet(culture2, createIfNotExists: true, tryParents: true)), (Func<DictionaryEntry, bool>)((DictionaryEntry e) => e.Key.ToString().Equals(key, StringComparison.InvariantCultureIgnoreCase)));
		if (dictionaryEntry.Value == null)
		{
			return result;
		}
		return dictionaryEntry.Value.ToString();
	}
}
