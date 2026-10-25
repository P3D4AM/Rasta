using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Security;
using CRM.General.Calendar;
using CRM.General.Security;
using CRM.General.Utilities;
using CRM.Resources;
using Elmah;
using GSD.Globalization;
using Mobile.Cache.Setting;
using Mobile.Models;
using Newtonsoft.Json;

namespace Mobile.Classes.Helper;

public class Company
{
	public static string GetCompanyName(int cmpId, int userId, int langId, int? cId = null)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		CRMEntities cRMEntities = new CRMEntities();
		string result2 = "";
		try
		{
			mct_MobspSelectCompanyWithID_Result mct_MobspSelectCompanyWithID_Result = Enumerable.FirstOrDefault<mct_MobspSelectCompanyWithID_Result>((IEnumerable<mct_MobspSelectCompanyWithID_Result>)cRMEntities.MobspSelectCompanyWithID(cmpId, userId, langId, result, cId));
			if (mct_MobspSelectCompanyWithID_Result != null)
			{
				result2 = mct_MobspSelectCompanyWithID_Result.CompanyName;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities.Dispose();
		}
		return result2;
	}

	public static string GetCmpPersonName(int? prsId, int langId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		if (!prsId.HasValue || prsId == 0)
		{
			return "";
		}
		CRMEntities cRMEntities = new CRMEntities();
		string result2 = "";
		try
		{
			MobspSelectPersonWithID_Result mobspSelectPersonWithID_Result = Enumerable.FirstOrDefault<MobspSelectPersonWithID_Result>((IEnumerable<MobspSelectPersonWithID_Result>)cRMEntities.MobspSelectPersonWithID(prsId, langId, result));
			if (mobspSelectPersonWithID_Result != null)
			{
				result2 = mobspSelectPersonWithID_Result.PersonName;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities.Dispose();
		}
		return result2;
	}

	public static string GetCmpProjectTitle(int? prjId, int langId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		if (!prjId.HasValue || prjId == 0)
		{
			return "";
		}
		CRMEntities cRMEntities = new CRMEntities();
		string result2 = "";
		try
		{
			MobspSelectProjectWithID_Result mobspSelectProjectWithID_Result = Enumerable.FirstOrDefault<MobspSelectProjectWithID_Result>((IEnumerable<MobspSelectProjectWithID_Result>)cRMEntities.MobspSelectProjectWithID(prjId, langId, result));
			if (mobspSelectProjectWithID_Result != null)
			{
				result2 = mobspSelectProjectWithID_Result.ProjectTitle;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities.Dispose();
		}
		return result2;
	}

	public static string GetMultiReferUserForTicket(int companyId, int departmentId, int currLangID, string langCollation, int? centerId = null)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		CRMEntities cRMEntities = new CRMEntities();
		string text = "";
		try
		{
			foreach (FOMobspSelectUserForTicketReferToMultilUser_Result item in Enumerable.ToList<FOMobspSelectUserForTicketReferToMultilUser_Result>((IEnumerable<FOMobspSelectUserForTicketReferToMultilUser_Result>)cRMEntities.FOMobspSelectUserForTicketReferToMultilUser(departmentId, 7, -1, companyId, currLangID, result, centerId)))
			{
				string text2 = "";
				if (item.CmpAccess.GetValueOrDefault() == -100)
				{
					text2 = string.Format(" ({0})", MyResource.GetResourceString("FOReferUserCmpNotAccess", langCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly));
				}
				text = text + item.FullName + text2 + ",";
			}
			text = ((!string.IsNullOrEmpty(text)) ? text.TrimEnd(new char[1] { ',' }) : "");
			cRMEntities.Dispose();
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			cRMEntities.Dispose();
		}
		return text;
	}

	public static string CreateCmpPassword(string password)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		string result2 = "";
		try
		{
			string text = DateTime.Now.ToString("fffss");
			string text2 = new Random().Next(1000, 9999).ToString();
			result2 = text + password + text2;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result2;
	}

	public static string CheckPrjIsFinishedByPrjPrdHNotDone(int prjId, bool isTicket = false, int? currLangID = null, int? cId = null)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		CRMEntities cRMEntities = new CRMEntities();
		string result2 = "";
		try
		{
			if (prjId != 0 && UserLogin.IsUserAccess("frmDefineProjects", "actCanNotPrjIsFinishedByPrjPrdHNotDone", UserLogin.CurrentUser, cId))
			{
				MobspSelectProjectProductHistoryNotDone_Result mobspSelectProjectProductHistoryNotDone_Result = Enumerable.FirstOrDefault<MobspSelectProjectProductHistoryNotDone_Result>((IEnumerable<MobspSelectProjectProductHistoryNotDone_Result>)cRMEntities.MobspSelectProjectProductHistoryNotDone(prjId, currLangID, result));
				if (mobspSelectProjectProductHistoryNotDone_Result != null)
				{
					string text = mobspSelectProjectProductHistoryNotDone_Result.PrjPrdHProduct ?? "";
					if (!string.IsNullOrWhiteSpace(text))
					{
						text = "'" + text + "'";
					}
					result2 = ((!isTicket) ? string.Format(Messages.msgErrorPrjNotFinishedWithPrjPrdHistoryNotDone, text) : string.Format(Messages.msgErrorTicketNotClosedWithPrjPrdHistoryNotDone, text));
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			cRMEntities.Dispose();
		}
		return result2;
	}

	public static string CheckCnvsRemindOkByPrjPrdHNotDone(int prjId, int? currLangID = null, int? cId = null)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		CRMEntities cRMEntities = new CRMEntities();
		string result2 = "";
		try
		{
			if (prjId != 0 && UserLogin.IsUserAccess("frmDefineConversation", "actCanNotCnvsRemindOkByPrjPrdHNotDone", UserLogin.CurrentUser, cId))
			{
				MobspSelectProjectProductHistoryNotDone_Result mobspSelectProjectProductHistoryNotDone_Result = Enumerable.FirstOrDefault<MobspSelectProjectProductHistoryNotDone_Result>((IEnumerable<MobspSelectProjectProductHistoryNotDone_Result>)cRMEntities.MobspSelectProjectProductHistoryNotDone(prjId, currLangID, result));
				if (mobspSelectProjectProductHistoryNotDone_Result != null)
				{
					string text = mobspSelectProjectProductHistoryNotDone_Result.PrjPrdHProduct ?? "";
					if (!string.IsNullOrWhiteSpace(text))
					{
						text = "'" + text + "'";
					}
					result2 = string.Format(Messages.msgErrorCnvsRemindOkWithPrjPrdHistoryNotDone, text);
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			cRMEntities.Dispose();
		}
		return result2;
	}

	public static string GetMultiReferUserForCnvs(int companyId, int projectId, int defLangID, int currLangID, string langCollation, int? cId = null)
	{
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		string text = "";
		try
		{
			foreach (FOMobspSelectUserForCnvsReferToMultiUser_Result item in Enumerable.ToList<FOMobspSelectUserForCnvsReferToMultiUser_Result>((IEnumerable<FOMobspSelectUserForCnvsReferToMultiUser_Result>)cRMSpEntities.FOMobspSelectUserForCnvsReferToMultiUser(projectId, 7, companyId, currLangID, defLangID, cId)))
			{
				string text2 = "";
				if (item.cmpAccess == -100)
				{
					text2 = string.Format(" ({0})", MyResource.GetResourceString("FOReferUserCmpNotAccess", langCollation, "CRM.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly));
				}
				text = text + item.FullName + text2 + ",";
			}
			text = ((!string.IsNullOrEmpty(text)) ? text.TrimEnd(new char[1] { ',' }) : "");
			cRMSpEntities.Dispose();
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			cRMSpEntities.Dispose();
		}
		return text;
	}

	public static string ActLogin(int cmpId, int prsId = 0, bool openPage = false, int? cId = null, int? foSettingId = null)
	{
		//IL_048a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0494: Expected O, but got Unknown
		//IL_049d: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a4: Expected O, but got Unknown
		CRMEntities cRMEntities = new CRMEntities();
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		string result = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			string text = "/Account/LoginClub";
			int num = int.Parse(DateTime.Now.ToString("yyyyMMdd", new PersianCulture()));
			string value = ApplicationSettings.GetValue("yevNGNeetPc=");
			if (!string.IsNullOrEmpty(value))
			{
				try
				{
					value = CodeDecode.DeCodding(value);
					value = value.Trim().Replace("/", "").Replace("-", "")
						.Replace("\\", "")
						.Replace(" ", "")
						.Replace("_", "");
					int num2 = int.Parse(value);
					if (num > num2)
					{
						if (openPage)
						{
							HttpContext.Current.Response.Redirect(text);
						}
						else
						{
							result = Messages.ResourceManager.GetString("FOMsgErrorExpDate", new CultureInfo(lCID));
						}
					}
				}
				catch (Exception e)
				{
					ErrorSignal.FromCurrentContext().Raise(e);
				}
			}
			CRMspSelectSystemCrmProject_Result cRMspSelectSystemCrmProject_Result = Enumerable.FirstOrDefault<CRMspSelectSystemCrmProject_Result>((IEnumerable<CRMspSelectSystemCrmProject_Result>)cRMEntities.CRMspSelectSystemCrmProject());
			string text2 = "";
			if (cRMspSelectSystemCrmProject_Result != null)
			{
				text2 = cRMspSelectSystemCrmProject_Result.Version ?? "";
			}
			if (VersionConfig.CurrentVerWin == text2)
			{
				int num3 = 1;
				if (prsId != 0)
				{
					num3 = 2;
				}
				FOMobspLoadCompanyLoginInfo_Result fOMobspLoadCompanyLoginInfo_Result = Enumerable.FirstOrDefault<FOMobspLoadCompanyLoginInfo_Result>((IEnumerable<FOMobspLoadCompanyLoginInfo_Result>)cRMSpEntities.FOMobspLoadCompanyLoginInfo(cmpId, lCID, result2, "", "", "", num3, prsId, cId, foSettingId));
				if (fOMobspLoadCompanyLoginInfo_Result != null)
				{
					int num4 = 0;
					if (!fOMobspLoadCompanyLoginInfo_Result.cmpFOIsActive.GetValueOrDefault())
					{
						num4++;
						string @string = Messages.ResourceManager.GetString("msgErrorHaveNotAccessUseFoShp", new CultureInfo(lCID));
						text = text + "?erMsg" + @string;
						if (openPage)
						{
							HttpContext.Current.Response.Redirect(text);
						}
						else
						{
							result = @string;
						}
					}
					long num5 = long.Parse(DateTime.Now.ToString("yyyyMMdd", new PersianCulture()));
					string text3 = fOMobspLoadCompanyLoginInfo_Result.cmpMobile ?? "";
					if (fOMobspLoadCompanyLoginInfo_Result.CompanyPersonID.GetValueOrDefault() != 0)
					{
						text3 = fOMobspLoadCompanyLoginInfo_Result.PersonMobile ?? text3;
					}
					if (fOMobspLoadCompanyLoginInfo_Result.cmpFOLoginExpireDate.HasValue)
					{
						string s = (fOMobspLoadCompanyLoginInfo_Result.cmpFOLoginExpireDate.HasValue ? fOMobspLoadCompanyLoginInfo_Result.cmpFOLoginExpireDate.Value.ToString("yyyyMMdd", new PersianCulture()) : "");
						long result3 = 0L;
						long.TryParse(s, out result3);
						if (num5 > result3 && result3 > 0)
						{
							num4++;
							string string2 = Messages.ResourceManager.GetString("FOMsgErrorUsernameExpired", new CultureInfo(lCID));
							text = text + "?erMsg" + string2;
							if (openPage)
							{
								HttpContext.Current.Response.Redirect(text);
							}
							else
							{
								result = string2;
							}
						}
					}
					if (num3 == 2)
					{
						if (!fOMobspLoadCompanyLoginInfo_Result.prsFOIsActive.GetValueOrDefault())
						{
							num4++;
							string string3 = Messages.ResourceManager.GetString("msgErrorHaveNotAccessUseFoShp", new CultureInfo(lCID));
							text = text + "?erMsg" + string3;
							if (openPage)
							{
								HttpContext.Current.Response.Redirect(text);
							}
							else
							{
								result = string3;
							}
						}
						if (fOMobspLoadCompanyLoginInfo_Result.prsFOLoginExpireDate.HasValue)
						{
							string s2 = (fOMobspLoadCompanyLoginInfo_Result.prsFOLoginExpireDate.HasValue ? fOMobspLoadCompanyLoginInfo_Result.prsFOLoginExpireDate.Value.ToString("yyyyMMdd", new PersianCulture()) : "");
							long result4 = 0L;
							long.TryParse(s2, out result4);
							if (num5 > result4 && result4 > 0)
							{
								num4++;
								string string4 = Messages.ResourceManager.GetString("FOMsgErrorUsernameExpired", new CultureInfo(lCID));
								text = text + "?erMsg" + string4;
								if (openPage)
								{
									HttpContext.Current.Response.Redirect(text);
								}
								else
								{
									result = string4;
								}
							}
						}
					}
					if (num4 == 0)
					{
						DateTime now = DateTime.Now;
						int cacheDefaultTimeInMinutes = Configuration.CacheDefaultTimeInMinutes;
						string text4 = FormsAuthentication.Encrypt(new FormsAuthenticationTicket(fOMobspLoadCompanyLoginInfo_Result.CompanyID + "-" + prsId + "-" + num3, false, cacheDefaultTimeInMinutes));
						HttpCookie val = new HttpCookie(FormsAuthentication.FormsCookieName, text4);
						val.Expires = now.AddMinutes(cacheDefaultTimeInMinutes);
						val.HttpOnly = true;
						HttpContext.Current.Response.Cookies.Add(val);
						string text5 = "fa-IR";
						text5 = new CultureInfo(lCID).EnglishName;
						if (HttpContext.Current.Request.Cookies["CurrentLanguage"] == null)
						{
							text5 = ApplicationSettings.GetValue("BeginCultureName");
							HttpCookie val2 = HttpContext.Current.Request.Cookies["CurrentLanguage"];
							val2.Value = text5;
							val2.Expires = DateTime.MaxValue;
							HttpContext.Current.Response.Cookies.Add(val2);
						}
						else
						{
							text5 = HttpContext.Current.Request.Cookies["CurrentLanguage"].Value;
						}
					}
				}
				else if (openPage)
				{
					HttpContext.Current.Response.Redirect(text);
				}
				else
				{
					result = Messages.ResourceManager.GetString("FOMsgErrorDoneOperation", new CultureInfo(lCID));
				}
			}
			else if (openPage)
			{
				HttpContext.Current.Response.Redirect(text);
			}
			else
			{
				result = Messages.ResourceManager.GetString("FOMsgErrorDoneOperation", new CultureInfo(lCID));
			}
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		finally
		{
			cRMEntities?.Dispose();
			cRMSpEntities?.Dispose();
		}
		return result;
	}

	public static string GetFoInfoJsonByName(string foInfo, string cIds)
	{
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		string result = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int result3 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result3);
			}
			string[] array = new string[1];
			if (!string.IsNullOrWhiteSpace(cIds))
			{
				array = cIds.Split(new char[1] { ',' });
			}
			if (array == null || array.Length == 0)
			{
				array = new string[1] { result3.ToString() };
			}
			List<CommonFoInfoByNameViewModel> list = new List<CommonFoInfoByNameViewModel>();
			if (!string.IsNullOrWhiteSpace(foInfo))
			{
				list = new JavaScriptSerializer().Deserialize<List<CommonFoInfoByNameViewModel>>(foInfo);
			}
			if (list != null && array != null)
			{
				if (Enumerable.Any<CommonFoInfoByNameViewModel>((IEnumerable<CommonFoInfoByNameViewModel>)list))
				{
					for (int i = 0; i < array.Length; i++)
					{
						int cI = 0;
						int.TryParse(array[i], out cI);
						if (cI == 0)
						{
							continue;
						}
						bool flag = false;
						CommonFoInfoByNameViewModel commonFoInfoByNameViewModel = Enumerable.FirstOrDefault<CommonFoInfoByNameViewModel>((IEnumerable<CommonFoInfoByNameViewModel>)list, (Func<CommonFoInfoByNameViewModel, bool>)((CommonFoInfoByNameViewModel m) => m.CId == cI.ToString()));
						if (commonFoInfoByNameViewModel != null)
						{
							int result4 = 0;
							int.TryParse(commonFoInfoByNameViewModel.CId, out result4);
							if (result4 != 0)
							{
								flag = true;
							}
						}
						if (!flag)
						{
							list.Add(new CommonFoInfoByNameViewModel
							{
								CId = cI.ToString(),
								FOAct = "0",
								FOActDt = "",
								FOActUId = "0",
								FOExpDt = "",
								FOExpUId = "0",
								ShpAct = "0",
								ShpActDt = "",
								ShpActUId = "0",
								ShpExpDt = "",
								ShpExpUId = "0",
								ReferUId = "0",
								SuppUId = "0"
							});
						}
					}
				}
				else
				{
					for (int j = 0; j < array.Length; j++)
					{
						int result5 = 0;
						int.TryParse(array[j], out result5);
						if (result5 != 0)
						{
							list.Add(new CommonFoInfoByNameViewModel
							{
								CId = result5.ToString(),
								FOAct = "0",
								FOActDt = "",
								FOActUId = "0",
								FOExpDt = "",
								FOExpUId = "0",
								ShpAct = "0",
								ShpActDt = "",
								ShpActUId = "0",
								ShpExpDt = "",
								ShpExpUId = "0",
								ReferUId = "0",
								SuppUId = "0"
							});
						}
					}
				}
			}
			if (list != null && Enumerable.Any<CommonFoInfoByNameViewModel>((IEnumerable<CommonFoInfoByNameViewModel>)list))
			{
				foreach (CommonFoInfoByNameViewModel item in list)
				{
					int result6 = 0;
					int.TryParse(item.CId, out result6);
					item.CenterName = Center.GetNames(result6.ToString());
					if (!string.IsNullOrWhiteSpace(item.FOActDt))
					{
						item.FOActDtStr = DateTime.Parse(item.FOActDt, new CultureInfo("en-US")).ToString("yyyy/MM/dd", new CultureInfo(lCID));
					}
					int result7 = 0;
					int.TryParse(item.FOActUId, out result7);
					if (result7 != 0)
					{
						item.FOActUName = User.GetUserName(result7, lCID, result2);
					}
					if (!string.IsNullOrWhiteSpace(item.FOExpDt))
					{
						item.FOExpDtStr = DateTime.Parse(item.FOExpDt, new CultureInfo("en-US")).ToString("yyyy/MM/dd", new CultureInfo(lCID));
					}
					int result8 = 0;
					int.TryParse(item.FOExpUId, out result8);
					if (result8 != 0)
					{
						item.FOExpUName = User.GetUserName(result8, lCID, result2);
					}
					if (!string.IsNullOrWhiteSpace(item.ShpActDt))
					{
						item.ShpActDtStr = DateTime.Parse(item.ShpActDt, new CultureInfo("en-US")).ToString("yyyy/MM/dd", new CultureInfo(lCID));
					}
					int result9 = 0;
					int.TryParse(item.ShpActUId, out result9);
					if (result9 != 0)
					{
						item.ShpActUName = User.GetUserName(result9, lCID, result2);
					}
					if (!string.IsNullOrWhiteSpace(item.ShpExpDt))
					{
						item.ShpExpDtStr = DateTime.Parse(item.ShpExpDt, new CultureInfo("en-US")).ToString("yyyy/MM/dd", new CultureInfo(lCID));
					}
					int result10 = 0;
					int.TryParse(item.ShpExpUId, out result10);
					if (result10 != 0)
					{
						item.ShpExpUName = User.GetUserName(result10, lCID, result2);
					}
					int result11 = 0;
					int.TryParse(item.ReferUId, out result11);
					if (result11 != 0)
					{
						item.ReferUName = User.GetUserName(result11, lCID, result2);
					}
					int result12 = 0;
					int.TryParse(item.SuppUId, out result12);
					if (result12 != 0)
					{
						item.SuppUName = User.GetUserName(result12, lCID, result2);
					}
				}
				result = JsonConvert.SerializeObject(Enumerable.ToList<CommonFoInfoByNameViewModel>((IEnumerable<CommonFoInfoByNameViewModel>)list));
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public static string GetFoInfoJson(string foInfo, string oldFoInfo, string cIds, ref bool haveEroroFoCnt, int userId = 0, int userLastCId = 0, bool isCmp = false, int referUId = 0, int suppUId = 0, int? defaultReferUId = null)
	{
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_014e: Unknown result type (might be due to invalid IL or missing references)
		string result = "";
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			string text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", new CultureInfo("en-US"));
			bool flag = false;
			if (UserLogin.CurrentUser != null)
			{
				if (userLastCId == 0)
				{
					int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out userLastCId);
				}
				if (userId == 0)
				{
					userId = UserLogin.CurrentUser.UserId;
				}
			}
			List<CommonFoInfoViewModel> list = new List<CommonFoInfoViewModel>();
			List<CommonFoInfoViewModel> list2 = new List<CommonFoInfoViewModel>();
			if (!string.IsNullOrWhiteSpace(oldFoInfo))
			{
				list2 = new JavaScriptSerializer().Deserialize<List<CommonFoInfoViewModel>>(oldFoInfo);
				if (list2 != null && Enumerable.Any<CommonFoInfoViewModel>((IEnumerable<CommonFoInfoViewModel>)list2) && Enumerable.FirstOrDefault<CommonFoInfoViewModel>((IEnumerable<CommonFoInfoViewModel>)list2, (Func<CommonFoInfoViewModel, bool>)((CommonFoInfoViewModel m) => (m.FOAct ?? "0") == "1")) != null)
				{
					flag = true;
				}
			}
			string[] array = new string[1];
			if (!string.IsNullOrWhiteSpace(cIds))
			{
				array = cIds.Split(new char[1] { ',' });
			}
			if (array == null || array.Length == 0)
			{
				array = new string[1] { userLastCId.ToString() };
			}
			List<CommonFoInfoByNameViewModel> list3 = new List<CommonFoInfoByNameViewModel>();
			if (!string.IsNullOrWhiteSpace(foInfo))
			{
				list3 = new JavaScriptSerializer().Deserialize<List<CommonFoInfoByNameViewModel>>(foInfo);
			}
			if (list3 != null && array != null)
			{
				if (Enumerable.Any<CommonFoInfoByNameViewModel>((IEnumerable<CommonFoInfoByNameViewModel>)list3))
				{
					for (int i = 0; i < array.Length; i++)
					{
						int cI = 0;
						int.TryParse(array[i], out cI);
						if (cI == 0)
						{
							continue;
						}
						bool flag2 = false;
						CommonFoInfoByNameViewModel commonFoInfoByNameViewModel = Enumerable.FirstOrDefault<CommonFoInfoByNameViewModel>((IEnumerable<CommonFoInfoByNameViewModel>)list3, (Func<CommonFoInfoByNameViewModel, bool>)((CommonFoInfoByNameViewModel m) => m.CId == cI.ToString()));
						if (commonFoInfoByNameViewModel != null)
						{
							int result3 = 0;
							int.TryParse(commonFoInfoByNameViewModel.CId, out result3);
							if (result3 != 0)
							{
								flag2 = true;
							}
						}
						if (!flag2)
						{
							list3.Add(new CommonFoInfoByNameViewModel
							{
								CId = cI.ToString(),
								FOAct = "0",
								FOActDt = "",
								FOActUId = "0",
								FOExpDt = "",
								FOExpUId = "0",
								ShpAct = "0",
								ShpActDt = "",
								ShpActUId = "0",
								ShpExpDt = "",
								ShpExpUId = "0",
								ReferUId = ((defaultReferUId.GetValueOrDefault() != 0) ? defaultReferUId.ToString() : "0"),
								SuppUId = "0"
							});
						}
					}
				}
				else
				{
					for (int j = 0; j < array.Length; j++)
					{
						int result4 = 0;
						int.TryParse(array[j], out result4);
						if (result4 != 0)
						{
							list3.Add(new CommonFoInfoByNameViewModel
							{
								CId = result4.ToString(),
								FOAct = "0",
								FOActDt = "",
								FOActUId = "0",
								FOExpDt = "",
								FOExpUId = "0",
								ShpAct = "0",
								ShpActDt = "",
								ShpActUId = "0",
								ShpExpDt = "",
								ShpExpUId = "0",
								ReferUId = ((defaultReferUId.GetValueOrDefault() != 0) ? defaultReferUId.ToString() : "0"),
								SuppUId = "0"
							});
						}
					}
				}
			}
			if (list3 != null && Enumerable.Any<CommonFoInfoByNameViewModel>((IEnumerable<CommonFoInfoByNameViewModel>)list3))
			{
				foreach (CommonFoInfoByNameViewModel item in list3)
				{
					int cId = 0;
					int.TryParse(item.CId, out cId);
					if (cId == 0)
					{
						continue;
					}
					bool flag3 = false;
					int result5 = 0;
					int.TryParse(item.FOAct, out result5);
					if (result5 == 1)
					{
						flag3 = true;
					}
					bool flag4 = false;
					int result6 = 0;
					int.TryParse(item.ShpAct, out result6);
					if (result6 == 1)
					{
						flag4 = true;
					}
					DateTime dateTime = default(DateTime);
					string text2 = "";
					try
					{
						if (!string.IsNullOrWhiteSpace(item.FOActDtStr))
						{
							text2 = PersianDate.GetFormatetdDate(item.FOActDtStr.Replace("/", ""));
							item.FOActDt = (lCID switch
							{
								1065 => DateTime.Parse(text2 + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture()), 
								1025 => DateTime.Parse(text2 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA")), 
								_ => DateTime.Parse(text2 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US")), 
							}).ToString("yyyy-MM-dd HH:mm:ss", new CultureInfo("en-US"));
						}
						else
						{
							item.FOActDt = "";
						}
					}
					catch (Exception e)
					{
						ErrorSignal.FromCurrentContext().Raise(e);
					}
					dateTime = default(DateTime);
					text2 = "";
					try
					{
						if (!string.IsNullOrWhiteSpace(item.ShpActDtStr))
						{
							text2 = PersianDate.GetFormatetdDate(item.ShpActDtStr.Replace("/", ""));
							item.ShpActDt = (lCID switch
							{
								1065 => DateTime.Parse(text2 + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture()), 
								1025 => DateTime.Parse(text2 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA")), 
								_ => DateTime.Parse(text2 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US")), 
							}).ToString("yyyy-MM-dd HH:mm:ss", new CultureInfo("en-US"));
						}
						else
						{
							item.ShpActDt = "";
						}
					}
					catch (Exception e2)
					{
						ErrorSignal.FromCurrentContext().Raise(e2);
					}
					dateTime = default(DateTime);
					text2 = "";
					try
					{
						if (!string.IsNullOrWhiteSpace(item.FOExpDtStr))
						{
							text2 = PersianDate.GetFormatetdDate(item.FOExpDtStr.Replace("/", ""));
							item.FOExpDt = (lCID switch
							{
								1065 => DateTime.Parse(text2 + " 00:00:00", new PersianCulture()), 
								1025 => DateTime.Parse(text2 + " 00:00:00", new CultureInfo("ar-SA")), 
								_ => DateTime.Parse(text2 + " 00:00:00", new CultureInfo("en-US")), 
							}).ToString("yyyy-MM-dd HH:mm:ss", new CultureInfo("en-US"));
						}
						else
						{
							item.FOExpDt = "";
						}
					}
					catch (Exception e3)
					{
						ErrorSignal.FromCurrentContext().Raise(e3);
					}
					dateTime = default(DateTime);
					text2 = "";
					try
					{
						if (!string.IsNullOrWhiteSpace(item.ShpExpDtStr))
						{
							text2 = PersianDate.GetFormatetdDate(item.ShpExpDtStr.Replace("/", ""));
							item.ShpExpDt = (lCID switch
							{
								1065 => DateTime.Parse(text2 + " 00:00:00", new PersianCulture()), 
								1025 => DateTime.Parse(text2 + " 00:00:00", new CultureInfo("ar-SA")), 
								_ => DateTime.Parse(text2 + " 00:00:00", new CultureInfo("en-US")), 
							}).ToString("yyyy-MM-dd HH:mm:ss", new CultureInfo("en-US"));
						}
						else
						{
							item.ShpExpDt = "";
						}
					}
					catch (Exception e4)
					{
						ErrorSignal.FromCurrentContext().Raise(e4);
					}
					item.ReferUId = (string.IsNullOrWhiteSpace(item.ReferUId) ? "0" : item.ReferUId);
					item.SuppUId = (string.IsNullOrWhiteSpace(item.SuppUId) ? "0" : item.SuppUId);
					if (cId.ToString() == userLastCId.ToString() && referUId != 0)
					{
						item.ReferUId = referUId.ToString();
						if (suppUId != 0)
						{
							item.SuppUId = suppUId.ToString();
						}
						else
						{
							item.SuppUId = "0";
						}
					}
					CommonFoInfoViewModel commonFoInfoViewModel = new CommonFoInfoViewModel();
					if (list2 != null && Enumerable.Any<CommonFoInfoViewModel>((IEnumerable<CommonFoInfoViewModel>)list2))
					{
						commonFoInfoViewModel = Enumerable.FirstOrDefault<CommonFoInfoViewModel>((IEnumerable<CommonFoInfoViewModel>)list2, (Func<CommonFoInfoViewModel, bool>)((CommonFoInfoViewModel m) => m.CId == cId.ToString()));
					}
					if (commonFoInfoViewModel == null)
					{
						commonFoInfoViewModel = new CommonFoInfoViewModel
						{
							CId = cId.ToString(),
							ReferUId = referUId.ToString(),
							SuppUId = suppUId.ToString()
						};
					}
					if (commonFoInfoViewModel != null)
					{
						bool flag5 = false;
						int result7 = 0;
						int.TryParse(commonFoInfoViewModel.FOAct, out result7);
						if (result7 == 1)
						{
							flag5 = true;
						}
						if (!flag3)
						{
							item.FOAct = "0";
							item.FOActDt = "";
							item.FOActUId = "0";
						}
						else if (!flag5 && flag3 && !flag)
						{
							int maxFOCount = Configuration.MaxFOCount;
							if (Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMSpEntities.MobspReturnCmpFOIsActiveCnt()).GetValueOrDefault() + 1 > maxFOCount && isCmp)
							{
								haveEroroFoCnt = true;
							}
							else
							{
								item.FOAct = (flag3 ? "1" : "0");
							}
						}
						else if (flag5 == flag3)
						{
							item.FOAct = (flag3 ? "1" : "0");
							item.FOActUId = commonFoInfoViewModel.FOActUId;
						}
						else
						{
							item.FOAct = (flag3 ? "1" : "0");
						}
						if (flag3 && string.IsNullOrWhiteSpace(item.FOActDt))
						{
							item.FOActDt = text;
						}
						if (flag3 && (string.IsNullOrWhiteSpace(item.FOActUId) || item.FOActUId == "0"))
						{
							item.FOActUId = userId.ToString();
						}
						bool flag6 = false;
						int result8 = 0;
						int.TryParse(commonFoInfoViewModel.ShpAct, out result8);
						if (result8 == 1)
						{
							flag6 = true;
						}
						if (!flag4)
						{
							item.ShpAct = "0";
							item.ShpActDt = "";
							item.ShpActUId = "0";
						}
						else
						{
							item.ShpAct = (flag4 ? "1" : "0");
							if (flag6 == flag4)
							{
								item.ShpActUId = commonFoInfoViewModel.ShpActUId;
							}
						}
						if (flag4 && string.IsNullOrWhiteSpace(item.ShpActDt))
						{
							item.ShpActDt = text;
						}
						if (flag4 && (string.IsNullOrWhiteSpace(item.ShpActUId) || item.ShpActUId == "0"))
						{
							item.ShpActUId = userId.ToString();
						}
						long result9 = 0L;
						long result10 = 0L;
						if (!string.IsNullOrWhiteSpace(commonFoInfoViewModel.FOExpDt))
						{
							long.TryParse(DateTime.Parse(commonFoInfoViewModel.FOExpDt).ToString("yyyyMMdd", new CultureInfo("en-US")), out result9);
						}
						if (!string.IsNullOrWhiteSpace(item.FOExpDt))
						{
							long.TryParse(DateTime.Parse(item.FOExpDt).ToString("yyyyMMdd", new CultureInfo("en-US")), out result10);
						}
						if (result9 != result10)
						{
							item.FOExpUId = userId.ToString();
						}
						else
						{
							item.FOExpUId = commonFoInfoViewModel.FOExpUId;
						}
						if (result10 == 0L)
						{
							item.FOExpUId = "0";
						}
						long result11 = 0L;
						long result12 = 0L;
						if (!string.IsNullOrWhiteSpace(commonFoInfoViewModel.ShpExpDt))
						{
							long.TryParse(DateTime.Parse(commonFoInfoViewModel.ShpExpDt).ToString("yyyyMMdd", new CultureInfo("en-US")), out result11);
						}
						if (!string.IsNullOrWhiteSpace(item.ShpExpDt))
						{
							long.TryParse(DateTime.Parse(item.ShpExpDt).ToString("yyyyMMdd", new CultureInfo("en-US")), out result12);
						}
						if (result11 != result12)
						{
							item.ShpExpUId = userId.ToString();
						}
						else
						{
							item.ShpExpUId = commonFoInfoViewModel.ShpExpUId;
						}
						if (result12 == 0L)
						{
							item.ShpExpUId = "0";
						}
					}
					CommonFoInfoViewModel commonFoInfoViewModel2 = new CommonFoInfoViewModel
					{
						CId = cId.ToString(),
						FOAct = (item.FOAct ?? "0"),
						FOActDt = (item.FOActDt ?? ""),
						FOActUId = (item.FOActUId ?? "0"),
						ShpAct = (item.ShpAct ?? "0"),
						ShpActDt = (item.ShpActDt ?? ""),
						ShpActUId = (item.ShpActUId ?? "0"),
						FOExpDt = (item.FOExpDt ?? ""),
						FOExpUId = (item.FOExpUId ?? "0"),
						ShpExpDt = (item.ShpExpDt ?? ""),
						ShpExpUId = (item.ShpExpUId ?? "0"),
						ReferUId = (item.ReferUId ?? "0"),
						SuppUId = (item.SuppUId ?? "0")
					};
					if ((string.IsNullOrWhiteSpace(commonFoInfoViewModel2.ReferUId) || commonFoInfoViewModel2.ReferUId == "0") && defaultReferUId.GetValueOrDefault() != 0)
					{
						commonFoInfoViewModel2.ReferUId = defaultReferUId.ToString();
					}
					list.Add(commonFoInfoViewModel2);
				}
			}
			if (list != null && Enumerable.Any<CommonFoInfoViewModel>((IEnumerable<CommonFoInfoViewModel>)list))
			{
				result = JsonConvert.SerializeObject(Enumerable.ToList<CommonFoInfoViewModel>((IEnumerable<CommonFoInfoViewModel>)list));
			}
		}
		catch (Exception e5)
		{
			ErrorSignal.FromCurrentContext().Raise(e5);
		}
		finally
		{
			cRMSpEntities?.Dispose();
		}
		return result;
	}

	public static string UpdateCompanyPersonCIds(int cmpId, int prsId, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		try
		{
			cRMSpEntities = new CRMSpEntities();
			cRMSpEntities.MobspUpdateCompanyPersonCIds(UserLogin.CurrentUser.UserLastCId, cmpId, prsId);
			return "";
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			return "Error: " + ex.Message;
		}
		finally
		{
			cRMSpEntities?.Dispose();
		}
	}

	public static bool SetCmpFOIsActive(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var _);
		CRMSpEntities cRMSpEntities = null;
		bool result3 = false;
		try
		{
			cRMSpEntities = new CRMSpEntities();
			int maxFOCount = Configuration.MaxFOCount;
			if (Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMSpEntities.FOMobspReturnCmpFOIsActiveCnt()).GetValueOrDefault() + 1 <= maxFOCount)
			{
				result3 = true;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			result3 = false;
		}
		finally
		{
			cRMSpEntities?.Dispose();
		}
		return result3;
	}

	public static void UpdateCompanyFOInfoAndCIds(int cId = 0, int cmpId = 0, string foAct = "", string shpAct = "", int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var _);
		CRMSpEntities cRMSpEntities = null;
		try
		{
			cRMSpEntities = new CRMSpEntities();
			int? num = FoCenter.GetCurrentCId();
			if (cId == 0)
			{
				num = cId;
			}
			cRMSpEntities.SHPMobspUpdateCompanyFOInfoAndCIds(num.GetValueOrDefault(), cmpId, foAct, shpAct);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpEntities?.Dispose();
		}
	}

	public static void UpdateCompanyPersonFOInfoAndCIds(int cId = 0, int prsId = 0, string foAct = "", string shpAct = "", int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var _);
		CRMSpEntities cRMSpEntities = null;
		try
		{
			cRMSpEntities = new CRMSpEntities();
			int? cId2 = FoCenter.GetCurrentCId();
			if (cId == 0)
			{
				cId2 = cId;
			}
			cRMSpEntities.SHPMobspUpdateCompanyPersonFOInfoAndCIds(cId2, prsId, foAct, shpAct);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpEntities?.Dispose();
		}
	}
}
