using System;
using System.Collections.Generic;
using System.Data.Mapping;
using System.Text;

namespace Edm_EntityMappingGeneratedViews;

public sealed class ViewsForBaseEntitySets270A42A9E0C037CF63C510E2FB18E31302FEFA1C44E7433482EAB6C038F87C14 : EntityViewContainer
{
	public ViewsForBaseEntitySets270A42A9E0C037CF63C510E2FB18E31302FEFA1C44E7433482EAB6C038F87C14()
	{
		base.EdmEntityContainerName = "CRMEntities";
		base.StoreEntityContainerName = "ModelStoreContainer";
		base.HashOverMappingClosure = "0619f7fa0c967b902bdd74f5bed2b504c4115d129bf7cfb5e00e770bd494b8fd";
		base.HashOverAllExtentViews = "fba911ae6b49c3684331b29c7e0b95b2aa6769577ae7f8cc3fbc9f4f9fc15a9e";
		base.ViewCount = 8;
	}

	protected override KeyValuePair<string, string> GetViewAt(int index)
	{
		return index switch
		{
			0 => GetView0(), 
			1 => GetView1(), 
			2 => GetView2(), 
			3 => GetView3(), 
			4 => GetView4(), 
			5 => GetView5(), 
			6 => GetView6(), 
			7 => GetView7(), 
			_ => throw new IndexOutOfRangeException(), 
		};
	}

	private KeyValuePair<string, string> GetView0()
	{
		StringBuilder stringBuilder = new StringBuilder(3164);
		stringBuilder.Append("\r\n    SELECT VALUE -- Constructing MobCompanyAppInfo\r\n        [Model.Store.MobCo");
		stringBuilder.Append("mpanyAppInfo](T1.MobCompanyAppInfo_MobCompanyAppInfoID, T1.MobCompanyAppInfo_Com");
		stringBuilder.Append("panyID, T1.MobCompanyAppInfo_CompanyPersonID, T1.MobCompanyAppInfo_RegisterCode,");
		stringBuilder.Append(" T1.MobCompanyAppInfo_DownloadURL, T1.MobCompanyAppInfo_WcfURL, T1.MobCompanyApp");
		stringBuilder.Append("Info_ExtraCode, T1.MobCompanyAppInfo_IsActive, T1.MobCompanyAppInfo_FirstRegiste");
		stringBuilder.Append("rUserId, T1.MobCompanyAppInfo_FirstRegisterDate, T1.MobCompanyAppInfo_FirstRegis");
		stringBuilder.Append("terDatePersian, T1.MobCompanyAppInfo_UserId, T1.MobCompanyAppInfo_RegisterDate, ");
		stringBuilder.Append("T1.MobCompanyAppInfo_RegisterDatePersian, T1.MobCompanyAppInfo_Year1, T1.MobComp");
		stringBuilder.Append("anyAppInfo_Month1, T1.MobCompanyAppInfo_AppType, T1.MobCompanyAppInfo_LanguageID");
		stringBuilder.Append(", T1.MobCompanyAppInfo_GUId, T1.MobCompanyAppInfo_ImeiCode, T1.MobCompanyAppInfo");
		stringBuilder.Append("_cmp, T1.MobCompanyAppInfo_DevTypeId, T1.MobCompanyAppInfo_AppName, T1.MobCompan");
		stringBuilder.Append("yAppInfo_LastVersion, T1.MobCompanyAppInfo_NewVersionDownloadURL, T1.MobCompanyA");
		stringBuilder.Append("ppInfo_CurrentVersion, T1.MobCompanyAppInfo_NewVersionAlarmActive, T1.MobCompany");
		stringBuilder.Append("AppInfo_JustLastVersionActive, T1.MobCompanyAppInfo_AppDomain, T1.MobCompanyAppI");
		stringBuilder.Append("nfo_PwaServerUrl)\r\n    FROM (\r\n        SELECT \r\n            T.MobCompanyAppInfoI");
		stringBuilder.Append("D AS MobCompanyAppInfo_MobCompanyAppInfoID, \r\n            T.CompanyID AS MobComp");
		stringBuilder.Append("anyAppInfo_CompanyID, \r\n            T.CompanyPersonID AS MobCompanyAppInfo_Compa");
		stringBuilder.Append("nyPersonID, \r\n            T.RegisterCode AS MobCompanyAppInfo_RegisterCode, \r\n  ");
		stringBuilder.Append("          T.DownloadURL AS MobCompanyAppInfo_DownloadURL, \r\n            T.WcfURL");
		stringBuilder.Append(" AS MobCompanyAppInfo_WcfURL, \r\n            T.ExtraCode AS MobCompanyAppInfo_Ext");
		stringBuilder.Append("raCode, \r\n            T.IsActive AS MobCompanyAppInfo_IsActive, \r\n            T.");
		stringBuilder.Append("FirstRegisterUserId AS MobCompanyAppInfo_FirstRegisterUserId, \r\n            T.Fi");
		stringBuilder.Append("rstRegisterDate AS MobCompanyAppInfo_FirstRegisterDate, \r\n            T.FirstReg");
		stringBuilder.Append("isterDatePersian AS MobCompanyAppInfo_FirstRegisterDatePersian, \r\n            T.");
		stringBuilder.Append("UserId AS MobCompanyAppInfo_UserId, \r\n            T.RegisterDate AS MobCompanyAp");
		stringBuilder.Append("pInfo_RegisterDate, \r\n            T.RegisterDatePersian AS MobCompanyAppInfo_Reg");
		stringBuilder.Append("isterDatePersian, \r\n            T.Year1 AS MobCompanyAppInfo_Year1, \r\n          ");
		stringBuilder.Append("  T.Month1 AS MobCompanyAppInfo_Month1, \r\n            T.AppType AS MobCompanyApp");
		stringBuilder.Append("Info_AppType, \r\n            T.LanguageID AS MobCompanyAppInfo_LanguageID, \r\n    ");
		stringBuilder.Append("        T.GUId AS MobCompanyAppInfo_GUId, \r\n            T.ImeiCode AS MobCompany");
		stringBuilder.Append("AppInfo_ImeiCode, \r\n            T.cmp AS MobCompanyAppInfo_cmp, \r\n            T.");
		stringBuilder.Append("DevTypeId AS MobCompanyAppInfo_DevTypeId, \r\n            T.AppName AS MobCompanyA");
		stringBuilder.Append("ppInfo_AppName, \r\n            T.LastVersion AS MobCompanyAppInfo_LastVersion, \r\n");
		stringBuilder.Append("            T.NewVersionDownloadURL AS MobCompanyAppInfo_NewVersionDownloadURL, ");
		stringBuilder.Append("\r\n            T.CurrentVersion AS MobCompanyAppInfo_CurrentVersion, \r\n          ");
		stringBuilder.Append("  T.NewVersionAlarmActive AS MobCompanyAppInfo_NewVersionAlarmActive, \r\n        ");
		stringBuilder.Append("    T.JustLastVersionActive AS MobCompanyAppInfo_JustLastVersionActive, \r\n      ");
		stringBuilder.Append("      T.AppDomain AS MobCompanyAppInfo_AppDomain, \r\n            T.PwaServerUrl A");
		stringBuilder.Append("S MobCompanyAppInfo_PwaServerUrl, \r\n            True AS _from0\r\n        FROM CRM");
		stringBuilder.Append("Entities.MobCompanyAppInfo AS T\r\n    ) AS T1");
		return new KeyValuePair<string, string>("ModelStoreContainer.MobCompanyAppInfo", stringBuilder.ToString());
	}

	private KeyValuePair<string, string> GetView1()
	{
		StringBuilder stringBuilder = new StringBuilder(3169);
		stringBuilder.Append("\r\n    SELECT VALUE -- Constructing MobCompanyAppInfo\r\n        [MOBModel.MobCompa");
		stringBuilder.Append("nyAppInfo](T1.MobCompanyAppInfo_MobCompanyAppInfoID, T1.MobCompanyAppInfo_Compan");
		stringBuilder.Append("yID, T1.MobCompanyAppInfo_CompanyPersonID, T1.MobCompanyAppInfo_RegisterCode, T1");
		stringBuilder.Append(".MobCompanyAppInfo_DownloadURL, T1.MobCompanyAppInfo_WcfURL, T1.MobCompanyAppInf");
		stringBuilder.Append("o_ExtraCode, T1.MobCompanyAppInfo_IsActive, T1.MobCompanyAppInfo_FirstRegisterUs");
		stringBuilder.Append("erId, T1.MobCompanyAppInfo_FirstRegisterDate, T1.MobCompanyAppInfo_FirstRegister");
		stringBuilder.Append("DatePersian, T1.MobCompanyAppInfo_UserId, T1.MobCompanyAppInfo_RegisterDate, T1.");
		stringBuilder.Append("MobCompanyAppInfo_RegisterDatePersian, T1.MobCompanyAppInfo_Year1, T1.MobCompany");
		stringBuilder.Append("AppInfo_Month1, T1.MobCompanyAppInfo_AppType, T1.MobCompanyAppInfo_LanguageID, T");
		stringBuilder.Append("1.MobCompanyAppInfo_GUId, T1.MobCompanyAppInfo_ImeiCode, T1.MobCompanyAppInfo_cm");
		stringBuilder.Append("p, T1.MobCompanyAppInfo_DevTypeId, T1.MobCompanyAppInfo_AppName, T1.MobCompanyAp");
		stringBuilder.Append("pInfo_LastVersion, T1.MobCompanyAppInfo_NewVersionDownloadURL, T1.MobCompanyAppI");
		stringBuilder.Append("nfo_CurrentVersion, T1.MobCompanyAppInfo_NewVersionAlarmActive, T1.MobCompanyApp");
		stringBuilder.Append("Info_JustLastVersionActive, T1.MobCompanyAppInfo_AppDomain, T1.MobCompanyAppInfo");
		stringBuilder.Append("_PwaServerUrl)\r\n    FROM (\r\n        SELECT \r\n            T.MobCompanyAppInfoID A");
		stringBuilder.Append("S MobCompanyAppInfo_MobCompanyAppInfoID, \r\n            T.CompanyID AS MobCompany");
		stringBuilder.Append("AppInfo_CompanyID, \r\n            T.CompanyPersonID AS MobCompanyAppInfo_CompanyP");
		stringBuilder.Append("ersonID, \r\n            T.RegisterCode AS MobCompanyAppInfo_RegisterCode, \r\n     ");
		stringBuilder.Append("       T.DownloadURL AS MobCompanyAppInfo_DownloadURL, \r\n            T.WcfURL AS");
		stringBuilder.Append(" MobCompanyAppInfo_WcfURL, \r\n            T.ExtraCode AS MobCompanyAppInfo_ExtraC");
		stringBuilder.Append("ode, \r\n            T.IsActive AS MobCompanyAppInfo_IsActive, \r\n            T.Fir");
		stringBuilder.Append("stRegisterUserId AS MobCompanyAppInfo_FirstRegisterUserId, \r\n            T.First");
		stringBuilder.Append("RegisterDate AS MobCompanyAppInfo_FirstRegisterDate, \r\n            T.FirstRegist");
		stringBuilder.Append("erDatePersian AS MobCompanyAppInfo_FirstRegisterDatePersian, \r\n            T.Use");
		stringBuilder.Append("rId AS MobCompanyAppInfo_UserId, \r\n            T.RegisterDate AS MobCompanyAppIn");
		stringBuilder.Append("fo_RegisterDate, \r\n            T.RegisterDatePersian AS MobCompanyAppInfo_Regist");
		stringBuilder.Append("erDatePersian, \r\n            T.Year1 AS MobCompanyAppInfo_Year1, \r\n            T");
		stringBuilder.Append(".Month1 AS MobCompanyAppInfo_Month1, \r\n            T.AppType AS MobCompanyAppInf");
		stringBuilder.Append("o_AppType, \r\n            T.LanguageID AS MobCompanyAppInfo_LanguageID, \r\n       ");
		stringBuilder.Append("     T.GUId AS MobCompanyAppInfo_GUId, \r\n            T.ImeiCode AS MobCompanyApp");
		stringBuilder.Append("Info_ImeiCode, \r\n            T.cmp AS MobCompanyAppInfo_cmp, \r\n            T.Dev");
		stringBuilder.Append("TypeId AS MobCompanyAppInfo_DevTypeId, \r\n            T.AppName AS MobCompanyAppI");
		stringBuilder.Append("nfo_AppName, \r\n            T.LastVersion AS MobCompanyAppInfo_LastVersion, \r\n   ");
		stringBuilder.Append("         T.NewVersionDownloadURL AS MobCompanyAppInfo_NewVersionDownloadURL, \r\n ");
		stringBuilder.Append("           T.CurrentVersion AS MobCompanyAppInfo_CurrentVersion, \r\n            T");
		stringBuilder.Append(".NewVersionAlarmActive AS MobCompanyAppInfo_NewVersionAlarmActive, \r\n           ");
		stringBuilder.Append(" T.JustLastVersionActive AS MobCompanyAppInfo_JustLastVersionActive, \r\n         ");
		stringBuilder.Append("   T.AppDomain AS MobCompanyAppInfo_AppDomain, \r\n            T.PwaServerUrl AS M");
		stringBuilder.Append("obCompanyAppInfo_PwaServerUrl, \r\n            True AS _from0\r\n        FROM ModelS");
		stringBuilder.Append("toreContainer.MobCompanyAppInfo AS T\r\n    ) AS T1");
		return new KeyValuePair<string, string>("CRMEntities.MobCompanyAppInfo", stringBuilder.ToString());
	}

	private KeyValuePair<string, string> GetView2()
	{
		return new KeyValuePair<string, string>("ModelStoreContainer.CrmPersonPicture", "\r\n    SELECT VALUE -- Constructing CrmPersonPicture\r\n        [Model.Store.CrmPersonPicture](T1.CrmPersonPicture_PersonPictureID, T1.CrmPersonPicture_CompanyPersonId, T1.CrmPersonPicture_PersonPicture, T1.CrmPersonPicture_PictureDesc, T1.CrmPersonPicture_UserId, T1.CrmPersonPicture_Year1, T1.CrmPersonPicture_Month1, T1.CrmPersonPicture_RegisterDate, T1.CrmPersonPicture_RegisterDatePersian, T1.CrmPersonPicture_GUId, T1.CrmPersonPicture_AppType, T1.CrmPersonPicture_LanguageID, T1.CrmPersonPicture_FirstRegisterUserId, T1.CrmPersonPicture_FirstRegisterDatePersian, T1.CrmPersonPicture_FirstRegisterDate)\r\n    FROM (\r\n        SELECT \r\n            T.PersonPictureID AS CrmPersonPicture_PersonPictureID, \r\n            T.CompanyPersonId AS CrmPersonPicture_CompanyPersonId, \r\n            T.PersonPicture AS CrmPersonPicture_PersonPicture, \r\n            T.PictureDesc AS CrmPersonPicture_PictureDesc, \r\n            T.UserId AS CrmPersonPicture_UserId, \r\n            T.Year1 AS CrmPersonPicture_Year1, \r\n            T.Month1 AS CrmPersonPicture_Month1, \r\n            T.RegisterDate AS CrmPersonPicture_RegisterDate, \r\n            T.RegisterDatePersian AS CrmPersonPicture_RegisterDatePersian, \r\n            T.GUId AS CrmPersonPicture_GUId, \r\n            T.AppType AS CrmPersonPicture_AppType, \r\n            T.LanguageID AS CrmPersonPicture_LanguageID, \r\n            T.FirstRegisterUserId AS CrmPersonPicture_FirstRegisterUserId, \r\n            T.FirstRegisterDatePersian AS CrmPersonPicture_FirstRegisterDatePersian, \r\n            T.FirstRegisterDate AS CrmPersonPicture_FirstRegisterDate, \r\n            True AS _from0\r\n        FROM CRMEntities.CrmPersonPicture AS T\r\n    ) AS T1");
	}

	private KeyValuePair<string, string> GetView3()
	{
		return new KeyValuePair<string, string>("CRMEntities.CrmPersonPicture", "\r\n    SELECT VALUE -- Constructing CrmPersonPicture\r\n        [MOBModel.CrmPersonPicture](T1.CrmPersonPicture_PersonPictureID, T1.CrmPersonPicture_CompanyPersonId, T1.CrmPersonPicture_PersonPicture, T1.CrmPersonPicture_PictureDesc, T1.CrmPersonPicture_UserId, T1.CrmPersonPicture_Year1, T1.CrmPersonPicture_Month1, T1.CrmPersonPicture_RegisterDate, T1.CrmPersonPicture_RegisterDatePersian, T1.CrmPersonPicture_GUId, T1.CrmPersonPicture_AppType, T1.CrmPersonPicture_LanguageID, T1.CrmPersonPicture_FirstRegisterUserId, T1.CrmPersonPicture_FirstRegisterDatePersian, T1.CrmPersonPicture_FirstRegisterDate)\r\n    FROM (\r\n        SELECT \r\n            T.PersonPictureID AS CrmPersonPicture_PersonPictureID, \r\n            T.CompanyPersonId AS CrmPersonPicture_CompanyPersonId, \r\n            T.PersonPicture AS CrmPersonPicture_PersonPicture, \r\n            T.PictureDesc AS CrmPersonPicture_PictureDesc, \r\n            T.UserId AS CrmPersonPicture_UserId, \r\n            T.Year1 AS CrmPersonPicture_Year1, \r\n            T.Month1 AS CrmPersonPicture_Month1, \r\n            T.RegisterDate AS CrmPersonPicture_RegisterDate, \r\n            T.RegisterDatePersian AS CrmPersonPicture_RegisterDatePersian, \r\n            T.GUId AS CrmPersonPicture_GUId, \r\n            T.AppType AS CrmPersonPicture_AppType, \r\n            T.LanguageID AS CrmPersonPicture_LanguageID, \r\n            T.FirstRegisterUserId AS CrmPersonPicture_FirstRegisterUserId, \r\n            T.FirstRegisterDatePersian AS CrmPersonPicture_FirstRegisterDatePersian, \r\n            T.FirstRegisterDate AS CrmPersonPicture_FirstRegisterDate, \r\n            True AS _from0\r\n        FROM ModelStoreContainer.CrmPersonPicture AS T\r\n    ) AS T1");
	}

	private KeyValuePair<string, string> GetView4()
	{
		StringBuilder stringBuilder = new StringBuilder(2247);
		stringBuilder.Append("\r\n    SELECT VALUE -- Constructing CrmWebSetting\r\n        [Model.Store.CrmWebSet");
		stringBuilder.Append("ting](T1.CrmWebSetting_WebSettingID, T1.CrmWebSetting_KeyFa, T1.CrmWebSetting_Ke");
		stringBuilder.Append("y, T1.CrmWebSetting_Value, T1.CrmWebSetting_Type, T1.CrmWebSetting_IsActive, T1.");
		stringBuilder.Append("CrmWebSetting_IsRequired, T1.CrmWebSetting_RregularExpression, T1.CrmWebSetting_");
		stringBuilder.Append("IsDecoded, T1.CrmWebSetting_MaxLength, T1.CrmWebSetting_MinLength, T1.CrmWebSett");
		stringBuilder.Append("ing_Description, T1.CrmWebSetting_UserId, T1.CrmWebSetting_Year1, T1.CrmWebSetti");
		stringBuilder.Append("ng_Month1, T1.CrmWebSetting_RegisterDate, T1.CrmWebSetting_RegisterDatePersian, ");
		stringBuilder.Append("T1.CrmWebSetting_GUId, T1.CrmWebSetting_AppType, T1.CrmWebSetting_LanguageID, T1");
		stringBuilder.Append(".CrmWebSetting_FirstRegisterUserId, T1.CrmWebSetting_FirstRegisterDatePersian, T");
		stringBuilder.Append("1.CrmWebSetting_FirstRegisterDate, T1.CrmWebSetting_OrderView)\r\n    FROM (\r\n    ");
		stringBuilder.Append("    SELECT \r\n            T.WebSettingID AS CrmWebSetting_WebSettingID, \r\n       ");
		stringBuilder.Append("     T.KeyFa AS CrmWebSetting_KeyFa, \r\n            T.[Key] AS CrmWebSetting_Key,");
		stringBuilder.Append(" \r\n            T.[Value] AS CrmWebSetting_Value, \r\n            T.Type AS CrmWebS");
		stringBuilder.Append("etting_Type, \r\n            T.IsActive AS CrmWebSetting_IsActive, \r\n            T");
		stringBuilder.Append(".IsRequired AS CrmWebSetting_IsRequired, \r\n            T.RregularExpression AS C");
		stringBuilder.Append("rmWebSetting_RregularExpression, \r\n            T.IsDecoded AS CrmWebSetting_IsDe");
		stringBuilder.Append("coded, \r\n            T.MaxLength AS CrmWebSetting_MaxLength, \r\n            T.Min");
		stringBuilder.Append("Length AS CrmWebSetting_MinLength, \r\n            T.Description AS CrmWebSetting_");
		stringBuilder.Append("Description, \r\n            T.UserId AS CrmWebSetting_UserId, \r\n            T.Yea");
		stringBuilder.Append("r1 AS CrmWebSetting_Year1, \r\n            T.Month1 AS CrmWebSetting_Month1, \r\n   ");
		stringBuilder.Append("         T.RegisterDate AS CrmWebSetting_RegisterDate, \r\n            T.RegisterD");
		stringBuilder.Append("atePersian AS CrmWebSetting_RegisterDatePersian, \r\n            T.GUId AS CrmWebS");
		stringBuilder.Append("etting_GUId, \r\n            T.AppType AS CrmWebSetting_AppType, \r\n            T.L");
		stringBuilder.Append("anguageID AS CrmWebSetting_LanguageID, \r\n            T.FirstRegisterUserId AS Cr");
		stringBuilder.Append("mWebSetting_FirstRegisterUserId, \r\n            T.FirstRegisterDatePersian AS Crm");
		stringBuilder.Append("WebSetting_FirstRegisterDatePersian, \r\n            T.FirstRegisterDate AS CrmWeb");
		stringBuilder.Append("Setting_FirstRegisterDate, \r\n            T.OrderView AS CrmWebSetting_OrderView,");
		stringBuilder.Append(" \r\n            True AS _from0\r\n        FROM CRMEntities.CrmWebSetting AS T\r\n    ");
		stringBuilder.Append(") AS T1");
		return new KeyValuePair<string, string>("ModelStoreContainer.CrmWebSetting", stringBuilder.ToString());
	}

	private KeyValuePair<string, string> GetView5()
	{
		StringBuilder stringBuilder = new StringBuilder(2252);
		stringBuilder.Append("\r\n    SELECT VALUE -- Constructing CrmWebSetting\r\n        [MOBModel.CrmWebSettin");
		stringBuilder.Append("g](T1.CrmWebSetting_WebSettingID, T1.CrmWebSetting_KeyFa, T1.CrmWebSetting_Key, ");
		stringBuilder.Append("T1.CrmWebSetting_Value, T1.CrmWebSetting_Type, T1.CrmWebSetting_IsActive, T1.Crm");
		stringBuilder.Append("WebSetting_IsRequired, T1.CrmWebSetting_RregularExpression, T1.CrmWebSetting_IsD");
		stringBuilder.Append("ecoded, T1.CrmWebSetting_MaxLength, T1.CrmWebSetting_MinLength, T1.CrmWebSetting");
		stringBuilder.Append("_Description, T1.CrmWebSetting_UserId, T1.CrmWebSetting_Year1, T1.CrmWebSetting_");
		stringBuilder.Append("Month1, T1.CrmWebSetting_RegisterDate, T1.CrmWebSetting_RegisterDatePersian, T1.");
		stringBuilder.Append("CrmWebSetting_GUId, T1.CrmWebSetting_AppType, T1.CrmWebSetting_LanguageID, T1.Cr");
		stringBuilder.Append("mWebSetting_FirstRegisterUserId, T1.CrmWebSetting_FirstRegisterDatePersian, T1.C");
		stringBuilder.Append("rmWebSetting_FirstRegisterDate, T1.CrmWebSetting_OrderView)\r\n    FROM (\r\n       ");
		stringBuilder.Append(" SELECT \r\n            T.WebSettingID AS CrmWebSetting_WebSettingID, \r\n          ");
		stringBuilder.Append("  T.KeyFa AS CrmWebSetting_KeyFa, \r\n            T.[Key] AS CrmWebSetting_Key, \r\n");
		stringBuilder.Append("            T.[Value] AS CrmWebSetting_Value, \r\n            T.Type AS CrmWebSett");
		stringBuilder.Append("ing_Type, \r\n            T.IsActive AS CrmWebSetting_IsActive, \r\n            T.Is");
		stringBuilder.Append("Required AS CrmWebSetting_IsRequired, \r\n            T.RregularExpression AS CrmW");
		stringBuilder.Append("ebSetting_RregularExpression, \r\n            T.IsDecoded AS CrmWebSetting_IsDecod");
		stringBuilder.Append("ed, \r\n            T.MaxLength AS CrmWebSetting_MaxLength, \r\n            T.MinLen");
		stringBuilder.Append("gth AS CrmWebSetting_MinLength, \r\n            T.Description AS CrmWebSetting_Des");
		stringBuilder.Append("cription, \r\n            T.UserId AS CrmWebSetting_UserId, \r\n            T.Year1 ");
		stringBuilder.Append("AS CrmWebSetting_Year1, \r\n            T.Month1 AS CrmWebSetting_Month1, \r\n      ");
		stringBuilder.Append("      T.RegisterDate AS CrmWebSetting_RegisterDate, \r\n            T.RegisterDate");
		stringBuilder.Append("Persian AS CrmWebSetting_RegisterDatePersian, \r\n            T.GUId AS CrmWebSett");
		stringBuilder.Append("ing_GUId, \r\n            T.AppType AS CrmWebSetting_AppType, \r\n            T.Lang");
		stringBuilder.Append("uageID AS CrmWebSetting_LanguageID, \r\n            T.FirstRegisterUserId AS CrmWe");
		stringBuilder.Append("bSetting_FirstRegisterUserId, \r\n            T.FirstRegisterDatePersian AS CrmWeb");
		stringBuilder.Append("Setting_FirstRegisterDatePersian, \r\n            T.FirstRegisterDate AS CrmWebSet");
		stringBuilder.Append("ting_FirstRegisterDate, \r\n            T.OrderView AS CrmWebSetting_OrderView, \r\n");
		stringBuilder.Append("            True AS _from0\r\n        FROM ModelStoreContainer.CrmWebSetting AS T\r");
		stringBuilder.Append("\n    ) AS T1");
		return new KeyValuePair<string, string>("CRMEntities.CrmWebSetting", stringBuilder.ToString());
	}

	private KeyValuePair<string, string> GetView6()
	{
		return new KeyValuePair<string, string>("ModelStoreContainer.CrmCompanyLoGo", "\r\n    SELECT VALUE -- Constructing CrmCompanyLoGo\r\n        [Model.Store.CrmCompanyLoGo](T1.CrmCompanyLoGo_CompanyLoGoID, T1.CrmCompanyLoGo_CompanyId, T1.CrmCompanyLoGo_CompanyLogo, T1.CrmCompanyLoGo_LogoDesc, T1.CrmCompanyLoGo_UserId, T1.CrmCompanyLoGo_Year1, T1.CrmCompanyLoGo_Month1, T1.CrmCompanyLoGo_RegisterDate, T1.CrmCompanyLoGo_RegisterDatePersian, T1.CrmCompanyLoGo_GUId, T1.CrmCompanyLoGo_AppType, T1.CrmCompanyLoGo_LanguageID, T1.CrmCompanyLoGo_FirstRegisterUserId, T1.CrmCompanyLoGo_FirstRegisterDatePersian, T1.CrmCompanyLoGo_FirstRegisterDate)\r\n    FROM (\r\n        SELECT \r\n            T.CompanyLoGoID AS CrmCompanyLoGo_CompanyLoGoID, \r\n            T.CompanyId AS CrmCompanyLoGo_CompanyId, \r\n            T.CompanyLogo AS CrmCompanyLoGo_CompanyLogo, \r\n            T.LogoDesc AS CrmCompanyLoGo_LogoDesc, \r\n            T.UserId AS CrmCompanyLoGo_UserId, \r\n            T.Year1 AS CrmCompanyLoGo_Year1, \r\n            T.Month1 AS CrmCompanyLoGo_Month1, \r\n            T.RegisterDate AS CrmCompanyLoGo_RegisterDate, \r\n            T.RegisterDatePersian AS CrmCompanyLoGo_RegisterDatePersian, \r\n            T.GUId AS CrmCompanyLoGo_GUId, \r\n            T.AppType AS CrmCompanyLoGo_AppType, \r\n            T.LanguageID AS CrmCompanyLoGo_LanguageID, \r\n            T.FirstRegisterUserId AS CrmCompanyLoGo_FirstRegisterUserId, \r\n            T.FirstRegisterDatePersian AS CrmCompanyLoGo_FirstRegisterDatePersian, \r\n            T.FirstRegisterDate AS CrmCompanyLoGo_FirstRegisterDate, \r\n            True AS _from0\r\n        FROM CRMEntities.CrmCompanyLoGo AS T\r\n    ) AS T1");
	}

	private KeyValuePair<string, string> GetView7()
	{
		return new KeyValuePair<string, string>("CRMEntities.CrmCompanyLoGo", "\r\n    SELECT VALUE -- Constructing CrmCompanyLoGo\r\n        [MOBModel.CrmCompanyLoGo](T1.CrmCompanyLoGo_CompanyLoGoID, T1.CrmCompanyLoGo_CompanyId, T1.CrmCompanyLoGo_CompanyLogo, T1.CrmCompanyLoGo_LogoDesc, T1.CrmCompanyLoGo_UserId, T1.CrmCompanyLoGo_Year1, T1.CrmCompanyLoGo_Month1, T1.CrmCompanyLoGo_RegisterDate, T1.CrmCompanyLoGo_RegisterDatePersian, T1.CrmCompanyLoGo_GUId, T1.CrmCompanyLoGo_AppType, T1.CrmCompanyLoGo_LanguageID, T1.CrmCompanyLoGo_FirstRegisterUserId, T1.CrmCompanyLoGo_FirstRegisterDatePersian, T1.CrmCompanyLoGo_FirstRegisterDate)\r\n    FROM (\r\n        SELECT \r\n            T.CompanyLoGoID AS CrmCompanyLoGo_CompanyLoGoID, \r\n            T.CompanyId AS CrmCompanyLoGo_CompanyId, \r\n            T.CompanyLogo AS CrmCompanyLoGo_CompanyLogo, \r\n            T.LogoDesc AS CrmCompanyLoGo_LogoDesc, \r\n            T.UserId AS CrmCompanyLoGo_UserId, \r\n            T.Year1 AS CrmCompanyLoGo_Year1, \r\n            T.Month1 AS CrmCompanyLoGo_Month1, \r\n            T.RegisterDate AS CrmCompanyLoGo_RegisterDate, \r\n            T.RegisterDatePersian AS CrmCompanyLoGo_RegisterDatePersian, \r\n            T.GUId AS CrmCompanyLoGo_GUId, \r\n            T.AppType AS CrmCompanyLoGo_AppType, \r\n            T.LanguageID AS CrmCompanyLoGo_LanguageID, \r\n            T.FirstRegisterUserId AS CrmCompanyLoGo_FirstRegisterUserId, \r\n            T.FirstRegisterDatePersian AS CrmCompanyLoGo_FirstRegisterDatePersian, \r\n            T.FirstRegisterDate AS CrmCompanyLoGo_FirstRegisterDate, \r\n            True AS _from0\r\n        FROM ModelStoreContainer.CrmCompanyLoGo AS T\r\n    ) AS T1");
	}
}
