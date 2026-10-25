using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using CRM.General.Security;
using CRM.Resources;
using Elmah;
using Mobile.Cache.Setting;
using Mobile.Models;

namespace Mobile.Classes.Helper;

public class Common
{
	public Token GetToken(string token)
	{
		try
		{
			token = CodeDecode.DeCodding(token);
			string[] array = token.Split(new char[1] { '|' });
			int.TryParse(array[3], out var result);
			int.TryParse(array[1], out var result2);
			return new Token
			{
				RollId = result,
				userId = result2,
				currentDateTime = array[7],
				extra = array[5]
			};
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			return null;
		}
	}

	public bool CheckExtra(string extra)
	{
		if (string.IsNullOrEmpty(extra))
		{
			return false;
		}
		return true;
	}

	public CheckVersionViewModel CheckVersion(string apiVersion, string appName)
	{
		CRMEntities cRMEntities = null;
		CheckVersionViewModel checkVersionViewModel = new CheckVersionViewModel();
		try
		{
			if (string.IsNullOrEmpty(apiVersion))
			{
				checkVersionViewModel.Message = Messages.MobMsgErrorApiVersion;
				checkVersionViewModel.Status = false;
				return checkVersionViewModel;
			}
			if (string.IsNullOrEmpty(appName))
			{
				checkVersionViewModel.Message = Messages.MobMsgErrorApiVersion;
				checkVersionViewModel.Status = false;
				return checkVersionViewModel;
			}
			cRMEntities = new CRMEntities();
			CRMspSelectSystemCrmProject_Result cRMspSelectSystemCrmProject_Result = Enumerable.FirstOrDefault<CRMspSelectSystemCrmProject_Result>((IEnumerable<CRMspSelectSystemCrmProject_Result>)cRMEntities.CRMspSelectSystemCrmProject());
			if (cRMspSelectSystemCrmProject_Result != null)
			{
				string text = cRMspSelectSystemCrmProject_Result.Version ?? "";
				if (VersionConfig.CurrentVerWin != text)
				{
					checkVersionViewModel.Message = Messages.MobMsgErrorConflictsDatabaseVersion.Replace("{0}", text).Replace("{1}", VersionConfig.CurrentVerWin);
					checkVersionViewModel.Status = false;
					cRMEntities?.Dispose();
					return checkVersionViewModel;
				}
				if (appName == "Android" && VersionConfig.CurrentVerApi != apiVersion)
				{
					checkVersionViewModel.Message = Messages.MobMsgErrorConflictsApiVersion.Replace("{0}", apiVersion).Replace("{1}", VersionConfig.CurrentVerApi);
					checkVersionViewModel.Status = false;
					cRMEntities?.Dispose();
					return checkVersionViewModel;
				}
				if (appName == "IOS" && VersionConfig.CurrentIOSVerApi != apiVersion)
				{
					checkVersionViewModel.Message = Messages.MobMsgErrorConflictsApiVersion.Replace("{0}", apiVersion).Replace("{1}", VersionConfig.CurrentIOSVerApi);
					checkVersionViewModel.Status = false;
					cRMEntities?.Dispose();
					return checkVersionViewModel;
				}
				if (appName == "PWA" && VersionConfig.CurrentPwaVerApi != apiVersion)
				{
					checkVersionViewModel.Message = Messages.MobMsgErrorConflictsApiVersion.Replace("{0}", apiVersion).Replace("{1}", VersionConfig.CurrentPwaVerApi);
					checkVersionViewModel.Status = false;
					cRMEntities?.Dispose();
					return checkVersionViewModel;
				}
				if (appName == "Ocsan" && VersionConfig.CurrentOcsanVerApi != apiVersion)
				{
					checkVersionViewModel.Message = Messages.MobMsgErrorConflictsApiVersion.Replace("{0}", apiVersion).Replace("{1}", VersionConfig.CurrentOcsanVerApi);
					checkVersionViewModel.Status = false;
					cRMEntities?.Dispose();
					return checkVersionViewModel;
				}
				if (appName == "HrmAndroid" && VersionConfig.CurrentHrmVerApi != apiVersion)
				{
					checkVersionViewModel.Message = Messages.MobMsgErrorConflictsApiVersion.Replace("{0}", apiVersion).Replace("{1}", VersionConfig.CurrentHrmVerApi);
					checkVersionViewModel.Status = false;
					cRMEntities?.Dispose();
					return checkVersionViewModel;
				}
				if (appName == "HrmIOS" && VersionConfig.CurrentHrmIosVerApi != apiVersion)
				{
					checkVersionViewModel.Message = Messages.MobMsgErrorConflictsApiVersion.Replace("{0}", apiVersion).Replace("{1}", VersionConfig.CurrentHrmIosVerApi);
					checkVersionViewModel.Status = false;
					cRMEntities?.Dispose();
					return checkVersionViewModel;
				}
				if (appName == "HrmPWA" && VersionConfig.CurrentHrmPwaVerApi != apiVersion)
				{
					checkVersionViewModel.Message = Messages.MobMsgErrorConflictsApiVersion.Replace("{0}", apiVersion).Replace("{1}", VersionConfig.CurrentHrmPwaVerApi);
					checkVersionViewModel.Status = false;
					cRMEntities?.Dispose();
					return checkVersionViewModel;
				}
				if (appName == "CicAndroid" && VersionConfig.CurrentCicVerApi != apiVersion)
				{
					checkVersionViewModel.Message = Messages.MobMsgErrorConflictsApiVersion.Replace("{0}", apiVersion).Replace("{1}", VersionConfig.CurrentCicVerApi);
					checkVersionViewModel.Status = false;
					cRMEntities?.Dispose();
					return checkVersionViewModel;
				}
				checkVersionViewModel.Message = "";
				checkVersionViewModel.Status = true;
			}
		}
		catch (Exception e)
		{
			checkVersionViewModel.Message = "";
			checkVersionViewModel.Status = false;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return checkVersionViewModel;
	}

	public static string GetUserName(int userId, int defLangId, int currLangId, int? cId = null)
	{
		CRMEntities cRMEntities = new CRMEntities();
		string result = "";
		try
		{
			MobspSelectUsers_Result mobspSelectUsers_Result = Enumerable.FirstOrDefault<MobspSelectUsers_Result>((IEnumerable<MobspSelectUsers_Result>)cRMEntities.MobspSelectUsers(userId, currLangId, defLangId, cId));
			if (mobspSelectUsers_Result != null)
			{
				result = ((!string.IsNullOrEmpty(mobspSelectUsers_Result.FullName)) ? mobspSelectUsers_Result.FullName : "");
			}
			cRMEntities.Dispose();
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			cRMEntities.Dispose();
		}
		finally
		{
			cRMEntities.Dispose();
		}
		return result;
	}

	public TokenForLoginByCmpMobile GetTokenForLoginByCmpMobile(string token)
	{
		try
		{
			token = CodeDecode.DeCodding(token);
			string[] array = token.Split(new char[1] { '|' });
			int.TryParse(array[1], out var result);
			int.TryParse(array[3], out var result2);
			return new TokenForLoginByCmpMobile
			{
				CompanyId = result,
				PersonId = result2,
				AuthenticationCode = array[5],
				CurrentDateTime = array[7]
			};
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			return null;
		}
	}

	public string DelphiCToRgbolor(string rgbColor)
	{
		string result = null;
		if (!string.IsNullOrEmpty(rgbColor))
		{
			string text = rgbColor.Substring(3, 2);
			string text2 = rgbColor.Substring(5, 2);
			string text3 = rgbColor.Substring(7, 2);
			result = "#" + text3 + text2 + text;
		}
		return result;
	}

	public static bool CheckUserImeiCode(int userId, string imei, string appName)
	{
		if (string.IsNullOrEmpty(imei) || string.IsNullOrEmpty(appName))
		{
			return true;
		}
		CRMSpEntities cRMSpEntities = null;
		bool result = false;
		try
		{
			cRMSpEntities = new CRMSpEntities();
			result = Enumerable.Any<MobspSelectActiveUserAppDeviceInfoByUserId_Result>((IEnumerable<MobspSelectActiveUserAppDeviceInfoByUserId_Result>)Enumerable.ToList<MobspSelectActiveUserAppDeviceInfoByUserId_Result>((IEnumerable<MobspSelectActiveUserAppDeviceInfoByUserId_Result>)cRMSpEntities.MobspSelectActiveUserAppDeviceInfoByUserId(userId, appName)), (Func<MobspSelectActiveUserAppDeviceInfoByUserId_Result, bool>)((MobspSelectActiveUserAppDeviceInfoByUserId_Result e) => e.ImeiCode == imei));
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		finally
		{
			cRMSpEntities?.Dispose();
		}
		return result;
	}

	public static string GetDefMapName()
	{
		string result = "Leaflet";
		try
		{
			List<MobspSelectCrmWebSetting_Result> list = WebSetting.Get();
			if (list != null)
			{
				MobspSelectCrmWebSetting_Result mobspSelectCrmWebSetting_Result = Enumerable.FirstOrDefault<MobspSelectCrmWebSetting_Result>((IEnumerable<MobspSelectCrmWebSetting_Result>)list, (Func<MobspSelectCrmWebSetting_Result, bool>)((MobspSelectCrmWebSetting_Result c) => c.Key.Equals("DefMapName")));
				if (mobspSelectCrmWebSetting_Result != null && !string.IsNullOrWhiteSpace(mobspSelectCrmWebSetting_Result.Value.Split(new char[1] { ':' })[0]))
				{
					result = mobspSelectCrmWebSetting_Result.Value.Split(new char[1] { ':' })[0];
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public static void InsTextToElmah(string ex = "")
	{
		if (!string.IsNullOrWhiteSpace(ex))
		{
			ErrorSignal.FromCurrentContext().Raise(new Exception(ex));
		}
	}

	public static bool IsKara()
	{
		bool result = false;
		try
		{
			string text = "3110-9202-2572";
			MobspSelectCrmsysSetting_Result mobspSelectCrmsysSetting_Result = SysSeting.Get();
			if (mobspSelectCrmsysSetting_Result != null && !string.IsNullOrEmpty(mobspSelectCrmsysSetting_Result.LockSerial) && mobspSelectCrmsysSetting_Result.LockSerial == text)
			{
				result = true;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public static double GetDistance(double longitude, double latitude, double otherLongitude, double otherLatitude)
	{
		double num = latitude * (Math.PI / 180.0);
		double num2 = longitude * (Math.PI / 180.0);
		double num3 = otherLatitude * (Math.PI / 180.0);
		double num4 = otherLongitude * (Math.PI / 180.0) - num2;
		double num5 = Math.Pow(Math.Sin((num3 - num) / 2.0), 2.0) + Math.Cos(num) * Math.Cos(num3) * Math.Pow(Math.Sin(num4 / 2.0), 2.0);
		return 6376500.0 * (2.0 * Math.Atan2(Math.Sqrt(num5), Math.Sqrt(1.0 - num5)));
	}

	public static string ClearHiddenCharacters(string value)
	{
		if (string.IsNullOrWhiteSpace(value))
		{
			return value;
		}
		value = value.TrimEnd(Array.Empty<char>()).TrimStart(Array.Empty<char>());
		return Enumerable.Aggregate<KeyValuePair<string, string>, string>((IEnumerable<KeyValuePair<string, string>>)new Dictionary<string, string> { ["\ufeff"] = "" }, value, (Func<string, KeyValuePair<string, string>, string>)((string current, KeyValuePair<string, string> item) => current.Replace(item.Key, item.Value)));
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
}
