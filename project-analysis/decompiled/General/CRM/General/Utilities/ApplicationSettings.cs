using System.Configuration;

namespace CRM.General.Utilities;

public static class ApplicationSettings
{
	public static string GetValue(string key)
	{
		return GetValue(key, string.Empty);
	}

	public static string GetValue(string key, string defaultValue)
	{
		defaultValue = ((defaultValue != null) ? defaultValue.Trim() : string.Empty);
		if (key == null)
		{
			return defaultValue;
		}
		key = key.Trim();
		if (key == string.Empty)
		{
			return defaultValue;
		}
		try
		{
			string text = ConfigurationManager.AppSettings[key];
			if (string.IsNullOrEmpty(text))
			{
				return defaultValue;
			}
			return text.Trim();
		}
		catch
		{
			return defaultValue;
		}
	}
}
