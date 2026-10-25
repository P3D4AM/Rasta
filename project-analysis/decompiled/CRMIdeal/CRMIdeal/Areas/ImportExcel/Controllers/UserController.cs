using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Data.Objects;
using System.DirectoryServices.AccountManagement;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;
using CRM.General.Calendar;
using CRM.General.Security;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Cache.User;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.Classes.Helper;
using CRMIdeal.GSD.Globalization;
using Elmah;
using Kendo.Mvc.UI;
using Newtonsoft.Json;

namespace CRMIdeal.Areas.ImportExcel.Controllers;

public class UserController : Controller
{
	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	private readonly CRMSpIIEntities _dbII = new CRMSpIIEntities();

	private const int UserSystemPartId = 140;

	public static readonly string[] ActiveDirectoryImportFields = new string[5] { "FName", "LName", "Nickname", "UserName", "ActiveDirectoryUser" };

	[HttpPost]
	[LoginAuthorize]
	public async Task<string> FetchUsersFromActiveDirectory(bool loadGroups = false)
	{
		string res = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspSelectImportExcelFields_Result> list = Enumerable.ToList<CRMspSelectImportExcelFields_Result>((IEnumerable<CRMspSelectImportExcelFields_Result>)_dbI.CRMspSelectImportExcelFields(140, lCID, result));
			if (list.Count > 0)
			{
				_dbI.CRMspUpdateImportExcelSelectedFields(140, null, false, null, true);
				string[] activeDirectoryImportFields = ActiveDirectoryImportFields;
				foreach (string item in activeDirectoryImportFields)
				{
					_dbI.CRMspUpdateImportExcelSelectedFields(140, Enumerable.FirstOrDefault<CRMspSelectImportExcelFields_Result>((IEnumerable<CRMspSelectImportExcelFields_Result>)list, (Func<CRMspSelectImportExcelFields_Result, bool>)((CRMspSelectImportExcelFields_Result x) => x.FieldName == item)).Id, true, null, null);
				}
				await Task.Factory.StartNew(delegate
				{
					//IL_0013: Unknown result type (might be due to invalid IL or missing references)
					//IL_0019: Expected O, but got Unknown
					//IL_0086: Unknown result type (might be due to invalid IL or missing references)
					//IL_0090: Expected O, but got Unknown
					//IL_008b: Unknown result type (might be due to invalid IL or missing references)
					//IL_0022: Unknown result type (might be due to invalid IL or missing references)
					//IL_002c: Expected O, but got Unknown
					//IL_0027: Unknown result type (might be due to invalid IL or missing references)
					//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
					//IL_00af: Expected O, but got Unknown
					List<SelectListItem> list2 = new List<SelectListItem>();
					List<SelectListItem> list3 = new List<SelectListItem>();
					List<UserPrincipalViewModel> list4 = new List<UserPrincipalViewModel>();
					PrincipalContext val = new PrincipalContext((ContextType)1);
					if (loadGroups)
					{
						PrincipalSearchResult<Principal> val2 = new PrincipalSearcher((Principal)new GroupPrincipal(val)).FindAll();
						if (val2 != null)
						{
							list3.AddRange(Enumerable.Select<Principal, SelectListItem>((IEnumerable<Principal>)val2, (Func<Principal, SelectListItem>)((Principal x) => new SelectListItem
							{
								Text = (x.DisplayName ?? x.SamAccountName),
								Value = x.SamAccountName
							})));
						}
						list2.Add(new SelectListItem
						{
							Text = "Groups",
							Value = JsonConvert.SerializeObject(list3)
						});
					}
					foreach (UserPrincipal item2 in new PrincipalSearcher((Principal)new UserPrincipal(val)).FindAll())
					{
						UserPrincipal val3 = item2;
						UserPrincipalViewModel userPrincipalViewModel = new UserPrincipalViewModel
						{
							Groups = new List<SelectListItem>(),
							FName = ((Principal)val3).Name,
							LName = (val3.Surname ?? ((Principal)val3).SamAccountName),
							Nickname = ((Principal)val3).DisplayName,
							UserName = ((Principal)val3).SamAccountName,
							ActiveDirectoryUser = ((Principal)val3).SamAccountName
						};
						if (loadGroups)
						{
							userPrincipalViewModel.Groups.AddRange(Enumerable.Select<Principal, SelectListItem>((IEnumerable<Principal>)((Principal)val3).GetGroups(), (Func<Principal, SelectListItem>)((Principal x) => new SelectListItem
							{
								Text = (x.DisplayName ?? x.SamAccountName),
								Value = x.SamAccountName
							})));
						}
						list4.Add(userPrincipalViewModel);
					}
					list2.Add(new SelectListItem
					{
						Text = "Users",
						Value = JsonConvert.SerializeObject(list4)
					});
					res = JsonConvert.SerializeObject(list2);
				});
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return res;
	}

	[HttpPost]
	[LoginAuthorize]
	public string FetchUsersFromActiveDirectory_Old()
	{
		//IL_0133: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Unknown result type (might be due to invalid IL or missing references)
		//IL_013e: Expected O, but got Unknown
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		//IL_0143: Expected O, but got Unknown
		//IL_013e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0180: Expected O, but got Unknown
		//IL_017b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0185: Expected O, but got Unknown
		//IL_0180: Unknown result type (might be due to invalid IL or missing references)
		//IL_019d: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a4: Expected O, but got Unknown
		string result = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspSelectImportExcelFields_Result> list = Enumerable.ToList<CRMspSelectImportExcelFields_Result>((IEnumerable<CRMspSelectImportExcelFields_Result>)_dbI.CRMspSelectImportExcelFields(140, lCID, result2));
			if (list.Count > 0)
			{
				_dbI.CRMspUpdateImportExcelSelectedFields(140, null, false, null, true);
				string[] activeDirectoryImportFields = ActiveDirectoryImportFields;
				foreach (string item in activeDirectoryImportFields)
				{
					_dbI.CRMspUpdateImportExcelSelectedFields(140, Enumerable.FirstOrDefault<CRMspSelectImportExcelFields_Result>((IEnumerable<CRMspSelectImportExcelFields_Result>)list, (Func<CRMspSelectImportExcelFields_Result, bool>)((CRMspSelectImportExcelFields_Result x) => x.FieldName == item)).Id, true, null, null);
				}
				List<SelectListItem> list2 = new List<SelectListItem>();
				List<UserPrincipalViewModel> list3 = new List<UserPrincipalViewModel>();
				PrincipalContext val = new PrincipalContext((ContextType)1);
				PrincipalSearchResult<Principal> val2 = new PrincipalSearcher((Principal)new GroupPrincipal(val)).FindAll();
				if (val2 != null)
				{
					list2.AddRange(Enumerable.Select<Principal, SelectListItem>((IEnumerable<Principal>)val2, (Func<Principal, SelectListItem>)((Principal x) => new SelectListItem
					{
						Text = x.DisplayName,
						Value = x.SamAccountName
					})));
				}
				foreach (UserPrincipal item2 in new PrincipalSearcher((Principal)new UserPrincipal(val)).FindAll())
				{
					UserPrincipal val3 = item2;
					UserPrincipalViewModel userPrincipalViewModel = new UserPrincipalViewModel();
					userPrincipalViewModel.Groups = new List<SelectListItem>();
					userPrincipalViewModel.FName = ((Principal)val3).Name;
					userPrincipalViewModel.LName = val3.Surname;
					userPrincipalViewModel.Nickname = ((Principal)val3).DisplayName;
					userPrincipalViewModel.UserName = ((Principal)val3).SamAccountName;
					userPrincipalViewModel.ActiveDirectoryUser = ((Principal)val3).SamAccountName;
					userPrincipalViewModel.Groups.AddRange(Enumerable.Select<Principal, SelectListItem>((IEnumerable<Principal>)((Principal)val3).GetGroups(), (Func<Principal, SelectListItem>)((Principal x) => new SelectListItem
					{
						Text = (x.DisplayName ?? x.Name),
						Value = x.Name
					})));
					list3.Add(userPrincipalViewModel);
				}
				result = JsonConvert.SerializeObject(new List<SelectListItem>
				{
					new SelectListItem
					{
						Text = "Groups",
						Value = JsonConvert.SerializeObject(list2)
					},
					new SelectListItem
					{
						Text = "Users",
						Value = JsonConvert.SerializeObject(list3)
					}
				});
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return result;
	}

	[HttpPost]
	[LoginAuthorize]
	public string ImportExcelToCrm(int totalRecsCnt = 0, int currRecsCnt = 0, string recs = "", string requiredFieldsJs = "")
	{
		bool flag = false;
		ImpExcelData impExcelData = new ImpExcelData();
		impExcelData.StartReq = DateTime.Now;
		impExcelData.StartReqStr = impExcelData.StartReq.ToString("yyyy/MM/dd HH:mm:ss");
		List<ImportExcelSpResultViewModel> list = new List<ImportExcelSpResultViewModel>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangID);
			if (defLangID <= 0)
			{
				defLangID = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			int userId = UserLogin.CurrentUser.UserId;
			short value2 = short.Parse(Financial.Get().Id.ToString());
			short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			int? userCIds = null;
			if (UserLogin.CurrentUser != null)
			{
				userCIds = UserLogin.CurrentUser.UserLastCId;
			}
			recs = ((recs == "[]" || recs == "{}") ? "" : recs);
			requiredFieldsJs = ((requiredFieldsJs == "[]" || requiredFieldsJs == "{}") ? "" : requiredFieldsJs);
			if (currRecsCnt == 1)
			{
				flag = true;
			}
			if (string.IsNullOrWhiteSpace(recs))
			{
				impExcelData.Messages += Messages.ErrorNotFindRecord;
			}
			else
			{
				new List<ImportExcelUserViewModel>();
				List<ImportExcelUserViewModel>? list2 = JsonConvert.DeserializeObject<List<ImportExcelUserViewModel>>(recs);
				List<SelectListItem> list3 = JsonConvert.DeserializeObject<List<SelectListItem>>(requiredFieldsJs);
				foreach (ImportExcelUserViewModel item in list2)
				{
					int? RowNum = item.RowNum;
					try
					{
						if (item.DepartmentId.GetValueOrDefault() <= 0 && Enumerable.FirstOrDefault<SelectListItem>((IEnumerable<SelectListItem>)list3, (Func<SelectListItem, bool>)((SelectListItem x) => x.Text == "DepartmentId")).Value != null)
						{
							item.DepartmentId = int.Parse(Enumerable.FirstOrDefault<SelectListItem>((IEnumerable<SelectListItem>)list3, (Func<SelectListItem, bool>)((SelectListItem x) => x.Text == "DepartmentId")).Value);
						}
						if (item.UserGroupId.GetValueOrDefault() == 0 && Enumerable.FirstOrDefault<SelectListItem>((IEnumerable<SelectListItem>)list3, (Func<SelectListItem, bool>)((SelectListItem x) => x.Text == "UserGroupId")).Value != null)
						{
							item.UserGroupId = int.Parse(Enumerable.FirstOrDefault<SelectListItem>((IEnumerable<SelectListItem>)list3, (Func<SelectListItem, bool>)((SelectListItem x) => x.Text == "UserGroupId")).Value);
						}
						if (item.PositionId.GetValueOrDefault() == 0 && Enumerable.FirstOrDefault<SelectListItem>((IEnumerable<SelectListItem>)list3, (Func<SelectListItem, bool>)((SelectListItem x) => x.Text == "PositionId")).Value != null)
						{
							item.PositionId = int.Parse(Enumerable.FirstOrDefault<SelectListItem>((IEnumerable<SelectListItem>)list3, (Func<SelectListItem, bool>)((SelectListItem x) => x.Text == "PositionId")).Value);
						}
						if (item.ResponsibleUserId.GetValueOrDefault() == 0 && Enumerable.FirstOrDefault<SelectListItem>((IEnumerable<SelectListItem>)list3, (Func<SelectListItem, bool>)((SelectListItem x) => x.Text == "ResponsibleUserId")).Value != null)
						{
							item.ResponsibleUserId = int.Parse(Enumerable.FirstOrDefault<SelectListItem>((IEnumerable<SelectListItem>)list3, (Func<SelectListItem, bool>)((SelectListItem x) => x.Text == "ResponsibleUserId")).Value);
						}
						if (item.RollId.GetValueOrDefault() <= 0 && Enumerable.FirstOrDefault<SelectListItem>((IEnumerable<SelectListItem>)list3, (Func<SelectListItem, bool>)((SelectListItem x) => x.Text == "RollId")).Value != null)
						{
							item.RollId = int.Parse(Enumerable.FirstOrDefault<SelectListItem>((IEnumerable<SelectListItem>)list3, (Func<SelectListItem, bool>)((SelectListItem x) => x.Text == "RollId")).Value);
						}
						if (!item.IsActive.GetValueOrDefault() && Enumerable.FirstOrDefault<SelectListItem>((IEnumerable<SelectListItem>)list3, (Func<SelectListItem, bool>)((SelectListItem x) => x.Text == "IsActive")).Value != null)
						{
							item.IsActive = bool.Parse(Enumerable.FirstOrDefault<SelectListItem>((IEnumerable<SelectListItem>)list3, (Func<SelectListItem, bool>)((SelectListItem x) => x.Text == "IsActive")).Value);
						}
						if (!item.UserIsActiveInWinApp.GetValueOrDefault() && Enumerable.FirstOrDefault<SelectListItem>((IEnumerable<SelectListItem>)list3, (Func<SelectListItem, bool>)((SelectListItem x) => x.Text == "UserIsActiveInWinApp")).Value != null)
						{
							item.UserIsActiveInWinApp = bool.Parse(Enumerable.FirstOrDefault<SelectListItem>((IEnumerable<SelectListItem>)list3, (Func<SelectListItem, bool>)((SelectListItem x) => x.Text == "UserIsActiveInWinApp")).Value);
						}
						if (!item.UserIsActiveInWebApp.GetValueOrDefault() && Enumerable.FirstOrDefault<SelectListItem>((IEnumerable<SelectListItem>)list3, (Func<SelectListItem, bool>)((SelectListItem x) => x.Text == "UserIsActiveInWebApp")).Value != null)
						{
							item.UserIsActiveInWebApp = bool.Parse(Enumerable.FirstOrDefault<SelectListItem>((IEnumerable<SelectListItem>)list3, (Func<SelectListItem, bool>)((SelectListItem x) => x.Text == "UserIsActiveInWebApp")).Value);
						}
						if (!item.UserIsActiveInFOSetting.GetValueOrDefault() && Enumerable.FirstOrDefault<SelectListItem>((IEnumerable<SelectListItem>)list3, (Func<SelectListItem, bool>)((SelectListItem x) => x.Text == "UserIsActiveInFOSetting")).Value != null)
						{
							item.UserIsActiveInFOSetting = bool.Parse(Enumerable.FirstOrDefault<SelectListItem>((IEnumerable<SelectListItem>)list3, (Func<SelectListItem, bool>)((SelectListItem x) => x.Text == "UserIsActiveInFOSetting")).Value);
						}
						if (!item.AccessOtherUsersCmpInfo.GetValueOrDefault() && Enumerable.FirstOrDefault<SelectListItem>((IEnumerable<SelectListItem>)list3, (Func<SelectListItem, bool>)((SelectListItem x) => x.Text == "AccessOtherUsersCmpInfo")).Value != null)
						{
							item.AccessOtherUsersCmpInfo = bool.Parse(Enumerable.FirstOrDefault<SelectListItem>((IEnumerable<SelectListItem>)list3, (Func<SelectListItem, bool>)((SelectListItem x) => x.Text == "AccessOtherUsersCmpInfo")).Value);
						}
						if (!item.AccessOtherUsersPrsInfo.GetValueOrDefault() && Enumerable.FirstOrDefault<SelectListItem>((IEnumerable<SelectListItem>)list3, (Func<SelectListItem, bool>)((SelectListItem x) => x.Text == "AccessOtherUsersPrsInfo")).Value != null)
						{
							item.AccessOtherUsersPrsInfo = bool.Parse(Enumerable.FirstOrDefault<SelectListItem>((IEnumerable<SelectListItem>)list3, (Func<SelectListItem, bool>)((SelectListItem x) => x.Text == "AccessOtherUsersPrsInfo")).Value);
						}
						if (!item.AccessOtherUsersPrjInfo.GetValueOrDefault() && Enumerable.FirstOrDefault<SelectListItem>((IEnumerable<SelectListItem>)list3, (Func<SelectListItem, bool>)((SelectListItem x) => x.Text == "AccessOtherUsersPrjInfo")).Value != null)
						{
							item.AccessOtherUsersPrjInfo = bool.Parse(Enumerable.FirstOrDefault<SelectListItem>((IEnumerable<SelectListItem>)list3, (Func<SelectListItem, bool>)((SelectListItem x) => x.Text == "AccessOtherUsersPrjInfo")).Value);
						}
						if (!item.AccessOtherUsersCnvsInfo.GetValueOrDefault() && Enumerable.FirstOrDefault<SelectListItem>((IEnumerable<SelectListItem>)list3, (Func<SelectListItem, bool>)((SelectListItem x) => x.Text == "AccessOtherUsersCnvsInfo")).Value != null)
						{
							item.AccessOtherUsersCnvsInfo = bool.Parse(Enumerable.FirstOrDefault<SelectListItem>((IEnumerable<SelectListItem>)list3, (Func<SelectListItem, bool>)((SelectListItem x) => x.Text == "AccessOtherUsersCnvsInfo")).Value);
						}
						if (!item.DisableInternalMessageAllarmVoice.GetValueOrDefault() && Enumerable.FirstOrDefault<SelectListItem>((IEnumerable<SelectListItem>)list3, (Func<SelectListItem, bool>)((SelectListItem x) => x.Text == "DisableInternalMessageAllarmVoice")).Value != null)
						{
							item.DisableInternalMessageAllarmVoice = bool.Parse(Enumerable.FirstOrDefault<SelectListItem>((IEnumerable<SelectListItem>)list3, (Func<SelectListItem, bool>)((SelectListItem x) => x.Text == "DisableInternalMessageAllarmVoice")).Value);
						}
						if (!item.DisableReceiveCNVSInfoAllarm.GetValueOrDefault() && Enumerable.FirstOrDefault<SelectListItem>((IEnumerable<SelectListItem>)list3, (Func<SelectListItem, bool>)((SelectListItem x) => x.Text == "DisableReceiveCNVSInfoAllarm")).Value != null)
						{
							item.DisableReceiveCNVSInfoAllarm = bool.Parse(Enumerable.FirstOrDefault<SelectListItem>((IEnumerable<SelectListItem>)list3, (Func<SelectListItem, bool>)((SelectListItem x) => x.Text == "DisableReceiveCNVSInfoAllarm")).Value);
						}
						if (!item.UserAccessDailyChrtAllUsers.GetValueOrDefault() && Enumerable.FirstOrDefault<SelectListItem>((IEnumerable<SelectListItem>)list3, (Func<SelectListItem, bool>)((SelectListItem x) => x.Text == "UserAccessDailyChrtAllUsers")).Value != null)
						{
							item.UserAccessDailyChrtAllUsers = bool.Parse(Enumerable.FirstOrDefault<SelectListItem>((IEnumerable<SelectListItem>)list3, (Func<SelectListItem, bool>)((SelectListItem x) => x.Text == "UserAccessDailyChrtAllUsers")).Value);
						}
						if (!item.UserAccessSaleChrtAllUsers.GetValueOrDefault() && Enumerable.FirstOrDefault<SelectListItem>((IEnumerable<SelectListItem>)list3, (Func<SelectListItem, bool>)((SelectListItem x) => x.Text == "UserAccessSaleChrtAllUsers")).Value != null)
						{
							item.UserAccessSaleChrtAllUsers = bool.Parse(Enumerable.FirstOrDefault<SelectListItem>((IEnumerable<SelectListItem>)list3, (Func<SelectListItem, bool>)((SelectListItem x) => x.Text == "UserAccessSaleChrtAllUsers")).Value);
						}
						if (!item.MobDeActiveAccessToLocation.GetValueOrDefault() && Enumerable.FirstOrDefault<SelectListItem>((IEnumerable<SelectListItem>)list3, (Func<SelectListItem, bool>)((SelectListItem x) => x.Text == "MobDeActiveAccessToLocation")).Value != null)
						{
							item.MobDeActiveAccessToLocation = bool.Parse(Enumerable.FirstOrDefault<SelectListItem>((IEnumerable<SelectListItem>)list3, (Func<SelectListItem, bool>)((SelectListItem x) => x.Text == "MobDeActiveAccessToLocation")).Value);
						}
						if (!item.MobDeActiveScreenshot.GetValueOrDefault() && Enumerable.FirstOrDefault<SelectListItem>((IEnumerable<SelectListItem>)list3, (Func<SelectListItem, bool>)((SelectListItem x) => x.Text == "MobDeActiveScreenshot")).Value != null)
						{
							item.MobDeActiveScreenshot = bool.Parse(Enumerable.FirstOrDefault<SelectListItem>((IEnumerable<SelectListItem>)list3, (Func<SelectListItem, bool>)((SelectListItem x) => x.Text == "MobDeActiveScreenshot")).Value);
						}
						if (!item.CallreIdDeActive.GetValueOrDefault() && Enumerable.FirstOrDefault<SelectListItem>((IEnumerable<SelectListItem>)list3, (Func<SelectListItem, bool>)((SelectListItem x) => x.Text == "CallreIdDeActive")).Value != null)
						{
							item.CallreIdDeActive = bool.Parse(Enumerable.FirstOrDefault<SelectListItem>((IEnumerable<SelectListItem>)list3, (Func<SelectListItem, bool>)((SelectListItem x) => x.Text == "CallreIdDeActive")).Value);
						}
						if (!item.MobCallerIdDeActive.GetValueOrDefault() && Enumerable.FirstOrDefault<SelectListItem>((IEnumerable<SelectListItem>)list3, (Func<SelectListItem, bool>)((SelectListItem x) => x.Text == "MobCallerIdDeActive")).Value != null)
						{
							item.MobCallerIdDeActive = bool.Parse(Enumerable.FirstOrDefault<SelectListItem>((IEnumerable<SelectListItem>)list3, (Func<SelectListItem, bool>)((SelectListItem x) => x.Text == "MobCallerIdDeActive")).Value);
						}
						if (!item.CallerIdDeActiveFromMobile.GetValueOrDefault() && Enumerable.FirstOrDefault<SelectListItem>((IEnumerable<SelectListItem>)list3, (Func<SelectListItem, bool>)((SelectListItem x) => x.Text == "CallerIdDeActiveFromMobile")).Value != null)
						{
							item.CallerIdDeActiveFromMobile = bool.Parse(Enumerable.FirstOrDefault<SelectListItem>((IEnumerable<SelectListItem>)list3, (Func<SelectListItem, bool>)((SelectListItem x) => x.Text == "CallerIdDeActiveFromMobile")).Value);
						}
						if (!item.AllowCopyOtherLanguage.GetValueOrDefault() && Enumerable.FirstOrDefault<SelectListItem>((IEnumerable<SelectListItem>)list3, (Func<SelectListItem, bool>)((SelectListItem x) => x.Text == "AllowCopyOtherLanguage")).Value != null)
						{
							item.AllowCopyOtherLanguage = bool.Parse(Enumerable.FirstOrDefault<SelectListItem>((IEnumerable<SelectListItem>)list3, (Func<SelectListItem, bool>)((SelectListItem x) => x.Text == "AllowCopyOtherLanguage")).Value);
						}
						if (!item.AccessAllLanguage.GetValueOrDefault() && Enumerable.FirstOrDefault<SelectListItem>((IEnumerable<SelectListItem>)list3, (Func<SelectListItem, bool>)((SelectListItem x) => x.Text == "AccessAllLanguage")).Value != null)
						{
							item.AccessAllLanguage = bool.Parse(Enumerable.FirstOrDefault<SelectListItem>((IEnumerable<SelectListItem>)list3, (Func<SelectListItem, bool>)((SelectListItem x) => x.Text == "AccessAllLanguage")).Value);
						}
						if (!item.DeActiveSmartTimeAttendance.GetValueOrDefault() && Enumerable.FirstOrDefault<SelectListItem>((IEnumerable<SelectListItem>)list3, (Func<SelectListItem, bool>)((SelectListItem x) => x.Text == "DeActiveSmartTimeAttendance")).Value != null)
						{
							item.DeActiveSmartTimeAttendance = bool.Parse(Enumerable.FirstOrDefault<SelectListItem>((IEnumerable<SelectListItem>)list3, (Func<SelectListItem, bool>)((SelectListItem x) => x.Text == "DeActiveSmartTimeAttendance")).Value);
						}
						bool valueOrDefault = item.IsActive.GetValueOrDefault();
						bool valueOrDefault2 = item.UserIsActiveInWinApp.GetValueOrDefault();
						bool valueOrDefault3 = item.UserIsActiveInWebApp.GetValueOrDefault();
						bool valueOrDefault4 = item.UserIsActiveInMobApp.GetValueOrDefault();
						bool valueOrDefault5 = item.UserIsActiveInHRM.GetValueOrDefault();
						bool valueOrDefault6 = item.UserIsActiveInCIC.GetValueOrDefault();
						if (!valueOrDefault)
						{
							item.UserIsActiveInWinApp = false;
							item.UserIsActiveInWebApp = false;
							item.UserIsActiveInMobApp = false;
							item.UserIsActiveInHRM = false;
							item.UserIsActiveInCIC = false;
						}
						if (valueOrDefault2 || valueOrDefault3 || valueOrDefault4 || valueOrDefault5 || valueOrDefault6)
						{
							item.IsActive = true;
						}
						try
						{
							int num = 0;
							int num2 = 0;
							num = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)_dbI.CRMspReturnActiveUsersCount()).GetValueOrDefault();
							num2 = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)_dbI.CRMspReturnActiveUsersInWebAppCount()).GetValueOrDefault();
							int num3 = 50;
							int num4 = Configuration.MaxCountOfOnlineUser + Configuration.MaxCountOfOnlineUserDeActive;
							if (VersionBuyer.Enterprise)
							{
								num3 = Configuration.MaxCountOfOnlineUser;
							}
							bool result = false;
							bool.TryParse(item.IsActive.ToString(), out result);
							bool result2 = false;
							bool.TryParse(item.UserIsActiveInWebApp.ToString(), out result2);
							int maxCountOfOnlineUser = Configuration.MaxCountOfOnlineUser;
							if (result)
							{
								if (num4 <= num)
								{
									list.Add(new ImportExcelSpResultViewModel
									{
										RowNum = RowNum,
										Result = Messages.msgErrorFinishingUserDefinitionCapacity
									});
								}
								if (result2 && maxCountOfOnlineUser <= num2)
								{
									list.Add(new ImportExcelSpResultViewModel
									{
										RowNum = RowNum,
										Result = Messages.msgErrorFinishingUserDefinitionCapacity
									});
								}
								if (num3 <= num2)
								{
									list.Add(new ImportExcelSpResultViewModel
									{
										RowNum = RowNum,
										Result = Messages.msgErrorFinishingUserDefinitionCapacity
									});
								}
							}
						}
						catch (Exception e)
						{
							ErrorSignal.FromCurrentContext().Raise(e);
						}
						if (base.ModelState.IsValid)
						{
							if (!Center.HaveModule && item.UserCIds.GetValueOrDefault() == 0 && string.IsNullOrWhiteSpace(item.UserCenterCode))
							{
								item.UserCIds = userCIds;
							}
							DateTime dateTime = default(DateTime);
							string text = "";
							try
							{
								if (!string.IsNullOrEmpty(item.StartDatePersian))
								{
									text = PersianDate.GetFormatetdDate(item.StartDatePersian.Replace("/", ""));
									switch (lCID)
									{
									case 1065:
										dateTime = DateTime.Parse(text + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture());
										item.StartDatePersian = dateTime.ToString("yyyyMMdd");
										break;
									case 1025:
										dateTime = DateTime.Parse(text + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA"));
										item.StartDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
										break;
									default:
										dateTime = DateTime.Parse(text + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US"));
										item.StartDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
										break;
									}
									item.StartDate = dateTime;
								}
								else
								{
									item.StartDate = null;
								}
							}
							catch (Exception e2)
							{
								ErrorSignal.FromCurrentContext().Raise(e2);
								list.Add(new ImportExcelSpResultViewModel
								{
									RowNum = RowNum,
									Result = string.Format(Messages.ErrorInFormat, Labels.UserStartDate)
								});
							}
							if (item.StartDatePersian != null)
							{
								item.StartDatePersian = item.StartDatePersian.Replace("/", "").Replace("-", "").Replace("_", "")
									.Replace(".", "")
									.Replace(",", "")
									.Replace("\\", "");
							}
							dateTime = default(DateTime);
							text = "";
							try
							{
								if (!string.IsNullOrEmpty(item.ExpireDatePersian))
								{
									text = PersianDate.GetFormatetdDate(item.ExpireDatePersian.Replace("/", ""));
									switch (lCID)
									{
									case 1065:
										dateTime = DateTime.Parse(text + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture());
										item.ExpireDatePersian = dateTime.ToString("yyyyMMdd");
										break;
									case 1025:
										dateTime = DateTime.Parse(text + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA"));
										item.ExpireDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
										break;
									default:
										dateTime = DateTime.Parse(text + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US"));
										item.ExpireDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
										break;
									}
									item.ExpireDate = dateTime;
								}
								else
								{
									item.ExpireDate = null;
								}
							}
							catch (Exception e3)
							{
								ErrorSignal.FromCurrentContext().Raise(e3);
								list.Add(new ImportExcelSpResultViewModel
								{
									RowNum = RowNum,
									Result = string.Format(Messages.ErrorInFormat, Labels.UserExpireDate)
								});
							}
							if (item.ExpireDatePersian != null)
							{
								item.ExpireDatePersian = item.ExpireDatePersian.Replace("/", "").Replace("-", "").Replace("_", "")
									.Replace(".", "")
									.Replace(",", "")
									.Replace("\\", "");
							}
							item.UserIsActiveInWebApp.GetValueOrDefault();
							bool valueOrDefault7 = item.UserIsActiveInMobApp.GetValueOrDefault();
							_ = Configuration.MaxCountOfOnlineUser;
							int maxCountOfOnlineUserInMob = Configuration.MaxCountOfOnlineUserInMob;
							if (!valueOrDefault7)
							{
								item.MobUserAppUseCnt = null;
							}
							if (valueOrDefault7 && Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)_dbI.CRMspReturnSumMobUserAppUseCnt()).GetValueOrDefault() + item.MobUserAppUseCnt.GetValueOrDefault() > maxCountOfOnlineUserInMob)
							{
								list.Add(new ImportExcelSpResultViewModel
								{
									RowNum = RowNum,
									Result = string.Format(Messages.msgErrorDefineNewUserAppUseCntMoreThenMaxCountAllowedInMob, maxCountOfOnlineUserInMob.ToString())
								});
							}
							bool result3 = false;
							bool.TryParse(item.UserIsActiveInHRM.ToString(), out result3);
							int maxCountOfOnlineUserInHrm = Configuration.MaxCountOfOnlineUserInHrm;
							if (!result3)
							{
								item.MobHRMUserAppUseCnt = null;
							}
							if (result3 && Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)_dbI.CRMspReturnSumMobHRMUserAppUseCnt()).GetValueOrDefault() + item.MobHRMUserAppUseCnt.GetValueOrDefault() > maxCountOfOnlineUserInHrm)
							{
								list.Add(new ImportExcelSpResultViewModel
								{
									RowNum = RowNum,
									Result = string.Format(Messages.msgErrorDefineNewUserAppUseCntMoreThenMaxCountAllowedInHrm, maxCountOfOnlineUserInHrm.ToString())
								});
							}
							bool result4 = false;
							bool.TryParse(item.UserIsActiveInCIC.ToString(), out result4);
							int maxCountCic = Configuration.MaxCountCic;
							if (!result4)
							{
								item.MobCICUserAppUseCnt = null;
							}
							if (result4 && Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)_dbI.CRMspReturnSumMobCICUserAppUseCnt()).GetValueOrDefault() + item.MobCICUserAppUseCnt.GetValueOrDefault() > maxCountCic)
							{
								list.Add(new ImportExcelSpResultViewModel
								{
									RowNum = RowNum,
									Result = string.Format(Messages.msgErrorDefineNewUserAppUseCntMoreThenMaxCountAllowedInCic, maxCountCic.ToString())
								});
							}
							CRMspCheckDuplicateActiveDirectoryUser_Result cRMspCheckDuplicateActiveDirectoryUser_Result = Enumerable.FirstOrDefault<CRMspCheckDuplicateActiveDirectoryUser_Result>((IEnumerable<CRMspCheckDuplicateActiveDirectoryUser_Result>)_dbII.CRMspCheckDuplicateActiveDirectoryUser(item.UserName, 0, lCID, defLangID));
							if (cRMspCheckDuplicateActiveDirectoryUser_Result != null && cRMspCheckDuplicateActiveDirectoryUser_Result.UserId != 0)
							{
								list.Add(new ImportExcelSpResultViewModel
								{
									RowNum = RowNum,
									Result = Labels.Duplicate
								});
							}
							if (Enumerable.FirstOrDefault<ImportExcelSpResultViewModel>((IEnumerable<ImportExcelSpResultViewModel>)list, (Func<ImportExcelSpResultViewModel, bool>)((ImportExcelSpResultViewModel x) => x.RowNum == RowNum)) != null)
							{
								continue;
							}
							DateTime now2 = DateTime.Now;
							item.PositionId = ((item.PositionId == 0) ? null : item.PositionId);
							ObjectParameter objectParameter = new ObjectParameter("InsertedId", 0);
							_dbII.CRMspImportUserFromExcelOrActiveDirectory(item.FName, item.LName, item.PersCode, item.UserName, item.Password ?? "12345", new BaseInfo().ConvertMd5(item.Password ?? "12345").ToLower(), item.IsActive, item.Description, item.IPAddress, item.Tel, item.TelDesc, item.PositionId, item.DepartmentId, item.ResponsibleUserId, item.ComputerName, item.CallreIdDeActive, item.CallreIdDeActiveLines, item.DisableInternalMessageAllarmVoice, item.DisableReceiveCNVSInfoAllarm, item.AllowCopyOtherLanguage, item.UserIsActiveInWinApp, item.UserIsActiveInWebApp, item.UserIsActiveInMobApp, item.UserIsActiveInFOSetting, item.UserAccessDailyChrtAllUsers, item.UserAccessSaleChrtAllUsers, item.Mobile, item.MobileII, item.Address, item.FatherName, item.NationalCode, item.IdentityNumber, item.InsuranceCode, item.StartDate, item.StartDatePersian, item.ExpireDate, item.ExpireDatePersian, item.UserGroupId, item.UserGroup, item.UserExtensions, item.MobDeActiveAccessToLocation, item.Nickname, item.DeActiveSmartTimeAttendance, item.UserIsActiveInHRM, item.AlternativeUserIds, item.ActiveMobMovementTracking, item.MobMovementTrackingDistanceInterval, item.MobMovementTrackingTimeInterval, item.DefCmpPrjTitle, item.MobDeActiveScreenshot, item.MobCallerIdDeActive, item.MobUserAppUseCnt, item.MobHRMUserAppUseCnt, item.UserIsActiveInCIC, item.MobCICUserAppUseCnt, item.CallerIdDeActiveFromMobile, item.ActiveDirectoryUser, userId, value, registerDatePersian, value3, appType, lCID, defLangID, objectParameter, item.UserCIds, item.UserCenterCode);
							int result5 = 0;
							if (objectParameter != null)
							{
								int.TryParse(objectParameter.Value.ToString(), out result5);
							}
							if (result5 > 0)
							{
								if (item.AccessAllLanguage.GetValueOrDefault())
								{
									foreach (Languages item2 in CRMIdeal.Cache.Setting.Language.Get())
									{
										UserLanguages entity = new UserLanguages
										{
											LanguageID = item2.LanguageID,
											UserId = result5,
											AppType = Configuration.AppType,
											GUId = Guid.NewGuid(),
											Year1 = short.Parse(Financial.Get().Id.ToString()),
											Month1 = short.Parse(now2.ToString("MM", new PersianCulture())),
											IsActive = true,
											RegisterDate = now2,
											RegisterDatePersian = now2.ToString("yyyyMMdd", new PersianCulture()),
											LanguageDirection = item2.LanguageDirection,
											UserId1 = userId,
											FirstRegisterDate = now2,
											FirstRegisterDatePersian = now2.ToString("yyyyMMdd", new PersianCulture()),
											FirstRegisterUserId = userId
										};
										_dbTbl.UserLanguages.Add(entity);
										_dbTbl.SaveChanges();
									}
								}
								else
								{
									string languageDirection = "";
									Languages languages = Enumerable.FirstOrDefault<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID == defLangID));
									if (languages != null)
									{
										languageDirection = languages.LanguageDirection;
									}
									UserLanguages entity2 = new UserLanguages
									{
										LanguageID = defLangID,
										UserId = result5,
										AppType = Configuration.AppType,
										GUId = Guid.NewGuid(),
										Year1 = short.Parse(Financial.Get().Id.ToString()),
										Month1 = short.Parse(now2.ToString("MM", new PersianCulture())),
										IsActive = true,
										RegisterDate = now2,
										RegisterDatePersian = now2.ToString("yyyyMMdd", new PersianCulture()),
										LanguageDirection = languageDirection,
										UserId1 = userId,
										FirstRegisterDate = now2,
										FirstRegisterDatePersian = now2.ToString("yyyyMMdd", new PersianCulture()),
										FirstRegisterUserId = userId
									};
									_dbTbl.UserLanguages.Add(entity2);
									_dbTbl.SaveChanges();
								}
								CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("Users");
								CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("UserLanguages", result5);
								if (result5 > 0)
								{
									int userId2 = UserLogin.CurrentUser.UserId;
									if (item.AccessOtherUsersCmpInfo.GetValueOrDefault())
									{
										_db.CRMspInsertCrmLinkedUserToAllUsers(14, result5, userId2, value2, value3, value, registerDatePersian, appType, defLangID, item.UserCIds);
									}
									if (item.AccessOtherUsersPrsInfo.GetValueOrDefault())
									{
										_db.CRMspInsertCrmLinkedUserToAllUsers(23, result5, userId2, value2, value3, value, registerDatePersian, appType, defLangID, item.UserCIds);
									}
									if (item.AccessOtherUsersPrjInfo.GetValueOrDefault())
									{
										_db.CRMspInsertCrmLinkedUserToAllUsers(24, result5, userId2, value2, value3, value, registerDatePersian, appType, defLangID, item.UserCIds);
									}
									if (item.AccessOtherUsersCnvsInfo.GetValueOrDefault())
									{
										_db.CRMspInsertCrmLinkedUserToAllUsers(25, result5, userId2, value2, value3, value, registerDatePersian, appType, defLangID, item.UserCIds);
									}
									CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmLinkedUsers", result5);
								}
								if (item.PositionId > 0)
								{
									_db.CRMspInsertLinkedUserPositionsByUserId(result5, item.PositionId, UserLogin.CurrentUser.UserId, value2, value3, value, registerDatePersian, appType, defLangID, item.UserCIds);
									CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmLinkedUsers");
								}
								item.StartDatePersian = (item.StartDate.HasValue ? item.StartDate.Value.ToString("yyyy/MM/dd") : "");
								item.ExpireDatePersian = (item.ExpireDate.HasValue ? item.ExpireDate.Value.ToString("yyyy/MM/dd") : "");
								UsersPermission usersPermission = new UsersPermission
								{
									RegisterDate = DateTime.Now,
									GUId = Guid.NewGuid(),
									AppType = Configuration.AppType,
									RollId = item.RollId,
									PrjId = 11,
									FirstRegisterDate = DateTime.Now,
									FirstRegisterDatePersian = DateTime.Now.ToString("yyyyMMdd", new PersianCulture()),
									UserId = result5,
									FirstRegisterUserId = UserLogin.CurrentUser.UserId,
									AccessLevel = null,
									LanguageID = defLangID,
									CId = item.UserCIds
								};
								_dbTbl.UsersPermission.Add(usersPermission);
								_dbTbl.SaveChanges();
								CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("UsersPermission", usersPermission.UserId);
								if (usersPermission.ID > 0)
								{
									_db.CRMspInsertLinkedUsersByRollId(1, usersPermission.UserId, usersPermission.RollId, userId, value2, value3, value, registerDatePersian, appType, defLangID, usersPermission.CId);
									CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmLinkedUsers");
								}
								Permissions.Update(usersPermission.UserId);
								list.Add(new ImportExcelSpResultViewModel
								{
									RowNum = RowNum,
									InsertedId = result5
								});
							}
							else
							{
								switch (result5)
								{
								case -50:
									list.Add(new ImportExcelSpResultViewModel
									{
										RowNum = RowNum,
										Result = Messages.msgErrorCenterNotFound
									});
									break;
								case 0:
									list.Add(new ImportExcelSpResultViewModel
									{
										RowNum = RowNum,
										Result = Messages.msgErrorOperationFailed
									});
									break;
								}
							}
							continue;
						}
						list.AddRange(Enumerable.Select<ModelError, ImportExcelSpResultViewModel>(Enumerable.SelectMany<ModelState, ModelError>((IEnumerable<ModelState>)base.ModelState.Values, (Func<ModelState, IEnumerable<ModelError>>)((ModelState x) => x.Errors)), (Func<ModelError, ImportExcelSpResultViewModel>)((ModelError x) => new ImportExcelSpResultViewModel
						{
							Result = x.ErrorMessage
						})));
					}
					catch (DbEntityValidationException e4)
					{
						ErrorSignal.FromCurrentContext().Raise((Exception)(object)e4);
						list.Add(new ImportExcelSpResultViewModel
						{
							Result = Messages.frmErrorMessage
						});
					}
					catch (Exception e5)
					{
						ErrorSignal.FromCurrentContext().Raise(e5);
						list.Add(new ImportExcelSpResultViewModel
						{
							Result = Messages.frmErrorMessage
						});
					}
				}
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
			impExcelData.Messages = impExcelData.Messages + "\n" + ex.Message;
		}
		impExcelData.EndReq = DateTime.Now;
		impExcelData.EndReqStr = impExcelData.EndReq.ToString("yyyy/MM/dd HH:mm:ss");
		if (flag)
		{
			double totalSeconds = (impExcelData.EndReq - impExcelData.StartReq).TotalSeconds;
			impExcelData.EndTotalReq = impExcelData.StartReq.AddSeconds(totalSeconds);
			impExcelData.EndTotalReqStr = impExcelData.EndTotalReq.ToString();
		}
		impExcelData.Data = JsonConvert.SerializeObject(list);
		return JsonConvert.SerializeObject(impExcelData);
	}

	[HttpPost]
	[LoginAuthorize]
	public string DeleteImportedData(string ids = "")
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			if (string.IsNullOrWhiteSpace(ids))
			{
				list.Add(new SelectListItem
				{
					Text = Messages.msgErrorEmptyList
				});
			}
			if (list.Count <= 0)
			{
				string[] array = ids.Split(new char[1] { ',' });
				foreach (string text in array)
				{
					if (string.IsNullOrWhiteSpace(text))
					{
						continue;
					}
					mct_II_Result mct_II_Result = Enumerable.FirstOrDefault<mct_II_Result>((IEnumerable<mct_II_Result>)_dbII.CRMspDeleteUserImportedExcelFromCrm(text));
					if (mct_II_Result != null)
					{
						if (mct_II_Result.Result != 1)
						{
							list.Add(new SelectListItem
							{
								Text = Messages.msgErrorOperationFailed,
								Value = text
							});
						}
					}
					else
					{
						list.Add(new SelectListItem
						{
							Text = Messages.msgErrorOperationFailed
						});
					}
				}
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return JsonConvert.SerializeObject(list);
	}

	[HttpPost]
	[LoginAuthorize]
	public string SelectUserDepartement()
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			List<CRMspSelectUserDepartments_Result> list2 = Enumerable.ToList<CRMspSelectUserDepartments_Result>((IEnumerable<CRMspSelectUserDepartments_Result>)_db.CRMspSelectUserDepartments(lCID, result, result2));
			if (list2 != null)
			{
				list.AddRange(Enumerable.Select<CRMspSelectUserDepartments_Result, SelectListItem>((IEnumerable<CRMspSelectUserDepartments_Result>)list2, (Func<CRMspSelectUserDepartments_Result, SelectListItem>)((CRMspSelectUserDepartments_Result x) => new SelectListItem
				{
					Text = x.Department,
					Value = x.DepartmentID.ToString()
				})));
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return JsonConvert.SerializeObject(list);
	}

	[HttpPost]
	[LoginAuthorize]
	public string SelectUserGroups()
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspSelectUserGroups_Result> list2 = Enumerable.ToList<CRMspSelectUserGroups_Result>((IEnumerable<CRMspSelectUserGroups_Result>)_db.CRMspSelectUserGroups(lCID, result));
			if (list2 != null)
			{
				list.AddRange(Enumerable.Select<CRMspSelectUserGroups_Result, SelectListItem>((IEnumerable<CRMspSelectUserGroups_Result>)list2, (Func<CRMspSelectUserGroups_Result, SelectListItem>)((CRMspSelectUserGroups_Result x) => new SelectListItem
				{
					Text = x.GroupName,
					Value = x.UserGroupId.ToString()
				})));
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return JsonConvert.SerializeObject(list);
	}

	[HttpPost]
	[LoginAuthorize]
	public string SelectSysRolls()
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspSelectsysRolls_Result> list2 = Enumerable.ToList<CRMspSelectsysRolls_Result>((IEnumerable<CRMspSelectsysRolls_Result>)_db.CRMspSelectsysRolls(lCID, result));
			if (list2 != null)
			{
				list.AddRange(Enumerable.Select<CRMspSelectsysRolls_Result, SelectListItem>((IEnumerable<CRMspSelectsysRolls_Result>)list2, (Func<CRMspSelectsysRolls_Result, SelectListItem>)((CRMspSelectsysRolls_Result x) => new SelectListItem
				{
					Text = x.RollName,
					Value = x.ID.ToString()
				})));
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return JsonConvert.SerializeObject(list);
	}

	[HttpPost]
	[LoginAuthorize]
	public string SelectResponsibleUsers()
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			List<CRMspSelectActiveUsers_Result> list2 = Enumerable.ToList<CRMspSelectActiveUsers_Result>((IEnumerable<CRMspSelectActiveUsers_Result>)_db.CRMspSelectActiveUsers(lCID, result, result2));
			if (list2 != null)
			{
				list.AddRange(Enumerable.Select<CRMspSelectActiveUsers_Result, SelectListItem>((IEnumerable<CRMspSelectActiveUsers_Result>)list2, (Func<CRMspSelectActiveUsers_Result, SelectListItem>)((CRMspSelectActiveUsers_Result x) => new SelectListItem
				{
					Text = x.FName + " " + x.LName,
					Value = x.UserId.ToString()
				})));
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return JsonConvert.SerializeObject(list);
	}

	[AjaxOnly]
	public ActionResult _PartialUserPositionsTree(int posId = 0, bool showId = false)
	{
		try
		{
			List<TreeViewItemModel> userPositionTree = GetUserPositionTree(posId, showId);
			base.ViewBag.PositionsTree = userPositionTree;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return PartialView();
	}

	public List<TreeViewItemModel> GetUserPositionTree(int posId = 0, bool showId = false)
	{
		List<TreeViewItemModel> list = new List<TreeViewItemModel>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspSelectUserPositionTree_Result> list2 = Enumerable.ToList<CRMspSelectUserPositionTree_Result>(Enumerable.Where<CRMspSelectUserPositionTree_Result>((IEnumerable<CRMspSelectUserPositionTree_Result>)_db.CRMspSelectUserPositionTree(lCID, result), (Func<CRMspSelectUserPositionTree_Result, bool>)((CRMspSelectUserPositionTree_Result m) => m.PositionId != posId)));
			if (Enumerable.Any<CRMspSelectUserPositionTree_Result>((IEnumerable<CRMspSelectUserPositionTree_Result>)list2))
			{
				List<CRMspSelectUserPositionTree_Result> list3 = Enumerable.ToList<CRMspSelectUserPositionTree_Result>(Enumerable.Where<CRMspSelectUserPositionTree_Result>((IEnumerable<CRMspSelectUserPositionTree_Result>)list2, (Func<CRMspSelectUserPositionTree_Result, bool>)((CRMspSelectUserPositionTree_Result m) => m.ParentId == 0)));
				if (Enumerable.Any<CRMspSelectUserPositionTree_Result>((IEnumerable<CRMspSelectUserPositionTree_Result>)list3))
				{
					foreach (CRMspSelectUserPositionTree_Result item in list3)
					{
						TreeViewItemModel treeViewItemModel = new TreeViewItemModel();
						treeViewItemModel.HtmlAttributes.Add(new KeyValuePair<string, string>("accesskey", item.PositionId.ToString()));
						treeViewItemModel.Id = item.PositionId.ToString();
						treeViewItemModel.Text = item.PositionNameWithCode + (showId ? (" ( id: " + item.PositionId + " )") : "");
						treeViewItemModel.ImageUrl = "";
						List<TreeViewItemModel> userPositionNodeTree = GetUserPositionNodeTree(list2, item.PositionId, showId);
						treeViewItemModel.Items = new List<TreeViewItemModel>(userPositionNodeTree);
						list.Add(treeViewItemModel);
					}
				}
			}
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		return list;
	}

	public List<TreeViewItemModel> GetUserPositionNodeTree(List<CRMspSelectUserPositionTree_Result> lstPositions, int? posId, bool showId = false)
	{
		List<TreeViewItemModel> list = new List<TreeViewItemModel>();
		try
		{
			List<CRMspSelectUserPositionTree_Result> list2 = Enumerable.ToList<CRMspSelectUserPositionTree_Result>(Enumerable.Where<CRMspSelectUserPositionTree_Result>((IEnumerable<CRMspSelectUserPositionTree_Result>)lstPositions, (Func<CRMspSelectUserPositionTree_Result, bool>)((CRMspSelectUserPositionTree_Result m) => m.ParentId == posId)));
			if (Enumerable.Any<CRMspSelectUserPositionTree_Result>((IEnumerable<CRMspSelectUserPositionTree_Result>)list2))
			{
				foreach (CRMspSelectUserPositionTree_Result item in list2)
				{
					TreeViewItemModel treeViewItemModel = new TreeViewItemModel();
					treeViewItemModel.HtmlAttributes.Add(new KeyValuePair<string, string>("accesskey", item.PositionId.ToString()));
					treeViewItemModel.Id = item.PositionId.ToString();
					treeViewItemModel.Text = item.PositionNameWithCode + (showId ? (" ( id: " + item.PositionId + " )") : "");
					treeViewItemModel.ImageUrl = "";
					List<TreeViewItemModel> userPositionNodeTree = GetUserPositionNodeTree(lstPositions, item.PositionId, showId);
					treeViewItemModel.Items = new List<TreeViewItemModel>(userPositionNodeTree);
					list.Add(treeViewItemModel);
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}
}
