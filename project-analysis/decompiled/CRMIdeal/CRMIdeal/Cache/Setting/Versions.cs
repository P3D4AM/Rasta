using System;
using System.Collections.Generic;
using System.Linq;
using CRM.General.Cache;
using CRM.General.Security;
using CRM.General.Utilities;
using CRM.Models;
using CRMIdeal.Classes.Common;
using Elmah;

namespace CRMIdeal.Cache.Setting;

public static class Versions
{
	private static readonly string MainCacheName = Configuration.CacheDefaultName + Configuration.CacheUniqueName + "-Setting-Versions";

	private static readonly int DefaultTimeInMinutes = Configuration.CacheDefaultTimeInMinutes;

	public static Dictionary<string, bool> Get()
	{
		if (!CacheManager.Get<Dictionary<string, bool>>(MainCacheName, out var value))
		{
			CRMTabelEntities cRMTabelEntities = new CRMTabelEntities();
			try
			{
				value = new Dictionary<string, bool>();
				if (Enumerable.Any<CrmWebSetting>((IEnumerable<CrmWebSetting>)Enumerable.ToList<CrmWebSetting>((IEnumerable<CrmWebSetting>)cRMTabelEntities.CrmWebSetting)))
				{
					string value2 = ApplicationSettings.GetValue("RegisterCode");
					if (value2 != null)
					{
						string[] array = CodeDecode.RegDeCodding(CodeDecode.RegDeCodding(value2).Split(new char[1] { '|' })[1]).Split(new char[1] { '|' });
						foreach (string text in array)
						{
							if (text.EndsWith("0"))
							{
								if (text.Length == 2)
								{
									value.Add(text.Substring(0, 1), value: false);
								}
								else
								{
									value.Add(text.Substring(0, text.Length - 1), value: false);
								}
							}
							else if (text.EndsWith("1"))
							{
								if (text.Length == 2)
								{
									value.Add(text.Substring(0, 1), value: true);
								}
								else
								{
									value.Add(text.Substring(0, text.Length - 1), value: true);
								}
							}
							else
							{
								value.Add("name:" + text, value: true);
							}
						}
					}
				}
				CacheManager.Add(value, MainCacheName, DefaultTimeInMinutes);
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
			}
			finally
			{
				cRMTabelEntities.Dispose();
			}
		}
		return value;
	}

	public static bool Clear()
	{
		try
		{
			CacheManager.Clear(MainCacheName);
			return true;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return false;
	}

	public static bool Update()
	{
		CRMTabelEntities cRMTabelEntities = new CRMTabelEntities();
		try
		{
			Dictionary<string, bool> dictionary = new Dictionary<string, bool>();
			if (Enumerable.Any<CrmWebSetting>((IEnumerable<CrmWebSetting>)Enumerable.ToList<CrmWebSetting>((IEnumerable<CrmWebSetting>)cRMTabelEntities.CrmWebSetting)))
			{
				string value = ApplicationSettings.GetValue("RegisterCode");
				if (value != null)
				{
					string[] array = CodeDecode.RegDeCodding(CodeDecode.RegDeCodding(value).Split(new char[1] { '|' })[1]).Split(new char[1] { '|' });
					foreach (string text in array)
					{
						if (text.EndsWith("0"))
						{
							if (text.Length == 2)
							{
								dictionary.Add(text.Substring(0, 1), value: false);
							}
							else
							{
								dictionary.Add(text.Substring(0, text.Length - 1), value: false);
							}
						}
						else if (text.EndsWith("1"))
						{
							if (text.Length == 2)
							{
								dictionary.Add(text.Substring(0, 1), value: true);
							}
							else
							{
								dictionary.Add(text.Substring(0, text.Length - 1), value: true);
							}
						}
						else
						{
							dictionary.Add("name:" + text, value: true);
						}
					}
				}
			}
			CacheManager.Clear(MainCacheName);
			CacheManager.Add(dictionary, MainCacheName, DefaultTimeInMinutes);
			return true;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMTabelEntities.Dispose();
		}
		return false;
	}
}
