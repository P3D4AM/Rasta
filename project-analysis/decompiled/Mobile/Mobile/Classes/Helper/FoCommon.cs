using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using CRM.General.Security;
using CRM.Resources;
using Elmah;
using Mobile.Cache.Setting;
using Mobile.Models;

namespace Mobile.Classes.Helper;

public class FoCommon
{
	public FoToken GetToken(string token)
	{
		try
		{
			token = CodeDecode.DeCodding(token);
			string[] array = token.Split(new char[1] { '|' });
			int.TryParse(array[1], out var result);
			return new FoToken
			{
				CompanyId = result,
				Extra = array[3],
				CurrentDateTime = array[5]
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

	public FoCheckVersionResult CheckVersion(string apiVersion, string appName)
	{
		CRMEntities cRMEntities = null;
		FoCheckVersionResult foCheckVersionResult = new FoCheckVersionResult();
		try
		{
			if (string.IsNullOrEmpty(apiVersion))
			{
				foCheckVersionResult.Message = Messages.MobMsgErrorApiVersion;
				foCheckVersionResult.Status = false;
				return foCheckVersionResult;
			}
			if (string.IsNullOrEmpty(appName))
			{
				foCheckVersionResult.Message = Messages.MobMsgErrorApiVersion;
				foCheckVersionResult.Status = false;
				return foCheckVersionResult;
			}
			cRMEntities = new CRMEntities();
			CRMspSelectSystemCrmProject_Result cRMspSelectSystemCrmProject_Result = Enumerable.FirstOrDefault<CRMspSelectSystemCrmProject_Result>((IEnumerable<CRMspSelectSystemCrmProject_Result>)cRMEntities.CRMspSelectSystemCrmProject());
			if (cRMspSelectSystemCrmProject_Result != null)
			{
				string text = cRMspSelectSystemCrmProject_Result.Version ?? "";
				if (VersionConfig.CurrentVerWin != text)
				{
					foCheckVersionResult.Message = Messages.MobMsgErrorConflictsDatabaseVersion.Replace("{0}", text).Replace("{1}", VersionConfig.CurrentVerWin);
					foCheckVersionResult.Status = false;
					cRMEntities?.Dispose();
					return foCheckVersionResult;
				}
				if (appName == "CrmFoAndroid" && FoVersionConfig.CurrentVerApi != apiVersion)
				{
					foCheckVersionResult.Message = Messages.MobMsgErrorConflictsApiVersion.Replace("{0}", apiVersion).Replace("{1}", FoVersionConfig.CurrentVerApi);
					foCheckVersionResult.Status = false;
					cRMEntities?.Dispose();
					return foCheckVersionResult;
				}
				if (appName == "CrmFoIOS" && FoVersionConfig.CurrentIOSVerApi != apiVersion)
				{
					foCheckVersionResult.Message = Messages.MobMsgErrorConflictsApiVersion.Replace("{0}", apiVersion).Replace("{1}", FoVersionConfig.CurrentIOSVerApi);
					foCheckVersionResult.Status = false;
					cRMEntities?.Dispose();
					return foCheckVersionResult;
				}
				if (appName == "CrmFoPWA" && FoVersionConfig.CurrentPWAVerApi != apiVersion)
				{
					foCheckVersionResult.Message = Messages.MobMsgErrorConflictsApiVersion.Replace("{0}", apiVersion).Replace("{1}", FoVersionConfig.CurrentPWAVerApi);
					foCheckVersionResult.Status = false;
					cRMEntities?.Dispose();
					return foCheckVersionResult;
				}
				foCheckVersionResult.Message = "";
				foCheckVersionResult.Status = true;
			}
		}
		catch (Exception e)
		{
			foCheckVersionResult.Message = "";
			foCheckVersionResult.Status = false;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return foCheckVersionResult;
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

	public static FOMobspSelectFoSettingTabInfo_Result GetFoTabInfo(int? cId = null, int? foSettingId = null)
	{
		FOMobspSelectFoSettingTabInfo_Result fOMobspSelectFoSettingTabInfo_Result = new FOMobspSelectFoSettingTabInfo_Result();
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			fOMobspSelectFoSettingTabInfo_Result = Enumerable.FirstOrDefault<FOMobspSelectFoSettingTabInfo_Result>((IEnumerable<FOMobspSelectFoSettingTabInfo_Result>)cRMSpEntities.FOMobspSelectFoSettingTabInfo(lCID, result, cId, foSettingId));
			if (fOMobspSelectFoSettingTabInfo_Result != null)
			{
				fOMobspSelectFoSettingTabInfo_Result.FoShowCmpPrjInfoTab = fOMobspSelectFoSettingTabInfo_Result.FoShowCmpPrjInfoTab.HasValue && fOMobspSelectFoSettingTabInfo_Result.FoShowCmpPrjInfoTab != false;
				fOMobspSelectFoSettingTabInfo_Result.FoShowLinkedCmpPrjInfoTab = fOMobspSelectFoSettingTabInfo_Result.FoShowLinkedCmpPrjInfoTab.HasValue && fOMobspSelectFoSettingTabInfo_Result.FoShowLinkedCmpPrjInfoTab != false;
				fOMobspSelectFoSettingTabInfo_Result.FoShowCmpPordInfoTab = fOMobspSelectFoSettingTabInfo_Result.FoShowCmpPordInfoTab.HasValue && fOMobspSelectFoSettingTabInfo_Result.FoShowCmpPordInfoTab != false;
				fOMobspSelectFoSettingTabInfo_Result.FoShowLinkedCmpPordInfoTab = fOMobspSelectFoSettingTabInfo_Result.FoShowLinkedCmpPordInfoTab.HasValue && fOMobspSelectFoSettingTabInfo_Result.FoShowLinkedCmpPordInfoTab != false;
				fOMobspSelectFoSettingTabInfo_Result.FoShowCmpOrdInfoTab = fOMobspSelectFoSettingTabInfo_Result.FoShowCmpOrdInfoTab.HasValue && fOMobspSelectFoSettingTabInfo_Result.FoShowCmpOrdInfoTab != false;
				fOMobspSelectFoSettingTabInfo_Result.FoShowLinkedCmpOrdInfoTab = fOMobspSelectFoSettingTabInfo_Result.FoShowLinkedCmpOrdInfoTab.HasValue && fOMobspSelectFoSettingTabInfo_Result.FoShowLinkedCmpOrdInfoTab != false;
				fOMobspSelectFoSettingTabInfo_Result.FoShowCmpDraftInfoTab = fOMobspSelectFoSettingTabInfo_Result.FoShowCmpDraftInfoTab.HasValue && fOMobspSelectFoSettingTabInfo_Result.FoShowCmpDraftInfoTab != false;
				fOMobspSelectFoSettingTabInfo_Result.FoShowLinkedCmpDraftInfoTab = fOMobspSelectFoSettingTabInfo_Result.FoShowLinkedCmpDraftInfoTab.HasValue && fOMobspSelectFoSettingTabInfo_Result.FoShowLinkedCmpDraftInfoTab != false;
				fOMobspSelectFoSettingTabInfo_Result.FoShowCmpTicketInfoTab = fOMobspSelectFoSettingTabInfo_Result.FoShowCmpTicketInfoTab.HasValue && fOMobspSelectFoSettingTabInfo_Result.FoShowCmpTicketInfoTab != false;
				fOMobspSelectFoSettingTabInfo_Result.FoShowDyFormInfoTab = fOMobspSelectFoSettingTabInfo_Result.FoShowDyFormInfoTab.HasValue && fOMobspSelectFoSettingTabInfo_Result.FoShowDyFormInfoTab != false;
				fOMobspSelectFoSettingTabInfo_Result.FoShowCmpLinkedInfoTab = fOMobspSelectFoSettingTabInfo_Result.FoShowCmpLinkedInfoTab.HasValue && fOMobspSelectFoSettingTabInfo_Result.FoShowCmpLinkedInfoTab != false;
				fOMobspSelectFoSettingTabInfo_Result.FoCmpInfoTabTitle = fOMobspSelectFoSettingTabInfo_Result.FoCmpInfoTabTitle ?? "";
				fOMobspSelectFoSettingTabInfo_Result.FoLinkedCmpInfoTabTitle = fOMobspSelectFoSettingTabInfo_Result.FoLinkedCmpInfoTabTitle ?? "";
				fOMobspSelectFoSettingTabInfo_Result.FoCmpPrjInfoTabTitle = fOMobspSelectFoSettingTabInfo_Result.FoCmpPrjInfoTabTitle ?? "";
				fOMobspSelectFoSettingTabInfo_Result.FoLinkedCmpPrjInfoTabTitle = fOMobspSelectFoSettingTabInfo_Result.FoLinkedCmpPrjInfoTabTitle ?? "";
				fOMobspSelectFoSettingTabInfo_Result.FoCmpPordInfoTabTitle = fOMobspSelectFoSettingTabInfo_Result.FoCmpPordInfoTabTitle ?? "";
				fOMobspSelectFoSettingTabInfo_Result.FoLinkedCmpPordInfoTabTitle = fOMobspSelectFoSettingTabInfo_Result.FoLinkedCmpPordInfoTabTitle ?? "";
				fOMobspSelectFoSettingTabInfo_Result.FoCmpOrdInfoTabTitle = fOMobspSelectFoSettingTabInfo_Result.FoCmpOrdInfoTabTitle ?? "";
				fOMobspSelectFoSettingTabInfo_Result.FoLinkedCmpOrdInfoTabTitle = fOMobspSelectFoSettingTabInfo_Result.FoLinkedCmpOrdInfoTabTitle ?? "";
				fOMobspSelectFoSettingTabInfo_Result.FoCmpDraftInfoTabTitle = fOMobspSelectFoSettingTabInfo_Result.FoCmpDraftInfoTabTitle ?? "";
				fOMobspSelectFoSettingTabInfo_Result.FoLinkedCmpDraftInfoTabTitle = fOMobspSelectFoSettingTabInfo_Result.FoLinkedCmpDraftInfoTabTitle ?? "";
				fOMobspSelectFoSettingTabInfo_Result.FoCmpTicketInfoTabTitle = fOMobspSelectFoSettingTabInfo_Result.FoCmpTicketInfoTabTitle ?? "";
				fOMobspSelectFoSettingTabInfo_Result.FoDyFormInfoTabTitle = fOMobspSelectFoSettingTabInfo_Result.FoDyFormInfoTabTitle ?? "";
				fOMobspSelectFoSettingTabInfo_Result.FoCmpLinkedInfoTabTitle = fOMobspSelectFoSettingTabInfo_Result.FoCmpLinkedInfoTabTitle ?? "";
				fOMobspSelectFoSettingTabInfo_Result.FoShowBParsianTabs = fOMobspSelectFoSettingTabInfo_Result.FoShowBParsianTabs.HasValue && fOMobspSelectFoSettingTabInfo_Result.FoShowBParsianTabs != false;
				fOMobspSelectFoSettingTabInfo_Result.FoCmpLetterInfoTabTitle = fOMobspSelectFoSettingTabInfo_Result.FoCmpLetterInfoTabTitle ?? "";
				fOMobspSelectFoSettingTabInfo_Result.FoShowCmpLetterInfoTab = fOMobspSelectFoSettingTabInfo_Result.FoShowCmpLetterInfoTab.HasValue && fOMobspSelectFoSettingTabInfo_Result.FoShowCmpLetterInfoTab != false;
				fOMobspSelectFoSettingTabInfo_Result.FoCmpFileInfoTabTitle = fOMobspSelectFoSettingTabInfo_Result.FoCmpFileInfoTabTitle ?? "";
				fOMobspSelectFoSettingTabInfo_Result.FoShowCmpFileInfoTab = fOMobspSelectFoSettingTabInfo_Result.FoShowCmpFileInfoTab.HasValue && fOMobspSelectFoSettingTabInfo_Result.FoShowCmpFileInfoTab != false;
				fOMobspSelectFoSettingTabInfo_Result.FoSurveyInfoTabTitle = fOMobspSelectFoSettingTabInfo_Result.FoSurveyInfoTabTitle ?? "";
				fOMobspSelectFoSettingTabInfo_Result.FoShowSurveyInfoTab = fOMobspSelectFoSettingTabInfo_Result.FoShowSurveyInfoTab.HasValue && fOMobspSelectFoSettingTabInfo_Result.FoShowSurveyInfoTab != false;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpEntities?.Dispose();
		}
		return fOMobspSelectFoSettingTabInfo_Result;
	}
}
