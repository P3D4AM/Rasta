using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Cache.User;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.Classes.Helper;
using CRMIdeal.GSD.Globalization;
using Newtonsoft.Json;

namespace CRMIdeal.Areas.Filter.Controllers;

public class HomeController : Controller
{
	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	private readonly CRMSpIIEntities _dbII = new CRMSpIIEntities();

	public ActionResult Index()
	{
		base.ViewBag.UserReportFilterGroupJs = SelectUserReportFilterGroup();
		return View();
	}

	[HttpPost]
	[LoginAuthorize]
	public List<CRMspSelectActiveSysDBObjects_Result> SelectSysDBObjects(string dbObjectName = "")
	{
		List<CRMspSelectActiveSysDBObjects_Result> result = new List<CRMspSelectActiveSysDBObjects_Result>();
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
			List<CRMspSelectActiveSysDBObjects_Result> list = Enumerable.ToList<CRMspSelectActiveSysDBObjects_Result>((IEnumerable<CRMspSelectActiveSysDBObjects_Result>)_dbII.CRMspSelectActiveSysDBObjects(lCID, result2, dbObjectName));
			if (list != null)
			{
				result = list;
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
	public string GetDBObjectsJs(string dbObjectName = "")
	{
		return JsonConvert.SerializeObject(SelectSysDBObjects(dbObjectName));
	}

	[HttpPost]
	[LoginAuthorize]
	public List<CRMspRpt_SysDBObjects_UserReportFilter_Result> Rpt_SysDBObjects_UserReportFilter(int userReportFilterId = 0, string dbObjectName = "")
	{
		List<CRMspRpt_SysDBObjects_UserReportFilter_Result> list = new List<CRMspRpt_SysDBObjects_UserReportFilter_Result>();
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
			List<CRMspRpt_SysDBObjects_UserReportFilter_Result> list2 = Enumerable.ToList<CRMspRpt_SysDBObjects_UserReportFilter_Result>((IEnumerable<CRMspRpt_SysDBObjects_UserReportFilter_Result>)_dbII.CRMspRpt_SysDBObjects_UserReportFilter(userReportFilterId, lCID, result));
			if (list2 != null)
			{
				list = list2;
				if (dbObjectName.Contains("WSProducts"))
				{
					list = Product.FillUserReportFieldsByPrdSpecifications(list, false);
				}
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return list;
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetRpt_SysDBObjects_UserReportFilter(int userReportFilterId = 0, string dbObjectName = "")
	{
		return JsonConvert.SerializeObject(Rpt_SysDBObjects_UserReportFilter(userReportFilterId, dbObjectName));
	}

	private List<CRMspSelectUserReportFilterGroup_Result> SelectUserReportFilterGroup()
	{
		List<CRMspSelectUserReportFilterGroup_Result> result = new List<CRMspSelectUserReportFilterGroup_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspSelectUserReportFilterGroup_Result> list = Enumerable.ToList<CRMspSelectUserReportFilterGroup_Result>((IEnumerable<CRMspSelectUserReportFilterGroup_Result>)_dbII.CRMspSelectUserReportFilterGroup(lCID, result2));
			if (list != null)
			{
				result = list;
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
	public string GetUserReportFilterGroup()
	{
		return JsonConvert.SerializeObject(SelectUserReportFilterGroup());
	}

	[HttpPost]
	[LoginAuthorize]
	public List<CRMspSelectUserReportFilter_Result> SelectUserReportFilter(int? groupId = null)
	{
		List<CRMspSelectUserReportFilter_Result> result = new List<CRMspSelectUserReportFilter_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int? userLastCId = null;
			if (UserLogin.CurrentUser != null)
			{
				userLastCId = UserLogin.CurrentUser.UserLastCId;
			}
			List<CRMspSelectUserReportFilter_Result> list = Enumerable.ToList<CRMspSelectUserReportFilter_Result>((IEnumerable<CRMspSelectUserReportFilter_Result>)_dbII.CRMspSelectUserReportFilter(UserLogin.CurrentUser.UserId, groupId, lCID, result2, userLastCId));
			if (list != null)
			{
				foreach (CRMspSelectUserReportFilter_Result item in list)
				{
					if (string.IsNullOrWhiteSpace(item.rptIsPublicForUsersId))
					{
						continue;
					}
					List<CommonSelectListItemViewModel> list2 = JsonConvert.DeserializeObject<List<CommonSelectListItemViewModel>>(item.rptIsPublicForUsersId);
					item.rptIsPublicForUsersId = "";
					if (list2 != null)
					{
						CommonSelectListItemViewModel commonSelectListItemViewModel = Enumerable.FirstOrDefault<CommonSelectListItemViewModel>((IEnumerable<CommonSelectListItemViewModel>)list2, (Func<CommonSelectListItemViewModel, bool>)((CommonSelectListItemViewModel x) => x.Id == userLastCId));
						if (commonSelectListItemViewModel != null)
						{
							item.rptIsPublicForUsersId = commonSelectListItemViewModel.Value ?? "";
						}
					}
				}
				result = list;
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
	public string GetUserReportFilter(int? groupId = null)
	{
		return JsonConvert.SerializeObject(SelectUserReportFilter(groupId));
	}

	[HttpPost]
	[LoginAuthorize]
	public CRMspSelectUserReportFilterWithId_Result SelectUserReportFilterWithId(int? userReportFilterId = null)
	{
		CRMspSelectUserReportFilterWithId_Result result = new CRMspSelectUserReportFilterWithId_Result();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int? userLastCId = null;
			if (UserLogin.CurrentUser != null)
			{
				userLastCId = UserLogin.CurrentUser.UserLastCId;
			}
			CRMspSelectUserReportFilterWithId_Result cRMspSelectUserReportFilterWithId_Result = Enumerable.FirstOrDefault<CRMspSelectUserReportFilterWithId_Result>((IEnumerable<CRMspSelectUserReportFilterWithId_Result>)_dbII.CRMspSelectUserReportFilterWithId(userReportFilterId, lCID, result2, userLastCId));
			if (cRMspSelectUserReportFilterWithId_Result != null)
			{
				if (!string.IsNullOrWhiteSpace(cRMspSelectUserReportFilterWithId_Result.rptIsPublicForUsersId))
				{
					List<CommonSelectListItemViewModel> list = JsonConvert.DeserializeObject<List<CommonSelectListItemViewModel>>(cRMspSelectUserReportFilterWithId_Result.rptIsPublicForUsersId);
					cRMspSelectUserReportFilterWithId_Result.rptIsPublicForUsersId = "";
					if (list != null)
					{
						CommonSelectListItemViewModel commonSelectListItemViewModel = Enumerable.FirstOrDefault<CommonSelectListItemViewModel>((IEnumerable<CommonSelectListItemViewModel>)list, (Func<CommonSelectListItemViewModel, bool>)((CommonSelectListItemViewModel x) => x.Id == userLastCId));
						if (commonSelectListItemViewModel != null)
						{
							cRMspSelectUserReportFilterWithId_Result.rptIsPublicForUsersId = commonSelectListItemViewModel.Value ?? "";
						}
					}
				}
				result = cRMspSelectUserReportFilterWithId_Result;
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
	public string GetUserReportFilterWithId(int? userReportFilterId = null)
	{
		return JsonConvert.SerializeObject(SelectUserReportFilterWithId(userReportFilterId));
	}

	[HttpPost]
	[LoginAuthorize]
	public List<CRMspRpt_SysDBObjects_UserReportFilterResultColumns_Result> SelectUserReportFilterResultColumns(string dBObjectNames = "", int? userReportFilterId = null, bool? orderBySelectedCols = null, bool? addExtraFields = false)
	{
		List<CRMspRpt_SysDBObjects_UserReportFilterResultColumns_Result> list = new List<CRMspRpt_SysDBObjects_UserReportFilterResultColumns_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspRpt_SysDBObjects_UserReportFilterResultColumns_Result> list2 = Enumerable.ToList<CRMspRpt_SysDBObjects_UserReportFilterResultColumns_Result>((IEnumerable<CRMspRpt_SysDBObjects_UserReportFilterResultColumns_Result>)_dbII.CRMspRpt_SysDBObjects_UserReportFilterResultColumns(dBObjectNames, userReportFilterId, lCID, result, orderBySelectedCols));
			if (list2 != null)
			{
				list = list2;
				if (dBObjectNames.Contains("WSProducts"))
				{
					list = Product.FillUserReportFilterResultColumnsByPrdSpecifications(list, addExtraFields);
				}
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return list;
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetUserReportFilterResultColumns(string dBObjectNames = "", int? userReportFilterId = null, bool? orderBySelectedCols = null, bool? addExtraFields = false)
	{
		return JsonConvert.SerializeObject(SelectUserReportFilterResultColumns(dBObjectNames, userReportFilterId, orderBySelectedCols, addExtraFields));
	}

	[HttpPost]
	[LoginAuthorize]
	public string UpdateUserReportFilterResultColumns(string js = null, int rptId = 0)
	{
		string result = "";
		try
		{
			_dbII.CRMspUpdateUserReportFilterResultColumns(js, rptId);
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
			result = Messages.msgErrorOperationFailed;
		}
		return result;
	}

	[HttpPost]
	[LoginAuthorize]
	public string InsertUpdateUserReportFilter(int id = 0, int? groupId = null, string title = "", string title_Lang = "", string fieldsJs = null, bool? isPublic = null, string isPublicForUsers = null, int? orderView = null)
	{
		string result = "";
		try
		{
			DateTime now = DateTime.Now;
			int userId = UserLogin.CurrentUser.UserId;
			short value = short.Parse(Financial.Get().Id.ToString());
			short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
			now.ToString("yyyyMMdd", new PersianCulture());
			string appType = Configuration.AppType;
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangID);
			if (defLangID <= 0)
			{
				defLangID = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int? userLastCId = null;
			if (UserLogin.CurrentUser != null)
			{
				userLastCId = UserLogin.CurrentUser.UserLastCId;
			}
			List<CrmUserReportFilter_Lang> list = new List<CrmUserReportFilter_Lang>();
			list.AddRange(Enumerable.ToList<CrmUserReportFilter_Lang>(Enumerable.Select<Languages, CrmUserReportFilter_Lang>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, CrmUserReportFilter_Lang>)((Languages x) => new CrmUserReportFilter_Lang
			{
				LanguageID = x.LanguageID
			}))));
			Enumerable.FirstOrDefault<CrmUserReportFilter_Lang>((IEnumerable<CrmUserReportFilter_Lang>)list, (Func<CrmUserReportFilter_Lang, bool>)((CrmUserReportFilter_Lang x) => x.LanguageID == defLangID)).rptTitle = title;
			List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrWhiteSpace(title_Lang))
			{
				list2 = JsonConvert.DeserializeObject<List<CommonMultiLanguageViewModel>>(title_Lang);
			}
			checkMultiLanguage(title, list2);
			foreach (CommonMultiLanguageViewModel i in list2)
			{
				Enumerable.FirstOrDefault<CrmUserReportFilter_Lang>((IEnumerable<CrmUserReportFilter_Lang>)list, (Func<CrmUserReportFilter_Lang, bool>)((CrmUserReportFilter_Lang x) => x.LanguageID == i.LanguageId)).rptTitle = i.Value;
			}
			List<CommonSelectListItemViewModel> list3 = new List<CommonSelectListItemViewModel>();
			CRMspSelectUserReportFilterWithId_Result cRMspSelectUserReportFilterWithId_Result = Enumerable.FirstOrDefault<CRMspSelectUserReportFilterWithId_Result>((IEnumerable<CRMspSelectUserReportFilterWithId_Result>)_dbII.CRMspSelectUserReportFilterWithId(id, lCID, defLangID, userLastCId));
			if (cRMspSelectUserReportFilterWithId_Result != null && !string.IsNullOrWhiteSpace(cRMspSelectUserReportFilterWithId_Result.rptIsPublicForUsersId))
			{
				list3 = JsonConvert.DeserializeObject<List<CommonSelectListItemViewModel>>(cRMspSelectUserReportFilterWithId_Result.rptIsPublicForUsersId);
			}
			int num = list3.FindIndex((CommonSelectListItemViewModel x) => x.Id.GetValueOrDefault() != 0 && x.Id.GetValueOrDefault() == userLastCId.GetValueOrDefault());
			if (num != -1)
			{
				list3[num].Value = isPublicForUsers;
			}
			else
			{
				list3.Add(new CommonSelectListItemViewModel
				{
					Id = userLastCId,
					Value = isPublicForUsers
				});
			}
			if (id > 0)
			{
				_dbII.CRMspUpdateUserReportFilter(id, groupId, fieldsJs, isPublic, JsonConvert.SerializeObject(list3), orderView, JsonConvert.SerializeObject(list), userId, value2, now, now.ToString("yyyyMMdd", new PersianCulture()), lCID, defLangID);
			}
			else
			{
				ObjectParameter objectParameter = new ObjectParameter("InsertedId", 0);
				Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)_dbII.CRMspInsertUserReportFilter(groupId, fieldsJs, isPublic, JsonConvert.SerializeObject(list3), orderView, JsonConvert.SerializeObject(list), userId, value, value2, now, now.ToString("yyyyMMdd", new PersianCulture()), appType, lCID, defLangID, objectParameter));
				if (objectParameter != null)
				{
					int result2 = 0;
					int.TryParse(objectParameter.Value.ToString(), out result2);
					_ = 0;
				}
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
			result = "Error: " + ex.Message;
		}
		return result;
	}

	[HttpPost]
	[LoginAuthorize]
	public string DeleteUserReportFilter(int id = 0)
	{
		string result = "";
		try
		{
			mct_II_Result mct_II_Result = Enumerable.FirstOrDefault<mct_II_Result>((IEnumerable<mct_II_Result>)_dbII.CRMspDeleteUserReportFilter(id));
			if (mct_II_Result != null && mct_II_Result.Result != 1)
			{
				result = Messages.MsgErrorDoneOperation;
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
	public string GetUsers(int? selectedId = null)
	{
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
			List<CRMspSelectActiveUsers_Result> list = Enumerable.ToList<CRMspSelectActiveUsers_Result>((IEnumerable<CRMspSelectActiveUsers_Result>)_db.CRMspSelectActiveUsers(lCID, result2, result3));
			if (list != null)
			{
				result = JsonConvert.SerializeObject(Enumerable.ToList<nComboBoxListItem>(Enumerable.Select<CRMspSelectActiveUsers_Result, nComboBoxListItem>((IEnumerable<CRMspSelectActiveUsers_Result>)list, (Func<CRMspSelectActiveUsers_Result, nComboBoxListItem>)((CRMspSelectActiveUsers_Result x) => new nComboBoxListItem
				{
					Text = x.Name,
					Value = x.UserId.ToString(),
					Selected = (x.UserId == selectedId)
				}))));
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return result;
	}

	public bool checkMultiLanguage(string defaultValue, List<CommonMultiLanguageViewModel> list)
	{
		bool result = true;
		List<CRMspSelectUserLanguages_Result> list2 = CRMIdeal.Cache.User.Language.Get();
		bool isCurrentUserAllowCopyOtherLanguage = UserLogin.IsCurrentUserAllowCopyOtherLanguage;
		foreach (Languages itemLang in CRMIdeal.Cache.Setting.Language.Get())
		{
			CommonMultiLanguageViewModel commonMultiLanguageViewModel = Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == itemLang.LanguageID));
			if (commonMultiLanguageViewModel == null)
			{
				if (Enumerable.Any<CRMspSelectUserLanguages_Result>((IEnumerable<CRMspSelectUserLanguages_Result>)list2, (Func<CRMspSelectUserLanguages_Result, bool>)((CRMspSelectUserLanguages_Result c) => c.LanguageID == itemLang.LanguageID)))
				{
					if (isCurrentUserAllowCopyOtherLanguage)
					{
						list.Add(new CommonMultiLanguageViewModel
						{
							LanguageId = itemLang.LanguageID,
							Value = defaultValue
						});
					}
					else
					{
						result = false;
					}
				}
				else
				{
					list.Add(new CommonMultiLanguageViewModel
					{
						LanguageId = itemLang.LanguageID,
						Value = defaultValue
					});
				}
			}
			else
			{
				if (!string.IsNullOrEmpty(commonMultiLanguageViewModel.Value))
				{
					continue;
				}
				if (Enumerable.Any<CRMspSelectUserLanguages_Result>((IEnumerable<CRMspSelectUserLanguages_Result>)list2, (Func<CRMspSelectUserLanguages_Result, bool>)((CRMspSelectUserLanguages_Result c) => c.LanguageID == itemLang.LanguageID)))
				{
					if (isCurrentUserAllowCopyOtherLanguage)
					{
						commonMultiLanguageViewModel.Value = defaultValue;
					}
					else
					{
						result = false;
					}
				}
				else
				{
					commonMultiLanguageViewModel.Value = defaultValue;
				}
			}
		}
		return result;
	}
}
